// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Metrics;
using System;
using Microsoft.Extensions.Options;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Extension methods to simplify registering of Azure Monitor Metrics Exporter.
    /// </summary>
    public static class AzureMonitorExporterMetricExtensions
    {
        private const int DefaultExportIntervalMilliseconds = 60000;
        private const int DefaultExportTimeoutMilliseconds = 30000;

        /// <summary>
        /// Adds <see cref="AzureMonitorMetricExporter"/> to the <see cref="MeterProviderBuilder"/>.
        /// </summary>
        /// <param name="builder"><see cref="MeterProviderBuilder"/> builder to use.</param>
        /// <param name="configureExporter">Exporter configuration options.</param>
        /// <returns>The instance of <see cref="MeterProviderBuilder"/> to chain the calls.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The objects should not be disposed.")]
        public static MeterProviderBuilder AddAzureMonitorMetricExporter(this MeterProviderBuilder builder, Action<AzureMonitorExporterOptions> configureExporter)
        {
            if (builder is IDeferredMeterProviderBuilder deferredMeterProviderBuilder)
            {
                return deferredMeterProviderBuilder.Configure((sp, innerBuilder) =>
                {
                    AddAzureMonitorMetricExporter(innerBuilder, sp.GetOptions(GetDefaultExportOptions), sp.GetOptions(GetDefaultReaderOptions), configureExporter, null);
                });
            }

            return AddAzureMonitorMetricExporter(builder, GetDefaultExportOptions(), GetDefaultReaderOptions(), configureExporter, null);
        }

        /// <summary>
        /// Adds <see cref="AzureMonitorMetricExporter"/> to the <see cref="MeterProviderBuilder"/>.
        /// </summary>
        /// <param name="builder"><see cref="MeterProviderBuilder"/> builder to use.</param>
        /// <param name="configureExporterAndMetricReader">Exporter and <see cref="MetricReader"/> configuration options.</param>
        /// <returns>The instance of <see cref="MeterProviderBuilder"/> to chain the calls.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The objects should not be disposed.")]
        public static MeterProviderBuilder AddAzureMonitorMetricExporter(
            this MeterProviderBuilder builder,
            Action<AzureMonitorExporterOptions, MetricReaderOptions> configureExporterAndMetricReader)
        {
            if (builder is IDeferredMeterProviderBuilder deferredMeterProviderBuilder)
            {
                return deferredMeterProviderBuilder.Configure((sp, innerBuilder) =>
                {
                    AddAzureMonitorMetricExporter(innerBuilder, sp.GetOptions(GetDefaultExportOptions), sp.GetOptions(GetDefaultReaderOptions), null, configureExporterAndMetricReader);
                });
            }

            return AddAzureMonitorMetricExporter(builder, GetDefaultExportOptions(), GetDefaultReaderOptions(), null, configureExporterAndMetricReader);
        }

        private static MeterProviderBuilder AddAzureMonitorMetricExporter(
            MeterProviderBuilder builder,
            AzureMonitorExporterOptions exporterOptions,
            MetricReaderOptions metricReaderOptions,
            Action<AzureMonitorExporterOptions> configureExporter,
            Action<AzureMonitorExporterOptions, MetricReaderOptions> configureExporterAndMetricReader)
        {
            if (configureExporterAndMetricReader != null)
            {
                configureExporterAndMetricReader.Invoke(exporterOptions, metricReaderOptions);
            }
            else
            {
                configureExporter?.Invoke(exporterOptions);
            }

            if (!exporterOptions.DisableOfflineStorage && exporterOptions.StorageDirectory == null)
            {
                exporterOptions.StorageDirectory = StorageHelper.GetDefaultStorageDirectory();
            }

            var metricExporter = new AzureMonitorMetricExporter(exporterOptions);

            var exportInterval = metricReaderOptions.PeriodicExportingMetricReaderOptions?.ExportIntervalMilliseconds
                ?? DefaultExportIntervalMilliseconds;

            var exportTimeout = metricReaderOptions.PeriodicExportingMetricReaderOptions?.ExportTimeoutMilliseconds
                ?? DefaultExportTimeoutMilliseconds;

            var metricReader = new PeriodicExportingMetricReader(metricExporter, exportInterval, exportTimeout)
            {
                TemporalityPreference = metricReaderOptions.TemporalityPreference,
            };

            return builder.AddReader(metricReader);
        }

        private static T GetOptions<T>(this IServiceProvider serviceProvider, Func<T> createDefaultOptions)
            where T : class, new()
        {
            IOptions<T> options = (IOptions<T>)serviceProvider.GetService(typeof(IOptions<T>));
            // Note: options could be null if user never invoked services.AddOptions().
            return options?.Value ?? createDefaultOptions();
        }

        private static AzureMonitorExporterOptions GetDefaultExportOptions()
        {
            return new AzureMonitorExporterOptions();
        }

        private static MetricReaderOptions GetDefaultReaderOptions()
        {
            return new MetricReaderOptions
            {
                TemporalityPreference = MetricReaderTemporalityPreference.Delta
            };
        }
    }
}
