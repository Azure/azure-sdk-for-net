// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.Serialization;
using Azure.Monitor.OpenTelemetry.Exporter;

namespace Azure.Monitor.OpenTelemetry
{
    /// <summary>
    /// Options that allow users to configure the Azure Monitor OpenTelemetry.
    /// </summary>
    public class AzureMonitorOpenTelemetryOptions
    {
        /// <summary>
        /// Gets or sets a value of Azure Monitor Exporter Options.
        /// </summary>
        public AzureMonitorExporterOptions AzureMonitorExporterOptions { get; set; } = new AzureMonitorExporterOptions();

        /// <summary>
        /// The Connection String provides users with a single configuration setting to identify the Azure Monitor resource and endpoint.
        /// </summary>
        /// <remarks>
        /// (https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string).
        /// </remarks>
        public string ConnectionString
        {
            get
            {
                return AzureMonitorExporterOptions.ConnectionString;
            }
            set
            {
                AzureMonitorExporterOptions.ConnectionString = value;
            }
        }

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

        internal AzureMonitorOpenTelemetryOptions Clone(AzureMonitorOpenTelemetryOptions options)
        {
            if (options != null)
            {
                AzureMonitorExporterOptions = options.AzureMonitorExporterOptions;
                ConnectionString = options.ConnectionString;
                EnableLogs = options.EnableLogs;
                EnableMetrics = options.EnableMetrics;
                EnableTraces = options.EnableTraces;
            }

            return this;
        }
    }
}
