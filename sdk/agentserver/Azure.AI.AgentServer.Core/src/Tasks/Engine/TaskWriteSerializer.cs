// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
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
    /// The entry is removed from the dictionary but its <see cref="ActiveTaskEntry.WriteGate"/> is
    /// intentionally NOT disposed here: a caller may already have obtained the entry (via
    /// <see cref="GetOrAddEntry"/>) and be holding or awaiting the gate. Disposing it underneath
    /// them would surface an <see cref="ObjectDisposedException"/> on their <c>Release</c>/<c>WaitAsync</c>.
    /// The gate is only ever used through <c>WaitAsync</c>/<c>Release</c> (its wait handle is never
    /// materialized), so it needs no deterministic disposal — once the removed entry and any
    /// in-flight caller reference are gone, the GC reclaims it. Full disposal still happens at
    /// serializer teardown (<see cref="Dispose"/>), when no callers remain.
    /// </remarks>
    public void Remove(string taskId)
    {
        _entries.TryRemove(taskId, out _);
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
        ActiveTaskEntry entry = GetOrAddEntry(taskId);
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
