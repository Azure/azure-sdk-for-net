// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Implementation of LRO polling logic.
    /// </summary>
    internal sealed class OperationPoller
    {
        private readonly DelayStrategyInternal _delayStrategy;

        public OperationPoller(DelayStrategyInternal? fallbackStrategy = null)
        {
            _delayStrategy = new RetryAfterDelayStrategy(fallbackStrategy);
        }

        public ValueTask<Response> WaitForCompletionResponseAsync(Operation operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken)
            => WaitForCompletionAsync(true, operation, suggestedInterval, cancellationToken);

        public Response WaitForCompletionResponse(Operation operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken)
            => WaitForCompletionAsync(false, operation, suggestedInterval, cancellationToken).EnsureCompleted();

        public ValueTask<Response> WaitForCompletionResponseAsync(OperationInternalBase operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken)
            => WaitForCompletionAsync(true, operation, suggestedInterval, cancellationToken);

        public Response WaitForCompletionResponse(OperationInternalBase operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken)
            => WaitForCompletionAsync(false, operation, suggestedInterval, cancellationToken).EnsureCompleted();

        public async ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken) where T : notnull
        {
            Response response = await WaitForCompletionAsync(true, operation, suggestedInterval, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, response);
        }

        public Response<T> WaitForCompletion<T>(Operation<T> operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken) where T : notnull
        {
            Response response = WaitForCompletionAsync(false, operation, suggestedInterval, cancellationToken).EnsureCompleted();
            return Response.FromValue(operation.Value, response);
        }

        public async ValueTask<Response<T>> WaitForCompletionAsync<T>(OperationInternal<T> operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken) where T : notnull
        {
            Response response = await WaitForCompletionAsync(true, operation, suggestedInterval, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, response);
        }

        public Response<T> WaitForCompletion<T>(OperationInternal<T> operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken) where T : notnull
        {
            Response response = WaitForCompletionAsync(false, operation, suggestedInterval, cancellationToken).EnsureCompleted();
            return Response.FromValue(operation.Value, response);
        }

        private async ValueTask<Response> WaitForCompletionAsync(bool async, Operation operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                Response response = async ? await operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false) : operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return operation.GetRawResponse();
                }

                await Delay(async, _delayStrategy.GetNextDelay(response, suggestedInterval), cancellationToken).ConfigureAwait(false);
            }
        }

        private async ValueTask<Response> WaitForCompletionAsync(bool async, OperationInternalBase operation, TimeSpan? suggestedInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                Response response = async ? await operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false) : operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return operation.RawResponse;
                }

                await Delay(async, _delayStrategy.GetNextDelay(response, suggestedInterval), cancellationToken).ConfigureAwait(false);
            }
        }

        private static async ValueTask Delay(bool async, TimeSpan delay, CancellationToken cancellationToken)
        {
            if (async)
            {
                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            }
            else if (cancellationToken.CanBeCanceled)
            {
                if (cancellationToken.WaitHandle.WaitOne(delay))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
            else
            {
                Thread.Sleep(delay);
            }
        }
    }
}
