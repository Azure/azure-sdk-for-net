// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public abstract class HttpPipelineIOAgnosticPolicy: HttpPipelinePolicy
    {
        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            ProcessNext(pipeline, message);
            OnReceivedResponse(message);
        }

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            await ProcessNextAsync(pipeline, message);
            OnReceivedResponse(message);
        }

        public virtual void OnSendingRequest(HttpPipelineMessage message) { }

        public virtual void OnReceivedResponse(HttpPipelineMessage message) { }
    }

    public abstract class HttpPipelinePolicy
    {
        /// <summary>
        /// Applies the policy to the <see cref="message"/>. Implementers are expected to mutate <see cref="HttpPipelineMessage.Request"/> before calling <see cref="ProcessNextAsync"/> and observe the <see cref="HttpPipelineMessage.Response"/> changes after.
        /// Last policy in the pipeline is expected to set the <see cref="HttpPipelineMessage.Response"/>
        /// </summary>
        /// <param name="message">The <see cref="HttpPipelineMessage"/> this policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after current one.</param>
        /// <returns></returns>
        public abstract Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        public abstract void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        /// <summary>
        /// Invokes the next <see cref="HttpPipelinePolicy"/> in the <see cref="pipeline"/>.
        /// </summary>
        /// <param name="message">The <see cref="HttpPipelineMessage"/> next policy would be applied to.</param>
        /// <param name="pipeline">The set of <see cref="HttpPipelinePolicy"/> to execute after next one.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static async Task ProcessNextAsync(ReadOnlyMemory<HttpPipelinePolicy> pipeline, HttpPipelineMessage message)
        {
            if (pipeline.IsEmpty) throw new InvalidOperationException("last policy in the pipeline must be a transport");
            var next = pipeline.Span[0];
            await next.ProcessAsync(message, pipeline.Slice(1)).ConfigureAwait(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static void ProcessNext(ReadOnlyMemory<HttpPipelinePolicy> pipeline, HttpPipelineMessage message)
        {
            if (pipeline.IsEmpty) throw new InvalidOperationException("last policy in the pipeline must be a transport");
            pipeline.Span[0].Process(message, pipeline.Slice(1));
        }
    }
}
