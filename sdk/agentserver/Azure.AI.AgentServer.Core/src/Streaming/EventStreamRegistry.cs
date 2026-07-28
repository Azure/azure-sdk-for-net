// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming.Backings;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// The process-level <see cref="IEventStreamRegistry"/>. Maps ids to backing
/// instances and wires each stream's close-clock self-destruct back to the
/// registry. Mirrors Python's module-global <c>streams</c> registry, but as an
/// injectable singleton.
/// </summary>
internal sealed class EventStreamRegistry : IEventStreamRegistry
{
    private readonly object _gate = new();
    private readonly Dictionary<string, IEventStream> _streams = new(StringComparer.Ordinal);
    private readonly EventStreamOptions _options;

    public EventStreamRegistry(EventStreamOptions options) => _options = options;

    public ValueTask<IEventStream> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Stream id must be non-empty.", nameof(id));
        }

        IEventStream? stream;
        lock (_gate)
        {
            if (!_streams.TryGetValue(id, out stream))
            {
                throw new EventStreamNotFoundException($"Stream '{id}' is not a live stream.");
            }
        }

        // Opportunistic close-clock check OUTSIDE the registry lock (the stream's self-destruct
        // re-enters the registry): a closed stream whose TTL deadline has elapsed auto-tombstones
        // here so a plain lookup observes it as gone, even without an emit/subscribe.
        if (stream is IDestroyableStream destroyable && destroyable.TryAutoDestroyIfElapsed())
        {
            throw new EventStreamNotFoundException($"Stream '{id}' is not a live stream.");
        }

        return new ValueTask<IEventStream>(stream);
    }

    public ValueTask<IEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Stream id must be non-empty.", nameof(id));
        }

        lock (_gate)
        {
            if (_streams.TryGetValue(id, out IEventStream? existing))
            {
                return new ValueTask<IEventStream>(existing);
            }

            IEventStream created = null!;
            created = _options.CreateStream(id, () => SelfDestruct(id, created));
            _streams[id] = created;
            return new ValueTask<IEventStream>(created);
        }
    }

    public ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Stream id must be non-empty.", nameof(id));
        }

        IEventStream? stream;
        lock (_gate)
        {
            if (_streams.TryGetValue(id, out stream))
            {
                // C-STR-FBR-4: clean up the backing (delete the file) BEFORE tombstoning the id,
                // atomically under the registry lock. This guarantees that a same-id
                // GetOrCreateAsync can never observe a destroyed-but-still-registered stream, and —
                // because the file is gone before the (in-memory) registration is dropped — a crash
                // between the two steps cannot leave a stale file that a later rehydrate resurrects.
                DestroyStream(stream);
                _streams.Remove(id);
            }
        }

        return default;
    }

    // The close-clock auto-tombstone path: a replay backing whose close + TTL has
    // elapsed calls this to remove itself. The stream has already transitioned
    // itself to Destroyed and freed its resources. A later GetOrCreateAsync(id)
    // recreates a fresh stream for the same id. The identity guard ensures a stale
    // self-destruct from a previous instance never evicts a newer same-id stream.
    private void SelfDestruct(string id, IEventStream self)
    {
        lock (_gate)
        {
            if (_streams.TryGetValue(id, out IEventStream? current) && ReferenceEquals(current, self))
            {
                _streams.Remove(id);
            }
        }
    }

    private static void DestroyStream(IEventStream? stream)
    {
        if (stream is IDestroyableStream destroyable)
        {
            destroyable.Destroy();
        }

        if (stream is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
