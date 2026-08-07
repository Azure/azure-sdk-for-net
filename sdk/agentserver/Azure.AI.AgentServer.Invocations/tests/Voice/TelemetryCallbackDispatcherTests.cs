// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

[TestFixture]
[NonParallelizable]
public class TelemetryCallbackDispatcherTests
{
    [Test]
    public async Task ActivityStopIsNotDroppedWhenGeneralQueueIsFull()
    {
        var activityStopped = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsTelemetry.SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = _ => activityStopped.TrySetResult(),
        };
        ActivitySource.AddActivityListener(listener);
        using var dispatcher = new TelemetryCallbackDispatcher();
        var activity = await InvocationsTelemetry.StartActivityAsync(
            dispatcher,
            "test.activity",
            ActivityKind.Internal,
            default);
        Assert.That(activity, Is.Not.Null);

        var blockerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseBlocker = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Assert.That(dispatcher.TryQueue(() =>
        {
            blockerStarted.TrySetResult();
            releaseBlocker.Task.GetAwaiter().GetResult();
        }), Is.True);
        await blockerStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        for (var index = 0; index < 256; index++)
        {
            Assert.That(dispatcher.TryQueue(static () => { }), Is.True);
        }

        var stopTask = InvocationsTelemetry.StopActivityAsync(
            dispatcher,
            activity!,
            activity!.Stop);
        releaseBlocker.TrySetResult();

        await stopTask.WaitAsync(TimeSpan.FromSeconds(2));
        await activityStopped.Task.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task ReservedActivityCanStopAfterDispatcherDispose()
    {
        var activityStopped = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsTelemetry.SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = _ => activityStopped.TrySetResult(),
        };
        ActivitySource.AddActivityListener(listener);
        var dispatcher = new TelemetryCallbackDispatcher();
        var activity = await InvocationsTelemetry.StartActivityAsync(
            dispatcher,
            "test.activity.dispose",
            ActivityKind.Internal,
            default);
        Assert.That(activity, Is.Not.Null);

        dispatcher.Dispose();
        await InvocationsTelemetry.StopActivityAsync(dispatcher, activity!, activity!.Stop)
            .WaitAsync(TimeSpan.FromSeconds(2));

