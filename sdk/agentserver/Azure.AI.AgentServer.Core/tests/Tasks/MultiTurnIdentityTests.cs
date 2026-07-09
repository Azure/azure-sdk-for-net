// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class MultiTurnIdentityTests
{
    [Test]
    public void MultiTurnWithoutTaskIdIsArgumentErrorBeforeNetwork()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("needs-id", (ctx, ct) => Task.FromResult(ctx.Input));

        Assert.ThrowsAsync<ArgumentException>(async () =>
            await host.Invoker.RunAsync<string, string>("needs-id", "a"));
        Assert.ThrowsAsync<ArgumentException>(async () =>
            await host.Invoker.StartAsync<string, string>("needs-id", "a"));
    }

    [Test]
    public async Task OneShotAutoGeneratesTaskId()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<string, string>("auto-id", (ctx, ct) => Task.FromResult(ctx.Input));

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>("auto-id", "a");
        Assert.That(run.TaskId, Is.Not.Null.And.Not.Empty);
        await run;
    }
}
