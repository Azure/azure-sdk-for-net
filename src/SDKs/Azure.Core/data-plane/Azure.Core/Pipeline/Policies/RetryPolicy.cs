// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline.Policies
{
    public abstract class RetryPolicy : HttpPipelinePolicy
    {
        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            int attempt = 0;
            List<Exception> exceptions = null;
            while (true)
            {
                Exception lastException = null;

                try
                {
                    await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    if (exceptions == null)
                    {
                        exceptions = new List<Exception>();
                    }
                    exceptions.Add(ex);

                    lastException = ex;
                }

                TimeSpan delay = TimeSpan.Zero;

                attempt++;

                if (lastException != null)
                {
                    if (!IsRetriableException(message, lastException, attempt, out delay))
                    {
                        // Rethrow a singular exception
                        if (exceptions.Count == 1)
                        {
                            ExceptionDispatchInfo.Capture(lastException).Throw();
                        }

                        throw new AggregateException($"Retry failed after {attempt} tries.", exceptions);
                    }
                }
                else if (!message.ResponseClassifier.IsErrorResponse(message.Response) || !IsRetriableResponse(message, attempt, out delay))
                {
                    return;
                }

                if (delay > TimeSpan.Zero)
                {
                    await DelayAsync(delay, message.Cancellation);
                }

                HttpPipelineEventSource.Singleton.RequestRetrying(message.Request, attempt);
            }
        }

        internal virtual async Task DelayAsync(TimeSpan time, CancellationToken cancellationToken)
        {
            await Task.Delay(time, cancellationToken).ConfigureAwait(false);
        }

        protected abstract bool IsRetriableResponse(HttpPipelineMessage message, int attempted, out TimeSpan delay);

        protected abstract bool IsRetriableException(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay);
    }
}
