// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Serializes all read-modify-write mutations of a task through a per-task gate and
/// applies the always-on <c>If-Match</c> + intent-based 412 resolution policy
/// (SOT §25). This removes avoidable precondition failures between in-process
/// call-sites and resolves genuine races deterministically. Reads and list calls
/// take no lock.
/// </summary>
internal sealed class TaskWriteSerializer : IDisposable
{
    private readonly ITaskStore _store;
    private readonly ConcurrentDictionary<string, ActiveTaskEntry> _entries = new(StringComparer.Ordinal);
    private readonly int _maxAttempts;

    /// <summary>Initializes a new instance of the <see cref="TaskWriteSerializer"/> class.</summary>
    /// <param name="store">The backing task store.</param>
    /// <param name="maxAttempts">The maximum number of 412 resolution attempts.</param>
    public TaskWriteSerializer(ITaskStore store, int maxAttempts = EtagConflictResolver.DefaultMaxAttempts)
    {
        _store = store ?? throw new ArgumentNullException(nameof(store));
        _maxAttempts = maxAttempts;
    }

    /// <summary>Gets (creating if necessary) the per-task bookkeeping entry.</summary>
    /// <param name="taskId">The task id.</param>
    /// <returns>The active-task entry.</returns>
    public ActiveTaskEntry GetOrAddEntry(string taskId)
        => _entries.GetOrAdd(taskId, static id => new ActiveTaskEntry(id));

