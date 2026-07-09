// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Conformance;

/// <summary>
/// Lease-arithmetic conformance run against BOTH backings (FR-019a / SC-011): the
/// in-memory Foundry-protocol harness (server-equivalent) and the filesystem
/// <see cref="LocalTaskStore"/> must produce identical reclaim/generation/expiry
/// results so recovery works without a live deployment.
/// </summary>
[TestFixture]
public sealed class LeaseArithmeticTests
{
    private string _tempDir = string.Empty;

    [SetUp]
    public void SetUp()
    {
        _tempDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "agentserver-lease-arith-" + Guid.NewGuid().ToString("N"));
        System.IO.Directory.CreateDirectory(_tempDir);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (System.IO.Directory.Exists(_tempDir))
            {
                System.IO.Directory.Delete(_tempDir, recursive: true);
            }
        }
        catch (System.IO.IOException)
        {
            // Best-effort cleanup.
        }
    }

    public enum Backing
    {
        Local,
        Hosted,
    }

    private ITaskStore CreateStore(Backing backing)
    {
        if (backing == Backing.Local)
        {
            return new LocalTaskStore(_tempDir);
        }

        var options = new HostedTaskStoreClientOptions { Transport = new FoundryProtocolHarness() };
        options.Retry.MaxRetries = 0;
        var pipeline = HttpPipelineBuilder.Build(options);
        return new HostedTaskStore(pipeline, new Uri("https://test.example.com/api/projects/proj/"));
    }

    private static TaskCreateRequest NewCreate(string id, string agentName = "agent-a", string sessionId = "sess-1") => new()
    {
        Id = id,
        AgentName = agentName,
        SessionId = sessionId,
        Title = "t",
        Payload = new System.Text.Json.Nodes.JsonObject { ["input"] = "hello" },
        Source = new System.Text.Json.Nodes.JsonObject
        {
            ["type"] = "agentserver.task",
            ["name"] = "demo",
            ["server_version"] = "x/1",
        },
    };

    [Test]
    public async Task ReacquireBySameOwnerNewInstanceBumpsGenerationWithoutExpiry([Values] Backing backing)
    {
        ITaskStore store = CreateStore(backing);
        await store.CreateAsync(NewCreate("g1"));

        // Owner derived from agentName + sessionId (the engine's stable lease owner).
        string owner = LeaseManager.FormatOwner("agent-a", "sess-1");

        TaskRecord acquired = await store.PatchAsync(
            "g1",
            new TaskPatchRequest { Status = "in_progress", LeaseOwner = owner, LeaseInstanceId = "inst-1", LeaseDurationSeconds = 3600 },
            null);
        Assert.That(acquired.Lease!.Generation, Is.EqualTo(0));
        Assert.That(acquired.Lease.ExpiryCount, Is.EqualTo(0));

        // Same owner, NEW instance (a process restart) reacquires the still-valid lease:
        // generation bumps (different instance) but the lease did not expire, so expiry_count stays.
        TaskRecord reacquired = await store.PatchAsync(
            "g1",
            new TaskPatchRequest { Status = "in_progress", LeaseOwner = owner, LeaseInstanceId = "inst-2", LeaseDurationSeconds = 3600 },
            null);
        Assert.That(reacquired.Lease!.Generation, Is.EqualTo(1));
        Assert.That(reacquired.Lease.ExpiryCount, Is.EqualTo(0));
        Assert.That(reacquired.Lease.InstanceId, Is.EqualTo("inst-2"));
    }

    [Test]
    public async Task DifferentOwnerExpiredTakeoverBumpsExpiryCountAndGeneration([Values] Backing backing)
    {
        ITaskStore store = CreateStore(backing);
        await store.CreateAsync(NewCreate("e1"));

        string owner1 = LeaseManager.FormatOwner("agent-a", "sess-1");
        await store.PatchAsync(
            "e1",
            new TaskPatchRequest { Status = "in_progress", LeaseOwner = owner1, LeaseInstanceId = "inst-1", LeaseDurationSeconds = 60 },
            null);

        // Force-expire (duration 0) by the same owner so a different owner can take over.
        await store.PatchAsync(
            "e1",
            new TaskPatchRequest { LeaseOwner = owner1, LeaseInstanceId = "inst-1", LeaseDurationSeconds = 0 },
            null);

        string owner2 = LeaseManager.FormatOwner("agent-b", "sess-2");
        TaskRecord takeover = await store.PatchAsync(
            "e1",
            new TaskPatchRequest { Status = "in_progress", LeaseOwner = owner2, LeaseInstanceId = "inst-9", LeaseDurationSeconds = 60 },
            null);
        Assert.That(takeover.Lease!.ExpiryCount, Is.EqualTo(1));
        Assert.That(takeover.Lease.Generation, Is.EqualTo(1));
        Assert.That(takeover.Lease.Owner, Is.EqualTo(owner2));
    }

    [Test]
    public async Task ListOwnInProgressByLeaseOwnerFiltersToOwnedRecords([Values] Backing backing)
    {
        ITaskStore store = CreateStore(backing);
        string owner = LeaseManager.FormatOwner("agent-a", "sess-1");

        await store.CreateAsync(NewCreate("o1"));
        await store.CreateAsync(NewCreate("o2"));
        await store.CreateAsync(NewCreate("o3"));

        await store.PatchAsync("o1", new TaskPatchRequest { Status = "in_progress", LeaseOwner = owner, LeaseInstanceId = "i", LeaseDurationSeconds = 3600 }, null);
        await store.PatchAsync("o2", new TaskPatchRequest { Status = "in_progress", LeaseOwner = "other-owner", LeaseInstanceId = "i", LeaseDurationSeconds = 3600 }, null);
        // o3 stays pending (no lease).

        TaskListResult owned = await store.ListAsync(new TaskListQuery
        {
            AgentName = "agent-a",
            SessionId = "sess-1",
            Status = "in_progress",
            LeaseOwner = owner,
        });

        Assert.That(owned.Items, Has.Count.EqualTo(1));
        Assert.That(owned.Items[0].Record.Id, Is.EqualTo("o1"));
    }

    [Test]
    public async Task CreateWithLeaseDurationPreservesLeaseAcrossBackings([Values] Backing backing)
    {
        // Regression (CR7): a create request carrying lease params + duration must
        // round-trip the lease so the server can compute an expiry — the duration
        // must not be dropped by the hosted serialization path.
        ITaskStore store = CreateStore(backing);
        string owner = LeaseManager.FormatOwner("agent-a", "sess-1");

        var create = NewCreate("c1");
        create.Status = "in_progress";
        create.LeaseOwner = owner;
        create.LeaseInstanceId = "inst-1";
        create.LeaseDurationSeconds = 3600;

        TaskRecord created = await store.CreateAsync(create);

        Assert.That(created.Lease, Is.Not.Null);
        Assert.That(created.Lease!.Owner, Is.EqualTo(owner));
        Assert.That(created.Lease.InstanceId, Is.EqualTo("inst-1"));
        // A non-zero duration produces a future expiry rather than an empty/expired lease.
        Assert.That(created.Lease.ExpiresAt, Is.Not.Empty);
    }
}
