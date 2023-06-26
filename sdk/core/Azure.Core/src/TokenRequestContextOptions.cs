// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    /// Defines the options of a <see cref="TokenRequestContext" />.
    /// </summary>
    public struct TokenRequestContextOptions
    {
        /// <summary>
        /// The <see cref="Request.ClientRequestId"/> of the request requiring a token for authentication, if applicable.
        /// </summary>
        public string? ParentRequestId { get; set; }

        /// <summary>
        /// Additional claims to be included in the token. See <see href="https://openid.net/specs/openid-connect-core-1_0-final.html#ClaimsParameter">https://openid.net/specs/openid-connect-core-1_0-final.html#ClaimsParameter</see> for more information on format and content.
        /// </summary>
        public string? Claims { get; set; }

        /// <summary>
        /// The tenantId to be included in the token request.
        /// </summary>
        public string? TenantId { get; set; }

        /// <summary>
        /// Indicates whether to enable Conditional Access Exclusion (CAE) for the token request.
        /// </summary>
        public bool EnableCae { get; set; }
    }
}
