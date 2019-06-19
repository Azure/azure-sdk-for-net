// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
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

        [DebuggerStepThrough]
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

            var returnType = methodInfo.ReturnType;
            bool returnsIEnumerable = returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(IEnumerable<>);

            try
            {
                object result = methodInfo.Invoke(invocation.InvocationTarget, invocation.Arguments);


                // Map IEnumerable to IAsyncEnumerable
                if (returnsIEnumerable)
                {
                    invocation.ReturnValue = Activator.CreateInstance(
                        typeof(AsyncEnumerableWrapper<>).MakeGenericType(returnType.GenericTypeArguments), new[] { result });
                }
                else
                {
                    invocation.ReturnValue = TaskFromResultMethod.MakeGenericMethod(returnType).Invoke(null, new [] { result });
                }
            }
            catch (TargetInvocationException exception)
            {
                if (returnsIEnumerable)
                {
                    ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
                }
                else
                {
                    invocation.ReturnValue = TaskFromExceptionMethod.MakeGenericMethod(methodInfo.ReturnType).Invoke(null, new [] { exception.InnerException });
                }
            }
        }

        private static MethodInfo GetMethod(IInvocation invocation, string nonAsyncMethodName, Type[] types)
        {
            return invocation.TargetType.GetMethod(nonAsyncMethodName, BindingFlags.Public | BindingFlags.Instance, null, types, null);
        }

        private class AsyncEnumerableWrapper<T> : IAsyncEnumerable<T>
        {
            private readonly IEnumerable<T> _enumerable;

            public AsyncEnumerableWrapper(IEnumerable<T> enumerable)
            {
                _enumerable = enumerable;
            }

            public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
            {
                return new Enumerator(_enumerable.GetEnumerator());
            }

            private class Enumerator: IAsyncEnumerator<T>
            {
                private readonly IEnumerator<T> _enumerator;

                public Enumerator(IEnumerator<T> enumerator)
                {
                    _enumerator = enumerator;
                }

                public ValueTask DisposeAsync() => default;

                public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(_enumerator.MoveNext());

                public T Current => _enumerator.Current;
            }
        }
    }
}
