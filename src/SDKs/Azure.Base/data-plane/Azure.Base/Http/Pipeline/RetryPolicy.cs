// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Diagnostics;

namespace Azure.Base.Http.Pipeline
{
    public abstract class RetryPolicy : HttpPipelinePolicy
    {
        public static RetryPolicy CreateFixed(int maxRetries, TimeSpan delay, params int[] retriableCodes)
            => new FixedRetryPolicy(retriableCodes, exception => false, maxRetries, delay);


        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {

        }

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

                TimeSpan delay;

                attempt++;

                if (lastException != null)
                {
                    if (!ShouldRetryException(lastException, attempt, out delay))
                    {
                        // Rethrow a singular exception
                        if (exceptions.Count == 1)
                        {
                            ExceptionDispatchInfo.Capture(lastException).Throw();
                        }

                        throw new AggregateException($"Retry failed after {attempt} tries.", exceptions);
                    }
                }
                else if (!ShouldRetryResponse(message, attempt, out delay))
                {
                    return;
                }

                if (delay > TimeSpan.Zero)
                {
                    await Delay(delay, message.Cancellation);
                }

                HttpPipelineEventSource.Singleton.RequestRetrying(message.Request, attempt);
            }
        }

        internal virtual async Task Delay(TimeSpan time, CancellationToken cancellationToken)
        {
            await Task.Delay(time, cancellationToken).ConfigureAwait(false);
        }

        protected abstract bool ShouldRetryResponse(HttpPipelineMessage message, int attempted, out TimeSpan delay);

        protected abstract bool ShouldRetryException(Exception exception, int attempted, out TimeSpan delay);
    }
}
