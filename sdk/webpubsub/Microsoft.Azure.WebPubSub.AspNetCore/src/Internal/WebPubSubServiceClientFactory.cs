// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Options;
using System;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    internal class WebPubSubServiceClientFactory
    {
        private readonly WebPubSubOptions _options;

        public WebPubSubServiceClientFactory(IOptions<WebPubSubOptions> options)
        {
            _options = options.Value;
        }

        public WebPubSubServiceClient<THub> Create<THub>() where THub : WebPubSubHub
        {
            if (_options == null || _options.ServiceEndpoint == null)
            {
                throw new ArgumentException($"Not able to create the WebPubSubServiceClient without a valid WebPubSubOptions.ServiceEndpoint. Please configure the ServiceEndpoint when DI the WebPubSub.");
            }

            if (!string.IsNullOrEmpty(_options.ServiceEndpoint.ConnectionString))
            {
                return new WebPubSubServiceClient<THub>(_options.ServiceEndpoint.ConnectionString, _options.ServiceEndpoint.ClientOptions);
            }
            if (_options.ServiceEndpoint.AzureKeyCredential != null)
            {
                return new WebPubSubServiceClient<THub>(_options.ServiceEndpoint.Endpoint, _options.ServiceEndpoint.AzureKeyCredential, _options.ServiceEndpoint.ClientOptions);
            }
            if (_options.ServiceEndpoint.TokenCredential != null)
            {
                return new WebPubSubServiceClient<THub>(_options.ServiceEndpoint.Endpoint, _options.ServiceEndpoint.TokenCredential, _options.ServiceEndpoint.ClientOptions);
            }

            return null;
        }
    }
}
