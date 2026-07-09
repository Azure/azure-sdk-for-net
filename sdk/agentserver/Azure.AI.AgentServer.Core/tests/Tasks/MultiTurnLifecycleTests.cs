// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class MultiTurnLifecycleTests
{
    [Test]
    public async Task TurnsShareChainSuspendBetweenTurnsAndResumeWithNewInput()
    {
        using var host = TaskTestHost.Create();
        var entries = new List<(string Input, EntryMode Mode, string InputId)>();
        host.Builder.AddMultiTurnTask<string, string>("chat", (ctx, ct) =>
        {
            entries.Add((ctx.Input, ctx.EntryMode, ctx.InputId));
            return Task.FromResult(ctx.Input.ToUpperInvariant());
        });

        // Turn 1.
        TaskRun<string> t1 = await host.Invoker.StartAsync<string, string>(
            "chat", "hello", new RunOptions { TaskId = "chain-1" });
        Assert.That(await t1, Is.EqualTo("HELLO"));

        // The chain parks at suspended (not deleted, not completed).
        var suspended = await host.WaitForStatusAsync("chain-1", "suspended", TimeSpan.FromSeconds(5));
        Assert.That(suspended.Status, Is.EqualTo("suspended"));

        // Turn 2 against the same chain id resumes the chain. With input_id omitted, both turns'
        // context.input_id default to the task_id (Python parity: input_id defaults to task_id when
        // the caller omits it — no fabricated per-turn id).
        TaskRun<string> t2 = await host.Invoker.StartAsync<string, string>(
            "chat", "world", new RunOptions { TaskId = "chain-1" });
        Assert.That(await t2, Is.EqualTo("WORLD"));
        await host.WaitForStatusAsync("chain-1", "suspended", TimeSpan.FromSeconds(5));

        Assert.That(entries.Count, Is.EqualTo(2));
        Assert.That(entries[0].Mode, Is.EqualTo(EntryMode.Fresh));
        Assert.That(entries[1].Mode, Is.EqualTo(EntryMode.Resumed));
        Assert.That(entries[1].Input, Is.EqualTo("world"));
        Assert.That(entries[0].InputId, Is.EqualTo("chain-1"));
        Assert.That(entries[1].InputId, Is.EqualTo("chain-1"));
    }

    [Test]
    public async Task OmittedInputIdDoesNotPersistLastInputId()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("chat", (ctx, ct) => Task.FromResult(ctx.Input));

        // input_id omitted: context defaults to the task_id and last_input_id is NOT stamped
        // (Python parity: framework extras write last_input_id only for a caller-supplied id).
        await host.Invoker.StartAsync<string, string>("chat", "hi", new RunOptions { TaskId = "c-omit" });
        var suspended = await host.WaitForStatusAsync("c-omit", "suspended", TimeSpan.FromSeconds(5));
        Assert.That(suspended.Payload[TaskWireKeys.PayloadLastInputId], Is.Null);
    }

    [Test]
    public async Task SuppliedInputIdPersistsLastInputId()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("chat", (ctx, ct) => Task.FromResult(ctx.Input));

        await host.Invoker.StartAsync<string, string>(
            "chat", "hi", new RunOptions { TaskId = "c-supp", InputId = "given-1" });
        var suspended = await host.WaitForStatusAsync("c-supp", "suspended", TimeSpan.FromSeconds(5));
        Assert.That((string?)suspended.Payload[TaskWireKeys.PayloadLastInputId], Is.EqualTo("given-1"));
    }
}
