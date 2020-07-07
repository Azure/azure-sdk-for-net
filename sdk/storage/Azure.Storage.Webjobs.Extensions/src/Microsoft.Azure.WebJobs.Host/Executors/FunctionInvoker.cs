// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class FunctionInvoker<TReflected, TReturnValue> : IFunctionInvokerEx
    {
        private readonly IReadOnlyList<string> _parameterNames;
        private readonly IJobInstanceFactory<TReflected> _instanceFactory;
        private readonly IMethodInvoker<TReflected, TReturnValue> _methodInvoker;

        public FunctionInvoker(
            IReadOnlyList<string> parameterNames,
            IJobInstanceFactory<TReflected> instanceFactory,
            IMethodInvoker<TReflected, TReturnValue> methodInvoker)
        {
            _parameterNames = parameterNames ?? throw new ArgumentNullException(nameof(parameterNames));
            _instanceFactory = instanceFactory ?? throw new ArgumentNullException(nameof(instanceFactory));
            _methodInvoker = methodInvoker ?? throw new ArgumentNullException(nameof(methodInvoker));
        }

        public IJobInstanceFactory<TReflected> InstanceFactory
        {
            get { return _instanceFactory; }
        }

        public IReadOnlyList<string> ParameterNames
        {
            get { return _parameterNames; }
        }


        public object CreateInstance()
        {
            throw new NotSupportedException($"{nameof(CreateInstance)} is not supported, please use the overload that accepts an {nameof(IFunctionInstance)} argument.");
        }

        public object CreateInstance(IFunctionInstanceEx functionInstance)
        {
            return _instanceFactory.Create(functionInstance);
        }

        public async Task<object> InvokeAsync(object instance, object[] arguments)
        {
            // Return a task immediately in case the method is not async.
            await Task.Yield();

            return await _methodInvoker.InvokeAsync((TReflected)instance, arguments);
        }
    }
}
