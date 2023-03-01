// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Azure.Monitor.OpenTelemetry
{
    /// <summary>
    /// An <see cref="ILoggerProvider"/> implementation for Noop Logger.
    /// This class is used to read <see cref="AzureMonitorOpenTelemetryOptions"/> from dependency container.
    /// </summary>
    internal class AzureMonitorOpenTelemetryLoggerProvider : ILoggerProvider
    {
        // The constructor allows the AzureMonitorOpenTelemetryOptions to be read from the dependency container.
        // If a parameterized constructor is not present, the options cannot be read.
        internal AzureMonitorOpenTelemetryLoggerProvider(IOptionsMonitor<AzureMonitorOpenTelemetryOptions> azureMonitorOpenTelemetryOptions)
        {
            _ = azureMonitorOpenTelemetryOptions?.CurrentValue;
        }

        internal AzureMonitorOpenTelemetryLoggerProvider(IServiceProvider serviceProvider)
        {
            _ = serviceProvider?.GetRequiredService<IOptionsMonitor<AzureMonitorOpenTelemetryOptions>>().CurrentValue;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return NullLogger.Instance;
        }

        public void Dispose()
        {
        }
    }
}
