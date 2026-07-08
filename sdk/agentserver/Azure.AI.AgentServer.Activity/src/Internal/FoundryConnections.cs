// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias AzureIdentity;
using AzureIdentity::Azure.Identity;
using Microsoft.Agents.Authentication;
using Microsoft.Agents.Core.Models;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Custom <see cref="IConnections"/> implementation for Foundry hosted containers.
///
/// This is the C# equivalent of Python's monkey-patch on
/// <c>MsalAuth.get_agentic_application_token</c>. Instead of patching sealed
/// M365 SDK classes, we register our own <c>IConnections</c> that provides a
/// <see cref="FoundryAccessTokenProvider"/> which acquires tokens via
/// <c>DefaultAzureCredential</c> with the blueprint managed identity.
///
/// The M365 adapter's ConnectorClient calls <c>IConnections.GetTokenProvider()</c>
/// → gets our provider → calls <c>GetAccessTokenAsync()</c> → gets correct token
/// → reply to Teams succeeds (no 401).
/// </summary>
internal sealed class FoundryConnections : IConnections
{
    private readonly ILogger _logger;
    private readonly FoundryAccessTokenProvider _tokenProvider;

    /// <summary>Exposed for diagnostics logging.</summary>
    public string? ClientId { get; }
    /// <summary>Exposed for diagnostics logging.</summary>
    public string? Scope { get; }

    public FoundryConnections(ILogger<FoundryConnections> logger)
    {
        _logger = logger;

        var clientId = Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__CLIENTID") ?? "";
        var tenantId = Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__TENANTID") ?? "";
        var scope = Environment.GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__SCOPES__0") ?? "";

        _logger.LogInformation(
            "[FoundryConnections] Initialized | clientId={ClientId} | tenantId={TenantId} | scope_from_env={Scope}",
            clientId.Length > 8 ? clientId[..8] + "..." : clientId,
            tenantId.Length > 8 ? tenantId[..8] + "..." : tenantId,
            scope);

        // If no scope from env, default to botframework (simple mode)
        if (string.IsNullOrEmpty(scope))
        {
            scope = "https://api.botframework.com/.default";
            _logger.LogInformation("[FoundryConnections] No SCOPES__0 env var — defaulting to: {Scope}", scope);
        }

        ClientId = clientId;
        Scope = scope;

        _logger.LogInformation("[FoundryConnections] Final config | ClientId={ClientId} | Scope={Scope}", ClientId, Scope);

        _tokenProvider = new FoundryAccessTokenProvider(clientId, tenantId, scope, logger);
    }

    public IAccessTokenProvider GetConnection(string name)
    {
        _logger.LogInformation("[FoundryConnections] GetConnection(name={Name})", name);
        return _tokenProvider;
    }

    public IAccessTokenProvider GetDefaultConnection()
    {
        _logger.LogInformation("[FoundryConnections] GetDefaultConnection()");
        return _tokenProvider;
    }

    public bool TryGetConnection(string name, out IAccessTokenProvider connection)
    {
        _logger.LogInformation("[FoundryConnections] TryGetConnection(name={Name})", name);
        connection = _tokenProvider;
        return true;
    }

    public IAccessTokenProvider GetTokenProvider(ClaimsIdentity claimsIdentity, string serviceUrl)
    {
        _logger.LogInformation("[FoundryConnections] GetTokenProvider(serviceUrl={ServiceUrl})", serviceUrl);
        return _tokenProvider;
    }

    public IAccessTokenProvider GetTokenProvider(ClaimsIdentity claimsIdentity, IActivity activity)
    {
        _logger.LogInformation("[FoundryConnections] GetTokenProvider(activity.Type={Type})", activity?.Type);
        return _tokenProvider;
    }
}

/// <summary>
/// Token provider that acquires tokens using <c>DefaultAzureCredential</c>
/// with the blueprint managed identity client ID.
///
/// Equivalent to Python's patched <c>MsalAuth.get_agentic_application_token</c>:
/// <code>
/// credential = DefaultAzureCredential(
///     managed_identity_client_id=client_id,
///     identity_config={"fmi_path": agent_app_instance_id}
/// )
/// token = await credential.get_token("api://AzureADTokenExchange/.default")
/// </code>
///
/// In C#, <c>DefaultAzureCredential</c> with <c>ManagedIdentityClientId</c>
/// acquires a token via the managed identity endpoint. The scope
/// <c>api://AzureADTokenExchange/.default</c> yields a client assertion that
/// can be used for outbound Bot Connector calls.
/// </summary>
internal sealed class FoundryAccessTokenProvider : IAccessTokenProvider
{
    private readonly string _clientId;
    private readonly string _tenantId;
    private readonly string _scope;
    private readonly ILogger _logger;

