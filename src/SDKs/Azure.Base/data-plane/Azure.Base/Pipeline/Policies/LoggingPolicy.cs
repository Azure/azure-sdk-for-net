// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Base.Diagnostics;

namespace Azure.Base.Pipeline.Policies
{
    public class LoggingPolicy : HttpPipelinePolicy
    {
        private static readonly long s_delayWarningThreshold = 3000; // 3000ms
        private static readonly long s_frequency = Stopwatch.Frequency;
        private static readonly HttpPipelineEventSource s_eventSource = HttpPipelineEventSource.Singleton;

        public static readonly LoggingPolicy Shared = new LoggingPolicy();

        // TODO (pri 1): we should remove sensitive information, e.g. keys
        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            s_eventSource.Request(message.Request);

            if (message.Request.Content != null)
            {
                await s_eventSource.RequestContentAsync(message.Request, message.Cancellation);
            }

            var before = Stopwatch.GetTimestamp();
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            var after = Stopwatch.GetTimestamp();

            if (message.ResponseClassifier.IsErrorResponse(message.Response))
            {
                s_eventSource.ErrorResponse(message.Response);

                if (message.Response.ResponseContentStream != null)
                {
                    await s_eventSource.ErrorResponseContentAsync(message.Response, message.Cancellation).ConfigureAwait(false);
                }
            }

            s_eventSource.Response(message.Response);

            if (message.Response.ResponseContentStream != null)
            {
                await s_eventSource.ResponseContentAsync(message.Response, message.Cancellation).ConfigureAwait(false);
            }

            var elapsedMilliseconds = (after - before) * 1000 / s_frequency;
            if (elapsedMilliseconds > s_delayWarningThreshold) {
                s_eventSource.ResponseDelay(message.Response, elapsedMilliseconds);
            }
        }
    }
}
