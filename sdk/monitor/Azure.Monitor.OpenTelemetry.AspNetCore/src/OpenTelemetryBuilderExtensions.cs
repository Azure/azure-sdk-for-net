// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Extensions.AzureMonitor;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    /// <summary>
    /// Extension methods for setting up Azure Monitor in an <see cref="OpenTelemetryBuilder" />.
    /// </summary>
    public static class OpenTelemetryBuilderExtensions
    {
        /// <summary>
        /// Adds Azure Monitor Defaults into <see cref="OpenTelemetryBuilder" />.
        /// </summary>
        /// <param name="builder"><see cref="OpenTelemetryBuilder"/>.</param>
        /// <returns>The supplied <see cref="OpenTelemetryBuilder"/> for chaining calls.</returns>
        public static OpenTelemetryBuilder WithAzureMonitor(this OpenTelemetryBuilder builder)
        {
            builder.Services.TryAddSingleton<IConfigureOptions<AzureMonitorOptions>,
                        DefaultAzureMonitorOptions>();
            return builder.WithAzureMonitor(o => o = new AzureMonitorOptions());
        }

        /// <summary>
        /// Adds Azure Monitor Defaults into <see cref="OpenTelemetryBuilder" />.
        /// </summary>
        /// <param name="builder"><see cref="OpenTelemetryBuilder"/>.</param>
        /// <param name="configureAzureMonitor">Callback action for configuring <see cref="AzureMonitorOptions"/>.</param>
        /// <returns>The supplied <see cref="OpenTelemetryBuilder"/> for chaining calls.</returns>
        public static OpenTelemetryBuilder WithAzureMonitor(this OpenTelemetryBuilder builder, Action<AzureMonitorOptions> configureAzureMonitor)
        {
            if (builder.Services == null)
            {
                throw new ArgumentNullException(nameof(builder.Services));
            }

            if (configureAzureMonitor != null)
            {
                builder.Services.Configure(configureAzureMonitor);
            }

            builder.WithTracing(b => b
                            .AddAspNetCoreInstrumentation()
                            .AddHttpClientInstrumentation()
                            .AddSqlClientInstrumentation()
                            .SetSampler(new ApplicationInsightsSampler(1.0F))
                            .AddAzureMonitorTraceExporter());

            builder.WithMetrics(b => b
                            .AddAspNetCoreInstrumentation()
                            .AddHttpClientInstrumentation()
                            .AddAzureMonitorMetricExporter());

            builder.Services.AddLogging(logging =>
            {
                logging.AddOpenTelemetry(builderOptions =>
                {
                    builderOptions.IncludeFormattedMessage = true;
                    builderOptions.ParseStateValues = true;
                    builderOptions.IncludeScopes = false;
                });
            });

            // Add AzureMonitorLogExporter to AzureMonitorOptions
            // once the service provider is available containing the final
            // AzureMonitorOptions.
            builder.Services.AddOptions<OpenTelemetryLoggerOptions>()
                    .Configure<IOptionsMonitor<AzureMonitorOptions>>((loggingOptions, azureOptions) =>
                    {
                        loggingOptions.AddAzureMonitorLogExporter(o => azureOptions.Get(Options.DefaultName).SetValueToExporterOptions(o));
                    });

            // Register a configuration action so that when
            // AzureMonitorExporterOptions is requested it is populated from
            // AzureMonitorOptions.
            builder.Services
                    .AddOptions<AzureMonitorExporterOptions>()
                    .Configure<IOptionsMonitor<AzureMonitorOptions>>((exporterOptions, azureMonitorOptions) =>
                    {
                        azureMonitorOptions.Get(Options.DefaultName).SetValueToExporterOptions(exporterOptions);
                    });

            return builder;
        }
    }
}
