// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Logs;
using System;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// Extension methods for setting up Azure Monitor in an <see cref="OpenTelemetryBuilder" />.
    /// </summary>
    public static class OpenTelemetryBuilderExtensions
    {
        /// <summary>
        /// Configures Azure Monitor Exporter for all signals.
        /// </summary>
        /// <param name="builder"><see cref="OpenTelemetryBuilder"/>.</param>
        /// <returns>The supplied <see cref="OpenTelemetryBuilder"/> for chaining calls.</returns>
        /// <remarks>
        /// <para>
        /// This method configures Azure Monitor for use with OpenTelemetry by adding the Azure Monitor exporter for logging,
        /// distributed tracing, and metrics. It also configures the OpenTelemetry logger to include formatted messages and
        /// parsed state values.
        /// </para>
        /// </remarks>
        public static OpenTelemetryBuilder UseAzureMonitorExporter(this OpenTelemetryBuilder builder)
        {
            builder.Services.TryAddSingleton<IConfigureOptions<AzureMonitorExporterOptions>,
                        DefaultAzureMonitorExporterOptions>();
            return builder.UseAzureMonitorExporter(o => { });
        }

        /// <summary>
        /// Configures Azure Monitor Exporter for logging, distributed tracing, and metrics.
        /// </summary>
        /// <param name="builder"><see cref="OpenTelemetryBuilder"/>.</param>
        /// <param name="configureAzureMonitor">Callback action for configuring <see cref="AzureMonitorExporterOptions"/>.</param>
        /// <returns>The supplied <see cref="OpenTelemetryBuilder"/> for chaining calls.</returns>
        /// <remarks>
        /// <para>
        /// This method configures Azure Monitor for use with OpenTelemetry by adding the Azure Monitor exporter for logging,
        /// distributed tracing, and metrics. It also configures the OpenTelemetry logger to include formatted messages and
        /// parsed state values.
        /// </para>
        /// </remarks>
        public static OpenTelemetryBuilder UseAzureMonitorExporter(this OpenTelemetryBuilder builder, Action<AzureMonitorExporterOptions> configureAzureMonitor)
        {
            if (builder.Services == null)
            {
                throw new ArgumentNullException(nameof(builder.Services));
            }

            if (configureAzureMonitor != null)
            {
                builder.Services.Configure(configureAzureMonitor);
            }

            builder
                .WithLogging()
                .WithMetrics(metrics => metrics.AddAzureMonitorMetricExporter())
                .WithTracing();

            builder.Services.Configure<OpenTelemetryLoggerOptions>((loggingOptions) =>
            {
                loggingOptions.IncludeFormattedMessage = true;
            });

            builder.Services.AddHostedService(sp =>
            {
                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
                var loggerFilterOptions = sp.GetRequiredService<IOptionsMonitor<LoggerFilterOptions>>().CurrentValue;
                return new ExporterRegistrationHostedService(sp);
            });

            return builder;
        }
    }
}
