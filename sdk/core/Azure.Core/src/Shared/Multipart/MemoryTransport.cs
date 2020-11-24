// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// An empty transport protocol that never sends anything over the wire.
    /// It allows multipart sub-operations to run through a pipeline to and have policies like Authentication prepare the Request.
    /// </summary>
    internal class MemoryTransport : HttpPipelineTransport
    {
        /// <inheritdoc />
        public override Request CreateRequest() => new MemoryRequest();

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
