// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// The durability recovery loop is opt-in: it runs only when at least one task handler is
/// registered. With an empty registry the cold-start scan and periodic sweep stay inert so a
/// process that never uses resilient tasks does not list the task store on every boot/interval
/// (Python parity — no registered tasks means nothing to recover).
/// </summary>
[TestFixture]
public sealed class RecoveryLoopGatingTests
{
    [Test]
    public void HasRegisteredTasksReflectsRegistryState()
    {
        using var host = TaskTestHost.Create();
        Assert.That(host.Engine.HasRegisteredTasks, Is.False, "no handlers registered yet");

        host.Builder.AddTask<string, string>("t", (ctx, ct) => Task.FromResult(ctx.Input));

        Assert.That(host.Engine.HasRegisteredTasks, Is.True, "a handler is now registered");
    }

    [Test]
    public async Task EmptyRegistrySkipsColdStartScan()
    {
        using var host = TaskTestHost.Create();
        await SeedLegacyInProgressRecordAsync(host, "gated-1");

        var service = new TaskDurabilityService(
            new RecoveryScanner(host.Engine), host.Engine, scanInterval: TimeSpan.FromHours(1));

        await service.StartAsync();

        // The scan never listed the store, so the record the scan would otherwise have cleaned up
        // is left untouched — proof the recovery loop stayed inert with an empty registry.
        Assert.That(await host.Store.GetAsync("gated-1"), Is.Not.Null,
            "an empty registry must not trigger a store scan");

        await service.StopAsync();
    }

    [Test]
    public async Task NonEmptyRegistryRunsColdStartScan()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<string, string>("unrelated", (ctx, ct) => Task.FromResult(ctx.Input));
        await SeedLegacyInProgressRecordAsync(host, "gated-2");

        var service = new TaskDurabilityService(
            new RecoveryScanner(host.Engine), host.Engine, scanInterval: TimeSpan.FromHours(1));

        await service.StartAsync();

        // With a registered handler the cold-start scan runs and cleans up the legacy record.
        Assert.That(await host.Store.GetAsync("gated-2"), Is.Null,
            "a non-empty registry must run the startup recovery scan");

        await service.StopAsync();
    }

    // Seeds a pre-schema in_progress record (legacy wire format: no payload.schema_version) owned
    // by this engine. If the recovery scan runs, this record is force-deleted (legacy cleanup); if
    // the scan is skipped, it survives — making it a deterministic witness for whether the scan ran.
    private static Task SeedLegacyInProgressRecordAsync(TaskTestHost host, string id)
    {
        string owner = LeaseManager.FormatOwner(host.AgentName, host.SessionId);
        return host.Store.CreateAsync(new TaskCreateRequest
        {
            Id = id,
            AgentName = host.AgentName,
            SessionId = host.SessionId,
            Title = "Legacy",
            Status = "in_progress",
            LeaseOwner = owner,
            LeaseInstanceId = "old-worker",
            LeaseDurationSeconds = 60,
            Payload = new JsonObject
            {
                ["input"] = "stale",
                ["last_input_id"] = id,
                // NOTE: deliberately no schema_version — this is the legacy shape.
            },
            Source = new JsonObject
            {
                ["type"] = "agentserver.task",
                ["name"] = "legacy",
                ["server_version"] = "py/0.0.1",
            },
        });
    }
}
