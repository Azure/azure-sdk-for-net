﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Azure.Messaging.WebPubSub;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubService : IWebPubSubService
    {
        private readonly WebPubSubServiceClient _client;
        private readonly ServiceConfigParser _serviceConfig;

        public WebPubSubService(string connectionString, string hub)
        {
            _serviceConfig = new ServiceConfigParser(connectionString);
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
            var url = _client.GetClientAccessUri(userId, roles);

            #region TODO: Remove after SDK fix. Work-around to support http.
            if (!_serviceConfig.Endpoint.Scheme.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                var replaced = url.AbsoluteUri.Replace("wss", "ws");
                url = new Uri(replaced);
            }
            #endregion

            return new WebPubSubConnection(url);
        }
    }
}
