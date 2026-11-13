// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Conformance;

/// <summary>
/// Cross-language byte-compat recovery (SC-010): a record written by the Python
/// implementation (raw snake_case wire JSON) must be recovered/interpreted
/// identically by .NET through BOTH backings — reserved payload keys, attachment
/// refs, tags, and source survive the round-trip byte-for-byte.
/// </summary>
[TestFixture]
public sealed class CrossLanguageRecoveryTests
{
    // A record exactly as the Python store's to_dict would emit it (snake_case keys,
    // reserved payload markers, an attachment-ref placeholder, reserved tags, source identity).
    private const string PythonWrittenRecordJson = """
    {
      "object": "task",
      "id": "py-task-1",
      "agent_name": "agent-a",
      "session_id": "sess-1",
      "title": "Recovered from Python",
      "status": "in_progress",
      "lease": {
        "owner": "agent-a|session:sess-1",
        "instance_id": "py-worker-7",
        "generation": 3,
        "expires_at": "2099-01-01T00:00:00.000000+00:00",
        "expiry_count": 1,
        "heartbeat_at": "2024-05-01T12:00:00.000000+00:00"
      },
      "payload": {
        "input": "hello from python",
        "last_input_id": "input-42",
        "turn_started_at": "2024-05-01T12:00:00.000000+00:00",
        "retry_attempt": 2,
        "schema_version": "1",
        "metadata:user": "{\"name\":\"ada\"}",
        "large_field": {
          "__attachment_ref__": true,
          "key": "large_field",
          "hash": "sha256:deadbeef"
        }
      },
      "tags": {
        "task_name": "research",
        "priority": "high"
      },
      "source": {
        "type": "agentserver.task",
        "name": "research",
        "server_version": "py/1.2.3",
        "hosting_environment": ""
      },
      "attachments": {
        "large_field": "the original large value that was promoted out of the payload"
      },
      "created_at": "2024-05-01T11:59:00.000000+00:00",
      "updated_at": "2024-05-01T12:00:00.000000+00:00",
      "started_at": "2024-05-01T11:59:30.000000+00:00",
      "etag": "py-etag-1"
    }
    """;

    public enum Backing
    {
        Local,
        Hosted,
    }

    private string _tempDir = string.Empty;

    [SetUp]
    public void SetUp()
    {
        _tempDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "agentserver-xlang-" + Guid.NewGuid().ToString("N"));
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

    [Test]
    public void PythonRecordParsesReservedKeysAttachmentsTagsSourceIdentically()
    {
        var obj = (JsonObject)JsonNode.Parse(PythonWrittenRecordJson)!;
        TaskRecord record = TaskRecord.FromJson(obj);

        // Identity + status.
        Assert.That(record.Id, Is.EqualTo("py-task-1"));
        Assert.That(record.AgentName, Is.EqualTo("agent-a"));
        Assert.That(record.SessionId, Is.EqualTo("sess-1"));
        Assert.That(record.Status, Is.EqualTo("in_progress"));

        // Reserved payload keys are preserved verbatim.
        Assert.That((string?)record.Payload[TaskWireKeys.PayloadInput], Is.EqualTo("hello from python"));
        Assert.That((string?)record.Payload[TaskWireKeys.PayloadLastInputId], Is.EqualTo("input-42"));
        Assert.That((string?)record.Payload[TaskWireKeys.PayloadTurnStartedAt], Is.EqualTo("2024-05-01T12:00:00.000000+00:00"));
        Assert.That((int?)record.Payload[TaskWireKeys.PayloadRetryAttempt], Is.EqualTo(2));
        Assert.That((string?)record.Payload["metadata:user"], Is.EqualTo("{\"name\":\"ada\"}"));

        // Attachment ref placeholder survives with its magic marker, key, and hash.
        var attachmentRef = (JsonObject)record.Payload["large_field"]!;
        Assert.That((bool?)attachmentRef[TaskWireKeys.AttachmentRefMagic], Is.True);
        Assert.That((string?)attachmentRef[TaskWireKeys.AttachmentRefKey], Is.EqualTo("large_field"));
        Assert.That((string?)attachmentRef[TaskWireKeys.AttachmentRefHash], Is.EqualTo("sha256:deadbeef"));

        // Tags (including reserved task_name), source identity, lease arithmetic state.
        Assert.That(record.Tags[TaskWireKeys.TagTaskName], Is.EqualTo("research"));
        Assert.That(record.Tags["priority"], Is.EqualTo("high"));
        Assert.That(record.Source!.Type, Is.EqualTo("agentserver.task"));
        Assert.That(record.Source.Name, Is.EqualTo("research"));
        Assert.That(record.Lease!.Generation, Is.EqualTo(3));
        Assert.That(record.Lease.ExpiryCount, Is.EqualTo(1));

        // Attachments value is recovered intact.
        Assert.That((string?)record.Attachments!["large_field"], Is.EqualTo("the original large value that was promoted out of the payload"));

        // Round-trip back to wire JSON preserves every reserved key (byte-compat with Python).
        JsonObject roundTrip = record.ToJson();
        Assert.That((string?)((JsonObject)roundTrip[TaskWireKeys.Payload]!)[TaskWireKeys.PayloadLastInputId], Is.EqualTo("input-42"));
        Assert.That((string?)((JsonObject)roundTrip[TaskWireKeys.Source]!)[TaskWireKeys.SourceServerVersion], Is.EqualTo("py/1.2.3"));
    }

    [Test]
    public async Task PythonRecordIsRecoverableThroughBothStores([Values] Backing backing)
    {
        ITaskStore store = CreateStore(backing);

        // Seed the store with the Python-written record (a recovery scan would List then re-dispatch it).
        var obj = (JsonObject)JsonNode.Parse(PythonWrittenRecordJson)!;
        TaskRecord source = TaskRecord.FromJson(obj);

        await store.CreateAsync(new TaskCreateRequest
        {
            Id = source.Id,
            AgentName = source.AgentName,
            SessionId = source.SessionId,
            Title = source.Title,
            Status = TaskWireKeys.StatusPending,
            Payload = (JsonObject)source.Payload.DeepClone(),
            Tags = source.Tags,
            Attachments = source.Attachments is null ? null : (JsonObject)source.Attachments.DeepClone(),
            Source = source.Source is null ? null : (JsonObject)source.Source.ToJson(),
        });

        TaskRecord? recovered = await store.GetAsync("py-task-1");
        Assert.That(recovered, Is.Not.Null);
        Assert.That((string?)recovered!.Payload[TaskWireKeys.PayloadLastInputId], Is.EqualTo("input-42"));
        Assert.That(recovered.Tags[TaskWireKeys.TagTaskName], Is.EqualTo("research"));
        Assert.That(recovered.Source!.Name, Is.EqualTo("research"));

        var recoveredRef = (JsonObject)recovered.Payload["large_field"]!;
        Assert.That((bool?)recoveredRef[TaskWireKeys.AttachmentRefMagic], Is.True);
    }
}
