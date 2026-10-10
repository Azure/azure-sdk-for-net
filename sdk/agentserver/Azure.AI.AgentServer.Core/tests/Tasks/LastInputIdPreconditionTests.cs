// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class LastInputIdPreconditionTests
{
    [Test]
    public async Task MismatchedIfLastInputIdRaisesTypedPreconditionFailure()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("seq", (ctx, ct) => Task.FromResult(ctx.Input));

        // Turn 1 establishes _last_input_id = "in-1". Await the turn handle (not just the
        // persisted "suspended" status): the durable suspend write lands before the in-memory
        // active-run entry is cleared, so gating on status alone can race turn 2 into the
        // "turn already in progress" conflict path instead of the store-level precondition check.
        TaskRun<string> turn1 = await host.Invoker.StartAsync<string, string>(
            "seq", "a", new RunOptions { TaskId = "s-1", InputId = "in-1" });
        await turn1.Completion;

        // Turn 2 with a stale precondition is rejected.
        var ex = Assert.ThrowsAsync<ResilientTaskException>(async () =>
            await host.Invoker.StartAsync<string, string>(
                "seq", "b", new RunOptions { TaskId = "s-1", InputId = "in-2", IfLastInputId = "wrong" }));
        Assert.That(ex!.ActualLastInputId, Is.EqualTo("in-1"));
    }

    [Test]
    public async Task MatchingIfLastInputIdDrivesNextTurn()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("seq2", (ctx, ct) => Task.FromResult(ctx.Input));

        TaskRun<string> turn1 = await host.Invoker.StartAsync<string, string>(
            "seq2", "a", new RunOptions { TaskId = "s-2", InputId = "in-1" });
        await turn1.Completion;

        TaskRun<string> t2 = await host.Invoker.StartAsync<string, string>(
            "seq2", "b", new RunOptions { TaskId = "s-2", InputId = "in-2", IfLastInputId = "in-1" });
        Assert.That(await t2.Completion, Is.EqualTo("b"));
    }

    [Test]
    public void IfLastInputIdWithoutInputIdIsArgumentErrorBeforeNetwork()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("seq3", (ctx, ct) => Task.FromResult(ctx.Input));

        Assert.ThrowsAsync<ArgumentException>(async () =>
            await host.Invoker.StartAsync<string, string>(
                "seq3", "a", new RunOptions { TaskId = "s-3", IfLastInputId = "in-1" }));
    }
}
