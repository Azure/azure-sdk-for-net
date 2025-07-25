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

internal class WrapResultInterceptor : IInterceptor
{
    //private static readonly MethodInfo InstrumentOperationInterceptorMethodInfo = typeof(WrapResultInterceptor)
    //    .GetMethod(nameof(InstrumentOperationInterceptor), BindingFlags.NonPublic | BindingFlags.Instance)
    //    ?? throw new InvalidOperationException("Unable to find InstrumentOperationInterceptor method");

    private readonly ClientTestBase _testBase;
    private readonly RecordedTestMode _testMode;

    public WrapResultInterceptor(ClientTestBase testBase)
    {
        _testBase = testBase;
        // non-recorded tests are treated like Playback mode
        _testMode = testBase is RecordedTestBase recordedTestBase ? recordedTestBase.Mode : RecordedTestMode.Playback;
    }

    public void Intercept(IInvocation invocation)
    {
        var type = invocation.Method.ReturnType;

        // We don't want to instrument generated rest clients.
        if (type.Name.EndsWith("Client") && !type.Name.EndsWith("RestClient") && !type.Name.EndsWith("ExtensionClient"))
        {
            if (IsNullResult(invocation))
                return;

            invocation.ReturnValue = _testBase.InstrumentClient(type, invocation.ReturnValue! /* TODO */, Array.Empty<IInterceptor>());
            return;
        }

        if (type is { IsGenericType: true, GenericTypeArguments: { } arguments } &&
            type.GetGenericTypeDefinition() == typeof(Task<>) &&
            typeof(OperationResult).IsAssignableFrom(arguments[0]))
        {
            // Handle Task<OperationResult> - instrument the LRO when the task completes
            invocation.Proceed();
            if (invocation.ReturnValue is Task task)
            {
                invocation.ReturnValue = InstrumentLongRunningOperationAsync(task, arguments[0]);
            }
            return;
        }

        if (typeof(OperationResult).IsAssignableFrom(type))
        {
            // Handle direct OperationResult returns
            invocation.Proceed();
            if (invocation.ReturnValue != null)
            {
                invocation.ReturnValue = InstrumentOperationResult(invocation.ReturnValue, type);
            }
            return;
        }

        invocation.Proceed();
    }

    //internal async ValueTask<T> InstrumentOperationInterceptor<T>(IInvocation invocation, Func<ValueTask<T>> innerTask)
    //{
    //    return (T)_testBase.InstrumentOperation(typeof(T), await innerTask());
    //}

    private bool IsNullResult(IInvocation invocation)
    {
        invocation.Proceed();
        return invocation.ReturnValue == null;
    }

    private async Task<OperationResult> InstrumentLongRunningOperationAsync(Task task, Type operationResultType)
    {
        await task.ConfigureAwait(false);
        
        // Get the result from the completed task
        var resultProperty = task.GetType().GetProperty("Result");
        if (resultProperty?.GetValue(task) is OperationResult operationResult)
        {
            return InstrumentOperationResult(operationResult, operationResultType);
        }

        throw new InvalidOperationException($"Expected Task<{operationResultType.Name}> but could not extract result.");
    }

    private OperationResult InstrumentOperationResult(object operationResult, Type operationResultType)
    {
        // If it's already test-aware, don't wrap it again
        if (operationResult is TestAwareOperationResult)
        {
            return (OperationResult)operationResult;
        }

        // Create a proxy that will intercept WaitForCompletion calls and apply mode-aware polling
        var proxy = ClientTestBase.ProxyGenerator.CreateClassProxyWithTarget(
            operationResultType,
            operationResult,
            new OperationResultInterceptor(_testMode));

        return (OperationResult)proxy;
    }
}
