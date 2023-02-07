// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Extension methods to simplify registering of Azure Monitor Metrics Exporter.
    /// </summary>
    public static class AzureMonitorExporterMetricExtensions
    {
        /// <summary>
        /// Adds Azure Monitor Metric exporter.
        /// </summary>
        /// <param name="builder"><see cref="MeterProviderBuilder"/> builder to use.</param>
        /// <param name="configure">Exporter configuration options.</param>
        /// <param name="credential"><see cref="TokenCredential" /></param>
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

            builder.AddMeter(StandardMetricConstants.StandardMetricMeterName);

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

                return new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions, credential))
                           { TemporalityPreference = MetricReaderTemporalityPreference.Delta };
            });
        }
    }
}
