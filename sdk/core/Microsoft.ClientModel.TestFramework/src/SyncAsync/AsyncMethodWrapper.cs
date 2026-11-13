// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using System;
using System.ClientModel;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A base interceptor that provides infrastructure for handling async method interception
/// with support for Task, ValueTask, and collection result wrapping.
/// </summary>
internal static class AsyncMethodWrapper
{
    private static readonly MethodInfo WrapAsyncResultCoreMethod = typeof(AsyncMethodWrapper)
        .GetMethod(nameof(WrapAsyncResultCore), BindingFlags.NonPublic | BindingFlags.Static)
        ?? throw new InvalidOperationException("Unable to find AsyncMethodWrapper.WrapAsyncResultCore method");

    internal static void WrapAsyncResult(IInvocation invocation, object target, MethodInfo interceptorMethod)
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

    internal static void WrapAsyncResultCore<T>(IInvocation invocation, Type genericType, AsyncCallInterceptor<T> wrap)
    {
        // All this ceremony is not to await the returned Task/ValueTask synchronously
        // instead we are replacing the invocation.ReturnValue with the ValidateDiagnosticScope task
        // but we need to make sure the types match
        if (genericType == typeof(Task<>))
        {
            async ValueTask<T> Await()
            {
                invocation.Proceed();
                var signatureResponseType = typeof(T);
                if (signatureResponseType.IsGenericType && signatureResponseType.GetGenericTypeDefinition().Equals(typeof(ClientResult<>)))
                {
                    //guaranteed only one generic arg with Response<T>
                    var signatureGenericType = signatureResponseType.GetGenericArguments()[0];
                    var runtimeTaskType = invocation.ReturnValue?.GetType();
                    Type? runtimeGenericType = null;
                    if (runtimeTaskType?.IsGenericType == true && runtimeTaskType.GetGenericTypeDefinition().Equals(typeof(Task<>)))
                    {
                        var runtimeResponseType = runtimeTaskType.GetGenericArguments()[0];
                        if (!runtimeResponseType.Equals(signatureResponseType) && runtimeResponseType.IsGenericType && runtimeResponseType.GetGenericTypeDefinition().Equals(typeof(ClientResult<>)))
                        {
                            runtimeGenericType = runtimeResponseType.GetGenericArguments()[0];
                        }
                    }
                    if (runtimeGenericType is not null && runtimeGenericType.IsSubclassOf(signatureGenericType))
                    {
                        //keep async nature of the call and guarantee we are complete at this point
                        if (invocation.ReturnValue is Task invocationTask)
                        {
                            await invocationTask.ConfigureAwait(false);
                            var runtimeResponseObject = TaskExtensions.GetResultFromTask(invocationTask);
                            var runtimeRawResponse = runtimeResponseObject!.GetType()?.GetMethod("GetRawResponse", BindingFlags.Instance | BindingFlags.Public)?.Invoke(runtimeResponseObject, null);
                            var runtimeValue = runtimeResponseObject!.GetType()?.GetProperty("Value", BindingFlags.Public | BindingFlags.Instance)?.GetValue(runtimeResponseObject);

                            //reconstruct
                            var signatureFromValueMethod = typeof(ClientResult).GetMethod("FromOptionalValue", BindingFlags.Static | BindingFlags.Public)?.MakeGenericMethod(signatureGenericType);
                            var convertedResponseObject = signatureFromValueMethod?.Invoke(null, new object[] { runtimeValue!, runtimeRawResponse! });
                            return (T)convertedResponseObject!;
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
            ValueTask<T> Await()
            {
                invocation.Proceed();
                return new ValueTask<T>((T)invocation.ReturnValue!);
            }

            invocation.ReturnValue = wrap(invocation, Await).EnsureCompleted();
        }
    }
}