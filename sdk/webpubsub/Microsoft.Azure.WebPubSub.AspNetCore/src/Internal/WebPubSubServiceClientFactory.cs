// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Options;

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

            switch (_options.ServiceEndpoint.CredentialKind)
            {
                case CredentialKind.ConnectionString: return new WebPubSubServiceClient<THub>(_options.ServiceEndpoint.ConnectionString, _options.ServiceEndpoint.ClientOptions);
                case CredentialKind.AzureKeyCredential: return new WebPubSubServiceClient<THub>(_options.ServiceEndpoint.Endpoint, _options.ServiceEndpoint.AzureKeyCredential, _options.ServiceEndpoint.ClientOptions);
                case CredentialKind.TokenCredential: return new WebPubSubServiceClient<THub>(_options.ServiceEndpoint.Endpoint, _options.ServiceEndpoint.TokenCredential, _options.ServiceEndpoint.ClientOptions);
                default: throw new NotSupportedException("Not supported method to inject `WebPubSubServiceClient`.");
            }
        }
    }
}
