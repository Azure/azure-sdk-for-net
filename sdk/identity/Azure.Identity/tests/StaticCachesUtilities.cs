// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests
{
    internal static class StaticCachesUtilities
    {
        private static readonly Action s_noOpAction = () => { };

        internal static readonly Lazy<Action> s_clearStaticMetadataProvider = new Lazy<Action>(() =>
        {
            Type staticMetadataProviderType = typeof(PublicClientApplication).Assembly.GetType("Microsoft.Identity.Client.Instance.Discovery.NetworkCacheMetadataProvider", false);
            if (staticMetadataProviderType == null)
            {
                return s_noOpAction;
            }

            MethodInfo resetMethod = staticMetadataProviderType.GetMethod("ResetStaticCacheForTest", BindingFlags.NonPublic | BindingFlags.Static);
            if (resetMethod == null)
            {
                return s_noOpAction;
            }

            return Expression.Lambda<Action>(Expression.Call(resetMethod)).Compile();
        });

        public static void ClearStaticMetadataProviderCache()
        {
            s_clearStaticMetadataProvider.Value();
        }
    }
}
