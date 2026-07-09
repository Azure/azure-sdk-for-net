// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Conformance;

/// <summary>
/// Shared provider-conformance suite exercised against every <see cref="ITaskStore"/>
/// implementation (Local and Hosted) so both produce identical accept/reject
/// decisions, lease arithmetic, ETag behavior, and status side-effects
/// (FR-019a / SC-011).
/// </summary>
public abstract class TaskStoreConformanceTestsBase
{
    /// <summary>Creates a fresh, isolated store instance for a test.</summary>
    /// <returns>A new <see cref="ITaskStore"/>.</returns>
    private protected abstract ITaskStore CreateStore();

    private static TaskCreateRequest NewCreate(string id, string? status = null) => new()
    {
        Id = id,
        AgentName = "agent-a",
        SessionId = "sess-1",
        Title = "t",
        Status = status,
        Payload = new JsonObject { ["input"] = "hello" },
        Source = new JsonObject { ["type"] = "agentserver.task", ["name"] = "demo", ["server_version"] = "x/1" },
    };

    [Test]
    public void CreateWithoutTitleIsRejected()
    {
        var store = CreateStore();
        var req = NewCreate("t-notitle");
        req.Title = null;
        Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(req));
    }

    [Test]
    public void CreateWithWhitespaceTitleIsRejected()
    {
        var store = CreateStore();
        var req = NewCreate("t-wstitle");
        req.Title = "   ";
        Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(req));
    }

    [Test]
    public async Task ErrorPatchRequiresMessageAndType()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t-err"));

        // Missing message/type is rejected.
        Assert.ThrowsAsync<TaskStoreException>(async () => await store.PatchAsync("t-err", new TaskPatchRequest
        {
            Error = new JsonObject { ["code"] = "boom" },
        }, null));

        // A well-formed error is accepted.
        var patched = await store.PatchAsync("t-err", new TaskPatchRequest
        {
            Error = new JsonObject { ["message"] = "kaboom", ["type"] = "RuntimeError" },
        }, null);
        Assert.That((string?)patched.Error?["message"], Is.EqualTo("kaboom"));
    }

    [Test]
    public async Task ErrorPatchDefaultsMissingCode()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t-errcode"));

        var patched = await store.PatchAsync("t-errcode", new TaskPatchRequest
        {
            Error = new JsonObject { ["message"] = "kaboom", ["type"] = "RuntimeError" },
        }, null);

        // code defaults to "error" when omitted (C-VAL-8).
        Assert.That((string?)patched.Error?["code"], Is.EqualTo("error"));
    }

    [Test]
    public async Task CreateThenGetRoundTrips()
    {
        var store = CreateStore();
        var created = await store.CreateAsync(NewCreate("t1"));
        Assert.That(created.Status, Is.EqualTo("pending"));
        Assert.That(created.Etag, Is.Not.Null);

        var fetched = await store.GetAsync("t1");
        Assert.That(fetched, Is.Not.Null);
        Assert.That((string?)fetched!.Payload["input"], Is.EqualTo("hello"));
    }

    [Test]
    public async Task GetMissingReturnsNull()
    {
        var store = CreateStore();
        Assert.That(await store.GetAsync("nope"), Is.Null);
    }

    [Test]
    public async Task DuplicateCreateConflicts()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("dup"));
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(NewCreate("dup")));
        Assert.That(ex!.StatusCode, Is.EqualTo(409));
    }

    [Test]
    public async Task PendingCreateWithLeaseRejected()
    {
        var store = CreateStore();
        var req = NewCreate("t2");
        req.LeaseOwner = "agent-a|session:sess-1";
        req.LeaseInstanceId = "worker-1";
        req.LeaseDurationSeconds = 30;
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(req));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));
    }

    [Test]
    public async Task LeaseAcquireOnInProgressSetsStartedAt()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t3"));
        var patched = await store.PatchAsync("t3", new TaskPatchRequest
        {
            Status = "in_progress",
            LeaseOwner = "agent-a|session:sess-1",
            LeaseInstanceId = "worker-1",
            LeaseDurationSeconds = 30,
        }, ifMatch: null);

        Assert.That(patched.Status, Is.EqualTo("in_progress"));
        Assert.That(patched.StartedAt, Is.Not.Null);
        Assert.That(patched.Lease, Is.Not.Null);
        Assert.That(patched.Lease!.HeartbeatAt, Is.Not.Null);
    }

    [Test]
    public async Task LeaseHeldByDifferentOwnerConflicts()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t4"));
        await store.PatchAsync("t4", new TaskPatchRequest
        {
            Status = "in_progress",
            LeaseOwner = "owner-1",
            LeaseInstanceId = "worker-1",
            LeaseDurationSeconds = 3600,
        }, null);

        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.PatchAsync("t4", new TaskPatchRequest
        {
            LeaseOwner = "owner-2",
            LeaseInstanceId = "worker-2",
            LeaseDurationSeconds = 3600,
        }, null));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeLeaseHeld));
    }

    [Test]
    public async Task PayloadObjectPatchShallowMerges()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t5"));
        var patched = await store.PatchAsync("t5", new TaskPatchRequest
        {
            PayloadSupplied = true,
            Payload = new JsonObject { ["extra"] = 1 },
        }, null);

        Assert.That((string?)patched.Payload["input"], Is.EqualTo("hello"));
        Assert.That((int?)patched.Payload["extra"], Is.EqualTo(1));
    }

    [Test]
    public async Task PayloadNonObjectPatchFullReplaces()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t5b"));

        // A non-object payload value (here an array) full-replaces the payload (spec §F1 /
        // C-VAL-11) rather than being wrapped under a reserved key.
        var patched = await store.PatchAsync("t5b", new TaskPatchRequest
        {
            PayloadSupplied = true,
            Payload = new JsonArray(1, 2, 3),
        }, null);

        Assert.That(patched.Payload, Is.TypeOf<JsonArray>());
        Assert.That(((JsonArray)patched.Payload).Count, Is.EqualTo(3));
    }

    [Test]
    public async Task PayloadNullPatchIsNoOp()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t5c"));

        var patched = await store.PatchAsync("t5c", new TaskPatchRequest
        {
            PayloadSupplied = true,
            Payload = null,
        }, null);

        Assert.That((string?)patched.Payload["input"], Is.EqualTo("hello"));
    }

    [Test]
    public async Task SuspendThenResume()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t6"));
        await store.PatchAsync("t6", new TaskPatchRequest
        {
            Status = "in_progress",
            LeaseOwner = "o",
            LeaseInstanceId = "w",
            LeaseDurationSeconds = 60,
        }, null);

        var suspended = await store.PatchAsync("t6", new TaskPatchRequest { Status = "suspended", SuspensionReason = "await-input" }, null);
        Assert.That(suspended.Status, Is.EqualTo("suspended"));
        Assert.That(suspended.SuspensionReason, Is.EqualTo("await-input"));
        Assert.That(suspended.Lease, Is.Null);

        var resumed = await store.PatchAsync("t6", new TaskPatchRequest
        {
            Status = "in_progress",
            LeaseOwner = "o",
            LeaseInstanceId = "w",
            LeaseDurationSeconds = 60,
        }, null);
        Assert.That(resumed.Status, Is.EqualTo("in_progress"));
    }

    [Test]
    public async Task CompleteIsTerminalAndImmutable()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t7"));
        await store.PatchAsync("t7", new TaskPatchRequest { Status = "in_progress", LeaseOwner = "o", LeaseInstanceId = "w", LeaseDurationSeconds = 60 }, null);
        var completed = await store.PatchAsync("t7", new TaskPatchRequest { Status = "completed" }, null);
        Assert.That(completed.Status, Is.EqualTo("completed"));
        Assert.That(completed.CompletedAt, Is.Not.Null);

        // Same-status no-op succeeds.
        var noop = await store.PatchAsync("t7", new TaskPatchRequest { Status = "completed" }, null);
        Assert.That(noop.Status, Is.EqualTo("completed"));

        // A mutating patch is rejected.
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.PatchAsync("t7",
            new TaskPatchRequest { PayloadSupplied = true, Payload = new JsonObject { ["x"] = 1 } }, null));
        Assert.That(ex!.StatusCode, Is.EqualTo(409));
    }

    [Test]
    public async Task InvalidTransitionRejected()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t8"));
        // pending -> suspended is not a valid transition (spec §7.3: pending -> {in_progress, completed}).
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.PatchAsync("t8", new TaskPatchRequest { Status = "suspended" }, null));
        Assert.That(ex!.StatusCode, Is.EqualTo(409));
    }

    [Test]
    public async Task EtagMismatchRejected()
    {
        var store = CreateStore();
        var created = await store.CreateAsync(NewCreate("t9"));
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.PatchAsync("t9",
            new TaskPatchRequest { PayloadSupplied = true, Payload = new JsonObject { ["x"] = 1 } }, ifMatch: "local-wrongetag"));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeEtagMismatch));

        // Correct etag succeeds.
        var ok = await store.PatchAsync("t9", new TaskPatchRequest { PayloadSupplied = true, Payload = new JsonObject { ["x"] = 1 } }, ifMatch: created.Etag);
        Assert.That((int?)ok.Payload["x"], Is.EqualTo(1));
    }

    [Test]
    public async Task ForceExpireThenReacquireBumpsExpiryCount()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("t10"));
        await store.PatchAsync("t10", new TaskPatchRequest { Status = "in_progress", LeaseOwner = "o1", LeaseInstanceId = "w1", LeaseDurationSeconds = 60 }, null);

        // Force-expire by the same owner.
        await store.PatchAsync("t10", new TaskPatchRequest { LeaseOwner = "o1", LeaseInstanceId = "w1", LeaseDurationSeconds = 0 }, null);

        // A different owner reacquires the now-expired lease: expiry_count bumps, generation bumps.
        var reacquired = await store.PatchAsync("t10", new TaskPatchRequest { LeaseOwner = "o2", LeaseInstanceId = "w2", LeaseDurationSeconds = 60 }, null);
        Assert.That(reacquired.Lease!.ExpiryCount, Is.EqualTo(1));
        Assert.That(reacquired.Lease.Generation, Is.EqualTo(1));
    }

    [Test]
    public async Task ListFiltersByStatusAndPaginates()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("la"));
        await store.CreateAsync(NewCreate("lb"));
        await store.PatchAsync("lb", new TaskPatchRequest { Status = "in_progress", LeaseOwner = "o", LeaseInstanceId = "w", LeaseDurationSeconds = 60 }, null);

        var inProgress = await store.ListAsync(new TaskListQuery { Status = "in_progress" });
        Assert.That(inProgress.Items, Has.Count.EqualTo(1));
        Assert.That(inProgress.Items[0].Record.Id, Is.EqualTo("lb"));

        var all = await store.ListAsync(new TaskListQuery { AgentName = "agent-a", SessionId = "sess-1" });
        Assert.That(all.Items, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task ListFiltersByTagRoundTripsThroughTheStore()
    {
        // Exercises the full tag-filter path end-to-end (query encoding → transport → filtering),
        // locking in the `tag.<key>=<value>` wire shape for the hosted store.
        var store = CreateStore();

        var tagged = NewCreate("tg-hi");
        tagged.Tags = new System.Collections.Generic.Dictionary<string, string> { ["priority"] = "high" };
        await store.CreateAsync(tagged);

        var other = NewCreate("tg-lo");
        other.Tags = new System.Collections.Generic.Dictionary<string, string> { ["priority"] = "low" };
        await store.CreateAsync(other);

        var high = await store.ListAsync(new TaskListQuery
        {
            Tags = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>
            {
                new("priority", "high"),
            },
        });

        Assert.That(high.Items, Has.Count.EqualTo(1));
        Assert.That(high.Items[0].Record.Id, Is.EqualTo("tg-hi"));
    }

    [Test]
    public async Task ContractFieldLimitsMatchProtocolSpec()
    {
        // The authoritative foundry-task-storage-protocol-spec fixes these ceilings; a record at the
        // limit is accepted and one byte over is rejected. Values must match the spec (and the Python
        // reference) exactly so the hosted store never rejects a record the local store accepted.
        var store = CreateStore();

        // description: 1024 OK, 1025 rejected.
        var descOk = NewCreate("desc-ok");
        descOk.Description = new string('d', 1024);
        Assert.DoesNotThrowAsync(async () => await store.CreateAsync(descOk));

        var descBad = NewCreate("desc-bad");
        descBad.Description = new string('d', 1025);
        var ex1 = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(descBad));
        Assert.That(ex1!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));

        // agent_name: 128 OK, 129 rejected.
        var agentOk = NewCreate("agent-ok");
        agentOk.AgentName = new string('a', 128);
        Assert.DoesNotThrowAsync(async () => await store.CreateAsync(agentOk));

        var agentBad = NewCreate("agent-bad");
        agentBad.AgentName = new string('a', 129);
        var ex2 = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(agentBad));
        Assert.That(ex2!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));

        // session_id: 128 OK, 129 rejected.
        var sessOk = NewCreate("sess-ok");
        sessOk.SessionId = new string('s', 128);
        Assert.DoesNotThrowAsync(async () => await store.CreateAsync(sessOk));

        var sessBad = NewCreate("sess-bad");
        sessBad.SessionId = new string('s', 129);
        var ex3 = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(sessBad));
        Assert.That(ex3!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));
    }

    [Test]
    public async Task DeleteRemovesTask()
    {
        var store = CreateStore();
        await store.CreateAsync(NewCreate("td"));

        // Deleting a non-terminal task without force is rejected with invalid_request (spec §24.3).
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.DeleteAsync("td"));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));

        // Force delete removes the non-terminal task.
        await store.DeleteAsync("td", force: true);
        Assert.That(await store.GetAsync("td"), Is.Null);
    }

    [Test]
    public async Task OversizedTitleRejected()
    {
        var store = CreateStore();
        var req = NewCreate("tbig");
        req.Title = new string('x', 1000);
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(req));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));
    }

    [Test]
    public async Task InvalidTaskIdRejected()
    {
        var store = CreateStore();
        var req = NewCreate("bad id!");
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(req));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));
    }

    [Test]
    public async Task CreateWithCompletedStatusRejected()
    {
        // Create-status is restricted to pending|in_progress (spec §7.1); completed/suspended are rejected.
        var store = CreateStore();
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(NewCreate("cs1", status: "completed")));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));

        var ex2 = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(NewCreate("cs2", status: "suspended")));
        Assert.That(ex2!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));
    }

    [Test]
    public async Task PendingToCompletedTransitionAllowed()
    {
        // Spec §7.3 state table: pending -> completed is a legal transition.
        var store = CreateStore();
        await store.CreateAsync(NewCreate("pc1"));
        var completed = await store.PatchAsync("pc1", new TaskPatchRequest { Status = "completed" }, null);
        Assert.That(completed.Status, Is.EqualTo("completed"));
    }

    [Test]
    public async Task SuspendedToPendingTransitionAllowed()
    {
        // Spec §7.3 state table: suspended -> pending is a legal transition.
        var store = CreateStore();
        await store.CreateAsync(NewCreate("sp1"));
        await store.PatchAsync("sp1", new TaskPatchRequest { Status = "in_progress", LeaseOwner = "o", LeaseInstanceId = "w", LeaseDurationSeconds = 60 }, null);
        await store.PatchAsync("sp1", new TaskPatchRequest { Status = "suspended" }, null);
        var pending = await store.PatchAsync("sp1", new TaskPatchRequest { Status = "pending" }, null);
        Assert.That(pending.Status, Is.EqualTo("pending"));
    }

    [Test]
    public async Task InvalidTagKeyRejected()
    {
        // Tag keys must match [a-zA-Z0-9_.-]+ (Python _validation parity).
        var store = CreateStore();
        var req = NewCreate("tag1");
        req.Tags = new System.Collections.Generic.Dictionary<string, string> { ["bad key!"] = "v" };
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(req));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));
    }

    [Test]
    public async Task SourceWithoutTypeRejected()
    {
        // source.type is required when source is provided (Python _validation parity).
        var store = CreateStore();
        var req = NewCreate("src1");
        req.Source = new JsonObject { ["name"] = "demo" };
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.CreateAsync(req));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));
    }

    [Test]
    public async Task OversizedLeaseIdentityRejected()
    {
        // lease owner/instance_id are capped at 256 chars (Python _validation parity).
        var store = CreateStore();
        await store.CreateAsync(NewCreate("li1"));
        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.PatchAsync("li1", new TaskPatchRequest
        {
            Status = "in_progress",
            LeaseOwner = new string('o', 257),
            LeaseInstanceId = "w",
            LeaseDurationSeconds = 30,
        }, null));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));
    }

    [Test]
    public async Task InvalidAttachmentKeyRejected()
    {
        // Attachment keys must match [a-zA-Z0-9_.-]{1,64} (C-ATT-8 / Python validate_attachment_key).
        var store = CreateStore();
        await store.CreateAsync(NewCreate("att1"));
        await store.PatchAsync("att1", new TaskPatchRequest { Status = "in_progress", LeaseOwner = "o", LeaseInstanceId = "w", LeaseDurationSeconds = 60 }, null);

        var ex = Assert.ThrowsAsync<TaskStoreException>(async () => await store.PatchAsync("att1", new TaskPatchRequest
        {
            Attachments = new JsonObject { ["bad key!"] = "v" },
        }, null));
        Assert.That(ex!.Code, Is.EqualTo(TaskStoreException.CodeInvalidRequest));
    }

    [Test]
    public async Task CascadeDeleteIsANoOpForDependents()
    {
        // The library does not track task dependencies (no depends_on_task_ids field, matching the
        // Python provider). `cascade` is accepted but is a no-op for the local store — deleting a
        // task never removes other tasks; the hosted service is responsible for any server-side
        // cascade semantics.
        var store = CreateStore();
        await store.CreateAsync(NewCreate("parent"));
        await store.CreateAsync(NewCreate("child"));

        await store.DeleteAsync("parent", force: true, cascade: true);

        Assert.That(await store.GetAsync("parent"), Is.Null);
        Assert.That(await store.GetAsync("child"), Is.Not.Null);
    }
}
