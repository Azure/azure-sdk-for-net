// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Engine;

[TestFixture]
public sealed class LeaseManagerTests
{
    private string _tempDir = string.Empty;
    private LocalTaskStore _store = null!;
    private TaskWriteSerializer _serializer = null!;
    private LeaseManager _lease = null!;

    [SetUp]
    public async Task SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "agentserver-lease-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
        _store = new LocalTaskStore(_tempDir);
        _serializer = new TaskWriteSerializer(_store);
        _lease = new LeaseManager(_serializer);

        var created = await _store.CreateAsync(new TaskCreateRequest
        {
            Id = "t",
            AgentName = "agent-a",
            SessionId = "sess-1",
            Title = "t",
            Payload = new JsonObject(),
            Source = new JsonObject { ["type"] = "agentserver.task", ["name"] = "demo", ["server_version"] = "x/1" },
        });
        _serializer.Track(created);
    }

    [TearDown]
    public void TearDown()
    {
        _serializer.Dispose();
        try
        {
            Directory.Delete(_tempDir, recursive: true);
        }
        catch (IOException)
        {
        }
    }

    [Test]
    public void OwnerFormatMatchesContract()
        => Assert.That(LeaseManager.FormatOwner("agent-a", "sess-1"), Is.EqualTo("agent-a|session:sess-1"));

    [Test]
    public void InstanceIdHasExpectedShape()
    {
        string id = LeaseManager.NewInstanceId();
        // worker-<pid>-<rand8hex>-<unixSeconds>
        Assert.That(id, Does.Match("^worker-[0-9]+-[0-9a-f]{8}-[0-9]+$"));
    }

    [Test]
    public async Task AcquireSetsLeaseAndTransitionsToInProgress()
    {
        string owner = LeaseManager.FormatOwner("agent-a", "sess-1");
        var record = await _lease.AcquireAsync("t", owner, durationSeconds: 60);
        Assert.That(record.Status, Is.EqualTo(TaskWireKeys.StatusInProgress));
        Assert.That(record.Lease, Is.Not.Null);
        Assert.That(record.Lease!.Owner, Is.EqualTo(owner));
        Assert.That(record.Lease.InstanceId, Is.EqualTo(_lease.InstanceId));
    }

    [Test]
    public async Task HeartbeatRenewsLease()
    {
        string owner = LeaseManager.FormatOwner("agent-a", "sess-1");
        await _lease.AcquireAsync("t", owner, 60);
        var renewed = await _lease.HeartbeatAsync("t", owner, 60);
        Assert.That(renewed.Lease!.HeartbeatAt, Is.Not.Null);
    }
}
