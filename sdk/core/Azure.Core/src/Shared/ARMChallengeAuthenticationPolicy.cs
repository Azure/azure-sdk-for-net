// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A policy that sends an <see cref="AccessToken"/> provided by a <see cref="TokenCredential"/> as an Authentication header.
    /// Note: This class is currently in preview and is therefore subject to possible future breaking changes.
    /// </summary>
    internal class ARMChallengeAuthenticationPolicy : BearerTokenAuthenticationPolicy
    {
        private readonly string[] _scopes;

        /// <summary>
        /// Creates a new instance of <see cref="ARMChallengeAuthenticationPolicy"/> using provided token credential and scope to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scope">The scope to authenticate for.</param>
        public ARMChallengeAuthenticationPolicy(TokenCredential credential, string scope) : base(credential, new[] { scope })
        {
            _scopes = new[] { scope };
        }

        /// <summary>
        /// Creates a new instance of <see cref="ARMChallengeAuthenticationPolicy"/> using provided token credential and scopes to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scopes">Scopes to authenticate for.</param>
        public ARMChallengeAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes) : base(credential, scopes)
        {
            _scopes = scopes.ToArray();
        }

        /// <inheritdoc cref="BearerTokenChallengeAuthenticationPolicy.AuthorizeRequestOnChallengeAsync" />
        protected override async ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message)
        {
            var challenge = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "claims");
            if (challenge == null)
            {
                return false;
            }

            string claimsChallenge = Base64Url.DecodeString(challenge);
            var context = new TokenRequestContext(_scopes, message.Request.ClientRequestId, claimsChallenge);
            await AuthenticateAndAuthorizeRequestAsync(message, context);
            return true;
        }

        /// <inheritdoc cref="BearerTokenChallengeAuthenticationPolicy.AuthorizeRequestOnChallengeAsync" />
        protected override bool AuthorizeRequestOnChallenge(HttpMessage message)
        {
            var challenge = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "claims");
            if (challenge == null)
            {
                return false;
            }

            string claimsChallenge = Base64Url.DecodeString(challenge);
            var context = new TokenRequestContext(_scopes, message.Request.ClientRequestId, claimsChallenge);
            AuthenticateAndAuthorizeRequest(message, context);
            return true;
        }
    }
}
