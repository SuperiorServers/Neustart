using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Neustart
{
    public static class Util
    {
        public static void LogError(string message)
        {
            File.AppendAllText("error.log", message + Environment.NewLine);
        }
    }
}
