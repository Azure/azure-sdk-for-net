// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A wrapper type for <see cref="HttpPipeline"/> that exposes a Dispose method for disposal of the underlying <see cref="HttpPipelineTransport"/>.
    /// </summary>
    public sealed class DisposableHttpPipeline : HttpPipeline, IDisposable
    {
        /// <summary>
        /// Indicates whether this instance was constructed internally. This information is used to determine if Dispose(true) is required to dispose of the Transport.
        /// </summary>
        internal bool isTransportOwnedInternally;

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
        /// Disposes the underlying transport if it is owned internally. If the underlying transport was created externally, nothing is disposed.
        /// <remarks>
        /// The behavior of ignoring disposal when the transport is not owned is to account for scenarios in which the supplied transport is created
        /// externally and potentially shared across clients. In this case, it is possible to dispose of a transport still in use by other clients.
        /// When the transport is created internally, it can properly determine if a shared instance is in use.
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
