using Azure.AI.AgentServer.Core.Common;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.Projects;
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.AspNetCore;
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

    private static (bool Enabled, string? ConnectionString) TryUseApplicationInsights(
        this IHostApplicationBuilder builder,
        AppConfiguration appConf)
    {
        if (!appConf.AppInsightsEnabled)
        {
            return (false, null);
        }

        var appInsightsConnectionString = appConf.AppInsightsConnectionString;
        if (string.IsNullOrWhiteSpace(appConf.AppInsightsConnectionString) && appConf.FoundryProjectInfo is not null)
        {
            var projectClient = new AIProjectClient(appConf.FoundryProjectInfo.ProjectEndpoint,
                new DefaultAzureCredential());
            try
            {
                appInsightsConnectionString = projectClient.Telemetry.GetApplicationInsightsConnectionString();
            }
            catch (Exception e)
            {
                // Ignore any exceptions, we just won't enable App Insights
                Console.WriteLine(
                    $"Failed to get Application Insights connection string from Foundry project. {e.Message}");
            }
        }

        if (!string.IsNullOrWhiteSpace(appInsightsConnectionString))
        {
            builder.Services.AddOpenTelemetry()
                .UseAzureMonitor(o => o.ConnectionString = appInsightsConnectionString);
            return (true, appInsightsConnectionString);
        }

        return (false, null);
    }

    private static (bool Enabled, string? OtelEndpoint) TryUseOpenTelemetryExporter(
        this IHostApplicationBuilder builder,
        AppConfiguration appConf,
        bool azureMonitorEnabled)
    {
        if (string.IsNullOrWhiteSpace(appConf.OpenTelemetryExporterEndpoint))
        {
            return (false, null);
        }

        var uri = new Uri(appConf.OpenTelemetryExporterEndpoint);
        var otel = builder.Services.AddOpenTelemetry();

        otel.WithTracing(b =>
        {
            if (!azureMonitorEnabled)
            {
                b.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            }

            b.AddOtlpExporter(o => o.Endpoint = uri);
        });

        otel.WithMetrics(b =>
        {
            if (!azureMonitorEnabled)
            {
                b.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            }

            b.AddOtlpExporter(o => { o.Endpoint = uri; });
        });

        return (true, appConf.OpenTelemetryExporterEndpoint);
    }
}
