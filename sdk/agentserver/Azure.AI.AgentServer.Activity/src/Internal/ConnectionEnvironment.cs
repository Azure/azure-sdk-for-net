// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Well-known Foundry environment-variable names, Microsoft 365 Agents SDK configuration keys, and
/// default values used to configure the SDK connection stack inside a Foundry hosted container.
/// </summary>
/// <remarks>
/// The <c>FOUNDRY_AGENT_*</c> constants are process environment-variable names. The
/// <c>CONNECTIONS:*</c> / <c>CONNECTIONSMAP:*</c> constants are colon-delimited
/// <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> keys that are overlaid via
/// <c>AddInMemoryCollection</c>; they are never read from the process environment.
/// </remarks>
internal static class ConnectionEnvironment
{
    // ── Foundry-native inputs ────────────────────────────────────────────────
    public const string FoundryBlueprintClientId = "FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID";
    public const string FoundryInstanceClientId = "FOUNDRY_AGENT_INSTANCE_CLIENT_ID";
    public const string FoundryTenantId = "FOUNDRY_AGENT_TENANT_ID";

    // ── Microsoft 365 connection settings keys ───────────────────────────────
    // The connection-provider selection keys (Type/Assembly) tell the SDK's ConfigurationConnections
    // to build an MsalAuth provider; the Settings:* keys configure it.
    public const string ConnectionType = "CONNECTIONS:SERVICE_CONNECTION:TYPE";
    public const string ConnectionAssembly = "CONNECTIONS:SERVICE_CONNECTION:ASSEMBLY";
    public const string AuthType = "CONNECTIONS:SERVICE_CONNECTION:SETTINGS:AUTHTYPE";
    public const string ClientId = "CONNECTIONS:SERVICE_CONNECTION:SETTINGS:CLIENTID";
    public const string TenantId = "CONNECTIONS:SERVICE_CONNECTION:SETTINGS:TENANTID";
    public const string Scope0 = "CONNECTIONS:SERVICE_CONNECTION:SETTINGS:SCOPES:0";
    public const string Authority = "CONNECTIONS:SERVICE_CONNECTION:SETTINGS:AUTHORITY";
    public const string ConnectionMapServiceUrl = "CONNECTIONSMAP:0:SERVICEURL";
    public const string ConnectionMapConnection = "CONNECTIONSMAP:0:CONNECTION";

    // ── Default values ───────────────────────────────────────────────────────
    /// <summary>The M365 SDK connection provider type (MsalAuth) that reads the Settings:* keys.</summary>
    public const string MsalAuthConnectionType = "MsalAuth";

    /// <summary>The assembly that hosts the MsalAuth connection provider.</summary>
    public const string MsalAuthAssembly = "Microsoft.Agents.Authentication.Msal";

    public const string DefaultAuthType = "UserManagedIdentity";
    public const string DigitalWorkerAuthType = "IdentityProxyManager";
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
