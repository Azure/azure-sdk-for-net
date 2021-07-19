// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    ///
    /// </summary>
    public class OnBehalfOfCredentialOptions : TokenCredentialOptions, ITokenCacheOptions
    {
        /// <summary>
        /// The <see cref="TokenCachePersistenceOptions"/>.
        /// </summary>
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
}
