// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Hosting;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using OpenTelemetry;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.DependencyInjection;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Microsoft.Extensions.Options;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal sealed class ExporterRegistrationHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public ExporterRegistrationHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Initialize(_serviceProvider);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private static void Initialize(IServiceProvider serviceProvider)
        {
            Debug.Assert(serviceProvider != null, "serviceProvider was null");

            // Note: For MeterProvider just do normal registration style and call
            // meterProviderBuilder.AddReader because the order doesn't matter for
            // metrics

            var tracerProvider = serviceProvider!.GetService<TracerProvider>();
            if (tracerProvider != null)
            {
                // Add a processor manually to the TracerProvider created by the SDK
                var exporterOptions = serviceProvider!.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(Options.DefaultName);
                tracerProvider.AddProcessor(new CompositeProcessor<Activity>(new BaseProcessor<Activity>[]
                {
                    new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(exporterOptions)),
                    new BatchActivityExportProcessor(new AzureMonitorTraceExporter(exporterOptions))
                }));
            }

            var loggerProvider = serviceProvider!.GetService<LoggerProvider>();
            if (loggerProvider != null)
            {
                // Add a processor manually to the LoggerProvider created by the SDK
                var exporterOptions = serviceProvider!.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(Options.DefaultName);
                loggerProvider.AddProcessor(new BatchLogRecordExportProcessor(new AzureMonitorLogExporter(exporterOptions)));
            }
        }
    }
}
