// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    /// <summary>
    /// Extension methods to register Live Metrics.
    /// </summary>
    public static class LiveMetricsExtensions
    {
        /// <summary>
        /// Adds Live Metrics to the TracerProvider.
        /// </summary>
        /// <param name="builder"><see cref="TracerProviderBuilder"/> builder to use.</param>
        /// <param name="configure">Callback action for configuring <see cref="LiveMetricsExporterOptions"/>.</param>
        /// <param name="name">Name which is used when retrieving options.</param>
        /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
        public static TracerProviderBuilder AddLiveMetrics(
            this TracerProviderBuilder builder,
            Action<LiveMetricsExporterOptions> configure = null,
            string name = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var finalOptionsName = name ?? Options.DefaultName;

            builder.ConfigureServices(services =>
            {
                if (name != null && configure != null)
                {
                    // If we are using named options we register the
                    // configuration delegate into options pipeline.
                    services.Configure(finalOptionsName, configure);
                }
            });

            return builder.AddProcessor(sp =>
            {
                // SETUP OPTIONS
                LiveMetricsExporterOptions exporterOptions;

                if (name == null)
                {
                    exporterOptions = sp.GetRequiredService<IOptionsFactory<LiveMetricsExporterOptions>>().Create(finalOptionsName);

                    // Configuration delegate is executed inline on the fresh instance.
                    configure?.Invoke(exporterOptions);
                }
                else
                {
                    // When using named options we can properly utilize Options
                    // API to create or reuse an instance.
                    exporterOptions = sp.GetRequiredService<IOptionsMonitor<LiveMetricsExporterOptions>>().Get(finalOptionsName);
                }

                // INITIALIZE INTERNALS
                var manager = new Manager(exporterOptions, new DefaultPlatform());
                return new LiveMetricsActivityProcessor(manager);
            });
        }
    }
}
