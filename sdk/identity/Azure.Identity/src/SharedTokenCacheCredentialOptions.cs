// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="SharedTokenCacheCredential"/> authentication.
    /// </summary>
    public class SharedTokenCacheCredentialOptions : TokenCredentialOptions
    {
        /// <summary>
        /// Specifies the preferred authentication account username, or UPN, to be retrieved from the shared token cache for single sign on authentication with
        /// development tools, in the case multiple accounts are found in the shared token.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Specifies the tenant id of the preferred authentication account, to be retrieved from the shared token cache for single sign on authentication with
        /// development tools, in the case multiple accounts are found in the shared token.
        /// </summary>
        public string TenantId { get; set; }
    }
}
