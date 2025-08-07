// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.WebPubSub;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal interface IWebPubSubForSocketIOService
    {
        public WebPubSubServiceClient Client { get; }
    }
}
