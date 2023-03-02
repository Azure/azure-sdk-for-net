// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Azure.Monitor.OpenTelemetry
{
    internal class DefaultAzureMonitorOpenTelemetryOptions : IConfigureOptions<AzureMonitorOpenTelemetryOptions>
    {
        private const string AzureMonitorOpenTelemetrySectionFromConfig = "AzureMonitorOpenTelemetry";
        private const string ConnectionStringEnvironmentVariable = "APPLICATIONINSIGHTS_CONNECTION_STRING";
        private readonly IConfiguration? _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAzureMonitorOpenTelemetryOptions"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> from which configuration for ApplicationInsights can be retrieved.</param>
        public DefaultAzureMonitorOpenTelemetryOptions(IConfiguration? configuration = null)
        {
            _configuration = configuration;
        }

        public void Configure(AzureMonitorOpenTelemetryOptions options)
        {
            if (_configuration != null)
            {
                _configuration.GetSection(AzureMonitorOpenTelemetrySectionFromConfig).Bind(options);
            }

            string? connectionString = _configuration?[ConnectionStringEnvironmentVariable];

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                options.ConnectionString = connectionString;
            }
        }
    }
}
