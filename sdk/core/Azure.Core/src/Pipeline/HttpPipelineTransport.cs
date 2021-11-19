// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
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
        /// <see cref="HttpPipeline.CreateMessage()"/> should be used instead.
        /// </summary>
        /// <returns></returns>
        public abstract Request CreateRequest();

        /// <summary>
        /// Creates the default <see cref="HttpPipelineTransport"/> based on the current environment and configuration.
        /// </summary>
        /// <param name="options"><see cref="HttpPipelineTransportOptions"/> that affect how the transport is configured.</param>
        /// <returns></returns>
        internal static HttpPipelineTransport Create(HttpPipelineTransportOptions? options = null)
        {
#if NETFRAMEWORK
            if (!AppContextSwitchHelper.GetConfigValue(
                "Azure.Core.Pipeline.DisableHttpWebRequestTransport",
                "AZURE_CORE_DISABLE_HTTPWEBREQUESTTRANSPORT"))
            {
                return options switch
                {
                    null => HttpWebRequestTransport.Shared,
                    _ => new HttpWebRequestTransport(options)
                };
            }
#endif
            return options switch
            {
                null => HttpClientTransport.Shared,
                _ => new HttpClientTransport(options)
            };
        }

        /// <summary>
        /// Disposes the underlying transport.
        /// </summary>
        public void Dispose()
        {
            // TODO: When transport disposal is needed for a nested client scenario, this method should implement reference counting to ensure proper disposal.
            DisposeInternal();
        }

        /// <summary>
        /// Dispose implementation for implementors to override for freeing resources on Dispose.
        /// This method should not be called directly.
        /// </summary>
        internal virtual void DisposeInternal() { }
    }
}
