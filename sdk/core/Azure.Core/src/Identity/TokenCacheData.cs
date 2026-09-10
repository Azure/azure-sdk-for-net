// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Runtime.CompilerServices;

namespace Azure.Identity
{
    /// <summary>
    /// Details related to a <see cref="UnsafeTokenCacheOptions"/> cache delegate.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
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
#pragma warning restore AZC0034
}
