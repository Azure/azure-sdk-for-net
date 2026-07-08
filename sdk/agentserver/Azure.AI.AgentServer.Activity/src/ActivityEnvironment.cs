// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Initializes connection-related environment variables used by the M365 Agents SDK
/// when running inside a Foundry hosted container. Call
/// <see cref="InitializeEnvironment()"/> early in your application startup (before
/// creating any M365 SDK types) to bridge Foundry-native environment variables
/// to the connection format expected by the M365 SDK.
/// </summary>
/// <remarks>
/// <para>Precedence order:</para>
/// <list type="number">
///   <item>Existing explicit connection env vars (never overwritten).</item>
///   <item>Values derived from Foundry-native env vars.</item>
///   <item>Static defaults for non-critical options.</item>
/// </list>
/// <para>
/// The defaults differ by auth model:
/// <list type="bullet">
///   <item><b>Simple</b> (<c>digitalWorker: false</c>, default): the <em>instance</em>
///     identity (<c>FOUNDRY_AGENT_INSTANCE_CLIENT_ID</c>) mints the Bot Connector
///     token directly, scoped to <c>https://api.botframework.com/.default</c>.</item>
///   <item><b>Digital worker</b> (<c>digitalWorker: true</c>): the <em>blueprint</em>
///     identity (<c>FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID</c>) is used with the
///     federated-identity exchange, scoped to the agentic resource.</item>
/// </list>
/// </para>
/// <para>This is the .NET equivalent of the Python SDK's
/// <c>ActivityAgentServerHost._initialize_default_env_vars()</c>.</para>
/// </remarks>
public static class ActivityEnvironment
{
    private static bool _digitalWorkerMode;

    /// <summary>
    /// Gets whether the digital worker auth model is active.
    /// </summary>
    public static bool IsDigitalWorkerMode => _digitalWorkerMode;

    /// <summary>
    /// Initializes M365 SDK connection environment variables from Foundry-native
    /// environment variables using the <b>simple agent</b> auth model (default).
    /// Safe to call multiple times — existing values are never overwritten.
    /// </summary>
    public static void InitializeEnvironment() => InitializeEnvironment(digitalWorker: false);

    /// <summary>
    /// Initializes M365 SDK connection environment variables from Foundry-native
    /// environment variables. Safe to call multiple times — existing values are
    /// never overwritten.
    /// </summary>
    /// <param name="digitalWorker">
    /// <c>false</c> (default) for the simple agent-instance-identity model.
    /// <c>true</c> for the digital-worker (blueprint + FMI exchange) model.
    /// </param>
    public static void InitializeEnvironment(bool digitalWorker)
    {
        _digitalWorkerMode = digitalWorker;

        string scope;
        string clientIdEnvVar;

        if (digitalWorker)
        {
            // Digital worker: blueprint identity + FMI token exchange
            scope = "5a807f24-c9de-44ee-a3a7-329e88a00ffc/.default";
            clientIdEnvVar = "FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID";
        }
        else
        {
            // Simple agent: instance identity mints Bot Connector token directly
            scope = "https://api.botframework.com/.default";
            clientIdEnvVar = "FOUNDRY_AGENT_INSTANCE_CLIENT_ID";
        }

        // Log what mode we're in and what env vars we see
        Console.WriteLine($"[ENV-INIT] digitalWorker={digitalWorker}, clientIdEnvVar={clientIdEnvVar}");
        Console.WriteLine($"[ENV-INIT] CONNECTIONS__SERVICE_CONNECTION__SETTINGS__AUTHTYPE={Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__AUTHTYPE") ?? "(not set)"}");
        Console.WriteLine($"[ENV-INIT] CONNECTIONS__SERVICE_CONNECTION__SETTINGS__CLIENTID={Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__CLIENTID") ?? "(not set)"}");
        Console.WriteLine($"[ENV-INIT] CONNECTIONS__SERVICE_CONNECTION__SETTINGS__TENANTID={Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__TENANTID") ?? "(not set)"}");
        Console.WriteLine($"[ENV-INIT] CONNECTIONS__SERVICE_CONNECTION__SETTINGS__SCOPES__0={Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__SCOPES__0") ?? "(not set)"}");
        Console.WriteLine($"[ENV-INIT] CONNECTIONSMAP__0__SERVICEURL={Environment.GetEnvironmentVariable("CONNECTIONSMAP__0__SERVICEURL") ?? "(not set)"}");
        Console.WriteLine($"[ENV-INIT] CONNECTIONSMAP__0__CONNECTION={Environment.GetEnvironmentVariable("CONNECTIONSMAP__0__CONNECTION") ?? "(not set)"}");
        Console.WriteLine($"[ENV-INIT] {clientIdEnvVar}={Environment.GetEnvironmentVariable(clientIdEnvVar) ?? "(not set)"}");
        Console.WriteLine($"[ENV-INIT] FOUNDRY_AGENT_TENANT_ID={Environment.GetEnvironmentVariable("FOUNDRY_AGENT_TENANT_ID") ?? "(not set)"}");

        // Static defaults for M365 connection settings
        SetIfMissing("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__AUTHTYPE", "UserManagedIdentity");
        SetIfMissing("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__SCOPES__0", scope);
        SetIfMissing("CONNECTIONSMAP__0__SERVICEURL", "*");
        SetIfMissing("CONNECTIONSMAP__0__CONNECTION", "SERVICE_CONNECTION");

        // Derive client ID from the appropriate Foundry env var
        var clientId = GetNonEmpty(clientIdEnvVar)
            ?? (digitalWorker ? FoundryEnvironment.AgentBlueprintClientId : FoundryEnvironment.AgentInstanceClientId);
        var tenantId = GetNonEmpty("FOUNDRY_AGENT_TENANT_ID")
            ?? FoundryEnvironment.AgentTenantId;

        if (!string.IsNullOrEmpty(clientId))
        {
            SetIfMissing("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__CLIENTID", clientId);
        }

        if (!string.IsNullOrEmpty(tenantId))
        {
            SetIfMissing("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__TENANTID", tenantId);
            SetIfMissing(
                "CONNECTIONS__SERVICE_CONNECTION__SETTINGS__AUTHORITY",
                $"https://login.microsoftonline.com/{tenantId}");
        }

        // Log final state after initialization
        Console.WriteLine($"[ENV-INIT] === FINAL STATE ===");
        Console.WriteLine($"[ENV-INIT] AUTHTYPE={Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__AUTHTYPE")}");
        Console.WriteLine($"[ENV-INIT] CLIENTID={Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__CLIENTID")}");
        Console.WriteLine($"[ENV-INIT] TENANTID={Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__TENANTID")}");
        Console.WriteLine($"[ENV-INIT] SCOPES__0={Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__SCOPES__0")}");
        Console.WriteLine($"[ENV-INIT] AUTHORITY={Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__AUTHORITY")}");
        Console.WriteLine($"[ENV-INIT] CONNECTIONSMAP__0__SERVICEURL={Environment.GetEnvironmentVariable("CONNECTIONSMAP__0__SERVICEURL")}");
        Console.WriteLine($"[ENV-INIT] CONNECTIONSMAP__0__CONNECTION={Environment.GetEnvironmentVariable("CONNECTIONSMAP__0__CONNECTION")}");
    }

    private static string? GetNonEmpty(string name)
    {
        var value = Environment.GetEnvironmentVariable(name)?.Trim();
        return string.IsNullOrEmpty(value) ? null : value;
    }

    private static void SetIfMissing(string name, string value)
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(name)?.Trim()))
        {
            Environment.SetEnvironmentVariable(name, value);
        }
    }
}
