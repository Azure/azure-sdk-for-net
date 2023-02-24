// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Azure.Monitor.OpenTelemetry
{
    /// <summary>
    /// Options that allow users to configure the Azure Monitor OpenTelemetry.
    /// </summary>
    public class AzureMonitorOpenTelemetryOptions
    {
        /// <summary>
        /// The Connection String provides users with a single configuration setting to identify the Azure Monitor resource and endpoint.
        /// </summary>
        /// <remarks>
        /// (https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string).
        /// </remarks>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Disable offline storage.
        /// </summary>
        public bool DisableOfflineStorage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Logs should be enabled.
        /// </summary>
        public bool EnableLogs { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether Metrics should be enabled.
        /// </summary>
        public bool EnableMetrics { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether Traces should be enabled.
        /// </summary>
        public bool EnableTraces { get; set; } = true;

        /// <summary>
        /// Override the default directory for offline storage.
        /// </summary>
        public string StorageDirectory { get; set; }

        internal AzureMonitorOpenTelemetryOptions Clone(AzureMonitorOpenTelemetryOptions options)
        {
            if (options != null)
            {
                ConnectionString = options.ConnectionString;
                DisableOfflineStorage = options.DisableOfflineStorage;
                EnableLogs = options.EnableLogs;
                EnableMetrics = options.EnableMetrics;
                EnableTraces = options.EnableTraces;
                StorageDirectory = options.StorageDirectory;
            }

            return this;
        }

        internal void SetValueToExporterOptions(IServiceProvider sp)
        {
            var exporterOptions = sp.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get("");
            exporterOptions.ConnectionString = ConnectionString;
            exporterOptions.DisableOfflineStorage = DisableOfflineStorage;
            exporterOptions.StorageDirectory = StorageDirectory;
        }
    }
}
