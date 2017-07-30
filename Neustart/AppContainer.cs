using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Timers;

namespace Neustart
{
    public class AppContainer
    {
        public static event EventHandler OnLoadCompleted;

        private List<AppConfig> m_ConfigContainer;
        private List<App> m_AppContainer = new List<App>();
        private System.Timers.Timer m_SaveTimer;

        private string configPath = "Apps.json";

        public AppContainer()
        {
            Debug.Log("App container created");

            LoadConfig();
        }

        private bool LoadConfig()
        {
            Debug.Log("Loading configurations");
            string configString = File.Exists(configPath) ? File.ReadAllText(configPath) : "[]";

            try
            {
                m_ConfigContainer = JsonConvert.DeserializeObject<List<AppConfig>>(configString);


                Debug.Log("Loaded. Now populating App container and initializing apps.");
                foreach (AppConfig appConfig in m_ConfigContainer)
                    SetupApp(appConfig);

                AppConfig.OnConfiguationChanged += SaveConfig;
                SaveConfig(this, null);

                OnLoadCompleted?.Invoke(this, null);
            } catch(Exception e)
            {
                Debug.Error("Couldn't load Neustart config: " + e.Message);

                if (MessageBox.Show(null, "Configuration file is corrupt. Would you like to reset it?", "Neustart", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    File.Move(configPath, configPath + ".bak");

                    Debug.Warning("Configuration file has been deleted. Trying again..");

                    return LoadConfig();
                } else
                {
                    Debug.Error("Cannot proceed.");

                    MessageBox.Show(null, "Please inspect " + configPath + " for JSON errors and correct them. Neustart will now close.", "Neustart");

                    Core.ForceQuit();

                    return false;
                }
            }

            return true;
        }

        private void SaveConfig(object sender, EventArgs e)
        {
            if (sender != this && !m_ConfigContainer.Contains(sender))
                return;

            if (m_SaveTimer != null && m_SaveTimer.Enabled) // Just restart the timer we have instead of creating a new one
            {
                m_SaveTimer.Stop();
                m_SaveTimer.Start();
                return;
            }

            m_SaveTimer = new System.Timers.Timer(250);
            m_SaveTimer.AutoReset = false;
            m_SaveTimer.Elapsed += async (o, args) =>
            {
                Debug.Log("AppConfig modified - saving.");

                string jsonData = JsonConvert.SerializeObject(m_ConfigContainer, Formatting.Indented);
                File.WriteAllText(configPath, jsonData);

                m_SaveTimer.Stop();
            };
            m_SaveTimer.Start();
        }

        public void SetupApp(AppConfig appConfig, bool isNew = false)
        {
            if (isNew)
            {
                m_ConfigContainer.Add(appConfig);
                SaveConfig(this, null);
            }

            App app = new App(appConfig);
            m_AppContainer.Add(app);
        }

        public void DeleteApp(App app)
        {
            Forms.Main.Get().AppDeleted(app);

            app.Stop();
            m_ConfigContainer.Remove(app.Config);
            m_AppContainer.Remove(app);

            SaveConfig(this, null);

            Debug.Log("Deleted app: " + app.Config.ID);
        }

        public App GetAppByID(string id)
        {
            foreach(App app in m_AppContainer)
            {
                if (app.Config.ID == id)
                    return app;
            }

            return null;
        }
    }
}
