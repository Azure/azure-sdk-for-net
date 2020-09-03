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
            if (type.Name.EndsWith("Client") ||
                // Generated ARM clients will have a property containing the subclient that ends with Operations.
                (invocation.Method.Name.StartsWith("get_") && type.Name.EndsWith("Operations")))
            {
                invocation.ReturnValue = _testBase.InstrumentClient(type, result, Array.Empty<IInterceptor>());
            }
        }
    }
}
