using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Neustart
{
    public class CrashChecker
    {
        public static Dictionary<string, Type> Handlers = new Dictionary<string, Type>
        {
           {"srcds", typeof(CrashCheckers.SRCDS) }
        };

        public static CrashChecker CreateNew(App app)
        {
            if (Handlers.ContainsKey(app.Process.ProcessName))
                return (CrashChecker)Activator.CreateInstance(Handlers[app.Process.ProcessName], app);

            return new CrashChecker(app);
        }

        private int FrozenInterval = 0;
        protected App Application;
        protected virtual bool IsCrashedAppSpecific() => false;
        public virtual void StopWatching() { }

        public CrashChecker(App application)
        {
            Application = application;
        }

        public bool IsCrashed()
        {
            if (IsCrashedAppSpecific())
                return true;

            if (Application.Process.Responding)
                FrozenInterval = Math.Max(FrozenInterval - 1, 0);
            else
                FrozenInterval++;

            return FrozenInterval >= 10;
        }

        public void LogError(string message)
        {
            Application.LogError("[CrashChecker] " + message);
        }
    }
}