// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    public class ManagementInterceptor : IInterceptor
    {
        private readonly ClientTestBase _testBase;
        private readonly RecordedTestMode _testMode;
        private static readonly ProxyGenerator s_proxyGenerator = new ProxyGenerator();

        public ManagementInterceptor(ClientTestBase testBase)
        {
            _testBase = testBase;
            _testMode = testBase is RecordedTestBase recordedTestBase ? recordedTestBase.Mode : RecordedTestMode.Playback;
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
            if (TaskExtensions.IsTaskType(type))
            {
                if (TaskExtensions.IsTaskFaulted(result))
                    return;

                var taskResultType = type.GetGenericArguments()[0];
                if (taskResultType.Name.StartsWith("Response") || InheritsFromArmResource(taskResultType))
                {
                    var taskResult = TaskExtensions.GetResultFromTask(result);
                    var instrumentedResult = _testBase.InstrumentClient(taskResultType, taskResult, new IInterceptor[] { new ManagementInterceptor(_testBase) });
                    invocation.ReturnValue = type.Name.StartsWith("ValueTask")
                        ? GetValueFromValueTask(taskResultType, instrumentedResult)
                        : TaskExtensions.GetValueFromTask(taskResultType, instrumentedResult);
                }
            }
            else if (invocation.Method.Name.EndsWith("Value") && InheritsFromArmResource(type))
            {
                invocation.ReturnValue = _testBase.InstrumentClient(type, result, new IInterceptor[] { new ManagementInterceptor(_testBase) });
            }
            else if (type.BaseType.Name.StartsWith("AsyncPageable"))
            {
                invocation.ReturnValue = s_proxyGenerator.CreateClassProxyWithTarget(type, result, new IInterceptor[] { new ManagementInterceptor(_testBase) });
            }
            else if (invocation.Method.Name.StartsWith("Get") &&
                invocation.Method.Name.EndsWith("Enumerator") &&
                type.IsGenericType &&
                InheritsFromArmResource(type.GetGenericArguments().First()))
            {
                var wrapperType = typeof(AsyncPageableInterceptor<>);
                var genericType = wrapperType.MakeGenericType(type.GetGenericArguments()[0]);
                var ctor = genericType.GetConstructor(new Type[] { typeof(ClientTestBase), result.GetType() });
                invocation.ReturnValue = ctor.Invoke(new object[] { _testBase, result });
            }
        }

        private static bool IsLro(Type returnType)
        {
            if (returnType.Name.StartsWith("Task"))
            {
                returnType = returnType.GetGenericArguments()[0];
            }

            return returnType.IsSubclassOf(typeof(Operation));
        }

        internal static bool InheritsFromArmResource(Type elementType)
        {
            if (elementType.BaseType == null)
                return false;

            if (elementType.BaseType == typeof(object))
                return false;

            if (elementType.BaseType.Name.Equals("ArmResource", StringComparison.Ordinal) || elementType.BaseType.Name.Equals("ArmCollection", StringComparison.Ordinal))
                return true;

            return InheritsFromArmResource(elementType.BaseType);
        }

        private object GetValueFromValueTask(Type taskResultType, object instrumentedResult)
        {
            var genericValueTask = typeof(ValueTask<>).MakeGenericType(taskResultType);
            var vtCtor = genericValueTask.GetConstructor(new Type[] { taskResultType });
            return vtCtor.Invoke(new object[] { instrumentedResult });
        }
    }
}
