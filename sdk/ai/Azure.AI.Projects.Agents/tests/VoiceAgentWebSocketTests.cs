// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class VoiceAgentWebSocketTests
{
    [Test]
    public void CreatesExpectedFoundryWebSocketUri()
    {
        VoiceAgentWebSocket client = new(
            pipeline: null,
            endpoint: new Uri("https://example.services.ai.azure.com/api/projects/my-project/"),
            apiVersion: "v1",
            tokenProvider: null);
        VoiceAgentConnectionOptions options = new()
        {
            SessionId = "session 1",
            AgentVersion = "4",
            Store = true
        };

        Uri uri = client.CreateWebSocketUri("agent/name", options);

        Assert.Multiple(() =>
        {
            Assert.That(uri.Scheme, Is.EqualTo("wss"));
            Assert.That(uri.AbsolutePath, Is.EqualTo("/api/projects/my-project/agents/agent%2Fname/endpoint/protocols/voice"));
            Assert.That(uri.Query, Does.Contain("api-version=v1"));
            Assert.That(uri.Query, Does.Contain("agent_session_id=session%201"));
            Assert.That(uri.Query, Does.Contain("x-agent-version-override=4"));
            Assert.That(uri.Query, Does.Contain("store=true"));
        });
    }

    [Test]
    public async Task ReassemblesFragmentedMessages()
    {
        TestWebSocket webSocket = new(
            new TestWebSocket.Frame("hel", WebSocketMessageType.Text, endOfMessage: false),
            new TestWebSocket.Frame("lo", WebSocketMessageType.Text, endOfMessage: true),
            TestWebSocket.Frame.Close());
        await using VoiceAgentSession session = new(webSocket);
        List<VoiceAgentSessionMessage> messages = new();

        await foreach (VoiceAgentSessionMessage message in session.ReceiveUpdatesAsync())
        {
            messages.Add(message);
        }

        Assert.That(messages, Has.Count.EqualTo(1));
        Assert.That(messages[0].MessageType, Is.EqualTo(WebSocketMessageType.Text));
        Assert.That(messages[0].Data.ToString(), Is.EqualTo("hello"));
    }

    [Test]
    public async Task SendsTextAndBinaryFrames()
    {
        TestWebSocket webSocket = new();
        await using VoiceAgentSession session = new(webSocket);

        await session.SendCommandAsync(BinaryData.FromString("{\"type\":\"response.create\"}"));
        await session.SendBinaryAsync(BinaryData.FromBytes(new byte[] { 1, 2, 3 }));

        Assert.That(webSocket.SentFrames, Has.Count.EqualTo(2));
        Assert.That(webSocket.SentFrames[0].MessageType, Is.EqualTo(WebSocketMessageType.Text));
        Assert.That(Encoding.UTF8.GetString(webSocket.SentFrames[0].Data), Is.EqualTo("{\"type\":\"response.create\"}"));
        Assert.That(webSocket.SentFrames[1].MessageType, Is.EqualTo(WebSocketMessageType.Binary));
        Assert.That(webSocket.SentFrames[1].Data, Is.EqualTo(new byte[] { 1, 2, 3 }));
    }

    private sealed class TestWebSocket : WebSocket
    {
        private readonly Queue<Frame> _receivedFrames;
        private WebSocketCloseStatus? _closeStatus;
        private string _closeStatusDescription;
        private WebSocketState _state = WebSocketState.Open;

        internal TestWebSocket(params Frame[] receivedFrames)
        {
            _receivedFrames = new Queue<Frame>(receivedFrames);
        }

        internal List<SentFrame> SentFrames { get; } = new();

        public override WebSocketCloseStatus? CloseStatus => _closeStatus;
        public override string CloseStatusDescription => _closeStatusDescription;
        public override WebSocketState State => _state;
        public override string SubProtocol => "realtime";

        public override void Abort() => _state = WebSocketState.Aborted;

        public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            _closeStatus = closeStatus;
            _closeStatusDescription = statusDescription;
            _state = WebSocketState.Closed;
            return Task.CompletedTask;
        }

        public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
            => CloseAsync(closeStatus, statusDescription, cancellationToken);

        public override void Dispose() => _state = WebSocketState.Closed;

        public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            Frame frame = _receivedFrames.Dequeue();
            if (frame.MessageType == WebSocketMessageType.Close)
            {
                _state = WebSocketState.CloseReceived;
                return Task.FromResult(new WebSocketReceiveResult(0, WebSocketMessageType.Close, true));
            }

            Array.Copy(frame.Data, 0, buffer.Array, buffer.Offset, frame.Data.Length);
            return Task.FromResult(new WebSocketReceiveResult(frame.Data.Length, frame.MessageType, frame.EndOfMessage));
        }

        public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            byte[] data = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, data, 0, buffer.Count);
            SentFrames.Add(new SentFrame(messageType, data));
            return Task.CompletedTask;
        }

        internal sealed class Frame
        {
            internal Frame(string data, WebSocketMessageType messageType, bool endOfMessage)
                : this(Encoding.UTF8.GetBytes(data), messageType, endOfMessage)
            {
            }

            private Frame(byte[] data, WebSocketMessageType messageType, bool endOfMessage)
            {
                Data = data;
                MessageType = messageType;
                EndOfMessage = endOfMessage;
            }

            internal byte[] Data { get; }
            internal WebSocketMessageType MessageType { get; }
            internal bool EndOfMessage { get; }

            internal static Frame Close() => new(Array.Empty<byte>(), WebSocketMessageType.Close, true);
        }

        internal sealed class SentFrame
        {
            internal SentFrame(WebSocketMessageType messageType, byte[] data)
            {
                MessageType = messageType;
                Data = data;
            }

            internal WebSocketMessageType MessageType { get; }
            internal byte[] Data { get; }
        }
    }
}