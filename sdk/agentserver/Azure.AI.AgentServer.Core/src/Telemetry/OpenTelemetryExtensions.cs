// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// Configures OpenTelemetry tracing, logging, and metrics for the agent server.
/// OTLP exporters are conditional on <c>OTEL_EXPORTER_OTLP_ENDPOINT</c>.
/// Azure Monitor is conditional on <c>APPLICATIONINSIGHTS_CONNECTION_STRING</c>.
/// </summary>
internal static class OpenTelemetryExtensions
{
    /// <summary>
    /// Registers OpenTelemetry providers and conditional exporters.
    /// </summary>
    internal static IServiceCollection AddAgentHostTelemetry(
        this IServiceCollection services,
        Action<TracerProviderBuilder>? configureTracing = null)
    {
        var otlpEndpoint = FoundryEnvironment.OtlpEndpoint;
        var appInsightsCs = FoundryEnvironment.AppInsightsConnectionString;
        var hasOtlp = !string.IsNullOrEmpty(otlpEndpoint);
        var hasAppInsights = !string.IsNullOrEmpty(appInsightsCs);

        // Build resource attributes from Foundry environment
        var resourceBuilder = ResourceBuilder.CreateDefault();
        var agentName = FoundryEnvironment.AgentName;
        var agentVersion = FoundryEnvironment.AgentVersion;
        if (!string.IsNullOrEmpty(agentName))
        {
            resourceBuilder.AddAttributes(new[]
            {
                new KeyValuePair<string, object>("service.name", agentName),
            });
        }

        if (!string.IsNullOrEmpty(agentVersion))
        {
            resourceBuilder.AddAttributes(new[]
            {
                new KeyValuePair<string, object>("service.version", agentVersion),
            });
        }

        // Azure Monitor (must be registered first — it hooks into the OTel builder)
        if (hasAppInsights)
        {
            services.AddOpenTelemetry().UseAzureMonitor(options =>
            {
                options.ConnectionString = appInsightsCs;
            });
        }

        services.AddOpenTelemetry()
            .ConfigureResource(r =>
            {
                r.AddDetector(new FoundryResourceDetector());
                r.AddAttributes(resourceBuilder.Build().Attributes);
            })
            .WithTracing(tracing =>
            {
                // Only add ASP.NET Core and HttpClient instrumentation when UseAzureMonitor
                // is not active, because UseAzureMonitor already registers both and adding
                // them again would produce duplicate spans.
                if (!hasAppInsights)
                {
                    tracing.AddAspNetCoreInstrumentation();
                    tracing.AddHttpClientInstrumentation();
                }

                tracing.AddSource(AgentHostTelemetry.ResponsesSourceName);
                tracing.AddSource(AgentHostTelemetry.InvocationsSourceName);

                // Foundry enrichment processor — stamps agent identity and project ID
                // on every span so protocol packages get it automatically.
                tracing.AddProcessor(new FoundryEnrichmentProcessor());

                configureTracing?.Invoke(tracing);

                if (hasOtlp)
                {
                    tracing.AddOtlpExporter();
                }
            })
            .WithMetrics(metrics =>
            {
                // Same guard — UseAzureMonitor already adds ASP.NET Core and HttpClient metrics.
                if (!hasAppInsights)
                {
                    metrics.AddAspNetCoreInstrumentation();
                    metrics.AddHttpClientInstrumentation();
                }

                metrics.AddMeter(AgentHostTelemetry.ResponsesMeterName);
                metrics.AddMeter(AgentHostTelemetry.InvocationsMeterName);

                if (hasOtlp)
                {
                    metrics.AddOtlpExporter();
                }
            });

        // Logging with OTel bridge
        services.AddLogging(logging =>
        {
            logging.AddOpenTelemetry(otelLogging =>
            {
                otelLogging.SetResourceBuilder(resourceBuilder);
                otelLogging.IncludeScopes = true;
                otelLogging.IncludeFormattedMessage = true;
                otelLogging.AddProcessor(new BaggageToLogProcessor());

                if (hasOtlp)
                {
                    otelLogging.AddOtlpExporter();
                }
            });
        });

        return services;
    }

    /// <summary>
    /// Resource detector that adds Foundry environment attributes.
    /// </summary>
    private sealed class FoundryResourceDetector : IResourceDetector
    {
        public Resource Detect()
        {
            var attributes = new List<KeyValuePair<string, object>>();

            var agentName = FoundryEnvironment.AgentName;
            if (!string.IsNullOrEmpty(agentName))
            {
                attributes.Add(new KeyValuePair<string, object>("foundry.agent.name", agentName));
            }

            var agentVersion = FoundryEnvironment.AgentVersion;
            if (!string.IsNullOrEmpty(agentVersion))
            {
                attributes.Add(new KeyValuePair<string, object>("foundry.agent.version", agentVersion));
            }

            var projectEndpoint = FoundryEnvironment.ProjectEndpoint;
            if (!string.IsNullOrEmpty(projectEndpoint))
            {
                attributes.Add(new KeyValuePair<string, object>("foundry.project.endpoint", projectEndpoint));
            }

            var projectArmId = FoundryEnvironment.ProjectArmId;
            if (!string.IsNullOrEmpty(projectArmId))
            {
                attributes.Add(new KeyValuePair<string, object>("foundry.project.arm_id", projectArmId));
            }

            return attributes.Count > 0
                ? new Resource(attributes)
                : Resource.Empty;
        }
    }
}
