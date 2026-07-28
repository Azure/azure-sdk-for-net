// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class DrainReentryTimeoutTests
{
    [Test]
    public async Task DrainedSteeredTurnReStampsTurnStartedAt()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var firstGate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var steeredGate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        host.Builder.AddMultiTurnTask<string, string>(
            "chat",
            async (ctx, ct) =>
            {
                if (ctx.IsSteeredTurn)
                {
                    await steeredGate.Task.ConfigureAwait(false);
                    return "steered:" + ctx.Input;
                }

                await firstGate.Task.ConfigureAwait(false);
                return "first:" + ctx.Input;
            },
            steerable: true);

        TaskRun<string> run1 = await host.Invoker.StartAsync<string, string>(
            "chat", "in1", new RunOptions { TaskId = "t1", InputId = "i1" });
        await host.WaitForStatusAsync("t1", "in_progress", TimeSpan.FromSeconds(5));

        TaskRecord? firstRecord = await host.Store.GetAsync("t1");
        DateTimeOffset stamp1 = ParseStamp(firstRecord);

        // Queue a steering input, then let the first turn finish so it drains into a steered turn.
        TaskRun<string> run2 = await host.Invoker.StartAsync<string, string>(
            "chat", "in2", new RunOptions { TaskId = "t1", InputId = "i2" });
        Assert.That(run2.IsQueued, Is.True);

        firstGate.SetResult();
        Assert.That(await run1.GetResultAsync(), Is.EqualTo("first:in1"));

        // Wait until the steered turn has been driven (last_input_id advances to i2).
        DateTimeOffset stamp2 = await WaitForSteeredTurnStampAsync(host, "i2", TimeSpan.FromSeconds(5));

        // The per-turn budget is re-based on each drained turn (FR-015): the new turn-start is
        // strictly later than the first turn's, so the watchdog reads a fresh deadline.
        Assert.That(stamp2, Is.GreaterThan(stamp1));

        steeredGate.SetResult();
        Assert.That(await run2.GetResultAsync(), Is.EqualTo("steered:in2"));
    }

    private static async Task<DateTimeOffset> WaitForSteeredTurnStampAsync(
        TaskTestHost host, string expectedInputId, TimeSpan timeout)
    {
        var sw = Stopwatch.StartNew();
        while (sw.Elapsed < timeout)
        {
            TaskRecord? record = await host.Store.GetAsync("t1");
            if (record is not null
                && (string?)record.Payload[TaskWireKeys.PayloadLastInputId] == expectedInputId)
            {
                return ParseStamp(record);
            }

            await Task.Delay(20);
        }

        throw new TimeoutException($"Steered turn with input '{expectedInputId}' did not start in time.");
    }

    private static DateTimeOffset ParseStamp(TaskRecord? record)
    {
        string iso = (string?)record!.Payload[TaskWireKeys.PayloadTurnStartedAt]
            ?? throw new InvalidOperationException("_turn_started_at missing.");
        return DateTimeOffset.Parse(iso);
    }
}
