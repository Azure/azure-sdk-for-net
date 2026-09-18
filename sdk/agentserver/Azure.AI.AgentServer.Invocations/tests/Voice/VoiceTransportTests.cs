// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceTransportTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(2);

    [Test]
    public void MockSessionHasUsableInvocationContext()
    {
        var session = new MockVoiceSession();

        Assert.Multiple(() =>
        {
            Assert.That(session.InvocationContext, Is.Not.Null);
            Assert.That(session.InvocationContext.InvocationId, Is.EqualTo("invocation_mock"));
            Assert.That(session.InvocationContext.SessionId, Is.EqualTo("session_mock"));
            Assert.That(session.InvocationContext.PlatformContext, Is.SameAs(PlatformContext.Empty));
        });
    }

    [Test]
    public async Task ProtocolFailureClosesSessionBeforeCleanupAndPreservesCode()
    {
        using var webSocket = new ScriptedWebSocket(
            new ReceiveFrame(Encoding.UTF8.GetBytes("{"), WebSocketMessageType.Text, EndOfMessage: true));
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var handler = new CleanupCapturingHandler();

        var outcome = await RunHandlerAsync(handler, connection);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1002));
            Assert.That(handler.CleanupCount, Is.EqualTo(1));
            Assert.That(webSocket.CloseCount, Is.Zero);
        });
        Assert.That(
            async () => await handler.LateSend!,
            Throws.TypeOf<InvalidOperationException>());

        webSocket.ApplicationWasNotified = () => handler.CleanupCount == 1;
        var closeException = await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(closeException, Is.Null);
            Assert.That(webSocket.CloseCount, Is.EqualTo(1));
            Assert.That((int?)webSocket.SentCloseStatus, Is.EqualTo(1002));
            Assert.That(webSocket.ApplicationWasNotifiedAtClose, Is.True);
        });
    }

    [Test]
    public async Task PeerCloseCodeSurvivesCleanupFailure()
    {
        using var webSocket = new ScriptedWebSocket(
            ReceiveFrame.Close(WebSocketCloseStatus.EndpointUnavailable, "service-shutdown"));
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var handler = new ThrowingCleanupHandler();

        var outcome = await RunHandlerAsync(handler, connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1001));
            Assert.That(outcome.Reason, Is.EqualTo("service-shutdown"));
            Assert.That(outcome.CleanupException, Is.TypeOf<InvalidOperationException>());
            Assert.That((int?)webSocket.SentCloseStatus, Is.EqualTo(1001));
            Assert.That(webSocket.SentCloseReason, Is.EqualTo("service-shutdown"));
        });
    }

    [Test]
    public async Task RequestCancellationMapsTo1006()
    {
        using var webSocket = new ScriptedWebSocket(SessionStartFrame());
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var handler = new RequestCancellationHandler();
        using var requestCancellation = new CancellationTokenSource();
        var run = RunHandlerAsync(handler, connection, requestCancellation.Token);
        await handler.Started.Task.WaitAsync(TestTimeout);

        await requestCancellation.CancelAsync();
        var outcome = await run.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1006));
            Assert.That(outcome.Exception, Is.Null);
            Assert.That(handler.CleanupCount, Is.EqualTo(1));
        });
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);
    }

    [Test]
    public async Task IndependentCallbackCancellationDuringRequestAbortMapsTo1011()
    {
        using var webSocket = new ScriptedWebSocket(SessionStartFrame());
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var handler = new IndependentCancellationHandler();
        using var requestCancellation = new CancellationTokenSource();
        var run = RunHandlerAsync(handler, connection, requestCancellation.Token);
        await handler.Started.Task.WaitAsync(TestTimeout);

        await requestCancellation.CancelAsync();
        handler.Release.TrySetResult();
        var outcome = await run.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1011));
            Assert.That(outcome.Exception, Is.TypeOf<OperationCanceledException>());
            Assert.That(handler.CleanupCount, Is.EqualTo(1));
        });
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);
    }

    [Test]
    public async Task CallbackFailureMapsTo1011AndStillRunsCleanup()
    {
        using var webSocket = new ScriptedWebSocket(SessionStartFrame());
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var handler = new ThrowingCallbackHandler();

        var outcome = await RunHandlerAsync(handler, connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1011));
            Assert.That(outcome.Exception, Is.TypeOf<InvalidOperationException>());
            Assert.That(handler.CleanupCount, Is.EqualTo(1));
            Assert.That((int?)webSocket.SentCloseStatus, Is.EqualTo(1011));
        });
    }

    [TestCase("websocket")]
    [TestCase("io")]
    [TestCase("disposed")]
    public async Task CallbackTransportShapedFailureMapsTo1011(string exceptionKind)
    {
        using var webSocket = new ScriptedWebSocket(SessionStartFrame());
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var handler = new TransportShapedCallbackFailureHandler(exceptionKind);

        var outcome = await RunHandlerAsync(handler, connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1011));
            Assert.That(outcome.Exception, Is.Not.Null);
            Assert.That((int?)webSocket.SentCloseStatus, Is.EqualTo(1011));
        });
    }

    [TestCase("websocket")]
    [TestCase("io")]
    [TestCase("disposed")]
    [TestCase("operation-canceled")]
    public async Task ConnectionSendFailureMapsTo1006(string exceptionKind)
    {
        var sendException = CreateTransportShapedException(exceptionKind, "transport send failed");
        using var webSocket = new ScriptedWebSocket(SessionStartFrame())
        {
            SendException = sendException,
        };
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));

        var outcome = await RunHandlerAsync(new ReadySendingHandler(), connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1006));
            Assert.That(outcome.Exception, Is.SameAs(sendException));
            Assert.That(webSocket.SentCloseStatus, Is.Null);
        });
    }

    [Test]
    public async Task ConnectionSendFailurePreservesOriginalExceptionForCallback()
    {
        var sendException = new WebSocketException("transport send failed");
        using var webSocket = new ScriptedWebSocket(
            SessionStartFrame(),
            ReceiveFrame.Close(WebSocketCloseStatus.NormalClosure, "done"))
        {
            SendException = sendException,
        };
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var handler = new SendFailureCatchingHandler();

        var outcome = await RunHandlerAsync(handler, connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(handler.CaughtException, Is.SameAs(sendException));
            Assert.That(outcome.Code, Is.EqualTo(1000));
        });
    }

    [Test]
    public async Task FragmentedTextMessageDispatchesExactlyOnce()
    {
        var payload = SessionStartFrame().Payload;
        var split = payload.Length / 2;
        using var webSocket = new ScriptedWebSocket(
            new ReceiveFrame(payload[..split], WebSocketMessageType.Text, EndOfMessage: false),
            new ReceiveFrame(payload[split..], WebSocketMessageType.Text, EndOfMessage: true),
            ReceiveFrame.Close(WebSocketCloseStatus.NormalClosure, "done"));
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var handler = new StartCountingHandler();

        var outcome = await RunHandlerAsync(handler, connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(handler.StartCount, Is.EqualTo(1));
            Assert.That(handler.CleanupCount, Is.EqualTo(1));
            Assert.That(outcome.Code, Is.EqualTo(1000));
        });
    }

    [TestCase(WebSocketMessageType.Binary, 1003)]
    [TestCase(WebSocketMessageType.Text, 1007)]
    public async Task InvalidFrameTypeOrUtf8UsesProtocolClose(
        WebSocketMessageType messageType,
        int expectedCode)
    {
        var payload = messageType == WebSocketMessageType.Binary
            ? new byte[] { 1, 2, 3 }
            : new byte[] { 0xC3, 0x28 };
        using var webSocket = new ScriptedWebSocket(
            new ReceiveFrame(payload, messageType, EndOfMessage: true));
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));

        var outcome = await RunHandlerAsync(new CleanupCapturingHandler(), connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(expectedCode));
            Assert.That((int?)webSocket.SentCloseStatus, Is.EqualTo(expectedCode));
        });
    }

    [Test]
    public async Task FragmentedMessageOverOneMiBUses1009()
    {
        using var webSocket = new ScriptedWebSocket(
            new ReceiveFrame(
                Enumerable.Repeat((byte)' ', VoiceProtocolCodec.MaxFrameBytes).ToArray(),
                WebSocketMessageType.Text,
                EndOfMessage: false),
            new ReceiveFrame(new byte[] { (byte)' ' }, WebSocketMessageType.Text, EndOfMessage: true));
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));

        var outcome = await RunHandlerAsync(new CleanupCapturingHandler(), connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.That(outcome.Code, Is.EqualTo(1009));
    }

    [Test]
    public async Task ExactlyOneMiBWithEmptyFinalContinuationIsAccepted()
    {
        const string prefix = "{\"type\":\"future.message\",\"id\":\"m_1\",\"ts\":\"2026-08-13T00:00:00.000Z\",\"padding\":\"";
        const string suffix = "\"}";
        var paddingLength = VoiceProtocolCodec.MaxFrameBytes - Encoding.UTF8.GetByteCount(prefix + suffix);
        var payload = Encoding.UTF8.GetBytes(prefix + new string('x', paddingLength) + suffix);
        using var webSocket = new ScriptedWebSocket(
            new ReceiveFrame(payload, WebSocketMessageType.Text, EndOfMessage: false),
            new ReceiveFrame(Array.Empty<byte>(), WebSocketMessageType.Text, EndOfMessage: false),
            new ReceiveFrame(Array.Empty<byte>(), WebSocketMessageType.Text, EndOfMessage: true),
            ReceiveFrame.Close(WebSocketCloseStatus.NormalClosure, "done"));
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));

        var outcome = await RunHandlerAsync(new CleanupCapturingHandler(), connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(payload, Has.Length.EqualTo(VoiceProtocolCodec.MaxFrameBytes));
            Assert.That(outcome.Code, Is.EqualTo(1000));
        });
    }

    [Test]
    public async Task PeerCloseAfterExactLimitFragmentPreservesPeerOutcome()
    {
        var payload = Enumerable.Repeat((byte)' ', VoiceProtocolCodec.MaxFrameBytes).ToArray();
        using var webSocket = new ScriptedWebSocket(
            new ReceiveFrame(payload, WebSocketMessageType.Text, EndOfMessage: false),
            ReceiveFrame.Close(WebSocketCloseStatus.EndpointUnavailable, "service-shutdown"));
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));

        var outcome = await RunHandlerAsync(new CleanupCapturingHandler(), connection);
        await connection.CloseAsync(outcome.Status, outcome.Reason).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.Code, Is.EqualTo(1001));
            Assert.That(outcome.Reason, Is.EqualTo("service-shutdown"));
            Assert.That((int?)webSocket.SentCloseStatus, Is.EqualTo(1001));
        });
    }

    [Test]
    public async Task ConcurrentSessionSendsAreSerialized()
    {
        using var webSocket = new BlockingSendWebSocket();
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromSeconds(1));
        var session = new VoiceSession(connection, CreateContext());

        var first = session.SendAsync(new VoiceSessionReadyMessage(id: "m_first"));
        await webSocket.SendStarted.Task.WaitAsync(TestTimeout);
        var second = session.SendAsync(new VoiceSessionReadyMessage(id: "m_second"));
        Assert.That(webSocket.SendCount, Is.EqualTo(1));

        webSocket.ReleaseSend.TrySetResult();
        await Task.WhenAll(first, second).WaitAsync(TestTimeout);
        await connection.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(webSocket.SendCount, Is.EqualTo(2));
            Assert.That(webSocket.MaximumConcurrentWrites, Is.EqualTo(1));
            Assert.That(webSocket.SentMessageIds, Is.EqualTo(new[] { "m_first", "m_second" }));
        });
    }

    [Test]
    public async Task BlockedSendCannotOverlapCloseAndCloseWaitIsBounded()
    {
        using var webSocket = new BlockingSendWebSocket();
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromMilliseconds(50));
        var session = new VoiceSession(connection, CreateContext());
        var send = session.SendAsync(new VoiceSessionReadyMessage());
        await webSocket.SendStarted.Task.WaitAsync(TestTimeout);
        var stopwatch = Stopwatch.StartNew();

        var closeException = await connection.CloseAsync(
            WebSocketCloseStatus.NormalClosure,
            string.Empty).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(stopwatch.Elapsed, Is.LessThan(TimeSpan.FromSeconds(1)));
            Assert.That(closeException, Is.TypeOf<OperationCanceledException>());
            Assert.That(webSocket.CloseCount, Is.Zero);
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(webSocket.MaximumConcurrentWrites, Is.EqualTo(1));
        });
        webSocket.ReleaseSend.TrySetResult();
        await send.WaitAsync(TestTimeout);
    }

    [Test]
    public async Task NonCooperativeCloseIsAbortedAtAbsoluteDeadline()
    {
        using var webSocket = new NonCooperativeCloseWebSocket();
        var connection = new InvocationsWebSocketConnection(webSocket, TimeSpan.FromMilliseconds(50));
        var stopwatch = Stopwatch.StartNew();

        await connection.CloseAsync(
            WebSocketCloseStatus.NormalClosure,
            string.Empty).WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(stopwatch.Elapsed, Is.LessThan(TimeSpan.FromSeconds(1)));
            Assert.That(webSocket.CloseStarted.Task.IsCompleted, Is.True);
            Assert.That(webSocket.AbortCount, Is.EqualTo(1));
            Assert.That(webSocket.DisposeCount, Is.EqualTo(1));
        });
        webSocket.ReleaseClose.TrySetResult();
    }

    private static Task<InvocationsWebSocketCloseResult> RunHandlerAsync(
        VoiceHandler handler,
        InvocationsWebSocketConnection connection,
        CancellationToken cancellationToken = default) =>
        handler.HandleWebSocketConnectionAsync(
            connection,
            CreateContext(),
            cancellationToken);

    private static InvocationContext CreateContext() => new(
        "inv_test",
        "session_test",
        new Dictionary<string, string>(),
        new Dictionary<string, StringValues>(),
        PlatformContext.Empty);

    private static Exception CreateTransportShapedException(string exceptionKind, string message) =>
        exceptionKind switch
        {
            "websocket" => new WebSocketException(message),
            "io" => new IOException(message),
            "disposed" => new ObjectDisposedException(message),
            _ => new OperationCanceledException(message),
        };

    private static ReceiveFrame SessionStartFrame() => new(
        Encoding.UTF8.GetBytes("""
            {"type":"session.start","id":"m_1","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}
            """),
        WebSocketMessageType.Text,
        EndOfMessage: true);

    private class CleanupCapturingHandler : VoiceHandler
    {
        public int CleanupCount { get; private set; }

        public Task? LateSend { get; private set; }

        protected override void OnConnectionTerminating(VoiceSession session)
        {
            CleanupCount++;
            LateSend = session.SendAsync(new VoiceSessionReadyMessage());
        }
    }

    private sealed class ThrowingCleanupHandler : VoiceHandler
    {
        protected override void OnConnectionTerminating(VoiceSession session) =>
            throw new InvalidOperationException("cleanup failed");
    }

    private sealed class ThrowingCallbackHandler : VoiceHandler
    {
        public int CleanupCount { get; private set; }

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken) =>
            throw new InvalidOperationException("callback failed");

        protected override void OnConnectionTerminating(VoiceSession session) => CleanupCount++;
    }

    private sealed class StartCountingHandler : VoiceHandler
    {
        public int StartCount { get; private set; }

        public int CleanupCount { get; private set; }

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            StartCount++;
            return Task.CompletedTask;
        }

        protected override void OnConnectionTerminating(VoiceSession session) => CleanupCount++;
    }

    private sealed class TransportShapedCallbackFailureHandler : VoiceHandler
    {
        private readonly string _exceptionKind;

        public TransportShapedCallbackFailureHandler(string exceptionKind) =>
            _exceptionKind = exceptionKind;

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken) =>
            throw CreateTransportShapedException(_exceptionKind, "application callback failure");
    }

    private sealed class ReadySendingHandler : VoiceHandler
    {
        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken) =>
            session.SendAsync(new VoiceSessionReadyMessage(), cancellationToken);
    }

    private sealed class SendFailureCatchingHandler : VoiceHandler
    {
        public WebSocketException? CaughtException { get; private set; }

        protected override async Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            try
            {
                await session.SendAsync(new VoiceSessionReadyMessage(), cancellationToken);
            }
            catch (WebSocketException exception)
            {
                CaughtException = exception;
            }
        }
    }

    private sealed class MockVoiceSession : VoiceSession;

    private sealed class RequestCancellationHandler : VoiceHandler
    {
        public TaskCompletionSource Started { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int CleanupCount { get; private set; }

        protected override async Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            Started.TrySetResult();
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }

        protected override void OnConnectionTerminating(VoiceSession session) => CleanupCount++;
    }

    private sealed class IndependentCancellationHandler : VoiceHandler
    {
        private readonly CancellationTokenSource _callbackCancellation = new();

        public TaskCompletionSource Started { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource Release { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int CleanupCount { get; private set; }

        protected override async Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            Started.TrySetResult();
            await Release.Task;
            await _callbackCancellation.CancelAsync();
            throw new OperationCanceledException(_callbackCancellation.Token);
        }

        protected override void OnConnectionTerminating(VoiceSession session) => CleanupCount++;
    }

    private readonly record struct ReceiveFrame(
        byte[] Payload,
        WebSocketMessageType MessageType,
        bool EndOfMessage,
        WebSocketCloseStatus? CloseStatus = null,
        string? CloseReason = null)
    {
        public static ReceiveFrame Close(WebSocketCloseStatus status, string? reason) =>
            new(Array.Empty<byte>(), WebSocketMessageType.Close, EndOfMessage: true, status, reason);
    }

    private sealed class ScriptedWebSocket : WebSocket
    {
        private readonly Queue<ReceiveFrame> _frames;
        private WebSocketState _state = WebSocketState.Open;
        private WebSocketCloseStatus? _closeStatus;
        private string? _closeReason;
        private int _frameOffset;

        public ScriptedWebSocket(params ReceiveFrame[] frames) => _frames = new Queue<ReceiveFrame>(frames);

        public Func<bool>? ApplicationWasNotified { get; set; }

        public bool ApplicationWasNotifiedAtClose { get; private set; }

        public Exception? SendException { get; init; }

        public int CloseCount { get; private set; }

        public WebSocketCloseStatus? SentCloseStatus { get; private set; }

        public string? SentCloseReason { get; private set; }

        public override WebSocketCloseStatus? CloseStatus => _closeStatus;

        public override string? CloseStatusDescription => _closeReason;

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
            CloseCount++;
            SentCloseStatus = closeStatus;
            SentCloseReason = statusDescription;
            ApplicationWasNotifiedAtClose = ApplicationWasNotified?.Invoke() == true;
            _state = WebSocketState.CloseSent;
            return Task.CompletedTask;
        }

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            var frame = _frames.Peek();
            var count = Math.Min(buffer.Count, frame.Payload.Length - _frameOffset);
            frame.Payload.AsSpan(_frameOffset, count).CopyTo(buffer.AsSpan());
            _frameOffset += count;
            var frameCompleted = _frameOffset == frame.Payload.Length;
            if (frame.MessageType == WebSocketMessageType.Close)
            {
                _closeStatus = frame.CloseStatus;
                _closeReason = frame.CloseReason;
                _state = WebSocketState.CloseReceived;
            }
            if (frameCompleted)
            {
                _frames.Dequeue();
                _frameOffset = 0;
            }
            return Task.FromResult(new WebSocketReceiveResult(
                count,
                frame.MessageType,
                frameCompleted && frame.EndOfMessage,
                frame.CloseStatus,
                frame.CloseReason));
        }

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) =>
            SendException is null ? Task.CompletedTask : Task.FromException(SendException);

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

        public int SendCount { get; private set; }

        public List<string> SentMessageIds { get; } = new();

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
            EnterWrite();
            ExitWrite();
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
            EnterWrite();
            SendCount++;
            using (var payload = JsonDocument.Parse(buffer.AsMemory()))
            {
                SentMessageIds.Add(payload.RootElement.GetProperty("id").GetString()!);
            }
            SendStarted.TrySetResult();
            try
            {
                await ReleaseSend.Task;
            }
            finally
            {
                ExitWrite();
            }
        }

        public override void Dispose() => _state = WebSocketState.Closed;

        private void EnterWrite()
        {
            var active = Interlocked.Increment(ref _activeWrites);
            MaximumConcurrentWrites = Math.Max(MaximumConcurrentWrites, active);
        }

        private void ExitWrite() => Interlocked.Decrement(ref _activeWrites);
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
}
