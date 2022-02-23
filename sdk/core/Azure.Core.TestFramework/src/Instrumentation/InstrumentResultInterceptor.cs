// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    internal class InstrumentResultInterceptor : IInterceptor
    {
        private static readonly MethodInfo InstrumentOperationInterceptorMethodInfo = typeof(InstrumentResultInterceptor)
            .GetMethod(nameof(InstrumentOperationInterceptor), BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("Unable to find InstrumentOperationInterceptor method");

        private readonly ClientTestBase _testBase;

        public InstrumentResultInterceptor(ClientTestBase testBase)
        {
            _testBase = testBase;
        }

        public void Intercept(IInvocation invocation)
        {
            var type = invocation.Method.ReturnType;

            // We don't want to instrument generated rest clients.
            if ((type.Name.EndsWith("Client") && !type.Name.EndsWith("RestClient") && !type.Name.EndsWith("ExtensionClient")) ||
                // Generated ARM clients will have a property containing the sub-client that ends with Operations.
                //TODO: remove after all track2 .net mgmt libraries are updated to the new generation
                (invocation.Method.Name.StartsWith("get_") && type.Name.EndsWith("Operations")))
            {
                if (IsNullResult(invocation))
                    return;

                invocation.ReturnValue = _testBase.InstrumentClient(type, invocation.ReturnValue, Array.Empty<IInterceptor>());
                return;
            }

            if (
                // Generated ARM clients will have a property containing the sub-client that ends with Operations.
                (invocation.Method.Name.StartsWith("get_") && ManagementInterceptor.InheritsFromArmResource(type)) ||
                // Instrument the container construction methods inside Operations objects
                // Instrument the operations construction methods inside Operations objects
                (invocation.Method.Name.StartsWith("Get") && ManagementInterceptor.InheritsFromArmResource(type)))
            {
                if (IsNullResult(invocation))
                    return;

                invocation.ReturnValue = _testBase.InstrumentClient(type, invocation.ReturnValue, new IInterceptor[] { new ManagementInterceptor(_testBase) });
                return;
            }

            if (type is {IsGenericType: true, GenericTypeArguments: {} arguments } &&
                type.GetGenericTypeDefinition() == typeof(Task<>) &&
                typeof(Operation).IsAssignableFrom(arguments[0]))
            {
                DiagnosticScopeValidatingInterceptor.WrapAsyncResult(invocation, this, InstrumentOperationInterceptorMethodInfo);
                return;
            }

            invocation.Proceed();
        }

        internal async ValueTask<T> InstrumentOperationInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask)
        {
            return (T) _testBase.InstrumentOperation(typeof(T), await innerTask());
        }

        private bool IsNullResult(IInvocation invocation)
        {
            invocation.Proceed();
            return invocation.ReturnValue == null;
        }
    }
}
