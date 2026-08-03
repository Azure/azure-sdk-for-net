// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceTerminationCoordinatorTests
{
    [Test]
    public async Task ConnectionSealAndApplyRunExactlyOnce()
    {
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        var sealCount = 0;
        var applyCount = 0;
        var coordinator = new VoiceTerminationCoordinator(
            new CleanupDeadline(TimeSpan.FromSeconds(5)),
            runtimeCancellation,
            webSocket,
            new VoiceTurnLease(),
            static _ => { },
            (request, _) =>
            {
                Interlocked.Increment(ref sealCount);
                return ValueTask.FromResult(VoiceConnectionTerminationSnapshot.Empty(request));
            },
            _ =>
            {
                Interlocked.Increment(ref applyCount);
                return ValueTask.CompletedTask;
            },
            static _ => ValueTask.CompletedTask);
        var request = new VoiceConnectionTerminationRequest("session_end", stopRuntime: true);

        await Task.WhenAll(
            coordinator.BeginAsync(request, CancellationToken.None),
            coordinator.BeginAsync(request, CancellationToken.None));

        Assert.Multiple(() =>
        {
            Assert.That(sealCount, Is.EqualTo(1));
            Assert.That(applyCount, Is.EqualTo(1));
            Assert.That(coordinator.IsTerminating, Is.True);
        });
        coordinator.MarkCompleted();
    }

    [Test]
    public async Task ExactlyOneConcurrentTerminalIsReportedAsWinner()
    {
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        var coordinator = CreateCoordinator(webSocket, runtimeCancellation);

        var first = coordinator.BeginAsync(
            new VoiceConnectionTerminationRequest("end_call", stopRuntime: false),
            CancellationToken.None);
        var second = coordinator.BeginAsync(
            new VoiceConnectionTerminationRequest("session_error", stopRuntime: false),
            CancellationToken.None);
        var outcomes = await Task.WhenAll(first, second);

        Assert.That(outcomes.Count(outcome => outcome.IsWinner), Is.EqualTo(1));
        coordinator.MarkCompleted();
    }

    [Test]
    public async Task CleanupDrainRunsExactlyOnce()
    {
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        var drainCount = 0;
        var coordinator = CreateCoordinator(webSocket, runtimeCancellation);
        await coordinator.BeginAsync(
            new VoiceConnectionTerminationRequest("disconnect", stopRuntime: true),
            CancellationToken.None);

        await Task.WhenAll(
            coordinator.CompleteAsync(_ =>
            {
                Interlocked.Increment(ref drainCount);
                return Task.CompletedTask;
            }),
            coordinator.CompleteAsync(_ =>
            {
                Interlocked.Increment(ref drainCount);
                return Task.CompletedTask;
            }));

        coordinator.MarkCompleted();
        Assert.That(drainCount, Is.EqualTo(1));
    }

    [Test]
    public async Task LateSessionEndEnrichesExistingTerminalExactlyOnce()
    {
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        var notifyCount = 0;
        var coordinator = new VoiceTerminationCoordinator(
            new CleanupDeadline(TimeSpan.FromSeconds(5)),
            runtimeCancellation,
            webSocket,
            new VoiceTurnLease(),
            static _ => { },
            static (request, _) => ValueTask.FromResult(VoiceConnectionTerminationSnapshot.Empty(request)),
            static _ => ValueTask.CompletedTask,
            _ =>
            {
                Interlocked.Increment(ref notifyCount);
                return ValueTask.CompletedTask;
            });
        await coordinator.BeginAsync(
            new VoiceConnectionTerminationRequest("end_call", stopRuntime: false),
            CancellationToken.None);
        var sessionEnd = VoiceModelFactory.SessionEndEvent("agent_completed");

        await coordinator.BeginAsync(
            new VoiceConnectionTerminationRequest("session_end", stopRuntime: true, sessionEnd),
            CancellationToken.None);

        coordinator.MarkCompleted();
        Assert.Multiple(() =>
        {
            Assert.That(notifyCount, Is.EqualTo(1));
            Assert.That(runtimeCancellation.IsCancellationRequested, Is.True);
            Assert.That(coordinator.Request?.TerminalKind, Is.EqualTo("end_call"));
        });
    }

    [Test]
    public void ResponseTerminalAndTurnLeaseAreCapturedTogetherExactlyOnce()
    {
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        var turnLease = new VoiceTurnLease();
        var response = new StubResponse();
        turnLease.Activate(response, "reactive", release: null, activity: null);
        var coordinator = CreateCoordinator(webSocket, runtimeCancellation, turnLease);

        var first = coordinator.TryTerminateResponse(response, "timeout");
        var second = coordinator.TryTerminateResponse(response, "timeout");

        Assert.Multiple(() =>
        {
            Assert.That(first.IsNewTerminal, Is.True);
            Assert.That(first.TurnTermination.IsNewTerminal, Is.True);
            Assert.That(second.IsNewTerminal, Is.False);
            Assert.That(second.TurnTermination.IsNewTerminal, Is.False);
            Assert.That(coordinator.IsResponseTerminal(response.ResponseId), Is.True);
            Assert.That(turnLease.Current, Is.Null);
        });
        coordinator.MarkCompleted();
    }

    private static VoiceTerminationCoordinator CreateCoordinator(
        WebSocket webSocket,
        CancellationTokenSource runtimeCancellation,
        VoiceTurnLease? turnLease = null) =>
        new(
            new CleanupDeadline(TimeSpan.FromSeconds(5)),
            runtimeCancellation,
            webSocket,
            turnLease ?? new VoiceTurnLease(),
            static _ => { },
            static (request, _) => ValueTask.FromResult(VoiceConnectionTerminationSnapshot.Empty(request)),
            static _ => ValueTask.CompletedTask,
            static _ => ValueTask.CompletedTask);

    private sealed class StubResponse : VoiceResponse
    {
    }

    private sealed class StubWebSocket : WebSocket
    {
        private WebSocketState _state = WebSocketState.Open;

        public override WebSocketCloseStatus? CloseStatus => null;

        public override string? CloseStatusDescription => null;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public override void Abort() => _state = WebSocketState.Aborted;

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

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) => Task.CompletedTask;

        public override void Dispose() => _state = WebSocketState.Closed;
    }
}
