// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats
{
    /// <summary>
    /// Provides registration methods for customer SDK statistics.
    /// </summary>
    internal static class CustomerSdkStatsRegistration
    {
        /// <summary>
        /// Registers customer SDK stats services if enabled via environment variables.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="options">Azure Monitor exporter options</param>
        public static void RegisterCustomerSdkStats(IServiceCollection services, AzureMonitorExporterOptions options)
        {
            if (!CustomerSdkStatsHelper.IsEnabled())
            {
                return;
            }

            try
            {
                // Create a separate MeterProvider for customer SDK stats with 15-minute interval
                var exportInterval = CustomerSdkStatsHelper.GetExportIntervalMilliseconds();

                var meterProvider = Sdk.CreateMeterProviderBuilder()
                    .AddMeter(CustomerSdkStatsMeters.MeterName)
                    .AddReader(new PeriodicExportingMetricReader(
                        new AzureMonitorMetricExporter(CreateCustomerSdkStatsOptions(options)),
                        exportIntervalMilliseconds: CustomerSdkStatsHelper.GetExportIntervalMilliseconds())
                        {
                            TemporalityPreference = MetricReaderTemporalityPreference.Delta
                        })
                    .Build();

                // Register the MeterProvider for disposal
                services.AddSingleton(new BackgroundMeterProviderDisposer(meterProvider));

                AzureMonitorExporterEventSource.Log.CustomerSdkStatsEnabled(exportInterval);
            }
            catch (Exception ex)
            {
                // Don't let customer SDK stats initialization affect main exporter
                AzureMonitorExporterEventSource.Log.CustomerSdkStatsInitializationFailed(ex);
            }
        }

        /// <summary>
        /// Creates Azure Monitor exporter options for customer SDK stats.
        /// Ensures customer SDK stats are disabled to prevent recursion.
        /// </summary>
        /// <param name="originalOptions">Original exporter options</param>
        /// <returns>Options configured for customer SDK stats</returns>
        internal static AzureMonitorExporterOptions CreateCustomerSdkStatsOptions(AzureMonitorExporterOptions originalOptions)
        {
            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = originalOptions.ConnectionString,
                Credential = originalOptions.Credential,
                EnableStatsbeat = false,
                EnableLiveMetrics = false,
            };

            // No network timeout override: transmitters are cached per connection string and these
            // stats share the customer's, so setting one here would either be discarded or, if this
            // ran first, impose a five second timeout on the customer's own telemetry.
            // BackgroundMeterProviderDisposer is what keeps the final export off the exit path.

            return options;
        }

        /// <summary>
        /// Registered in place of the meter provider itself. Disposing the provider exports one last
        /// time, and customer SDK stats have no offline storage behind them, so losing that export is
        /// preferable to holding up container teardown for an ingestion round trip.
        /// </summary>
        private sealed class BackgroundMeterProviderDisposer : IDisposable
        {
            private readonly MeterProvider _meterProvider;

            public BackgroundMeterProviderDisposer(MeterProvider meterProvider) => _meterProvider = meterProvider;

            public void Dispose()
            {
                var meterProvider = _meterProvider;

                _ = Task.Run(() =>
                {
                    try
                    {
                        meterProvider.Dispose();
                    }
                    catch (Exception)
                    {
                        // The process is going away; there is nothing useful to report.
                    }
                });
            }
        }
    }
}
