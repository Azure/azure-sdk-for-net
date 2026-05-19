// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Provides strongly-typed access to Foundry platform environment variables
/// injected by the Azure AI Foundry hosting infrastructure.
/// All values are read once in the static constructor and cached for the
/// lifetime of the process.
/// </summary>
public static class FoundryEnvironment
{
    /// <summary>
    /// The agent name. Sourced from the <c>FOUNDRY_AGENT_NAME</c> environment variable.
    /// </summary>
    public static string? AgentName { get; private set; }

    /// <summary>
    /// The agent version. Sourced from the <c>FOUNDRY_AGENT_VERSION</c> environment variable.
    /// </summary>
    public static string? AgentVersion { get; private set; }

    /// <summary>
    /// The Foundry project endpoint. Sourced from the <c>FOUNDRY_PROJECT_ENDPOINT</c> environment variable.
    /// </summary>
    public static string? ProjectEndpoint { get; private set; }

    /// <summary>
    /// The full ARM ID of the Foundry project.
    /// Sourced from the <c>FOUNDRY_PROJECT_ARM_ID</c> environment variable.
    /// </summary>
    public static string? ProjectArmId { get; private set; }

    /// <summary>
    /// The session ID. Sourced from the <c>FOUNDRY_AGENT_SESSION_ID</c> environment variable.
    /// </summary>
    public static string? SessionId { get; private set; }

    /// <summary>
    /// The HTTP listen port. Sourced from the <c>PORT</c> environment variable. Default: 8088.
    /// </summary>
    public static int Port { get; private set; }

    /// <summary>
    /// The OTLP exporter endpoint. Sourced from the <c>OTEL_EXPORTER_OTLP_ENDPOINT</c> environment variable.
    /// </summary>
    public static string? OtlpEndpoint { get; private set; }

    /// <summary>
    /// The Application Insights connection string. Sourced from the <c>APPLICATIONINSIGHTS_CONNECTION_STRING</c> environment variable.
    /// </summary>
    public static string? AppInsightsConnectionString { get; private set; }

    /// <summary>
    /// The SSE keep-alive comment frame interval. Sourced from the <c>SSE_KEEPALIVE_INTERVAL</c>
    /// environment variable (value in integer seconds). When absent, zero, or unparseable,
    /// returns <see cref="Timeout.InfiniteTimeSpan"/> (disabled).
    /// </summary>
    public static TimeSpan SseKeepAliveInterval { get; private set; }

    /// <summary>
    /// The WebSocket Ping/Pong keep-alive interval used by the
    /// <c>invocations_ws</c> protocol. Sourced from the <c>WS_KEEPALIVE_INTERVAL</c>
    /// environment variable (value in integer seconds). When absent, zero, or
    /// unparseable, returns <see cref="Timeout.InfiniteTimeSpan"/> (disabled —
    /// Kestrel default of 30s does <em>not</em> apply because Core sets the
    /// option explicitly to honour the spec's "disabled by default" contract).
    /// </summary>
    /// <remarks>
    /// Hypercorn's <c>websocket_ping_interval</c> setting on the Python side
    /// maps to ASP.NET Core's <c>WebSocketOptions.KeepAliveInterval</c>: both
    /// emit RFC 6455 protocol-level Ping frames (opcode <c>0x9</c>) at the
    /// configured cadence. The Foundry hosting platform auto-injects this env
    /// var; configure it locally to test long-lived WS connections through
    /// idle-timeout-aware intermediaries (e.g., APIM, Azure Load Balancer).
    /// </remarks>
    public static TimeSpan WebSocketKeepAliveInterval { get; private set; }

    /// <summary>
    /// Indicates whether the process is running in a Foundry hosted environment.
    /// Returns <c>true</c> when the <c>FOUNDRY_HOSTING_ENVIRONMENT</c> environment variable
    /// is set to a non-empty value.
    /// </summary>
    /// <remarks>
    /// This variable is injected by the Azure AI Foundry hosting infrastructure as a
    /// non-empty value when the container is running in a Foundry context.
    /// </remarks>
    public static bool IsHosted { get; private set; }

