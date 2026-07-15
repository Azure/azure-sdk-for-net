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

        // Turn 2 against the same chain id resumes the chain. With input_id omitted, each turn of a
        // chain gets its OWN unique auto-generated per-turn input_id (FR-005: "per-turn
        // auto-generated GUID for multi-turn unless supplied") — the two turns' ids differ and
        // neither equals the chain's task_id.
        TaskRun<string> t2 = await host.Invoker.StartAsync<string, string>(
            "chat", "world", new RunOptions { TaskId = "chain-1" });
        Assert.That(await t2, Is.EqualTo("WORLD"));
        await host.WaitForStatusAsync("chain-1", "suspended", TimeSpan.FromSeconds(5));

        Assert.That(entries.Count, Is.EqualTo(2));
        Assert.That(entries[0].Mode, Is.EqualTo(EntryMode.Fresh));
        Assert.That(entries[1].Mode, Is.EqualTo(EntryMode.Resumed));
        Assert.That(entries[1].Input, Is.EqualTo("world"));
        // Each turn observes a distinct, auto-generated per-turn input_id — never the task_id.
        Assert.That(entries[0].InputId, Is.Not.Null.And.Not.Empty);
        Assert.That(entries[1].InputId, Is.Not.Null.And.Not.Empty);
        Assert.That(entries[0].InputId, Is.Not.EqualTo("chain-1"));
        Assert.That(entries[1].InputId, Is.Not.EqualTo("chain-1"));
        Assert.That(entries[1].InputId, Is.Not.EqualTo(entries[0].InputId));
    }

    [Test]
    public async Task OmittedInputIdGeneratesAndPersistsPerTurnLastInputId()
    {
        using var host = TaskTestHost.Create();
        string? observedInputId = null;
        host.Builder.AddMultiTurnTask<string, string>("chat", (ctx, ct) =>
        {
            observedInputId = ctx.InputId;
            return Task.FromResult(ctx.Input);
        });

        // input_id omitted on a multi-turn chain: the framework auto-generates a unique per-turn
        // input_id and stamps it as the chain's last_input_id (the chain head always advances),
        // so a subsequent turn can pin it via ifLastInputId. The handle exposes the same id.
        TaskRun<string> t1 = await host.Invoker.StartAsync<string, string>(
            "chat", "hi", new RunOptions { TaskId = "c-omit" });
        await t1;
        var suspended = await host.WaitForStatusAsync("c-omit", "suspended", TimeSpan.FromSeconds(5));

        string? persisted = (string?)suspended.Payload[TaskWireKeys.PayloadLastInputId];
        Assert.That(persisted, Is.Not.Null.And.Not.Empty);
        Assert.That(persisted, Is.Not.EqualTo("c-omit"));
        Assert.That(persisted, Is.EqualTo(observedInputId));
        Assert.That(t1.InputId, Is.EqualTo(observedInputId));
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
