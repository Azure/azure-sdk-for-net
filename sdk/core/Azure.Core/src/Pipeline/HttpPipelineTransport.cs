// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.ServiceModel.Rest;
using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Core.Pipeline;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Represents an HTTP pipeline transport used to send HTTP requests and receive responses.
    /// </summary>
    public abstract class HttpPipelineTransport : PipelineTransport<HttpMessage>
    {
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
        /// TBD.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="classifier"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // TODO: we could look at removing CreateMessage at the top level because we _have_ to preserve
        // the public API on this type to CreateRequest, and do we really need both?
        // But, it seems good to have something that takes RequestOptions and ResponseClassifier (i.e.
        // a "response options" type) and creates a message with them both all at once.
        public override HttpMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier)
            => throw new System.NotImplementedException();
    }
}
