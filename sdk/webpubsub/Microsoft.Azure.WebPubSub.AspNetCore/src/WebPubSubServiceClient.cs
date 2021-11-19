// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core;
using Azure.Messaging.WebPubSub;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Web PubSub serivce client based on user implemented <see cref="WebPubSubHub"/>.
    /// Hub name is the class name of user implemented <see cref="WebPubSubHub"/>.
    /// </summary>
    /// <typeparam name="THub">User implemented <see cref="WebPubSubHub"/>.</typeparam>
    public class WebPubSubServiceClient<THub> : WebPubSubServiceClient where THub : WebPubSubHub
    {
        /// <summary> Initializes a new instance of WebPubSubServiceClient for mocking. </summary>
        protected WebPubSubServiceClient()
            : base()
        { }

        internal WebPubSubServiceClient(string connectionString, WebPubSubServiceClientOptions options)
            : base(connectionString, typeof(THub).Name, options)
        { }

        internal WebPubSubServiceClient(Uri endpoint, TokenCredential credential, WebPubSubServiceClientOptions options)
            : base(endpoint, typeof(THub).Name, credential, options)
        { }

        internal WebPubSubServiceClient(Uri endpoint, AzureKeyCredential credential, WebPubSubServiceClientOptions options)
            : base(endpoint, typeof(THub).Name, credential, options)
        { }
    }
}
