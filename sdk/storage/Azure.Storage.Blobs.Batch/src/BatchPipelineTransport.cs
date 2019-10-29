// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// BatchPipelineTransport is an empty transport protocol that never sends
    /// anything over the wire.  It allows batch sub-operations to run through
    /// a pipeline to and have policies like Authentication prepare the Request.
    /// </summary>
    internal class BatchPipelineTransport : HttpPipelineTransport
    {
        /// <summary>
        /// We cache the original pipeline used to create the BlobBatchClient
        /// so we can create the same type of Request objects.
        /// </summary>
        private readonly HttpPipeline _original;

        /// <summary>
        /// Creates a new instance of the <see cref="BatchPipelineTransport"/>
        /// class.
        /// </summary>
        /// <param name="originalPipeline">
        /// The original pipeline used to create the BlobBatchClient.
        /// </param>
        public BatchPipelineTransport(HttpPipeline originalPipeline) =>
            _original = originalPipeline ?? throw new ArgumentNullException(nameof(originalPipeline));

        /// <inheritdoc />
        public override Request CreateRequest() => _original.CreateRequest();

        /// <inheritdoc />
        public override void Process(HttpMessage message) =>
            SetResponse(message);

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        /// <inheritdoc />
        public override async ValueTask ProcessAsync(HttpMessage message) =>
            SetResponse(message);
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        private static void SetResponse(HttpMessage message) =>
            message.Response = new MemoryResponse();
    }
}
