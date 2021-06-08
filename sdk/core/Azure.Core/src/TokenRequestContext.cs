﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
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
            Claims = default;
            TenantId = default;
        }

        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        /// <param name="claims">Additional claims to be included in the token.</param>
        public TokenRequestContext(string[] scopes, string? parentRequestId, string? claims)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            Claims = claims;
            TenantId = default;
        }

        /// <summary>
        /// Creates a new TokenRequest with the specified scopes.
        /// </summary>
        /// <param name="scopes">The scopes required for the token.</param>
        /// <param name="parentRequestId">The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.</param>
        /// <param name="claims">Additional claims to be included in the token.</param>
        /// <param name="tenantId"> The tenantId to be included in the token request. </param>
        public TokenRequestContext(string[] scopes, string? parentRequestId = null, string? claims = null, string? tenantId = null)
        {
            Scopes = scopes;
            ParentRequestId = parentRequestId;
            Claims = claims;
            TenantId = tenantId;
        }

        /// <summary>
        /// The scopes required for the token.
        /// </summary>
        public string[] Scopes { get; }

        /// <summary>
        /// The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.
        /// </summary>
        public string? ParentRequestId { get; }

        /// <summary>
        /// Additional claims to be included in the token. See <see href="https://openid.net/specs/openid-connect-core-1_0-final.html#ClaimsParameter">https://openid.net/specs/openid-connect-core-1_0-final.html#ClaimsParameter</see> for more information on format and content.
        /// </summary>
        public string? Claims { get; }

        /// <summary>
        /// The tenantId to be included in the token request.
        /// </summary>
        public string? TenantId { get; }
    }
}
