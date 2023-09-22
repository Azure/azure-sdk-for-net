// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represent an extension point for the <see cref="HttpPipeline"/> that can mutate the <see cref="Request"/> and react to received <see cref="Response"/>.
    /// </summary>
    public abstract class HttpPipelinePolicy
    {
        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public abstract ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        public abstract void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        /// <summary>
        /// Invokes the next <see cref="HttpPipelinePolicy"/> in the <paramref name="pipeline"/>.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> next policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after next one.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        protected static ValueTask ProcessNextAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1));
        }

        /// <summary>
        /// Invokes the next <see cref="HttpPipelinePolicy"/> in the <paramref name="pipeline"/>.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> next policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after next one.</param>
        protected static void ProcessNext(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            pipeline.Span[0].Process(message, pipeline.Slice(1));
        }
    }
}
