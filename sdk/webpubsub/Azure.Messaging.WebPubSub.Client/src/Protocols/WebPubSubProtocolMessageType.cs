// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// It's a map to <see cref="System.Net.WebSockets.WebSocketMessageType"/>, indicating the message type.
    /// </summary>
    public enum WebPubSubProtocolMessageType
    {
        /// <summary>
        /// The message is in text format.
        /// </summary>
        Text = 0,
        /// <summary>
        /// The message is in binary format.
        /// </summary>
        Binary = 1,
    }
}
