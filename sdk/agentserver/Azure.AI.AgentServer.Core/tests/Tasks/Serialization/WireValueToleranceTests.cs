// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Serialization;

/// <summary>
/// Guards the wire parsers against a hosted Task Storage service that serializes
/// timestamp fields as JSON numbers (epoch) rather than the ISO-8601 strings the
/// protocol spec declares. The framework never interprets these timestamps on the
/// hosted path (the server owns lease arithmetic), so the parser MUST tolerate the
/// numeric form instead of throwing — matching the Python implementation, which
/// stores whatever the service returns. Regression guard for the hosted-deploy
/// crash where <c>(string?)</c> casting a JSON Number threw
/// <c>InvalidOperationException</c> and failed every response create.
/// </summary>
/// <remarks>
/// Fixtures are parsed from JSON text (not built from CLR primitives) so the
/// <see cref="JsonNode"/> tree is JsonElement-backed exactly like the production
/// path, where <c>HostedTaskStore.ParseRecordResponse</c> parses the raw response body.
/// </remarks>
[TestFixture]
public class WireValueToleranceTests
{
    [Test]
    public void LeaseFromJsonToleratesNumericExpiresAtAndHeartbeat()
    {
        // Hosted service returned epoch numbers for expires_at/heartbeat_at instead
        // of ISO-8601 strings.
        const string json = """
        {
          "owner": "session:abc",
          "instance_id": "worker-1-deadbeef-123",
          "generation": 3,
          "expires_at": 1784003571,
          "expiry_count": 1,
          "heartbeat_at": 1784003511
        }
        """;
        var obj = JsonNode.Parse(json)!.AsObject();

        var lease = Lease.FromJson(obj);

        Assert.That(lease, Is.Not.Null);
        Assert.That(lease!.Owner, Is.EqualTo("session:abc"));
        Assert.That(lease.InstanceId, Is.EqualTo("worker-1-deadbeef-123"));
        Assert.That(lease.Generation, Is.EqualTo(3));
        Assert.That(lease.ExpiresAt, Is.EqualTo("1784003571"));
        Assert.That(lease.ExpiryCount, Is.EqualTo(1));
        Assert.That(lease.HeartbeatAt, Is.EqualTo("1784003511"));
    }

    [Test]
    public void LeaseFromJsonStillParsesIsoStringTimestamps()
    {
        const string json = """
        {
          "owner": "session:abc",
          "instance_id": "worker-1",
          "generation": 0,
          "expires_at": "2026-05-02T10:31:00Z",
          "expiry_count": 0,
          "heartbeat_at": "2026-05-02T10:30:45Z"
        }
        """;
        var obj = JsonNode.Parse(json)!.AsObject();

        var lease = Lease.FromJson(obj);

        Assert.That(lease, Is.Not.Null);
        Assert.That(lease!.ExpiresAt, Is.EqualTo("2026-05-02T10:31:00Z"));
        Assert.That(lease.HeartbeatAt, Is.EqualTo("2026-05-02T10:30:45Z"));
    }

    [Test]
    public void TaskRecordFromJsonToleratesNumericTimestamps()
    {
        const string json = """
        {
          "object": "task",
          "id": "task-1",
          "agent_name": "agent",
          "session_id": "sess",
          "status": "in_progress",
          "created_at": 1784003500,
          "updated_at": 1784003530,
          "started_at": 1784003505,
          "completed_at": null,
          "etag": "etag-1"
        }
        """;
        var obj = JsonNode.Parse(json)!.AsObject();

        var record = TaskRecord.FromJson(obj);

        Assert.That(record.Id, Is.EqualTo("task-1"));
        Assert.That(record.CreatedAt, Is.EqualTo("1784003500"));
        Assert.That(record.UpdatedAt, Is.EqualTo("1784003530"));
        Assert.That(record.StartedAt, Is.EqualTo("1784003505"));
        Assert.That(record.CompletedAt, Is.Null);
    }

    [Test]
    public void TaskRecordFromJsonStillParsesIsoStringTimestamps()
    {
        const string json = """
        {
          "object": "task",
          "id": "task-2",
          "agent_name": "agent",
          "session_id": "sess",
          "status": "completed",
          "created_at": "2026-05-02T10:30:00Z",
          "updated_at": "2026-05-02T10:30:30Z",
          "started_at": "2026-05-02T10:30:05Z",
          "completed_at": "2026-05-02T10:31:00Z",
          "etag": "etag-2"
        }
        """;
        var obj = JsonNode.Parse(json)!.AsObject();

        var record = TaskRecord.FromJson(obj);

        Assert.That(record.CreatedAt, Is.EqualTo("2026-05-02T10:30:00Z"));
        Assert.That(record.UpdatedAt, Is.EqualTo("2026-05-02T10:30:30Z"));
        Assert.That(record.StartedAt, Is.EqualTo("2026-05-02T10:30:05Z"));
        Assert.That(record.CompletedAt, Is.EqualTo("2026-05-02T10:31:00Z"));
    }
}
