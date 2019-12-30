using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Exporter.Zipkin;
using OpenTelemetry.Trace;
using OpenTelemetry.Trace.Configuration;

namespace LineCounter
{
    public class Program
    {   public static void Main(string[] args)
        {

            using (TracerFactory.Create(builder => builder
                .AddDependencyCollector()
                .AddRequestCollector()))
            {
                CreateHostBuilder(args).Build().Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(
                    services => {
                        services.AddSingleton<IHostedService, LineCounterService>();
                    })
                .ConfigureAppConfiguration(builder=> builder.AddUserSecrets(typeof(Program).Assembly))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}