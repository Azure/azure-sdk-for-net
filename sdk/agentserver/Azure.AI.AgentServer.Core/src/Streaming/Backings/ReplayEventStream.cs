// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>
/// The in-memory replay backing: retains emitted events (with optional per-event
/// TTL) so late subscribers catch up and reconnecting clients resume after an
/// <see cref="SseItem{T}.EventId"/>. A close-clock auto-tombstone fires <c>ttl</c>
/// after close.
/// </summary>
internal class ReplayEventStream : AgentEventStream, IDestroyableStream
{
    private readonly object _gate = new();
    private readonly SubscriberHub _hub = new();
    private readonly List<HistoryEntry> _history = new();
    private readonly double? _ttlSeconds;
    private readonly Action _onDestroy;

    private StreamState _state = StreamState.Active;
    private string? _lastEventId;
    private double _closeTime;

    public ReplayEventStream(string id, TimeSpan? ttl, Action onDestroy)
    {
        Id = id;
        _ttlSeconds = ttl?.TotalSeconds;
        _onDestroy = onDestroy;
    }

    /// <summary>The stream id.</summary>
    protected string Id { get; }

    public override ValueTask EmitAsync(SseItem<string> item, bool close = false, CancellationToken cancellationToken = default)
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
                    throw new AgentEventStreamNotFoundException($"Stream '{Id}' is not a live stream.");
                }

                if (_state == StreamState.Closed)
                {
                    throw new AgentEventStreamClosedException($"Stream '{Id}' is closed; emit is not allowed.");
                }

                // Persist before mutating in-memory state so a disk failure does not leave
                // an event that subscribers can see but that never reached durable storage. On
                // emit-and-close, persist the event and terminal marker as one durable unit so a
                // crash cannot leave the event without its terminal sentinel.
                if (close)
                {
                    PersistEmitAndClose(item, now);
                }
                else
                {
                    PersistEmit(item, now);
                }

                _history.Add(new HistoryEntry(item, now));
                _lastEventId = item.EventId ?? _lastEventId;

                _hub.Publish(item);

                if (close)
                {
                    _state = StreamState.Closed;
                    _closeTime = now;
                    _hub.CompleteAll();
                    selfDestroyed = EvictExpired(now);
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

    public override ValueTask CloseAsync(CancellationToken cancellationToken = default)
    {
        bool selfDestroyed = false;
        try
        {
            lock (_gate)
            {
                double now = Now();
                if (_state == StreamState.Active)
                {
                    _state = StreamState.Closed;
                    _closeTime = now;
                    PersistClose();
                    _hub.CompleteAll();
                }

                selfDestroyed = EvictExpired(now);
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

    public override IAsyncEnumerable<SseItem<string>> Subscribe(
        string? afterEventId = null, CancellationToken cancellationToken = default)
    {
        // Validate eagerly (mirroring a synchronous `subscribe`): a NotFound for a destroyed
        // stream must surface at the call site, not be deferred until the caller begins enumerating.
        Channel<SseItem<string>> channel = BeginSubscription(afterEventId, out List<SseItem<string>> backlog);
        return Iterate(channel, backlog, cancellationToken);
    }

    private async IAsyncEnumerable<SseItem<string>> Iterate(
        Channel<SseItem<string>> channel,
        List<SseItem<string>> backlog,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        try
        {
            foreach (SseItem<string> item in backlog)
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return item;
            }

            await foreach (SseItem<string> item in channel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
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

    private Channel<SseItem<string>> BeginSubscription(string? afterEventId, out List<SseItem<string>> backlog)
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
                    backlog = new List<SseItem<string>>();
                    throw new AgentEventStreamNotFoundException($"Stream '{Id}' is not a live stream.");
                }

                Channel<SseItem<string>> channel = _hub.Add();
                backlog = SnapshotHistory(afterEventId);
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

    public override ValueTask<string?> GetLastEventIdAsync(CancellationToken cancellationToken = default)
    {
        // Side-effect-free: never evicts and never triggers the close-clock tombstone,
        // so a recovering producer can read it during the close window.
        lock (_gate)
        {
            if (_state == StreamState.Destroyed)
            {
                throw new AgentEventStreamNotFoundException($"Stream '{Id}' is not a live stream.");
            }

            return new ValueTask<string?>(_lastEventId);
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
    protected virtual void PersistEmit(SseItem<string> item, double emitTime)
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
    protected virtual void PersistEmitAndClose(SseItem<string> item, double emitTime)
    {
        PersistEmit(item, emitTime);
        PersistClose();
    }

    /// <summary>Removes any persisted backing resources on destroy (no-op for the in-memory backing).</summary>
    protected virtual void PersistDelete()
    {
    }

    /// <summary>Seeds a rehydrated event into history (used by the file-backed subclass on construction).</summary>
    protected void SeedHistory(SseItem<string> item, double emitTime)
    {
        _history.Add(new HistoryEntry(item, emitTime));
        _lastEventId = item.EventId ?? _lastEventId;
    }

    /// <summary>Marks a rehydrated stream as already closed (terminal sentinel was present).</summary>
    protected void SeedClosed()
    {
        _state = StreamState.Closed;
        _closeTime = _history.Count > 0 ? _history[_history.Count - 1].EmitTime : Now();
    }

    /// <summary>Returns the still-retained events (item + emit time) for on-disk compaction. Must be called under the backing lock.</summary>
    protected IReadOnlyList<KeyValuePair<SseItem<string>, double>> RetainedForCompaction()
    {
        var list = new List<KeyValuePair<SseItem<string>, double>>(_history.Count);
        foreach (HistoryEntry entry in _history)
        {
            list.Add(new KeyValuePair<SseItem<string>, double>(entry.Item, entry.EmitTime));
        }

        return list;
    }

    // Resume strictly after the retained item whose EventId matches afterEventId. A null id yields
    // all retained items; an id no longer in the retained window (evicted, or never seen) replays
    // all retained items — best-effort, matching SSE Last-Event-ID semantics.
    private List<SseItem<string>> SnapshotHistory(string? afterEventId)
    {
        int startIndex = 0;
        if (afterEventId is not null)
        {
            int matchIndex = -1;
            for (int i = 0; i < _history.Count; i++)
            {
                if (string.Equals(_history[i].Item.EventId, afterEventId, StringComparison.Ordinal))
                {
                    matchIndex = i;
                }
            }

            if (matchIndex >= 0)
            {
                startIndex = matchIndex + 1;
            }
        }

        var snapshot = new List<SseItem<string>>(_history.Count - startIndex);
        for (int i = startIndex; i < _history.Count; i++)
        {
            snapshot.Add(_history[i].Item);
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
        public HistoryEntry(SseItem<string> item, double emitTime)
        {
            Item = item;
            EmitTime = emitTime;
        }

        public SseItem<string> Item { get; }

        public double EmitTime { get; }
    }
}
