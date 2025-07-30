// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

internal class ProxyResultInterceptor : IInterceptor
{
    private static readonly MethodInfo InstrumentOperationInterceptorMethodInfo = typeof(ProxyResultInterceptor)
            .GetMethod(nameof(InstrumentOperationInterceptor), BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new InvalidOperationException("Unable to find InstrumentOperationInterceptor method");

    private readonly ClientTestBase _testBase;
    private readonly RecordedTestMode _testMode;

    public ProxyResultInterceptor(ClientTestBase testBase)
    {
        _testBase = testBase;
        // non-recorded tests are treated like Playback mode
        _testMode = testBase is RecordedTestBase recordedTestBase ? recordedTestBase.Mode : RecordedTestMode.Playback;
    }

    public void Intercept(IInvocation invocation)
    {
        var type = invocation.Method.ReturnType;

        // We don't want to instrument generated rest clients.
        if ((type.Name.EndsWith("Client") && !type.Name.EndsWith("RestClient") && !type.Name.EndsWith("ExtensionClient")))
        {
            if (IsNullResult(invocation))
                return;

            if (invocation.ReturnValue is null)
            {
                throw new InvalidOperationException("Unexpected error: Could not find original client.");
            }

            invocation.ReturnValue = _testBase.CreateProxyFromClient(type, invocation.ReturnValue, Array.Empty<IInterceptor>());
            return;
        }

        if (type is { IsGenericType: true, GenericTypeArguments: { } arguments } &&
            type.GetGenericTypeDefinition() == typeof(Task<>) &&
            typeof(OperationResult).IsAssignableFrom(arguments[0]))
        {
            bool swappedWaitUntilArg = false;
            bool? current = invocation.Arguments[0] as bool?;

            // We swap out WaitUntil.Completed for WaitUntil.Started when in Playback because otherwise the operation
            // would not be instrumented when WaitForCompletion is called on it, which would mean that
            // the zero polling strategy wouldn't be used.
            if (current == true && _testMode == RecordedTestMode.Playback)
            {
                swappedWaitUntilArg = true;
                invocation.Arguments[0] = false;
            }

            // This will asynchronously invoke the operation and instrument it.
            AsyncMethodWrapper.WrapAsyncResult(invocation, this, InstrumentOperationInterceptorMethodInfo);

            // if we swapped out WaitUntil.Completed, we now will need to call WaitForCompletion.
            if (swappedWaitUntilArg)
            {
                if (invocation.ReturnValue is null)
                {
                    throw new InvalidOperationException("Unexpected error: Could not find original operation.");
                }
                if (TaskExtensions.IsTaskFaulted(invocation.ReturnValue) ?? false)
                    return;

                object lro = TaskExtensions.GetResultFromTask(invocation.ReturnValue) ?? throw new InvalidOperationException("Unexpected error: Could not find original operation.");

                CancellationToken token = invocation.Arguments.Last() switch
                {
                    RequestOptions options => options.CancellationToken,
                    CancellationToken cancellationToken => cancellationToken,
                    _ => CancellationToken.None
                };
                var valueTask = OperationResultInterceptor.InvokeWaitForCompletionAsync((OperationResult)lro, token);
                _ = TaskExtensions.GetResultFromTask(valueTask);
            }
            return;
        }

        invocation.Proceed();
    }

    internal async ValueTask<T> InstrumentOperationInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask)
    {
        return (T)_testBase.CreateProxyFromOperationResult(typeof(T), (await innerTask().ConfigureAwait(false))!);
    }

    private bool IsNullResult(IInvocation invocation)
    {
        invocation.Proceed();
        return invocation.ReturnValue == null;
    }
}
