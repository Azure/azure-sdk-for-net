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
    [Test]
    public async Task SteeringNudgeReachesTheCurrentTurnAcrossAHandlerCtsSwap()
    {
        // Models the handler source replacement race: a steering nudge reads the source and begins
        // cancelling it, and a turn transition swaps in a NEW source while that cancel is in flight.
        // The nudge must still signal the source that is now current — otherwise it completes against
        // the superseded source and a blocking handler on the new turn never wakes to drain the
        // queued input. The private ActiveRun<T> is reached via reflection, and the old source's
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

        var nextState = new TaskRunState<string>(
            "t", "next", isQueued: true, new TaskStreamState(streams, "t", "next"));
        CancellationTokenSource oldSource = runState.Cancellation.Source;
        CancellationTokenSource currentSource = nextState.Cancellation.Source;
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
            setCurrent.Invoke(activeRun, new object[] { nextState });
            runState.Cancellation.Retire();
        }
        finally
        {
            allowCancellationToFinish.Set();
            await signalTask.WaitAsync(TimeSpan.FromSeconds(5));
            runState.Cancellation.Retire();
            nextState.Cancellation.Retire();
        }

        Assert.That(currentSource.IsCancellationRequested, Is.True,
            "the steering nudge must reach the turn that is now current, not the superseded source");
    }
}
