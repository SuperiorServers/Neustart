using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Update
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(1000);

            try
            {
                string updateVersion = args[0];
                if (Directory.Exists("update_" + updateVersion))
                {
                    foreach (string path in Directory.GetFiles("update_" + updateVersion))
                    {
                        FileInfo inf = new FileInfo(path);
                        File.Delete(inf.Name);
                        inf.MoveTo(inf.Name);
                    }

                    Directory.Delete("update_" + updateVersion, true);
                }
            } catch(Exception) { }

            Process.Start("Neustart.exe");
        }
    }
}
