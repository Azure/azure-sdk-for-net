// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represents an HTTP pipeline transport used to send HTTP requests and receive responses.
    /// </summary>
    public abstract class HttpPipelineTransport
    {
        /// <summary>
        /// Sends the request contained by the <paramref name="message"/> and sets the <see cref="HttpMessage.Response"/> property to received response synchronously.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> containing request and response.</param>
        public abstract void Process(HttpMessage message);

        /// <summary>
        /// Sends the request contained by the <paramref name="message"/> and sets the <see cref="HttpMessage.Response"/> property to received response asynchronously.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> containing request and response.</param>
        public abstract ValueTask ProcessAsync(HttpMessage message);

        /// <summary>
        /// Creates a new transport specific instance of <see cref="Request"/>. This should not be called directly, <see cref="HttpPipeline.CreateRequest"/> or
        /// <see cref="HttpPipeline.CreateMessage"/> should be used instead.
        /// </summary>
        /// <returns></returns>
        public abstract Request CreateRequest();
    }
}
