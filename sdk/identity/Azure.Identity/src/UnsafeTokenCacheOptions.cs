// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Options controlling the storage of the token cache.
    /// </summary>
    public abstract class UnsafeTokenCacheOptions : TokenCachePersistenceOptions
    {
        /// <summary>
        /// The delegate to be called when the Updated event fires.
        /// </summary>
        /// <value></value>
        protected internal abstract Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs);

        /// <summary>
        /// The bytes used to initialize the token cache. This would most likely have come from the <see cref="TokenCacheUpdatedArgs"/>.
        /// </summary>
        /// <value></value>
        protected internal abstract Task<ReadOnlyMemory<byte>> RefreshCacheAsync();
    }
}
