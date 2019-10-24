// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represents a <see cref="HttpPipelinePolicy"/> that doesn't do any asynchronous or synchronously blocking operations.
    /// </summary>
    public abstract class HttpPipelineSynchronousPolicy : HttpPipelinePolicy
    {
        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            ProcessNext(message, pipeline);
            OnReceivedResponse(message);
        }

        /// <inheritdoc />
        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            OnReceivedResponse(message);
        }

        /// <summary>
        /// Method is invoked before the request is sent.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage" /> containing the request.</param>
        public virtual void OnSendingRequest(HttpMessage message) { }

        /// <summary>
        /// Method is invoked after the response is received.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage" /> containing the response.</param>
        public virtual void OnReceivedResponse(HttpMessage message) { }
    }
}