        await activityStopped.Task.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task ConcurrentActivityStopsConsumeReservationExactlyOnce()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsTelemetry.SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
        };
        ActivitySource.AddActivityListener(listener);
        using var dispatcher = new TelemetryCallbackDispatcher();
        var activity = await InvocationsTelemetry.StartActivityAsync(
            dispatcher,
            "test.activity.concurrent-stop",
            ActivityKind.Internal,
            default);
        Assert.That(activity, Is.Not.Null);

        var blockerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseBlocker = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Assert.That(dispatcher.TryQueue(() =>
        {
            blockerStarted.TrySetResult();
            releaseBlocker.Task.GetAwaiter().GetResult();
        }), Is.True);
        await blockerStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        var stopCount = 0;
        var first = InvocationsTelemetry.StopActivityAsync(
            dispatcher,
            activity!,
            () =>
            {
                Interlocked.Increment(ref stopCount);
                activity!.Stop();
            });
        var second = InvocationsTelemetry.StopActivityAsync(
            dispatcher,
            activity!,
            () =>
            {
                Interlocked.Increment(ref stopCount);
                activity!.Stop();
            });
        Assert.Multiple(() =>
        {
            Assert.That(first.IsCompleted, Is.False);
            Assert.That(second.IsCompleted, Is.False);
        });
        releaseBlocker.TrySetResult();

        await Task.WhenAll(first, second).WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(stopCount, Is.EqualTo(1));
    }

    [Test]
    public async Task ActivityStopUsesOriginalDispatcherWhenCallerSuppliesAnother()
    {
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsTelemetry.SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
        };
        ActivitySource.AddActivityListener(listener);
        var originalDispatcher = new TelemetryCallbackDispatcher();
        using var otherDispatcher = new TelemetryCallbackDispatcher();
        var activity = await InvocationsTelemetry.StartActivityAsync(
            originalDispatcher,
            "test.activity.dispatcher-owner",
            ActivityKind.Internal,
            default);
        Assert.That(activity, Is.Not.Null);

        originalDispatcher.Dispose();
        await InvocationsTelemetry.StopActivityAsync(
            otherDispatcher,
            activity!,
            activity!.Stop).WaitAsync(TimeSpan.FromSeconds(2));

        await originalDispatcher.WorkerCompletion.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task ReleasingLastReservationAfterDisposeWakesWorkerForExit()
    {
        var dispatcher = new TelemetryCallbackDispatcher();
        var workerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Assert.That(dispatcher.TryQueue(workerStarted.SetResult), Is.True);
        await workerStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(dispatcher.TryReserveActivity(), Is.True);

        dispatcher.Dispose();
        dispatcher.ReleaseActivity();

        await dispatcher.WorkerCompletion.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task DisposeWithoutStartingWorkersCompletesWorkerCompletion()
    {
        var dispatcher = new TelemetryCallbackDispatcher(workerCount: 2);

        dispatcher.Dispose();

        await dispatcher.WorkerCompletion.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task ReleasingDisposedReservationCompletesWithoutStartingWorker()
    {
        var dispatcher = new TelemetryCallbackDispatcher(workerCount: 2);
        Assert.That(dispatcher.TryReserveActivity(), Is.True);

        dispatcher.Dispose();
        dispatcher.ReleaseActivity();

        await dispatcher.WorkerCompletion.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task DisposeDoesNotWaitForBlockedWorkersAndCompletionWaitsForBoth()
    {
        var dispatcher = new TelemetryCallbackDispatcher(workerCount: 2);
        var blockersStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseBlockers = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var startedCount = 0;
        Action blocker = () =>
        {
            if (Interlocked.Increment(ref startedCount) == 2)
            {
                blockersStarted.TrySetResult();
            }

            releaseBlockers.Task.GetAwaiter().GetResult();
        };
        Assert.Multiple(() =>
        {
            Assert.That(dispatcher.TryQueue(blocker), Is.True);
            Assert.That(dispatcher.TryQueue(blocker), Is.True);
        });
        await blockersStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        dispatcher.Dispose();
        Assert.That(dispatcher.WorkerCompletion.IsCompleted, Is.False);

        releaseBlockers.TrySetResult();
        await dispatcher.WorkerCompletion.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task GeneralQueueSaturationPreservesCriticalCallbacksAndConnectionGauge()
    {
        using var dispatcher = new TelemetryCallbackDispatcher();
        var blockerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseBlocker = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Assert.That(dispatcher.TryQueue(() =>
        {
            blockerStarted.TrySetResult();
            releaseBlocker.Task.GetAwaiter().GetResult();
        }), Is.True);
        await blockerStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        for (var index = 0; index < 256; index++)
        {
            Assert.That(dispatcher.TryQueue(static () => { }), Is.True);
        }

        var globalDropBaseline = InvocationsTelemetry.DroppedCallbackCount;
        Assert.That(dispatcher.TryQueue(static () => { }), Is.False);
        Assert.Multiple(() =>
        {
            Assert.That(dispatcher.DroppedCallbackCount, Is.EqualTo(1));
            Assert.That(InvocationsTelemetry.DroppedCallbackCount, Is.EqualTo(globalDropBaseline + 1));
        });

        var criticalCallback = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Assert.That(dispatcher.TryQueueCritical(criticalCallback.SetResult), Is.True);

        var baselineConnections = VoiceMetrics.ActiveConnectionCount;
        VoiceMetrics.ConnectionOpened(dispatcher);
        VoiceMetrics.ConnectionClosed(dispatcher);
        Assert.That(VoiceMetrics.ActiveConnectionCount, Is.EqualTo(baselineConnections));

        releaseBlocker.TrySetResult();
        await criticalCallback.Task.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Test]
    public async Task CriticalQueueSaturationAppliesBackpressureWithoutDroppingCallback()
    {
        using var dispatcher = new TelemetryCallbackDispatcher();
        var blockerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseBlocker = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Assert.That(dispatcher.TryQueue(() =>
        {
            blockerStarted.TrySetResult();
            releaseBlocker.Task.GetAwaiter().GetResult();
        }), Is.True);
        await blockerStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));

        for (var index = 0; index < 256; index++)
        {
            Assert.That(dispatcher.TryQueueCritical(static () => { }), Is.True);
        }

        var dropBaseline = dispatcher.DroppedCallbackCount;
        var finalCallback = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(2));
        var queued = dispatcher.QueueCriticalAsync(finalCallback.SetResult, cancellation.Token);
        Assert.That(queued.IsCompleted, Is.False);

        releaseBlocker.TrySetResult();
        Assert.That(await queued, Is.EqualTo(CriticalTelemetryEnqueueResult.Accepted));
        await finalCallback.Task.WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(dispatcher.DroppedCallbackCount, Is.EqualTo(dropBaseline));
    }

    [Test]
    public async Task CriticalEnqueueReportsDispatcherCompletion()
    {
        var dispatcher = new TelemetryCallbackDispatcher();
        dispatcher.Dispose();

        var result = await dispatcher.QueueCriticalAsync(
            static () => { },
            CancellationToken.None);

        Assert.That(result, Is.EqualTo(CriticalTelemetryEnqueueResult.DispatcherCompleted));
    }

    [Test]
    public async Task CriticalEnqueueCancellationReportsDeadlineExpiry()
    {
        using var dispatcher = new TelemetryCallbackDispatcher();
        var blockerStarted = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseBlocker = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Assert.That(dispatcher.TryQueue(() =>
        {
            blockerStarted.TrySetResult();
            releaseBlocker.Task.GetAwaiter().GetResult();
        }), Is.True);
        await blockerStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
        for (var index = 0; index < 256; index++)
        {
            Assert.That(dispatcher.TryQueueCritical(static () => { }), Is.True);
        }

        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        var result = await dispatcher.QueueCriticalAsync(static () => { }, cancellation.Token);

        Assert.That(result, Is.EqualTo(CriticalTelemetryEnqueueResult.DeadlineExpired));
        releaseBlocker.TrySetResult();
    }

    [Test]
    public async Task CloseEventSinkFailureIsCountedAndDoesNotStopWorker()
    {
        using var dispatcher = new TelemetryCallbackDispatcher();
        var baseline = InvocationsTelemetry.CloseEventSinkFaultedCount;
        var afterFailure = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        Assert.That(dispatcher.TryQueueCritical(InvocationsTelemetry.CreateCloseEventCallback(
            static () => throw new InvalidOperationException("sink failed"))), Is.True);
        Assert.That(dispatcher.TryQueueCritical(afterFailure.SetResult), Is.True);

        await afterFailure.Task.WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(InvocationsTelemetry.CloseEventSinkFaultedCount, Is.EqualTo(baseline + 1));
    }

    [Test]
    public async Task SelectedAndFinalCloseCodesUseDistinctMetricContracts()
    {
        var measurements = new System.Collections.Concurrent.ConcurrentQueue<(
            string Name,
            long Value,
            string? TagValue)>();
        using var listener = new MeterListener
        {
            InstrumentPublished = (instrument, meterListener) =>
            {
                if (instrument.Meter.Name == InvocationsTelemetry.SourceName)
                {
                    meterListener.EnableMeasurementEvents(instrument);
                }
            },
        };
        listener.SetMeasurementEventCallback<long>((instrument, measurement, tags, _) =>
        {
            var tagValue = tags.Length > 0 ? tags[0].Value?.ToString() : null;
            measurements.Enqueue((instrument.Name, measurement, tagValue));
        });
        listener.Start();
        using var dispatcher = new TelemetryCallbackDispatcher();
        var completed = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        VoiceMetrics.RecordSelectedCloseCode(dispatcher, 1008);
        InvocationsTelemetry.RecordWebSocketTermination(CreateAbortedTermination());
        listener.RecordObservableInstruments();
        Assert.That(dispatcher.TryQueue(completed.SetResult), Is.True);
        await completed.Task.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.Multiple(() =>
        {
            Assert.That(measurements, Does.Contain((
                "azure.ai.agentserver.invocations.voice.selected_close_codes",
                1L,
                "1008")));
            Assert.That(measurements.Any(item =>
                item.Name == "azure.ai.agentserver.invocations_ws.final_close_codes" &&
                item.Value >= 1 &&
                item.TagValue == "1006"), Is.True);
            Assert.That(measurements.Any(item =>
                item.Name == "azure.ai.agentserver.invocations_ws.close_outcomes" &&
                item.Value >= 1 &&
                item.TagValue == "aborted"), Is.True);
            Assert.That(measurements.Any(item =>
                item.Name == "azure.ai.agentserver.invocations.voice.close_codes"), Is.False);
        });
    }

    private static WebSocketTerminationResult CreateAbortedTermination() =>
        WebSocketTerminationResult.Create(
            "session",
            selectedCloseCode: 1008,
            attemptedCloseCode: 1008,
            WebSocketCloseAttemptApi.CloseAsync,
            peerCloseCode: null,
            localCloseInitiated: true,
            wasAborted: true,
            closeOperationSucceeded: false,
            System.Net.WebSockets.WebSocketState.Aborted,
            errorCode: null,
            durationMs: 1,
            endTimeUtc: DateTime.UtcNow);
}
