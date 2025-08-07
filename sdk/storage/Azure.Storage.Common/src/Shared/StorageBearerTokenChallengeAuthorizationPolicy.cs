// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage
{
    /// <summary>
    /// The storage authorization policy which supports challenges including tenantId discovery.
    /// </summary>
    internal class StorageBearerTokenChallengeAuthorizationPolicy : BearerTokenAuthenticationPolicy
    {
        private volatile string[] _scopes;
        private volatile string tenantId;
        private readonly bool _enableTenantDiscovery;

        /// <summary>
        ///
        /// </summary>
        /// <param name="credential"></param>
        /// <param name="scope"></param>
        /// <param name="enableTenantDiscovery"> </param>
        public StorageBearerTokenChallengeAuthorizationPolicy(TokenCredential credential, string scope, bool enableTenantDiscovery) : base(credential, scope)
        {
            Argument.AssertNotNullOrEmpty(scope, nameof(scope));
            _scopes = new[] { scope };
            _enableTenantDiscovery = enableTenantDiscovery;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="credential"></param>
        /// <param name="scopes"></param>
        /// <param name="enableTenantDiscovery"> </param>
        public StorageBearerTokenChallengeAuthorizationPolicy(TokenCredential credential, IEnumerable<string> scopes, bool enableTenantDiscovery) : base(
            credential,
            scopes)
        {
            Argument.AssertNotNull(scopes, nameof(scopes));
            _scopes = scopes.ToArray();
            _enableTenantDiscovery = enableTenantDiscovery;
        }

        /// <inheritdoc />
        protected override void AuthorizeRequest(HttpMessage message)
            => AuthorizeRequestInternal(message, false).EnsureCompleted();

        /// <inheritdoc />
        protected override ValueTask AuthorizeRequestAsync(HttpMessage message)
            => AuthorizeRequestInternal(message, true);

        private async ValueTask AuthorizeRequestInternal(HttpMessage message, bool async)
        {
            if (tenantId != null || !_enableTenantDiscovery)
            {
                TokenRequestContext context = new TokenRequestContext(_scopes, message.Request.ClientRequestId, tenantId: tenantId, isCaeEnabled: true);
                if (async)
                {
                    await base.AuthenticateAndAuthorizeRequestAsync(message, context).ConfigureAwait(false);
                }
                else
                {
                    base.AuthenticateAndAuthorizeRequest(message, context);
                }
            }
        }

        /// <inheritdoc />
        protected override bool AuthorizeRequestOnChallenge(HttpMessage message) => AuthorizeRequestOnChallengeInternalAsync(message, false).EnsureCompleted();

        /// <inheritdoc />
        protected override ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message) => AuthorizeRequestOnChallengeInternalAsync(message, true);

        private async ValueTask<bool> AuthorizeRequestOnChallengeInternalAsync(HttpMessage message, bool async)
        {
            try
            {
                if (AuthorizationChallengeParser.IsCaeClaimsChallenge(message.Response))
                {
                    if (TryGetTokenRequestContextForCaeChallenge(message, out var tokenRequestContext))
                    {
                        if (async)
                        {
                            await AuthenticateAndAuthorizeRequestAsync(message, tokenRequestContext).ConfigureAwait(false);
                        }
                        else
                        {
                            AuthenticateAndAuthorizeRequest(message, tokenRequestContext);
                        }
                        return true;
                    }
                    return false;
                }

                var authUri = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "authorization_uri");

                // tenantId should be the guid as seen in this example: https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47/oauth2/authorize
                tenantId = new Uri(authUri).Segments[1].Trim('/');

                string scope = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "resource_id");
                if (scope != null)
                {
                    scope += Constants.DefaultScope;
                    _scopes = new string[] { scope };
                }

                TokenRequestContext context = new TokenRequestContext(_scopes, message.Request.ClientRequestId, tenantId: tenantId);
                if (async)
                {
                    await AuthenticateAndAuthorizeRequestAsync(message, context).ConfigureAwait(false);
                }
                else
                {
                    AuthenticateAndAuthorizeRequest(message, context);
                }
                return true;
            }
            catch
            {
                return default;
            }
        }

        internal bool TryGetTokenRequestContextForCaeChallenge(HttpMessage message, out TokenRequestContext tokenRequestContext)
        {
            string decodedClaims = null;
            string encodedClaims = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "claims");
            try
            {
                decodedClaims = encodedClaims switch
                {
                    null => null,
                    { Length: 0 } => null,
                    string enc => Encoding.UTF8.GetString(Convert.FromBase64String(enc))
                };
            }
            catch
            {
                // The claims are not in the expected format. This is not a CAE challenge.
            }
            if (decodedClaims == null)
            {
                tokenRequestContext = default;
                return false;
            }

            tokenRequestContext = new TokenRequestContext(_scopes, message.Request.ClientRequestId, decodedClaims, isCaeEnabled: true);
            return true;
        }
    }
}
