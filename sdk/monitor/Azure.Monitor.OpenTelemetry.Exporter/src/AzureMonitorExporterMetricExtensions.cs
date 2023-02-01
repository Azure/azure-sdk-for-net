// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using Azure.Core;
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
        /// <returns>The instance of <see cref="MeterProviderBuilder"/> to chain the calls.</returns>
        public static MeterProviderBuilder AddAzureMonitorMetricExporter(this MeterProviderBuilder builder, Action<AzureMonitorExporterOptions> configure = null, TokenCredential credential = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (builder is IDeferredMeterProviderBuilder deferredMeterProviderBuilder)
            {
                return deferredMeterProviderBuilder.Configure((sp, builder) =>
                {
                    AddAzureMonitorMetricExporter(builder, sp.GetOptions<AzureMonitorExporterOptions>(), configure, credential);
                });
            }

            return AddAzureMonitorMetricExporter(builder, new AzureMonitorExporterOptions(), configure, credential);
        }

        private static MeterProviderBuilder AddAzureMonitorMetricExporter(
            MeterProviderBuilder builder,
            AzureMonitorExporterOptions exporterOptions,
            Action<AzureMonitorExporterOptions> configure,
            TokenCredential credential)
        {
            configure?.Invoke(exporterOptions);
            return builder.AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions, credential))
                                    { TemporalityPreference = MetricReaderTemporalityPreference.Delta });
        }
    }
}
