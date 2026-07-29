// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class SteeringQueueTests
{
    [Test]
    public async Task SteerableInFlightStartIsQueuedNotConflicted()
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

        gate.SetResult();

        Assert.That(await run1.GetResultAsync(), Is.EqualTo("F:in1"));
        Assert.That(await run2.GetResultAsync(), Is.EqualTo("S:in2"));
    }

    [Test]
    public async Task NonSteerableInFlightStartConflicts()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var gate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        host.Builder.AddMultiTurnTask<string, string>(
            "chat",
            async (ctx, ct) =>
            {
                await gate.Task.ConfigureAwait(false);
                return "F:" + ctx.Input;
            },
            steerable: false);

        TaskRun<string> run1 = await host.Invoker.StartAsync<string, string>(
            "chat", "in1", new RunOptions { TaskId = "t1", InputId = "i1" });
        await host.WaitForStatusAsync("t1", "in_progress", TimeSpan.FromSeconds(5));

        Assert.ThrowsAsync<TaskConflictException>(async () =>
            await host.Invoker.StartAsync<string, string>(
                "chat", "in2", new RunOptions { TaskId = "t1", InputId = "i2" }));

        gate.SetResult();
        Assert.That(await run1.GetResultAsync(), Is.EqualTo("F:in1"));
    }
}
