// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

using Azure.Core;

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
        /// (https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string).
        /// </remarks>
        public string? ConnectionString { get; set; }

        /// <summary>
        /// Get or sets the value of <see cref="TokenCredential" />.
        /// </summary>
        public TokenCredential? Credential { get; set; }

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
        }

        /// <summary>
        /// The versions of Azure Monitor supported by this client library.
        /// </summary>
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "This naming format is defined in the Azure SDK Design Guidelines.")]
        public enum ServiceVersion
        {
            /// <summary>
            /// (https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/data-plane/Monitor.Exporters/preview/2020-09-15_Preview/swagger.json).
            /// </summary>
            V2020_09_15_Preview = 1,

            /// <summary>
            /// (https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/data-plane/Monitor.Exporters/preview/v2.1/swagger.json).
            /// </summary>
            v2_1 = 2,
        }

        /// <summary>
        /// Override the default directory for offline storage.
        /// </summary>
        public string? StorageDirectory { get; set; }

        /// <summary>
        /// Disable offline storage.
        /// </summary>
        public bool DisableOfflineStorage { get; set; }

        /// <summary>
        /// Internal flag to control if Statsbeat is enabled.
        /// </summary>
        internal bool EnableStatsbeat { get; set; } = true;
    }
}
