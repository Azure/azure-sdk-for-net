// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Identity;
using Microsoft.Agents.A365.Observability.Runtime.Tracing.Exporters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenTelemetry;
using OpenTelemetry;
using OpenTelemetry.Context.Propagation;
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
    // The A365 token acquisition scope.
    private const string Agent365Scope = "api://9b975845-388f-4429-889e-eab1ef63949c/.default";

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
        // exporters from environment variables. It registers ASP.NET Core, HttpClient,
        // SQL, Azure SDK, and AI instrumentation automatically.
        var otelBuilder = services.AddOpenTelemetry();

        // Ensure W3C Trace Context and Baggage propagators are active on all TFMs.
        // On net9+, ASP.NET Core natively respects OTel's propagator for incoming
        // requests. On net8.0, the W3CBaggagePropagator middleware handles extraction.
        // This call ensures outgoing requests also propagate baggage correctly.
        Sdk.SetDefaultTextMapPropagator(new CompositeTextMapPropagator(new TextMapPropagator[]
        {
            new TraceContextPropagator(),
            new BaggagePropagator(),
        }));

        otelBuilder.UseMicrosoftOpenTelemetry(options =>
        {
            var exporters = ExportTarget.None;

            if (!string.IsNullOrEmpty(FoundryEnvironment.AppInsightsConnectionString))
            {
                exporters |= ExportTarget.AzureMonitor;
            }

            if (!string.IsNullOrEmpty(FoundryEnvironment.OtlpEndpoint))
            {
                exporters |= ExportTarget.Otlp;
            }

            if (FoundryEnvironment.IsAgent365TracingEnabled)
            {
                exporters |= ExportTarget.Agent365;
                ConfigureAgent365Export(options);
            }

            options.Exporters = exporters;
        });

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
    /// Configures Agent365 export when the environment indicates it should be enabled.
    /// Requires <see cref="FoundryEnvironment.IsAgent365TracingEnabled"/> to be true,
    /// and <see cref="FoundryEnvironment.AgentInstanceClientId"/> to be set for token acquisition.
    /// </summary>
    private static void ConfigureAgent365Export(MicrosoftOpenTelemetryOptions options)
    {
        if (!FoundryEnvironment.IsAgent365TracingEnabled)
        {
            return;
        }

        var clientId = FoundryEnvironment.AgentInstanceClientId;
        if (string.IsNullOrEmpty(clientId))
        {
            return;
        }

        options.Exporters |= ExportTarget.Agent365;
        options.Agent365.Exporter.UseS2SEndpoint = true;
        options.Agent365.Exporter.TokenResolver = CreateTokenResolver();
    }

    /// <summary>
    /// Creates a token resolver delegate that acquires tokens using
    /// <see cref="DefaultAzureCredential"/> for the A365 exporter scope.
    /// The credential is configured with the agent instance's managed identity client ID
    /// so that token acquisition uses the correct identity.
    /// </summary>
    private static AsyncAuthTokenResolver CreateTokenResolver()
    {
        var credentialOptions = new DefaultAzureCredentialOptions();
        var clientId = FoundryEnvironment.AgentInstanceClientId;
        if (!string.IsNullOrEmpty(clientId))
        {
            credentialOptions.ManagedIdentityClientId = clientId;
        }

        var credential = new DefaultAzureCredential(credentialOptions);

        return async (agentId, tenantId) =>
        {
            var tenantForRequest = tenantId ?? FoundryEnvironment.AgentTenantId;
            var context = new TokenRequestContext(
                new[] { Agent365Scope },
                tenantId: tenantForRequest);
            var token = await credential.GetTokenAsync(context, CancellationToken.None);
            return token.Token;
        };
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
