// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Engine;

[TestFixture]
public sealed class TaskWriteSerializerTests
{
    private string _tempDir = string.Empty;
    private LocalTaskStore _store = null!;
    private TaskWriteSerializer _serializer = null!;

    [SetUp]
    public async Task SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "agentserver-ser-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
        _store = new LocalTaskStore(_tempDir);
        _serializer = new TaskWriteSerializer(_store);

        var created = await _store.CreateAsync(new TaskCreateRequest
        {
            Id = "t",
            AgentName = "agent-a",
            SessionId = "sess-1",
            Title = "t",
            Payload = new JsonObject { ["counter"] = 0 },
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
    public async Task ConcurrentMutationsNeverRaiseAvoidable412()
    {
        // Fan many concurrent in-process increments; the per-task gate must serialize
        // them so each PATCH carries the freshest etag and no avoidable 412 surfaces.
        const int writers = 50;
        var tasks = Enumerable.Range(0, writers).Select(_ => Task.Run(async () =>
            await _serializer.UpdateAsync("t", current =>
            {
                int counter = (int)(current.Payload["counter"]!.GetValue<int>());
                return new TaskPatchRequest
                {
                    PayloadSupplied = true,
                    Payload = new JsonObject { ["counter"] = counter + 1 },
                };
            }, WriteIntent.Generic)));

        await Task.WhenAll(tasks);

        var final = await _store.GetAsync("t");
        Assert.That((int)final!.Payload["counter"]!.GetValue<int>(), Is.EqualTo(writers));
    }

    [Test]
    public async Task UpdateRefreshesTrackedEtagFromResponse()
    {
        ActiveTaskEntry entry = _serializer.GetOrAddEntry("t");
        string? before = entry.TrackedEtag;
        await _serializer.UpdateAsync("t", _ => new TaskPatchRequest
        {
            PayloadSupplied = true,
            Payload = new JsonObject { ["counter"] = 99 },
        }, WriteIntent.Generic);
        Assert.That(entry.TrackedEtag, Is.Not.EqualTo(before));
    }

    [Test]
    public async Task PayloadOnlyWriteDoesNotRefreshLeaseHeartbeatTimestamp()
    {
        await CreateLeasedTaskAsync("leased-payload");
        ActiveTaskEntry entry = _serializer.GetOrAddEntry("leased-payload");
        DateTimeOffset oldRefresh = DateTimeOffset.UtcNow.AddMinutes(-5);
        entry.LastRefreshUtc = oldRefresh;

        await _serializer.UpdateAsync("leased-payload", _ => new TaskPatchRequest
        {
            PayloadSupplied = true,
            Payload = new JsonObject { ["counter"] = 1 },
        }, WriteIntent.MetadataFlush);

        Assert.That(entry.LastRefreshUtc, Is.EqualTo(oldRefresh),
            "payload-only writes do not extend lease.expires_at and must not suppress the next heartbeat");
    }

    [Test]
    public async Task LeaseWriteRefreshesLeaseHeartbeatTimestamp()
    {
        await CreateLeasedTaskAsync("leased-heartbeat");
        ActiveTaskEntry entry = _serializer.GetOrAddEntry("leased-heartbeat");
        DateTimeOffset oldRefresh = DateTimeOffset.UtcNow.AddMinutes(-5);
        entry.LastRefreshUtc = oldRefresh;

        await _serializer.UpdateAsync("leased-heartbeat", _ => new TaskPatchRequest
        {
            LeaseOwner = "owner",
            LeaseInstanceId = "instance-1",
            LeaseDurationSeconds = 60,
        }, WriteIntent.LeaseHeartbeat);

        Assert.That(entry.LastRefreshUtc, Is.GreaterThan(oldRefresh));
        Assert.That(entry.HeldInstanceId, Is.EqualTo("instance-1"));
    }

    [Test]
    public async Task NoOpComputeReturnsCurrentWithoutWrite()
    {
        var result = await _serializer.UpdateAsync("t", _ => null, WriteIntent.Generic);
        Assert.That(result.Id, Is.EqualTo("t"));
    }

    [Test]
    public void RemoveDropsEntryWithoutDisposingInUseGate()
    {
        ActiveTaskEntry entry = _serializer.GetOrAddEntry("t");
        _serializer.Remove("t");

        // Remove must NOT dispose the gate underneath a caller that already obtained the entry:
        // disposing it would surface ObjectDisposedException on their Release/WaitAsync. The gate
        // stays usable and is reclaimed by the GC once no caller references it.
        Assert.DoesNotThrow(() =>
        {
            entry.WriteGate.Wait(0);
            entry.WriteGate.Release();
        });

        // Remove still drops the entry from the dictionary: a later lookup allocates a fresh one.
        Assert.That(_serializer.GetOrAddEntry("t"), Is.Not.SameAs(entry));
    }

    [Test]
    public async Task RemoveWhileGateHeldDoesNotAdmitASecondWriterUnderAFreshGate()
    {
        // Regression: Remove used to drop the entry from the map unconditionally, so a subsequent
        // UpdateAsync minted a FRESH gate and a second writer entered while the original gate was
        // still held — two concurrent writers on the same task. A synchronous store makes it
        // deterministic: under the bug the second write runs to completion inline (before the
        // original gate is released); with the fix it blocks on the same gate.
        var record = TaskRecord.FromJson(new JsonObject
        {
            ["id"] = "g",
            ["status"] = "in_progress",
            ["etag"] = "e0",
            ["payload"] = new JsonObject(),
        });
        using var serializer = new TaskWriteSerializer(new SyncStore(record));

        ActiveTaskEntry first = serializer.GetOrAddEntry("g");
        await first.WriteGate.WaitAsync();

        serializer.Remove("g");

        bool secondEntered = false;
        Task second = serializer.UpdateAsync("g", _ =>
        {
            secondEntered = true;
            return null;
        }, WriteIntent.Generic);

        bool enteredBeforeRelease = secondEntered;

        first.WriteGate.Release();
        await second;

        Assert.That(enteredBeforeRelease, Is.False,
            "a second writer must not enter under a fresh gate while the original gate is held");
        Assert.That(secondEntered, Is.True, "the second writer proceeds once the original gate is released");
    }

    [Test]
    public void BindingMismatchOnPatchAbandonsImmediately()
    {
        // Python parity (SOT §39.1): a hosted 409 binding_mismatch means the task was rebound to
        // another worker (evicted). The serializer must abandon immediately, not surface a raw store
        // error or retry — no CAS re-read can recover ownership.
        AssertEvictionCodeAbandons(TaskStoreException.CodeBindingMismatch);
    }

    [Test]
    public void LeaseOwnershipChangedOnPatchAbandonsImmediately()
    {
        // Cross-language parity (lease_ownership_changed -> TaskConflictError): the same
        // immediate-abandon eviction semantics apply.
        AssertEvictionCodeAbandons(TaskStoreException.CodeLeaseOwnershipChanged);
    }

    private static void AssertEvictionCodeAbandons(string evictionCode)
    {
        var current = TaskRecord.FromJson(new JsonObject
        {
            ["id"] = "t",
            ["status"] = "in_progress",
            ["etag"] = "e0",
            ["payload"] = new JsonObject { ["counter"] = 0 },
        });
        var store = new EvictingStore(current, evictionCode);
        using var serializer = new TaskWriteSerializer(store);
        serializer.Track(current);

        Assert.ThrowsAsync<WriteAbandonedException>(async () =>
            await serializer.UpdateAsync("t", _ => new TaskPatchRequest
            {
                PayloadSupplied = true,
                Payload = new JsonObject { ["counter"] = 1 },
            }, WriteIntent.Generic));
    }

    private async Task CreateLeasedTaskAsync(string id)
    {
        var created = await _store.CreateAsync(new TaskCreateRequest
        {
            Id = id,
            AgentName = "agent-a",
            SessionId = "sess-1",
            Title = id,
            Status = "in_progress",
            LeaseOwner = "owner",
            LeaseInstanceId = "instance-1",
            LeaseDurationSeconds = 60,
            Payload = new JsonObject { ["counter"] = 0 },
            Source = new JsonObject { ["type"] = "agentserver.task", ["name"] = "demo", ["server_version"] = "x/1" },
        });
        _serializer.SeedLease(created);
    }

    /// <summary>A fake store that returns a fixed record synchronously (no I/O yield), so gate
    /// ordering is deterministic in tests.</summary>
    private sealed class SyncStore : ITaskStore
    {
        private readonly TaskRecord _record;

        public SyncStore(TaskRecord record) => _record = record;

        public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
            => Task.FromResult(_record);

        public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
            => Task.FromResult<TaskRecord?>(_record);

        public Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
            => Task.FromResult(_record);

        public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
            => Task.CompletedTask;

        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
            => Task.FromResult(new TaskListResult());
    }

    /// <summary>A fake store whose <see cref="PatchAsync"/> always fails with a 409 eviction code.</summary>
    private sealed class EvictingStore : ITaskStore
    {
        private readonly TaskRecord _current;
        private readonly string _evictionCode;

        public EvictingStore(TaskRecord current, string evictionCode)
        {
            _current = current;
            _evictionCode = evictionCode;
        }

        public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
            => Task.FromResult(_current);

        public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
            => Task.FromResult<TaskRecord?>(_current);

        public Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
            => throw new TaskStoreException(_evictionCode, 409, "evicted", taskId);

        public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
            => Task.CompletedTask;

        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
            => Task.FromResult(new TaskListResult());
    }
}
