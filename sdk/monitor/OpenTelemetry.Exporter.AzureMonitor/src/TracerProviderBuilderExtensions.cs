// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Trace;
using System;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    /// <summary>
    /// test
    /// </summary>
    public static class TracerProviderBuilderExtensions
    {
        /// <summary>
        /// Registers an Azure Monitor trace exporter that will receive <see cref="System.Diagnostics.Activity"/> instances.
        /// </summary>
        /// <param name="builder"><see cref="TracerProviderBuilder"/> builder to use.</param>
        /// <param name="configure">Exporter configuration options.</param>
        /// <param name="processorConfigure">Activity processor configuration.</param>
        /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
        public static TracerProviderBuilder UseAzureMonitorTraceExporter(this TracerProviderBuilder builder, Action<AzureMonitorExporterOptions> configure = null, Action<ActivityProcessorPipelineBuilder> processorConfigure = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.AddProcessorPipeline(pipeline =>
            {
                var options = new AzureMonitorExporterOptions();
                configure?.Invoke(options);

                var exporter = new AzureMonitorTraceExporter(options);
                processorConfigure?.Invoke(pipeline);
                pipeline.SetExporter(exporter);
            });
        }
    }
}
