// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable AZC0012 // Avoid single word type names
#pragma warning disable CA1724 // Conflict Metrics name with OpenTelemetry.Metrics

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
        public string ConnectionString { get; set; } = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        /// <summary>
        /// Gets or sets a value indicating whether Traces should be enabled.
        /// </summary>
        public bool DisableTraces { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Metrics should be enabled.
        /// </summary>
        public bool DisableMetrics { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Logs should be enabled.
        /// </summary>
        public bool DisableLogs { get; set; }

        /// <summary>
        /// Override the default directory for offline storage.
        /// </summary>
        public string StorageDirectory { get; set; }

        /// <summary>
        /// Disable offline storage.
        /// </summary>
        public bool DisableOfflineStorage { get; set; }

        /// <summary>
        /// Traces Configuration.
        /// </summary>
        public Traces Traces { get; set; } = new Traces();

        /// <summary>
        /// Metrics Configuration.
        /// </summary>
        public Metrics Metrics { get; set; } = new Metrics();
    }

    /// <summary>
    /// Traces Configuration.
    /// </summary>
    public class Traces
    {
        /// <summary>
        /// Gets or sets a value indicating whether AspNet Instrumentation should be enabled.
        /// </summary>
        public bool DisableAspNetInstrumentation { get; set; }
    }

    /// <summary>
    /// Metrics Configuration.
    /// </summary>
    public class Metrics
    {
        /// <summary>
        /// Gets or sets a value indicating whether AspNet Instrumentation should be enabled.
        /// </summary>
        public bool DisableAspNetInstrumentation { get; set; }
    }
}
