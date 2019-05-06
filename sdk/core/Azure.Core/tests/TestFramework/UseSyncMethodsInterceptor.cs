// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.Testing
{
    /// <summary>
    /// This interceptor forwards the async call to a sync method call with the same arguments
    /// </summary>
    public class UseSyncMethodsInterceptor : IInterceptor
    {
        private readonly bool _forceSync;

        public UseSyncMethodsInterceptor(bool forceSync)
        {
            _forceSync = forceSync;
        }

        private const string AsyncSuffix = "Async";

        private readonly MethodInfo TaskFromResultMethod = typeof(Task)
            .GetMethod("FromResult", BindingFlags.Static | BindingFlags.Public);

        private readonly MethodInfo TaskFromExceptionMethod = typeof(Task)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Single(m => m.Name == "FromException" && m.IsGenericMethod);

        public void Intercept(IInvocation invocation)
        {
            var parameterTypes = invocation.Method.GetParameters().Select(p => p.ParameterType).ToArray();

            var methodName = invocation.Method.Name;
            if (!methodName.EndsWith(AsyncSuffix))
            {
                var asyncAlternative = GetMethod(invocation, methodName + AsyncSuffix, parameterTypes);

                // Check if there is an async alternative to sync call
                if (asyncAlternative != null)
                {
                    throw new InvalidOperationException("Async method call expected");
                }
                else
                {
                    invocation.Proceed();
                    return;
                }
            }

            if (!_forceSync)
            {
                invocation.Proceed();
                return;
            }

            var nonAsyncMethodName = methodName.Substring(0, methodName.Length - AsyncSuffix.Length);

            var methodInfo = GetMethod(invocation, nonAsyncMethodName, parameterTypes);
            if (methodInfo == null)
            {
                throw new InvalidOperationException($"Unable to find a method with name {nonAsyncMethodName} and {string.Join<Type>(",", parameterTypes)} parameters. "
                                                    + "Make sure both methods have the same signature including the cancellationToken parameter");
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

        private static MethodInfo GetMethod(IInvocation invocation, string nonAsyncMethodName, Type[] types)
        {
            return invocation.TargetType.GetMethod(nonAsyncMethodName, BindingFlags.Public | BindingFlags.Instance, null, types, null);
        }
    }
}
