// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class GetActiveRunStaleRecoveryTests
{
    [Test]
    public async Task OneShotGetActiveRunReclaimsStaleInProgressRun()
    {
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);
        host1.Builder.AddTask<string, string>("job", async (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                await ctx.ExitForRecoveryAsync(ct);
            }

            return "done:" + ctx.Input;
        });

        host1.SignalShutdown();
        TaskRun<string> run1 = await host1.Invoker.StartAsync<string, string>(
            "job", "payload", new RunOptions { TaskId = "j1" });
        Assert.ThrowsAsync<TaskDeferredException>(async () => await run1);
        Assert.That((await host1.Store.GetAsync("j1"))!.Status, Is.EqualTo("in_progress"));

        // New lifetime: no in-memory run. GetActiveRun must consult the store, inline-reclaim the
        // dead lease, re-invoke as recovered, and return a live handle (E7).
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);
        host2.Builder.AddTask<string, string>("job", (ctx, ct) => Task.FromResult("done:" + ctx.Input));

        TaskRun<string>? active = await host2.Invoker.GetActiveRunAsync<string>("job", "j1");
        Assert.That(active, Is.Not.Null);
        Assert.That(await active!.GetResultAsync(), Is.EqualTo("done:payload"));
    }

    [Test]
    public async Task OneShotGetActiveRunReturnsNullWhenNothingPersisted()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<string, string>("job", (ctx, ct) => Task.FromResult("x"));

        TaskRun<string>? active = await host.Invoker.GetActiveRunAsync<string>("job", "missing");
        Assert.That(active, Is.Null);
    }
}
