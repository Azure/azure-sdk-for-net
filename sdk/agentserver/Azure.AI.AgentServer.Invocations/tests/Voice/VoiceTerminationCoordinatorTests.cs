// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceTerminationCoordinatorTests
{
    [Test]
    public async Task ResponseTerminationDoesNotRunActivityListenerOnProtocolPath()
    {
        var listenerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseListener = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == "VoiceTerminationCoordinatorTests",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = _ =>
            {
                listenerStarted.TrySetResult();
                releaseListener.Task.GetAwaiter().GetResult();
            },
        };
        ActivitySource.AddActivityListener(listener);
        using var source = new ActivitySource("VoiceTerminationCoordinatorTests");
        var activity = source.StartActivity("turn")!;
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        var turnLease = new VoiceTurnLease();
        var response = new StubResponse();
        turnLease.Activate(response, "reactive", release: null, activity);
        var coordinator = CreateCoordinator(webSocket, runtimeCancellation, turnLease);

        try
        {
            var reservation = await Task.Run(() => coordinator.TryTerminateResponse(response, "timeout"))
                .WaitAsync(TimeSpan.FromSeconds(1));
            var telemetryCompletion = VoiceTerminationCoordinator.ApplyResponseTermination(reservation);
            await listenerStarted.Task.WaitAsync(TimeSpan.FromSeconds(1));
            Assert.That(telemetryCompletion.IsCompleted, Is.False);
            releaseListener.TrySetResult();
            await telemetryCompletion.WaitAsync(TimeSpan.FromSeconds(1));
        }
        finally
        {
            releaseListener.TrySetResult();
            coordinator.MarkCompleted();
        }
    }

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
            static (_, _) => ValueTask.CompletedTask);
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
    public async Task CallerCancellationCannotPoisonSharedStructuralTermination()
    {
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        using var callerCancellation = new CancellationTokenSource();
        var sealStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseSeal = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var sealCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var sealCount = 0;
        var applyCount = 0;
        var coordinator = new VoiceTerminationCoordinator(
            new CleanupDeadline(TimeSpan.FromSeconds(5)),
            runtimeCancellation,
            webSocket,
            new VoiceTurnLease(),
            static _ => { },
            async (request, cancellationToken) =>
            {
                try
                {
                    Interlocked.Increment(ref sealCount);
                    sealStarted.TrySetResult();
                    await releaseSeal.Task;
                    cancellationToken.ThrowIfCancellationRequested();
                    return VoiceConnectionTerminationSnapshot.Empty(request);
                }
                finally
                {
                    sealCompleted.TrySetResult();
                }
            },
            _ =>
            {
                Interlocked.Increment(ref applyCount);
                return ValueTask.CompletedTask;
            },
            static (_, _) => ValueTask.CompletedTask);

        Task<VoiceTerminationOutcome>? first = null;
        try
        {
            first = coordinator.BeginAsync(
                new VoiceConnectionTerminationRequest("end_call", stopRuntime: false),
                callerCancellation.Token);
            await sealStarted.Task.WaitAsync(TimeSpan.FromSeconds(1));
            await callerCancellation.CancelAsync();
            OperationCanceledException? cancellation = null;
            try
            {
                await first.WaitAsync(TimeSpan.FromSeconds(1));
            }
            catch (OperationCanceledException exception)
            {
                cancellation = exception;
            }
            Assert.That(cancellation?.CancellationToken, Is.EqualTo(callerCancellation.Token));

            var second = coordinator.BeginAsync(
                new VoiceConnectionTerminationRequest("session_end", stopRuntime: true),
                CancellationToken.None);
            releaseSeal.TrySetResult();
            var outcome = await second.WaitAsync(TimeSpan.FromSeconds(1));

            Assert.Multiple(() =>
            {
                Assert.That(sealCount, Is.EqualTo(1));
                Assert.That(applyCount, Is.EqualTo(1));
                Assert.That(outcome.IsWinner, Is.False);
                Assert.That(outcome.Snapshot.Request.TerminalKind, Is.EqualTo("end_call"));
                Assert.That(runtimeCancellation.IsCancellationRequested, Is.True);
            });
        }
        finally
        {
            releaseSeal.TrySetResult();
            await sealCompleted.Task.WaitAsync(TimeSpan.FromSeconds(1));
            if (first is not null)
            {
                try
                {
                    await first;
                }
                catch (OperationCanceledException)
                {
                }
            }
            coordinator.MarkCompleted();
        }
    }

    [Test]
    public async Task LateCallerCancellationDoesNotCancelTerminalEnrichment()
    {
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        using var lateCallerCancellation = new CancellationTokenSource();
        var sealStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseSeal = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var sealCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var sessionEndNotified = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var coordinator = new VoiceTerminationCoordinator(
            new CleanupDeadline(TimeSpan.FromSeconds(5)),
            runtimeCancellation,
            webSocket,
            new VoiceTurnLease(),
            static _ => { },
            async (request, _) =>
            {
                try
                {
                    sealStarted.TrySetResult();
                    await releaseSeal.Task;
                    return VoiceConnectionTerminationSnapshot.Empty(request);
                }
                finally
                {
                    sealCompleted.TrySetResult();
                }
            },
            static _ => ValueTask.CompletedTask,
            (_, _) =>
            {
                sessionEndNotified.TrySetResult();
                return ValueTask.CompletedTask;
            });

        try
        {
            var first = coordinator.BeginAsync(
                new VoiceConnectionTerminationRequest("end_call", stopRuntime: false),
                CancellationToken.None);
            await sealStarted.Task.WaitAsync(TimeSpan.FromSeconds(1));
            var late = coordinator.BeginAsync(
                new VoiceConnectionTerminationRequest(
                    "session_end",
                    stopRuntime: true,
                    VoiceModelFactory.SessionEndEvent("caller_hangup")),
                lateCallerCancellation.Token);

            await lateCallerCancellation.CancelAsync();
            OperationCanceledException? cancellation = null;
            try
            {
                await late.WaitAsync(TimeSpan.FromSeconds(1));
            }
            catch (OperationCanceledException exception)
            {
                cancellation = exception;
            }
            Assert.That(cancellation?.CancellationToken, Is.EqualTo(lateCallerCancellation.Token));

            var completion = coordinator.CompleteAsync(static _ => Task.CompletedTask);
            Assert.That(completion.IsCompleted, Is.False);
            releaseSeal.TrySetResult();
            await first.WaitAsync(TimeSpan.FromSeconds(1));
            await sessionEndNotified.Task.WaitAsync(TimeSpan.FromSeconds(1));
            await completion.WaitAsync(TimeSpan.FromSeconds(1));
            Assert.That(runtimeCancellation.IsCancellationRequested, Is.True);
        }
        finally
        {
            releaseSeal.TrySetResult();
            await sealCompleted.Task.WaitAsync(TimeSpan.FromSeconds(1));
            coordinator.MarkCompleted();
        }
    }

    [Test]
    public async Task StructuralOwnerDeadlineFailsSharedCompletionAndClosesRegistration()
    {
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        using var callerCancellation = new CancellationTokenSource();
        var sealStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseSeal = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var originalSealCompleted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var sealCount = 0;
        var applyCount = 0;
        var coordinator = new VoiceTerminationCoordinator(
            new CleanupDeadline(TimeSpan.FromMilliseconds(50)),
            runtimeCancellation,
            webSocket,
            new VoiceTurnLease(),
            static _ => { },
            async (request, _) =>
            {
                if (Interlocked.Increment(ref sealCount) == 1)
                {
                    try
                    {
                        sealStarted.TrySetResult();
                        await releaseSeal.Task;
                    }
                    finally
                    {
                        originalSealCompleted.TrySetResult();
                    }
                }
                return VoiceConnectionTerminationSnapshot.Empty(request);
            },
            _ =>
            {
                Interlocked.Increment(ref applyCount);
                return ValueTask.CompletedTask;
            },
            static (_, _) => ValueTask.CompletedTask);

        try
        {
            var first = coordinator.BeginAsync(
                new VoiceConnectionTerminationRequest("end_call", stopRuntime: false),
                callerCancellation.Token);
            await sealStarted.Task.WaitAsync(TimeSpan.FromSeconds(1));
            await callerCancellation.CancelAsync();
            Assert.That(
                async () => await first.WaitAsync(TimeSpan.FromSeconds(1)),
                Throws.InstanceOf<OperationCanceledException>());

            await coordinator.CompleteAsync(static _ => Task.CompletedTask)
                .WaitAsync(TimeSpan.FromSeconds(1));
            Assert.Multiple(() =>
            {
                Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Aborted));
                Assert.That(runtimeCancellation.IsCancellationRequested, Is.True);
                Assert.That(sealCount, Is.EqualTo(2));
                Assert.That(applyCount, Is.EqualTo(1));
                Assert.That(
                    async () => await coordinator.BeginAsync(
                        new VoiceConnectionTerminationRequest("session_end", stopRuntime: true),
                        CancellationToken.None),
                    Throws.TypeOf<VoiceBridgeConnectionClosedException>());
            });
        }
        finally
        {
            releaseSeal.TrySetResult();
            await originalSealCompleted.Task.WaitAsync(TimeSpan.FromSeconds(1));
            coordinator.MarkCompleted();
        }
    }

    [Test]
    public async Task DeadlineBeforeFirstBeginFencesStructuralOwnerCreation()
    {
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        var deadlineSelected = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var sealCount = 0;
        var coordinator = new VoiceTerminationCoordinator(
            new CleanupDeadline(TimeSpan.FromMilliseconds(50)),
            runtimeCancellation,
            webSocket,
            new VoiceTurnLease(),
            _ => deadlineSelected.TrySetResult(),
            (request, _) =>
            {
                Interlocked.Increment(ref sealCount);
                return ValueTask.FromResult(VoiceConnectionTerminationSnapshot.Empty(request));
            },
            static _ => ValueTask.CompletedTask,
            static (_, _) => ValueTask.CompletedTask);

        coordinator.StartDeadline();
        await deadlineSelected.Task.WaitAsync(TimeSpan.FromSeconds(1));
        var outcome = await coordinator.BeginAsync(
            new VoiceConnectionTerminationRequest("session_rejected", stopRuntime: true),
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(outcome.IsWinner, Is.False);
            Assert.That(outcome.Snapshot.Request.TerminalKind, Is.EqualTo("session_rejected"));
            Assert.That(sealCount, Is.Zero);
            Assert.That(runtimeCancellation.IsCancellationRequested, Is.True);
            Assert.That(webSocket.State, Is.EqualTo(WebSocketState.Aborted));
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
            (_, _) =>
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

    [Test]
    public async Task ConnectionShutdownCaptureDoesNotDependOnIdentityAdmission()
    {
        var governor = new VoiceResourceGovernor(new VoiceResourceLimits
        {
            MaxTrackedIdentityBytes = 1,
        });
        using var webSocket = new StubWebSocket();
        using var runtimeCancellation = new CancellationTokenSource();
        var turnLease = new VoiceTurnLease();
        var response = new StubResponse();
        var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        turnLease.Activate(response, "reactive", release, activity: null);
        var coordinator = new VoiceTerminationCoordinator(
            new CleanupDeadline(TimeSpan.FromSeconds(5)),
            runtimeCancellation,
            webSocket,
            turnLease,
            static _ => { },
            static (request, _) => ValueTask.FromResult(VoiceConnectionTerminationSnapshot.Empty(request)),
            static _ => ValueTask.CompletedTask,
            static (_, _) => ValueTask.CompletedTask,
            governor);

        await response.MarkTerminalAsync();
        var termination = coordinator.CaptureResponseForConnectionShutdown(response, "connection_closed");
        await VoiceTerminationCoordinator.ApplyResponseTermination(termination);
        var duplicate = coordinator.CaptureResponseForConnectionShutdown(response, "connection_closed");

        Assert.Multiple(() =>
        {
            Assert.That(termination.IsNewTerminal, Is.True);
            Assert.That(termination.TurnTermination.IsNewTerminal, Is.True);
            Assert.That(duplicate.IsNewTerminal, Is.False);
            Assert.That(duplicate.TurnTermination.IsNewTerminal, Is.False);
            Assert.That(turnLease.Current, Is.Null);
            Assert.That(release.Task.IsCompleted, Is.True);
            Assert.That(response.IsTerminal, Is.True);
            Assert.That(response.CancellationToken.IsCancellationRequested, Is.True);
            Assert.That(governor.TrackedIdentityBytes, Is.Zero);
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
            static (_, _) => ValueTask.CompletedTask);

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
