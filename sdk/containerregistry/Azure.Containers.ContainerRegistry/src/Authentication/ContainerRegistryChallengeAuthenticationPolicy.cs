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
    internal class ContainerRegistryChallengeAuthenticationPolicy : BearerTokenAuthenticationPolicy
    {
        private readonly IContainerRegistryAuthenticationClient _authenticationClient;
        private readonly ContainerRegistryRefreshTokenCache _refreshTokenCache;
        private readonly string[] _aadScopes;
        private readonly bool _anonymousAccess;

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
            _aadScopes = new[] { aadScope };
            _anonymousAccess = credential is ContainerRegistryAnonymousAccessCredential;
        }

        // Since we'll not cache the AAD access token or set an auth header on the initial request,
        // that receives a challenge response, we override the method that does this.
        protected override void AuthorizeRequest(HttpMessage message)
        {
            return;
        }

        // Since we'll not cache the AAD access token or set an auth header on the initial request,
        // that receives a challenge response, we override the method that does this.
        protected override ValueTask AuthorizeRequestAsync(HttpMessage message)
        {
            return default;
        }

        protected override ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message)
            => AuthorizeRequestOnChallengeAsyncInternal(message, true);

        protected override bool AuthorizeRequestOnChallenge(HttpMessage message)
            => AuthorizeRequestOnChallengeAsyncInternal(message, false).EnsureCompleted();

        private async ValueTask<bool> AuthorizeRequestOnChallengeAsyncInternal(HttpMessage message, bool async)
        {
            // Once we're here, we've completed Step 1.

            // We'll need this context to refresh the AAD access credential if that's needed.
            var context = new TokenRequestContext(_aadScopes, message.Request.ClientRequestId);

            // Step 2: Parse challenge string to retrieve serviceName and scope, where scope is the ACR Scope
            var service = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "service");
            var scope = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "scope");

            string acrAccessToken;
            if (_anonymousAccess)
            {
                acrAccessToken = await GetAnonymousAcrAccessTokenAsync(service, scope, async, message.CancellationToken).ConfigureAwait(false);
            }
            else
            {
                // Step 3: Exchange AAD Access Token for ACR Refresh Token, or get the cached value instead.
                string acrRefreshToken = await _refreshTokenCache.GetAcrRefreshTokenAsync(message, context, service, async).ConfigureAwait(false);

                // Step 4: Send in acrRefreshToken and get back acrAccessToken
                acrAccessToken = await ExchangeAcrRefreshTokenForAcrAccessTokenAsync(acrRefreshToken, service, scope, async, message.CancellationToken).ConfigureAwait(false);
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
                acrAccessToken = await _authenticationClient.ExchangeAcrRefreshTokenForAcrAccessTokenAsync(service, scope, acrRefreshToken, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                acrAccessToken = _authenticationClient.ExchangeAcrRefreshTokenForAcrAccessToken(service, scope, acrRefreshToken, cancellationToken: cancellationToken);
            }

            return acrAccessToken.Value.AccessToken;
        }

        private async Task<string> GetAnonymousAcrAccessTokenAsync(string service, string scope, bool async, CancellationToken cancellationToken)
        {
            Response<AcrAccessToken> acrAccessToken = null;
            if (async)
            {
                acrAccessToken = await _authenticationClient.ExchangeAcrRefreshTokenForAcrAccessTokenAsync(service, scope, string.Empty, TokenGrantType.Password, cancellationToken ).ConfigureAwait(false);
            }
            else
            {
                acrAccessToken = _authenticationClient.ExchangeAcrRefreshTokenForAcrAccessToken(service, scope, string.Empty, TokenGrantType.Password, cancellationToken);
            }

            return acrAccessToken.Value.AccessToken;
        }
    }
}
