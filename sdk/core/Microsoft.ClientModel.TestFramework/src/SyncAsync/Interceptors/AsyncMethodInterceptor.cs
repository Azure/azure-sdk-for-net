// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A base interceptor that provides infrastructure for handling async method interception
/// with support for Task, ValueTask, and collection result wrapping.
/// </summary>
public class AsyncMethodInterceptor : IInterceptor
{
    private static readonly MethodInfo WrapAsyncResultCoreMethod = typeof(AsyncMethodInterceptor)
        .GetMethod(nameof(WrapAsyncResultCore), BindingFlags.NonPublic | BindingFlags.Static)
        ?? throw new InvalidOperationException("Unable to find AsyncMethodInterceptor.WrapAsyncResultCore method");

    private readonly MethodInfo _asyncCallInterceptorMethod;
    private readonly object? _target;

    /// <summary>
    /// Initializes a new instance of AsyncMethodInterceptor.
    /// </summary>
    /// <param name="asyncCallInterceptorMethod">The method to use as the async call interceptor.</param>
    /// <param name="target">The target object that contains the interceptor method. Can be null if this instance will be the target.</param>
    protected AsyncMethodInterceptor(MethodInfo asyncCallInterceptorMethod, object? target = null)
    {
        _asyncCallInterceptorMethod = asyncCallInterceptorMethod ?? throw new ArgumentNullException(nameof(asyncCallInterceptorMethod));
        _target = target ?? this; // Default to this instance if no target provided
    }

    /// <summary>
    /// Intercepts method calls and applies async handling where appropriate.
    /// </summary>
    /// <param name="invocation">The method invocation.</param>
    public virtual void Intercept(IInvocation invocation)
    {
        var type = invocation.Method.ReturnType;

        // Handle IAsyncEnumerable - pass through without interception
        if (IsAsyncEnumerable(type))
        {
            invocation.Proceed();
            return;
        }

        // Handle async methods
        if (invocation.Method.Name.EndsWith("Async") && !IsAsyncEnumerable(type))
        {
            if (_target == null)
            {
                throw new InvalidOperationException("Target cannot be null for async method interception");
            }
            WrapAsyncResult(invocation, _target, _asyncCallInterceptorMethod);
            return;
        }

        // Handle AsyncCollectionResult
        if (IsAsyncCollectionResult(type))
        {
            invocation.Proceed();
            invocation.ReturnValue = WrapAsyncCollectionResult(invocation);
            return;
        }

        // Handle synchronous CollectionResult
        if (IsCollectionResult(type))
        {
            invocation.Proceed();
            invocation.ReturnValue = WrapCollectionResult(invocation);
            return;
        }

        invocation.Proceed();
    }

