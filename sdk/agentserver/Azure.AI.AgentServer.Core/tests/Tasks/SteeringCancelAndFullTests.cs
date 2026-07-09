// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class SteeringCancelAndFullTests
{
    [Test]
    public async Task QueuedCallerCancelRemovesSlotWithoutDisturbingActiveTurn()
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
        Assert.That(run2.IsQueued, Is.True);

        // The queued caller cancels its slot before promotion.
        await run2.CancelAsync();
        Assert.ThrowsAsync<TaskCancelledException>(async () => await run2.GetResultAsync());

        // The active turn is undisturbed and there is nothing left to promote.
        gate.SetResult();
        Assert.That(await run1.GetResultAsync(), Is.EqualTo("F:in1"));
        await host.WaitForStatusAsync("t1", "suspended", TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task TenthQueuedInputThrowsSteeringQueueFull()
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

        // Fill the queue to its capacity of 9.
        for (int i = 0; i < 9; i++)
        {
            TaskRun<string> queued = await host.Invoker.StartAsync<string, string>(
                "chat", "q" + i, new RunOptions { TaskId = "t1", InputId = "qi" + i });
            Assert.That(queued.IsQueued, Is.True);
        }

        // The 10th queued input exceeds the cap.
        Assert.ThrowsAsync<SteeringQueueFullException>(async () =>
            await host.Invoker.StartAsync<string, string>(
                "chat", "overflow", new RunOptions { TaskId = "t1", InputId = "overflow" }));

        gate.SetResult();
        Assert.That(await run1.GetResultAsync(), Is.EqualTo("F:in1"));
    }
}
