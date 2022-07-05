// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Metrics;
using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Extension methods to simplify registering of Azure Monitor Metrics Exporter.
    /// </summary>
    internal static class AzureMonitorStatsBeatMetricExtensions
    {
        /// <summary>
        /// Adds Azure Monitor Metric exporter.
        /// </summary>
        /// <param name="builder"><see cref="MeterProviderBuilder"/> builder to use.</param>
        /// <param name="configure">Exporter configuration options.</param>
        /// <returns>The instance of <see cref="MeterProviderBuilder"/> to chain the calls.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The objects should not be disposed.")]
        internal static MeterProviderBuilder AddAzureMonitorStatsBeatExporter(this MeterProviderBuilder builder, Action<AzureMonitorExporterOptions> configure = null)
        {
            var options = new AzureMonitorExporterOptions();
            configure?.Invoke(options);

            return builder.AddReader(new PeriodicExportingMetricReader(new AzureMonitorStatsBeatExporter(options), options.StatsBeatInterval)
            { TemporalityPreference = MetricReaderTemporalityPreference.Delta });
        }
    }
}
