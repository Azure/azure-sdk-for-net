// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Messaging.WebPubSub.Clients
{
    internal sealed partial class WebSocketClient : IWebSocketClient
    {
        private readonly ClientWebSocket _socket;
        private readonly Uri _uri;
        private readonly string _protocol;
        private readonly MemoryBufferWriter _buffer;

        private readonly SemaphoreSlim _sendLock = new SemaphoreSlim(1);

        public WebSocketClient(Uri uri, string protocol)
        {
            _protocol = protocol;
            _socket = new ClientWebSocket();
            _socket.Options.AddSubProtocol(_protocol);
            _uri = uri;
            _buffer = new MemoryBufferWriter();
        }

        public void Dispose()
        {
            _sendLock.Dispose();
            _socket.Dispose();
            _buffer.Dispose();
        }

        public async Task ConnectAsync(CancellationToken token)
        {
            WebPubSubClientEventSource.Log.WebSocketConnecting(_protocol);

            await _socket.ConnectAsync(_uri, token).ConfigureAwait(false);
        }

        public async Task SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await _socket.SendAsync(new ArraySegment<byte>(buffer.ToArray()) , messageType, endOfMessage, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _sendLock.Release();
            }
        }

        public async Task<WebSocketReadResult> ReceiveOneFrameAsync(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            if (_socket.State == WebSocketState.Closed)
            {
                return new WebSocketReadResult(default, true);
            }

            _buffer.Reset();
            var type = await ReceiveOneFrameAsync(_buffer, _socket, token).ConfigureAwait(false);
            if (type == WebSocketMessageType.Close)
            {
                if (_socket.State == WebSocketState.CloseReceived)
                {
                    try
                    {
                        await _socket.CloseOutputAsync(_socket.CloseStatus ?? WebSocketCloseStatus.EndpointUnavailable, null, default).ConfigureAwait(false);
                    }
                    catch { }
                }

                return new WebSocketReadResult(default, true, _socket.CloseStatus);
            }

            return new WebSocketReadResult(_buffer.AsReadOnlySequence());
        }

        public async Task StopAsync(CancellationToken token)
        {
            await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, token).ConfigureAwait(false);
        }

        internal void Abort()
        {
            _socket.Abort();
        }

        private static async Task<WebSocketMessageType> ReceiveOneFrameAsync(IBufferWriter<byte> buffer, WebSocket socket, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }

            var memory = buffer.GetMemory();
            var receiveResult = await ReadSocketAsync(socket, memory, token).ConfigureAwait(false);

            if (receiveResult.MessageType == WebSocketMessageType.Close)
            {
                return WebSocketMessageType.Close;
            }

            buffer.Advance(receiveResult.Count);

            while (!receiveResult.EndOfMessage)
            {
                memory = buffer.GetMemory();
                receiveResult = await ReadSocketAsync(socket, memory, token).ConfigureAwait(false);

                // Need to check again for NetCoreApp2.2 because a close can happen between a 0-byte read and the actual read
                if (receiveResult.MessageType == WebSocketMessageType.Close)
                {
                    return WebSocketMessageType.Close;
                }

                buffer.Advance(receiveResult.Count);
            }

            return receiveResult.MessageType;
        }

        private static async Task<WebSocketReceiveResult> ReadSocketAsync(WebSocket socket, Memory<byte> destination, CancellationToken token)
        {
            var array = new ArraySegment<byte>(new byte[destination.Length]);
            var receiveResult = await socket.ReceiveAsync(array, token).ConfigureAwait(false);
            array.Array.CopyTo(destination);
            return receiveResult;
        }
    }
}
