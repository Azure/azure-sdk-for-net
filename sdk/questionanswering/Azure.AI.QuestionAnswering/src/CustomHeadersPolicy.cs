// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.QuestionAnswering
{
    /// <summary>
    /// Renames custom headers like "RetryAfter" to standard headers like "Retry-After".
    /// </summary>
    internal class CustomHeadersPolicy : HttpPipelinePolicy
    {
        private const string CustomRetryAfterHeader = "RetryAfter";

        /// <inheritdoc/>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            UpdateHeaders(message);
            ProcessNext(message, pipeline);
        }

        /// <inheritdoc/>
        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            UpdateHeaders(message);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }

        private static void UpdateHeaders(HttpMessage message)
        {
            if (message.Response is null)
            {
                return;
            }

            if (message.Response.Headers.TryGetValue(CustomRetryAfterHeader, out _))
            {
               // TODO: Get service to send proper Retry-After header or request/make a change to modify Response.Headers.
            }
        }
    }
}
