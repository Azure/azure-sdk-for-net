// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Request builder.
    /// </summary>
    public class WebPubSubRequestHandlerBuilder
    {
        private WebPubSubValidationOptions _options;

        /// <summary>
        /// ctor.
        /// </summary>
        public WebPubSubRequestHandlerBuilder()
        {
        }

        /// <summary>
        /// Register to add validation options.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public WebPubSubRequestHandlerBuilder AddValidationOptions(WebPubSubValidationOptions options)
        {
            _options = options;
            return this;
        }

        /// <summary>
        /// Build IServiceHub instance.
        /// </summary>
        /// <returns></returns>
        public ServiceRequestHandler Build()
        {
            return new ServiceRequestHandlerAdapter(_options);
        }
    }
}
