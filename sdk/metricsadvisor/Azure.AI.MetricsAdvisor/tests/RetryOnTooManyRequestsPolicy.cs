// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class RetryOnTooManyRequestsPolicy : HttpPipelinePolicy
    {
        private const int TooManyRequestsStatusCode = 429;

        private const string RetryAfterHeaderName = "Retry-After";

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline) =>
            ProcessAsync(message, pipeline, false).EnsureCompleted();

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline) =>
            ProcessAsync(message, pipeline, true);

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            bool gotResponse = false;

            while (!gotResponse)
            {
                if (async)
                {
                    await ProcessNextAsync(message, pipeline);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }

                if (message.Response.Status == TooManyRequestsStatusCode)
                {
                    TimeSpan delay = message.Response.Headers.TryGetValue(RetryAfterHeaderName, out string retryAfterValue)
                        && int.TryParse(retryAfterValue, out int delayInSeconds)
                        ? TimeSpan.FromSeconds(delayInSeconds)
                        : TimeSpan.FromSeconds(1);

                    await WaitAsync(delay, async, message.CancellationToken);
                }
                else
                {
                    gotResponse = true;
                }
            }
        }

        private async ValueTask WaitAsync(TimeSpan delay, bool async, CancellationToken cancellationToken)
        {
            if (async)
            {
                await Task.Delay(delay, cancellationToken);
            }
            else
            {
                cancellationToken.WaitHandle.WaitOne(delay);
            }
        }
    }
}
