// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    public class ManagementInterceptor : IInterceptor
    {
        private readonly ClientTestBase _testBase;
        private static readonly ProxyGenerator s_proxyGenerator = new ProxyGenerator();

        public ManagementInterceptor(ClientTestBase testBase)
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
            if (type.Name.StartsWith("ValueTask"))
            {
                if ((bool)type.GetProperty("IsFaulted").GetValue(result))
                    return;

                var taskResultType = type.GetGenericArguments()[0];
                if (taskResultType.Name.StartsWith("Response") || taskResultType.Name.StartsWith("ArmResponse"))
                {
                    var taskResult = result.GetType().GetProperty("Result").GetValue(result);
                    var instrumentedResult = _testBase.InstrumentClient(taskResultType, taskResult, new IInterceptor[] { new ManagementInterceptor(_testBase) });
                    var genericValueTask = typeof(ValueTask<>).MakeGenericType(taskResultType);
                    var vtCtor = genericValueTask.GetConstructor(new Type[] { taskResultType });
                    invocation.ReturnValue = vtCtor.Invoke(new object[] { instrumentedResult });
                }
            }
            else if (invocation.Method.Name.EndsWith("Value") && type.BaseType.Name.EndsWith("Operations"))
            {
                invocation.ReturnValue = _testBase.InstrumentClient(type, result, new IInterceptor[] { new ManagementInterceptor(_testBase) });
            }
            else if (type.BaseType.Name.StartsWith("AsyncPageable"))
            {
                invocation.ReturnValue = s_proxyGenerator.CreateClassProxyWithTarget(type, result, new IInterceptor[] { new ManagementInterceptor(_testBase) });
            }
            else if (invocation.Method.Name.StartsWith("Get") && invocation.Method.Name.EndsWith("Enumerator"))
            {
                var wrapperType = typeof(AsyncPageableInterceptor<>);
                var genericType = wrapperType.MakeGenericType(type.GetGenericArguments()[0]);
                var ctor = genericType.GetConstructor(new Type[] { typeof(ClientTestBase), result.GetType() });
                invocation.ReturnValue = ctor.Invoke(new object[] { _testBase, result });
            }
        }
    }
}
