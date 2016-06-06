using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Timers;

namespace Neustart
{
    [JsonObject(MemberSerialization.OptIn)]
    public class App
    {
        private static List<ProcessPriorityClass> Priorities = new List<ProcessPriorityClass>()
        {
            ProcessPriorityClass.Idle,
            ProcessPriorityClass.BelowNormal,
            ProcessPriorityClass.Normal,
            ProcessPriorityClass.AboveNormal,
            ProcessPriorityClass.High,
            ProcessPriorityClass.RealTime
        };

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr hwnd, bool enable);
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);
        
        [JsonProperty]
        public string   ID          { get; set; }
        [JsonProperty]
        public bool     Enabled     { get; set; }
        [JsonProperty]
        public bool     Hidden      { get; set; } = false;
        [JsonProperty]
        public string   Path        { get; set; }
        [JsonProperty]
        public string   Args        { get; set; }
        [JsonProperty]
        public int      Affinities  { get; set; }
        [JsonProperty]
        public int      Priority { get; set; } = 2;
        [JsonProperty]
        public int      PID         { get; set; } = -1;
        [JsonProperty]
        public DateTime StartTime   { get; set; }
        [JsonProperty]
        public int      Crashes     { get; set; } = 0;

        public string   WindowName  { get; set; }
        public Process  Process     { get; set; }

        public DataGridViewRow DataRow { get; set; }

        public PerformanceCounter CPUCounter { get; set; }
        public PerformanceCounter RamCounter { get; set; }
        public int FrozenInterval = 0;

        public System.Timers.Timer RestartTimer { get; set; }

        public void Init()
        {
            WindowName = ID;

            if (Enabled)
                Start();

            DataRow.Cells[2].Value = Crashes;
        }

        public bool Start()
        {
            try {
                bool resumed = false;

                if (PID != -1)
                {
                    try
                    {
                        Process = Process.GetProcessById(PID);

                        if (Process.StartTime != StartTime)
                            throw new Exception();

                        resumed = true;
                    } catch { } // We'll have to start a new instance

                    PID = -1;
                    StartTime = DateTime.MinValue;
                }

                if (!resumed)
                {
                    Process = Process.Start(Path, Args);
                   
                    Process.ProcessorAffinity = (IntPtr)Affinities;
                    Process.PriorityClass = Priorities[Priority];

                    Process.WaitForInputIdle();

                    StartTime = Process.StartTime;
                }

                HandleHide();

                DataRow.Cells[6].Value = "Stop";

                return true;
            } catch (Exception e)
            {
                MessageBox.Show("An error occurred while starting " + ID + ". It has been disabled.", "Neustart");

                Enabled = false;
                DataRow.Cells[6].Value = "Start";

                return false;
            }
        }

        public void Restart()
        {
            WindowName = "Restarting...";
            DataRow.Cells[1].Value = WindowName;

            RestartTimer = new System.Timers.Timer(3000);
            RestartTimer.Elapsed += _Restart;
            RestartTimer.AutoReset = false;
            RestartTimer.Enabled = true;
        }

        public void _Restart(Object source, ElapsedEventArgs e)
        {
            Start();
            RestartTimer = null;
        }

        public void Stop()
        {
            if (Process == null)
                return;

            Process.CloseMainWindow();
            Process.Close();

            DataRow.Cells[1].Value = ID;
            DataRow.Cells[6].Value = "Start";

            Process = null;
        }

        public string GetProcessName()
        {
            var processes = Process.GetProcessesByName(Process.ProcessName);

            int count = -1;
            foreach (Process proc in processes)
            {
                count++;
                if (proc.Id == Process.Id)
                {
                    if (count == 0)
                        return Process.ProcessName;
                    else
                        return Process.ProcessName + "#" + count;
                }
            }
            return Process.ProcessName + "#" + processes.Length;
        }

        public void GetTitle()
        {
            if (IsRestarting())
            {
                WindowName = "Restarting...";
            }
            else if (Process != null)
            {
                IntPtr hwnd = Process.MainWindowHandle;

                int capacity = GetWindowTextLength(new HandleRef(this, hwnd)) * 2;
                StringBuilder sBuilder = new StringBuilder(capacity);

                GetWindowText(new HandleRef(this, hwnd), sBuilder, sBuilder.Capacity);

                WindowName = sBuilder.ToString();
            }
            else
            {
                WindowName = ID;
            }
            DataRow.Cells[1].Value = WindowName;
        }

        public void GetUptime()
        {
            if (Process != null)
                DataRow.Cells[3].Value = (DateTime.Now - Process.StartTime).ToString(@"hh\:mm\:ss");
        }

        public void GetCPU() // TODO, make this more accurate? Is that even possible?
        {
            if (Process != null)
            {
                try {
                    var currentprocname = GetProcessName();
                    if (CPUCounter == null || (CPUCounter.InstanceName != currentprocname))
                        CPUCounter = new PerformanceCounter("Process", "% Processor Time", currentprocname);

                    DataRow.Cells[4].Value = Math.Round(CPUCounter.NextValue(), 1) + "%";
                } catch (Exception) { }
            }

        }

        public void GetRam()
        {
            if (Process != null)
            {
                try {
                    var currentprocname = GetProcessName();
                    if (RamCounter == null || (RamCounter.InstanceName != currentprocname))
                        RamCounter = new PerformanceCounter("Process", "Working Set", currentprocname);

                    DataRow.Cells[5].Value = Math.Round(RamCounter.NextValue() / 1024 / 1024, 1) + " MB";
                } catch(Exception) { }
            }
               
        }

        public bool IsClosed()
        {
            if (Process == null)
                return false;

            return Process.HasExited;
        }

        public bool IsCrashed()
        {
            if (Process == null)
                return false;

            if (Process.Responding)
                FrozenInterval = 0;
            else
                FrozenInterval++;

            return FrozenInterval >= 10;
        }

        public bool IsRestarting()
        {
        }

        public bool ToggleHide()
        {
            if (!Enabled)
                return Hidden;

            Hidden = !Hidden;

            HandleHide();

            DataRow.Cells[7].Value = Hidden ? "Show" : "Hide";

            return Hidden;
        }

        private void HandleHide()
        {
            if (Process == null)
                return;

            IntPtr hwnd = Process.MainWindowHandle;

            ShowWindow(hwnd, Hidden ? 0 : 1);
            EnableWindow(hwnd, Hidden ? false : true);
        }

        public void PrepareForResume()
        {
            if (Process != null)
                PID = Process.Id;
        }

        public void ResetCrashes()
        {
            Crashes = 0;
            DataRow.Cells[2].Value = Crashes;
        }

        public void AddCrash()
        {
            Crashes++;
            DataRow.Cells[2].Value = Crashes;
        }
    }
}
