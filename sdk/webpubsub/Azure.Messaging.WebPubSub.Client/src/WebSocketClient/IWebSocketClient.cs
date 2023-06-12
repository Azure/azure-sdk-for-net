// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.Messaging.WebPubSub.Clients
{
    internal interface IWebSocketClient : IDisposable
    {
        Task ConnectAsync(CancellationToken token);

        Task SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken);

        Task<WebSocketReadResult> ReceiveOneFrameAsync(CancellationToken token);

        Task StopAsync(CancellationToken token);
    }
}
