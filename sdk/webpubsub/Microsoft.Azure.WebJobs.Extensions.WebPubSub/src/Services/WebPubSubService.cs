// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.WebPubSub;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubService : IWebPubSubService
    {
        private readonly WebPubSubServiceClient _client;

        public WebPubSubService(string connectionString, string hub)
        {
            _client = new WebPubSubServiceClient(connectionString, hub);
        }

        // For tests.
        public WebPubSubService(WebPubSubServiceClient client)
        {
            _client = client;
        }

        public WebPubSubServiceClient Client => _client;

        internal WebPubSubConnection GetClientConnection(string userId = null, string[] roles = null, WebPubSubClientProtocol clientProtocol = WebPubSubClientProtocol.Default)
        {
            var url = _client.GetClientAccessUri(userId: userId, roles: roles, clientProtocol: clientProtocol);

            return new WebPubSubConnection(url);
        }
    }
}
