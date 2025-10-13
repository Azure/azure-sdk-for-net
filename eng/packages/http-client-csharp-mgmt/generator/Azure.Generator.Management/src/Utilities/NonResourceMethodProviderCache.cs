// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Azure.Generator.Management.Utilities
{
    /// <summary>
    /// Utility class that provides caching for method providers created from non-resource methods.
    /// This is a thread-safe cache that stores method providers for reuse.
    /// </summary>
    internal static class NonResourceMethodProviderCache
    {
        /// <summary>
        /// Private backing field for the method provider cache.
        /// Using ConcurrentDictionary for thread safety.
        /// </summary>
        private static readonly ConcurrentDictionary<MethodProvider, byte> _methodProviderCache = new();

        /// <summary>
        /// Placeholder value used in the cache dictionary. The value is not used; only the key matters.
        /// </summary>
        private const byte CachePlaceholderValue = 0;

        /// <summary>
        /// Adds a method provider to the cache.
        /// </summary>
        /// <param name="methodProvider">The method provider to add to the cache.</param>
        public static void Add(MethodProvider methodProvider)
        {
            _methodProviderCache.TryAdd(methodProvider, CachePlaceholderValue);
        }

        /// <summary>
        /// Determines whether the cache contains the specified method provider.
        /// </summary>
        /// <param name="methodProvider">The method provider to locate in the cache.</param>
        /// <returns>true if the cache contains the method provider; otherwise, false.</returns>
        public static bool Contains(MethodProvider methodProvider)
        {
            return _methodProviderCache.ContainsKey(methodProvider);
        }
    }
}