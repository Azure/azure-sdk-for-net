// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options used to configure the <see cref="ClientSecretCredential"/>.
    /// </summary>
    public class ClientSecretCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {
        /// <summary>
        /// Specifies the <see cref="TokenCacheOptions"/> to be used by the credential.
        /// </summary>
        public TokenCacheOptions TokenCacheOptions { get; set; }
    }
}
