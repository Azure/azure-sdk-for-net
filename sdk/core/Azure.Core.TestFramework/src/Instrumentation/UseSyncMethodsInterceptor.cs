// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
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

            if (IsSystemClientModelCollectionResult(returnType))
            {
                // TODO - this is not handled in the Azure Test Framework, but only in the ClientModel test framework.
                invocation.Proceed();
                return;
            }

            bool returnsSyncCollection = returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Pageable<>);

            try
            {
                // If we've got GetAsync<Model>() and just found Get<T>(), we
                // need to change the method to Get<Model>().
                if (methodInfo.ContainsGenericParameters)
                {
                    methodInfo = methodInfo.MakeGenericMethod(invocation.Method.GetGenericArguments());
                    returnType = methodInfo.ReturnType;
                }
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

        private static bool IsSystemClientModelCollectionResult(Type type)
        {
            if (type.IsGenericType)
            {
                var genericDef = type.GetGenericTypeDefinition();
                return genericDef == typeof(CollectionResult<>) || genericDef == typeof(AsyncCollectionResult<>);
            }

            return type == typeof(CollectionResult) || type == typeof(AsyncCollectionResult);
        }

        private void SetAsyncResult(IInvocation invocation, Type returnType, object result)
        {
            Type methodReturnType = invocation.Method.ReturnType;
            if (methodReturnType.IsGenericType)
            {
                returnType = CloseResponseType(returnType, methodReturnType);
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
                returnType = CloseResponseType(returnType, methodReturnType);
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

        /// <summary>
        /// If the sync method returned Response{Model} and the async method's
        /// return type is still an open Response{U}, we need to close it to
        /// Response{Model} as well.  We don't care about this if Response{}
        /// has already been closed.
        /// </summary>
        /// <param name="returnType">The sync method's return type.</param>
        /// <param name="methodReturnType">The async method's return type.</param>
        /// <returns>A return type with Response{U} closed.</returns>
        private static Type CloseResponseType(Type returnType, Type methodReturnType)
        {
            if (returnType.IsGenericType &&
                returnType.GetGenericTypeDefinition() == typeof(Response<>) &&
                returnType.ContainsGenericParameters)
            {
                Type modelType = methodReturnType.GetGenericArguments()[0].GetGenericArguments()[0];
                returnType = returnType.GetGenericTypeDefinition().MakeGenericType(modelType);
            }
            return returnType;
        }

        private static MethodInfo GetMethod(IInvocation invocation, string nonAsyncMethodName, Type[] types)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

            // Do our own slow "lightweight binding" in situations where we
            // have generic arguments that aren't factored into the binder for
            // the regular GetMethod call.  We're taking lots of shortcuts like
            // only comparing the generic type or count and it's only enough
            // for the cases we have today.
            static Type GenericDef(Type t) => t.IsGenericType ? t.GetGenericTypeDefinition() : t;
            MethodInfo GetMethodSlow()
            {
                var methods = invocation.TargetType
                // Start with all methods that have the right name
                .GetMethods(flags).Where(m => m.Name == nonAsyncMethodName);

                // Check if their type parameters have the same generic
                // type definitions (i.e., if I invoked
                // GetAsync<Model>(Wrapper<Model>) we want that to match
                // with Get<T>(Wrapper<T>)
                var genericDefs = methods.Where(m =>
                    m.GetParameters().Select(p => GenericDef(p.ParameterType))
                    .SequenceEqual(types.Select(GenericDef)));

                // If the previous check has any results, check if they have the same number of type arguments
                // (all of our cases today either specialize on 0 or 1 type
                // argument for the static or dynamic user schema approach)
                // Else, close each GenericMethodDefinition and compare its parameter types.
                var withSimilarGenericArguments = genericDefs.Any() ?
                    genericDefs.Where(m =>
                        m.GetGenericArguments().Length ==
                        invocation.Method.GetGenericArguments().Length) :
                    methods
                        .Where(m => m.IsGenericMethodDefinition)
                        .Select(m => m.MakeGenericMethod(invocation.GenericArguments))
                        .Where(gm => gm.GetParameters().Select(p => p.ParameterType)
                            .SequenceEqual(invocation.Method.GetParameters().Select(p => p.ParameterType)));

                // Hopefully we're down to 1.  If you arrive here in the
                // future because SingleOrDefault threw, we need to make
                // the comparison logic more specific.  If you arrive here
                // because we're returning null, then we need to search
                // a little more broadly.  Either way, congratulations on
                // blazing new API patterns and taking us boldly into the
                // future.
                return withSimilarGenericArguments.SingleOrDefault();
            }

            try
            {
                return invocation.TargetType.GetMethod(
                    nonAsyncMethodName,
                    flags,
                    null,
                    types,
                    null) ??
                    // Search a little more broadly if the regular binder
                    // couldn't find a match
                    GetMethodSlow();
            }
            catch (AmbiguousMatchException)
            {
                // Use our own binder to pick the best method if the regular
                // binder couldn't decide between multiple choices
                return GetMethodSlow();
            }
        }

        public class SyncPageableWrapper<T> : AsyncPageable<T>
        {
            private readonly Pageable<T> _enumerable;

            protected SyncPageableWrapper()
            {
            }

            public SyncPageableWrapper(Pageable<T> enumerable)
            {
                _enumerable = enumerable;
            }

#pragma warning disable 1998
            public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = default, int? pageSizeHint = default)
#pragma warning restore 1998
            {
                foreach (Page<T> page in _enumerable.AsPages(continuationToken, pageSizeHint))
                {
                    yield return page;
                }
            }
        }
    }
}
