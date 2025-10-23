// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

internal class ProxyResultInterceptor : IInterceptor
{
    private readonly ClientTestBase _testBase;

    public ProxyResultInterceptor(ClientTestBase testBase)
    {
        _testBase = testBase;
    }

    public void Intercept(IInvocation invocation)
    {
        var type = invocation.Method.ReturnType;

        // We don't want to instrument generated rest clients.
        if ((type.Name.EndsWith("Client") && !type.Name.EndsWith("RestClient") && !type.Name.EndsWith("ExtensionClient")))
        {
            if (IsNullResult(invocation))
                return;

            if (invocation.ReturnValue is null)
            {
                throw new InvalidOperationException("Unexpected error: Could not find original client.");
            }

            invocation.ReturnValue = _testBase.CreateProxyFromClient(type, invocation.ReturnValue, Array.Empty<IInterceptor>());
            return;
        }

        invocation.Proceed();
    }

    private bool IsNullResult(IInvocation invocation)
    {
        invocation.Proceed();
        return invocation.ReturnValue == null;
    }
}
