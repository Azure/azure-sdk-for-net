// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Containers.Apps.Sandbox
{
    /// <summary> A WebSocket message stream connected to a sandbox. The caller owns the connection. </summary>
    public class SandboxStream : IDisposable, IAsyncDisposable
    {
        private readonly ISandboxWebSocketClient _client;

        /// <summary> Initializes a stream for mocking. </summary>
        protected SandboxStream()
        {
        }

        internal SandboxStream(ISandboxWebSocketClient client) =>
            _client = client ?? throw new ArgumentNullException(nameof(client));

        /// <summary> Sends one complete text or binary WebSocket message. The caller is responsible for the service's message schema. </summary>
        public virtual Task SendMessageAsync(BinaryData data, SandboxStreamMessageType type = SandboxStreamMessageType.Text,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            return _client.SendAsync(data, type, cancellationToken);
        }

        /// <summary> Receives one complete message, including a close message when the peer closes the connection. </summary>
        public virtual Task<SandboxStreamMessage> ReceiveMessageAsync(CancellationToken cancellationToken = default) =>
            _client.ReceiveAsync(cancellationToken);

        /// <inheritdoc />
        public void Dispose() => _client?.Dispose();

        /// <inheritdoc />
        public virtual ValueTask DisposeAsync() => _client?.DisposeAsync() ?? default;
    }
}
