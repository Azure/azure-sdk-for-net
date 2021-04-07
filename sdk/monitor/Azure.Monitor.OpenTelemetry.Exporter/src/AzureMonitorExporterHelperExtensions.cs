// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry;
using OpenTelemetry.Trace;
using System;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// test
    /// </summary>
    public static class AzureMonitorExporterHelperExtensions
    {
        /// <summary>
        /// Registers an Azure Monitor trace exporter that will receive <see cref="System.Diagnostics.Activity"/> instances.
        /// </summary>
        /// <param name="builder"><see cref="TracerProviderBuilder"/> builder to use.</param>
        /// <param name="configure">Exporter configuration options.</param>
        /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
        public static TracerProviderBuilder AddAzureMonitorTraceExporter(this TracerProviderBuilder builder, Action<AzureMonitorExporterOptions> configure = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var options = new AzureMonitorExporterOptions();
            configure?.Invoke(options);

            // TODO: Pick Simple vs Batching based on AzureMonitorExporterOptions
            return builder.AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(options)));
        }
    }
}
