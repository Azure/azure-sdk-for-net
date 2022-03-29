// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Details related to a <see cref="UnsafeTokenCacheOptions"/> cache delegate.
    /// </summary>
    public struct TokenCacheData
    {
        /// <summary>
        /// Constructs a new <see cref="TokenCacheData"/> instance with the specified cache bytes.
        /// </summary>
        /// <param name="cacheBytes">The serialized content of the token cache.</param>
        public TokenCacheData(ReadOnlyMemory<byte> cacheBytes)
        {
            CacheBytes = cacheBytes;
        }

        /// <summary>
        /// The bytes representing the state of the token cache.
        /// </summary>
        public ReadOnlyMemory<byte> CacheBytes { get; }
    }
}
