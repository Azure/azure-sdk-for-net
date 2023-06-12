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
        /// Configures Azure Monitor for logging, distributed tracing, and metrics.
        /// </summary>
        /// <param name="builder"><see cref="OpenTelemetryBuilder"/>.</param>
        /// <returns>The supplied <see cref="OpenTelemetryBuilder"/> for chaining calls.</returns>
        /// <remarks>
        /// <para>
        /// This method configures Azure Monitor for use with OpenTelemetry by adding the Azure Monitor exporter for logging,
        /// distributed tracing, and metrics. It also configures the OpenTelemetry logger to include formatted messages and
        /// parsed state values.
        /// </para>
        ///
        /// <para>The following instrumentations are added for distributed tracing:</para>
        /// <list type="bullet">
        /// <item>ASP.NET Core: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.AspNetCore/"/>.</item>
        /// <item>HTTP Client: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.Http"/>.</item>
        /// <item>SQL Client: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.sqlclient"/>.</item>
        /// </list>
        ///
        /// <para>The following instrumentations are added for metrics:</para>
        /// <list type="bullet">
        /// <item>ASP.NET Core: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.AspNetCore/"/>.</item>
        /// <item>HTTP Client: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.Http"/>.</item>
        /// </list>
        /// </remarks>
        public static OpenTelemetryBuilder UseAzureMonitor(this OpenTelemetryBuilder builder)
        {
            builder.Services.TryAddSingleton<IConfigureOptions<AzureMonitorOptions>,
                        DefaultAzureMonitorOptions>();
            return builder.UseAzureMonitor(o => o = new AzureMonitorOptions());
        }

        /// <summary>
        /// Configures Azure Monitor for logging, distributed tracing, and metrics.
        /// </summary>
        /// <param name="builder"><see cref="OpenTelemetryBuilder"/>.</param>
        /// <param name="configureAzureMonitor">Callback action for configuring <see cref="AzureMonitorOptions"/>.</param>
        /// <returns>The supplied <see cref="OpenTelemetryBuilder"/> for chaining calls.</returns>
        /// <remarks>
        /// <para>
        /// This method configures Azure Monitor for use with OpenTelemetry by adding the Azure Monitor exporter for logging,
        /// distributed tracing, and metrics. It also configures the OpenTelemetry logger to include formatted messages and
        /// parsed state values.
        /// </para>
        ///
        /// <para>The following instrumentations are added for distributed tracing:</para>
        /// <list type="bullet">
        /// <item>ASP.NET Core: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.AspNetCore/"/>.</item>
        /// <item>HTTP Client: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.Http"/>.</item>
        /// <item>SQL Client: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.sqlclient"/>.</item>
        /// </list>
        ///
        /// <para>The following instrumentations are added for metrics:</para>
        /// <list type="bullet">
        /// <item>ASP.NET Core: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.AspNetCore/"/>.</item>
        /// <item>HTTP Client: <see href="https://www.nuget.org/packages/OpenTelemetry.Instrumentation.Http"/>.</item>
        /// </list>
        /// </remarks>
        public static OpenTelemetryBuilder UseAzureMonitor(this OpenTelemetryBuilder builder, Action<AzureMonitorOptions> configureAzureMonitor)
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
                            .SetSampler(sp =>
                            {
                                var options = sp.GetRequiredService<IOptionsMonitor<ApplicationInsightsSamplerOptions>>().Get(Options.DefaultName);
                                return new ApplicationInsightsSampler(options);
                            })
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

            // Set the default sampling ratio to 100 % to ensure that all telemetry is captured by default.
            builder.Services.Configure<ApplicationInsightsSamplerOptions>(options => { options.SamplingRatio = 1.0F; });

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