    /// <summary>
    /// The managed identity client ID of the agent instance.
    /// Sourced from the <c>FOUNDRY_AGENT_INSTANCE_CLIENT_ID</c> environment variable.
    /// When present, this is used as the primary agent identifier for telemetry.
    /// </summary>
    public static string? AgentInstanceClientId { get; private set; }

    /// <summary>
    /// The managed identity client ID of the agent blueprint.
    /// Sourced from the <c>FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID</c> environment variable.
    /// Stamped as <c>gen_ai.agent.blueprint.id</c> on telemetry spans.
    /// </summary>
    public static string? AgentBlueprintClientId { get; private set; }

    /// <summary>
    /// The Microsoft Entra tenant ID of the agent.
    /// Sourced from the <c>FOUNDRY_AGENT_TENANT_ID</c> environment variable.
    /// Stamped as <c>microsoft.tenant.id</c> on telemetry spans.
    /// </summary>
    public static string? AgentTenantId { get; private set; }

    /// <summary>
    /// Indicates whether Agent365 tracing export is enabled.
    /// Returns <c>true</c> when both <see cref="IsHosted"/> is <c>true</c> and the
    /// <c>FOUNDRY_AGENT365_TRACING_ENABLED</c> environment variable is set to <c>"true"</c> (case-insensitive).
    /// </summary>
    public static bool IsAgent365TracingEnabled { get; private set; }

    static FoundryEnvironment() => Reload();

    /// <summary>
    /// Re-reads all environment variables. Intended for test isolation only;
    /// production code relies on the static constructor which calls this once.
    /// </summary>
    internal static void Reload()
    {
        AgentName = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_NAME");
        AgentVersion = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_VERSION");
        ProjectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        ProjectArmId = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ARM_ID");
        SessionId = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        OtlpEndpoint = Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT");
        AppInsightsConnectionString = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");

        // Port: default 8088, validate range 1-65535.
        var portEnv = Environment.GetEnvironmentVariable("PORT");
        if (string.IsNullOrEmpty(portEnv))
        {
            Port = 8088;
        }
        else if (!int.TryParse(portEnv, out var port) || port < 1 || port > 65535)
        {
            throw new InvalidOperationException(
                $"The PORT environment variable value '{portEnv}' is not a valid port number (1\u201365535).");
        }
        else
        {
            Port = port;
        }

        // SSE keep-alive: disabled (InfiniteTimeSpan) unless a positive integer seconds value is set.
        var sseEnv = Environment.GetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL");
        SseKeepAliveInterval = !string.IsNullOrEmpty(sseEnv)
            && int.TryParse(sseEnv, out var seconds)
            && seconds > 0
                ? TimeSpan.FromSeconds(seconds)
                : Timeout.InfiniteTimeSpan;

        // WebSocket keep-alive: disabled (InfiniteTimeSpan) unless a positive integer seconds value is set.
        // Matches the Python `WS_KEEPALIVE_INTERVAL` env var; wired to Kestrel's `WebSocketOptions.KeepAliveInterval`.
        var wsEnv = Environment.GetEnvironmentVariable("WS_KEEPALIVE_INTERVAL");
        WebSocketKeepAliveInterval = !string.IsNullOrEmpty(wsEnv)
            && int.TryParse(wsEnv, out var wsSeconds)
            && wsSeconds > 0
                ? TimeSpan.FromSeconds(wsSeconds)
                : Timeout.InfiniteTimeSpan;

        // IsHosted: true when the FOUNDRY_HOSTING_ENVIRONMENT environment variable exists
        // and is non-empty. This variable is injected by the Azure AI Foundry hosting infrastructure.
        IsHosted = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT"));

        // Agent identity env vars for A365 tracing.
        AgentInstanceClientId = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_INSTANCE_CLIENT_ID");
        AgentBlueprintClientId = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID");
        AgentTenantId = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_TENANT_ID");

        // A365 tracing enabled when both hosted and explicitly opted in.
        IsAgent365TracingEnabled = IsHosted
            && string.Equals(Environment.GetEnvironmentVariable("FOUNDRY_AGENT365_TRACING_ENABLED"), "true", StringComparison.OrdinalIgnoreCase);
    }
}
