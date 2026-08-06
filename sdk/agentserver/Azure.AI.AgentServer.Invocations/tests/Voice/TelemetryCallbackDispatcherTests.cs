// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
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
        Assert.That(await queued, Is.True);
        await finalCallback.Task.WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(dispatcher.DroppedCallbackCount, Is.EqualTo(dropBaseline));
    }
}
