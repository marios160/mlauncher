using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using MLauncherServer.Core.Configuration;
using Newtonsoft.Json;
using NLog;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MLauncherServer.Core
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetLogger(nameof(Program));

        static void Main(string[] args)
        {
            var appConfiguration = JsonConvert.DeserializeObject<Appconfiguration>(File.ReadAllText
                ($@"{AppDomain.CurrentDomain.BaseDirectory}\appsettings.json"));
            try
            {

                IWebHost host;
                if (Debugger.IsAttached || args.Contains("console"))
                {
                    Logger.Info("Starting application with debug mode");
                    Debugger.Launch();
                    host = WebHost.CreateDefaultBuilder()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>()
                        .Build();
                    host.Run();
                }
                else
                {
                    Logger.Info("Starting application as service without debug mode");
                    host = WebHost.CreateDefaultBuilder(args)
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>()
                        .Build();

                    host.RunAsService();
                }
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
                throw;
            }
        }
    }
}
