// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
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
        /// Starts customer SDK stats collection if enabled via environment variables.
        /// </summary>
        /// <param name="options">Azure Monitor exporter options</param>
        public static void RegisterCustomerSdkStats(AzureMonitorExporterOptions options)
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

                // Deliberately not registered for disposal. This runs from a
                // ConfigureOpenTelemetryMeterProvider callback, which fires while the container is
                // being resolved, so anything added to the collection here is invisible to the
                // already-built provider and would never be disposed anyway. Leaving it to live for
                // the process lifetime also keeps its final export off the exit path; the reader's
                // own timer is what delivers these stats.
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
            // ran first, impose a five second timeout on the customer's own telemetry. Nothing
            // disposes this provider, so it never exports on the exit path either way.

            return options;
        }
    }
}
