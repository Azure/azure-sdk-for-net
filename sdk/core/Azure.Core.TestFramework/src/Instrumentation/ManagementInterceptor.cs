// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
            if (type.Name.StartsWith("ValueTask") ||
                type.Name.StartsWith("Task") ||
                type.Name.StartsWith("AsyncStateMachineBox")) //in .net 5 the type is not task here
            {
                if ((bool)type.GetProperty("IsFaulted").GetValue(result))
                    return;

                var taskResultType = type.GetGenericArguments()[0];
                if (taskResultType.Name.StartsWith("Response"))
                {
                    try
                    {
                        var taskResult = result.GetType().GetProperty("Result").GetValue(result);
                        var instrumentedResult = _testBase.InstrumentClient(taskResultType, taskResult, new IInterceptor[] { new ManagementInterceptor(_testBase) });
                        invocation.ReturnValue = type.Name.StartsWith("ValueTask")
                            ? GetValueFromValueTask(taskResultType, instrumentedResult)
                            : GetValueFromOther(taskResultType, instrumentedResult);
                    }
                    catch (TargetInvocationException e)
                    {
                        if (e.InnerException is AggregateException aggException)
                        {
                            throw aggException.InnerExceptions.First();
                        }
                        else
                        {
                            throw e.InnerException;
                        }
                    }
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

        internal static bool InheritsFromArmResource(Type elementType)
        {
            if (elementType.BaseType == null)
                return false;

            if (elementType.BaseType == typeof(object))
                return false;

            if (elementType.BaseType.Name == "ArmResource")
                return true;

            return InheritsFromArmResource(elementType.BaseType);
        }

        private object GetValueFromOther(Type taskResultType, object instrumentedResult)
        {
            var method = typeof(Task).GetMethod("FromResult", BindingFlags.Public | BindingFlags.Static);
            var genericMethod = method.MakeGenericMethod(taskResultType);
            return genericMethod.Invoke(null, new object[] { instrumentedResult });
        }

        private object GetValueFromValueTask(Type taskResultType, object instrumentedResult)
        {
            var genericValueTask = typeof(ValueTask<>).MakeGenericType(taskResultType);
            var vtCtor = genericValueTask.GetConstructor(new Type[] { taskResultType });
            return vtCtor.Invoke(new object[] { instrumentedResult });
        }
    }
}
