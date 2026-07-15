// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Microsoft.Agents.Authentication;
using Microsoft.Agents.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Custom <see cref="IConnections"/> implementation for Foundry hosted containers.
///
/// Registers an <c>IConnections</c> that provides a
/// <see cref="FoundryAccessTokenProvider"/> which acquires tokens via
/// <c>ManagedIdentityCredential</c> with the configured managed identity.
///
/// The M365 adapter's ConnectorClient calls <c>IConnections.GetTokenProvider()</c>
/// → gets our provider → calls <c>GetAccessTokenAsync()</c> → gets correct token
/// → reply to Teams.
/// </summary>
internal sealed class FoundryConnections : IConnections
{
    private readonly ILogger _logger;
    private readonly FoundryAccessTokenProvider _tokenProvider;

    public FoundryConnections(ILogger<FoundryConnections> logger, IConfiguration configuration)
    {
        _logger = logger;

        var clientId = configuration[ConnectionEnvironment.ClientId] ?? "";
        var tenantId = configuration[ConnectionEnvironment.TenantId] ?? "";
        var scope = configuration[ConnectionEnvironment.Scope0] ?? "";

        // If no scope from env, default to botframework (simple mode).
        if (string.IsNullOrEmpty(scope))
        {
            scope = ConnectionEnvironment.BotConnectorScope;
        }

        // Single init log (not per-turn); routine per-call resolution is logged at Debug below.
        _logger.LogInformation(
            "[FoundryConnections] Initialized | clientId={ClientId} | tenantId={TenantId} | scope={Scope}",
            clientId.Length > 8 ? clientId[..8] + "..." : clientId,
            tenantId.Length > 8 ? tenantId[..8] + "..." : tenantId,
            scope);

        _tokenProvider = new FoundryAccessTokenProvider(clientId, tenantId, scope, logger);
    }

    public IAccessTokenProvider GetConnection(string name)
    {
        _logger.LogDebug("[FoundryConnections] GetConnection(name={Name})", name);
        return _tokenProvider;
    }

    public IAccessTokenProvider GetDefaultConnection()
    {
        _logger.LogDebug("[FoundryConnections] GetDefaultConnection()");
        return _tokenProvider;
    }

    public bool TryGetConnection(string name, out IAccessTokenProvider connection)
    {
        _logger.LogDebug("[FoundryConnections] TryGetConnection(name={Name})", name);
        connection = _tokenProvider;
        return true;
    }

    public IAccessTokenProvider GetTokenProvider(ClaimsIdentity claimsIdentity, string serviceUrl)
    {
        _logger.LogDebug("[FoundryConnections] GetTokenProvider(serviceUrl={ServiceUrl})", serviceUrl);
        return _tokenProvider;
    }

    public IAccessTokenProvider GetTokenProvider(ClaimsIdentity claimsIdentity, IActivity activity)
    {
        _logger.LogDebug("[FoundryConnections] GetTokenProvider(activity.Type={Type})", activity?.Type);
        return _tokenProvider;
    }
}

/// <summary>
/// Token provider that acquires tokens using <c>ManagedIdentityCredential</c>
/// with the configured managed identity client ID.
///
/// The scope <c>api://AzureADTokenExchange/.default</c> yields a client assertion
/// that can be used for outbound Bot Connector calls.
/// </summary>
internal sealed class FoundryAccessTokenProvider : IAccessTokenProvider
{
    private readonly string _clientId;
    private readonly string _tenantId;
    private readonly string _scope;
    private readonly ILogger _logger;

    // A single credential instance is reused across calls so its internal token cache is effective
    // (constructing a new ManagedIdentityCredential per call would defeat that cache). Lazily built
    // so an unset client id in local development fails at token-acquisition time, not at DI resolve.
    private readonly Lazy<ManagedIdentityCredential> _credential;

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
        _credential = new Lazy<ManagedIdentityCredential>(
            () => new ManagedIdentityCredential(ManagedIdentityId.FromUserAssignedClientId(_clientId)));

        _logger.LogDebug("[FoundryAccessTokenProvider] Created | clientId={ClientId} | scope={Scope}",
            clientId.Length > 8 ? clientId[..8] + "..." : clientId, scope);

        // Create connection settings
        var baseSettings = new FoundryConnectionSettingsImpl
        {
            ClientId = clientId,
            TenantId = tenantId,
            Authority = ConnectionEnvironment.AuthorityFor(tenantId),
            Scopes = new List<string> { scope },
        };
        ConnectionSettings = new ImmutableConnectionSettings(baseSettings);
    }

    /// <summary>Concrete ConnectionSettingsBase for creating ImmutableConnectionSettings.</summary>
    private sealed class FoundryConnectionSettingsImpl : ConnectionSettingsBase { }

    public async Task<string> GetAccessTokenAsync(
        string resourceUrl,
        IList<string> scopes,
        bool forceRefresh)
    {
        // Determine the token scope:
        // 1. If adapter passed scopes, use the first one
        // 2. Otherwise use our configured scope (from env or default)
        string tokenScope;
        if (scopes != null && scopes.Count > 0 && !string.IsNullOrEmpty(scopes[0]))
        {
            tokenScope = scopes[0];
        }
        else
        {
            tokenScope = _scope;
        }

        _logger.LogDebug(
            "[FoundryToken] Acquiring token | clientId={ClientId} | scope={Scope} | forceRefresh={ForceRefresh}",
            _clientId.Length > 8 ? _clientId[..8] + "..." : _clientId, tokenScope, forceRefresh);

        try
        {
            var tokenResult = await _credential.Value.GetTokenAsync(
                new Azure.Core.TokenRequestContext(new[] { tokenScope })).ConfigureAwait(false);

            _logger.LogDebug("[FoundryToken] Token acquired | expiresOn={ExpiresOn} | tokenLength={Length}",
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

            // A managed-identity token failure is an infrastructure/misconfiguration problem
            // (identity, scope, or environment) — not the developer's handler. Tag it so the
            // error-source classifier reports it as a platform error.
            PlatformErrorMarker.Tag(ex);
            throw;
        }
    }

    public Azure.Core.TokenCredential GetTokenCredential()
    {
        return _credential.Value;
    }
}
