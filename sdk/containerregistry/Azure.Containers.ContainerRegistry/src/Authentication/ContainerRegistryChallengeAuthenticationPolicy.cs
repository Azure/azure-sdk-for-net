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
        private readonly ContainerRegistryRefreshTokenCache _refreshTokenCache;

        public ContainerRegistryChallengeAuthenticationPolicy(TokenCredential credential, string aadScope, IContainerRegistryAuthenticationClient authenticationClient)
            : this(credential, aadScope, authenticationClient, null, null)
        {
        }

        internal ContainerRegistryChallengeAuthenticationPolicy(TokenCredential credential, string aadScope, IContainerRegistryAuthenticationClient authenticationClient, TimeSpan? tokenRefreshOffset = null, TimeSpan? tokenRefreshRetryDelay = null)
            : base(credential, aadScope)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(aadScope, nameof(aadScope));

            _authenticationClient = authenticationClient;
            _refreshTokenCache = new ContainerRegistryRefreshTokenCache(credential, authenticationClient, tokenRefreshOffset, tokenRefreshRetryDelay);
        }

        // Since we'll not cache the AAD access token or set an auth header on the initial request,
        // we override the method that does this.
        protected override Task AuthorizeRequestAsync(HttpMessage message, bool async)
        {
            return Task.CompletedTask;
        }

        protected override async ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message, bool async)
        {
            // Once we're here, we've completed Step 1.

            // We'll need this context to refresh the AAD access credential if that's needed.
            var context = new TokenRequestContext(Scopes, message.Request.ClientRequestId);

            // Step 2: Parse challenge string to retrieve serviceName and scope, where scope is the ACR Scope
            var service = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "service");
            var scope = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "scope");

            string acrAccessToken;
            if (async)
            {
                // Step 3: Exchange AAD Access Token for ACR Refresh Token, or get the cached value instead.
                string acrRefreshToken = await _refreshTokenCache.GetAcrRefreshTokenAsync(message, context, service, async).ConfigureAwait(false);

                // Step 4: Send in acrRefreshToken and get back acrAccessToken
                acrAccessToken = await ExchangeAcrRefreshTokenForAcrAccessTokenAsync(acrRefreshToken, service, scope, true, message.CancellationToken).ConfigureAwait(false);
            }
            else
            {
                // Step 3: Exchange AAD Access Token for ACR Refresh Token, or get the cached value instead.
                string acrRefreshToken = _refreshTokenCache.GetAcrRefreshTokenAsync(message, context, service, false).EnsureCompleted();

                // Step 4: Send in acrRefreshToken and get back acrAccessToken
                acrAccessToken = ExchangeAcrRefreshTokenForAcrAccessTokenAsync(acrRefreshToken, service, scope, false, message.CancellationToken).EnsureCompleted();
            }

            // Step 5 - Authorize Request.  Note, we don't use SetAuthorizationHeader from the base class here, because it
            // sets an AAD access token header, and at this point we're done with AAD and using an ACR access token.
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, $"Bearer {acrAccessToken}");

            return true;
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
    }
}
