// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represent an extension point for the <see cref="HttpPipeline"/> that can mutate the <see cref="Request"/> and react to received <see cref="Response"/>.
    /// </summary>
    public abstract class HttpPipelinePolicy : PipelinePolicy
    {
        /// <summary>
        /// Applies the policy to the <paramref name="message"/>. Implementers are expected to mutate <see cref="HttpMessage.Request"/> before calling <see cref="ProcessNextAsync(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> and observe the <see cref="HttpMessage.Response"/> changes after.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public abstract ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        /// <summary>
        /// Applies the policy to the <paramref name="message"/>. Implementers are expected to mutate <see cref="ProcessNextAsync(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> and observe the <see cref="HttpMessage.Response"/> changes after.
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

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="pipeline"></param>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Invalid type for message: '{message?.GetType()}'");
            }

            if (pipeline is not AzureCorePipelineProcessor processor)
            {
                throw new InvalidOperationException($"Invalid type for pipeline: '{pipeline?.GetType()}'");
            }

            // The contract across ClientModel policy and Azure.Core policy is different
            // so if we're calling Process from a ClientModel policy, we need to pop some
            // policies off the stack before calling Process on the Azure.Core policy.
            await ProcessAsync(httpMessage, processor.Policies.Slice(currentIndex + 1)).ConfigureAwait(false);
        }

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="pipeline"></param>
        /// <param name="currentIndex"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Invalid type for message: '{message?.GetType()}'");
            }

            if (pipeline is not AzureCorePipelineProcessor processor)
            {
                throw new InvalidOperationException($"Invalid type for pipeline: '{pipeline?.GetType()}'");
            }

            Process(httpMessage, processor.Policies.Slice(currentIndex + 1));
        }
    }
}
