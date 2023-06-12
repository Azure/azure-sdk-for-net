﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <param name="credential">
        /// An Azure <see cref="TokenCredential" /> capable of providing an OAuth token.
        /// Note: if a credential is provided to both <see cref="AzureMonitorExporterOptions"/> and this parameter,
        /// the Options will take precedence.
        /// </param>
        /// <returns>The instance of <see cref="OpenTelemetryLoggerOptions"/> to chain the calls.</returns>
        public static OpenTelemetryLoggerOptions AddAzureMonitorLogExporter(this OpenTelemetryLoggerOptions loggerOptions, Action<AzureMonitorExporterOptions>? configure = null, TokenCredential? credential = null)
        {
            if (loggerOptions == null)
            {
                throw new ArgumentNullException(nameof(loggerOptions));
            }

            // Ideally user should set this to true
            // but if they miss we may have an issue of missing state values which gets converted to custom dimensions.
            loggerOptions.ParseStateValues = true;

            var options = new AzureMonitorExporterOptions();
            configure?.Invoke(options);

            if (credential != null)
            {
                // Credential can be set by either AzureMonitorExporterOptions or Extension Method Parameter.
                // Options should take precedence.
                options.Credential ??= credential;
            }

            return loggerOptions.AddProcessor(new BatchLogRecordExportProcessor(new AzureMonitorLogExporter(options)));
        }
    }
}
