﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// Gets or sets the ratio of telemetry items to be sampled. The value must be between 0.0F and 1.0F, inclusive.
        /// For example, specifying 0.4 means that 40% of traces are sampled and 60% are dropped.
        /// The default value is 1.0F, indicating that all telemetry items are sampled.
        /// </summary>
        public float SamplingRatio { get; set; } = 1.0F;

        /// <summary>
        /// Override the default directory for offline storage.
        /// </summary>
        public string StorageDirectory { get; set; }

        internal void SetValueToExporterOptions(AzureMonitorExporterOptions exporterOptions)
        {
            exporterOptions.ConnectionString = ConnectionString;
            exporterOptions.Credential = Credential;
            exporterOptions.DisableOfflineStorage = DisableOfflineStorage;
            exporterOptions.SamplingRatio = SamplingRatio;
            exporterOptions.StorageDirectory = StorageDirectory;
            if (Transport != null)
            {
                exporterOptions.Transport = Transport;
            }
        }
    }
}
