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
    /// Indicates whether the process is running in a Foundry hosted environment.
    /// Returns <c>true</c> when <see cref="ProjectEndpoint"/>,
    /// <see cref="AgentName"/>, and <see cref="AgentVersion"/> are all set
    /// <b>and</b> the .NET hosting environment is not <c>Development</c>.
    /// </summary>
    /// <remarks>
    /// The hosting environment is determined from the <c>ASPNETCORE_ENVIRONMENT</c>
    /// or <c>DOTNET_ENVIRONMENT</c> environment variable (checked in that order).
    /// When neither is set the environment is assumed to be non-development (i.e. hosted).
    /// </remarks>
    public static bool IsHosted { get; private set; }

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

        // IsHosted: true when all three Foundry platform env vars (ProjectEndpoint,
        // AgentName, AgentVersion) are configured AND the .NET hosting environment
        // is not "Development". This mirrors the logic used by
        // Microsoft.Extensions.Hosting.HostEnvironmentEnvExtensions.IsDevelopment().
        var hostingEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
        var isDevelopment = string.Equals(hostingEnv, "Development", StringComparison.OrdinalIgnoreCase);
        var hasFoundryVars = !string.IsNullOrWhiteSpace(ProjectEndpoint)
            && !string.IsNullOrWhiteSpace(AgentName)
            && !string.IsNullOrWhiteSpace(AgentVersion);
        IsHosted = hasFoundryVars && !isDevelopment;
    }
}
