﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

#nullable enable

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A policy that sends an <see cref="AccessToken"/> provided by a <see cref="TokenCredential"/> as an Authentication header.
    /// Note: This class is currently in preview and is therefore subject to possible future breaking changes.
    /// </summary>
    internal class ARMChallengeAuthenticationPolicy : BearerTokenChallengeAuthenticationPolicy
    {
        /// <summary>
        /// Creates a new instance of <see cref="ARMChallengeAuthenticationPolicy"/> using provided token credential and scope to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scope">The scope to authenticate for.</param>
        public ARMChallengeAuthenticationPolicy(TokenCredential credential, string scope) : base(credential, new[] { scope }) { }

        /// <summary>
        /// Creates a new instance of <see cref="ARMChallengeAuthenticationPolicy"/> using provided token credential and scopes to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scopes">Scopes to authenticate for.</param>
        public ARMChallengeAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes)
            : base(credential, scopes, TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(30)) { }

        /// <summary>
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// </summary>
        /// <remarks>Handles claims authentication challenges.</remarks>
        /// <param name="message">The <see cref="HttpMessage"/> to be authenticated.</param>
        /// <param name="context">If the return value is <c>true</c>, a <see cref="TokenRequestContext"/>.</param>
        /// <returns>A boolean indicated whether the request contained a valid challenge and a <see cref="TokenRequestContext"/> was successfully initialized with it.</returns>
        protected override bool TryGetTokenRequestContextFromChallenge(HttpMessage message, out TokenRequestContext context)
        {
            context = default;

            var challenge = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "claims");
            if (challenge == null)
            {
                return false;
            }

            string claimsChallenge = Base64Url.DecodeString(challenge.ToString());
           context = new TokenRequestContext(Scopes, message.Request.ClientRequestId, claimsChallenge);
            return true;
        }
    }
}
