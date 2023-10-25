// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Diagnostics;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Extension methods to simplify registering of Azure Monitor Exporter for all signals.
    /// </summary>
    public static class AzureMonitorExporterExtensions
    {
        /// <summary>
        /// Adds Azure Monitor Trace exporter to the TracerProvider.
        /// </summary>
        /// <param name="builder"><see cref="TracerProviderBuilder"/> builder to use.</param>
        /// <param name="configure">Callback action for configuring <see cref="AzureMonitorExporterOptions"/>.</param>
        /// <param name="credential">
        /// An Azure <see cref="TokenCredential" /> capable of providing an OAuth token.
        /// Note: if a credential is provided to both <see cref="AzureMonitorExporterOptions"/> and this parameter,
        /// the Options will take precedence.
        /// </param>
        /// <param name="name">Name which is used when retrieving options.</param>
        /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
        public static TracerProviderBuilder AddAzureMonitorTraceExporter(
            this TracerProviderBuilder builder,
            Action<AzureMonitorExporterOptions> configure = null,
            TokenCredential credential = null,
            string name = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var finalOptionsName = name ?? Options.DefaultName;

            if (name != null && configure != null)
            {
                // If we are using named options we register the
                // configuration delegate into options pipeline.
                builder.ConfigureServices(services => services.Configure(finalOptionsName, configure));
            }

            var deferredBuilder = builder as IDeferredTracerProviderBuilder;
            if (deferredBuilder == null)
            {
                throw new InvalidOperationException("The provided TracerProviderBuilder does not implement IDeferredTracerProviderBuilder.");
            }

            return deferredBuilder.Configure((sp, builder) =>
            {
                var exporterOptions = sp.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(finalOptionsName);
                if (name == null && configure != null)
                {
                    // If we are NOT using named options, we execute the
                    // configuration delegate inline. The reason for this is
                    // AzureMonitorExporterOptions is shared by all signals. Without a
                    // name, delegates for all signals will mix together. See:
                    // https://github.com/open-telemetry/opentelemetry-dotnet/issues/4043
                    configure(exporterOptions);
                }

                builder.SetSampler(new ApplicationInsightsSampler(exporterOptions.SamplingRatio));

                if (credential != null)
                {
                    // Credential can be set by either AzureMonitorExporterOptions or Extension Method Parameter.
                    // Options should take precedence.
                    exporterOptions.Credential ??= credential;
                }

                builder.AddProcessor(new CompositeProcessor<Activity>(new BaseProcessor<Activity>[]
                {
                    new StandardMetricsExtractionProcessor(new AzureMonitorMetricExporter(exporterOptions)),
                    new BatchActivityExportProcessor(new AzureMonitorTraceExporter(exporterOptions))
                }));
            });
        }

        /// <summary>
        /// Adds Azure Monitor Metric exporter.
        /// </summary>
        /// <param name="builder"><see cref="MeterProviderBuilder"/> builder to use.</param>
        /// <param name="configure">Exporter configuration options.</param>
        /// <param name="credential">
        /// An Azure <see cref="TokenCredential" /> capable of providing an OAuth token.
        /// Note: if a credential is provided to both <see cref="AzureMonitorExporterOptions"/> and this parameter,
        /// the Options will take precedence.
        /// </param>
        /// <param name="name">Name which is used when retrieving options.</param>
        /// <returns>The instance of <see cref="MeterProviderBuilder"/> to chain the calls.</returns>
        public static MeterProviderBuilder AddAzureMonitorMetricExporter(
            this MeterProviderBuilder builder,
            Action<AzureMonitorExporterOptions> configure = null,
            TokenCredential credential = null,
            string name = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var finalOptionsName = name ?? Options.DefaultName;

            if (name != null && configure != null)
            {
                // If we are using named options we register the
                // configuration delegate into options pipeline.
                builder.ConfigureServices(services => services.Configure(finalOptionsName, configure));
            }

            return builder.AddReader(sp =>
            {
                var exporterOptions = sp.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(finalOptionsName);

                if (name == null && configure != null)
                {
                    // If we are NOT using named options, we execute the
                    // configuration delegate inline. The reason for this is
                    // AzureMonitorExporterOptions is shared by all signals. Without a
                    // name, delegates for all signals will mix together. See:
                    // https://github.com/open-telemetry/opentelemetry-dotnet/issues/4043
                    configure(exporterOptions);
                }

                if (credential != null)
                {
                    // Credential can be set by either AzureMonitorExporterOptions or Extension Method Parameter.
                    // Options should take precedence.
                    exporterOptions.Credential ??= credential;
                }

                return new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions))
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta };
            });
        }

        /// <summary>
        /// Adds Azure Monitor Log Exporter with OpenTelemetryLoggerOptions.
        /// </summary>
        /// <param name="loggerOptions"><see cref="OpenTelemetryLoggerOptions"/> options to use.</param>
        /// <param name="configure">Exporter configuration options.</param>
        /// <param name="credential">
        /// An Azure <see cref="TokenCredential" /> capable of providing an OAuth token.
        /// Note: if a credential is provided to both <see cref="AzureMonitorExporterOptions"/> and this parameter,
        /// the Options will take precedence.
        /// </param>
        /// <returns>The instance of <see cref="OpenTelemetryLoggerOptions"/> to chain the calls.</returns>
        public static OpenTelemetryLoggerOptions AddAzureMonitorLogExporter(
            this OpenTelemetryLoggerOptions loggerOptions,
            Action<AzureMonitorExporterOptions> configure = null,
            TokenCredential credential = null)
        {
            if (loggerOptions == null)
            {
                throw new ArgumentNullException(nameof(loggerOptions));
            }

            var options = new AzureMonitorExporterOptions();
            configure?.Invoke(options);

            if (credential != null)
            {
                // Credential can be set by either AzureMonitorExporterOptions or Extension Method Parameter.
                // Options should take precedence.
                options.Credential ??= credential;
            }

            return loggerOptions.AddProcessor(new BatchLogRecordExportProcessor(new AzureMonitorLogExporter(options)));
        }
    }
}
