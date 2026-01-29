// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// A simple in-memory <see cref="WebSocket"/> implementation used by unit tests to:
    /// 1. Capture all outbound messages sent by the client under test.
    /// 2. Provide a scriptable queue of inbound messages delivered via <see cref="ReceiveAsync"/>.
    ///
    /// This implementation purposefully keeps the surface minimal and only supports text frames
    /// (binary and fragmented frames are not required for the VoiceLive unit test scenarios).
    /// </summary>
    internal sealed class FakeWebSocket : WebSocket
    {
        private readonly ConcurrentQueue<string> _inboundQueue = new ConcurrentQueue<string>();
        private readonly List<string> _sentMessages = new List<string>();
        private readonly object _sentLock = new object();
        private readonly SemaphoreSlim _sendSignal = new SemaphoreSlim(0, int.MaxValue); // Signals a newly sent message.
        private readonly CancellationTokenSource _lifecycleCts = new CancellationTokenSource();

        private WebSocketState _state = WebSocketState.Open;
        private WebSocketCloseStatus? _closeStatus;
        private string? _closeStatusDescription;
        private int _disposed; // 0 = false, 1 = true

        /// <summary>
        /// Enqueues a text message that will be returned by the next <see cref="ReceiveAsync"/> call.
        /// </summary>
        /// <param name="json">The textual payload (typically JSON) to deliver to the client.</param>
        public void EnqueueTextMessage(string json)
        {
            if (json == null) throw new ArgumentNullException(nameof(json));
            ThrowIfDisposed();
            _inboundQueue.Enqueue(json);
        }

        /// <summary>
        /// Returns a snapshot of the UTF-8 text messages that have been sent through <see cref="SendAsync"/>.
        /// </summary>
        public IReadOnlyList<string> GetSentTextMessages()
        {
            lock (_sentLock)
            {
                return _sentMessages.ToArray();
            }
        }

        /// <summary>
        /// Waits until at least <paramref name="count"/> messages have been sent, or the <paramref name="timeout"/> elapses.
        /// </summary>
        /// <exception cref="TimeoutException">Thrown if the condition is not satisfied within the timeout.</exception>
        public async Task WaitForAtLeastAsync(int count, TimeSpan timeout)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (timeout <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(timeout));
            ThrowIfDisposed();

            var deadline = DateTime.UtcNow + timeout;
            while (true)
            {
                int current;
                lock (_sentLock)
                {
                    current = _sentMessages.Count;
                    if (current >= count)
                    {
                        return;
                    }
                }

                var remaining = deadline - DateTime.UtcNow;
                if (remaining <= TimeSpan.Zero)
                {
                    throw new TimeoutException($"Timed out waiting for at least {count} sent messages.");
                }

                // Wait until another message is sent or timeout.
                var wait = remaining < TimeSpan.FromMilliseconds(250) ? remaining : TimeSpan.FromMilliseconds(250);
                try
                {
                    await _sendSignal.WaitAsync(wait, _lifecycleCts.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException) when (_lifecycleCts.IsCancellationRequested)
                {
                    throw new ObjectDisposedException(nameof(FakeWebSocket));
                }
            }
        }

        /// <inheritdoc />
        public override WebSocketCloseStatus? CloseStatus => _closeStatus;

        /// <inheritdoc />
        public override string? CloseStatusDescription => _closeStatusDescription;

        /// <inheritdoc />
        public override WebSocketState State => _state;

        /// <inheritdoc />
        public override string? SubProtocol => null;

        /// <inheritdoc />
        public override void Abort()
        {
            if (_state == WebSocketState.Aborted || _state == WebSocketState.Closed) return;
            _state = WebSocketState.Aborted;
            _lifecycleCts.Cancel();
        }

        /// <inheritdoc />
        public override Task CloseAsync(WebSocketCloseStatus closeStatus, string? statusDescription, CancellationToken cancellationToken)
        {
            if (_state == WebSocketState.Closed) return Task.CompletedTask;
            _closeStatus = closeStatus;
            _closeStatusDescription = statusDescription;
            _state = WebSocketState.Closed;
            _lifecycleCts.Cancel();
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string? statusDescription, CancellationToken cancellationToken)
        {
            if (_state == WebSocketState.Closed || _state == WebSocketState.CloseSent) return Task.CompletedTask;
            _closeStatus = closeStatus;
            _closeStatusDescription = statusDescription;
            _state = WebSocketState.CloseSent;
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override async Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            if (buffer.Array == null) throw new ArgumentException("Buffer must have a backing array", nameof(buffer));

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (_state != WebSocketState.Open && _inboundQueue.IsEmpty)
                {
                    // Return a 0-length close if closed and no data remains.
                    return new WebSocketReceiveResult(0, WebSocketMessageType.Text, endOfMessage: true, _closeStatus, _closeStatusDescription);
                }

                if (_inboundQueue.TryDequeue(out var message))
                {
                    var bytes = Encoding.UTF8.GetBytes(message);
                    if (bytes.Length > buffer.Count)
                    {
                        throw new InvalidOperationException($"Provided receive buffer too small. Needed {bytes.Length}, had {buffer.Count}.");
                    }

                    Array.Copy(bytes, 0, buffer.Array, buffer.Offset, bytes.Length);
                    return new WebSocketReceiveResult(bytes.Length, WebSocketMessageType.Text, endOfMessage: true);
                }

                // Brief delay to avoid busy loop; integrate cancellation.
                try
                {
                    await Task.Delay(10, cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    throw; // propagate per requirements.
                }
            }
        }

        /// <inheritdoc />
        public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            if (_state != WebSocketState.Open)
            {
                throw new InvalidOperationException("Cannot send when WebSocket is not open.");
            }

            if (messageType == WebSocketMessageType.Text)
            {
                if (buffer.Array == null) throw new ArgumentException("Buffer must have a backing array", nameof(buffer));
                var text = Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
                lock (_sentLock)
                {
                    _sentMessages.Add(text);
                }
                _sendSignal.Release();
            }
            // Binary & Close frames are ignored for current test needs.
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 1) return;
            _state = WebSocketState.Closed;
            _lifecycleCts.Cancel();
            _lifecycleCts.Dispose();
            _sendSignal.Dispose();
        }

        private void ThrowIfDisposed()
        {
            if (Volatile.Read(ref _disposed) == 1)
            {
                throw new ObjectDisposedException(nameof(FakeWebSocket));
            }
        }
    }
}
