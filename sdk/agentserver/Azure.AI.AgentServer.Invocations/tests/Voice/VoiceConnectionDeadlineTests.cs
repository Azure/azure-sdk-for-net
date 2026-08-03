// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceConnectionDeadlineTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(2);

    [TestCase("end_call")]
    [TestCase("error")]
    public async Task AgentTerminalAbortsCarrierWhenBridgeDoesNotClose(string terminalKind)
    {
        using var innerSocket = new BlockingReceiveWebSocket(terminalKind);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(50));
        var connection = new VoiceConnection(
            webSocket,
            new AgentTerminalHandler(terminalKind),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.TerminalSent.Task.WaitAsync(TestTimeout);

        await runTask.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
            Assert.That(innerSocket.State, Is.EqualTo(WebSocketState.Aborted));
        });
    }

    [Test]
    public async Task SessionEndAfterAgentTerminalStillInvokesTerminalCallback()
    {
        using var innerSocket = new BlockingReceiveWebSocket("end_call");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new AgentTerminalHandler("end_call");
        var connection = new VoiceConnection(webSocket, handler, CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await innerSocket.TerminalSent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:02.000Z",
            reason = "agent_completed",
        }));

        var sessionEnd = await handler.SessionEnded.Task.WaitAsync(TestTimeout);
        await runTask.WaitAsync(TestTimeout);

        Assert.That(sessionEnd.Reason, Is.EqualTo("agent_completed"));
    }

    private static string SessionStartFrame() => JsonSerializer.Serialize(new
    {
        type = "session.start",
        id = "m_start",
        ts = "2026-08-03T00:00:00.000Z",
        protocol_version = "1.0",
        reconnect = false,
        response_timeouts = new
        {
            first_output_ms = 5000,
            idle_ms = 8000,
            max_duration_ms = 60000,
        },
    });

    private static string UserMessageFrame() => JsonSerializer.Serialize(new
    {
        type = "user.message",
        id = "m_user",
        ts = "2026-08-03T00:00:01.000Z",
        item_id = "in_user",
        content = new[] { new { type = "input_text", text = "terminal" } },
    });

    private sealed class AgentTerminalHandler : VoiceHandler
    {
        private readonly string _terminalKind;

        public AgentTerminalHandler(string terminalKind)
        {
            _terminalKind = terminalKind;
        }

        public TaskCompletionSource<SessionEndEvent> SessionEnded { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) =>
            _terminalKind == "end_call"
                ? session.EndCallAsync("test_complete", cancellationToken: cancellationToken)
                : session.ReportErrorAsync("test_error", "Safe test error", cancellationToken);

        protected override Task OnSessionEndAsync(
            VoiceSession session,
            SessionEndEvent sessionEnd,
            CancellationToken cancellationToken)
        {
            SessionEnded.TrySetResult(sessionEnd);
            return Task.CompletedTask;
        }
    }

    private sealed class BlockingReceiveWebSocket : WebSocket
    {
        private readonly Channel<byte[]> _inbound = Channel.CreateUnbounded<byte[]>();
        private readonly string _terminalKind;
        private WebSocketState _state = WebSocketState.Open;
        private int _abortCount;

        public BlockingReceiveWebSocket(string terminalKind)
        {
            _terminalKind = terminalKind;
        }

        public TaskCompletionSource ReadySent { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TerminalSent { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int AbortCount => Volatile.Read(ref _abortCount);

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public void QueueFrame(string frame) =>
            _inbound.Writer.TryWrite(Encoding.UTF8.GetBytes(frame));

        public override void Abort()
        {
            Interlocked.Increment(ref _abortCount);
            _state = WebSocketState.Aborted;
            _inbound.Writer.TryComplete();
        }

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            _state = WebSocketState.Closed;
            return Task.CompletedTask;
        }

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            _state = WebSocketState.CloseSent;
            return Task.CompletedTask;
        }

        public override async Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            var frame = await _inbound.Reader.ReadAsync(cancellationToken);
            frame.AsSpan().CopyTo(buffer.AsSpan());
            return new WebSocketReceiveResult(
                frame.Length,
                WebSocketMessageType.Text,
                endOfMessage: true);
        }

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken)
        {
            using var payload = JsonDocument.Parse(buffer);
            var messageTypeName = payload.RootElement.GetProperty("type").GetString();
            if (messageTypeName == "session.ready")
            {
                ReadySent.TrySetResult();
            }
            else if (messageTypeName == _terminalKind)
            {
                TerminalSent.TrySetResult();
            }

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _state = WebSocketState.Closed;
            _inbound.Writer.TryComplete();
        }
    }
}
