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

        public override async Task ProcessAsync(HttpPipelineMessage pipelineMessage, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            int attempt = 1;
            while (true)
            {
                await ProcessNextAsync(pipeline, pipelineMessage).ConfigureAwait(false);
                if (!ShouldRetry(pipelineMessage, attempt++, out var delay)) return;
                if (delay > TimeSpan.Zero) await Task.Delay(delay, pipelineMessage.Cancellation).ConfigureAwait(false);
            }
        }

        protected abstract bool ShouldRetry(HttpPipelineMessage pipelineMessage, int attempted, out TimeSpan delay);
    }
}
