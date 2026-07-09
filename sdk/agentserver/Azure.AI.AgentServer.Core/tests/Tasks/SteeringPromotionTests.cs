// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class SteeringPromotionTests
{
    [Test]
    public async Task RunningHandlerObservesCancellationAndPendingCountOnSteer()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var observed = new TaskCompletionSource<(bool Cancelled, int Pending, bool CancelRequested)>(
            TaskCreationOptions.RunContinuationsAsynchronously);

        host.Builder.AddMultiTurnTask<string, string>(
            "chat",
            async (ctx, ct) =>
            {
                if (ctx.IsSteeredTurn)
                {
                    return "S:" + ctx.Input;
                }

                await release.Task.ConfigureAwait(false);
                observed.TrySetResult((ctx.Cancellation.IsCancellationRequested, ctx.PendingInputCount, ctx.CancelRequested));
                return "F:" + ctx.Input;
            },
            steerable: true);

        TaskRun<string> run1 = await host.Invoker.StartAsync<string, string>(
            "chat", "in1", new RunOptions { TaskId = "t1", InputId = "i1" });
        await host.WaitForStatusAsync("t1", "in_progress", TimeSpan.FromSeconds(5));

        TaskRun<string> run2 = await host.Invoker.StartAsync<string, string>(
            "chat", "in2", new RunOptions { TaskId = "t1", InputId = "i2" });
        Assert.That(run2.IsQueued, Is.True);

        // The steering append completed, so the running turn must already see the nudge.
        release.SetResult();

        (bool cancelled, int pending, bool cancelRequested) = await observed.Task;
        Assert.That(cancelled, Is.True, "steering should signal the cooperative cancellation token");
        Assert.That(pending, Is.GreaterThan(0), "pending-input count must be set before the cancel signal");
        Assert.That(cancelRequested, Is.False, "a steering nudge is not a caller cancel cause");

        Assert.That(await run1.GetResultAsync(), Is.EqualTo("F:in1"));
        Assert.That(await run2.GetResultAsync(), Is.EqualTo("S:in2"));
    }

    [Test]
    public async Task TwoQueuedInputsPromoteInFifoOrderWithMonotonicSeq()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var gate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        host.Builder.AddMultiTurnTask<string, string>(
            "chat",
            async (ctx, ct) =>
            {
                if (ctx.IsSteeredTurn)
                {
                    return "S:" + ctx.Input;
                }

                await gate.Task.ConfigureAwait(false);
                return "F:" + ctx.Input;
            },
            steerable: true);

        TaskRun<string> run1 = await host.Invoker.StartAsync<string, string>(
            "chat", "in1", new RunOptions { TaskId = "t1", InputId = "i1" });
        await host.WaitForStatusAsync("t1", "in_progress", TimeSpan.FromSeconds(5));

        TaskRun<string> run2 = await host.Invoker.StartAsync<string, string>(
            "chat", "in2", new RunOptions { TaskId = "t1", InputId = "i2" });
        TaskRun<string> run3 = await host.Invoker.StartAsync<string, string>(
            "chat", "in3", new RunOptions { TaskId = "t1", InputId = "i3" });
        Assert.That(run2.IsQueued && run3.IsQueued, Is.True);

        gate.SetResult();

        Assert.That(await run1.GetResultAsync(), Is.EqualTo("F:in1"));
        Assert.That(await run2.GetResultAsync(), Is.EqualTo("S:in2"));
        Assert.That(await run3.GetResultAsync(), Is.EqualTo("S:in3"));

        // The chain parks at suspended. Small steering inputs stay inline in pending_inputs and do
        // NOT burn an attachment seq, so next_input_seq stays 0 (Python parity: next_input_seq only
        // advances on the attachment-promotion branch).
        TaskRecord record = await host.WaitForStatusAsync("t1", "suspended", TimeSpan.FromSeconds(5));
        var steering = (System.Text.Json.Nodes.JsonObject?)record.Payload[TaskWireKeys.PayloadSteering];
        Assert.That(steering, Is.Not.Null);
        Assert.That((int)steering![TaskWireKeys.SteeringNextInputSeq]!, Is.EqualTo(0));
    }

    [Test]
    public async Task LargeQueuedInputsPromoteToAttachmentsAtAppendWithMonotonicSeq()
    {
        // Parity: oversized (> 20 KiB) steering inputs must be promoted to `steering_input_<seq>`
        // attachments at APPEND time, leaving only a tiny ref in pending_inputs so the persisted
        // `_steering` payload stays bounded regardless of how many large inputs are queued. Each
        // promotion advances next_input_seq (monotonic, never reused). The drained turn still
        // observes the full raw value, and the consumed attachment is deleted at drain.
        using TaskTestHost host = TaskTestHost.Create();
        var gate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        string big2 = "B2-" + new string('x', 40 * 1024);
        string big3 = "B3-" + new string('y', 40 * 1024);

        host.Builder.AddMultiTurnTask<string, int>(
            "chat",
            async (ctx, ct) =>
            {
                if (ctx.IsSteeredTurn)
                {
                    return ctx.Input.Length;
                }

                await gate.Task.ConfigureAwait(false);
                return ctx.Input.Length;
            },
            steerable: true);

        TaskRun<int> run1 = await host.Invoker.StartAsync<string, int>(
            "chat", "in1", new RunOptions { TaskId = "t1", InputId = "i1" });
        await host.WaitForStatusAsync("t1", "in_progress", TimeSpan.FromSeconds(5));

        TaskRun<int> run2 = await host.Invoker.StartAsync<string, int>(
            "chat", big2, new RunOptions { TaskId = "t1", InputId = "i2" });
        TaskRun<int> run3 = await host.Invoker.StartAsync<string, int>(
            "chat", big3, new RunOptions { TaskId = "t1", InputId = "i3" });
        Assert.That(run2.IsQueued && run3.IsQueued, Is.True);

        // While both large inputs are queued, pending_inputs must hold only refs (the payload stays
        // small); the raw content lives in attachments.
        TaskRecord queuedRecord = await host.Store.GetAsync("t1", CancellationToken.None);
        var queuedSteering = (System.Text.Json.Nodes.JsonObject?)queuedRecord!.Payload[TaskWireKeys.PayloadSteering];
        var pending = (System.Text.Json.Nodes.JsonArray?)queuedSteering![TaskWireKeys.SteeringPendingInputs];
        Assert.That(pending!.Count, Is.EqualTo(2));
        foreach (var entry in pending!)
        {
            Assert.That(entry is System.Text.Json.Nodes.JsonObject o && o.ContainsKey(TaskWireKeys.AttachmentRefMagic),
                Is.True, "queued oversized input must be a ref, not inline");
        }

        Assert.That(queuedRecord.Attachments, Is.Not.Null);
        Assert.That(queuedRecord.Attachments!.ContainsKey("steering_input_0"), Is.True);
        Assert.That(queuedRecord.Attachments!.ContainsKey("steering_input_1"), Is.True);

        gate.SetResult();

        Assert.That(await run1.GetResultAsync(), Is.EqualTo("in1".Length));
        Assert.That(await run2.GetResultAsync(), Is.EqualTo(big2.Length), "drained turn sees full raw value");
        Assert.That(await run3.GetResultAsync(), Is.EqualTo(big3.Length));

        // Two attachment promotions → next_input_seq == 2; consumed attachments deleted at drain.
        TaskRecord record = await host.WaitForStatusAsync("t1", "suspended", TimeSpan.FromSeconds(5));
        var steering = (System.Text.Json.Nodes.JsonObject?)record.Payload[TaskWireKeys.PayloadSteering];
        Assert.That((int)steering![TaskWireKeys.SteeringNextInputSeq]!, Is.EqualTo(2));
        Assert.That(record.Attachments is null || !record.Attachments.ContainsKey("steering_input_0"), Is.True);
        Assert.That(record.Attachments is null || !record.Attachments.ContainsKey("steering_input_1"), Is.True);
    }

    [Test]
    public async Task MetadataMutatedInTurnSurvivesInProcessSteeringDrain()
    {
        // Regression: a turn boundary that drains a queued steering input in-process must persist
        // the finishing turn's metadata before the next turn re-hydrates from the store. Otherwise
        // accumulated state (e.g. a running turn counter) is silently lost across the drain.
        using TaskTestHost host = TaskTestHost.Create();
        var gate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        host.Builder.AddMultiTurnTask<string, int>(
            "counter",
            async (ctx, ct) =>
            {
                int turn = 1;
                if (ctx.Metadata.TryGetValue("turn_count", out var raw))
                {
                    turn = raw.ToObjectFromJson<int>() + 1;
                }
                ctx.Metadata["turn_count"] = BinaryData.FromObjectAsJson(turn);

                if (!ctx.IsSteeredTurn)
                {
                    // Stall the first turn until the steering input is queued, then wrap up.
                    await gate.Task.ConfigureAwait(false);
                }

                return turn;
            },
            steerable: true);

        TaskRun<int> run1 = await host.Invoker.StartAsync<string, int>(
            "counter", "in1", new RunOptions { TaskId = "t1", InputId = "i1" });
        await host.WaitForStatusAsync("t1", "in_progress", TimeSpan.FromSeconds(5));

        TaskRun<int> run2 = await host.Invoker.StartAsync<string, int>(
            "counter", "in2", new RunOptions { TaskId = "t1", InputId = "i2" });
        Assert.That(run2.IsQueued, Is.True);

        gate.SetResult();

        Assert.That(await run1.GetResultAsync(), Is.EqualTo(1), "first turn sees turn_count = 1");
        Assert.That(await run2.GetResultAsync(), Is.EqualTo(2),
            "steered turn must read the persisted turn_count from the drained turn");
    }
}
