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
        /// <summary>
        /// Gets or sets the maximum number of retry attempts before giving up.
        /// </summary>
        public int MaxRetries { get; set; } = 10;

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

                var shouldRetry = attempt <= MaxRetries;

                if (lastException != null)
                {
                    if (shouldRetry && message.ResponseClassifier.IsRetriableException(lastException))
                    {
                        GetDelay(message, lastException, attempt, out delay);
                    }
                    else
                    {
                        // Rethrow a singular exception
                        if (exceptions.Count == 1)
                        {
                            ExceptionDispatchInfo.Capture(lastException).Throw();
                        }

                        throw new AggregateException($"Retry failed after {attempt} tries.", exceptions);
                    }
                }
                else if (message.ResponseClassifier.IsErrorResponse(message.Response))
                {
                    if (shouldRetry && message.ResponseClassifier.IsRetriableResponse(message.Response))
                    {
                        GetDelay(message, attempt, out delay);
                    }
                    else
                    {
                        return;
                    }
                }
                else
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

        protected abstract void GetDelay(HttpPipelineMessage message, int attempted, out TimeSpan delay);

        protected abstract void GetDelay(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay);
    }
}
