// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
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
                services.AddSingleton(meterProvider);

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
        private static AzureMonitorExporterOptions CreateCustomerSdkStatsOptions(AzureMonitorExporterOptions originalOptions)
        {
            return new AzureMonitorExporterOptions
            {
                ConnectionString = originalOptions.ConnectionString,
                Credential = originalOptions.Credential,
                DisableOfflineStorage = true, // Customer SDK stats should not use offline storage
                EnableStatsbeat = false, // Avoid statsbeat for customer SDK stats
                // Copy other relevant properties as needed
            };
        }
    }
}
