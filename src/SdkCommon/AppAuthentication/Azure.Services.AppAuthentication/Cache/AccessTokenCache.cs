// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Cache for access tokens. 
    /// </summary>
    internal class AccessTokenCache
    {
        private static readonly ConcurrentDictionary<string, Tuple<AccessToken, Principal>> CacheDictionary = new ConcurrentDictionary<string, Tuple<AccessToken, Principal>>();

        /// <summary>
        /// Gets the token from the cache. If it is present, and not about to expire, it is returned. 
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static Tuple<AccessToken, Principal> Get(string cacheKey)
        {
            Tuple<AccessToken, Principal> tokenTuple;

            if (CacheDictionary.TryGetValue(cacheKey, out tokenTuple))
            {
                if (tokenTuple?.Item1 != null && !tokenTuple.Item1.IsAboutToExpire())
                {
                    return tokenTuple;
                }
            }

            return null;
        }

        /// <summary>
        /// Tuple of access token and principal are added to the cache after the token is aquired. 
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="tokenTuple"></param>
        public static void AddOrUpdate(string cacheKey, Tuple<AccessToken, Principal> tokenTuple)
        {
            CacheDictionary.AddOrUpdate(cacheKey, tokenTuple, (s, tuple) => tokenTuple);
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
