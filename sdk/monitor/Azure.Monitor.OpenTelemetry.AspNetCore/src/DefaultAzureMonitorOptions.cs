// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    internal class DefaultAzureMonitorOptions : IConfigureOptions<AzureMonitorOptions>
    {
        private const string AzureMonitorSectionFromConfig = "AzureMonitor";
        private const string ConnectionStringEnvironmentVariable = "APPLICATIONINSIGHTS_CONNECTION_STRING";
        private readonly IConfiguration? _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAzureMonitorOptions"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> from which configuration for Azure Monitor can be retrieved.</param>
        public DefaultAzureMonitorOptions(IConfiguration? configuration = null)
        {
            _configuration = configuration;
        }

        public void Configure(AzureMonitorOptions options)
        {
            try
            {
                if (_configuration != null)
                {
                    _configuration.GetSection(AzureMonitorSectionFromConfig).Bind(options);

                    // IConfiguration can read from EnvironmentVariables or InMemoryCollection if configured to do so.
                    var connectionStringFromIConfig = _configuration[ConnectionStringEnvironmentVariable];
                    if (!string.IsNullOrEmpty(connectionStringFromIConfig))
                    {
                        options.ConnectionString = connectionStringFromIConfig;
                    }
                }

                // Environment Variable should take precedence.
                var connectionStringFromEnvVar = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariable);
                if (!string.IsNullOrEmpty(connectionStringFromEnvVar))
                {
                    options.ConnectionString = connectionStringFromEnvVar;
                }
            }
            catch (Exception ex)
            {
                AzureMonitorAspNetCoreEventSource.Log.ConfigureFailed(ex);
            }
        }
    }
}
