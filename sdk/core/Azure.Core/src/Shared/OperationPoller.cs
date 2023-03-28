// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Shared;

namespace Azure.Core
{
    /// <summary>
    /// Implementation of LRO polling logic.
    /// </summary>
    internal sealed class OperationPoller
    {
        private readonly Delay _delayStrategy;

        public OperationPoller(Delay? strategy = null)
        {
            _delayStrategy = strategy ?? new FixedDelayWithNoJitter();
        }

        public ValueTask<Response> WaitForCompletionResponseAsync(Operation operation, TimeSpan? delayHint, CancellationToken cancellationToken)
            => WaitForCompletionAsync(true, operation, delayHint, cancellationToken);

        public Response WaitForCompletionResponse(Operation operation, TimeSpan? delayHint, CancellationToken cancellationToken)
            => WaitForCompletionAsync(false, operation, delayHint, cancellationToken).EnsureCompleted();

        public ValueTask<Response> WaitForCompletionResponseAsync(OperationInternalBase operation, TimeSpan? delayHint, CancellationToken cancellationToken)
            => WaitForCompletionAsync(true, operation, delayHint, cancellationToken);

        public Response WaitForCompletionResponse(OperationInternalBase operation, TimeSpan? delayHint, CancellationToken cancellationToken)
            => WaitForCompletionAsync(false, operation, delayHint, cancellationToken).EnsureCompleted();

        public async ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation, TimeSpan? delayHint, CancellationToken cancellationToken) where T : notnull
        {
            Response response = await WaitForCompletionAsync(true, operation, delayHint, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, response);
        }

        public Response<T> WaitForCompletion<T>(Operation<T> operation, TimeSpan? delayHint, CancellationToken cancellationToken) where T : notnull
        {
            Response response = WaitForCompletionAsync(false, operation, delayHint, cancellationToken).EnsureCompleted();
            return Response.FromValue(operation.Value, response);
        }

        public async ValueTask<Response<T>> WaitForCompletionAsync<T>(OperationInternal<T> operation, TimeSpan? delayHint, CancellationToken cancellationToken) where T : notnull
        {
            Response response = await WaitForCompletionAsync(true, operation, delayHint, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, response);
        }

        public Response<T> WaitForCompletion<T>(OperationInternal<T> operation, TimeSpan? delayHint, CancellationToken cancellationToken) where T : notnull
        {
            Response response = WaitForCompletionAsync(false, operation, delayHint, cancellationToken).EnsureCompleted();
            return Response.FromValue(operation.Value, response);
        }

        private async ValueTask<Response> WaitForCompletionAsync(bool async, Operation operation, TimeSpan? delayHint, CancellationToken cancellationToken)
        {
            int retryNumber = 0;
            var context = new Dictionary<string, object?>();
            while (true)
            {
                Response response = async ? await operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false) : operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return operation.GetRawResponse();
                }

                var strategy = delayHint.HasValue ? new FixedDelayWithNoJitter(delayHint.Value) : _delayStrategy;

                await Delay(async, strategy.GetNextDelay(response, ++retryNumber, response.Headers.RetryAfter, context), cancellationToken).ConfigureAwait(false);
            }
        }

        private async ValueTask<Response> WaitForCompletionAsync(bool async, OperationInternalBase operation, TimeSpan? delayHint, CancellationToken cancellationToken)
        {
            int retryNumber = 0;
            var context = new Dictionary<string, object?>();
            while (true)
            {
                Response response = async ? await operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false) : operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return operation.RawResponse;
                }

                var strategy = delayHint.HasValue ? new FixedDelayWithNoJitter(delayHint.Value) : _delayStrategy;

                await Delay(async, strategy.GetNextDelay(response, ++retryNumber, response.Headers.RetryAfter, context), cancellationToken).ConfigureAwait(false);
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
