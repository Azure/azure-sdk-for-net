// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal class AzureMonitorLiveMetricsOptions : ClientOptions
    {
        public AzureMonitorLiveMetricsOptions()
        {
            // users can explicitly change it, but by default we don't want internal logs to be reported to Azure Monitor.
            this.Diagnostics.IsDistributedTracingEnabled = false;
            this.Diagnostics.IsLoggingEnabled = false;
        }

        /// <summary>
        /// The Connection String provides users with a single configuration setting to identify the Azure Monitor resource and endpoint.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string"/>.
        /// </remarks>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Get or sets the value of <see cref="TokenCredential" />.
        /// If <see cref="TokenCredential" /> is not set, AAD authentication is disabled
        /// and Instrumentation Key from the Connection String will be used.
        /// </summary>
        /// <remarks>
        /// <see href="https://learn.microsoft.com/en-us/azure/azure-monitor/app/sdk-connection-string?tabs=net#is-the-connection-string-a-secret"/>.
        /// </remarks>
        public TokenCredential Credential { get; set; }

        /// <summary>
        /// Enables or disables the Live Metrics feature. This property is enabled by default.
        /// Note: Enabling Live Metrics incurs no additional billing or costs. However, it does introduce
        /// a performance overhead due to extra data collection, processing, and networking calls. This overhead
        /// is only significant when the LiveMetrics portal is actively used in the UI. Once the portal is closed,
        /// LiveMetrics reverts to a 'silent' mode with minimal to no overhead.
        /// <see href="https://learn.microsoft.com/azure/azure-monitor/app/live-stream?tabs=dotnet6"/>.
        /// </summary>
        public bool EnableLiveMetrics { get; set; } = true;
    }
}
