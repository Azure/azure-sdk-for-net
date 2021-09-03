// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Request builder.
    /// </summary>
    public class WebPubSubRequestBuilder
    {
        private WebPubSubValidationOptions _options;

        /// <summary>
        /// ctor.
        /// </summary>
        public WebPubSubRequestBuilder()
        {
        }

        /// <summary>
        /// Register to add validation options.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public WebPubSubRequestBuilder AddValidationOptions(WebPubSubValidationOptions options)
        {
            _options = options;
            return this;
        }

        /// <summary>
        /// Build IServiceHub instance.
        /// </summary>
        /// <returns></returns>
        public IServiceRequestHandler Build()
        {
            return new ServiceRequestHandler(_options);
        }
    }
}
