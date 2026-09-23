// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Containers.Apps.Sandbox
{
    /// <summary> Represents a connected stream to a running sandbox. </summary>
    public class SandboxStream : IDisposable, IAsyncDisposable
    {
        private readonly SemaphoreSlim _sendLock = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim _receiveLock = new SemaphoreSlim(1, 1);
        private bool _disposed;

        /// <summary> Initializes a new instance of <see cref="SandboxStream"/> for mocking. </summary>
        protected SandboxStream()
        {
        }

        internal SandboxStream(WebSocket webSocket)
        {
            Argument.AssertNotNull(webSocket, nameof(webSocket));
            WebSocket = webSocket;
        }

        internal WebSocket WebSocket { get; }

        /// <summary> Sends a message to the sandbox. </summary>
        /// <param name="data"> The message payload. </param>
        /// <param name="messageType"> The message payload type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task SendMessageAsync(
            BinaryData data,
            SandboxStreamMessageType messageType = SandboxStreamMessageType.Text,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            ThrowIfDisposed();

            WebSocketMessageType webSocketMessageType = messageType switch
            {
                SandboxStreamMessageType.Text => WebSocketMessageType.Text,
                SandboxStreamMessageType.Binary => WebSocketMessageType.Binary,
                _ => throw new ArgumentOutOfRangeException(nameof(messageType))
            };

            byte[] bytes = data.ToArray();
            await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await WebSocket.SendAsync(
                    new ArraySegment<byte>(bytes),
                    webSocketMessageType,
                    endOfMessage: true,
                    cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _sendLock.Release();
            }
        }

        /// <summary> Receives the next complete message from the sandbox. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The next message received from the sandbox. </returns>
        public virtual async Task<SandboxStreamMessage> ReceiveMessageAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            await _receiveLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                byte[] buffer = new byte[8192];
                using var content = new MemoryStream();
                WebSocketReceiveResult result;
                do
                {
                    result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(false);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        return new SandboxStreamMessage(
                            SandboxStreamMessageType.Close,
                            BinaryData.FromBytes(Array.Empty<byte>()),
                            result.CloseStatus.HasValue ? (int?)result.CloseStatus.Value : null,
                            result.CloseStatusDescription);
                    }

                    content.Write(buffer, 0, result.Count);
                }
                while (!result.EndOfMessage);

                SandboxStreamMessageType messageType = result.MessageType == WebSocketMessageType.Binary
                    ? SandboxStreamMessageType.Binary
                    : SandboxStreamMessageType.Text;

                return new SandboxStreamMessage(
                    messageType,
                    BinaryData.FromBytes(content.ToArray()),
                    closeStatus: null,
                    closeStatusDescription: null);
            }
            finally
            {
                _receiveLock.Release();
            }
        }

        /// <summary> Closes the sandbox stream. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            if (WebSocket.State == WebSocketState.Open || WebSocket.State == WebSocketState.CloseReceived)
            {
                await WebSocket.CloseAsync(
                    WebSocketCloseStatus.NormalClosure,
                    statusDescription: null,
                    cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            WebSocket?.Dispose();
            _sendLock.Dispose();
            _receiveLock.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                await CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }
            finally
            {
                Dispose();
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(SandboxStream));
            }
        }
    }
}
