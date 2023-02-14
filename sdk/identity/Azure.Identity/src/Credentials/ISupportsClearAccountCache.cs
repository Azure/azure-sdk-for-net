// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal interface ISupportsClearAccountCache
    {
        /// <summary>
        /// Clears the token cache for the currently logged in account.
        /// </summary>
        public void ClearAccountCache(CancellationToken cancellationToken = default);

        /// <summary>
        /// Clears the token cache for the currently logged in account.
        /// </summary>
        public Task ClearAccountCacheAsync(CancellationToken cancellationToken = default);
    }
}
