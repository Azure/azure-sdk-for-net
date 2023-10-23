// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Net.Http;
using System.Net.ClientModel.Core;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represents an HTTP pipeline transport used to send HTTP requests and receive responses.
    /// </summary>
    public abstract class HttpPipelineTransport : HttpPipelineMessageTransport
    {
        /// <summary>
        /// Creates a new transport specific instance of <see cref="Request"/>. This should not be called directly, <see cref="HttpPipeline.CreateRequest"/> or
        /// <see cref="HttpPipeline.CreateMessage()"/> should be used instead.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract Request CreateRequest();

        /// <summary>
        /// TBD.
        /// </summary>
        public HttpPipelineTransport() : base() { }

        internal HttpPipelineTransport(HttpClient client) : base(client) { }

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
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        public virtual void Process(HttpMessage message)
            => base.Process(message);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        public virtual async ValueTask ProcessAsync(HttpMessage message)
            => await base.ProcessAsync(message).ConfigureAwait(false);
    }
}
