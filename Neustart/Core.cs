using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO.Compression;
using System.IO;

namespace Neustart
{
    class Core
    {
        public static readonly string Version = Assembly.GetCallingAssembly().GetName().Version.ToString();

        public static List<ProcessPriorityClass> Priorities = new List<ProcessPriorityClass>
        {
            ProcessPriorityClass.Idle,
            ProcessPriorityClass.BelowNormal,
            ProcessPriorityClass.Normal,
            ProcessPriorityClass.AboveNormal,
            ProcessPriorityClass.High,
            ProcessPriorityClass.RealTime
        };

        private static bool     m_Terminate = false;
        public static bool ShouldTerminate()
            => m_Terminate;

        private static AppContainer m_AppContainer;
        public static AppContainer GetContainer()
            => m_AppContainer;

        public static bool UpdateAvailable = false;
        private static string m_UpdateZipPath;
        private static string m_UpdateVersion;

        private static bool AlreadyRunning()
        {
            foreach (Process process in Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName))
                if (process.Id != Process.GetCurrentProcess().Id)
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == Process.GetCurrentProcess().MainModule.FileName)
                        return true;

            return false;
        }

        [STAThread]
        static int Main(string[] args)
        {
            if (AlreadyRunning())
            {
                MessageBox.Show(null, "This copy of Neustart is already running. Look in your system tray!", "Neustart");
                return 0;

            }

            CleanupPostUpdate();

            if (args.Contains<string>("-debug"))
                Debug.Start();

            Application.SetCompatibleTextRenderingDefault(false);

            Forms.Main.OnInterfaceReady += (o, a) =>
            {
                Debug.Log("Interface ready, signaling application to begin");
                Run();
            };

            Forms.Main.OnInterfaceClosed += (o, a) =>
            {
                Debug.Log("Interface closed, signaling worker thread to die");
                m_Terminate = true;
            };

            Debug.Log("Creating interface window");

            Forms.Main mainWindow = new Forms.Main()
            {
                TopMost = false
            };
            mainWindow.Show();

            Application.Run(mainWindow);

            return 0;
        }

        private static void CleanupPostUpdate()
        {
            try
            {
                File.Delete("Update.exe");
                File.Delete("Update.exe.config");
            } catch(Exception) { }
        }

        public static void ForceQuit()
        {
            Debug.Log("Received signal to forcefully end.");

            if (Forms.Main.Get() != null)
                Forms.Main.Get().Close();
            else
                m_Terminate = true;
        }

        static void Run()
        {
            m_AppContainer = new AppContainer();

            System.Timers.Timer updateChecker = new System.Timers.Timer(2.16e+7); // 6 hours
            updateChecker.AutoReset = true;
            updateChecker.Elapsed += CheckUpdates;

            Task.Run(async() => CheckUpdates(null, null) );
        }

        private static void CheckUpdates(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.Log("Checking for updates.");
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string respData = wc.DownloadString(@"https://api.github.com/repos/SuperiorServers/Neustart/releases/latest");

                dynamic jsonRet = JsonConvert.DeserializeObject(respData);
                var jsonData = (JObject)jsonRet;

                string releaseVers = jsonData.SelectToken("tag_name").ToString().Substring(1);

                Debug.Log("Latest release: " + releaseVers);

                if (releaseVers == Version)
                {
                    Debug.Log("Neustart is currently up to date");
                    return;
                }

                string[] splitVers = releaseVers.Split('.');
                string[] splitCurVers = Version.Split('.');

                for (int i = 0; i < splitVers.Length; i++)
                {
                    if (Int32.Parse(splitVers[i]) < Int32.Parse(splitCurVers[i]))
                    {
                        Debug.Log("Neustart is currently up to date");
                        return;
                    }
                }

                Debug.Log("Update is available");

                m_UpdateZipPath = jsonData.SelectToken("assets[0].browser_download_url").ToString();
                m_UpdateVersion = releaseVers;
                UpdateAvailable = true;
            }
            catch (Exception ex)
            {
                Debug.Warning("Error checking for updates: " + ex.Message);
            }
        }

        public static void TriggerUpdate()
        {
            if (!UpdateAvailable)
                return;

            if (MessageBox.Show(null, "Are you sure you want to update? This will cause Neustart to restart itself.", "Neustart", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            UpdateAvailable = false;

            Debug.Log("Starting update.");

            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            wc.DownloadFileAsync(new Uri(m_UpdateZipPath), "neustart_update_package.zip");
            wc.DownloadFileCompleted += (o, e) => {
                Debug.Log("File downloaded. Decompressing.");

                using (ZipArchive archive = ZipFile.OpenRead("neustart_update_package.zip"))
                {
                    Directory.CreateDirectory("update_" + m_UpdateVersion);
                    archive.ExtractToDirectory("update_" + m_UpdateVersion);

                    if (File.Exists("update_" + m_UpdateVersion + "/Update.exe"))
                        File.Move("update_" + m_UpdateVersion + "/Update.exe", "Update.exe");

                    File.Delete("neustart_update_package.zip");

                    Process.Start("Update.exe", m_UpdateVersion);
                    Environment.Exit(0);
                }
            } ;
        }
    }
}
