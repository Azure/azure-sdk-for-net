// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Traces
{
    internal sealed class UseAzureMonitorExporterDemo : IDisposable
    {
        private const string ActivitySourceName = "MyCompany.MyProduct.MyLibrary.UseAzureMonitorExporter";
        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

        private readonly ServiceProvider _serviceProvider;

        public UseAzureMonitorExporterDemo(string connectionString)
        {
            Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_SDKSTATS_DISABLED", "false");
            // Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_SDKSTATS_EXPORT_INTERVAL", "60");

            var services = new ServiceCollection();

            services.AddOpenTelemetry()
                .UseAzureMonitorExporter(options =>
                {
                    options.ConnectionString = connectionString;
                    options.TracesPerSecond = null;
                    options.SamplingRatio = 1.0F;
                })
                .WithTracing(tracerProviderBuilder =>
                {
                    tracerProviderBuilder.AddSource(ActivitySourceName);
                });

            _serviceProvider = services.BuildServiceProvider();

            // Force provider creation so listeners are active.
            _ = _serviceProvider.GetRequiredService<TracerProvider>();

            // Manually start hosted services (including ExporterRegistrationHostedService)
            // since we don't have a full IHost.
            foreach (var service in _serviceProvider.GetServices<IHostedService>())
            {
                service.StartAsync(CancellationToken.None).GetAwaiter().GetResult();
            }
        }

        public void GenerateTrace()
        {
            using var activity = s_activitySource.StartActivity("MinimalUseAzureMonitorExporterTrace", ActivityKind.Client);
            Console.WriteLine($"Activity created: {activity != null}");
            if (activity != null)
            {
                activity.SetTag("demo.kind", "minimal");
                activity.SetStatus(ActivityStatusCode.Ok);
                Console.WriteLine($"Activity ID: {activity.Id}");
                Console.WriteLine($"Activity Source: {activity.Source.Name}");
            }
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}
