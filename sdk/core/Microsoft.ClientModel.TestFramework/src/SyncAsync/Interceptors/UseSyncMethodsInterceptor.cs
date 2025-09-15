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
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

internal class UseSyncMethodsInterceptor : IInterceptor
{
    private readonly bool _forceSync;

    public UseSyncMethodsInterceptor(bool forceSync)
    {
        _forceSync = forceSync;
    }

    private const string AsyncSuffix = "Async";

    private readonly MethodInfo? _taskFromResultMethod = typeof(Task).GetMethod("FromResult", BindingFlags.Static | BindingFlags.Public);

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
            MethodInfo? asyncAlternative = GetMethod(invocation, methodName + AsyncSuffix, parameterTypes);

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

        MethodInfo? methodInfo = GetMethod(invocation, nonAsyncMethodName, parameterTypes);
        if (methodInfo == null)
        {
            throw new InvalidOperationException($"Unable to find a method with name {nonAsyncMethodName} and {string.Join<Type>(",", parameterTypes)} parameters. "
                                                + "Make sure both methods have the same signature including the cancellationToken parameter");
        }

        Type returnType = methodInfo.ReturnType;
        bool returnsSyncCollection = (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(CollectionResult<>)) ||
                                   returnType == typeof(CollectionResult);

        try
        {
            // If we've got GetAsync<Model>() and just found Get<T>(), we
            // need to change the method to Get<Model>().
            if (methodInfo.ContainsGenericParameters)
            {
                methodInfo = methodInfo.MakeGenericMethod(invocation.Method.GetGenericArguments());
                returnType = methodInfo.ReturnType;
            }

            // Get the original target to avoid infinite recursion
            object? target = invocation.InvocationTarget;
            if (target is IProxiedClient wrapped)
            {
                target = wrapped.Original;
            }

            object? result = methodInfo.Invoke(target, invocation.Arguments);

            // Map IEnumerable to IAsyncEnumerable
            if (returnsSyncCollection)
            {
                if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(CollectionResult<>))
                {
                    // Handle generic CollectionResult<T>
                    Type[] modelType = returnType.GenericTypeArguments;
                    Type wrapperType = typeof(SyncPageableWrapper<>).MakeGenericType(modelType);
                    invocation.ReturnValue = Activator.CreateInstance(wrapperType, new[] { result });
                }
                else if (returnType == typeof(CollectionResult))
                {
                    var collectionResult = result as CollectionResult;

                    if (collectionResult == null)
                    {
                        throw new InvalidOperationException("Expected CollectionResult from sync protocol method");
                    }

                    // Handle non-generic CollectionResult
                    invocation.ReturnValue = new SyncPageableWrapper(collectionResult);
                }
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
                ExceptionDispatchInfo.Capture(exception.InnerException ?? exception).Throw();
            }
            else
            {
                SetAsyncException(invocation, returnType, exception.InnerException ?? exception);
            }
        }
    }

    private void SetAsyncResult(IInvocation invocation, Type returnType, object? result)
    {
        Type methodReturnType = invocation.Method.ReturnType;
        if (methodReturnType.IsGenericType)
        {
            returnType = CloseResponseType(returnType, methodReturnType);
            if (methodReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                invocation.ReturnValue = _taskFromResultMethod?.MakeGenericMethod(returnType).Invoke(null, new[] { result });
                return;
            }
            if (methodReturnType.GetGenericTypeDefinition() == typeof(ValueTask<>))
            {
                invocation.ReturnValue = Activator.CreateInstance(typeof(ValueTask<>).MakeGenericType(returnType), result);
                return;
            }
        }

        // Handle non-generic AsyncCollectionResult case
        if (methodReturnType == typeof(Task<AsyncCollectionResult>) && result is AsyncCollectionResult)
        {
            invocation.ReturnValue = _taskFromResultMethod?.MakeGenericMethod(typeof(AsyncCollectionResult)).Invoke(null, new[] { result });
            return;
        }

        if (methodReturnType == typeof(ValueTask<AsyncCollectionResult>) && result is AsyncCollectionResult)
        {
            invocation.ReturnValue = new ValueTask<AsyncCollectionResult>((AsyncCollectionResult)result);
            return;
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

        // Handle non-generic AsyncCollectionResult case
        if (methodReturnType == typeof(Task<AsyncCollectionResult>))
        {
            invocation.ReturnValue = _taskFromExceptionMethod.MakeGenericMethod(typeof(AsyncCollectionResult)).Invoke(null, new[] { result });
            return;
        }

        if (methodReturnType == typeof(ValueTask<AsyncCollectionResult>))
        {
            var task = _taskFromExceptionMethod.MakeGenericMethod(typeof(AsyncCollectionResult)).Invoke(null, new[] { result });
            var asyncCollectionResult = task as Task<AsyncCollectionResult>;
            if (asyncCollectionResult == null)
            {
                throw new InvalidOperationException("Expected Task<AsyncCollectionResult> from exception task creation");
            }
            invocation.ReturnValue = new ValueTask<AsyncCollectionResult>(asyncCollectionResult);
            return;
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
            returnType.GetGenericTypeDefinition() == typeof(ClientResult<>) &&
            returnType.ContainsGenericParameters)
        {
            Type modelType = methodReturnType.GetGenericArguments()[0].GetGenericArguments()[0];
            returnType = returnType.GetGenericTypeDefinition().MakeGenericType(modelType);
        }
        return returnType;
    }

    private static MethodInfo? GetMethod(IInvocation invocation, string nonAsyncMethodName, Type[] types)
    {
        BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

        // Do our own slow "lightweight binding" in situations where we
        // have generic arguments that aren't factored into the binder for
        // the regular GetMethod call.  We're taking lots of shortcuts like
        // only comparing the generic type or count and it's only enough
        // for the cases we have today.
        static Type GenericDef(Type t) => t.IsGenericType ? t.GetGenericTypeDefinition() : t;
        MethodInfo? GetMethodSlow()
        {
            var methods = invocation?.TargetType?
            // Start with all methods that have the right name
            .GetMethods(flags).Where(m => m.Name == nonAsyncMethodName);

            // Check if their type parameters have the same generic
            // type definitions (i.e., if I invoked
            // GetAsync<Model>(Wrapper<Model>) we want that to match
            // with Get<T>(Wrapper<T>)
            var genericDefs = methods?.Where(m =>
                m.GetParameters().Select(p => GenericDef(p.ParameterType))
                .SequenceEqual(types.Select(GenericDef)));

            // If the previous check has any results, check if they have the same number of type arguments
            // (all of our cases today either specialize on 0 or 1 type
            // argument for the static or dynamic user schema approach)
            // Else, close each GenericMethodDefinition and compare its parameter types.
            var withSimilarGenericArguments = genericDefs?.Any() == true ?
                genericDefs?.Where(m =>
                    m.GetGenericArguments().Length ==
                    invocation?.Method.GetGenericArguments().Length) :
                methods?
                    .Where(m => m.IsGenericMethodDefinition)
                    .Select(m => m.MakeGenericMethod(invocation?.GenericArguments!))
                    .Where(gm => gm.GetParameters().Select(p => p.ParameterType)
                        .SequenceEqual(invocation?.Method.GetParameters().Select(p => p.ParameterType)!));

            // Hopefully we're down to 1.  If you arrive here in the
            // future because SingleOrDefault threw, we need to make
            // the comparison logic more specific.  If you arrive here
            // because we're returning null, then we need to search
            // a little more broadly.  Either way, congratulations on
            // blazing new API patterns and taking us boldly into the
            // future.
            return withSimilarGenericArguments?.SingleOrDefault();
        }

        try
        {
            return invocation.TargetType?.GetMethod(
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

    /// <summary>
    /// Wraps a synchronous <see cref="CollectionResult{T}"/> to provide an asynchronous
    /// <see cref="AsyncCollectionResult{T}"/> interface for testing scenarios where
    /// sync methods need to be called from async method signatures.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public class SyncPageableWrapper<T> : AsyncCollectionResult<T>
    {
        private readonly CollectionResult<T> _enumerable;

        /// <summary>
        /// Initializes a new instance of <see cref="SyncPageableWrapper{T}"/> for mocking scenarios.
        /// </summary>
        protected SyncPageableWrapper()
        {
            _enumerable = default!;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SyncPageableWrapper{T}"/> that wraps
        /// the specified synchronous collection result.
        /// </summary>
        /// <param name="enumerable">The synchronous collection result to wrap.</param>
        public SyncPageableWrapper(CollectionResult<T> enumerable)
        {
            _enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
        }

        /// <inheritdoc/>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected override async IAsyncEnumerable<T> GetValuesFromPageAsync(ClientResult page)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var items = NonPublic.FromMethod<CollectionResult<T>, ClientResult, IEnumerable<T>>("GetValuesFromPage")(_enumerable, page);
            foreach (T item in items)
            {
                yield return item;
            }
        }

        /// <inheritdoc/>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            foreach (ClientResult page in _enumerable.GetRawPages())
            {
                yield return page;
            }
        }

        /// <inheritdoc/>
        public override ContinuationToken? GetContinuationToken(ClientResult page)
        {
            // Delegate directly to the wrapped sync collection
            return _enumerable.GetContinuationToken(page);
        }
    }

    /// <summary>
    /// Wraps a synchronous CollectionResult to provide an asynchronous
    /// AsyncCollectionResult interface for testing scenarios where
    /// sync methods need to be called from async method signatures.
    /// </summary>
    public class SyncPageableWrapper : AsyncCollectionResult
    {
        private readonly CollectionResult _enumerable;

        /// <summary>
        /// Initializes a new instance of <see cref="SyncPageableWrapper"/> for mocking scenarios.
        /// </summary>
        protected SyncPageableWrapper()
        {
            _enumerable = default!;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SyncPageableWrapper"/> that wraps
        /// the specified synchronous collection result.
        /// </summary>
        /// <param name="enumerable">The synchronous collection result to wrap.</param>
        public SyncPageableWrapper(CollectionResult enumerable)
        {
            _enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
        }

        /// <inheritdoc/>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            foreach (ClientResult page in _enumerable.GetRawPages())
            {
                yield return page;
            }
        }

        /// <inheritdoc/>
        public override ContinuationToken? GetContinuationToken(ClientResult page)
        {
            // Delegate directly to the wrapped sync collection
            return _enumerable.GetContinuationToken(page);
        }
    }
}
