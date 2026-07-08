// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Well-known environment-variable names and default values used to configure the
/// Microsoft 365 Agents SDK connection stack inside a Foundry hosted container.
/// </summary>
internal static class ConnectionEnvironment
{
    // ── Foundry-native inputs ────────────────────────────────────────────────
    public const string FoundryBlueprintClientId = "FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID";
    public const string FoundryInstanceClientId = "FOUNDRY_AGENT_INSTANCE_CLIENT_ID";
    public const string FoundryTenantId = "FOUNDRY_AGENT_TENANT_ID";

    // ── Microsoft 365 connection settings keys ───────────────────────────────
    public const string AuthType = "CONNECTIONS__SERVICE_CONNECTION__SETTINGS__AUTHTYPE";
    public const string ClientId = "CONNECTIONS__SERVICE_CONNECTION__SETTINGS__CLIENTID";
    public const string TenantId = "CONNECTIONS__SERVICE_CONNECTION__SETTINGS__TENANTID";
    public const string Scope0 = "CONNECTIONS__SERVICE_CONNECTION__SETTINGS__SCOPES__0";
    public const string Authority = "CONNECTIONS__SERVICE_CONNECTION__SETTINGS__AUTHORITY";
    public const string ConnectionMapServiceUrl = "CONNECTIONSMAP__0__SERVICEURL";
    public const string ConnectionMapConnection = "CONNECTIONSMAP__0__CONNECTION";

    // ── Default values ───────────────────────────────────────────────────────
    public const string DefaultAuthType = "UserManagedIdentity";
    public const string DefaultServiceUrl = "*";
    public const string DefaultConnectionName = "SERVICE_CONNECTION";

    /// <summary>Outbound scope for the simple agent-instance-identity model.</summary>
    public const string BotConnectorScope = "https://api.botframework.com/.default";

    /// <summary>Outbound scope for the digital-worker (blueprint + FMI exchange) model.</summary>
    public const string DigitalWorkerScope = "5a807f24-c9de-44ee-a3a7-329e88a00ffc/.default";

    /// <summary>Base of the AAD authority URL; append the tenant id to complete it.</summary>
    public const string LoginAuthorityBase = "https://login.microsoftonline.com/";

    /// <summary>Builds the AAD authority URL for the given tenant.</summary>
    public static string AuthorityFor(string tenantId) => LoginAuthorityBase + tenantId;
}
