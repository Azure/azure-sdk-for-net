// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    public abstract class HttpPipelinePolicy
    {
        /// <summary>
        /// Applies the policy to the <paramref name="message"/>. Implementers are expected to mutate <see cref="HttpPipelineMessage.Request"/> before calling <see cref="ProcessNextAsync"/> and observe the <see cref="HttpPipelineMessage.Response"/> changes after.
        /// Last policy in the pipeline is expected to set the <see cref="HttpPipelineMessage.Response"/>
        /// </summary>
        /// <param name="message">The <see cref="HttpPipelineMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns></returns>
        public abstract Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        public abstract void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        /// <summary>
        /// Invokes the next <see cref="HttpPipelinePolicy"/> in the <paramref name="pipeline"/>.
        /// </summary>
        /// <param name="message">The <see cref="HttpPipelineMessage"/> next policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after next one.</param>
        /// <returns></returns>
        protected static Task ProcessNextAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1));
        }

        protected static void ProcessNext(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            pipeline.Span[0].Process(message, pipeline.Slice(1));
        }
    }
}
