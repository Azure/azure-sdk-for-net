// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline
{
    /// <summary>
    /// TBD.
    /// </summary>
    public abstract class PipelineSynchronousPolicy : PipelinePolicy
    {
        protected override void Process(RestMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            ProcessNext(message, pipeline);
            OnReceivedResponse(message);
        }

        protected override async ValueTask ProcessAsync(RestMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            OnReceivedResponse(message);
        }

        /// <summary>
        /// Method is invoked before the request is sent.
        /// </summary>
        /// <param name="message">The <see cref="RestMessage" /> containing the request.</param>
        public virtual void OnSendingRequest(RestMessage message) { }

        /// <summary>
        /// Method is invoked after the response is received.
        /// </summary>
        /// <param name="message">The <see cref="RestMessage" /> containing the response.</param>
        public virtual void OnReceivedResponse(RestMessage message) { }
    }
}