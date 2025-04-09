// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class DefaultAzureMonitorExporterOptions : IConfigureOptions<AzureMonitorExporterOptions>
    {
        private const string AzureMonitorExporterSectionFromConfig = "AzureMonitorExporter";
        private readonly IConfiguration? _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAzureMonitorExporterOptions"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> from which configuration for Azure Monitor can be retrieved.</param>
        public DefaultAzureMonitorExporterOptions(IConfiguration? configuration = null)
        {
            _configuration = configuration;
        }

        public void Configure(AzureMonitorExporterOptions options)
        {
            try
            {
                if (_configuration != null)
                {
                    _configuration.GetSection(AzureMonitorExporterSectionFromConfig).Bind(options);

                    // IConfiguration can read from EnvironmentVariables or InMemoryCollection if configured to do so.
                    var connectionStringFromIConfig = _configuration[EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING];
                    if (!string.IsNullOrEmpty(connectionStringFromIConfig))
                    {
                        options.ConnectionString = connectionStringFromIConfig;
                    }
                }

                // Environment Variable should take precedence.
                var connectionStringFromEnvVar = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING);
                if (!string.IsNullOrEmpty(connectionStringFromEnvVar))
                {
                    options.ConnectionString = connectionStringFromEnvVar;
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.ConfigureFailed(ex);
            }
        }
    }
}
