// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Resolves the Microsoft 365 Agents SDK connection settings (the
/// <c>CONNECTIONS__*</c> / <c>CONNECTIONSMAP__*</c> keys) from the Foundry-native
/// identity and returns them as a plain configuration map.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="GetHostedAgentConfiguration()"/> is a <b>pure function</b>: it reads the
/// current environment at call time and <b>never mutates it</b>. Feed the returned map
/// into a configuration builder (for example
/// <c>new ConfigurationBuilder().AddEnvironmentVariables().AddInMemoryCollection(config)</c>)
/// so the M365 Agents SDK can read the settings — or inspect it directly to see the
/// effective values the host will use.
/// </para>
/// <para>Each setting is resolved with the following precedence:</para>
/// <list type="number">
///   <item>An existing explicit connection value in the environment (never overridden).</item>
///   <item>A value derived from the Foundry-native identity.</item>
///   <item>A static default for non-critical options.</item>
/// </list>
/// <para>
/// The identity source differs by auth model:
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
    /// <summary>
    /// Resolves the M365 SDK connection settings for the <b>simple agent</b> auth model
    /// (default) as a configuration map. Does not mutate the process environment.
    /// </summary>
    /// <returns>
    /// The effective connection settings (existing environment value where present,
    /// otherwise the derived value) keyed by their M365 configuration names.
    /// </returns>
    public static IReadOnlyDictionary<string, string?> GetHostedAgentConfiguration()
        => GetHostedAgentConfiguration(digitalWorker: false);

    /// <summary>
    /// Resolves the M365 SDK connection settings as a configuration map.
    /// Does not mutate the process environment.
    /// </summary>
    /// <param name="digitalWorker">
    /// <c>false</c> (default) for the simple agent-instance-identity model.
    /// <c>true</c> for the digital-worker (blueprint + FMI exchange) model.
    /// </param>
    /// <returns>
    /// The effective connection settings (existing environment value where present,
    /// otherwise the derived value) keyed by their M365 configuration names.
    /// </returns>
    public static IReadOnlyDictionary<string, string?> GetHostedAgentConfiguration(bool digitalWorker)
    {
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

        var settings = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);

        // Records the effective value for a setting: an existing explicit environment
        // value takes precedence; otherwise the derived value is used. Empty values are
        // omitted. The process environment is never modified.
        void Resolve(string name, string? derived)
        {
            var effective = GetNonEmpty(name) ?? Trimmed(derived);
            if (!string.IsNullOrEmpty(effective))
            {
                settings[name] = effective;
            }
        }

        // Static defaults for M365 connection settings
        Resolve(ConnectionEnvironment.AuthType, ConnectionEnvironment.DefaultAuthType);
        Resolve(ConnectionEnvironment.Scope0, scope);
        Resolve(ConnectionEnvironment.ConnectionMapServiceUrl, ConnectionEnvironment.DefaultServiceUrl);
        Resolve(ConnectionEnvironment.ConnectionMapConnection, ConnectionEnvironment.DefaultConnectionName);

        // Client id and tenant id derived from the Foundry-native identity.
        var clientId = GetNonEmpty(clientIdEnvVar)
            ?? (digitalWorker ? FoundryEnvironment.AgentBlueprintClientId : FoundryEnvironment.AgentInstanceClientId);
        var tenantId = GetNonEmpty(ConnectionEnvironment.FoundryTenantId)
            ?? FoundryEnvironment.AgentTenantId;

        Resolve(ConnectionEnvironment.ClientId, clientId);

        var effectiveTenantId = GetNonEmpty(ConnectionEnvironment.TenantId) ?? Trimmed(tenantId);
        if (!string.IsNullOrEmpty(effectiveTenantId))
        {
            settings[ConnectionEnvironment.TenantId] = effectiveTenantId;
            Resolve(ConnectionEnvironment.Authority, ConnectionEnvironment.AuthorityFor(effectiveTenantId));
        }

        return settings;
    }

    private static string? GetNonEmpty(string name) => Trimmed(Environment.GetEnvironmentVariable(name));

    private static string? Trimmed(string? value)
    {
        var trimmed = value?.Trim();
        return string.IsNullOrEmpty(trimmed) ? null : trimmed;
    }
}
