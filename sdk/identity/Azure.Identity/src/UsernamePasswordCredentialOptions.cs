// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options to configure the <see cref="UsernamePasswordCredential"/>.
    /// </summary>
    public class UsernamePasswordCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {
        /// <summary>
        /// Specifies the <see cref="TokenCache"/> to be used by the credential.
        /// </summary>
        public TokenCache TokenCache { get; set; }
    }
}
