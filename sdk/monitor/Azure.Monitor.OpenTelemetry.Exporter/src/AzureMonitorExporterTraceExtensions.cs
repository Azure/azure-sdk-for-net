// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
        /// Adds Azure Monitor Trace exporter to the TracerProvider.
        /// </summary>
        /// <param name="builder"><see cref="TracerProviderBuilder"/> builder to use.</param>
        /// <param name="configure">Callback action for configuring <see cref="AzureMonitorExporterOptions"/>.</param>
        /// <param name="credential"><see cref="TokenCredential" /></param>
        /// <param name="name">Name which is used when retrieving options.</param>
        /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
        public static TracerProviderBuilder AddAzureMonitorTraceExporter(
            this TracerProviderBuilder builder,
            Action<AzureMonitorExporterOptions>? configure = null,
            TokenCredential? credential = null,
            string? name = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var finalOptionsName = name ?? Options.DefaultName;

            if (name != null && configure != null)
            {
                // If we are using named options we register the
                // configuration delegate into options pipeline.
                builder.ConfigureServices(services => services.Configure(finalOptionsName, configure));
            }

            return builder.AddProcessor(sp =>
            {
                var exporterOptions = sp.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(finalOptionsName);

                if (name == null && configure != null)
                {
                    // If we are NOT using named options, we execute the
                    // configuration delegate inline. The reason for this is
                    // AzureMonitorExporterOptions is shared by all signals. Without a
                    // name, delegates for all signals will mix together. See:
                    // https://github.com/open-telemetry/opentelemetry-dotnet/issues/4043
                    configure(exporterOptions);
                }

                return new BatchActivityExportProcessor(new AzureMonitorTraceExporter(exporterOptions, credential));
            });
        }
    }
}
