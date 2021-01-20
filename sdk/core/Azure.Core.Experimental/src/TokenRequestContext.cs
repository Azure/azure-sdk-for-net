// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Experimental
{
    /// <summary>
    /// Contains the details of an authentication token request.
    /// </summary>
    public readonly struct TokenRequestContext
    {
        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        public TokenRequestContext(string[] scopes, string? parentRequestId)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            ClaimsChallenge = default;
        }

        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        /// <param name="claimsChallenge">A claims challenge returned from a failed authentication or authorization request.</param>
        public TokenRequestContext(string[] scopes, string? parentRequestId = default, string? claimsChallenge = default)
        {
            Scopes = scopes;
            ClaimsChallenge = claimsChallenge;
            ParentRequestId = parentRequestId;
        }

        /// <summary>
        /// The scopes required for the token.
        /// </summary>
        public string[] Scopes { get; }

        /// <summary>
        /// A claims challenge returned from a failed authentication or authorization request.
        /// </summary>
        public string? ClaimsChallenge { get; }

        /// <summary>
        /// The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.
        /// </summary>
        public string? ParentRequestId { get; }
    }
}
