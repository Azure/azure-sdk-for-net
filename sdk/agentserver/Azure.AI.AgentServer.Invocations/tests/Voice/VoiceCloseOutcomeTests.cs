// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceCloseOutcomeTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(2);

    [Test]
    public async Task CallbackFailureStopsBeforeLaterFrame()
    {
        using var webSocket = new ScriptedCloseWebSocket(SessionStartFrame(), SessionStartFrame());
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var handler = new ThrowingCallbackHandler();

        var outcome = await handler.HandleWebSocketConnectionAsync(
            connection,
            CreateContext(),
            CancellationToken.None);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1011));
            Assert.That(outcome.Exception, Is.SameAs(handler.Failure));
            Assert.That(handler.CleanupCount, Is.EqualTo(1));
            Assert.That(webSocket.RemainingFrameCount, Is.EqualTo(1));
            Assert.That((int?)webSocket.SentCloseStatus, Is.EqualTo(1011));
        });
    }

    [Test]
    public async Task CloseFailureIsSecondaryToCommittedProtocolOutcome()
    {
        var closeException = new WebSocketException("close failed");
        using var webSocket = new ScriptedCloseWebSocket(MalformedFrame())
        {
            CloseException = closeException,
        };
        var handler = new ThrowingCleanupHandler();

        var nullableOutcome = await handler.HandleWebSocketWithOutcomeAsync(
            webSocket,
            CreateContext(),
            CancellationToken.None);

        Assert.That(nullableOutcome.HasValue, Is.True);
        var outcome = nullableOutcome.GetValueOrDefault();
        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1002));
            Assert.That(outcome.Exception, Is.TypeOf<VoiceProtocolException>());
            Assert.That(outcome.CleanupException, Is.SameAs(handler.Failure));
            Assert.That(outcome.CloseException, Is.SameAs(closeException));
        });
    }

    [Test]
    public async Task BlockedSendGateCancellationRemainsOperationCanceled()
    {
        using var webSocket = new BlockingSendWebSocket();
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromMilliseconds(50));
        var session = new VoiceSession(connection, CreateContext());
        var send = session.SendAsync(new VoiceSessionReadyMessage());
        await webSocket.SendStarted.Task.WaitAsync(TestTimeout);
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var closeException = await connection.CloseAsync(
                WebSocketCloseStatus.NormalClosure,
                string.Empty).WaitAsync(TestTimeout);

            Assert.Multiple(() =>
            {
                Assert.That(closeException, Is.TypeOf<OperationCanceledException>());
                Assert.That(stopwatch.Elapsed, Is.LessThan(TimeSpan.FromSeconds(1)));
                Assert.That(webSocket.CloseCount, Is.Zero);
                Assert.That(webSocket.AbortCount, Is.EqualTo(1));
                Assert.That(webSocket.MaximumConcurrentWrites, Is.EqualTo(1));
            });
        }
        finally
        {
            webSocket.ReleaseSend.TrySetResult();
            await send.WaitAsync(TestTimeout);
        }
    }

    [Test]
    public async Task NonCooperativeCloseDeadlineReportsTimeout()
    {
        using var webSocket = new NonCooperativeCloseWebSocket();
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromMilliseconds(50));
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var closeException = await connection.CloseAsync(
                WebSocketCloseStatus.NormalClosure,
                string.Empty).WaitAsync(TestTimeout);

            Assert.Multiple(() =>
            {
                Assert.That(closeException, Is.TypeOf<TimeoutException>());
                Assert.That(stopwatch.Elapsed, Is.LessThan(TimeSpan.FromSeconds(1)));
                Assert.That(webSocket.CloseStarted.Task.IsCompleted, Is.True);
                Assert.That(webSocket.AbortCount, Is.EqualTo(1));
                Assert.That(webSocket.DisposeCount, Is.EqualTo(1));
            });
        }
        finally
        {
            webSocket.ReleaseClose.TrySetResult();
        }
    }

    [Test]
    public async Task CooperativeCloseDeadlineReportsSameTimeout()
    {
        using var webSocket = new CooperativeCloseWebSocket();
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromMilliseconds(50));

        var closeException = await connection.CloseAsync(
            WebSocketCloseStatus.NormalClosure,
            string.Empty).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(closeException, Is.TypeOf<TimeoutException>());
            Assert.That(webSocket.CloseStarted.Task.IsCompleted, Is.True);
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(webSocket.DisposeCount, Is.EqualTo(1));
        });
    }

    private static InvocationContext CreateContext() => new(
        "inv_test",
        "session_test",
        new Dictionary<string, string>(),
        new Dictionary<string, StringValues>(),
        PlatformContext.Empty);

    private static ReceiveFrame SessionStartFrame() => new(
        Encoding.UTF8.GetBytes("""
            {"type":"session.start","id":"m_1","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}
            """),
        WebSocketMessageType.Text,
        EndOfMessage: true);

    private static ReceiveFrame MalformedFrame() => new(
        Encoding.UTF8.GetBytes("{"),
        WebSocketMessageType.Text,
        EndOfMessage: true);

    private sealed class ThrowingCallbackHandler : VoiceHandler
    {
        public InvalidOperationException Failure { get; } = new("callback failed");

        public int CleanupCount { get; private set; }

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken) => throw Failure;

        protected override void OnConnectionTerminating(VoiceSession session) => CleanupCount++;
    }

    private sealed class ThrowingCleanupHandler : VoiceHandler
    {
        public InvalidOperationException Failure { get; } = new("cleanup failed");

        protected override void OnConnectionTerminating(VoiceSession session) => throw Failure;
    }

    private readonly record struct ReceiveFrame(
        byte[] Payload,
        WebSocketMessageType MessageType,
        bool EndOfMessage);

    private sealed class ScriptedCloseWebSocket : WebSocket
    {
        private readonly Queue<ReceiveFrame> _frames;
        private WebSocketState _state = WebSocketState.Open;

        public ScriptedCloseWebSocket(params ReceiveFrame[] frames) =>
            _frames = new Queue<ReceiveFrame>(frames);

        public Exception? CloseException { get; init; }

        public int RemainingFrameCount => _frames.Count;

        public WebSocketCloseStatus? SentCloseStatus { get; private set; }

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public override void Abort() => _state = WebSocketState.Aborted;

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) =>
            CloseOutputAsync(closeStatus, statusDescription, cancellationToken);

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            SentCloseStatus = closeStatus;
            if (CloseException is not null)
            {
                return Task.FromException(CloseException);
            }
            _state = WebSocketState.CloseSent;
            return Task.CompletedTask;
        }

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            var frame = _frames.Dequeue();
            frame.Payload.AsSpan().CopyTo(buffer.AsSpan());
            return Task.FromResult(new WebSocketReceiveResult(
                frame.Payload.Length,
                frame.MessageType,
                frame.EndOfMessage));
        }

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) => Task.CompletedTask;

        public override void Dispose() => _state = WebSocketState.Closed;
    }

    private sealed class BlockingSendWebSocket : WebSocket
    {
        private WebSocketState _state = WebSocketState.Open;
        private int _activeWrites;

        public TaskCompletionSource SendStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseSend { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int AbortCount { get; private set; }

        public int CloseCount { get; private set; }

        public int MaximumConcurrentWrites { get; private set; }

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public override void Abort()
        {
            AbortCount++;
            _state = WebSocketState.Aborted;
        }

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) =>
            CloseOutputAsync(closeStatus, statusDescription, cancellationToken);

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            CloseCount++;
            return Task.CompletedTask;
        }

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override async Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken)
        {
            var activeWrites = Interlocked.Increment(ref _activeWrites);
            MaximumConcurrentWrites = Math.Max(MaximumConcurrentWrites, activeWrites);
            SendStarted.TrySetResult();
            try
            {
                await ReleaseSend.Task;
            }
            finally
            {
                Interlocked.Decrement(ref _activeWrites);
            }
        }

        public override void Dispose() => _state = WebSocketState.Closed;
    }

    private sealed class NonCooperativeCloseWebSocket : WebSocket
    {
        public TaskCompletionSource CloseStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseClose { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int AbortCount { get; private set; }

        public int DisposeCount { get; private set; }

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => WebSocketState.Open;

        public override string? SubProtocol => null;

        public override void Abort() => AbortCount++;

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) =>
            CloseOutputAsync(closeStatus, statusDescription, cancellationToken);

        public override async Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            CloseStarted.TrySetResult();
            await ReleaseClose.Task;
        }

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override void Dispose() => DisposeCount++;
    }

    private sealed class CooperativeCloseWebSocket : WebSocket
    {
        public TaskCompletionSource CloseStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int AbortCount { get; private set; }

        public int DisposeCount { get; private set; }

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => WebSocketState.Open;

        public override string? SubProtocol => null;

        public override void Abort() => AbortCount++;

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) =>
            CloseOutputAsync(closeStatus, statusDescription, cancellationToken);

        public override async Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            CloseStarted.TrySetResult();
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override void Dispose() => DisposeCount++;
    }
}
