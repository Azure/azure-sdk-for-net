// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An implementation of <see cref="HttpPipeline"/> that may contain resources that require disposal.
    /// </summary>
    public sealed class DisposableHttpPipeline : HttpPipeline, IDisposable
    {
        /// <summary>
        /// Indicates whether this instance was constructed internally. This information is used to determine if Dispose(true) is required to dispose of the Transport.
        /// </summary>
        private bool isTransportOwnedInternally;

        /// <summary>
        /// Creates a new instance of <see cref="HttpPipeline"/> with the provided transport, policies and response classifier.
        /// </summary>
        /// <param name="transport">The <see cref="HttpPipelineTransport"/> to use for sending the requests.</param>
        /// <param name="perCallIndex"></param>
        /// <param name="perRetryIndex"></param>
        /// <param name="policies">Policies to be invoked as part of the pipeline in order.</param>
        /// <param name="responseClassifier">The response classifier to be used in invocations.</param>
        /// <param name="isTransportOwnedInternally"> </param>
        internal DisposableHttpPipeline(HttpPipelineTransport transport, int perCallIndex, int perRetryIndex, HttpPipelinePolicy[] policies, ResponseClassifier responseClassifier, bool isTransportOwnedInternally)
            : base(transport, perCallIndex, perRetryIndex, policies, responseClassifier)
        {
            this.isTransportOwnedInternally = isTransportOwnedInternally;
        }

        /// <summary>
        /// Disposes the underlying transport if it is owned by the client, i.e. it was created via the Build method on <see cref="HttpPipelineBuilder"/>. If the underlying transport is not owned by the client, i.e. it was supplied as a custom transport on <see cref="ClientOptions"/>, it will not be disposed.
        /// <remarks>
        /// The reason not to dispose a transport owned outside the client, i.e. one that was provided via <see cref="ClientOptions"/> is to account for scenarios
        /// where the custom transport may be shared across clients. In this case, it is possible to dispose of a transport
        /// still in use by other clients. When the transport is created internally, it can properly determine if a shared instance is in use.
        /// </remarks>
        /// </summary>
        public void Dispose()
        {
            // TODO: When transport disposal is needed for a nested client scenario, this method should implement reference counting to ensure proper disposal.
            if (isTransportOwnedInternally)
            {
                (_transport as IDisposable)?.Dispose();
            }
        }
    }
}
