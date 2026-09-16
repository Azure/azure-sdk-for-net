// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Per-task in-process bookkeeping for write serialization (SOT §25.2). Holds the
/// latest tracked ETag (for always-on <c>If-Match</c>), a non-reentrant write gate
/// that serializes read → compute → apply cycles, and the last-seen lease expiry
/// count used by the terminal-write 412 resolver to detect an expired-and-taken-over
/// lease. Entries are lazily allocated and torn down with the active task.
/// <para>
/// Cross-thread fields are accessed without the gate on read paths (which take no
/// lock per §25.2), so they are written/read atomically.
/// </para>
/// </summary>
internal sealed class ActiveTaskEntry : IDisposable
{
    private volatile string? _trackedEtag;
    private volatile string? _heldInstanceId;
    private long _cachedExpiryCount;
    private long _heldGeneration;
    private long _lastRefreshUtcTicks;

    /// <summary>Initializes a new instance of the <see cref="ActiveTaskEntry"/> class.</summary>
    /// <param name="taskId">The task id this entry tracks.</param>
    public ActiveTaskEntry(string taskId)
    {
        TaskId = taskId;
        Volatile.Write(ref _lastRefreshUtcTicks, DateTimeOffset.UtcNow.UtcTicks);
    }

    /// <summary>The task id this entry tracks.</summary>
    public string TaskId { get; }

    /// <summary>The non-reentrant per-task write gate (C# analog of Python's asyncio.Lock).</summary>
    public SemaphoreSlim WriteGate { get; } = new(1, 1);

    /// <summary>
    /// Synchronizes the gate-lifetime reference counting below. Kept separate from the lock-free
    /// ETag/lease fields (which read without the write gate per §25.2) so those paths are unaffected.
    /// </summary>
    internal object ReapLock { get; } = new();

    /// <summary>
    /// The number of in-flight serialized writes that still reference this entry (guarded by
    /// <see cref="ReapLock"/>). The entry — and its single <see cref="WriteGate"/> — must outlive
    /// every referencing write so a concurrent <c>Remove</c> cannot split writers across two gates.
    /// </summary>
    internal int RefCount { get; set; }

    /// <summary>Whether teardown was requested; the entry is detached once nothing can reference its gate (guarded by <see cref="ReapLock"/>).</summary>
    internal bool RemovalRequested { get; set; }

    /// <summary>Whether the entry has been detached from the serializer map (guarded by <see cref="ReapLock"/>).</summary>
    internal bool Removed { get; set; }

    /// <summary>The latest ETag observed from a create/get/patch response, passed verbatim as <c>If-Match</c>.</summary>
    public string? TrackedEtag
    {
        get => _trackedEtag;
        set => _trackedEtag = value;
    }

    /// <summary>The UTC time of the last successful refresh, used to compute lease renewal cadence.</summary>
    public DateTimeOffset LastRefreshUtc
    {
        get => new(Volatile.Read(ref _lastRefreshUtcTicks), TimeSpan.Zero);
        set => Volatile.Write(ref _lastRefreshUtcTicks, value.UtcTicks);
    }

    /// <summary>The last-seen lease <c>expiry_count</c> at the time we last held our lease. Retained for diagnostics/binary-compat but intentionally NOT consulted by <see cref="EtagConflictResolver"/> — takeover is detected via instance-id/generation alone (Python parity, see resolver remarks).</summary>
    public long CachedExpiryCount
    {
        get => Interlocked.Read(ref _cachedExpiryCount);
        set => Interlocked.Exchange(ref _cachedExpiryCount, value);
    }

    /// <summary>The lease <c>instance_id</c> we last wrote while holding the lease. A re-read record whose lease instance differs signals a takeover (e.g. a process restart or another worker reclaiming) even when the lease never expired.</summary>
    public string? HeldInstanceId
    {
        get => _heldInstanceId;
        set => _heldInstanceId = value;
    }

    /// <summary>The lease <c>generation</c> we last wrote while holding the lease; a greater server value signals a takeover.</summary>
    public long HeldGeneration
    {
        get => Interlocked.Read(ref _heldGeneration);
        set => Interlocked.Exchange(ref _heldGeneration, value);
    }

    /// <inheritdoc/>
    public void Dispose() => WriteGate.Dispose();
}
