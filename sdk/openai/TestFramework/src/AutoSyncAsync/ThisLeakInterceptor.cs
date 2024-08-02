// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Castle.DynamicProxy;

namespace OpenAI.TestFramework.AutoSyncAsync;

/// <summary>
/// A basic interceptor that prevents the leaking of the original un-proxied this instance as a return value.
/// </summary>
public class ThisLeakInterceptor : IInterceptor
{
    /// <inheritdoc />
    [DebuggerStepThrough]
    public void Intercept(IInvocation invocation)
    {
        invocation.Proceed();

        if (invocation.ReturnValue == invocation.InvocationTarget)
        {
            invocation.ReturnValue = invocation.Proxy;
        }
    }
}
