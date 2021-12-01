// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A wrapper type for <see cref="HttpPipeline"/> that exposes a <see cref="Dispose"/> method for disposal of the underlying <see cref="HttpPipelineTransport"/>.
    /// </summary>
    public sealed class DisposableHttpPipeline : HttpPipeline, IDisposable
    {
        /// <summary>
        /// Creates a new instance of <see cref="HttpPipeline"/> with the provided transport, policies and response classifier.
        /// </summary>
        /// <param name="transport">The <see cref="HttpPipelineTransport"/> to use for sending the requests.</param>
        /// <param name="perCallIndex"></param>
        /// <param name="perRetryIndex"></param>
        /// <param name="policies">Policies to be invoked as part of the pipeline in order.</param>
        /// <param name="responseClassifier">The response classifier to be used in invocations.</param>
        internal DisposableHttpPipeline(HttpPipelineTransport transport, int perCallIndex, int perRetryIndex, HttpPipelinePolicy[] policies, ResponseClassifier responseClassifier)
            : base(transport, perCallIndex, perRetryIndex, policies, responseClassifier)
        {
        }

        /// <summary>
        /// Calls Dispose on the underlying <see cref="HttpPipelineTransport"/>.
        /// </summary>
        public void Dispose()
        {
            _transport.Dispose();
        }
    }
}
