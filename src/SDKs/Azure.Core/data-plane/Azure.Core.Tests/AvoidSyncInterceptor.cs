// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Castle.DynamicProxy;

namespace Azure.Core.Tests
{
    /// <summary>
    /// Ensures that tests sticks to calling only async methods
    /// </summary>
    public class AvoidSyncInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (!invocation.Method.Name.EndsWith("Async"))
            {
                throw new InvalidOperationException("Async method call expected");
            }

            invocation.Proceed();
        }
    }
}
