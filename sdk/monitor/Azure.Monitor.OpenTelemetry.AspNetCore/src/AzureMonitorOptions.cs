// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.Serialization;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.OpenTelemetry.LiveMetrics;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    /// <summary>
    /// Options that allow users to configure the Azure Monitor.
    /// </summary>
    public class AzureMonitorOptions : ClientOptions
    {
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
        /// Disable offline storage.
        /// </summary>
        public bool DisableOfflineStorage { get; set; }

        /// <summary>
        /// Enables or disables the Live Metrics feature. This property is enabled by default.
        /// Note: Enabling Live Metrics incurs no additional billing or costs. However, it does introduce
        /// a performance overhead due to extra data collection, processing, and networking calls. This overhead
        /// is only significant when the LiveMetrics portal is actively used in the UI. Once the portal is closed,
        /// LiveMetrics reverts to a 'silent' mode with minimal to no overhead.
        /// <see href="https://learn.microsoft.com/azure/azure-monitor/app/live-stream?tabs=dotnet6"/>.
        /// </summary>
        public bool EnableLiveMetrics { get; set; } = true;

        /// <summary>
        /// Gets or sets the ratio of telemetry items to be sampled. The value must be between 0.0F and 1.0F, inclusive.
        /// For example, specifying 0.4 means that 40% of traces are sampled and 60% are dropped.
        /// The default value is 1.0F, indicating that all telemetry items are sampled.
        /// </summary>
        public float SamplingRatio { get; set; } = 1.0F;

        /// <summary>
        /// Gets or sets the number of traces per second to be sampled when using rate-limited sampling.
        /// For example, specifying 0.5 means one request every two seconds.
        /// When both TracesPerSecond and SamplingRatio are specified, TracesPerSecond takes precedence.
        /// </summary>
        public double? TracesPerSecond { get; set; }

        /// <summary>
        /// Override the default directory for offline storage.
        /// </summary>
        public string StorageDirectory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMonitorOptions"/>.
        /// </summary>
        public AzureMonitorOptions()
        {
            // users can explicitly change it, but by default we don't want internal logs to be reported to Azure Monitor.
            this.Diagnostics.IsDistributedTracingEnabled = false;
            this.Diagnostics.IsLoggingEnabled = false;
        }

        internal void SetValueToExporterOptions(AzureMonitorExporterOptions exporterOptions)
        {
            exporterOptions.ConnectionString = ConnectionString;
            exporterOptions.Credential = Credential;
            exporterOptions.DisableOfflineStorage = DisableOfflineStorage;
            exporterOptions.SamplingRatio = SamplingRatio;
            exporterOptions.TracesPerSecond = TracesPerSecond;
            exporterOptions.StorageDirectory = StorageDirectory;
            exporterOptions.EnableLiveMetrics = EnableLiveMetrics;
            if (Transport != null)
            {
                exporterOptions.Transport = Transport;
            }
            exporterOptions.Diagnostics.IsDistributedTracingEnabled = Diagnostics.IsDistributedTracingEnabled;
            exporterOptions.Diagnostics.IsLoggingEnabled = Diagnostics.IsLoggingEnabled;
        }

        //internal void SetValueToLiveMetricsOptions(AzureMonitorLiveMetricsOptions liveMetricsOptions)
        //{
        //    liveMetricsOptions.ConnectionString = ConnectionString;
        //    liveMetricsOptions.Credential = Credential;
        //    liveMetricsOptions.EnableLiveMetrics = EnableLiveMetrics;

        //    if (Transport != null)
        //    {
        //        liveMetricsOptions.Transport = Transport;
        //    }

        //    liveMetricsOptions.Diagnostics.IsDistributedTracingEnabled = Diagnostics.IsDistributedTracingEnabled;
        //    liveMetricsOptions.Diagnostics.IsLoggingEnabled = Diagnostics.IsLoggingEnabled;
        //}
    }
}
