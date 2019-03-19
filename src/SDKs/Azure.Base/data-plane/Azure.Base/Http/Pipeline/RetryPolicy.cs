// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public abstract class RetryPolicy : HttpPipelinePolicy
    {
        public static RetryPolicy CreateFixed(int maxRetries, TimeSpan delay, params int[] retriableCodes)
            => new FixedPolicy(retriableCodes, maxRetries, delay);

        public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            int attempt = 1;
            while (true)
            {
                await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
                if (!ShouldRetry(message, attempt++, out var delay)) return;
                if (delay > TimeSpan.Zero) await Task.Delay(delay, message.Cancellation).ConfigureAwait(false);
            }
        }

        protected abstract bool ShouldRetry(HttpMessage message, int attempted, out TimeSpan delay);
    }
}
