// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Base.Diagnostics;

namespace Azure.Base.Http.Pipeline
{
    public class LoggingPolicy : HttpPipelinePolicy
    {
        static readonly long s_delayWarningThreshold = 3000; // 3000ms
        static readonly long s_frequency = Stopwatch.Frequency;
        private static readonly HttpPipelineEventSource s_eventSource = HttpPipelineEventSource.Singleton;

        int[] _excludeErrors = Array.Empty<int>();

        public readonly static LoggingPolicy Shared = new LoggingPolicy();

        public LoggingPolicy(params int[] excludeErrors)
            => _excludeErrors = excludeErrors;

        // TODO (pri 1): we should remove sensitive information, e.g. keys
        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            s_eventSource.ProcessingRequest(message.Request);

            var before = Stopwatch.GetTimestamp();
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            var after = Stopwatch.GetTimestamp();

            var status = message.Response.Status;
            // if error status
            if (status >= 400 && status <= 599 && (Array.IndexOf(_excludeErrors, status) == -1)) {
                Log.ErrorResponse(message.Response);
            }

            s_eventSource.ProcessingResponse(message.Response);

            var elapsedMilliseconds = (after - before) * 1000 / s_frequency;
            if (elapsedMilliseconds > s_delayWarningThreshold) {
                s_eventSource.ResponseDelay(message.Response, elapsedMilliseconds);
            }
        }
    }
}
