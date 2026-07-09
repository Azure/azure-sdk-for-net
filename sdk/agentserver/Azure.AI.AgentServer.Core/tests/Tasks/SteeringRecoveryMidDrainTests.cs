// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class SteeringRecoveryMidDrainTests
{
    [Test]
    public async Task CrashDuringSteeredTurnRecoversAsSteeredTurn()
    {
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);

        var firstTurnGate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        host1.Builder.AddMultiTurnTask<string, string>(
            "chat",
            async (ctx, ct) =>
            {
                if (ctx.IsSteeredTurn)
                {
                    // The steered turn crashes (exits for recovery) leaving the record in_progress
                    // with drain_in_progress=true persisted.
                    await ctx.ExitForRecoveryAsync(ct);
                    return "unreached";
                }

                await firstTurnGate.Task.ConfigureAwait(false);
                return "first:" + ctx.Input;
            },
            steerable: true);

        // ExitForRecovery is gated on graceful shutdown — signal it before dispatch so the steered
        // turn may bail out for recovery (the documented production pattern; tasks-guide.md §4.11).
        host1.SignalShutdown();
        TaskRun<string> run1 = await host1.Invoker.StartAsync<string, string>(
            "chat", "in1", new RunOptions { TaskId = "t1", InputId = "i1" });
        await host1.WaitForStatusAsync("t1", "in_progress", TimeSpan.FromSeconds(5));

        TaskRun<string> run2 = await host1.Invoker.StartAsync<string, string>(
            "chat", "in2", new RunOptions { TaskId = "t1", InputId = "i2" });
        Assert.That(run2.IsQueued, Is.True);

        // Releasing the first turn triggers the drain → steered turn → exit-for-recovery.
        firstTurnGate.SetResult();
        Assert.That(await run1.GetResultAsync(), Is.EqualTo("first:in1"));
        Assert.ThrowsAsync<TaskDeferredException>(async () => await run2.GetResultAsync());

        // The record is left in_progress with the drain markers persisted.
        TaskRecord? mid = await host1.Store.GetAsync("t1");
        Assert.That(mid, Is.Not.Null);
        Assert.That(mid!.Status, Is.EqualTo("in_progress"));
        var steering = (JsonObject?)mid.Payload[TaskWireKeys.PayloadSteering];
        Assert.That(steering, Is.Not.Null);
        Assert.That((bool)steering![TaskWireKeys.SteeringDrainInProgress]!, Is.True);

        // Simulate a process restart and recover. The recovered handler must re-enter as a
        // steered turn (FR-023a / C-REC-5).
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);

        var recoveredSteered = new TaskCompletionSource<(bool Steered, string Input)>(
            TaskCreationOptions.RunContinuationsAsynchronously);

        host2.Builder.AddMultiTurnTask<string, string>(
            "chat",
            (ctx, ct) =>
            {
                recoveredSteered.TrySetResult((ctx.IsSteeredTurn, ctx.Input));
                return Task.FromResult("recovered:" + ctx.Input);
            },
            steerable: true);

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));

        (bool steered, string input) = await recoveredSteered.Task.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(steered, Is.True);
        Assert.That(input, Is.EqualTo("in2"));
    }
}
