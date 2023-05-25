namespace Client;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EventHubProcessors;
using Microsoft.Extensions.Logging;

/// <summary>
/// The application.
/// </summary>
internal class Program
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    internal static void Main(string[] args)
    {
        // create the host
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Debug);
            })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
            })
            .ConfigureServices((hostContext, services) =>
            {
                // add hosted services
                services.AddHostedService<AppLifecycle>();
                services.AddHostedService<Consumer>();

                // add services
                services.AddSingleton<IConfig, Config>();
                services.AddEventHubFixedPartitionProcessor<IConfig>();
            });

        host.Build().Run();
    }
}