    /// <summary>
    /// Determines if the given type implements IAsyncEnumerable.
    /// </summary>
    protected static bool IsAsyncEnumerable(Type type)
    {
        foreach (var iface in type.GetInterfaces())
        {
            if (iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IAsyncEnumerable<>))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Determines if the given type is or derives from AsyncCollectionResult.
    /// </summary>
    protected static bool IsAsyncCollectionResult(Type type)
    {
        return typeof(AsyncCollectionResult).IsAssignableFrom(type);
    }

    /// <summary>
    /// Determines if the given type is or derives from CollectionResult.
    /// </summary>
    protected static bool IsCollectionResult(Type type)
    {
        return typeof(CollectionResult).IsAssignableFrom(type);
    }

    /// <summary>
    /// Wraps an AsyncCollectionResult. Override in derived classes to provide custom wrapping.
    /// </summary>
    protected virtual object? WrapAsyncCollectionResult(IInvocation invocation)
    {
        // Default implementation - just return as-is
        // Derived classes can override to provide validation wrapping
        return invocation.ReturnValue;
    }

    /// <summary>
    /// Wraps a CollectionResult. Override in derived classes to provide custom wrapping.
    /// </summary>
    protected virtual object? WrapCollectionResult(IInvocation invocation)
    {
        // Default implementation - just return as-is
        // Derived classes can override to provide validation wrapping
        return invocation.ReturnValue;
    }    /// <summary>
    /// Wraps an async method result with the provided interceptor.
    /// </summary>
    protected static void WrapAsyncResult(IInvocation invocation, object target, MethodInfo interceptorMethod)
    {
        Type genericArgument = typeof(object);
        Type awaitableType = invocation.Method.ReturnType;

        if (invocation.Method.ReturnType is { IsGenericType: true, GenericTypeArguments: { Length: 1 } genericTypeArguments })
        {
            genericArgument = genericTypeArguments[0];
            awaitableType = invocation.Method.ReturnType.GetGenericTypeDefinition();
        }

        WrapAsyncResultCoreMethod.MakeGenericMethod(genericArgument)
            .Invoke(null, new object[]
            {
                invocation,
                awaitableType,
                interceptorMethod
                    .MakeGenericMethod(genericArgument)
                    .CreateDelegate(typeof(AsyncCallInterceptor<>).MakeGenericType(genericArgument), target)
            });
    }

    /// <summary>
    /// Core async result wrapping logic that handles different return types.
    /// </summary>
    internal static void WrapAsyncResultCore<T>(IInvocation invocation, Type genericType, AsyncCallInterceptor<T> wrap)
    {
        // All this ceremony is to avoid awaiting the returned Task/ValueTask synchronously
        // Instead we replace the invocation.ReturnValue with our wrapped task
        // while ensuring the types match exactly

        if (genericType == typeof(Task<>))
        {
            async ValueTask<T> Await()
            {
                invocation.Proceed();
                var signatureResultType = typeof(T);

                // Handle ClientResult<T> type coercion similar to Azure's Response<T>
                if (signatureResultType.IsGenericType && signatureResultType.GetGenericTypeDefinition().Equals(typeof(ClientResult<>)))
                {
                    var signatureGenericType = signatureResultType.GetGenericArguments()[0];
                    var runtimeTaskType = invocation.ReturnValue?.GetType();
                    Type? runtimeGenericType = null;

                    if (runtimeTaskType?.IsGenericType == true && runtimeTaskType.GetGenericTypeDefinition().Equals(typeof(Task<>)))
                    {
                        var runtimeResultType = runtimeTaskType.GetGenericArguments()[0];
                        if (!runtimeResultType.Equals(signatureResultType) &&
                            runtimeResultType.IsGenericType &&
                            runtimeResultType.GetGenericTypeDefinition().Equals(typeof(ClientResult<>)))
                        {
                            runtimeGenericType = runtimeResultType.GetGenericArguments()[0];
                        }
                    }
                    if (runtimeGenericType is not null && signatureGenericType != null && runtimeGenericType.IsSubclassOf(signatureGenericType) && invocation.ReturnValue is not null)
                    {
                        await ((Task)invocation.ReturnValue).ConfigureAwait(false);
                        var runtimeResultObject = TaskExtensions.GetResultFromTask(invocation.ReturnValue);
                        var runtimePipelineResponse = runtimeResultObject?.GetType()
                            .GetMethod("GetRawResponse", BindingFlags.Instance | BindingFlags.Public)
                            ?.Invoke(runtimeResultObject, null);
                        var runtimeValue = runtimeResultObject?.GetType()
                            .GetProperty("Value", BindingFlags.Public | BindingFlags.Instance)
                            ?.GetValue(runtimeResultObject);

                        // Reconstruct using ClientResult.FromValue
                        var signatureFromValueMethod = typeof(ClientResult)
                            .GetMethod("FromValue", BindingFlags.Static | BindingFlags.Public)
                            ?.MakeGenericMethod(signatureGenericType);

                        if (signatureFromValueMethod != null && runtimePipelineResponse != null && runtimeValue != null)
                        {
                            var convertedResultObject = signatureFromValueMethod.Invoke(null, new object[] { runtimeValue, runtimePipelineResponse });
                            if (convertedResultObject != null)
                            {
                                return (T)convertedResultObject;
                            }
                        }
                    }
                }

                return await ((Task<T>)invocation.ReturnValue!).ConfigureAwait(false);
            }

            invocation.ReturnValue = wrap(invocation, Await).AsTask();
        }
        else if (genericType == typeof(Task))
        {
            async ValueTask<T> Await()
            {
                invocation.Proceed();
                await ((Task)invocation.ReturnValue!).ConfigureAwait(false);
                return default!;
            }

            invocation.ReturnValue = wrap(invocation, Await).AsTask();
        }
        else if (genericType == typeof(ValueTask<>))
        {
            ValueTask<T> Await()
            {
                invocation.Proceed();
                return (ValueTask<T>)invocation.ReturnValue!;
            }

            invocation.ReturnValue = wrap(invocation, Await);
        }
        else if (genericType == typeof(ValueTask))
        {
            async ValueTask<T> Await()
            {
                invocation.Proceed();
                await ((ValueTask)invocation.ReturnValue!).ConfigureAwait(false);
                return default!;
            }

            invocation.ReturnValue = new ValueTask(wrap(invocation, Await).AsTask());
        }
        else
        {
            // Fallback for other types - execute synchronously
            ValueTask<T> Await()
            {
                invocation.Proceed();
                return default;
            }

            var result = wrap(invocation, Await);
            if (result.IsCompleted)
            {
                invocation.ReturnValue = result.Result;
            }
            else
            {
                invocation.ReturnValue = result;
            }
        }
    }
}
