// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Identity
{
    /// <summary>
    /// Data regarding an update of a <see cref="TokenCache"/>.
    /// </summary>
    public class TokenCacheUpdatedArgs : SyncAsyncEventArgs
    {
        internal TokenCacheUpdatedArgs(
            TokenCache cache,
            bool isRunningSynchronously,
            CancellationToken cancellationToken = default)
            : base(isRunningSynchronously, cancellationToken)
        {
            Cache = cache;
        }

        /// <summary>
        /// The <see cref="TokenCache"/> instance which was updated.
        /// </summary>
        public TokenCache Cache { get; }
    }
}
