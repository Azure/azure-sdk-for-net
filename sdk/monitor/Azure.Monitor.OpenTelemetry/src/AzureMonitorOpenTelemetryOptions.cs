// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Monitor.OpenTelemetry.Exporter;

namespace Azure.Monitor.OpenTelemetry
{
    /// <summary>
    /// Options that allow users to configure the Azure Monitor OpenTelemetry.
    /// </summary>
    public class AzureMonitorOpenTelemetryOptions : AzureMonitorExporterOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether Traces should be enabled.
        /// </summary>
        public bool EnableTraces { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether Metrics should be enabled.
        /// </summary>
        public bool EnableMetrics { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether Logs should be enabled.
        /// </summary>
        public bool EnableLogs { get; set; } = true;
    }
}
