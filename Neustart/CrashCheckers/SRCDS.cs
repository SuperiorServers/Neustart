using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neustart.CrashCheckers
{
    public class SRCDS : CrashChecker
    {
        int QueryFailures = 0;
        Thread QueryWorker;
        IPEndPoint EndPoint;

        private readonly byte[] InfoRequest = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00 };

        public SRCDS(App application) : base(application)
        {
            string cmdLine = Application.Args;

            Match ipMatch = Regex.Match(cmdLine, @"-ip ((?:\d{1,3}\.){3}\d{1,3}\b)");
            Match portMatch = Regex.Match(cmdLine, @"-port ([0-9]+\b)");

            if (ipMatch.Success)
            {
                EndPoint = new IPEndPoint(IPAddress.Parse(ipMatch.Groups[1].Value), portMatch.Success ? Int32.Parse(portMatch.Groups[1].Value) : 27015);
                QueryWorker = new Thread(Poll);
                QueryWorker.Start();
            }
        }

        public override void StopWatching()
        {
            if (QueryWorker != null)
                QueryWorker.Abort();

            QueryWorker = null;
        }

        protected override bool IsCrashedAppSpecific()
        {
            return QueryFailures >= 5; // After roughly 25 seconds, we declare SrcDS officially hung
        }

        private async void Poll()
        {
            Thread.Sleep(60000); // Wait 60 seconds on startup to provide ample time for server to begin responding

            while (true)
            {
                if (QueryWorker == null)
                    break;

                await Refresh();

                Thread.Sleep(5000); // Wait 5 seconds between each query
            }
        }

        private async Task Refresh()
        {
            using (UdpClient client = new UdpClient())
            {
                try
                {
                    Task queryTask = SendQuery(client);
                    Task timeout = Task.Delay(1000);
                    Task finished = await Task.WhenAny(queryTask, timeout);

                    if (!queryTask.IsCompleted)
                        QueryFailures++;
                    else
                        QueryFailures = 0;

                    client.Dispose();
                }
                catch (Exception e)
                {
                    LogError("Failed to query SrcDS: " + e.Message);
                }
            }
        }

        private async Task SendQuery(UdpClient client)
        {
            await client.SendAsync(InfoRequest, InfoRequest.Length, EndPoint);
            await client.ReceiveAsync();
        }
    }
}
