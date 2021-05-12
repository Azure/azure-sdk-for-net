// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    /// Options for <see cref="TokenRequestContext"/> initialization.
    /// </summary>
    public struct TokenRequestContextOptions
    {
        /// <summary>
        /// The scopes required for the token.
        /// </summary>
        public string[] Scopes { get; set; }

        /// <summary>
        /// The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.
        /// </summary>
        public string? ParentRequestId { get; set; }

        /// <summary>
        /// Additional claims to be included in the token. See <see href="https://openid.net/specs/openid-connect-core-1_0-final.html#ClaimsParameter">https://openid.net/specs/openid-connect-core-1_0-final.html#ClaimsParameter</see> for more information on format and content.
        /// </summary>
        public string? Claims { get; set; }

        /// <summary>
        /// A hint to indicate which tenantId is preferred.
        /// </summary>
        public string? TenantIdHint { get; set; }
    }
}
