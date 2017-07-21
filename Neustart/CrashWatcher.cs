using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Neustart
{
    public class CrashWatcher
    {
        public event EventHandler OnCrashed;

        public static Dictionary<string, Type> Handlers = new Dictionary<string, Type>
        {
           {"srcds", typeof(CrashWatchers.SRCDS) }
        };

        public static CrashWatcher New(App app)
        {
            if (Handlers.ContainsKey(app.Process.ProcessName))
            {
                Debug.Log(app.Config.ID + ": Applying " + app.Process.ProcessName + "-specific crash watching.");

                return (CrashWatcher)Activator.CreateInstance(Handlers[app.Process.ProcessName], app);
            }

            return new CrashWatcher(app);
        }

        private int m_FrozenInterval = 0;

        protected App m_App;
        protected bool m_StopWorking;

        protected virtual bool IsCrashedAppSpecific() => false;

        public CrashWatcher(App application)
        {
            m_App = application;

            m_App.OnStopped += (o, e) => m_StopWorking = true;

            PollBasic();
        }

        private async void PollBasic()
        {
            int wait = 60000;
            while (!m_StopWorking)
            {
                if (m_App.Process.HasExited)
                {
                    TriggerCrashMessage();
                    continue;
                }

                if (wait > 0)
                {
                    wait -= 5000;
                    await Task.Delay(5000);

                    continue;
                }

                if (m_App.Process.Responding)
                    m_FrozenInterval = Math.Max(m_FrozenInterval - 1, 0);
                else
                {
                    m_FrozenInterval++;
                    Debug.Warning(m_App.Config.ID + ": Basic crash detection: " + m_FrozenInterval.ToString() + "/10");
                }

                if (m_FrozenInterval >= 10)
                    TriggerCrashMessage();
                else
                    await Task.Delay(5000);
            }
        }

        protected void TriggerCrashMessage()
        {
            m_StopWorking = true;
            OnCrashed?.Invoke(this, null);
        }
    }
}