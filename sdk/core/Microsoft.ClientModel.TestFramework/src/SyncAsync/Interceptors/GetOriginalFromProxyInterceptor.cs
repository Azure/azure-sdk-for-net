// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Implements the <see cref="IProxiedClient"/>. Returns the
/// original value when <see cref="IProxiedClient.Original"/> is called.
/// </summary>
internal class GetOriginalInterceptor : IInterceptor
{
    private readonly object _original;

    public GetOriginalInterceptor(object original)
    {
        _original = original;
    }

    public void Intercept(IInvocation invocation)
    {
        if (invocation.Method.DeclaringType == typeof(IProxiedClient))
        {
            invocation.ReturnValue = _original;
        }
        else
        {
            invocation.Proceed();
        }
    }
}
