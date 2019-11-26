// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
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

        private readonly MethodInfo _taskFromResultMethod = typeof(Task)
            .GetMethod("FromResult", BindingFlags.Static | BindingFlags.Public);

        private readonly MethodInfo _taskFromExceptionMethod = typeof(Task)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Single(m => m.Name == "FromException" && m.IsGenericMethod);

        [DebuggerStepThrough]
        public void Intercept(IInvocation invocation)
        {
            Type[] parameterTypes = invocation.Method.GetParameters().Select(p => p.ParameterType).ToArray();

            var methodName = invocation.Method.Name;
            if (!methodName.EndsWith(AsyncSuffix))
            {
                MethodInfo asyncAlternative = GetMethod(invocation, methodName + AsyncSuffix, parameterTypes);

                // Check if there is an async alternative to sync call
                if (asyncAlternative != null)
                {
                    throw new InvalidOperationException($"Async method call expected for {methodName}");
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

            MethodInfo methodInfo = GetMethod(invocation, nonAsyncMethodName, parameterTypes);
            if (methodInfo == null)
            {
                throw new InvalidOperationException($"Unable to find a method with name {nonAsyncMethodName} and {string.Join<Type>(",", parameterTypes)} parameters. "
                                                    + "Make sure both methods have the same signature including the cancellationToken parameter");
            }

            Type returnType = methodInfo.ReturnType;
            bool returnsSyncCollection = returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Pageable<>);

            try
            {
                object result = methodInfo.Invoke(invocation.InvocationTarget, invocation.Arguments);

                // Map IEnumerable to IAsyncEnumerable
                if (returnsSyncCollection)
                {
                    Type[] modelType = returnType.GenericTypeArguments;
                    Type wrapperType = typeof(SyncPageableWrapper<>).MakeGenericType(modelType);

                    invocation.ReturnValue = Activator.CreateInstance(wrapperType, new[] { result });
                }
                else
                {
                    SetAsyncResult(invocation, returnType, result);
                }
            }
            catch (TargetInvocationException exception)
            {
                if (returnsSyncCollection)
                {
                    ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
                }
                else
                {
                    SetAsyncException(invocation, returnType, exception.InnerException);
                }
            }
        }

        private void SetAsyncResult(IInvocation invocation, Type returnType, object result)
        {
            Type methodReturnType = invocation.Method.ReturnType;
            if (methodReturnType.IsGenericType)
            {
                if (methodReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                {
                    invocation.ReturnValue = _taskFromResultMethod.MakeGenericMethod(returnType).Invoke(null, new[] { result });
                    return;
                }
                if (methodReturnType.GetGenericTypeDefinition() == typeof(ValueTask<>))
                {
                    invocation.ReturnValue = Activator.CreateInstance(typeof(ValueTask<>).MakeGenericType(returnType), result);
                    return;
                }
            }

            throw new NotSupportedException();
        }

        private void SetAsyncException(IInvocation invocation, Type returnType, Exception result)
        {
            Type methodReturnType = invocation.Method.ReturnType;
            if (methodReturnType.IsGenericType)
            {
                if (methodReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                {
                    invocation.ReturnValue = _taskFromExceptionMethod.MakeGenericMethod(returnType).Invoke(null, new[] { result });
                    return;
                }

                if (methodReturnType.GetGenericTypeDefinition() == typeof(ValueTask<>))
                {
                    var task = _taskFromExceptionMethod.MakeGenericMethod(returnType).Invoke(null, new[] { result });
                    invocation.ReturnValue = Activator.CreateInstance(typeof(ValueTask<>).MakeGenericType(returnType), task);
                    return;
                }
            }

            throw new NotSupportedException();
        }

        private static MethodInfo GetMethod(IInvocation invocation, string nonAsyncMethodName, Type[] types) =>
            IsInternal(invocation.Method)
                ? invocation.TargetType.GetMethod(nonAsyncMethodName, BindingFlags.NonPublic | BindingFlags.Instance, null, types, null)
                : invocation.TargetType.GetMethod(nonAsyncMethodName, BindingFlags.Public | BindingFlags.Instance, null, types, null);

        private static bool IsInternal(MethodBase method) => method.IsAssembly || method.IsFamilyAndAssembly && !method.IsFamilyOrAssembly;

        private class SyncPageableWrapper<T> : AsyncPageable<T>
        {
            private readonly Pageable<T> _enumerable;

            public SyncPageableWrapper(Pageable<T> enumerable)
            {
                _enumerable = enumerable;
            }

#pragma warning disable 1998
            public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = default, int? pageSizeHint = default)
#pragma warning restore 1998
            {
                foreach (Page<T> page in _enumerable.AsPages())
                {
                    yield return page;
                }
            }
        }
    }
}
