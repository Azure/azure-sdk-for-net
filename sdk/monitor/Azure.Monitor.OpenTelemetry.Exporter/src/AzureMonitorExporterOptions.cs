// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Diagnostics.CodeAnalysis;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.LiveMetrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Options that allow users to configure the Azure Monitor Exporter.
    /// </summary>
    public class AzureMonitorExporterOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.v2_1;

        /// <summary>
        /// The Connection String provides users with a single configuration setting to identify the Azure Monitor resource and endpoint.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string"/>.
        /// </remarks>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Get or sets the value of <see cref="TokenCredential" />.
        /// </summary>
        public TokenCredential Credential { get; set; }

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
        /// The <see cref="ServiceVersion"/> of the Azure Monitor ingestion API.
        /// </summary>
        public ServiceVersion Version { get; set; } = LatestVersion;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMonitorExporterOptions"/>.
        /// </summary>
        public AzureMonitorExporterOptions() : this(LatestVersion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMonitorExporterOptions"/>.
        /// </summary>
        /// <param name="version">The <see cref="ServiceVersion"/> of the Azure Monitor ingestion API.</param>
        public AzureMonitorExporterOptions(ServiceVersion version = LatestVersion)
        {
            this.Version = version;
            // users can explicitly change it, but by default we don't want exporter internal logs to be reported to Azure Monitor.
            this.Diagnostics.IsDistributedTracingEnabled = false;
            this.Diagnostics.IsLoggingEnabled = false;
        }

        /// <summary>
        /// The versions of Azure Monitor supported by this client library.
        /// </summary>
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "This naming format is defined in the Azure SDK Design Guidelines.")]
        public enum ServiceVersion
        {
            /// <summary>
            /// <see href="https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/data-plane/Monitor.Exporters/preview/v2.1/swagger.json" />.
            /// </summary>
            v2_1 = 1,
        }

        /// <summary>
        /// Override the default directory for offline storage.
        /// </summary>
        public string StorageDirectory { get; set; }

        /// <summary>
        /// Disable offline storage.
        /// </summary>
        public bool DisableOfflineStorage { get; set; }

        /// <summary>
        /// Enables or disables the Live Metrics feature. This property is enabled by default.
        /// Note: Enabling Live Metrics incurs no additional billing or costs. However, it does introduce
        /// a performance overhead due to extra data collection, processing, and networking calls. This overhead
        /// is only significant when the LiveMetrics portal is actively used in the UI. Once the portal is closed,
        /// </summary>
        /// LiveMetrics reverts to a 'silent' mode with minimal to no overhead.
        /// <remarks>
        /// This setting is applicable only when `UseAzureMonitorExporter` API is used.
        /// <see href="https://learn.microsoft.com/azure/azure-monitor/app/live-stream"/>.
        /// </remarks>
        public bool EnableLiveMetrics { get; set; } = true;

        /// <summary>
        /// Internal flag to control if Statsbeat is enabled.
        /// </summary>
        internal bool EnableStatsbeat { get; set; } = true;

        internal void SetValueToLiveMetricsOptions(AzureMonitorLiveMetricsOptions liveMetricsOptions)
        {
            liveMetricsOptions.ConnectionString = ConnectionString;
            liveMetricsOptions.Credential = Credential;
            liveMetricsOptions.EnableLiveMetrics = EnableLiveMetrics;

            if (Transport != null)
            {
                liveMetricsOptions.Transport = Transport;
            }

            liveMetricsOptions.Diagnostics.IsDistributedTracingEnabled = Diagnostics.IsDistributedTracingEnabled;
            liveMetricsOptions.Diagnostics.IsLoggingEnabled = Diagnostics.IsLoggingEnabled;
        }
    }
}
