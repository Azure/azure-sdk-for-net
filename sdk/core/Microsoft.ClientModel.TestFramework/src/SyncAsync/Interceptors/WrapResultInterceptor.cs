// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

internal class WrapResultInterceptor
{
    internal class InstrumentResultInterceptor : IInterceptor
    {
        //private static readonly MethodInfo InstrumentOperationInterceptorMethodInfo = typeof(InstrumentResultInterceptor)
        //    .GetMethod(nameof(InstrumentOperationInterceptor), BindingFlags.NonPublic | BindingFlags.Instance)
        //    ?? throw new InvalidOperationException("Unable to find InstrumentOperationInterceptor method");

        private readonly ClientTestBase _testBase;
        private readonly RecordedTestMode _testMode;

        public InstrumentResultInterceptor(ClientTestBase testBase)
        {
            _testBase = testBase;
            // non-recorded tests are treated like Playback mode
            _testMode = testBase is RecordedTestBase recordedTestBase ? recordedTestBase.Mode : RecordedTestMode.Playback;
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

                invocation.ReturnValue = _testBase.InstrumentClient(type, invocation.ReturnValue! /* TODO */, Array.Empty<IInterceptor>());
                return;
            }

            if (type is { IsGenericType: true, GenericTypeArguments: { } arguments } &&
                type.GetGenericTypeDefinition() == typeof(Task<>) &&
                typeof(OperationResult).IsAssignableFrom(arguments[0]))
            {
                // TODO - LRO implementation
            }

            invocation.Proceed();
        }

        //internal async ValueTask<T> InstrumentOperationInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask)
        //{
        //    return (T)_testBase.InstrumentOperation(typeof(T), await innerTask());
        //}

        private bool IsNullResult(IInvocation invocation)
        {
            invocation.Proceed();
            return invocation.ReturnValue == null;
        }
    }
}
