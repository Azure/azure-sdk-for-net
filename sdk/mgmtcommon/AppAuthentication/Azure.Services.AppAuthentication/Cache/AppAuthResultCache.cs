// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Cache for app authentication results 
    /// </summary>
    internal class AppAuthResultCache
    {
        private static readonly ConcurrentDictionary<string, Tuple<AppAuthenticationResult, Principal>> CacheDictionary = new ConcurrentDictionary<string, Tuple<AppAuthenticationResult, Principal>>();

        /// <summary>
        /// Gets the app authentication result from the cache. If it is present, and token is not about to expire, it is returned.
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static Tuple<AppAuthenticationResult, Principal> Get(string cacheKey)
        {
            Tuple<AppAuthenticationResult, Principal> resultTuple;

            if (CacheDictionary.TryGetValue(cacheKey, out resultTuple))
            {
                if (resultTuple?.Item1 != null && !resultTuple.Item1.IsNearExpiry())
                {
                    return resultTuple;
                }
            }

            return null;
        }

        /// <summary>
        /// Tuple of app authentication result and principal are added to the cache after the token is acquired.
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="resultTuple"></param>
        public static void AddOrUpdate(string cacheKey, Tuple<AppAuthenticationResult, Principal> resultTuple)
        {
            CacheDictionary.AddOrUpdate(cacheKey, resultTuple, (s, tuple) => resultTuple);
        }

        /// <summary>
        /// This is for unit testing
        /// </summary>
        internal static void Clear()
        {
            CacheDictionary.Clear();
        }

    }
}
