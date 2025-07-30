// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

internal class OperationResultInterceptor : IInterceptor
{
    internal static readonly MethodInfo? WaitForCompletionAsync = typeof(OperationResult).GetMethod(nameof(OperationResult.WaitForCompletionAsync), [typeof(CancellationToken)]);

    private readonly RecordedTestMode _mode;

    public OperationResultInterceptor(RecordedTestMode mode)
    {
        _mode = mode;
    }

    public void Intercept(IInvocation invocation)
    {
        if (_mode == RecordedTestMode.Playback)
        {
            if (invocation.Method.Name == WaitForCompletionAsync?.Name)
            {
                invocation.ReturnValue = InvokeWaitForCompletionAsync(invocation.InvocationTarget as OperationResult, (CancellationToken?)invocation.Arguments.Last());
                return;
            }
        }

        invocation.Proceed();
    }

    internal static async ValueTask InvokeWaitForCompletionAsync(OperationResult? operation, CancellationToken? cancellationToken)
    {
        if (operation == null)
            return;

        var token = cancellationToken ?? CancellationToken.None;

        // In playback mode, we poll without delays to accelerate the operation
        while (!operation.HasCompleted)
        {
            RequestOptions options = new() { CancellationToken = token };
            ClientResult result = await operation.UpdateStatusAsync(options).ConfigureAwait(false);

            // SetRawResponse is protected, so we rely on UpdateStatusAsync to handle this
            // The operation should update its internal state during UpdateStatusAsync
        }
    }
}
