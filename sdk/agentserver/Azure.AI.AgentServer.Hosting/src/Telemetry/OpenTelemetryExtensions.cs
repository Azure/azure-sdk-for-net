// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Hosting.Internal;

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
            .ConfigureResource(r => r.AddDetector(new FoundryResourceDetector()))
            .WithTracing(tracing =>
            {
                tracing.SetResourceBuilder(resourceBuilder);
                tracing.AddAspNetCoreInstrumentation();
                tracing.AddSource(AgentHostTelemetry.ResponsesSourceName);
                tracing.AddSource(AgentHostTelemetry.InvocationsSourceName);

                configureTracing?.Invoke(tracing);

                if (hasOtlp)
                {
                    tracing.AddOtlpExporter();
                }
            })
            .WithMetrics(metrics =>
            {
                metrics.SetResourceBuilder(resourceBuilder);
                metrics.AddAspNetCoreInstrumentation();
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

            return attributes.Count > 0
                ? new Resource(attributes)
                : Resource.Empty;
        }
    }
}
