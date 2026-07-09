// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>
/// The in-memory replay backing: retains emitted events (with optional per-event
/// TTL) so late subscribers catch up and reconnecting clients resume after a
/// cursor. A close-clock auto-tombstone fires <c>ttl</c> after close. Mirrors
/// Python's in-memory replay backing.
/// </summary>
internal class ReplayEventStream : IEventStream, IDestroyableStream
{
    private readonly object _gate = new();
    private readonly SubscriberHub _hub = new();
    private readonly List<HistoryEntry> _history = new();
    private readonly Func<object, int>? _cursor;
    private readonly double? _ttlSeconds;
    private readonly Action _onDestroy;

    private StreamState _state = StreamState.Active;
    private int? _lastCursor;
    private double _closeTime;

    public ReplayEventStream(string id, Func<object, int>? cursor, TimeSpan? ttl, Action onDestroy)
    {
        Id = id;
        _cursor = cursor;
        _ttlSeconds = ttl?.TotalSeconds;
        _onDestroy = onDestroy;
    }

    /// <summary>The stream id.</summary>
    protected string Id { get; }

    /// <summary>Whether a cursor function is configured.</summary>
    protected bool HasCursor => _cursor is not null;

    public ValueTask EmitAsync(object payload, bool close = false, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        bool selfDestroyed = false;
        try
        {
            lock (_gate)
            {
                double now = Now();
                selfDestroyed = EvictExpired(now);
                if (_state == StreamState.Destroyed)
                {
                    throw new EventStreamNotFoundException($"Stream '{Id}' is not a live stream.");
                }

                if (_state == StreamState.Closed)
                {
                    throw new EventStreamClosedException($"Stream '{Id}' is closed; emit is not allowed.");
                }

                int? cursor = _cursor?.Invoke(payload);

                // Persist before mutating in-memory state so a disk failure does not leave
                // an event that subscribers can see but that never reached durable storage. On
                // emit-and-close, persist the event and terminal marker as one durable unit so a
                // crash cannot leave the event without its terminal sentinel.
                if (close)
                {
                    PersistEmitAndClose(payload, now);
                }
                else
                {
                    PersistEmit(payload, now);
                }

                _history.Add(new HistoryEntry(payload, now, cursor));
                if (cursor.HasValue)
                {
                    _lastCursor = _lastCursor.HasValue ? Math.Max(_lastCursor.Value, cursor.Value) : cursor.Value;
                }

                _hub.Publish(payload);

                if (close)
                {
                    _state = StreamState.Closed;
                    _closeTime = now;
                    _hub.CompleteAll();
                }
            }
        }
        finally
        {
            if (selfDestroyed)
            {
                _onDestroy();
            }
        }

        return default;
    }

    public ValueTask CloseAsync(CancellationToken cancellationToken = default)
    {
        lock (_gate)
        {
            if (_state == StreamState.Active)
            {
                _state = StreamState.Closed;
                _closeTime = Now();
                PersistClose();
                _hub.CompleteAll();
            }
        }

        return default;
    }

    public IAsyncEnumerable<object> Subscribe(
        int? after = null, CancellationToken cancellationToken = default)
    {
        // Validate eagerly (mirroring Python's synchronous `subscribe`): a NotFound for a destroyed
        // stream must surface at the call site, not be deferred until the caller begins enumerating.
        Channel<object> channel = BeginSubscription(after, out List<object> backlog);
        return Iterate(channel, backlog, cancellationToken);
    }

    private async IAsyncEnumerable<object> Iterate(
        Channel<object> channel,
        List<object> backlog,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        try
        {
            foreach (object item in backlog)
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return item;
            }

            await foreach (object item in channel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
            {
                yield return item;
            }
        }
        finally
        {
            lock (_gate)
            {
                _hub.Remove(channel);
            }
        }
    }

    private Channel<object> BeginSubscription(int? after, out List<object> backlog)
    {
        bool selfDestroyed = false;
        try
        {
            lock (_gate)
            {
                double now = Now();
                selfDestroyed = EvictExpired(now);
                if (_state == StreamState.Destroyed)
                {
                    backlog = new List<object>();
                    throw new EventStreamNotFoundException($"Stream '{Id}' is not a live stream.");
                }

                Channel<object> channel = _hub.Add();
                backlog = SnapshotHistory(after);
                if (_state == StreamState.Closed)
                {
                    _hub.Remove(channel);
                    channel.Writer.TryComplete();
                }

                return channel;
            }
        }
        finally
        {
            if (selfDestroyed)
            {
                _onDestroy();
            }
        }
    }

    public ValueTask<int?> GetLastCursorAsync(CancellationToken cancellationToken = default)
    {
        // Side-effect-free: never evicts and never triggers the close-clock tombstone,
        // so a recovering producer can read it during the close window.
        lock (_gate)
        {
            if (_state == StreamState.Destroyed)
            {
                throw new EventStreamNotFoundException($"Stream '{Id}' is not a live stream.");
            }

            return new ValueTask<int?>(_lastCursor);
        }
    }