    /// <summary>Records the latest ETag observed for a record (read-path refresh).</summary>
    /// <param name="record">The freshly observed record.</param>
    /// <remarks>
    /// This refreshes only the tracked ETag and refresh timestamp. <see cref="ActiveTaskEntry.CachedExpiryCount"/>
    /// is the baseline expiry count from when we last held our own lease and is advanced
    /// only by a successful lease write (in <see cref="UpdateLockedAsync"/>) — never from an
    /// arbitrary read — so the terminal-write takeover detection in
    /// <see cref="EtagConflictResolver"/> stays correct.
    /// </remarks>
    public void Track(TaskRecord record)
    {
        ActiveTaskEntry entry = GetOrAddEntry(record.Id);
        entry.TrackedEtag = record.Etag;
        entry.LastRefreshUtc = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Seeds the per-task entry's tracked ETag and held-lease identity from a record we just created
    /// with our own lease atomically. This lets the terminal-write takeover detection fence correctly
    /// without a separate lease-acquiring PATCH (the atomic create already established our lease).
    /// </summary>
    /// <param name="record">The freshly created record carrying our lease.</param>
    public void SeedLease(TaskRecord record)
    {
        ActiveTaskEntry entry = GetOrAddEntry(record.Id);
        entry.TrackedEtag = record.Etag;
        entry.LastRefreshUtc = DateTimeOffset.UtcNow;
        if (record.Lease is not null)
        {
            entry.CachedExpiryCount = record.Lease.ExpiryCount;
            entry.HeldInstanceId = record.Lease.InstanceId;
            entry.HeldGeneration = record.Lease.Generation;
        }
    }

    /// <summary>Drops the per-task entry on active-task teardown.</summary>
    /// <param name="taskId">The task id.</param>
    /// <remarks>
    /// The entry — and its single <see cref="ActiveTaskEntry.WriteGate"/> — is detached from the map
    /// only once nothing can still reference it: no in-flight serialized write holds a reference
    /// (<see cref="ActiveTaskEntry.RefCount"/> is zero) and the gate is not currently held. While a
    /// write is in progress the entry is merely marked for removal and the last releaser detaches it,
    /// so a concurrent <see cref="UpdateAsync"/> keeps observing the SAME gate and mutual exclusion is
    /// never broken by replacing the gate underneath a live writer. The gate is never disposed here
    /// (a caller that fetched the entry just before detachment may still await it); deterministic
    /// disposal happens at serializer teardown (<see cref="Dispose"/>), when no callers remain.
    /// </remarks>
    public void Remove(string taskId)
    {
        if (!_entries.TryGetValue(taskId, out ActiveTaskEntry? entry))
        {
            return;
        }

        lock (entry.ReapLock)
        {
            entry.RemovalRequested = true;
            TryDetachLocked(entry);
        }
    }

    // Pins the live per-task entry for the duration of a serialized write, incrementing its
    // reference count so a concurrent Remove cannot detach (and a later GetOrAdd cannot replace) the
    // gate while this write still needs it. Retries if it races a detachment of the entry it fetched.
    private ActiveTaskEntry AcquireForWrite(string taskId)
    {
        while (true)
        {
            ActiveTaskEntry entry = _entries.GetOrAdd(taskId, static id => new ActiveTaskEntry(id));
            lock (entry.ReapLock)
            {
                if (entry.Removed)
                {
                    // Detached from the map between GetOrAdd and here; fetch/create the live entry.
                    continue;
                }

                // A fresh write means the task is in use again, so cancel any pending teardown from a
                // prior Remove rather than detaching this entry out from under the new writer.
                entry.RemovalRequested = false;
                entry.RefCount++;
                return entry;
            }
        }
    }

    // Releases a write's reference and detaches the entry if a removal was requested while it was
    // still in use.
    private void ReleaseAfterWrite(ActiveTaskEntry entry)
    {
        lock (entry.ReapLock)
        {
            entry.RefCount--;
            TryDetachLocked(entry);
        }
    }

    // Detaches the entry from the map once removal was requested AND nothing can still reference its
    // gate: no in-flight serialized write (RefCount == 0) and the gate is not held (CurrentCount == 1,
    // which also implies no waiters — a waiter would have driven the count to 0). The gate is not
    // disposed (see Remove remarks). Must be called under entry.ReapLock.
    private void TryDetachLocked(ActiveTaskEntry entry)
    {
        if (entry.RemovalRequested
            && !entry.Removed
            && entry.RefCount == 0
            && entry.WriteGate.CurrentCount == 1)
        {
            entry.Removed = true;
            _entries.TryRemove(new KeyValuePair<string, ActiveTaskEntry>(entry.TaskId, entry));
        }
    }

    /// <summary>
    /// Serializes a read-modify-write under the per-task gate. The supplied
    /// <paramref name="compute"/> receives the freshly read record and returns the
    /// patch to apply, or <see langword="null"/> to no-op.
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="compute">Computes the patch from the current record.</param>
    /// <param name="intent">The write intent that governs 412 resolution.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The updated record (or the unchanged current record on no-op).</returns>
    public async Task<TaskRecord> UpdateAsync(
        string taskId,
        Func<TaskRecord, TaskPatchRequest?> compute,
        WriteIntent intent,
        CancellationToken cancellationToken = default)
    {
        ActiveTaskEntry entry = AcquireForWrite(taskId);
        try
        {
            await entry.WriteGate.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                return await UpdateLockedAsync(taskId, compute, intent, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                entry.WriteGate.Release();
            }
        }
        finally
        {
            ReleaseAfterWrite(entry);
        }
    }

    /// <summary>
    /// The lock-held variant of <see cref="UpdateAsync"/>. The caller must already
    /// hold the per-task gate (e.g. when composing multiple mutations).
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="compute">Computes the patch from the current record.</param>
    /// <param name="intent">The write intent that governs 412 resolution.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The updated record (or the unchanged current record on no-op).</returns>
    public async Task<TaskRecord> UpdateLockedAsync(
        string taskId,
        Func<TaskRecord, TaskPatchRequest?> compute,
        WriteIntent intent,
        CancellationToken cancellationToken = default)
    {
        ActiveTaskEntry entry = GetOrAddEntry(taskId);
        for (int attempt = 1; ; attempt++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            TaskRecord? current = await _store.GetAsync(taskId, cancellationToken).ConfigureAwait(false)
                ?? throw new TaskStoreException(TaskStoreException.CodeTaskNotFound, 404, $"Task '{taskId}' not found.", taskId);

            entry.TrackedEtag = current.Etag;
            TaskPatchRequest? patch = compute(current);
            if (patch is null)
            {
                return current;
            }

            try
            {
                TaskRecord updated = await _store
                    .PatchAsync(taskId, patch, ifMatch: entry.TrackedEtag, cancellationToken)
                    .ConfigureAwait(false);
                entry.TrackedEtag = updated.Etag;
                bool refreshedLease = patch.LeaseOwner is not null && patch.LeaseDurationSeconds > 0;
                if (updated.Lease is not null && refreshedLease)
                {
                    entry.CachedExpiryCount = updated.Lease.ExpiryCount;

                    // Remember the lease identity we just wrote so the resolver can fence a
                    // same-owner takeover (a restarted process reacquiring under a new instance
                    // id) even when the lease never expired and the expiry count did not advance.
                    entry.HeldInstanceId = updated.Lease.InstanceId;
                    entry.HeldGeneration = updated.Lease.Generation;

                    // A write that carries lease parameters refreshed the lease as a side effect;
                    // record the time so the renewal loop can shadow a redundant heartbeat.
                    // Payload-only writes may return a leased record without extending expires_at.
                    entry.LastRefreshUtc = DateTimeOffset.UtcNow;
                }

                return updated;
            }
            catch (TaskStoreException ex) when (
                ex.StatusCode == 409 &&
                (ex.Code == TaskStoreException.CodeBindingMismatch ||
                 ex.Code == TaskStoreException.CodeLeaseOwnershipChanged))
            {
                // Cross-language parity (SOT §39.1; binding_mismatch -> "evicted",
                // lease_ownership_changed -> TaskConflictError). A 409 binding_mismatch or
                // lease_ownership_changed means the platform rebound this task to another worker —
                // we were evicted. No CAS re-read can recover ownership, so abandon immediately for
                // recovery instead of surfacing a raw store error (terminal writes) or waiting out
                // the slow 3-strikes lease-loss path (heartbeats).
                throw new WriteAbandonedException(taskId, intent);
            }
            catch (TaskStoreException ex) when (ex.Code == TaskStoreException.CodeEtagMismatch || ex.StatusCode == 412)
            {
                TaskRecord? reread = await _store.GetAsync(taskId, cancellationToken).ConfigureAwait(false);
                EtagConflictResolver.Decision decision =
                    EtagConflictResolver.Resolve(intent, reread, entry, attempt, _maxAttempts);
                switch (decision)
                {
                    case EtagConflictResolver.Decision.Abandon:
                        throw new WriteAbandonedException(taskId, intent);
                    case EtagConflictResolver.Decision.Surface:
                        throw;
                    default:
                        if (reread is not null)
                        {
                            entry.TrackedEtag = reread.Etag;
                        }

                        continue;
                }
            }
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        foreach (ActiveTaskEntry entry in _entries.Values)
        {
            entry.Dispose();
        }

        _entries.Clear();
    }
}
