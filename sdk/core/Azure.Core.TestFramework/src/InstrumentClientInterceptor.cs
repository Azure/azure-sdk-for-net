// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    internal class InstrumentClientInterceptor : IInterceptor
    {
        private readonly ClientTestBase _testBase;

        public InstrumentClientInterceptor(ClientTestBase testBase)
        {
            _testBase = testBase;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            var result = invocation.ReturnValue;
            if (result == null)
            {
                return;
            }

            var type = result.GetType();

            if (
                // We don't want to instrument generated rest clients.
                type.Name.EndsWith("Client") && !type.Name.EndsWith("RestClient"))
            {
                invocation.ReturnValue = _testBase.InstrumentClient(type, result, Array.Empty<IInterceptor>());
                return;
            }

            if (
                // Generated ARM clients will have a property containing the sub-client that ends with Operations.
                (invocation.Method.Name.StartsWith("get_") && (type.Name.EndsWith("Operations") || type.BaseType.Name.EndsWith("Operations"))) ||
                // Instrument the container construction methods inside Operations objects
                (invocation.Method.Name.StartsWith("Get") && type.Name.EndsWith("Container")) ||
                // Instrument the operations construction methods inside Operations objects
                (invocation.Method.Name.StartsWith("Get") && type.Name.EndsWith("Operations")))
            {
                invocation.ReturnValue = _testBase.InstrumentClient(type, result, new IInterceptor[] { new ManagementInterceptor(_testBase) });
            }
        }
    }
}
