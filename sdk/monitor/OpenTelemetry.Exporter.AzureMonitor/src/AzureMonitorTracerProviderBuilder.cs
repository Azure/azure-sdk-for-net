// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Trace;
using System;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    /// <summary>
    /// This class contains the extension method for <see cref="TracerProviderBuilder"/> which is used to initialize the Azure Monitor Exporter for Open Telemetry.
    /// <code>
    /// var tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    ///         .AddSource("Samples.SampleServer")
    ///         .AddSource("Samples.SampleClient")
    ///         .AddAzureMonitorTraceExporter(o => {
    ///             o.ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000000";
    ///         })
    ///         .Build();
    /// </code>
    /// </summary>
    public static class AzureMonitorTracerProviderBuilder
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
            return builder.AddProcessor(new BatchExportActivityProcessor(new AzureMonitorTraceExporter(options)));
        }
    }
}
