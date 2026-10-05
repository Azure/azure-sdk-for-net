// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.WebPubSub.Chat
{
    public partial class WebPubSubChatServiceClientOptions
    {
        /// <summary>
        /// Gets or sets an optional reverse-proxy endpoint. When set, all requests are routed
        /// through this endpoint while preserving the original URI for JWT audience claims.
        /// Must be set before the client is constructed.
        /// </summary>
        public Uri ReverseProxyEndpoint { get; set; }
    }
}
