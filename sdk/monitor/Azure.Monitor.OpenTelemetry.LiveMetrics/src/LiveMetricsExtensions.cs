// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    /// <summary>
    /// Extension methods to register Live Metrics.
    /// </summary>
    public static class LiveMetricsExtensions
    {
        /// <summary>
        /// Configures Azure Monitor Live Metrics for distributed tracing and logging.
        /// </summary>
        /// <param name="builder"><see cref="OpenTelemetryBuilder"/>.</param>
        /// <param name="configure">Callback action for configuring <see cref="LiveMetricsExporterOptions"/>.</param>
        /// <returns>The supplied <see cref="OpenTelemetryBuilder"/> for chaining calls.</returns>
        /// <exception cref="ArgumentNullException">Throws an exception if OpenTelemetryBuilder is null.</exception>
        public static OpenTelemetryBuilder AddLiveMetrics(this OpenTelemetryBuilder builder, Action<LiveMetricsExporterOptions> configure = null)
        {
            if (builder.Services == null)
            {
                throw new ArgumentNullException(nameof(builder.Services));
            }

            // Register a user provided configuration for Options.
            if (configure != null)
            {
                builder.Services.Configure(configure);
            }

            // Register a singleton for the internal Manager.
            builder.Services.TryAddSingleton<Manager>(implementationFactory: serviceProvider =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<LiveMetricsExporterOptions>>().Value;
                return new Manager(options);
            });

            // Register the LiveMetricsActivityProcessor.
            builder.WithTracing(configure: builder =>
            {
                builder.AddLiveMetrics();
            });

            // Register the LiveMetricsLogProcessor.
            builder.Services.AddLogging(configure: logging =>
            {
                logging.AddOpenTelemetry(configure: options =>
                {
                    options.AddLiveMetrics();
                });
            });

            return builder;
        }

        private static TracerProviderBuilder AddLiveMetrics(this TracerProviderBuilder builder)
        {
            return builder.AddProcessor(serviceProvider =>
            {
                var manager = serviceProvider.GetRequiredService<Manager>();
                return new LiveMetricsActivityProcessor(manager);
            });
        }

        private static OpenTelemetryLoggerOptions AddLiveMetrics(this OpenTelemetryLoggerOptions loggerOptions)
        {
            return loggerOptions.AddProcessor(serviceProvider =>
            {
                var manager = serviceProvider.GetRequiredService<Manager>();
                return new LiveMetricsLogProcessor(manager);
            });
        }
    }
}
