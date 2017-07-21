using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neustart.CrashWatchers
{
    public class SRCDS : CrashWatcher
    {
        private int m_Failures = 0;
        private IPEndPoint m_EndPoint;

        private readonly byte[] InfoRequest = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00 };

        public SRCDS(App application) : base(application)
        {
            string cmdLine = m_App.Config.Args;

            Match ipMatch = Regex.Match(cmdLine, @"-ip ((?:\d{1,3}\.){3}\d{1,3}\b)");
            Match portMatch = Regex.Match(cmdLine, @"-port ([0-9]+\b)");

            if (ipMatch.Success)
            {
                string ip = ipMatch.Groups[1].Value;
                int port = portMatch.Success ? Int32.Parse(portMatch.Groups[1].Value) : 27015;

                Debug.Log(string.Format("Querying srcds instance at {0}:{1} every 5 seconds", ip, port));

                m_EndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                Poll();
            } else
                Debug.Warning("Cannot start SRCDS monitoring because -ip was not specified in the launch parameters.");
        }

        private async void Poll()
        {
            int wait = 60000;
            while (!m_StopWorking)
            {
                if (wait > 0)
                {
                    wait -= 5000;
                    await Task.Delay(5000);

                    continue;
                }

                await Refresh();
                await Task.Delay(5000);
            }
        }

        private async Task Refresh()
        {
            if (m_StopWorking)
                return;

            using (UdpClient client = new UdpClient())
            {
                try
                {
                    Task queryTask = SendQuery(client);
                    Task timeout = Task.Delay(1000);
                    Task finished = await Task.WhenAny(queryTask, timeout);

                    if (!queryTask.IsCompleted)
                    {
                        m_Failures++;
                        Debug.Warning(m_App.Config.ID + ": SRCDS crash detection: " + m_Failures.ToString() + "/5");
                    }
                    else
                        m_Failures = 0;

                    if (m_Failures >= 5)
                        TriggerCrashMessage();

                    client.Dispose();
                }
                catch (Exception e)
                {
                    Debug.Warning(m_App.Config.ID + ": Failed to query SrcDS: " + e.Message);
                }
            }
        }

        private async Task SendQuery(UdpClient client)
        {
            await client.SendAsync(InfoRequest, InfoRequest.Length, m_EndPoint);
            await client.ReceiveAsync();
        }
    }
}
