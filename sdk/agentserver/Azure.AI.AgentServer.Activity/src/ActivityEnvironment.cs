// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Activity.Internal;

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
            scope = ConnectionEnvironment.DigitalWorkerScope;
            clientIdEnvVar = ConnectionEnvironment.FoundryBlueprintClientId;
        }
        else
        {
            // Simple agent: instance identity mints Bot Connector token directly
            scope = ConnectionEnvironment.BotConnectorScope;
            clientIdEnvVar = ConnectionEnvironment.FoundryInstanceClientId;
        }

        // Static defaults for M365 connection settings
        SetIfMissing(ConnectionEnvironment.AuthType, ConnectionEnvironment.DefaultAuthType);
        SetIfMissing(ConnectionEnvironment.Scope0, scope);
        SetIfMissing(ConnectionEnvironment.ConnectionMapServiceUrl, ConnectionEnvironment.DefaultServiceUrl);
        SetIfMissing(ConnectionEnvironment.ConnectionMapConnection, ConnectionEnvironment.DefaultConnectionName);

        // Derive client ID from the appropriate Foundry env var
        var clientId = GetNonEmpty(clientIdEnvVar)
            ?? (digitalWorker ? FoundryEnvironment.AgentBlueprintClientId : FoundryEnvironment.AgentInstanceClientId);
        var tenantId = GetNonEmpty(ConnectionEnvironment.FoundryTenantId)
            ?? FoundryEnvironment.AgentTenantId;

        if (!string.IsNullOrEmpty(clientId))
        {
            SetIfMissing(ConnectionEnvironment.ClientId, clientId);
        }

        if (!string.IsNullOrEmpty(tenantId))
        {
            SetIfMissing(ConnectionEnvironment.TenantId, tenantId);
            SetIfMissing(ConnectionEnvironment.Authority, ConnectionEnvironment.AuthorityFor(tenantId));
        }
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
