// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Net.WebSockets;

namespace Azure.Messaging.WebPubSub.Clients
{
    internal struct WebSocketReadResult
    {
        public bool IsClosed { get; }

        public ReadOnlySequence<byte> Payload { get; }

        public WebSocketCloseStatus? CloseStatus { get; }

        public WebSocketReadResult(ReadOnlySequence<byte> payload, bool isClosed = false, WebSocketCloseStatus? closeStatus = null)
        {
            Payload = payload;
            IsClosed = isClosed;
            CloseStatus = closeStatus;
        }
    }
}
