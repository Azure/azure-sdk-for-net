// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
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
        protected internal abstract Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs);

        /// <summary>
        /// Returns the bytes used to initialize the token cache. This would most likely have come from the <see cref="TokenCacheUpdatedArgs"/>.
        /// This implementation will get called by the default implementation of <see cref="RefreshCacheAsync(TokenCacheRefreshArgs, CancellationToken)"/>.
        /// It is recommended to provide an implementation for <see cref="RefreshCacheAsync(TokenCacheRefreshArgs, CancellationToken)"/> rather than this method.
        /// </summary>
        protected internal abstract Task<ReadOnlyMemory<byte>> RefreshCacheAsync();

        /// <summary>
        /// Returns the bytes used to initialize the token cache. This would most likely have come from the <see cref="TokenCacheUpdatedArgs"/>.
        /// It is recommended that if this method is overriden, there is no need to provide a duplicate implementation for the parameterless <see cref="RefreshCacheAsync()"/>.
        /// </summary>
        /// <param name="args">The <see cref="TokenCacheRefreshArgs"/> containing information about the current state of the cache.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> controlling the lifetime of this operation.</param>
        protected internal virtual async Task<TokenCacheData> RefreshCacheAsync(TokenCacheRefreshArgs args, CancellationToken cancellationToken = default) =>
             new TokenCacheData(await RefreshCacheAsync().ConfigureAwait(false));
    }
}
