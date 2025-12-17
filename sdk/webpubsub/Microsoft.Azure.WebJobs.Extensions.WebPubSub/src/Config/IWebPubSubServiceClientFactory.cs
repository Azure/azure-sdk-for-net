// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.WebPubSub;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal interface IWebPubSubServiceClientFactory
    {
        /// <summary>
        /// Creates a WebPubSubServiceClient with fallback connection and hub resolution.
        /// Priority for connection:
        ///   1. attributeConnection (can be connection string or config section name)
        ///   2. options (identity-based connection prioritized over connection string for security)
        /// Priority for hub: attributeHub > options.Hub
        /// </summary>
        /// <param name="attributeConnection">Connection from the attribute (can be connection string or config section name).</param>
        /// <param name="attributeHub">Hub from the attribute (highest priority).</param>
        /// <returns>A configured WebPubSubServiceClient instance.</returns>
        WebPubSubServiceClient Create(string attributeConnection, string attributeHub);
    }
}
