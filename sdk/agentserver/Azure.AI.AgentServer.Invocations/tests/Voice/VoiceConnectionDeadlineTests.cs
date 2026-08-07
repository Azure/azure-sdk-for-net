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
            CreateInvocationContext(),
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
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

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

    [Test]
    public async Task BlockingStartupCancellationRegistrationDoesNotStallTeardown()
    {
        using var innerSocket = new BlockingReceiveWebSocket("session.rejected");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(50));
        var handler = new BlockingStartupCancellationHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await handler.StartupStarted.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        await handler.CancellationStarted.Task.WaitAsync(TestTimeout);

        try
        {
            await runTask.WaitAsync(TestTimeout);
        }
        finally
        {
            handler.ReleaseCancellation.TrySetResult();
        }
    }

    [Test]
    public async Task FrameArrivingBeforeReadyWriteCompletesIsRejected()
    {
        using var innerSocket = new BlockingReceiveWebSocket("session.ready", injectFrameDuringReady: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new DuringReadyHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();

        await runTask.WaitAsync(TestTimeout);
        Assert.Multiple(() =>
        {
            Assert.That(handler.UserReceived.Task.IsCompleted, Is.False);
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task BlockedSessionRejectionIsAbortedByCleanupDeadline()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "session.rejected",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromMilliseconds(50));
        var connection = new VoiceConnection(
            webSocket,
            new DuringReadyHandler(),
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(UserMessageFrame());
        var runTask = connection.RunAsync();
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);
        await runTask.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
            Assert.That(innerSocket.State, Is.EqualTo(WebSocketState.Aborted));
        });
    }

    [Test]
    public async Task CancelledProactiveAdmissionAcceptedThenTimedOutReleasesAbandonedIdentity()
    {
        using var innerSocket = new BlockingReceiveWebSocket("unused");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new CancelledProactiveHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "user.speech_started",
            id = "m_speech",
            ts = "2026-08-03T00:00:01.000Z",
        }));
        var responseId = await innerSocket.ProactiveResponseCreated.Task.WaitAsync(TestTimeout);

        handler.CancelAdmission();
        await handler.AdmissionCancelled.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "response.accepted",
            id = "m_accepted",
            ts = "2026-08-03T00:00:02.000Z",
            response_id = responseId,
        }));
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "response.timeout",
            id = "m_timeout",
            ts = "2026-08-03T00:00:03.000Z",
            response_id = responseId,
            stage = "first_output",
        }));

        await handler.TimeoutObserved.Task.WaitAsync(TestTimeout);
        Assert.That(await connection.GetAbandonedProactiveCancelCountAsync(), Is.Zero);

        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:04.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);
    }

    [Test]
    public async Task PlaybackOutcomeConsumesTrackedIdentityBudget()
    {
        using var innerSocket = new BlockingReceiveWebSocket("response.done");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new PlaybackOutcomeHandler();
        var connection = new VoiceConnection(webSocket, handler, CreateInvocationContext(), CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        var responseId = await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSent.Task.WaitAsync(TestTimeout);
        var beforeOutcome = connection.TrackedIdentityBytes;

        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "barge_in",
            id = "m_barge",
            ts = "2026-08-03T00:00:02.000Z",
            response_id = responseId,
            heard_text = string.Empty,
        }));
        await handler.BargeInObserved.Task.WaitAsync(TestTimeout);

        Assert.That(
            connection.TrackedIdentityBytes - beforeOutcome,
            Is.EqualTo(384),
            "The inbound message digest and playback outcome identity must both be budgeted.");

        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "session.end",
            id = "m_end",
            ts = "2026-08-03T00:00:03.000Z",
            reason = "caller_hangup",
        }));
        await runTask.WaitAsync(TestTimeout);
    }

    [Test]
    public async Task InvalidUtf8TextFrameIsRejectedAsProtocolError()
    {
        using var innerSocket = new BlockingReceiveWebSocket("unused");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var connection = new VoiceConnection(
            webSocket,
            new DuringReadyHandler(),
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrameBytes(new byte[] { 0xC3, 0x28 });

        await runTask.WaitAsync(TestTimeout);
        Assert.That(webSocket.SelectedCloseCode, Is.EqualTo(VoiceProtocolConstants.CloseProtocolError));
    }

    [Test]
    public async Task RequestCancellationEscapesWithOriginalTokenAndSelectsAbnormalClosure()
    {
        using var requestCancellation = new CancellationTokenSource();
        using var innerSocket = new BlockingReceiveWebSocket("unused");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var connection = new VoiceConnection(
            webSocket,
            new DuringReadyHandler(),
            CreateInvocationContext(),
            requestCancellation.Token);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        await requestCancellation.CancelAsync();

        var exception = Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await runTask.WaitAsync(TestTimeout));
        Assert.Multiple(() =>
        {
            Assert.That(exception!.CancellationToken, Is.EqualTo(requestCancellation.Token));
            Assert.That(webSocket.SelectedCloseCode, Is.EqualTo(1006));
        });
    }

    [Test]
    public async Task BargeInDuringBlockedCancelWriteReturnsAuthoritativeOutcome()
    {
        using var innerSocket = new BlockingReceiveWebSocket(
            "response.cancel",
            blockTerminalSend: true);
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var handler = new CancelRaceHandler();
        var connection = new VoiceConnection(
            webSocket,
            handler,
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(UserMessageFrame());
        var responseId = await innerSocket.ResponseCreated.Task.WaitAsync(TestTimeout);
        await innerSocket.TerminalSendStarted.Task.WaitAsync(TestTimeout);
        innerSocket.QueueFrame(JsonSerializer.Serialize(new
        {
            type = "barge_in",
            id = "m_barge",
            ts = "2026-08-03T00:00:02.000Z",
            response_id = responseId,
            heard_text = string.Empty,
        }));

        var outcome = await handler.Outcome.Task.WaitAsync(TestTimeout);
        Assert.That(outcome.Kind, Is.EqualTo("barge_in"));

        await runTask.WaitAsync(TestTimeout);
        Assert.That(innerSocket.AbortCount, Is.EqualTo(1));
    }

    [Test]
    public async Task UnexpectedRuntimeFailureEscapesAfterSelectingInternalError()
    {
        using var innerSocket = new BlockingReceiveWebSocket("unused");
        using var webSocket = new TrackingWebSocket(innerSocket, TimeSpan.FromSeconds(1));
        var connection = new VoiceConnection(
            webSocket,
            new DuringReadyHandler(),
            CreateInvocationContext(),
            CancellationToken.None);

        innerSocket.QueueFrame(SessionStartFrame());
        var runTask = connection.RunAsync();
        await innerSocket.ReadySent.Task.WaitAsync(TestTimeout);
        innerSocket.QueueReceiveException(new InvalidOperationException("runtime failed"));

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await runTask.WaitAsync(TestTimeout));
        Assert.Multiple(() =>
        {
            Assert.That(exception!.Message, Is.EqualTo("runtime failed"));
            Assert.That(webSocket.SelectedCloseCode, Is.EqualTo(VoiceProtocolConstants.CloseInternalError));
        });
    }

    [Test]
    public async Task CompletedSignalFailureRemainsFailureDuringSessionEndRace()
    {
        var failed = await VoiceConnection.ObserveSignalCallbackAsync(
            Task.FromException(new InvalidOperationException("callback failed")),
            CancellationToken.None);

        Assert.That(failed, Is.True);
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

    private static InvocationContext CreateInvocationContext() => new(
        "test-invocation",
        "test-session",
        new Dictionary<string, string>(),
        new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>(),
        Azure.AI.AgentServer.Core.PlatformContext.Empty);

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

    private sealed class BlockingStartupCancellationHandler : VoiceHandler
    {
        private readonly TaskCompletionSource _startupCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource StartupStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource CancellationStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseCancellation { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            SessionStartEvent startEvent,
            CancellationToken cancellationToken)
        {
            _ = cancellationToken.Register(() =>
            {
                CancellationStarted.TrySetResult();
                ReleaseCancellation.Task.GetAwaiter().GetResult();
                _startupCompletion.TrySetResult();
            });
            StartupStarted.TrySetResult();
            return _startupCompletion.Task;
        }

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class DuringReadyHandler : VoiceHandler
    {
        public TaskCompletionSource UserReceived { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            UserReceived.TrySetResult();
            return response.SendTextAsync("ready", cancellationToken);
        }
    }

    private sealed class CancelledProactiveHandler : VoiceHandler
    {
        private readonly CancellationTokenSource _admissionCancellation = new();

        public TaskCompletionSource AdmissionCancelled { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TimeoutObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public void CancelAdmission() => _admissionCancellation.Cancel();

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => Task.CompletedTask;

        protected override Task OnUserSpeechStartedAsync(
            VoiceSession session,
            UserSpeechStartedEvent speechStarted,
            CancellationToken cancellationToken)
        {
            _ = StartProactiveAsync(session);
            return Task.CompletedTask;
        }

        protected override Task OnResponseTimeoutAsync(
            VoiceSession session,
            ResponseTimeoutEvent timeout,
            CancellationToken cancellationToken)
        {
            TimeoutObserved.TrySetResult();
            return Task.CompletedTask;
        }

        private async Task StartProactiveAsync(VoiceSession session)
        {
            try
            {
                await session.StartProactiveResponseAsync(cancellationToken: _admissionCancellation.Token);
            }
            catch (OperationCanceledException) when (_admissionCancellation.IsCancellationRequested)
            {
                AdmissionCancelled.TrySetResult();
            }
        }
    }

    private sealed class PlaybackOutcomeHandler : VoiceHandler
    {
        public TaskCompletionSource BargeInObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken) => response.SendTextAsync("ready", cancellationToken);

        protected override Task OnBargeInAsync(
            VoiceSession session,
            BargeInEvent bargeIn,
            CancellationToken cancellationToken)
        {
            BargeInObserved.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class CancelRaceHandler : VoiceHandler
    {
        public TaskCompletionSource<ResponseCancellationOutcome> Outcome { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnUserMessageAsync(
            VoiceSession session,
            UserMessageEvent message,
            VoiceResponse response,
            CancellationToken cancellationToken)
        {
            await response.SendTextDeltaAsync("cancel", cancellationToken);
            var outcome = await response.CancelAsync(cancellationToken: CancellationToken.None);
            Outcome.TrySetResult(outcome);
        }
    }

    private sealed class BlockingReceiveWebSocket : WebSocket
    {
        private readonly Channel<byte[]> _inbound = Channel.CreateUnbounded<byte[]>();
        private readonly string _terminalKind;
        private readonly bool _injectFrameDuringReady;
        private readonly bool _blockTerminalSend;
        private readonly TaskCompletionSource _injectedFrameRead =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private WebSocketState _state = WebSocketState.Open;
        private Exception? _receiveException;
        private int _abortCount;
        private int _injectedFrameQueued;

        public BlockingReceiveWebSocket(
            string terminalKind,
            bool injectFrameDuringReady = false,
            bool blockTerminalSend = false)
        {
            _terminalKind = terminalKind;
            _injectFrameDuringReady = injectFrameDuringReady;
            _blockTerminalSend = blockTerminalSend;
        }

        public TaskCompletionSource ReadySent { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TerminalSent { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource TerminalSendStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<string> ProactiveResponseCreated { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<string> ResponseCreated { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int AbortCount => Volatile.Read(ref _abortCount);

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public void QueueFrame(string frame) =>
            _inbound.Writer.TryWrite(Encoding.UTF8.GetBytes(frame));

        public void QueueFrameBytes(byte[] frame) => _inbound.Writer.TryWrite(frame);

        public void QueueReceiveException(Exception exception)
        {
            _receiveException = exception;
            _inbound.Writer.TryWrite(Array.Empty<byte>());
        }

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
            byte[] frame;
            try
            {
                frame = await _inbound.Reader.ReadAsync(cancellationToken);
            }
            catch (ChannelClosedException exception)
            {
                throw new WebSocketException(
                    WebSocketError.ConnectionClosedPrematurely,
                    exception);
            }

            var injectedException = Interlocked.Exchange(ref _receiveException, null);
            if (injectedException is not null)
            {
                throw injectedException;
            }

            frame.AsSpan().CopyTo(buffer.AsSpan());
            if (Volatile.Read(ref _injectedFrameQueued) != 0)
            {
                _injectedFrameRead.TrySetResult();
            }

            return new WebSocketReceiveResult(
                frame.Length,
                WebSocketMessageType.Text,
                endOfMessage: true);
        }

        public override async Task SendAsync(
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
                if (_injectFrameDuringReady)
                {
                    Volatile.Write(ref _injectedFrameQueued, 1);
                    QueueFrame(UserMessageFrame());
                    await _injectedFrameRead.Task.WaitAsync(cancellationToken);
                    await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
                }
            }
            else if (messageTypeName == "response.created" &&
                !payload.RootElement.TryGetProperty("in_reply_to", out _))
            {
                ProactiveResponseCreated.TrySetResult(
                    payload.RootElement.GetProperty("response_id").GetString()!);
            }
            else if (messageTypeName == "response.created")
            {
                ResponseCreated.TrySetResult(
                    payload.RootElement.GetProperty("response_id").GetString()!);
            }
            else if (messageTypeName == _terminalKind)
            {
                TerminalSendStarted.TrySetResult();
                if (_blockTerminalSend)
                {
                    await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
                }

                TerminalSent.TrySetResult();
            }
        }

        public override void Dispose()
        {
            _state = WebSocketState.Closed;
            _inbound.Writer.TryComplete();
        }
    }
}
