// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Core.Pipeline;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represents a <see cref="HttpPipelinePolicy"/> that doesn't do any asynchronous or synchronously blocking operations.
    /// </summary>
    public abstract class HttpPipelineSynchronousPolicy : PipelineSynchronousPolicy
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HttpPipelineSynchronousPolicy"/>
        /// </summary>
        protected HttpPipelineSynchronousPolicy() : base()
        {
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => Process((RestMessage)message, pipeline);

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => ProcessAsync((RestMessage)message, pipeline);

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
