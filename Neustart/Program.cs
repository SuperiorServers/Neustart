using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Neustart
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Program
    {
        [JsonProperty]
        private static List<App> appList;
        private static Dictionary<string, App> appDictionary;

        private static string filePath = "Apps.json";

        private static Thread CrashThread;
        private static Thread InfoThread;
        public static Forms.Interface MainWindow { get; set; }

        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindow = new Forms.Interface();
            MainWindow.Show();

            LoadAppData();

            CrashThread = new Thread(CalcCrashes);
            CrashThread.Start();

            InfoThread = new Thread(CalcInfo);
            InfoThread.Start();

            Application.Run(MainWindow);

            return 0;
        }

        private static void LoadAppData()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            appDictionary = new Dictionary<string, App>();
            appList = JsonConvert.DeserializeObject<List<App>>(File.ReadAllText(filePath));

            foreach (App app in appList)
            {
                InitNewApp(app, false);
            }

            return;
        }

        public static void SaveAppData()
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(appList, Formatting.Indented));

            return;
        }

        private static void CalcCrashes()
        {
            while (MainWindow.Visible)
            {
                foreach (App app in appList)
                {
                    if (!app.Enabled || app.IsRestarting())
                        continue;

                    if (app.IsClosed() || app.IsCrashed())
                    {
                        app.Restart();
                        app.AddCrash();
                        SaveAppData();
                    }
                }
                Thread.Sleep(500);
            }
        }

        private static void CalcInfo()
        {
            while (MainWindow.Visible)
            {
                foreach (App app in appList)
                {
                    app.GetTitle();

                    if (!app.Enabled || app.IsClosed() || app.IsCrashed())
                        continue;
                    
                    app.GetUptime();
                    app.GetCPU();
                    app.GetRam();
                }

                Thread.Sleep(1000);
            }
        }

        public static List<App> GetApps()
        {
            return appList;
        }

        public static App GetAppByID(string id)
        {
            return appDictionary.ContainsKey(id) ? appDictionary[id] : null;
        }

        public static void InitNewApp(App app, bool created)
        {
            appDictionary[app.ID] = app;

            object[] rowData = new object[] { app.ID, app.ID, "0", "00:00:00", "0%", "0 MB", app.Enabled ? "Stop" : "Start", app.Hidden ? "Show" : "Hide", "Edit" };
            app.DataRow = MainWindow.AppsTable.Rows[MainWindow.AppsTable.Rows.Add(rowData)];

            app.Init();

            if (created)
            {
                appList.Add(app);
                SaveAppData();
            }
        }

        public static void RenameApp(string oldID, string newID)
        {
            appDictionary[newID] = appDictionary[oldID];
            appDictionary.Remove(oldID);

            appDictionary[newID].DataRow.Cells[1].Value = newID;
        }

        public static void RemoveApp(App app)
        {
            if (app.Enabled)
                app.Stop();

            MainWindow.AppsTable.Rows.Remove(app.DataRow);
            appDictionary.Remove(app.ID);
            appList.Remove(app);

            SaveAppData();
        }

        public static void Close()
        {
            CrashThread.Abort();
            InfoThread.Abort();
        }
    }
}
