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
        Assert.That(await run1.Completion, Is.EqualTo("first:in1"));
        // Recovery deferral is an internal lifecycle handoff: it never surfaces on the run handle.
        // Wait for the engine to release the run, then confirm Completion stays pending.
        await host1.WaitUntilInactiveAsync(run2.TaskId, TimeSpan.FromSeconds(5));
        Assert.That(run2.Completion.IsCompleted, Is.False, "deferral must not complete the run handle");

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

    [Test]
    public async Task CrashWithQueuedSteeringInputRehydratesPendingOnRecovery()
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
                    // The first steered turn (draining in2) crashes for recovery, leaving in3
                    // still queued behind it in pending_inputs.
                    await ctx.ExitForRecoveryAsync(ct);
                    return "unreached";
                }

                await firstTurnGate.Task.ConfigureAwait(false);
                return "first:" + ctx.Input;
            },
            steerable: true);

        host1.SignalShutdown();
        TaskRun<string> run1 = await host1.Invoker.StartAsync<string, string>(
            "chat", "in1", new RunOptions { TaskId = "t1", InputId = "i1" });
        await host1.WaitForStatusAsync("t1", "in_progress", TimeSpan.FromSeconds(5));

        // Queue TWO steering inputs while the first turn runs. Both land in pending_inputs.
        TaskRun<string> run2 = await host1.Invoker.StartAsync<string, string>(
            "chat", "in2", new RunOptions { TaskId = "t1", InputId = "i2" });
        TaskRun<string> run3 = await host1.Invoker.StartAsync<string, string>(
            "chat", "in3", new RunOptions { TaskId = "t1", InputId = "i3" });
        Assert.That(run2.IsQueued, Is.True);
        Assert.That(run3.IsQueued, Is.True);

        // Releasing the first turn promotes in2 as a steered turn, which exits for recovery,
        // leaving in3 stranded in pending_inputs.
        firstTurnGate.SetResult();
        Assert.That(await run1.Completion, Is.EqualTo("first:in1"));
        // Recovery deferral is an internal lifecycle handoff: it never surfaces on the run handle.
        // Wait for the engine to release the run, then confirm Completion stays pending.
        await host1.WaitUntilInactiveAsync(run2.TaskId, TimeSpan.FromSeconds(5));
        Assert.That(run2.Completion.IsCompleted, Is.False, "deferral must not complete the run handle");

        // The record is left in_progress: active_input=in2 (mid-drain), pending_inputs=[in3].
        TaskRecord? mid = await host1.Store.GetAsync("t1");
        Assert.That(mid, Is.Not.Null);
        Assert.That(mid!.Status, Is.EqualTo("in_progress"));
        var steering = (JsonObject?)mid.Payload[TaskWireKeys.PayloadSteering];
        Assert.That(steering, Is.Not.Null);
        Assert.That((bool)steering![TaskWireKeys.SteeringDrainInProgress]!, Is.True);
        var pending = (JsonArray?)steering[TaskWireKeys.SteeringPendingInputs];
        Assert.That(pending, Is.Not.Null);
        Assert.That(pending!.Count, Is.EqualTo(1), "in3 must still be queued in pending_inputs");

        // Recover in a fresh process. The recovered chain must process BOTH the active input (in2,
        // recovered as a steered turn) AND the rehydrated pending input (in3) — in3 must not strand.
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);

        var seen = new System.Collections.Concurrent.ConcurrentQueue<string>();
        var bothSeen = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        host2.Builder.AddMultiTurnTask<string, string>(
            "chat",
            (ctx, ct) =>
            {
                seen.Enqueue(ctx.Input);
                if (seen.Count >= 2)
                {
                    bothSeen.TrySetResult();
                }

                return Task.FromResult("recovered:" + ctx.Input);
            },
            steerable: true);

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));

        await bothSeen.Task.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(seen, Does.Contain("in2"));
        Assert.That(seen, Does.Contain("in3"));
    }

    [Test]
    public async Task RecoveredQueuedInputKeepsItsInputIdAndAdvancesLastInputId()
    {
        // A recovered queued steering input must keep its own per-turn InputId and advance the chain
        // head, exactly as it would without a crash — recovery is transparent. Before the id was
        // persisted per entry, a recovered input inherited the previous turn's id (in3 observed as
        // "i2") and never advanced last_input_id, breaking IfLastInputId / idempotent-retry.
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);

        var firstTurnGate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        host1.Builder.AddMultiTurnTask<string, string>(
            "chat",
            async (ctx, ct) =>
            {
                if (ctx.IsSteeredTurn)
                {
                    await ctx.ExitForRecoveryAsync(ct);
                    return "unreached";
                }

                await firstTurnGate.Task.ConfigureAwait(false);
                return "first:" + ctx.Input;
            },
            steerable: true);

        host1.SignalShutdown();
        TaskRun<string> run1 = await host1.Invoker.StartAsync<string, string>(
            "chat", "in1", new RunOptions { TaskId = "identity", InputId = "i1" });
        await host1.WaitForStatusAsync("identity", "in_progress", TimeSpan.FromSeconds(5));

        TaskRun<string> run2 = await host1.Invoker.StartAsync<string, string>(
            "chat", "in2", new RunOptions { TaskId = "identity", InputId = "i2" });
        TaskRun<string> run3 = await host1.Invoker.StartAsync<string, string>(
            "chat", "in3", new RunOptions { TaskId = "identity", InputId = "i3" });
        Assert.That(run2.IsQueued, Is.True);
        Assert.That(run3.IsQueued, Is.True);

        firstTurnGate.SetResult();
        Assert.That(await run1.Completion, Is.EqualTo("first:in1"));
        // Recovery deferral is an internal lifecycle handoff: it never surfaces on the run handle.
        // Wait for the engine to release the run, then confirm Completion stays pending.
        await host1.WaitUntilInactiveAsync(run2.TaskId, TimeSpan.FromSeconds(5));
        Assert.That(run2.Completion.IsCompleted, Is.False, "deferral must not complete the run handle");

        // Recover in a fresh process. Record (Input, InputId) for each recovered turn.
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);

        var seen = new System.Collections.Concurrent.ConcurrentQueue<(string Input, string InputId)>();
        var bothSeen = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        host2.Builder.AddMultiTurnTask<string, string>(
            "chat",
            (ctx, ct) =>
            {
                seen.Enqueue((ctx.Input, ctx.InputId));
                if (seen.Count >= 2)
                {
                    bothSeen.TrySetResult();
                }

                return Task.FromResult("recovered:" + ctx.Input);
            },
            steerable: true);

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));

        await bothSeen.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Each recovered turn carries its OWN durable input id — in3 is "i3", not the inherited "i2".
        Assert.That(seen, Does.Contain(("in2", "i2")));
        Assert.That(seen, Does.Contain(("in3", "i3")));

        // The chain head advanced through the recovered input, so last_input_id ends at "i3".
        TaskRecord suspended = await host2.WaitForStatusAsync("identity", "suspended", TimeSpan.FromSeconds(5));
        Assert.That((string?)suspended.Payload[TaskWireKeys.PayloadLastInputId], Is.EqualTo("i3"));
    }
}
