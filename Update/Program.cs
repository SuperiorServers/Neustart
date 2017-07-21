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

            if (Directory.Exists("update"))
            {
                foreach(string path in Directory.GetFiles("update"))
                {
                    try
                    {
                        FileInfo inf = new FileInfo(path);
                        File.Delete(inf.Name);
                        inf.MoveTo(inf.Name);
                    } catch(Exception) { }
                }

                Directory.Delete("update", true);
            }

            Process.Start("Neustart.exe");
        }
    }
}
