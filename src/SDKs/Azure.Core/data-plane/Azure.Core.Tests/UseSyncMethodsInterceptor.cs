// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.Tests
{
    /// <summary>
    /// This interceptor forwards the async call to a sync method call with the same arguments
    /// </summary>
    public class UseSyncMethodsInterceptor : IInterceptor
    {
        private const string AsyncSuffix = "Async";

        private readonly MethodInfo TaskFromResultMethod = typeof(Task)
            .GetMethod("FromResult", BindingFlags.Static | BindingFlags.Public);

        private readonly MethodInfo TaskFromExceptionMethod = typeof(Task)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Single(m => m.Name == "FromException" && m.IsGenericMethod);

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;
            if (!methodName.EndsWith(AsyncSuffix))
            {
                throw new InvalidOperationException("Async method call expected");
            }

            var nonAsyncMethodName = methodName.Substring(0, methodName.Length - AsyncSuffix.Length);

            var types = invocation.Method.GetParameters().Select(p => p.ParameterType).ToArray();

            var methodInfo = invocation.TargetType.GetMethod(nonAsyncMethodName, BindingFlags.Public | BindingFlags.Instance, null, types, null);
            if (methodInfo == null)
            {
                throw new InvalidOperationException($"Unable to find a method with name {nonAsyncMethodName} and {string.Join<Type>(",", types)} parameters");
            }

            try
            {
                object result = methodInfo.Invoke(invocation.InvocationTarget, invocation.Arguments);

                invocation.ReturnValue = TaskFromResultMethod.MakeGenericMethod(methodInfo.ReturnType).Invoke(null, new [] { result });
            }
            catch (TargetInvocationException exception)
            {
                invocation.ReturnValue = TaskFromExceptionMethod.MakeGenericMethod(methodInfo.ReturnType).Invoke(null, new [] { exception.InnerException });
            }
        }
    }
}