    /// <summary>
    /// Connection settings exposed for the M365 SDK internals.
    /// </summary>
    public ImmutableConnectionSettings ConnectionSettings { get; }

    public FoundryAccessTokenProvider(string clientId, string tenantId, string scope, ILogger logger)
    {
        _clientId = clientId;
        _tenantId = tenantId;
        _scope = scope;
        _logger = logger;

        _logger.LogInformation("[FoundryAccessTokenProvider] Created | clientId={ClientId} | scope={Scope}",
            clientId.Length > 8 ? clientId[..8] + "..." : clientId, scope);

        // Create connection settings
        var baseSettings = new FoundryConnectionSettingsImpl
        {
            ClientId = clientId,
            TenantId = tenantId,
            Authority = $"https://login.microsoftonline.com/{tenantId}",
            Scopes = new List<string> { scope },
        };
        ConnectionSettings = new ImmutableConnectionSettings(baseSettings);

        _logger.LogInformation("[FoundryAccessTokenProvider] ConnectionSettings.Scopes={Scopes}",
            string.Join(",", ConnectionSettings.Scopes ?? new List<string>()));
    }

    /// <summary>Concrete ConnectionSettingsBase for creating ImmutableConnectionSettings.</summary>
    private sealed class FoundryConnectionSettingsImpl : ConnectionSettingsBase { }

    public async Task<string> GetAccessTokenAsync(
        string resourceUrl,
        IList<string> scopes,
        bool forceRefresh)
    {
        _logger.LogInformation(
            "[FoundryToken] GetAccessTokenAsync called | resourceUrl={ResourceUrl} | scopes_param=[{Scopes}] | forceRefresh={ForceRefresh}",
            resourceUrl,
            scopes != null && scopes.Count > 0 ? string.Join(",", scopes) : "(empty)",
            forceRefresh);

        _logger.LogInformation("[FoundryToken] Using managed identity clientId={ClientId}",
            _clientId.Length > 8 ? _clientId[..8] + "..." : _clientId);

        // Determine the token scope:
        // 1. If adapter passed scopes, use the first one
        // 2. Otherwise use our configured scope (from env or default)
        string tokenScope;
        if (scopes != null && scopes.Count > 0 && !string.IsNullOrEmpty(scopes[0]))
        {
            tokenScope = scopes[0];
            _logger.LogInformation("[FoundryToken] Using scope from adapter parameter: {Scope}", tokenScope);
        }
        else
        {
            tokenScope = _scope;
            _logger.LogInformation("[FoundryToken] No scopes from adapter — using configured scope: {Scope}", tokenScope);
        }

        _logger.LogInformation("[FoundryToken] FINAL token request: clientId={ClientId} | scope={Scope}",
            _clientId.Length > 8 ? _clientId[..8] + "..." : _clientId, tokenScope);

        try
        {
            var credential = new ManagedIdentityCredential(_clientId);
            _logger.LogInformation("[FoundryToken] ManagedIdentityCredential created, calling GetTokenAsync...");

            var tokenResult = await credential.GetTokenAsync(
                new Azure.Core.TokenRequestContext(new[] { tokenScope })).ConfigureAwait(false);

            _logger.LogInformation("[FoundryToken] Token acquired successfully | expiresOn={ExpiresOn} | tokenLength={Length}",
                tokenResult.ExpiresOn, tokenResult.Token?.Length ?? 0);

            return tokenResult.Token!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "[FoundryToken] FAILED to acquire token | clientId={ClientId} | scope={Scope} | error={Error}",
                _clientId.Length > 8 ? _clientId[..8] + "..." : _clientId,
                tokenScope,
                ex.Message);
            throw;
        }
    }

    public Azure.Core.TokenCredential GetTokenCredential()
    {
        _logger.LogInformation("[FoundryToken] GetTokenCredential() called — returning ManagedIdentityCredential(clientId={ClientId})",
            _clientId.Length > 8 ? _clientId[..8] + "..." : _clientId);
        return new ManagedIdentityCredential(_clientId);
    }
}
