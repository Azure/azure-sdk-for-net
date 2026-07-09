// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class MultiTurnHotReclaimTests
{
    [Test]
    public async Task HotStartOfCrashedMultiTurnReclaimsDeadLeaseAndRecovers()
    {
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);
        host1.Builder.AddMultiTurnTask<string, string>(
            "chat",
            async (ctx, ct) =>
            {
                if (ctx.EntryMode == EntryMode.Fresh)
                {
                    await ctx.ExitForRecoveryAsync(ct);
                    return "unreached";
                }

                return "recovered:" + ctx.Input;
            });

        host1.SignalShutdown();
        TaskRun<string> run1 = await host1.Invoker.StartAsync<string, string>(
            "chat", "hello", new RunOptions { TaskId = "t1", InputId = "i1" });
        Assert.ThrowsAsync<TaskDeferredException>(async () => await run1);
        TaskRecord? mid = await host1.Store.GetAsync("t1");
        Assert.That(mid, Is.Not.Null);
        Assert.That(mid!.Status, Is.EqualTo("in_progress"));

        // New lifetime: no in-memory active entry, lease owned by us but dead. A hot StartAsync
        // must inline-reclaim and re-enter the in-flight turn as Recovered (E1), not throw.
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);
        EntryMode observed = EntryMode.Fresh;
        host2.Builder.AddMultiTurnTask<string, string>(
            "chat",
            (ctx, ct) =>
            {
                observed = ctx.EntryMode;
                return Task.FromResult("recovered:" + ctx.Input);
            });

        TaskRun<string> run2 = await host2.Invoker.StartAsync<string, string>(
            "chat", "ignored", new RunOptions { TaskId = "t1", InputId = "i2" });
        string result = await run2.GetResultAsync();

        Assert.That(observed, Is.EqualTo(EntryMode.Recovered));
        // Recovery re-invokes the persisted in-flight turn (input "hello"/id "i1"), not the
        // caller's superseding "ignored"/"i2".
        Assert.That(result, Is.EqualTo("recovered:hello"));
    }

    [Test]
    public async Task HotStartOfForeignOwnedInProgressThrowsConflict()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>(
            "chat", (ctx, ct) => Task.FromResult("ok"));

        // Seed an in_progress record owned by a DIFFERENT agent/session lease owner.
        var payload = new JsonObject
        {
            [TaskWireKeys.PayloadInput] = "hello",
            [TaskWireKeys.PayloadLastInputId] = "i1",
            [TaskWireKeys.PayloadTurnStartedAt] = DateTimeOffset.UtcNow.ToString("O"),
            [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue,
        };
        await host.Store.CreateAsync(new TaskCreateRequest
        {
            Id = "t2",
            AgentName = host.AgentName,
            SessionId = host.SessionId,
            Title = "chat",
            Status = TaskWireKeys.StatusInProgress,
            LeaseOwner = "someone-else|session:other",
            LeaseInstanceId = "worker-foreign",
            LeaseDurationSeconds = TaskEngineConstants.LeaseDurationSeconds,
            Payload = payload,
            Source = new JsonObject
            {
                [TaskWireKeys.SourceType] = TaskWireKeys.SourceTypeValue,
                [TaskWireKeys.SourceName] = "chat",
            },
        });

        Assert.ThrowsAsync<TaskConflictException>(async () =>
            await host.Invoker.StartAsync<string, string>(
                "chat", "x", new RunOptions { TaskId = "t2", InputId = "i9" }));
    }
}
