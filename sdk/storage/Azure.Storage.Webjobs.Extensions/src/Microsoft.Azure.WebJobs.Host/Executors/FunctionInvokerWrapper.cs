// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    /// <summary>
    /// Wraps an instance of an <see cref="IFunctionInvoker"/> into an implementation of <see cref="IFunctionInvokerEx"/>, maintaining 
    /// the behavior of the wrapped instance.
    /// </summary>
    internal class FunctionInvokerWrapper : IFunctionInvokerEx
    {
        private readonly IFunctionInvoker _functionInvoker;

        public FunctionInvokerWrapper(IFunctionInvoker functionInvoker)
        {
            _functionInvoker = functionInvoker;
        }

        public IReadOnlyList<string> ParameterNames => _functionInvoker.ParameterNames;

        public object CreateInstance(IFunctionInstanceEx functionInstance)
        {
            return CreateInstance();
        }

        public object CreateInstance()
        {
            return _functionInvoker.CreateInstance();
        }

        public Task<object> InvokeAsync(object instance, object[] arguments)
        {
            return _functionInvoker.InvokeAsync(instance, arguments);
        }
    }
}
