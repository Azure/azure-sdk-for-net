// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Metrics;
using System;

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
        /// <returns>The instance of <see cref="MeterProviderBuilder"/> to chain the calls.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The objects should not be disposed.")]
        public static MeterProviderBuilder AddAzureMonitorMetricExporter(this MeterProviderBuilder builder, Action<AzureMonitorExporterOptions> configure = null)
        {
            var options = new AzureMonitorExporterOptions();
            configure?.Invoke(options);

            // TODO: Fallback to default location if location provided via options does not work.
            if (!options.DisableOfflineStorage && options.StorageDirectory == null)
            {
                options.StorageDirectory = StorageHelper.GetDefaultStorageDirectory();
            }

            var exporter = new AzureMonitorMetricExporter(options);

            return builder.AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(options))
            { TemporalityPreference = MetricReaderTemporalityPreference.Delta });
        }
    }
}
