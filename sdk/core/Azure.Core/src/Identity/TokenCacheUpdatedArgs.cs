// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Runtime.CompilerServices;

namespace Azure.Identity
{
    /// <summary>
    /// Data regarding an update of a token cache.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
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
        /// Whether or not the cache is enabled for CAE. Note that this value should be used as an indicator for how the cache will be partitioned.
        /// Token cache refresh events with this value set to `true` will originate from a different cache instance than those with this value set to `false`.
        /// </summary>
        public bool IsCaeEnabled { get; }
    }
#pragma warning restore AZC0034
}
