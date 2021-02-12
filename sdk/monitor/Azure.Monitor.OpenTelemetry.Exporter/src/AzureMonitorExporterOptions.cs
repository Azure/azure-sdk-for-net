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
        internal const ServiceVersion LatestVersion = ServiceVersion.V2020_09_15_Preview;

        /// <summary>
        /// The Connection String provides users with a single configuration setting to identify the Azure Monitor resource and endpoint.
        /// </summary>
        /// <remarks>
        /// (https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string).
        /// </remarks>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The <see cref="ServiceVersion"/> of the Azure Monitor ingestion API.
        /// </summary>
        public ServiceVersion Version { get; set; } = ServiceVersion.V2020_09_15_Preview;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMonitorExporterOptions"/>.
        /// </summary>
        /// <param name="version">The <see cref="ServiceVersion"/> of the Azure Monitor ingestion API.</param>
        public AzureMonitorExporterOptions(ServiceVersion version = LatestVersion)
        {
            this.Version = version;
        }

        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "This naming format is defined in the Azure SDK Design Guidelines.")]
        public enum ServiceVersion
        {
            /// <summary>
            /// (https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/data-plane/Monitor.Exporters/preview/2020-09-15_Preview/swagger.json).
            /// </summary>
            V2020_09_15_Preview = 1,
        }
    }
}
