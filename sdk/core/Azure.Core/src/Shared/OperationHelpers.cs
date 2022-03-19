// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace Azure.Core
{
    internal static class OperationHelpers
    {
        public static T GetValue<T>(ref T? value) where T : class
        {
            if (value is null)
            {
                throw new InvalidOperationException("The operation has not completed yet.");
            }

            return value;
        }

        public static T GetValue<T>(ref T? value) where T : struct
        {
            if (value == null)
            {
                throw new InvalidOperationException("The operation has not completed yet.");
            }

            return value.Value;
        }

        public static async ValueTask<Response<TResult>> DefaultWaitForCompletionAsync<TResult>(this Operation<TResult> operation, CancellationToken cancellationToken)
            where TResult : notnull
        {
            OperationPoller poller = new OperationPoller();
            return await poller.WaitForCompletionAsync(operation, null, cancellationToken).ConfigureAwait(false);
        }

        public static async ValueTask<Response<TResult>> DefaultWaitForCompletionAsync<TResult>(this Operation<TResult> operation, TimeSpan pollingInterval, CancellationToken cancellationToken)
            where TResult : notnull
        {
            OperationPoller poller = new OperationPoller();
            return await poller.WaitForCompletionAsync(operation, pollingInterval, cancellationToken).ConfigureAwait(false);
        }

        public static Response<TResult> DefaultWaitForCompletion<TResult>(this Operation<TResult> operation, CancellationToken cancellationToken)
            where TResult : notnull
        {
            OperationPoller poller = new OperationPoller();
            return poller.WaitForCompletion(operation, null, cancellationToken);
        }

        public static Response<TResult> DefaultWaitForCompletion<TResult>(this Operation<TResult> operation, TimeSpan pollingInterval, CancellationToken cancellationToken)
            where TResult : notnull
        {
            OperationPoller poller = new OperationPoller();
            return poller.WaitForCompletion(operation, pollingInterval, cancellationToken);
        }

        public static async ValueTask<Response> DefaultWaitForCompletionResponseAsync(this Operation operation, CancellationToken cancellationToken)
        {
            OperationPoller poller = new OperationPoller();
            return await poller.WaitForCompletionResponseAsync(operation, null, cancellationToken).ConfigureAwait(false);
        }

        public static async ValueTask<Response> DefaultWaitForCompletionResponseAsync(this Operation operation, TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            OperationPoller poller = new OperationPoller();
            return await poller.WaitForCompletionResponseAsync(operation, pollingInterval, cancellationToken).ConfigureAwait(false);
        }

        public static Response DefaultWaitForCompletionResponse(this Operation operation, CancellationToken cancellationToken)
        {
            OperationPoller poller = new OperationPoller();
            return poller.WaitForCompletionResponse(operation, null, cancellationToken);
        }

        public static Response DefaultWaitForCompletionResponse(this Operation operation, TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            OperationPoller poller = new OperationPoller();
            return poller.WaitForCompletionResponse(operation, pollingInterval, cancellationToken);
        }
    }
}
