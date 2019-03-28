// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public abstract class RetryPolicy : HttpPipelinePolicy
    {
        public static RetryPolicy CreateFixed(int maxRetries, TimeSpan delay, params int[] retriableCodes)
            => new FixedPolicy(retriableCodes, maxRetries, delay);

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            int attempt = 1;
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

                if (!ShouldRetry(message, lastException, attempt++, out var delay))
                {
                    if (lastException != null)
                    {
                        throw new AggregateException($"Retry failed after {attempt - 1} tries.", exceptions);
                    }

                    return;
                }

                if (delay > TimeSpan.Zero)
                {
                    await Delay(delay, message.Cancellation);
                }
            }
        }

        protected virtual async Task Delay(TimeSpan time, CancellationToken cancellationToken)
        {
            await Task.Delay(time, cancellationToken).ConfigureAwait(false);
        }

        protected abstract bool ShouldRetry(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay);
    }
}
