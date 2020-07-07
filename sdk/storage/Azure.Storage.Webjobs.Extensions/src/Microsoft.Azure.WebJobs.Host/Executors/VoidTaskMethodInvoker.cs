// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class VoidTaskMethodInvoker<TReflected, TReturnType> : IMethodInvoker<TReflected, TReturnType>
    {
        private readonly Func<TReflected, object[], Task> _lambda;

        public VoidTaskMethodInvoker(Func<TReflected, object[], Task> lambda)
        {
            _lambda = lambda;
        }

        public async Task<TReturnType> InvokeAsync(TReflected instance, object[] arguments)
        {
            await _lambda.Invoke(instance, arguments);
            return default(TReturnType);
        }
    }
}
