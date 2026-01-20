// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Common;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Context;

internal static class OpenTelemetryExtensions
{
    public static void TryEnableOpenTelemetry(this IHostApplicationBuilder builder, AppConfiguration appConf,
        string userTelemetrySourceName,
        ILoggerFactory? loggerFactory)
    {
        var (azureMonitorEnabled, appInsightsConnectionString) = builder.TryUseApplicationInsights(appConf);

        var (otelExporterEnabled, otelExporterEndpoint) =
            builder.TryUseOpenTelemetryExporter(appConf, azureMonitorEnabled);

        if (azureMonitorEnabled || otelExporterEnabled)
        {
            builder.Services.AddOpenTelemetry()
                .WithTracing(b => b.AddSource(HostedAgentTelemetry.Source.Name, userTelemetrySourceName))
                .WithMetrics(b => b.AddMeter(HostedAgentTelemetry.Source.Name, userTelemetrySourceName));

            if (loggerFactory is null)
            {
                builder.Services.ConfigureOpenTelemetryLoggerProvider((sp, b) =>
                {
                    b.AddProcessor(new LogEnrichmentProcessor());
                });
                // set up logging for local DI
                builder.Logging.AddOpenTelemetry(o =>
                {
                    o.ParseStateValues = true;
                    o.IncludeFormattedMessage = true;
                    o.IncludeScopes = true;

                    if (!string.IsNullOrWhiteSpace(otelExporterEndpoint))
                    {
                        // only add the OTLP exporter since App Insights is already added by UseAzureMonitor()
                        o.AddOtlpExporter(opt => { opt.Endpoint = new Uri(otelExporterEndpoint); });
                    }
                });
            }
            else
            {
                // set up logging for external logger factory
                var provider =
                    loggerFactory.AddOpenTelemetryLoggerProvider(appInsightsConnectionString, otelExporterEndpoint);
                if (provider is not null)
                {
                    // Ensure provider is disposed with the host
                    builder.Services.AddSingleton(provider);
                }
            }
        }
    }

    public static OpenTelemetryLoggerProvider? AddOpenTelemetryLoggerProvider(this ILoggerFactory loggerFactory,
        string? appInsightsConnectionString,
        string? otelExporterEndpoint)
    {
        var opts = new OpenTelemetryLoggerOptions
        {
            ParseStateValues = true,
            IncludeFormattedMessage = true,
            IncludeScopes = true,
        };
        opts.AddProcessor(new LogEnrichmentProcessor());

        var hasAnyExporter = false;
        if (!string.IsNullOrWhiteSpace(appInsightsConnectionString))
        {
            hasAnyExporter = true;
            opts.AddAzureMonitorLogExporter(o => o.ConnectionString = appInsightsConnectionString);
        }

        if (!string.IsNullOrWhiteSpace(otelExporterEndpoint))
        {
            hasAnyExporter = true;
            opts.AddOtlpExporter(o => o.Endpoint = new Uri(otelExporterEndpoint));
        }

        if (!hasAnyExporter)
        {
            return null;
        }

        var provider = new OpenTelemetryLoggerProvider(new SingletonOptionsMonitor<OpenTelemetryLoggerOptions>(opts));
        loggerFactory.AddProvider(provider);
        return provider;
    }
}
