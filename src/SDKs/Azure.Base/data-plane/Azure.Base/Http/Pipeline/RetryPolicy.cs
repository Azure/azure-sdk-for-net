// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public abstract class RetryPolicy : HttpPipelinePolicy
    {
        private readonly HttpPipelinePolicy _next;

        public RetryPolicy(HttpPipelinePolicy next)
        {
            _next = next;
        }

        public override async Task ProcessAsync(HttpMessage message)
        {
            int attempt = 1;
            while (true)
            {
                await _next.ProcessAsync(message).ConfigureAwait(false);
                if (!ShouldRetry(message, attempt++, out var delay)) return;
                if (delay > TimeSpan.Zero) await Task.Delay(delay, message.Cancellation).ConfigureAwait(false);
            }
        }

        protected abstract bool ShouldRetry(HttpMessage message, int attempted, out TimeSpan delay);
    }
}
