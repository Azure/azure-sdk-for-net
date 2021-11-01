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
        private const string RetryAfterHeaderName = "Retry-After";
        private const string RetryAfterMsHeaderName = "retry-after-ms";
        private const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";

        public static TimeSpan DefaultPollingInterval { get; } = TimeSpan.FromSeconds(1);

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

        public static ValueTask<Response<TResult>> DefaultWaitForCompletionAsync<TResult>(this Operation<TResult> operation, CancellationToken cancellationToken)
            where TResult : notnull
        {
            return operation.WaitForCompletionAsync(DefaultPollingInterval, cancellationToken);
        }

        public static async ValueTask<Response<TResult>> DefaultWaitForCompletionAsync<TResult>(
            this Operation<TResult> operation,
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
            where TResult : notnull
        {
            while (true)
            {
                await operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
                if (operation.HasCompleted)
                {
                    return Response.FromValue(operation.Value, operation.GetRawResponse());
                }

                await Task.Delay(pollingInterval, cancellationToken).ConfigureAwait(false);
            }
        }

        public static Response<TResult> DefaultWaitForCompletion<TResult>(this Operation<TResult> operation, CancellationToken cancellationToken)
            where TResult : notnull
        {
            return operation.DefaultWaitForCompletion(DefaultPollingInterval, cancellationToken);
        }

        public static Response<TResult> DefaultWaitForCompletion<TResult>(
            this Operation<TResult> operation,
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
            where TResult : notnull
        {
            while (true)
            {
                operation.UpdateStatus(cancellationToken);

                if (operation.HasCompleted)
                {
                    return Response.FromValue(operation.Value, operation.GetRawResponse());
                }

                Thread.Sleep(pollingInterval);
            }
        }

        public static ValueTask<Response> DefaultWaitForCompletionResponseAsync(this Operation operation, CancellationToken cancellationToken)
        {
            return operation.WaitForCompletionResponseAsync(DefaultPollingInterval, cancellationToken);
        }

        public static async ValueTask<Response> DefaultWaitForCompletionResponseAsync(
            this Operation operation,
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
        {
            while (true)
            {
                await operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
                if (operation.HasCompleted)
                {
                    return operation.GetRawResponse();
                }

                await Task.Delay(pollingInterval, cancellationToken).ConfigureAwait(false);
            }
        }

        public static Response DefaultWaitForCompletionResponse(this Operation operation, CancellationToken cancellationToken) =>
            operation.DefaultWaitForCompletionResponse(DefaultPollingInterval, cancellationToken);

        public static Response DefaultWaitForCompletionResponse(this Operation operation, TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                operation.UpdateStatus(cancellationToken);

                if (operation.HasCompleted)
                {
                    return operation.GetRawResponse();
                }

                Thread.Sleep(pollingInterval);
            }
        }

        public static TimeSpan GetServerDelay(Response response)
        {
            if (response.Headers.TryGetValue(RetryAfterMsHeaderName, out string? retryAfterValue) ||
                response.Headers.TryGetValue(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInMilliseconds))
                {
                    return TimeSpan.FromMilliseconds(serverDelayInMilliseconds);
                }
            }

            if (response.Headers.TryGetValue(RetryAfterHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInSeconds))
                {
                    return TimeSpan.FromSeconds(serverDelayInSeconds);
                }
            }

            return TimeSpan.Zero;
        }
    }
}
