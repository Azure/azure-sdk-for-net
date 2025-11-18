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
            Type staticMetadataProviderType = typeof(PublicClientApplication).Assembly.GetType("Microsoft.Identity.Client.Instance.Discovery.NetworkCacheMetadataProvider", false);

            // Return no-op if the type doesn't exist (MSAL implementation changed)
            if (staticMetadataProviderType == null)
            {
                return () => { };
            }

            // Try new method name first (MSAL 4.79+)
            MethodInfo clearMethod = staticMetadataProviderType.GetMethod("ResetStaticCacheForTest", BindingFlags.NonPublic | BindingFlags.Static);

            // Fallback to old method name for older MSAL versions
            if (clearMethod == null)
            {
                clearMethod = staticMetadataProviderType.GetMethod("Clear", BindingFlags.Public | BindingFlags.Instance);
            }

            // Return no-op if neither method exists
            if (clearMethod == null)
            {
                return () => { };
            }

            // If it's a static method, call it directly; otherwise create an instance
            if (clearMethod.IsStatic)
            {
                MethodCallExpression invokeStatic = Expression.Call(clearMethod);
                return Expression.Lambda<Action>(invokeStatic).Compile();
            }
            else
            {
                NewExpression callConstructor = Expression.New(staticMetadataProviderType);
                MethodCallExpression invokeClear = Expression.Call(callConstructor, clearMethod);
                return Expression.Lambda<Action>(invokeClear).Compile();
            }
        });
        public static void ClearStaticMetadataProviderCache() => s_clearStaticMetadataProvider.Value();
    }
}
