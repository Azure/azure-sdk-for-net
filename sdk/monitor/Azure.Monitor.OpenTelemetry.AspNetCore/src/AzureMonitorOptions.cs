// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter;

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
        /// (https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string).
        /// </remarks>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Get or sets the value of <see cref="TokenCredential" />.
        /// If <see cref="TokenCredential" /> is not set, AAD authenication is disabled
        /// and Instrumentation Key from the Connection String will be used.
        /// </summary>
        /// <remarks>
        /// https://learn.microsoft.com/en-us/azure/azure-monitor/app/sdk-connection-string?tabs=net#is-the-connection-string-a-secret
        /// </remarks>
        public TokenCredential Credential { get; set; }

        /// <summary>
        /// Disable offline storage.
        /// </summary>
        public bool DisableOfflineStorage { get; set; }

        /// <summary>
        /// Override the default directory for offline storage.
        /// </summary>
        public string StorageDirectory { get; set; }

        internal void SetValueToExporterOptions(AzureMonitorExporterOptions exporterOptions)
        {
            exporterOptions.ConnectionString = ConnectionString;
            exporterOptions.Credential = Credential;
            exporterOptions.DisableOfflineStorage = DisableOfflineStorage;
            exporterOptions.StorageDirectory = StorageDirectory;
            if (Transport != null)
            {
                exporterOptions.Transport = Transport;
            }
        }
    }
}
