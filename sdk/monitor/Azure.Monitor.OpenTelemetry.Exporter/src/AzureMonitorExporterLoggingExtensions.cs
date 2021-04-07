// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure.Monitor.OpenTelemetry.Exporter;

using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Microsoft.Extensions.Logging
{
    internal static class AzureMonitorExporterLoggingExtensions
    {
        public static OpenTelemetryLoggerOptions AddAzureMonitorLogExporter(this OpenTelemetryLoggerOptions loggerOptions, Action<AzureMonitorExporterOptions> configure = null)
        {
            if (loggerOptions == null)
            {
                throw new ArgumentNullException(nameof(loggerOptions));
            }

            var options = new AzureMonitorExporterOptions();
            configure?.Invoke(options);

            return loggerOptions.AddProcessor(new BatchLogRecordExportProcessor(new AzureMonitorLogExporter(options)));
        }
    }
}
