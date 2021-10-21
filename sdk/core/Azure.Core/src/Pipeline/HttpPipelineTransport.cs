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
        /// <see cref="HttpPipeline.CreateMessage"/> should be used instead.
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

        internal const string MessageForServerCertificateCallback = "MessageForServerCertificateCallback";

        private object _thisLock { get; } = new();

        /// <summary>
        /// The current reference count for this transport. The count is incremented each time this transport instance is added to a <see cref="HttpPipeline"/>
        /// and is decremented each time <see cref="Dispose"/> is called.
        /// </summary>
        private int _referenceCount;

        /// <summary>
        /// Increments the reference count of this instance.
        /// </summary>
        internal void AddReference() => Interlocked.Increment(ref _referenceCount);

        /// <summary>
        /// Decrements the reference count for this transport instance and Disposes the underlying transport if the resulting count is zero.
        /// </summary>
        internal void Dispose()
        {
            int count = Interlocked.Decrement(ref _referenceCount);
            if (count == 0)
            {
                lock (_thisLock)
                {
                    if (_referenceCount == 0)
                    {
                        DisposeInternal();
                    }
                }
            }
        }

        /// <summary>
        /// Dispose implementation for implementors to override for freeing resources on Dispose.
        /// This method should not be called directly.
        /// </summary>
        internal virtual void DisposeInternal() { }
    }
}