    /// <summary>Registry-initiated destruction: completes subscribers and frees backing resources.</summary>
    public void Destroy()
    {
        lock (_gate)
        {
            _state = StreamState.Destroyed;
            _history.Clear();
            PersistDelete();
            _hub.CompleteAll();
        }
    }

    /// <inheritdoc/>
    public bool TryAutoDestroyIfElapsed()
    {
        bool selfDestroyed;
        lock (_gate)
        {
            if (_state == StreamState.Destroyed)
            {
                return false;
            }

            selfDestroyed = EvictExpired(Now());
        }

        if (selfDestroyed)
        {
            _onDestroy();
        }

        return selfDestroyed;
    }

    /// <summary>Persists an emitted event (no-op for the in-memory backing).</summary>
    protected virtual void PersistEmit(object payload, double emitTime)
    {
    }

    /// <summary>Persists the terminal sentinel on close (no-op for the in-memory backing).</summary>
    protected virtual void PersistClose()
    {
    }

    /// <summary>
    /// Persists an emitted event together with the terminal sentinel as a single durable unit
    /// (atomic emit-and-close). The default composes <see cref="PersistEmit"/> and
    /// <see cref="PersistClose"/>; durable backings override this to append both records in one
    /// write+flush so a crash cannot leave the event without its terminal marker.
    /// </summary>
    protected virtual void PersistEmitAndClose(object payload, double emitTime)
    {
        PersistEmit(payload, emitTime);
        PersistClose();
    }

    /// <summary>Removes any persisted backing resources on destroy (no-op for the in-memory backing).</summary>
    protected virtual void PersistDelete()
    {
    }

    /// <summary>Seeds a rehydrated event into history (used by the file-backed subclass on construction).</summary>
    protected void SeedHistory(object payload, double emitTime)
    {
        int? cursor = _cursor?.Invoke(payload);
        _history.Add(new HistoryEntry(payload, emitTime, cursor));
        if (cursor.HasValue)
        {
            _lastCursor = _lastCursor.HasValue ? Math.Max(_lastCursor.Value, cursor.Value) : cursor.Value;
        }
    }

    /// <summary>Marks a rehydrated stream as already closed (terminal sentinel was present).</summary>
    protected void SeedClosed()
    {
        _state = StreamState.Closed;
        _closeTime = _history.Count > 0 ? _history[_history.Count - 1].EmitTime : Now();
    }

    /// <summary>Returns the still-retained events (payload + emit time) for on-disk compaction. Must be called under the backing lock.</summary>
    protected IReadOnlyList<KeyValuePair<object, double>> RetainedForCompaction()
    {
        var list = new List<KeyValuePair<object, double>>(_history.Count);
        foreach (HistoryEntry entry in _history)
        {
            list.Add(new KeyValuePair<object, double>(entry.Payload, entry.EmitTime));
        }

        return list;
    }

    private List<object> SnapshotHistory(int? after)
    {
        var snapshot = new List<object>(_history.Count);
        foreach (HistoryEntry entry in _history)
        {
            if (HasCursor && after.HasValue && entry.Cursor.HasValue && entry.Cursor.Value <= after.Value)
            {
                continue;
            }

            snapshot.Add(entry.Payload);
        }

        return snapshot;
    }

    // Evicts events past their TTL and, if the close-clock has elapsed, transitions to
    // Destroyed. Returns whether this call self-destroyed the stream (so the caller can
    // notify the registry outside the lock). Runs on every emit and subscribe.
    private bool EvictExpired(double now)
    {
        if (_ttlSeconds is not { } ttl)
        {
            return false;
        }

        if (_history.Count > 0)
        {
            int keepFrom = 0;
            while (keepFrom < _history.Count && _history[keepFrom].EmitTime + ttl <= now)
            {
                keepFrom++;
            }

            if (keepFrom > 0)
            {
                _history.RemoveRange(0, keepFrom);
                OnEvicted(keepFrom);
            }
        }

        if (_state == StreamState.Closed && now >= _closeTime + ttl)
        {
            _state = StreamState.Destroyed;
            _history.Clear();
            PersistDelete();
            _hub.CompleteAll();
            return true;
        }

        return false;
    }

    /// <summary>Whether the stream is currently closed (read by file-backed compaction, under the
    /// stream lock, to decide whether to preserve the on-disk terminal marker).</summary>
    protected bool IsClosedSnapshot => _state == StreamState.Closed;

    /// <summary>Notifies the subclass that <paramref name="count"/> leading events were evicted (for compaction).</summary>
    protected virtual void OnEvicted(int count)
    {
    }

    private static double Now() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000.0;

    private readonly struct HistoryEntry
    {
        public HistoryEntry(object payload, double emitTime, int? cursor)
        {
            Payload = payload;
            EmitTime = emitTime;
            Cursor = cursor;
        }

        public object Payload { get; }

        public double EmitTime { get; }

        public int? Cursor { get; }
    }
}
