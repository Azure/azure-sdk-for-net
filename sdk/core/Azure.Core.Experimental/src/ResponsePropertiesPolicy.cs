// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// </summary>
    internal class ResponsePropertiesPolicy : HttpPipelinePolicy
    {
        /// <inheritdoc/>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        /// <inheritdoc/>
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private static async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            message.EvaluateError();

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }
        }
    }
}
