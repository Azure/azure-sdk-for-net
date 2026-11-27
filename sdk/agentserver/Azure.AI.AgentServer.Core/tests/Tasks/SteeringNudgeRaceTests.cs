// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class SteeringNudgeRaceTests
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task SteeringNudgeFollowsAHandlerCtsSwapOnlyWhileInputRemainsQueued(bool inputRemainsQueued)
    {
        // Models the handler source replacement race: a steering nudge reads the source and begins
        // cancelling it, and a turn transition swaps in a NEW source while that cancel is in flight.
        // The nudge must reach the new source only if another input still needs draining.
        // The private ActiveRun<T> is reached via reflection, and the old source's
        // cancellation is paused inside a registered callback so the swap is deterministic.
        var streams = new InMemoryEventStreamRegistry(new AgentEventStreamOptions());
        var runState = new TaskRunState<string>(
            "t",
            "i",
            isQueued: false,
            new TaskStreamState(streams, "t", "i"));

        Type activeRunType = typeof(TaskEngine)
            .GetNestedType("ActiveRun`1", BindingFlags.NonPublic)!
            .MakeGenericType(typeof(string));
        object activeRun = Activator.CreateInstance(
            activeRunType,
            "task-name",
            runState)!;

        MethodInfo setCurrent = activeRunType.GetMethod("SetCurrent")!;
        MethodInfo signalSteering = activeRunType.GetMethod("SignalSteeringAsync")!;
        MethodInfo enqueue = activeRunType.GetMethod("Enqueue")!;
        MethodInfo promote = activeRunType.GetMethod("PromoteNext")!;
        MethodInfo bindPending = activeRunType.GetMethod("BindPendingInputCount")!;

        var nextState = new TaskRunState<string>(
            "t", "next", isQueued: true, new TaskStreamState(streams, "t", "next"));
        enqueue.Invoke(activeRun, new object[] { new QueuedInput<string>(null, null, "next", false, nextState) });
        var lastState = new TaskRunState<string>(
            "t", "last", isQueued: true, new TaskStreamState(streams, "t", "last"));
        if (inputRemainsQueued)
        {
            enqueue.Invoke(activeRun, new object[] { new QueuedInput<string>(null, null, "last", false, lastState) });
        }
        CancellationTokenSource oldSource = runState.Cancellation.Source;
        CancellationTokenSource currentSource = nextState.Cancellation.Source;
        int currentPending = -1;
        bool causePublishedBeforeCancellation = false;
        using var currentRegistration = currentSource.Token.Register(() =>
            causePublishedBeforeCancellation = currentPending > 0);
        using var cancellationEntered = new ManualResetEventSlim(false);
        using var allowCancellationToFinish = new ManualResetEventSlim(false);

        oldSource.Token.Register(() =>
        {
            cancellationEntered.Set();
            Assert.That(allowCancellationToFinish.Wait(TimeSpan.FromSeconds(5)), Is.True);
        });

        var signalTask = (Task)signalSteering.Invoke(activeRun, null)!;

        try
        {
            // Swap while the nudge's callback is in flight, just as a real turn transition does.
            Assert.That(cancellationEntered.Wait(TimeSpan.FromSeconds(5)), Is.True);
            promote.Invoke(activeRun, null);
            setCurrent.Invoke(activeRun, new object[] { nextState });
            bindPending.Invoke(activeRun, new object[]
            {
                nextState, (Action<int>)(count => currentPending = count)
            });
            runState.Cancellation.Retire();
        }
        finally
        {
            allowCancellationToFinish.Set();
            await signalTask.WaitAsync(TimeSpan.FromSeconds(5));
            runState.Cancellation.Retire();
            nextState.Cancellation.Retire();
            lastState.Cancellation.Retire();
        }

        Assert.That(currentSource.IsCancellationRequested, Is.EqualTo(inputRemainsQueued),
            "a promoted turn must not be cancelled by a stale steering nudge after the queue drains");
        Assert.That(currentPending, Is.EqualTo(inputRemainsQueued ? 1 : 0));
        Assert.That(causePublishedBeforeCancellation, Is.EqualTo(inputRemainsQueued));
    }
}
