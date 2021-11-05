using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using OpenTelemetry.Collector.AspNetCore;
using OpenTelemetry.Collector.Dependencies;
using OpenTelemetry.Exporter.ApplicationInsights;
using OpenTelemetry.Stats;
using OpenTelemetry.Trace;
using OpenTelemetry.Trace.Sampler;

namespace CloudClipboard
{
    public class Program
    {
        public static IConfiguration Configuration { get; }

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: false)
                            .Build();
            // Enable distributed tracing
            string instrumentationKey = config["AZURE_INSTRUMENTATION_KEY"];

            new ApplicationInsightsExporter(Tracing.SpanExporter, Stats.ViewManager, new TelemetryConfiguration(instrumentationKey)).Start();
            using var dependencies = new DependenciesCollector(new DependenciesCollectorOptions(), Tracing.Tracer, Samplers.AlwaysSample);
            using var requests = new RequestsCollector(new RequestsCollectorOptions(), Tracing.Tracer, Samplers.AlwaysSample);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
