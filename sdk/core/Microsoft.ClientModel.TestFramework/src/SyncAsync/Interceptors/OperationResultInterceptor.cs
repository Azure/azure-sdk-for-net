// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using System.ClientModel;

namespace Microsoft.ClientModel.TestFramework
{
    /// <summary>
    /// An interceptor that wraps OperationResult instances to provide mode-aware polling behavior.
    /// This interceptor intercepts WaitForCompletion calls and applies appropriate polling strategies
    /// based on the current test mode (Live, Record, Playback).
    /// </summary>
    internal class OperationResultInterceptor : IInterceptor
    {
        private readonly RecordedTestMode _testMode;
        private readonly IPollingStrategy _pollingStrategy;

        public OperationResultInterceptor(RecordedTestMode testMode)
        {
            _testMode = testMode;
            _pollingStrategy = testMode == RecordedTestMode.Playback 
                ? ZeroPollingStrategy.Instance 
                : DefaultPollingStrategy.Instance;
        }

        public void Intercept(IInvocation invocation)
        {
            // Check if this is a WaitForCompletion method call
            if (IsWaitForCompletionMethod(invocation.Method.Name))
            {
                InterceptWaitForCompletion(invocation);
                return;
            }

            // For all other method calls, proceed normally
            invocation.Proceed();
        }

        private bool IsWaitForCompletionMethod(string methodName)
        {
            return methodName == "WaitForCompletion" || methodName == "WaitForCompletionAsync";
        }

        private void InterceptWaitForCompletion(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;
            var parameters = invocation.Arguments;

            if (methodName == "WaitForCompletionAsync")
            {
                InterceptWaitForCompletionAsync(invocation, parameters);
            }
            else if (methodName == "WaitForCompletion")
            {
                InterceptWaitForCompletionSync(invocation, parameters);
            }
            else
            {
                invocation.Proceed();
            }
        }

        private void InterceptWaitForCompletionAsync(IInvocation invocation, object[] parameters)
        {
            // Extract cancellation token if provided
            var cancellationToken = parameters.Length > 0 && parameters[parameters.Length - 1] is CancellationToken ct 
                ? ct 
                : CancellationToken.None;

            // Create a task that uses our polling strategy
            invocation.ReturnValue = WaitForCompletionWithPollingAsync(invocation, cancellationToken);
        }

        private void InterceptWaitForCompletionSync(IInvocation invocation, object[] parameters)
        {
            // Extract cancellation token if provided
            var cancellationToken = parameters.Length > 0 && parameters[parameters.Length - 1] is CancellationToken ct 
                ? ct 
                : CancellationToken.None;

            // Use our polling strategy for synchronous waiting
            WaitForCompletionWithPolling(invocation, cancellationToken);
        }

        private async Task WaitForCompletionWithPollingAsync(IInvocation invocation, CancellationToken cancellationToken)
        {
            var operationResult = (OperationResult)invocation.InvocationTarget;

            // Keep polling until the operation is completed
            while (!operationResult.HasCompleted)
            {
                // Use our polling strategy to determine wait time
                await _pollingStrategy.WaitAsync(operationResult.GetRawResponse(), cancellationToken);

                // Update the operation status by calling UpdateStatus
                if (operationResult.GetType().GetMethod("UpdateStatus") is { } updateMethod)
                {
                    try
                    {
                        updateMethod.Invoke(operationResult, new object[] { cancellationToken });
                    }
                    catch
                    {
                        // If UpdateStatus fails, break out of the loop
                        break;
                    }
                }
                else
                {
                    // If no UpdateStatus method, we can't continue polling
                    break;
                }
            }

            invocation.ReturnValue = Task.CompletedTask;
        }

        private void WaitForCompletionWithPolling(IInvocation invocation, CancellationToken cancellationToken)
        {
            var operationResult = (OperationResult)invocation.InvocationTarget;

            // Keep polling until the operation is completed
            while (!operationResult.HasCompleted)
            {
                // Use our polling strategy to determine wait time
                _pollingStrategy.Wait(operationResult.GetRawResponse(), cancellationToken);

                // Update the operation status by calling UpdateStatus
                if (operationResult.GetType().GetMethod("UpdateStatus") is { } updateMethod)
                {
                    try
                    {
                        updateMethod.Invoke(operationResult, new object[] { cancellationToken });
                    }
                    catch
                    {
                        // If UpdateStatus fails, break out of the loop
                        break;
                    }
                }
                else
                {
                    // If no UpdateStatus method, we can't continue polling
                    break;
                }
            }

            invocation.ReturnValue = null; // void return
        }
    }
}
