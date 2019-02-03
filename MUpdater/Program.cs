using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Update();
        }

        public static void Update()
        {
            Console.WriteLine("Updating MLauncher...");
            Console.WriteLine("Please wait...");
            var client = new WebClient();
            File.Delete("MLauncher.exe");
            Thread.Sleep(3000);
            client.DownloadFile("http://185.238.74.50/mlauncher/release/MLauncher.exe", "MLauncher.exe");
            System.Diagnostics.Process.Start("MLauncher.exe");
            return;
        }
    }
}
