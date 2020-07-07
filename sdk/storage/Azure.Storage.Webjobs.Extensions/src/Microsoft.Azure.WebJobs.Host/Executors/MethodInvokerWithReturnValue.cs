// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class MethodInvokerWithReturnValue<TReflected, TReturnValue> : IMethodInvoker<TReflected, TReturnValue>
    {
        private readonly Func<TReflected, object[], TReturnValue> _lambda;

        public MethodInvokerWithReturnValue(Func<TReflected, object[], TReturnValue> lambda)
        {
            _lambda = lambda;
        }

        public Task<TReturnValue> InvokeAsync(TReflected instance, object[] arguments)
        {
            TReturnValue result = _lambda.Invoke(instance, arguments);
            return Task.FromResult(result);
        }
    }
}
