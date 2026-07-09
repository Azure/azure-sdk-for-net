// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class OneShotRecoveryTests
{
    [Test]
    public async Task LeaseAbandonedMidRunIsReInvokedAsRecovered()
    {
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);

        // On the first (Fresh) entry, exit for recovery — leaving the record in_progress.
        host1.Builder.AddTask<string, string>("resumable", async (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                await ctx.ExitForRecoveryAsync(ct);
            }

            return $"done:{ctx.Input}:{ctx.EntryMode}";
        });

        // ExitForRecovery is gated on graceful shutdown — signal it before dispatch so the Fresh
        // turn may bail out for recovery (the documented production pattern; tasks-guide.md §4.11).
        host1.SignalShutdown();
        TaskRun<string> handle = await host1.Invoker.StartAsync<string, string>(
            "resumable", "payload", new RunOptions { TaskId = "rec-1" });

        // The Fresh attempt defers; the handle faults with TaskDeferred and the record stays in_progress.
        Assert.ThrowsAsync<TaskDeferredException>(async () => await handle);
        var midRecord = await host1.Store.GetAsync("rec-1");
        Assert.That(midRecord, Is.Not.Null);
        Assert.That(midRecord!.Status, Is.EqualTo("in_progress"));

        // Simulate a process restart: a new engine over the same store + a fresh registry.
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);
        host2.Builder.AddTask<string, string>("resumable", (ctx, ct) =>
            Task.FromResult($"done:{ctx.Input}:{ctx.EntryMode}"));

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));

        // The recovered run completes and the one-shot record is auto-deleted.
        await host2.WaitUntilDeletedAsync("rec-1", TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task LegacyInProgressTaskWithoutSchemaVersionIsDeletedNotRecovered()
    {
        var registry = new TaskRegistry();
        using var host = TaskTestHost.Create(sharedRegistry: registry);
        bool dispatchedHandler = false;
        host.Builder.AddTask<string, string>("legacy", (ctx, ct) =>
        {
            dispatchedHandler = true;
            return Task.FromResult(ctx.Input);
        });

        // Seed a pre-schema in_progress record (old wire format: no payload.schema_version),
        // owned by this engine and stamped with the framework's reserved source type/name.
        string owner = Azure.AI.AgentServer.Core.Tasks.Engine.LeaseManager.FormatOwner(host.AgentName, host.SessionId);
        await host.Store.CreateAsync(new Azure.AI.AgentServer.Core.Tasks.Providers.TaskCreateRequest
        {
            Id = "legacy-1",
            AgentName = host.AgentName,
            SessionId = host.SessionId,
            Title = "Legacy",
            Status = "in_progress",
            LeaseOwner = owner,
            LeaseInstanceId = "old-worker",
            LeaseDurationSeconds = 60,
            Payload = new System.Text.Json.Nodes.JsonObject
            {
                ["input"] = "stale",
                ["last_input_id"] = "legacy-1",
                // NOTE: deliberately no schema_version — this is the legacy shape.
            },
            Source = new System.Text.Json.Nodes.JsonObject
            {
                ["type"] = "agentserver.task",
                ["name"] = "legacy",
                ["server_version"] = "py/0.0.1",
            },
        });

        int dispatched = await host.Engine.ScanAndRecoverAsync();

        Assert.That(dispatched, Is.EqualTo(0), "legacy task must not be recovered/dispatched");
        Assert.That(dispatchedHandler, Is.False, "handler must not be invoked for a legacy task");
        Assert.That(await host.Store.GetAsync("legacy-1"), Is.Null, "legacy task must be deleted");
    }

    [Test]
    public async Task RecoveredRunObservesIncrementedRecoveryCount()
    {
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);
        host1.Builder.AddTask<string, string>("rc", async (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                await ctx.ExitForRecoveryAsync(ct);
            }

            return $"rc={ctx.RecoveryCount}";
        });

        host1.SignalShutdown();
        TaskRun<string> handle = await host1.Invoker.StartAsync<string, string>(
            "rc", "x", new RunOptions { TaskId = "rc-1" });
        Assert.ThrowsAsync<TaskDeferredException>(async () => await handle);

        // A fresh run reports recovery count 0.
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);
        int observedRecoveryCount = -1;
        host2.Builder.AddTask<string, string>("rc", (ctx, ct) =>
        {
            observedRecoveryCount = ctx.RecoveryCount;
            return Task.FromResult($"rc={ctx.RecoveryCount}");
        });

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));
        await host2.WaitUntilDeletedAsync("rc-1", TimeSpan.FromSeconds(5));

        // The reclaim bumped the lease generation from 0 to 1; recovery_count mirrors it (spec §22).
        Assert.That(observedRecoveryCount, Is.EqualTo(1));
    }
}
