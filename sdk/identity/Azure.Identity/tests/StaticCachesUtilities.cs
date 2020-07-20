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

        private static readonly Lazy<Action> s_clearAuthorityEndpointResolutionManager = new Lazy<Action>(() =>
        {
            var assembly = typeof(PublicClientApplication).Assembly;
            Type authorityEndpointResolutionManagerType = assembly.GetType("Microsoft.Identity.Client.Instance.AuthorityEndpointResolutionManager", true);
            Type iServiceBundleType = assembly.GetType("Microsoft.Identity.Client.Internal.IServiceBundle", true);
            Type booleanType = typeof(bool);

            ConstructorInfo[] constructors = authorityEndpointResolutionManagerType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (ConstructorInfo constructor in constructors)
            {
                var parameters = constructor.GetParameters();
                if (parameters.Length == 2 && parameters[0].ParameterType == iServiceBundleType && parameters[1].ParameterType == booleanType)
                {
                    NewExpression callConstructor = Expression.New(constructor, Expression.Constant(null, iServiceBundleType), Expression.Constant(true, booleanType));
                    return Expression.Lambda<Action>(callConstructor).Compile();
                }
            }

            throw new InvalidOperationException("Constructor wasn't found");
        });

        public static void ClearStaticMetadataProviderCache() => s_clearStaticMetadataProvider.Value();
        public static void ClearAuthorityEndpointResolutionManagerCache() => s_clearAuthorityEndpointResolutionManager.Value();
    }
}
