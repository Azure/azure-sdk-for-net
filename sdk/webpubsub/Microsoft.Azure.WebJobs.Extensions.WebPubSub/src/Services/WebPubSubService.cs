// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
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

        internal WebPubSubConnection GetClientConnection(string userId = null, string[] roles = null)
        {
            var url = _client.GenerateClientAccessUri(userId: userId, roles: roles);

            return new WebPubSubConnection(url);
        }
    }
}
