using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EmployeeService
{
    public class Program
    {
        private static string _environmentName;
        public static void Main(string[] args)
        {
           // CreateWebHostBuilder(args).Build().Run();

            var webHost = CreateWebHostBuilder(args).Build();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile($"appsettings.{_environmentName}.json", optional: true, reloadOnChange: true)
                        .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, config) =>
            {
                config.ClearProviders();
                _environmentName = hostingContext.HostingEnvironment.EnvironmentName;
            })
                .UseStartup<Startup>();
    }
}
