// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Containers.Apps.Sandbox
{
    internal sealed class SandboxWebSocketClient : ISandboxWebSocketClient
    {
        private const int MaximumMessageSize = 16 * 1024 * 1024;
        private readonly WebSocket _socket;
        private readonly SemaphoreSlim _sendLock = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim _receiveLock = new SemaphoreSlim(1, 1);
        private int _disposed;

        internal SandboxWebSocketClient(WebSocket socket) =>
            _socket = socket ?? throw new ArgumentNullException(nameof(socket));

        internal TimeSpan CloseTimeout { get; set; } = TimeSpan.FromSeconds(5);

        internal static async Task<ISandboxWebSocketClient> ConnectAsync(Uri uri, string authorization, CancellationToken cancellationToken)
        {
            var socket = new ClientWebSocket();
            try
            {
                socket.Options.SetRequestHeader("Authorization", authorization);
                await socket.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
                return new SandboxWebSocketClient(socket);
            }
            catch
            {
                socket.Dispose();
                throw;
            }
        }

        public async Task SendAsync(BinaryData data, SandboxStreamMessageType type, CancellationToken cancellationToken)
        {
            if (data is null) throw new ArgumentNullException(nameof(data));
            WebSocketMessageType messageType = type switch
            {
                SandboxStreamMessageType.Text => WebSocketMessageType.Text,
                SandboxStreamMessageType.Binary => WebSocketMessageType.Binary,
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
            ThrowIfDisposed();
            await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                ThrowIfDisposed();
                await _socket.SendAsync(new ArraySegment<byte>(data.ToArray()), messageType, true, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _sendLock.Release();
            }
        }

        public async Task<SandboxStreamMessage> ReceiveAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            await _receiveLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                ThrowIfDisposed();
                byte[] buffer = new byte[8192];
                using MemoryStream content = new MemoryStream();
                WebSocketMessageType? type = null;
                WebSocketReceiveResult result;
                do
                {
                    result = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(false);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        return new SandboxStreamMessage(SandboxStreamMessageType.Close, null,
                            result.CloseStatus.HasValue ? (int?)result.CloseStatus.Value : null, result.CloseStatusDescription);
                    }
                    if (type.HasValue && result.MessageType != type.Value)
                        throw new InvalidDataException("The sandbox stream changed message type within a message.");
                    type = result.MessageType;
                    if (content.Length + result.Count > MaximumMessageSize)
                        throw new InvalidDataException("The sandbox stream message exceeds the maximum supported size.");
                    content.Write(buffer, 0, result.Count);
                } while (!result.EndOfMessage);

                return new SandboxStreamMessage(result.MessageType == WebSocketMessageType.Binary
                    ? SandboxStreamMessageType.Binary : SandboxStreamMessageType.Text,
                    BinaryData.FromBytes(content.ToArray()));
            }
            finally
            {
                _receiveLock.Release();
            }
        }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) != 0) return;
            _socket.Abort();
            _socket.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (Interlocked.Exchange(ref _disposed, 1) != 0) return;
            try
            {
                if (_socket.State is WebSocketState.Open or WebSocketState.CloseReceived)
                {
                    using CancellationTokenSource timeout = new CancellationTokenSource(CloseTimeout);
                    Task close = _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", timeout.Token);
                    if (await Task.WhenAny(close, Task.Delay(CloseTimeout)).ConfigureAwait(false) == close)
                    {
                        await close.ConfigureAwait(false);
                    }
                    else
                    {
                        _socket.Abort();
                        _ = close.ContinueWith(t => { _ = t.Exception; }, CancellationToken.None,
                            TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
                    }
                }
            }
            catch (Exception ex) when (ex is WebSocketException or OperationCanceledException or ObjectDisposedException)
            {
                _socket.Abort();
            }
            finally
            {
                _socket.Dispose();
            }
        }

        private void ThrowIfDisposed()
        {
            if (Volatile.Read(ref _disposed) != 0) throw new ObjectDisposedException(nameof(SandboxWebSocketClient));
        }
    }
}
