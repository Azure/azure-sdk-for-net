// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public class LoggingPolicy : HttpPipelinePolicy
    {
        static readonly long s_delayWarningThreshold = 3000; // 3000ms
        static readonly long s_frequency = Stopwatch.Frequency;

        private readonly HttpPipelinePolicy _next;
        private readonly int[] _excludeCodes;

        public LoggingPolicy(HttpPipelinePolicy next, int[] excludeCodes)
        {
            _next = next;
            _excludeCodes = excludeCodes;
        }

        // TODO (pri 1): we should remove sensitive information, e.g. keys
        public override async Task ProcessAsync(HttpMessage message)
        {
            Log.ProcessingRequest(message);

            var before = Stopwatch.GetTimestamp();
            await _next.ProcessAsync(message).ConfigureAwait(false);
            var after = Stopwatch.GetTimestamp();

            var status = message.Response.Status;
            // if error status
            if (status >= 400 && status <= 599 && (Array.IndexOf(_excludeCodes, status) == -1)) {
                Log.ErrorResponse(message);
            }

            Log.ProcessingResponse(message);

            var elapsedMilliseconds = (after - before) * 1000 / s_frequency;
            if (elapsedMilliseconds > s_delayWarningThreshold) {
                Log.ResponseDelay(message, elapsedMilliseconds);
            }
        }
    }
}
