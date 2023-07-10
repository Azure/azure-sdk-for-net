// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Data regarding an update of a token cache.
    /// </summary>
    public class TokenCacheUpdatedArgs
    {
        internal TokenCacheUpdatedArgs(ReadOnlyMemory<byte> cacheData, bool enableCae)
        {
            UnsafeCacheData = cacheData;
            IsCaeEnabled = enableCae;
        }

        /// <summary>
        /// The <see cref="TokenCachePersistenceOptions"/> instance which was updated.
        /// </summary>
        public ReadOnlyMemory<byte> UnsafeCacheData { get; }

        /// <summary>
        /// Whether or not the cache is enabled for CAE.
        /// </summary>
        public bool IsCaeEnabled { get; }
    }
}
