// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    internal class ManagementInterceptor : IInterceptor
    {
        private readonly ClientTestBase _testBase;

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

            if (type.Name.StartsWith("Task"))
            {
                var taskResultType = type.GetGenericArguments()[0];
                if (taskResultType.Name.StartsWith("ArmResponse") || taskResultType.Name.StartsWith("ArmOperation"))
                {
                    var taskResult = result.GetType().GetProperty("Result").GetValue(result);
                    var instrumentedResult = _testBase.InstrumentClient(taskResultType, taskResult, new IInterceptor[] { new ManagementInterceptor(_testBase) });
                    var method = typeof(Task).GetMethod("FromResult", BindingFlags.Public | BindingFlags.Static);
                    var genericMethod = method.MakeGenericMethod(taskResult.GetType().BaseType);
                    invocation.ReturnValue = genericMethod.Invoke(null, new object[] { instrumentedResult });
                }
            }
            else if (invocation.Method.Name.EndsWith("Value") && type.BaseType.Name.EndsWith("Operations"))
            {
                invocation.ReturnValue = _testBase.InstrumentClient(type, result, new IInterceptor[] { new ManagementInterceptor(_testBase) });
            }
        }
    }
}
