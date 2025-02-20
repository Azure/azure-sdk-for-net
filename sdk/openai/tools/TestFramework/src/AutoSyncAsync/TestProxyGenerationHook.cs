// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Castle.DynamicProxy;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace OpenAI.TestFramework.AutoSyncAsync
{
    /// <summary>
    /// Controls which methods are skipped during dynamic proxy generation.
    /// </summary>
    public class TestProxyGenerationHook : IProxyGenerationHook
    {
        /// <inheritdoc />
        public void MethodsInspected()
        { }

        /// <inheritdoc />
        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        { }

        /// <inheritdoc />
        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            IMethodInfo? testMethod = TestExecutionContext.CurrentContext.CurrentTest.Method;

            if (methodInfo == null
                // Skip for special names (i.e. getters and setters)
                || methodInfo.IsSpecialName
                // Also for dispose methods
                || methodInfo.Name == nameof(IDisposable.Dispose)
                || methodInfo.Name == nameof(IAsyncDisposable.DisposeAsync)
                // If we are running a sync only or async only, skip intercepting altogether
                || testMethod?.IsDefined<SyncOnlyAttribute>(false) == true
                || testMethod?.IsDefined<AsyncOnlyAttribute>(false) == true)
            {
                return false;
            }

            return true;
        }
    }
}
