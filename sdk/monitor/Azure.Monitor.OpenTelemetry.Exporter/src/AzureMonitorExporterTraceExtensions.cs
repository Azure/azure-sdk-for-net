// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using Azure.Core;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Extension methods to simplify registering of Azure Monitor Trace Exporter.
    /// </summary>
    public static class AzureMonitorExporterTraceExtensions
    {
        /// <summary>
        /// Registers an Azure Monitor trace exporter that will receive <see cref="System.Diagnostics.Activity"/> instances.
        /// </summary>
        /// <param name="builder"><see cref="TracerProviderBuilder"/> builder to use.</param>
        /// <param name="configure">Exporter configuration options.</param>
        /// <param name="credential"><see cref="TokenCredential" /></param>
        /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
        public static TracerProviderBuilder AddAzureMonitorTraceExporter(this TracerProviderBuilder builder, Action<AzureMonitorExporterOptions> configure = null, TokenCredential credential = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (builder is IDeferredTracerProviderBuilder deferredTracerProviderBuilder)
            {
                return deferredTracerProviderBuilder.Configure((sp, builder) =>
                {
                    AddAzureMonitorTraceExporter(builder, sp.GetOptions<AzureMonitorExporterOptions>(), configure, credential);
                });
            }

            return AddAzureMonitorTraceExporter(builder, new AzureMonitorExporterOptions(), configure, credential);
        }

        private static TracerProviderBuilder AddAzureMonitorTraceExporter(
            TracerProviderBuilder builder,
            AzureMonitorExporterOptions exporterOptions,
            Action<AzureMonitorExporterOptions> configure,
            TokenCredential credential)
        {
            configure?.Invoke(exporterOptions);

            // TODO: provide a way to turn off statsbeat
            // Statsbeat.InitializeAttachStatsbeat(options.ConnectionString);

            return builder.AddProcessor(new BatchActivityExportProcessor(new AzureMonitorTraceExporter(exporterOptions, credential)));
        }
    }
}
