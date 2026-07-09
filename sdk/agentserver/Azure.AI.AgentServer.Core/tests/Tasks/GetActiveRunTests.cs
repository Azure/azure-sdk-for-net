// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class GetActiveRunTests
{
    [Test]
    public async Task ReturnsInFlightRunThenNullAfterTerminal()
    {
        using var host = TaskTestHost.Create();
        var gate = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        host.Builder.AddTask<string, string>("active", async (ctx, ct) =>
        {
            await gate.Task;
            return ctx.Input;
        });

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "active", "v", new RunOptions { TaskId = "act-1" });

        TaskRun<string>? inflight = await host.Invoker.GetActiveRunAsync<string>("active", "act-1");
        Assert.That(inflight, Is.Not.Null);
        Assert.That(inflight!.TaskId, Is.EqualTo("act-1"));

        gate.SetResult(true);
        await handle;
        await host.WaitUntilDeletedAsync("act-1", System.TimeSpan.FromSeconds(5));

        TaskRun<string>? after = await host.Invoker.GetActiveRunAsync<string>("active", "act-1");
        Assert.That(after, Is.Null);
    }

    [Test]
    public async Task ReturnsNullForUnknownTaskId()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<string, string>("active", (ctx, ct) => Task.FromResult(ctx.Input));
        TaskRun<string>? run = await host.Invoker.GetActiveRunAsync<string>("active", "nope");
        Assert.That(run, Is.Null);
    }
}
