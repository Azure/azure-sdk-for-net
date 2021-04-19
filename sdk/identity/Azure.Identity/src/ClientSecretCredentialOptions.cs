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
        /// Specifies the <see cref="TokenCachePersistenceOptions"/> to be used by the credential. If not options are specified, the token cache will not be persisted.
        /// </summary>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
}
