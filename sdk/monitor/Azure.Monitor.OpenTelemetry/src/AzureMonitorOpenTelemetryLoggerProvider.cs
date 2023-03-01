// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Azure.Monitor.OpenTelemetry
{
    internal class AzureMonitorOpenTelemetryLoggerProvider : ILoggerProvider
    {
        internal AzureMonitorOpenTelemetryLoggerProvider(IOptionsMonitor<AzureMonitorOpenTelemetryOptions> azureMonitorOpenTelemetryOptions)
        {
            _ = azureMonitorOpenTelemetryOptions?.CurrentValue;
        }

        public AzureMonitorOpenTelemetryLoggerProvider(IServiceProvider serviceProvider)
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
