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
        private const string RetryAfterHeaderName = "Retry-After";
        private const string RetryAfterMsHeaderName = "retry-after-ms";
        private const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";

        /// <summary>
        /// Gets or sets the maximum number of retry attempts before giving up.
        /// </summary>
        public int MaxRetries { get; set; } = 10;


        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).AssertCompleted();
        }

        public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            int attempt = 0;
            List<Exception> exceptions = null;
            while (true)
            {
                Exception lastException = null;

                try
                {
                    if (async)
                    {
                        await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
                    }
                    else
                    {
                        ProcessNext(pipeline, message);
                    }
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

                TimeSpan delay;

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
                    if (async)
                    {
                        await WaitAsync(delay, message.Cancellation);
                    }
                    else
                    {
                        Wait(delay, message.Cancellation);
                    }
                }

                HttpPipelineEventSource.Singleton.RequestRetrying(message.Request, attempt);
            }
        }

        internal virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
        {
            await Task.Delay(time, cancellationToken).ConfigureAwait(false);
        }

        internal virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
        {
            cancellationToken.WaitHandle.WaitOne(time);
        }

        protected virtual TimeSpan GetServerDelay(HttpPipelineMessage message)
        {
            if (message.Response.TryGetHeader(RetryAfterHeaderName, out var retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out var delaySeconds))
                {
                    return TimeSpan.FromSeconds(delaySeconds);
                }
                if (DateTimeOffset.TryParse(retryAfterValue, out var delayTime))
                {
                    return delayTime - DateTimeOffset.Now;
                }
            }

            if (message.Response.TryGetHeader(RetryAfterMsHeaderName, out retryAfterValue) ||
                message.Response.TryGetHeader(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out var delaySeconds))
                {
                    return TimeSpan.FromMilliseconds(delaySeconds);
                }
            }

            return TimeSpan.Zero;
        }

        protected abstract void GetDelay(HttpPipelineMessage message, int attempted, out TimeSpan delay);

        protected abstract void GetDelay(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay);
    }
}
