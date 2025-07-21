// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Developer.Playwright.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Azure.Developer.Playwright.Implementation;

internal class EntraLifecycle: IEntraLifecycle
{
    internal string? _entraIdAccessToken;
    internal long? _entraIdAccessTokenExpiry;
    private readonly TokenCredential? _tokenCredential;
    private readonly JsonWebTokenHandler _jsonWebTokenHandler;
    private readonly ILogger? _logger;
    private readonly IEnvironment _environment;
    private bool noOpFlag = false;

    public EntraLifecycle(TokenCredential? tokenCredential = null, JsonWebTokenHandler? jsonWebTokenHandler = null, ILogger? logger = null, IEnvironment? environment = null)
    {
        _logger = logger;
        _tokenCredential = tokenCredential;
        _jsonWebTokenHandler = jsonWebTokenHandler ?? new JsonWebTokenHandler();
        _environment = environment ?? new EnvironmentHandler();
        SetEntraIdAccessTokenFromEnvironment();
        if (_tokenCredential == null)
        {
            noOpFlag = true;
        }
    }

    public async Task FetchEntraIdAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        if (noOpFlag)
        {
            throw new Exception(Constants.s_entra_no_cred_error);
        }
        try
        {
            var tokenRequestContext = new TokenRequestContext(Constants.s_entra_access_token_scopes);
            AccessToken accessToken = await _tokenCredential!.GetTokenAsync(tokenRequestContext, cancellationToken).ConfigureAwait(false);
            _entraIdAccessToken = accessToken.Token;
            _entraIdAccessTokenExpiry = accessToken.ExpiresOn.ToUnixTimeSeconds();
            _environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), _entraIdAccessToken);
            return;
        }
        catch (Exception ex)
        {
            _logger?.LogError("{Error}", ex.ToString());
            throw new Exception(Constants.s_no_auth_error);
        }
    }

    public void FetchEntraIdAccessToken(CancellationToken cancellationToken = default)
    {
        if (noOpFlag)
        {
            throw new Exception(Constants.s_entra_no_cred_error);
        }
        try
        {
            var tokenRequestContext = new TokenRequestContext(Constants.s_entra_access_token_scopes);
            AccessToken accessToken = _tokenCredential!.GetToken(tokenRequestContext, cancellationToken);
            _entraIdAccessToken = accessToken.Token;
            _entraIdAccessTokenExpiry = accessToken.ExpiresOn.ToUnixTimeSeconds();
            _environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString(), _entraIdAccessToken);
            return;
        }
        catch (Exception ex)
        {
            _logger?.LogError("{Error}", ex.ToString());
            throw new Exception(Constants.s_no_auth_error);
        }
    }

    public bool DoesEntraIdAccessTokenRequireRotation()
    {
        if (noOpFlag)
        {
            throw new Exception(Constants.s_entra_no_cred_error);
        }
        if (string.IsNullOrEmpty(_entraIdAccessToken))
        {
            return true;
        }
        var lifetimeLeft = _entraIdAccessTokenExpiry - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return lifetimeLeft < Constants.s_entra_access_token_lifetime_left_threshold_in_minutes_for_rotation * 60;
    }

    public string? GetEntraIdAccessToken()
    {
        return _entraIdAccessToken;
    }

    internal void SetEntraIdAccessTokenFromEnvironment()
    {
        try
        {
            var token = _environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString());
            JsonWebToken jsonWebToken = _jsonWebTokenHandler.ReadJsonWebToken(token);
            jsonWebToken.TryGetClaim(
                "pwid",
                out System.Security.Claims.Claim? pwidClaim
            );
            if (pwidClaim != null)
                return; // MPT Token
            var expiry = (long)(jsonWebToken.ValidTo - new DateTime(1970, 1, 1)).TotalSeconds;
            _entraIdAccessToken = token;
            _entraIdAccessTokenExpiry = expiry;
        }
        catch (Exception)
        {
        }
    }
}
