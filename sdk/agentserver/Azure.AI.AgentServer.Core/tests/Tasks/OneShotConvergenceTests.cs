// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class OneShotConvergenceTests
{
    [Test]
    public async Task SecondSameTaskIdCallerAttachesToInFlightRun()
    {
        using var host = TaskTestHost.Create();
        int invocations = 0;
        var gate = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        host.Builder.AddTask<string, int>("converge", async (ctx, ct) =>
        {
            Interlocked.Increment(ref invocations);
            await gate.Task;
            return 7;
        });

        var opts = new RunOptions { TaskId = "conv-1" };
        TaskRun<int> first = await host.Invoker.StartAsync<string, int>("converge", "a", opts);
        TaskRun<int> second = await host.Invoker.StartAsync<string, int>("converge", "a", opts);

        Assert.That(second.TaskId, Is.EqualTo(first.TaskId));

        gate.SetResult(true);
        int r1 = await first;
        int r2 = await second;
        Assert.That(r1, Is.EqualTo(7));
        Assert.That(r2, Is.EqualTo(7));
        Assert.That(invocations, Is.EqualTo(1), "handler should run once for converged callers");
    }

    [Test]
    public async Task OneShotRecordIsDeletedOnTerminal()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<string, string>("cleanup", (ctx, ct) => Task.FromResult(ctx.Input));

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "cleanup", "x", new RunOptions { TaskId = "clean-1" });
        await handle;

        await host.WaitUntilDeletedAsync("clean-1", TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task SameTaskIdAfterTerminalConflicts()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<string, string>("once", (ctx, ct) => Task.FromResult(ctx.Input));

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "once", "x", new RunOptions { TaskId = "once-1" });
        await handle;
        await host.WaitUntilDeletedAsync("once-1", TimeSpan.FromSeconds(5));

        Assert.ThrowsAsync<TaskConflictException>(async () =>
            await host.Invoker.StartAsync<string, string>("once", "y", new RunOptions { TaskId = "once-1" }));
    }
}
