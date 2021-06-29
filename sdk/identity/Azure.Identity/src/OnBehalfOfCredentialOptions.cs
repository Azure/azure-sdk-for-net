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
        ///
        /// </summary>
        public OnBehalfOfCredentialOptions()
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cacheOptions"></param>
        public OnBehalfOfCredentialOptions(TokenCachePersistenceOptions cacheOptions)
        {
            TokenCachePersistenceOptions = cacheOptions;
        }

        /// <inheritdoc />
        public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; }
    }
}
