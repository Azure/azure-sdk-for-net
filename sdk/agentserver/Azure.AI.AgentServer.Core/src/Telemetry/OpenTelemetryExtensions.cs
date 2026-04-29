// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// Configures OpenTelemetry tracing, logging, and metrics for the agent server.
/// Uses the Microsoft OpenTelemetry distro which auto-detects Azure Monitor
/// (<c>APPLICATIONINSIGHTS_CONNECTION_STRING</c>) and OTLP
/// (<c>OTEL_EXPORTER_OTLP_ENDPOINT</c>) exporters from environment variables.
/// </summary>
internal static class OpenTelemetryExtensions
{
    /// <summary>
    /// Registers OpenTelemetry providers and conditional exporters via the
    /// Microsoft OpenTelemetry distro.
    /// </summary>
    internal static IServiceCollection AddAgentHostTelemetry(
        this IServiceCollection services,
        Action<TracerProviderBuilder>? configureTracing = null)
    {
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

        // The Microsoft OpenTelemetry distro auto-detects Azure Monitor and OTLP
        // from environment variables — no manual env var checks or duplicate-
        // instrumentation guards are needed. It registers ASP.NET Core, HttpClient,
        // SQL, Azure SDK, and AI instrumentation automatically.
        var otelBuilder = services.AddOpenTelemetry();

        // The Microsoft OpenTelemetry distro auto-configures Azure Monitor and OTLP
        // exporters from environment variables — no manual checks needed.
        otelBuilder.UseMicrosoftOpenTelemetry(options => { });

        otelBuilder
            .ConfigureResource(r =>
            {
                r.AddDetector(new FoundryResourceDetector());
                r.AddAttributes(resourceBuilder.Build().Attributes);
            })
            .WithTracing(tracing =>
            {
                tracing.AddSource(AgentHostTelemetry.ResponsesSourceName);
                tracing.AddSource(AgentHostTelemetry.InvocationsSourceName);

                // Foundry enrichment processor — stamps agent identity and project ID
                // on every span so protocol packages get it automatically.
                tracing.AddProcessor(new FoundryEnrichmentProcessor());

                configureTracing?.Invoke(tracing);
            })
            .WithMetrics(metrics =>
            {
                metrics.AddMeter(AgentHostTelemetry.ResponsesMeterName);
                metrics.AddMeter(AgentHostTelemetry.InvocationsMeterName);
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
