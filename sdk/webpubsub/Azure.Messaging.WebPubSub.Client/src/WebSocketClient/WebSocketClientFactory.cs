// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    internal class WebSocketClientFactory: IWebSocketClientFactory
    {
        public IWebSocketClient CreateWebSocketClient(Uri uri, string protocol)
        {
            return new WebSocketClient(uri, protocol);
        }
    }
}
