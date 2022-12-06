// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests
{
    internal static class StaticCachesUtilities
    {
        private static readonly Lazy<Action> s_clearStaticMetadataProvider = new Lazy<Action>(() =>
        {
            Type staticMetadataProviderType = typeof(PublicClientApplication).Assembly.GetType("Microsoft.Identity.Client.Instance.Discovery.NetworkCacheMetadataProvider", true);
            MethodInfo clearMethod = staticMetadataProviderType.GetMethod("Clear", BindingFlags.Public | BindingFlags.Instance);
            NewExpression callConstructor = Expression.New(staticMetadataProviderType);
            MethodCallExpression invokeClear = Expression.Call(callConstructor, clearMethod);
            return Expression.Lambda<Action>(invokeClear).Compile();
        });
        public static void ClearStaticMetadataProviderCache() => s_clearStaticMetadataProvider.Value();
    }
}
