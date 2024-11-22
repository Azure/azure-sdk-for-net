// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Identity;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;

internal class EntraLifecycle
{
    internal string? _entraIdAccessToken;
    internal long? _entraIdAccessTokenExpiry;
    private readonly TokenCredential _tokenCredential;
    private readonly JsonWebTokenHandler _jsonWebTokenHandler;
    private readonly IFrameworkLogger? _frameworkLogger;

    public EntraLifecycle(TokenCredential? tokenCredential = null, JsonWebTokenHandler? jsonWebTokenHandler = null, IFrameworkLogger? frameworkLogger = null)
    {
        _frameworkLogger = frameworkLogger;
        _tokenCredential = tokenCredential ?? new DefaultAzureCredential();
        _jsonWebTokenHandler = jsonWebTokenHandler ?? new JsonWebTokenHandler();
        SetEntraIdAccessTokenFromEnvironment();
    }

    internal async Task FetchEntraIdAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var tokenRequestContext = new TokenRequestContext(Constants.s_entra_access_token_scopes);
            AccessToken accessToken = await _tokenCredential.GetTokenAsync(tokenRequestContext, cancellationToken).ConfigureAwait(false);
            _entraIdAccessToken = accessToken.Token;
            _entraIdAccessTokenExpiry = accessToken.ExpiresOn.ToUnixTimeSeconds();
            Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken, _entraIdAccessToken);
            return;
        }
        catch (Exception ex)
        {
            _frameworkLogger?.Error(ex.ToString());
            throw new Exception(Constants.s_no_auth_error);
        }
    }

    internal bool DoesEntraIdAccessTokenRequireRotation()
    {
        if (string.IsNullOrEmpty(_entraIdAccessToken))
        {
            return true;
        }
        var lifetimeLeft = _entraIdAccessTokenExpiry - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return lifetimeLeft < Constants.s_entra_access_token_lifetime_left_threshold_in_minutes_for_rotation * 60;
    }

    private void SetEntraIdAccessTokenFromEnvironment()
    {
        try
        {
            var token = Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken);
            JsonWebToken jsonWebToken = _jsonWebTokenHandler.ReadJsonWebToken(token);
            jsonWebToken.TryGetClaim(
                "aid",
                out System.Security.Claims.Claim? aidClaim
            );
            jsonWebToken.TryGetClaim(
                "accountId",
                out System.Security.Claims.Claim? accountIdClaim
            );
            if (aidClaim != null || accountIdClaim != null)
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
