using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Neustart
{
    class Debug
    {
        public static bool Enabled = false;
        public static void Start()
        {
            Enabled = true;

            if (!AttachConsole(-1))
                AllocConsole();

            var hRealOut = CreateFile("CONOUT$", GENERIC_READ | GENERIC_WRITE, FileShare.Write, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
            SetStdHandle(STD_OUTPUT_HANDLE, hRealOut);
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding) { AutoFlush = true });

            Console.Title = "Neustart";
            Console.WriteLine(string.Format("\nNeustart Debug Mode\nVersion {0}\n", Core.Version));
        }

        private static void WriteLine(string message)
        {
            if (!Enabled)
                return;

            Console.WriteLine(message);
        }

        public static void Log(string message) => WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString("MM/dd/yyyy HH:mm"), message));
        public static void Warning(string message) => Log(string.Format("[WARNING] {0}", message));
        public static void Error(string message) => Log(string.Format("[ERROR] {0}", message));

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();
        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetStdHandle(int nStdHandle, IntPtr hHandle);

        public const int STD_OUTPUT_HANDLE = -11;
        public const int STD_INPUT_HANDLE = -10;
        public const int STD_ERROR_HANDLE = -12;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPTStr)] string filename,
                                               [MarshalAs(UnmanagedType.U4)]     uint access,
                                               [MarshalAs(UnmanagedType.U4)]     FileShare share,
                                                                                 IntPtr securityAttributes,
                                               [MarshalAs(UnmanagedType.U4)]     FileMode creationDisposition,
                                               [MarshalAs(UnmanagedType.U4)]     FileAttributes flagsAndAttributes,
                                                                                 IntPtr templateFile);

        public const uint GENERIC_WRITE = 0x40000000;
        public const uint GENERIC_READ = 0x80000000;
    }
}
