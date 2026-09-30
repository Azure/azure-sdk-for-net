// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxWebSocketClientTests
    {
#if NET8_0_OR_GREATER
        [Test]
        public async Task RealConnectionSendsBearerHeaderAndReceivesText()
        {
            int port;
            using (TcpListener reservation = new TcpListener(IPAddress.Loopback, 0))
            {
                reservation.Start();
                port = ((IPEndPoint)reservation.LocalEndpoint).Port;
            }

            using HttpListener listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:{port}/");
            listener.Start();
            using CancellationTokenSource timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            Task server = Task.Run(async () =>
            {
                HttpListenerContext context = await listener.GetContextAsync();
                Assert.That(context.Request.Headers["Authorization"], Is.EqualTo("Bearer test-token"));
                HttpListenerWebSocketContext accepted = await context.AcceptWebSocketAsync(null);
                using WebSocket peer = accepted.WebSocket;
                await peer.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("hello")),
                    WebSocketMessageType.Text, true, timeout.Token);
                await peer.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "done", timeout.Token);
                await peer.ReceiveAsync(new ArraySegment<byte>(new byte[1]), timeout.Token);
            });

            try
            {
                await using ISandboxWebSocketClient client = await SandboxWebSocketClient.ConnectAsync(
                    new Uri($"ws://localhost:{port}/"), "Bearer test-token", timeout.Token);
                Assert.That((await client.ReceiveAsync(timeout.Token)).Data.ToString(), Is.EqualTo("hello"));
                Assert.That((await client.ReceiveAsync(timeout.Token)).Type, Is.EqualTo(SandboxStreamMessageType.Close));
                await client.DisposeAsync();
                await server;
            }
            finally
            {
                listener.Stop();
            }
        }
#endif

        [Test]
        public async Task ReceivesCompleteFragmentedMessageAndClose()
        {
            FakeWebSocket socket = new FakeWebSocket();
            socket.Enqueue("hello ", WebSocketMessageType.Text, false);
            socket.Enqueue("world", WebSocketMessageType.Text, true);
            using SandboxWebSocketClient client = new SandboxWebSocketClient(socket);

            SandboxStreamMessage message = await client.ReceiveAsync(CancellationToken.None);
            Assert.That(message.Type, Is.EqualTo(SandboxStreamMessageType.Text));
            Assert.That(message.Data.ToString(), Is.EqualTo("hello world"));
            Assert.That((await client.ReceiveAsync(CancellationToken.None)).Type, Is.EqualTo(SandboxStreamMessageType.Close));
        }

        [Test]
        public void MixedFrameTypesAreRejected()
        {
            FakeWebSocket socket = new FakeWebSocket();
            socket.Enqueue("hello", WebSocketMessageType.Text, false);
            socket.Enqueue("world", WebSocketMessageType.Binary, true);
            using SandboxWebSocketClient client = new SandboxWebSocketClient(socket);
            Assert.ThrowsAsync<InvalidDataException>(async () => await client.ReceiveAsync(CancellationToken.None));
        }

        [Test]
        public async Task SendsAreSerialized()
        {
            FakeWebSocket socket = new FakeWebSocket { DelaySends = true };
            using SandboxWebSocketClient client = new SandboxWebSocketClient(socket);
            await Task.WhenAll(
                client.SendAsync(BinaryData.FromString("one"), SandboxStreamMessageType.Text, CancellationToken.None),
                client.SendAsync(BinaryData.FromString("two"), SandboxStreamMessageType.Binary, CancellationToken.None));
            Assert.That(socket.MaxConcurrentSends, Is.EqualTo(1));
            Assert.That(socket.Sent, Is.EqualTo(new[] { "one", "two" }));
        }

        [Test]
        public async Task DisposeAbortsWhenPeerDoesNotFinishClosing()
        {
            FakeWebSocket socket = new FakeWebSocket { HangOnClose = true };
            SandboxWebSocketClient client = new SandboxWebSocketClient(socket)
            {
                CloseTimeout = TimeSpan.FromMilliseconds(30)
            };
            await client.DisposeAsync();
            Assert.That(socket.WasAborted, Is.True);
            Assert.That(socket.WasDisposed, Is.True);
        }

        private sealed class FakeWebSocket : WebSocket
        {
            private readonly Queue<(byte[] Data, WebSocketMessageType Type, bool End)> _frames = new Queue<(byte[], WebSocketMessageType, bool)>();
            private WebSocketState _state = WebSocketState.Open;
            private int _sending;
            public List<string> Sent { get; } = new List<string>();
            public int MaxConcurrentSends { get; private set; }
            public bool DelaySends { get; set; }
            public bool HangOnClose { get; set; }
            public bool WasAborted { get; private set; }
            public bool WasDisposed { get; private set; }
            public override WebSocketCloseStatus? CloseStatus => WebSocketCloseStatus.NormalClosure;
            public override string CloseStatusDescription => null;
            public override WebSocketState State => _state;
            public override string SubProtocol => null;

            public void Enqueue(string message, WebSocketMessageType type, bool end) =>
                _frames.Enqueue((Encoding.UTF8.GetBytes(message), type, end));

            public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (_frames.Count == 0)
                    return Task.FromResult(new WebSocketReceiveResult(0, WebSocketMessageType.Close, true, WebSocketCloseStatus.NormalClosure, null));
                var frame = _frames.Dequeue();
                Array.Copy(frame.Data, 0, buffer.Array, buffer.Offset, frame.Data.Length);
                return Task.FromResult(new WebSocketReceiveResult(frame.Data.Length, frame.Type, frame.End));
            }

            public override async Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType type, bool endOfMessage, CancellationToken cancellationToken)
            {
                int current = Interlocked.Increment(ref _sending);
                MaxConcurrentSends = Math.Max(current, MaxConcurrentSends);
                try
                {
                    if (DelaySends) await Task.Delay(20, cancellationToken);
                    Sent.Add(Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count));
                }
                finally
                {
                    Interlocked.Decrement(ref _sending);
                }
            }

            public override Task CloseAsync(WebSocketCloseStatus status, string reason, CancellationToken cancellationToken)
            {
                if (HangOnClose) return Task.Delay(Timeout.Infinite);
                _state = WebSocketState.Closed;
                return Task.CompletedTask;
            }

            public override Task CloseOutputAsync(WebSocketCloseStatus status, string reason, CancellationToken cancellationToken) =>
                CloseAsync(status, reason, cancellationToken);

            public override void Abort()
            {
                WasAborted = true;
                _state = WebSocketState.Aborted;
            }

            public override void Dispose()
            {
                WasDisposed = true;
                _state = WebSocketState.Closed;
            }
        }
    }
}
