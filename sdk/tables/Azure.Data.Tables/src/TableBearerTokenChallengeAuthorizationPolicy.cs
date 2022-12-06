// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.Tables
{
    /// <summary>
    /// The Tables authorization policy which supports challenges including tenantId discovery.
    /// </summary>
    internal class TableBearerTokenChallengeAuthorizationPolicy : BearerTokenAuthenticationPolicy
    {
        private volatile string[] _scopes;
        private volatile string _tenantId;
        private readonly bool _enableTenantDiscovery;

        /// <summary>
        /// Initializes an instance of the <see cref="TableBearerTokenChallengeAuthorizationPolicy"/>.
        /// </summary>
        /// <param name="credential">The credential to be used for fetching tokens.</param>
        /// <param name="scope">The scope used by the credential.</param>
        /// <param name="enableTenantDiscovery">Determines if tenant discovery should be enabled.</param>
        public TableBearerTokenChallengeAuthorizationPolicy(TokenCredential credential, string scope, bool enableTenantDiscovery) : base(credential, scope)
        {
            Argument.AssertNotNullOrEmpty(scope, nameof(scope));
            _scopes = new[] { scope };
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
            if (_tenantId != null || !_enableTenantDiscovery)
            {
                TokenRequestContext context = new TokenRequestContext(_scopes, message.Request.ClientRequestId, tenantId: _tenantId);
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
                var authUri = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "authorization_uri");

                // tenantId should be the guid as seen in this example: https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47/oauth2/authorize
                _tenantId = new Uri(authUri).Segments[1].Trim('/');

                TokenRequestContext context = new TokenRequestContext(_scopes, message.Request.ClientRequestId, tenantId: _tenantId);
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
    }
}
