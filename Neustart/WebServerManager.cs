using System;
using System.Net;
using System.Threading;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Neustart.Forms.Main;

namespace Neustart
{
    /**
     * Class based on https://codehosting.net/blog/BlogEngine/post/Simple-C-Web-Server
     * By: David
     * Licence: https://codehosting.net/blog/files/MITlicense.txt
     */
    class SimpleWebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, string> _responderMethod;
        public delegate void StatusMessageEventHandler(string status);
        public event StatusMessageEventHandler StatusMessage;

        public SimpleWebServer(string[] prefixes, Func<HttpListenerRequest, string> method)
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");

            // URI prefixes are required
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // A responder method is required
            if (method == null)
                throw new ArgumentException("method");

            foreach (string s in prefixes)
                _listener.Prefixes.Add(s);

            _responderMethod = method;
            try
            {
                _listener.Start();
            }
            catch (HttpListenerException ex)
            {
                if (ex.Message.Contains("Access is denied"))
                {
                    UpdateStatusMessage("Access is denied to port, try running as administrator");
                }
                else
                {
                    throw;
                }
            }
        }

        public SimpleWebServer(Func<HttpListenerRequest, string> method, params string[] prefixes)
            : this(prefixes, method) { }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                UpdateStatusMessage("Webserver running");
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                string rstr = _responderMethod(ctx.Request);
                                byte[] buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch { } // suppress any exceptions
                            finally
                            {
                                // always close the stream
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch { } // suppress any exceptions
            });
        }

        public void Stop()
        {
            UpdateStatusMessage("Webserver stopped");
            _listener.Stop();
            _listener.Close();
        }

        void UpdateStatusMessage(string status)
        {
            StatusMessage?.Invoke(status);
        }
    }

    public static class WebServer
    {
        static SimpleWebServer ws;

        public static void Start()
        {
            ws = new SimpleWebServer(SendResponse, "http://*:4096/");
            ws.StatusMessage += StatusMessage;
            ws.Run();
        }

        public static void Stop()
        {
            ws.Stop();
        }

        private static void StatusMessage(string status)
        {
            Forms.Main.WebserverStatusMessage = status;
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            string bodyHTML = "";
            bodyHTML += "<!DOCTYPE html><html lang='en'><head>" +
                "<meta charset='utf-8'>" +
                "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
                "<meta name='viewport' content = 'width=device-width, initial-scale=1'>" +
                "<title>Neustart web management</title>" +
                "<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>" +
                "<!--[if lt IE 9]><script src='https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js'></script><script src='https://oss.maxcdn.com/respond/1.4.2/respond.min.js'></script><![endif]-->" +
                "<script src='https://code.jquery.com/jquery-3.2.1.min.js' integrity='sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4=' crossorigin='anonymous'></script>" +
                "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' integrity='sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa' crossorigin='anonymous'></script>" +
                "<script>function ajax(url){$.get(url, function(data) {alert(data);});}</script>" +
                "</head><body>";

            if (request.RawUrl.StartsWith("/stop/"))
            {
                var serverId = request.RawUrl.Remove(0, 6);
                App app = m_AppRowDictionary.FirstOrDefault(x => x.Key.Config.ID == serverId).Key;
                if (app.Config.Enabled)
                {
                    app.Stop();
                    return "Stopped server";
                }
            }
            else if (request.RawUrl.StartsWith("/start/"))
            {
                var serverId = request.RawUrl.Remove(0, 7);
                App app = m_AppRowDictionary.FirstOrDefault(x => x.Key.Config.ID == serverId).Key;
                if (!app.Config.Enabled)
                {
                    app.Start();
                    return "Started server";
                }
            }
            else if (request.RawUrl == "/")
            {
                bodyHTML += "<div class='container-fluid'>" +
                    "<table class='table table-striped'><thead><tr><th>Name</th><th>Crashes</th><th>Uptime</th><th>CPU</th><th>Memory</th><th style='width:55px;'></th><th style='width:65px;'></th></tr></thead><tbody>";
                
                foreach (var entry in m_AppRowDictionary)
                {
                    App app = entry.Key;
                    DataGridViewRow row = entry.Value.row;
                    string appID = app.Config.ID;

                    string statusButton = "<button class='btn btn-success' onclick='ajax(\"/start/" + appID + "\");'>Start</button>";
                    if (app.Config.Enabled)
                    {
                        statusButton = "<button class='btn btn-danger' onclick='ajax(\"/stop/" + appID + "\");'>Stop</button>";
                    }

                    bodyHTML += "<tr><th>" + row.Cells[1].Value + "</th><td>" + row.Cells[2].Value + "</td><td>" + row.Cells[3].Value + "</td><td>" + row.Cells[4].Value + "</td><td>" + row.Cells[5].Value + "</td><td>" + statusButton + "</td><td><a class='btn btn-primary' href='#' role='button'><span class='glyphicon glyphicon-pencil' aria-hidden='true'></span> Edit</a></td></tr>";
                }

                bodyHTML += "</tbody></table></div>";
            }
            else
            {
                bodyHTML += "<h2>Not Found</h2><hr><p>HTTP Error 404. The requested resource was not found.</p>";
            }

            bodyHTML += "</body></html>";
            return bodyHTML;
        }
    }
}
