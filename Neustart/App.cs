using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace Neustart
{
    public class App
    {
        public static event EventHandler OnAppInitialized;

        public event EventHandler OnStarted;
        public event EventHandler OnStopped;
        public event EventHandler OnCrashed;

        private AppConfig m_Config;

        public App(AppConfig config)
        {
            m_Config = config;

            OnAppInitialized?.Invoke(this, null);

            if (m_Config.Enabled)
                Start();
        }

        public AppConfig Config { get => m_Config; }
        public bool Running { get => m_Config.Enabled; }
        public Process Process { get => m_Process; }

        private Process m_Process;
        private IntPtr  m_Hwnd;
        private CrashWatcher m_CrashWatcher;

        public void Start()
        {
            try
            {
                bool didResume = false;

                if (m_Config.PID != -1)
                {
                    try
                    {
                        Process proc = Process.GetProcessById(m_Config.PID);
                        if (proc.MainModule.FileName == m_Config.Path)
                        {
                            m_Process = proc;
                            m_Hwnd = new IntPtr(m_Config.HWND);

                            didResume = true;
                        }
                    }
                    catch (Exception) { }
                }

                if (!didResume)
                {
                    ProcessStartInfo inf = new ProcessStartInfo()
                    {
                        WorkingDirectory = System.IO.Path.GetDirectoryName(m_Config.Path),
                        Arguments = m_Config.Args,
                        FileName = m_Config.Path,
                        UseShellExecute = true
                    };

                    m_Process = Process.Start(inf);
                    m_Process.ProcessorAffinity = (IntPtr)m_Config.Affinities;
                    m_Process.PriorityClass = Core.Priorities[m_Config.Priority];
                    m_Process.WaitForInputIdle(1);

                    while (m_Process.MainWindowHandle.ToInt32() == 0) ;

                    m_Hwnd = m_Process.MainWindowHandle;
                    m_Config.HWND = m_Hwnd.ToInt32();

                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);
                        if (m_Config.Hidden)
                            ToggleHide(true);
                    });
                }

                m_Config.StartTime = m_Process.StartTime;
                m_Config.PID = m_Process.Id;

                m_CrashWatcher = CrashWatcher.New(this);
                m_CrashWatcher.OnCrashed += (o, e) => HandleCrash();

                if (!m_Config.Enabled)
                    m_Config.Enabled = true;
                
                OnStarted?.Invoke(this, null);
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred while starting " + m_Config.ID + ": " + e.Message + ". It has been disabled.", "Neustart");
                Debug.Error(m_Config.ID + ": Error starting: " + e.Message + ". Disabling.");

                m_Config.Enabled = false;
            }
        }

        public void Stop()
        {
            if (m_Config.Enabled)
                m_Config.Enabled = false;

            if (m_Process != null && !m_Process.HasExited)
                m_Process.Kill();
            m_Process = null;

            m_Config.Crashes = 0;

            OnStopped?.Invoke(this, null);
        }

        private void HandleCrash()
        {
            Debug.Warning(m_Config.ID + ": Crashed. Restarting..");

            Task.Run(async () =>
            {
                await Task.Delay(2000);

                Start();
                m_Config.Crashes++;

                OnCrashed?.Invoke(this, null);
            });
        }

        public void ToggleHide(bool noModify = false)
        {
            if (m_Process == null)
                return;

            if (!noModify)
                m_Config.Hidden = !m_Config.Hidden;

            ShowWindow(m_Hwnd, m_Config.Hidden ? 0 : 1);
            EnableWindow(m_Hwnd, m_Config.Hidden ? false : true);

            if (!m_Config.Hidden)
                Forms.Main.Get().BringToFront();
        }

        public void RefreshStatuses(ref Forms.Main.AppRowTemplate template)
        {
            if (Running)
            {
                template.Crashes = Config.Crashes;

                if (m_Process == null || m_Process.HasExited)
                {
                    template.Title = Config.ID + " | Starting";
                    template.Uptime = "00:00:00";
                    template.CPU = "0%";
                    template.Memory = "0 MB";
                } else
                {
                    m_Process.Refresh();

                    int capacity = GetWindowTextLength(new HandleRef(this, m_Hwnd)) * 2;
                    StringBuilder sBuilder = new StringBuilder(capacity);
                    GetWindowText(new HandleRef(this, m_Hwnd), sBuilder, sBuilder.Capacity);
                    template.Title = Config.ID + " | " + sBuilder.ToString();

                    double total = (DateTime.Now - m_Process.StartTime).TotalSeconds;
                    double hours = Math.Floor(total / 3600);
                    double minutes = Math.Floor((total % 3600) / 60);
                    double seconds = Math.Floor(total - (hours * 3600) - (minutes * 60));
                    template.Uptime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

                    try
                    {
                        System.Management.ManagementObjectSearcher searcher =
                            new System.Management.ManagementObjectSearcher("root\\CIMV2",
                            "SELECT * FROM Win32_PerfFormattedData_PerfProc_Process WHERE IDProcess=" + m_Process.Id);
                        System.Management.ManagementObjectCollection res = searcher.Get();

                        if (res.Count < 1)
                            throw new Exception("WMI query returned no results (couldn't find this process?");

                        foreach(System.Management.ManagementObject obj in res)
                        {
                            string procPercent = string.Format("{0}", obj["PercentProcessorTime"]);                            
                            template.CPU = ((double)Int32.Parse(procPercent) / Environment.ProcessorCount).ToString() + "%";
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Error("An error occurred while querying for WMI data: " + e.Message);
                        template.CPU = "0%";
                    }

                    template.Memory = (m_Process.WorkingSet64 / 1048576) + " MB";
                }
            }
            else
            {
                template.Title = Config.ID;
                template.Crashes = 0;
                template.Uptime = "00:00:00";
                template.CPU = "0%";
                template.Memory = "0 MB";
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr hwnd, bool enable);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowTextLength(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);
    }
}
