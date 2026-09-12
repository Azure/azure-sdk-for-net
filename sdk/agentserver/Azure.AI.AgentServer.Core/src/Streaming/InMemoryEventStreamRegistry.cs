// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// The process-level in-memory <see cref="AgentEventStreamRegistry"/>. Maps ids to backing
/// instances and wires each stream's close-clock self-destruct back to the
/// registry. Mirrors Python's module-global <c>streams</c> registry, but as an
/// injectable singleton.
/// </summary>
internal sealed class InMemoryEventStreamRegistry :
    AgentEventStreamRegistry,
    ITaskEventStreamRegistry,
    IDisposable
{
    private readonly object _gate = new();
    private readonly Dictionary<string, AgentEventStream> _streams = new(StringComparer.Ordinal);
    private readonly Dictionary<string, string> _taskOwners = new(StringComparer.Ordinal);
    private readonly AgentEventStreamOptions _options;
    private readonly ILogger _logger;
    private readonly Timer? _sweepTimer;
    private bool _disposed;

    public InMemoryEventStreamRegistry(AgentEventStreamOptions options, ILogger? logger = null)
    {
        _options = options;
        _logger = logger ?? NullLogger.Instance;
        if (options.Configuration.Ttl is { } ttl && ttl > TimeSpan.Zero)
        {
            TimeSpan interval = ttl < TimeSpan.FromMinutes(1)
                ? ttl
                : TimeSpan.FromMinutes(1);
            _sweepTimer = new Timer(
                static state => ((InMemoryEventStreamRegistry)state!).SweepExpired(),
                this,
                interval,
                interval);
        }
    }

    internal int StreamCount
    {
        get
        {
            lock (_gate)
            {
                return _streams.Count;
            }
        }
    }

    internal int TaskOwnerCount
    {
        get
        {
            lock (_gate)
            {
                return _taskOwners.Count;
            }
        }
    }

    public override ValueTask<AgentEventStream> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Stream id must be non-empty.", nameof(id));
        }

        AgentEventStream? stream;
        lock (_gate)
        {
            if (!_streams.TryGetValue(id, out stream))
            {
                throw new AgentEventStreamNotFoundException($"Stream '{id}' is not a live stream.");
            }
        }

        // Opportunistic close-clock check OUTSIDE the registry lock (the stream's self-destruct
        // re-enters the registry): a closed stream whose TTL deadline has elapsed auto-tombstones
        // here so a plain lookup observes it as gone, even without an emit/subscribe.
        if (stream is IDestroyableStream destroyable && destroyable.TryAutoDestroyIfElapsed())
        {
            throw new AgentEventStreamNotFoundException($"Stream '{id}' is not a live stream.");
        }

        return new ValueTask<AgentEventStream>(stream);
    }

    public override ValueTask<AgentEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Stream id must be non-empty.", nameof(id));
        }

        lock (_gate)
        {
            if (_streams.TryGetValue(id, out AgentEventStream? existing))
            {
                return new ValueTask<AgentEventStream>(existing);
            }

            AgentEventStream created = null!;
            created = _options.CreateStream(id, () => SelfDestruct(id, created));
            _streams[id] = created;
            if (created is ITaskOwnedEventStream { TaskId: { } taskId })
            {
                _taskOwners[id] = taskId;
            }

            return new ValueTask<AgentEventStream>(created);
        }
    }

    public ValueTask<AgentEventStream> GetOrCreateTaskStreamAsync(
        string taskId,
        string inputId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(taskId))
        {
            throw new ArgumentException("Task id must be non-empty.", nameof(taskId));
        }

        if (string.IsNullOrEmpty(inputId))
        {
            throw new ArgumentException("Input id must be non-empty.", nameof(inputId));
        }

        lock (_gate)
        {
            if (_taskOwners.TryGetValue(inputId, out string? owner) &&
                !string.Equals(owner, taskId, StringComparison.Ordinal))
            {
                throw TaskOwnershipConflict(inputId, owner, taskId);
            }

            if (_streams.TryGetValue(inputId, out AgentEventStream? existing))
            {
                if (existing is ITaskOwnedEventStream taskOwned)
                {
                    taskOwned.ValidateOrClaimTask(taskId);
                }

                _taskOwners[inputId] = taskId;
                return new ValueTask<AgentEventStream>(existing);
            }

            AgentEventStream created = null!;
            created = _options.CreateStream(
                inputId,
                () => SelfDestruct(inputId, created),
                taskId);
            _streams[inputId] = created;
            _taskOwners[inputId] = taskId;
            return new ValueTask<AgentEventStream>(created);
        }
    }

    public ValueTask<AgentEventStream?> GetTaskStreamAsync(
        string taskId,
        string inputId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(taskId))
        {
            throw new ArgumentException("Task id must be non-empty.", nameof(taskId));
        }

        if (string.IsNullOrEmpty(inputId))
        {
            throw new ArgumentException("Input id must be non-empty.", nameof(inputId));
        }

        lock (_gate)
        {
            if (_taskOwners.TryGetValue(inputId, out string? owner)
                && !string.Equals(owner, taskId, StringComparison.Ordinal))
            {
                throw TaskOwnershipConflict(inputId, owner, taskId);
            }

            if (_streams.TryGetValue(inputId, out AgentEventStream? existing))
            {
                if (existing is ITaskOwnedEventStream taskOwned)
                {
                    taskOwned.ValidateOrClaimTask(taskId);
                }

                _taskOwners[inputId] = taskId;
                return new ValueTask<AgentEventStream?>(existing);
            }

            AgentEventStream created = null!;
            AgentEventStream? persisted = _options.CreateExistingTaskStream(
                inputId,
                () => SelfDestruct(inputId, created),
                taskId);
            if (persisted is null)
            {
                return new ValueTask<AgentEventStream?>((AgentEventStream?)null);
            }

            created = persisted;
            _streams[inputId] = created;
            _taskOwners[inputId] = taskId;
            return new ValueTask<AgentEventStream?>(created);
        }
    }

    public override ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Stream id must be non-empty.", nameof(id));
        }

        AgentEventStream? stream;
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
                _taskOwners.Remove(id);
            }
        }

        return default;
    }

    // The close-clock auto-tombstone path: a replay backing whose close + TTL has
    // elapsed calls this to remove itself. The stream has already transitioned
    // itself to Destroyed and freed its resources. A later GetOrCreateAsync(id)
    // recreates a fresh stream for the same id. The identity guard ensures a stale
    // self-destruct from a previous instance never evicts a newer same-id stream.
    private void SelfDestruct(string id, AgentEventStream self)
    {
        lock (_gate)
        {
            if (_streams.TryGetValue(id, out AgentEventStream? current) && ReferenceEquals(current, self))
            {
                _streams.Remove(id);
                _taskOwners.Remove(id);
            }
        }
    }

    private void SweepExpired()
    {
        IDestroyableStream[] streams;
        lock (_gate)
        {
            if (_disposed)
            {
                return;
            }

            streams = _streams.Values.OfType<IDestroyableStream>().ToArray();
        }

        foreach (IDestroyableStream stream in streams)
        {
            try
            {
                stream.TryAutoDestroyIfElapsed();
            }
            catch (Exception exception)
            {
                _logger.LogWarning(
                    exception,
                    "Failed to sweep an expired agent event stream; the next sweep will retry.");
            }
        }
    }

    public void Dispose()
    {
        IDisposable[] streams;
        lock (_gate)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _sweepTimer?.Dispose();
            streams = _streams.Values.OfType<IDisposable>().ToArray();
            _streams.Clear();
            _taskOwners.Clear();
        }

        foreach (IDisposable stream in streams)
        {
            stream.Dispose();
        }
    }

    private static void DestroyStream(AgentEventStream? stream)
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

    private static AgentEventStreamException TaskOwnershipConflict(
        string inputId,
        string existingTaskId,
        string requestedTaskId)
        => new(
            $"Task stream input id '{inputId}' is already owned by task " +
            $"'{existingTaskId}' and cannot be reused by task '{requestedTaskId}'. " +
            "Explicit input ids used for task-bound streams must be unique across tasks.");
}
