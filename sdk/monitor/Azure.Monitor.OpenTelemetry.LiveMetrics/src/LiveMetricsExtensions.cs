// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    /// <summary>
    /// Extension methods to register Live Metrics.
    /// </summary>
    public static class LiveMetricsExtensions
    {
        /// <summary>
        /// Adds Live Metrics to the IOpenTelemetryBuilder.
        /// </summary>
        /// <param name="builder"><see cref="IOpenTelemetryBuilder"/> builder to use.</param>
        /// <param name="configure">Callback action for configuring <see cref="LiveMetricsExporterOptions"/>.</param>
        /// <param name="name">Name which is used when retrieving options.</param>
        /// <returns>The instance of <see cref="IOpenTelemetryBuilder"/> to chain the calls.</returns>
        public static IOpenTelemetryBuilder AddLiveMetrics(
            this IOpenTelemetryBuilder builder,
            Action<LiveMetricsExporterOptions> configure = null,
            string name = null)
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
                builder.Services.Configure(finalOptionsName, configure);
            }

            // Register Manager as a singleton
            builder.Services.AddSingleton<Manager>(sp =>
            {
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
                return new Manager(exporterOptions, new DefaultPlatform());
            });

            return builder.WithTracing(t => t.AddProcessor(sp =>
            {
                Manager manager = sp.GetRequiredService<Manager>();
                return new LiveMetricsActivityProcessor(manager);
            }));
        }
    }
}
