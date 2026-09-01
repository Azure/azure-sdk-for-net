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
        // Models the HandlerCts replacement race: a steering nudge reads HandlerCts and begins
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
            runState,
            (Action<Exception>)(_ => { }))!;

        PropertyInfo handlerCts = activeRunType.GetProperty("HandlerCts")!;
        MethodInfo signalSteering = activeRunType.GetMethod("SignalSteeringAsync")!;

        using var oldSource = new CancellationTokenSource();
        using var currentSource = new CancellationTokenSource();
        var cancellationEntered = new ManualResetEventSlim(false);
        var allowCancellationToFinish = new ManualResetEventSlim(false);

        oldSource.Token.Register(() =>
        {
            cancellationEntered.Set();
            allowCancellationToFinish.Wait();
        });

        handlerCts.SetValue(activeRun, oldSource);
        var signalTask = (Task)signalSteering.Invoke(activeRun, null)!;

        // The nudge is now paused inside the OLD source's cancellation callback. Swap in the new
        // current source, then let the old cancellation finish.
        Assert.That(cancellationEntered.Wait(TimeSpan.FromSeconds(5)), Is.True);
        handlerCts.SetValue(activeRun, currentSource);
        allowCancellationToFinish.Set();

        await signalTask;

        Assert.That(currentSource.IsCancellationRequested, Is.True,
            "the steering nudge must reach the turn that is now current, not the superseded source");
    }
}
