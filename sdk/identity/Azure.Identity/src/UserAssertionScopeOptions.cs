// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Options used to initialize a <see cref="UserAssertionScope"/> instance.
    /// </summary>
    public class UserAssertionScopeOptions
    {
        /// <summary>
        /// The delegate to be called which retrieves the cache from persistence for this user assertion partition.
        /// </summary>
        public Func<TokenCacheNotificationDetails, Task<UserAssertionCacheDetails>> HydrateCache { get; set; }

        /// <summary>
        /// The delegate to be called with the current state of the token cache on each time it is updated for this <see cref="UserAssertionScope"/> instance.
        /// </summary>
        public Func<UserAssertionCacheDetails, Task> PersistCache { get; set; }
    }
}
