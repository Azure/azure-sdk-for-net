// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using Azure.Core;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Extension methods to simplify registering of Azure Monitor Log Exporter.
    /// </summary>
    public static class AzureMonitorExporterLoggingExtensions
    {
        /// <summary>
        /// Adds Azure Monitor Log Exporter with OpenTelemetryLoggerOptions.
        /// </summary>
        /// <param name="loggerOptions"><see cref="OpenTelemetryLoggerOptions"/> options to use.</param>
        /// <param name="configure">Exporter configuration options.</param>
        /// <param name="credential"><see cref="TokenCredential" /></param>
        /// <returns>The instance of <see cref="OpenTelemetryLoggerOptions"/> to chain the calls.</returns>
        public static OpenTelemetryLoggerOptions AddAzureMonitorLogExporter(this OpenTelemetryLoggerOptions loggerOptions, Action<AzureMonitorExporterOptions> configure = null, TokenCredential credential = null)
        {
            if (loggerOptions == null)
            {
                throw new ArgumentNullException(nameof(loggerOptions));
            }

            var options = new AzureMonitorExporterOptions();
            configure?.Invoke(options);

            return loggerOptions.AddProcessor(new BatchLogRecordExportProcessor(new AzureMonitorLogExporter(options, credential)));
        }
    }
}
