// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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
        /// </summary>
        public float SamplingRatio { get; set; } = 1.0F;

        /// <summary>
        /// Gets or sets the number of traces per second to be sampled when using rate-limited sampling.
        /// For example, specifying 0.5 means one request every two seconds.
        /// When both TracesPerSecond and SamplingRatio are specified, TracesPerSecond takes precedence.
        /// </summary>
        public double? TracesPerSecond { get; set; } = 5.0;

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
        /// When enabled, the exporter persists telemetry directly to offline storage
        /// without attempting network transmission during <c>Export()</c> calls.
        /// </summary>
        /// <remarks>
        /// This is intended for short-lived processes (e.g., CLI tools) where the
        /// latency of an HTTP round-trip on every invocation would exceed the runtime budget.
        /// Use in combination with <see cref="AzureMonitorTraceExporter.FlushOfflineStorage"/> or an external
        /// drain process to periodically upload the accumulated blobs.
        /// This setting does not affect Statsbeat (SDK health telemetry); use
        /// <see cref="EnableStatsbeat"/> to control that independently.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown during exporter construction if both this and <see cref="DisableOfflineStorage"/>
        /// are set to <c>true</c>, as there would be no destination for telemetry.
        /// </exception>
        public bool DisableNetworkTransmission { get; set; }

        /// <summary>
        /// The interval at which accumulated offline storage blobs are retransmitted.
        /// Default is 120 seconds. Set to <see cref="System.Threading.Timeout.InfiniteTimeSpan"/>
        /// to disable automatic retransmission (manual control via <see cref="AzureMonitorTraceExporter.FlushOfflineStorage"/>).
        /// </summary>
        /// <remarks>
        /// Has no effect if <see cref="DisableOfflineStorage"/> is <c>true</c>.
        /// Must be a positive value or <see cref="System.Threading.Timeout.InfiniteTimeSpan"/>.
        /// </remarks>
        public TimeSpan StorageTransmitInterval
        {
            get => _storageTransmitInterval;
            set
            {
                if (value != System.Threading.Timeout.InfiniteTimeSpan && value <= TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "StorageTransmitInterval must be a positive value or Timeout.InfiniteTimeSpan.");
                }

                if (value.TotalMilliseconds > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "StorageTransmitInterval must not exceed Int32.MaxValue milliseconds.");
                }

                _storageTransmitInterval = value;
            }
        }

        private TimeSpan _storageTransmitInterval = TimeSpan.FromSeconds(120);

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
        /// Enables or disables filtering logs based on trace sampling decisions.
        /// </summary>
        /// <remarks>
        /// When enabled, only logs associated with sampled traces are exported.
        /// Logs without trace context are always exported.
        /// This reduces log volume while maintaining trace-log correlation.
        /// </remarks>
        public bool EnableTraceBasedLogsSampler { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether Statsbeat (SDK health telemetry
        /// and environment detection via IMDS metadata probes) is enabled.
        /// Default is <c>true</c>.
        /// </summary>
        /// <remarks>
        /// When disabled, no IMDS metadata probes or SDK usage metrics are sent.
        /// Can also be disabled via the <c>APPLICATIONINSIGHTS_STATSBEAT_DISABLED</c>
        /// environment variable.
        /// For short-lived CLI processes, disabling this avoids a 150-200ms IMDS probe
        /// on each invocation.
        /// </remarks>
        public bool EnableStatsbeat { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether standard metrics should be collected.
        /// Default is true.
        /// </summary>
        public bool EnableStandardMetrics { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether performance counters should be collected.
        /// Default is true.
        /// </summary>
        public bool EnablePerformanceCounters { get; set; } = true;

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
