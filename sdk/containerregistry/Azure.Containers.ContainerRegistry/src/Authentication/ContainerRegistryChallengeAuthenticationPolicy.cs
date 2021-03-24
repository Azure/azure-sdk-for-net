// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// Challenge-based authentication policy for Container Registry Service.
    ///
    /// The challenge-based authorization flow for ACR is illustrated in the following steps.
    /// For example, GET /api/v1/acr/repositories translates into the following calls.
    ///
    /// Step 1: GET /api/v1/acr/repositories
    /// Return Header: 401: www-authenticate header - Bearer realm="{url}",service="{serviceName}",scope="{scope}",error="invalid_token"
    ///
    /// Step 2: Retrieve the serviceName, scope from the WWW-Authenticate header.  (Parse the string.)
    ///
    /// Step 3: POST /api/oauth2/exchange
    /// Request Body : { service, scope, grant-type, aadToken with ARM scope }
    /// Response Body: { acrRefreshToken }
    ///
    /// Step 4: POST /api/oauth2/token
    /// Request Body: { acrRefreshToken, scope, grant-type }
    /// Response Body: { acrAccessToken }
    ///
    /// Step 5: GET /api/v1/acr/repositories
    /// Request Header: { Bearer acrTokenAccess }
    /// </summary>
    internal class ContainerRegistryChallengeAuthenticationPolicy : BearerTokenChallengeAuthenticationPolicy
    {
        private readonly IContainerRegistryAuthenticationClient _authenticationClient;

        public ContainerRegistryChallengeAuthenticationPolicy(TokenCredential credential, string aadScope, IContainerRegistryAuthenticationClient authenticationClient)
            : base(credential, aadScope)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(aadScope, nameof(aadScope));

            _authenticationClient = authenticationClient;
        }

        protected override async ValueTask<bool> AuthenticateRequestOnChallengeAsync(HttpMessage message, bool async)
        {
            // Once we're here, we've completed Step 1.

            // Step 2: Parse challenge string to retrieve serviceName and scope, where scope is the ACR Scope
            var service = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "service");
            var scope = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "scope");

            string acrAccessToken = string.Empty;
            if (async)
            {
                // Step 3: Exchange AAD Access Token for ACR Refresh Token
                string acrRefreshToken = await ExchangeAadAccessTokenForAcrRefreshTokenAsync(message, service, true).ConfigureAwait(false);

                // Step 4: Send in acrRefreshToken and get back acrAccessToken
                acrAccessToken = await ExchangeAcrRefreshTokenForAcrAccessTokenAsync(acrRefreshToken, service, scope, true, message.CancellationToken).ConfigureAwait(false);
            }
            else
            {
                // Step 3: Exchange AAD Access Token for ACR Refresh Token
                string acrRefreshToken = ExchangeAadAccessTokenForAcrRefreshTokenAsync(message, service, false).EnsureCompleted();

                // Step 4: Send in acrRefreshToken and get back acrAccessToken
                acrAccessToken = ExchangeAcrRefreshTokenForAcrAccessTokenAsync(acrRefreshToken, service, scope, false, message.CancellationToken).EnsureCompleted();
            }

            // Step 5 - Authorize Request.  Note, we don't use SetAuthorizationHeader here, because it
            // sets an AAD access token header, and at this point we're done with AAD and using an ACR access token.
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, $"Bearer {acrAccessToken}");

            return true;
        }

        private async Task<string> ExchangeAadAccessTokenForAcrRefreshTokenAsync(HttpMessage message, string service, bool async)
        {
            string aadAccessToken = GetAuthorizationToken(message);

            Response<AcrRefreshToken> acrRefreshToken = null;
            if (async)
            {
                acrRefreshToken = await _authenticationClient.ExchangeAadAccessTokenForAcrRefreshTokenAsync(service, aadAccessToken, message.CancellationToken).ConfigureAwait(false);
            }
            else
            {
                acrRefreshToken = _authenticationClient.ExchangeAadAccessTokenForAcrRefreshToken(service, aadAccessToken, message.CancellationToken);
            }

            return acrRefreshToken.Value.RefreshToken;
        }

        private async Task<string> ExchangeAcrRefreshTokenForAcrAccessTokenAsync(string acrRefreshToken, string service, string scope, bool async, CancellationToken cancellationToken)
        {
            Response<AcrAccessToken> acrAccessToken = null;
            if (async)
            {
                acrAccessToken = await _authenticationClient.ExchangeAcrRefreshTokenForAcrAccessTokenAsync(service, scope, acrRefreshToken, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                acrAccessToken = _authenticationClient.ExchangeAcrRefreshTokenForAcrAccessToken(service, scope, acrRefreshToken, cancellationToken);
            }

            return acrAccessToken.Value.AccessToken;
        }

        private static string GetAuthorizationToken(HttpMessage message)
        {
            string aadAuthHeader;
            if (!message.Request.Headers.TryGetValue(HttpHeader.Names.Authorization, out aadAuthHeader))
            {
                throw new InvalidOperationException("Failed to retrieve Authentication header from message request.");
            }

            return aadAuthHeader.Remove(0, "Bearer ".Length);
        }
    }
}
