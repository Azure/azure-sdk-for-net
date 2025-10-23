// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// A hosted service responsible for registering the Azure Monitor Trace and Log Exporters.
    /// It also initializes Live Metrics if enabled.
    /// Note: The Metric Exporter is not registered here — it is directly handled.
    /// via the <see cref="OpenTelemetryBuilderExtensions.UseAzureMonitorExporter(IOpenTelemetryBuilder)"/> API.
    /// Unlike traces and logs, the order of metric instrumentation and exporters does not impact
    /// registration.
    /// Metrics should be registered using the <see cref="OpenTelemetryBuilderSdkExtensions.WithMetrics(IOpenTelemetryBuilder)"/> API.
    /// </summary>
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

            var tracerProvider = serviceProvider!.GetService<TracerProvider>();
            if (tracerProvider != null)
            {
                // Ensure that the AzureMonitorTraceExporter is registered only once
                serviceProvider!.EnsureSingleUseAzureMonitorExporterRegistration();

                // Add a processor manually to the TracerProvider created by the SDK
                var exporterOptions = serviceProvider!.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(Options.DefaultName);

                if (exporterOptions.EnableLiveMetrics)
                {
                    var manager = serviceProvider!.GetRequiredService<LiveMetricsClientManager>();
                    tracerProvider.AddProcessor(new LiveMetricsActivityProcessor(manager));
                }

                // TODO: Add Ai Sampler.
                tracerProvider.AddProcessor(new CompositeProcessor<Activity>(new BaseProcessor<Activity>[]
                {
                    new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(exporterOptions)),
                    new BatchActivityExportProcessor(new AzureMonitorTraceExporter(exporterOptions))
                }));
            }

            var loggerProvider = serviceProvider!.GetService<LoggerProvider>();
            if (loggerProvider != null)
            {
                // Ensure that the AzureMonitorLogExporter is registered only once
                serviceProvider!.EnsureSingleUseAzureMonitorExporterRegistration();

                // Add a processor manually to the LoggerProvider created by the SDK
                var exporterOptions = serviceProvider!.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(Options.DefaultName);
                var exporter = new AzureMonitorLogExporter(exporterOptions);

                BaseProcessor<LogRecord> baseProcessor = exporterOptions.EnableTraceBasedLogsSampler
                                                            ? new LogFilteringProcessor(exporter)
                                                            : new BatchLogRecordExportProcessor(exporter);

                if (exporterOptions.EnableLiveMetrics)
                {
                    var manager = serviceProvider!.GetRequiredService<LiveMetricsClientManager>();

                    loggerProvider.AddProcessor(new CompositeProcessor<LogRecord>(
                    [
                        new LiveMetricsLogProcessor(manager),
                        baseProcessor
                    ]));
                }
                else
                {
                    loggerProvider.AddProcessor(baseProcessor);
                }
            }
        }
    }
}
