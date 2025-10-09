// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Logs;
using System;
using OpenTelemetry.Trace;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Metrics;

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
        /// <param name="builder"><see cref="IOpenTelemetryBuilder"/>.</param>
        /// <returns>The supplied <see cref="IOpenTelemetryBuilder"/> for chaining calls.</returns>
        /// <remarks>
        /// <para>
        /// This method configures Azure Monitor for use with OpenTelemetry by adding the Azure Monitor exporter for logging,
        /// distributed tracing, and metrics. It also configures the OpenTelemetry logger to include formatted messages and
        /// parsed state values.
        /// </para>
        /// </remarks>
        public static IOpenTelemetryBuilder UseAzureMonitorExporter(this IOpenTelemetryBuilder builder)
        {
            builder.Services.TryAddSingleton<IConfigureOptions<AzureMonitorExporterOptions>,
                        DefaultAzureMonitorExporterOptions>();
            return builder.UseAzureMonitorExporter(o => { });
        }

        /// <summary>
        /// Configures Azure Monitor Exporter for logging, distributed tracing, and metrics.
        /// </summary>
        /// <param name="builder"><see cref="IOpenTelemetryBuilder"/>.</param>
        /// <param name="configureAzureMonitor">Callback action for configuring <see cref="AzureMonitorExporterOptions"/>.</param>
        /// <returns>The supplied <see cref="IOpenTelemetryBuilder"/> for chaining calls.</returns>
        /// <remarks>
        /// <para>
        /// This method configures Azure Monitor for use with OpenTelemetry by adding the Azure Monitor exporter for logging,
        /// distributed tracing, and metrics. It also configures the OpenTelemetry logger to include formatted messages and
        /// parsed state values.
        /// </para>
        /// </remarks>
        public static IOpenTelemetryBuilder UseAzureMonitorExporter(this IOpenTelemetryBuilder builder, Action<AzureMonitorExporterOptions> configureAzureMonitor)
        {
            if (builder.Services == null)
            {
                throw new ArgumentNullException(nameof(builder.Services));
            }

            if (configureAzureMonitor != null)
            {
                builder.Services.Configure(configureAzureMonitor);
            }

            builder.Services.AddSingleton(UseAzureMonitorExporterRegistration.Instance);

            // Note: We automatically turn on signals for "UseAzureMonitorExporter"
            builder
                .WithLogging()
                .WithMetrics()
                .WithTracing();

            builder.Services.ConfigureOpenTelemetryTracerProvider((sp, tracerProviderBuilder) =>
            {
                var exporterOptions = sp.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(Options.DefaultName);
                tracerProviderBuilder.SetSampler(exporterOptions.TracesPerSecond != null ?
                    new RateLimitedSampler(exporterOptions.TracesPerSecond.Value) :
                    new ApplicationInsightsSampler(exporterOptions.SamplingRatio));
            });

            builder.Services.Configure<OpenTelemetryLoggerOptions>((loggingOptions) =>
            {
                loggingOptions.IncludeFormattedMessage = true;
            });

            builder.Services.ConfigureOpenTelemetryMeterProvider((serviceProvider, meterProviderBuilder) =>
            {
                // Ensure that the AzureMonitorMetricExporter is registered only once
                serviceProvider!.EnsureSingleUseAzureMonitorExporterRegistration();

                var exporterOptions = serviceProvider!.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(Options.DefaultName);
                meterProviderBuilder.AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions))
                    { TemporalityPreference = MetricReaderTemporalityPreference.Delta });
            });

            // Register Manager as a singleton
            builder.Services.TryAddSingleton<LiveMetricsClientManager>(serviceProvider =>
            {
                AzureMonitorExporterOptions exporterOptions = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get(Options.DefaultName);
                var azureMonitorLiveMetricsOptions = new AzureMonitorLiveMetricsOptions();
                exporterOptions.SetValueToLiveMetricsOptions(azureMonitorLiveMetricsOptions);

                return new LiveMetricsClientManager(azureMonitorLiveMetricsOptions, new DefaultPlatform());
            });

            builder.Services.AddOptions<AzureMonitorExporterOptions>()
                .Configure<IConfiguration>((options, config) =>
                {
                    // If connection string is not set in the options, try to get it from configuration.
                    if (string.IsNullOrWhiteSpace(options.ConnectionString) && config[EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING] != null)
                    {
                        options.ConnectionString = config[EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING];
                    }
                });

            builder.Services.AddHostedService(serviceProvider =>
            {
                return new ExporterRegistrationHostedService(serviceProvider);
            });

            return builder;
        }
    }
}
