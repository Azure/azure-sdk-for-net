// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// Host-wide limits for retained work owned by the Voice runtime. Customer-owned
/// memory and transport-internal buffers are deliberately outside this scope.
/// </summary>
internal sealed class VoiceResourceLimits
{
    public int MaxConnections { get; init; } = 1024;

    public int MaxCustomerTasks { get; init; } = 1024;

    public int MaxTerminalCustomerTasks { get; init; } = 64;

    public int MaxCleanupTasks { get; init; } = 2048;

    public int MaxPendingOperations { get; init; } = 4096;

    public long MaxPreparedFrameBytes { get; init; } = 64L * 1024 * 1024;

    public int MaxPreparedFrames { get; init; } = 256;

    public long MaxControlFrameBytes { get; init; } = 8L * 1024 * 1024;

    public int MaxControlFrames { get; init; } = 64;

    public long MaxCallbackQueueBytes { get; init; } = 64L * 1024 * 1024;

    public int MaxCallbackQueueItems { get; init; } = 1024;

    public long MaxTrackedIdentityBytes { get; init; } = 256L * 1024 * 1024;

    public long MaxRetainedOutputBytes { get; init; } = 64L * 1024 * 1024;

    public int MaxRetainedOutputItems { get; init; } = 8192;

    public int MaxRetainedOutputChunks { get; init; } = 65536;

    public int MaxOutputWrites { get; init; } = 131072;

    public long MaxResponseOutputBytes { get; init; } = 2L * VoiceProtocolConstants.MaxResponseBytes;

    public int MaxResponseOutputItems { get; init; } = VoiceProtocolConstants.MaxResponseItems;

    public int MaxResponseOutputChunks { get; init; } = 16384;

    public int MaxResponseOutputWrites { get; init; } = 17408;
}

/// <summary>Raised when host-owned Voice work cannot be admitted safely.</summary>
internal sealed class VoiceResourceExhaustedException : InvalidOperationException
{
    public VoiceResourceExhaustedException(string resource)
        : base($"The host-wide Voice {resource} budget is exhausted.")
    {
        Resource = resource;
    }

    public string Resource { get; }
}

/// <summary>
/// One host-scoped governor shared by every Voice connection created through the
/// same AgentServer dependency-injection container.
/// </summary>
internal sealed class VoiceResourceGovernor
{
    private readonly object _sync = new();
    private readonly VoiceResourceLimits _limits;
    private long _connectionCount;
    private long _customerTaskCount;
    private long _terminalCustomerTaskCount;
    private long _cleanupTaskCount;
    private long _pendingOperationCount;
    private long _preparedFrameBytes;
    private long _preparedFrameCount;
    private long _controlFrameBytes;
    private long _controlFrameCount;
    private long _callbackQueueBytes;
    private long _callbackQueueItems;
    private long _trackedIdentityBytes;
    private long _retainedOutputBytes;
    private long _retainedOutputItems;
    private long _retainedOutputChunks;
    private long _outputWriteCount;

    public VoiceResourceGovernor()
        : this(new VoiceResourceLimits())
    {
    }

    internal VoiceResourceGovernor(VoiceResourceLimits limits)
    {
        _limits = limits ?? throw new ArgumentNullException(nameof(limits));
        ValidateLimits(limits);
    }

    internal long ConnectionCount => Read(static governor => governor._connectionCount);

    internal long CustomerTaskCount => Read(static governor => governor._customerTaskCount);

    internal long TerminalCustomerTaskCount => Read(static governor => governor._terminalCustomerTaskCount);

    internal long CleanupTaskCount => Read(static governor => governor._cleanupTaskCount);

    internal long PendingOperationCount => Read(static governor => governor._pendingOperationCount);

    internal long PreparedFrameBytes => Read(static governor => governor._preparedFrameBytes);

    internal long PreparedFrameCount => Read(static governor => governor._preparedFrameCount);

    internal long CallbackQueueBytes => Read(static governor => governor._callbackQueueBytes);

    internal long CallbackQueueItems => Read(static governor => governor._callbackQueueItems);

    internal long TrackedIdentityBytes => Read(static governor => governor._trackedIdentityBytes);

    internal long RetainedOutputBytes => Read(static governor => governor._retainedOutputBytes);

    internal long RetainedOutputItems => Read(static governor => governor._retainedOutputItems);

    internal long RetainedOutputChunks => Read(static governor => governor._retainedOutputChunks);

    internal long OutputWriteCount => Read(static governor => governor._outputWriteCount);

    internal VoiceResourceLease AcquireConnection() =>
        Acquire(
            "connection",
            static governor => governor._connectionCount,
            static (governor, value) => governor._connectionCount = value,
            1,
            _limits.MaxConnections);

    internal VoiceResourceLease AcquireCallbackQueueItem(int bytes)
    {
        if (bytes < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bytes));
        }

        lock (_sync)
        {
            EnsureAvailable(_callbackQueueBytes, bytes, _limits.MaxCallbackQueueBytes, "callback queue bytes");
            EnsureAvailable(_callbackQueueItems, 1, _limits.MaxCallbackQueueItems, "callback queue items");
            _callbackQueueBytes = checked(_callbackQueueBytes + bytes);
            _callbackQueueItems++;
        }

        return new VoiceResourceLease(() =>
        {
            lock (_sync)
            {
                SubtractExact(ref _callbackQueueBytes, bytes, "callback queue bytes");
                SubtractExact(ref _callbackQueueItems, 1, "callback queue items");
            }
        });
    }

    internal VoiceResourceLease AcquirePreparedFrames(int frameCount, long reservedBytes, bool control)
    {
        if (frameCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(frameCount));
        }

        if (reservedBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(reservedBytes));
        }

        lock (_sync)
        {
            if (control)
            {
                EnsureAvailable(_controlFrameBytes, reservedBytes, _limits.MaxControlFrameBytes, "control frame bytes");
                EnsureAvailable(_controlFrameCount, frameCount, _limits.MaxControlFrames, "control frame count");
                _controlFrameBytes = checked(_controlFrameBytes + reservedBytes);
                _controlFrameCount = checked(_controlFrameCount + frameCount);
            }
            else
            {
                EnsureAvailable(_preparedFrameBytes, reservedBytes, _limits.MaxPreparedFrameBytes, "prepared frame bytes");
                EnsureAvailable(_preparedFrameCount, frameCount, _limits.MaxPreparedFrames, "prepared frame count");
                _preparedFrameBytes = checked(_preparedFrameBytes + reservedBytes);
                _preparedFrameCount = checked(_preparedFrameCount + frameCount);
            }
        }

        return new VoiceResourceLease(() =>
        {
            lock (_sync)
            {
                if (control)
                {
                    SubtractExact(ref _controlFrameBytes, reservedBytes, "control frame bytes");
                    SubtractExact(ref _controlFrameCount, frameCount, "control frame count");
                }
                else
                {
                    SubtractExact(ref _preparedFrameBytes, reservedBytes, "prepared frame bytes");
                    SubtractExact(ref _preparedFrameCount, frameCount, "prepared frame count");
                }
            }
        });
    }

    internal Task InvokeCustomerTask(Func<Task> callback, bool terminal = false)
    {
        ArgumentNullException.ThrowIfNull(callback);
        VoiceResourceLease lease;
        try
        {
            lease = terminal
                ? Acquire(
                    "terminal customer task",
                    static governor => governor._terminalCustomerTaskCount,
                    static (governor, value) => governor._terminalCustomerTaskCount = value,
                    1,
                    _limits.MaxTerminalCustomerTasks)
                : Acquire(
                    "customer task",
                    static governor => governor._customerTaskCount,
                    static (governor, value) => governor._customerTaskCount = value,
                    1,
                    _limits.MaxCustomerTasks);
        }
        catch (Exception exception)
        {
            return Task.FromException(exception);
        }

        Task task;
        try
        {
            task = callback() ?? Task.FromException(
                new InvalidOperationException("A voice callback returned a null task."));
        }
#pragma warning disable CA1031 // Synchronous customer failures are represented by the returned task.
        catch (Exception exception)
#pragma warning restore CA1031
        {
            task = Task.FromException(exception);
        }

        if (task.IsCompleted)
        {
            lease.Dispose();
            return task;
        }

        return CompleteCustomerTaskAsync(task, lease);
    }

    internal VoiceResponseResources CreateResponseResources() => new(this, _limits);

    internal VoiceResourceLease AcquireCleanupTask() =>
        Acquire(
            "cleanup task",
            static governor => governor._cleanupTaskCount,
            static (governor, value) => governor._cleanupTaskCount = value,
            1,
            _limits.MaxCleanupTasks);

    internal VoiceResourceLease AcquirePendingOperation() =>
        Acquire(
            "pending operation",
            static governor => governor._pendingOperationCount,
            static (governor, value) => governor._pendingOperationCount = value,
            1,
            _limits.MaxPendingOperations);

    private static async Task CompleteCustomerTaskAsync(Task task, VoiceResourceLease lease)
    {
        try
        {
            await task.ConfigureAwait(false);
        }
        finally
        {
            lease.Dispose();
        }
    }

    internal void ReserveIdentityBytes(int bytes)
    {
        if (bytes < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bytes));
        }

        lock (_sync)
        {
            EnsureAvailable(_trackedIdentityBytes, bytes, _limits.MaxTrackedIdentityBytes, "tracked identity bytes");
            _trackedIdentityBytes = checked(_trackedIdentityBytes + bytes);
        }
    }

    internal void ReleaseIdentityBytes(long bytes)
    {
        if (bytes < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bytes));
        }

        lock (_sync)
        {
            SubtractExact(ref _trackedIdentityBytes, bytes, "tracked identity bytes");
        }
    }

    internal VoiceOutputReservation ReserveOutput(
        VoiceResponseResources owner,
        long bytes,
        int items,
        int chunks,
        int writes)
    {
        lock (_sync)
        {
            owner.EnsureAvailable(bytes, items, chunks, writes);
            EnsureAvailable(_retainedOutputBytes, bytes, _limits.MaxRetainedOutputBytes, "retained output bytes");
            EnsureAvailable(_retainedOutputItems, items, _limits.MaxRetainedOutputItems, "retained output items");
            EnsureAvailable(_retainedOutputChunks, chunks, _limits.MaxRetainedOutputChunks, "retained output chunks");
            EnsureAvailable(_outputWriteCount, writes, _limits.MaxOutputWrites, "output writes");
            _retainedOutputBytes = checked(_retainedOutputBytes + bytes);
            _retainedOutputItems = checked(_retainedOutputItems + items);
            _retainedOutputChunks = checked(_retainedOutputChunks + chunks);
            _outputWriteCount = checked(_outputWriteCount + writes);
        }

        return new VoiceOutputReservation(this, owner, bytes, items, chunks, writes);
    }

    internal void CommitOutput(VoiceResponseResources owner, long bytes, int items, int chunks, int writes)
    {
        lock (_sync)
        {
            owner.Commit(bytes, items, chunks, writes);
        }
    }

    internal void RollbackOutput(long bytes, int items, int chunks, int writes)
    {
        lock (_sync)
        {
            ReleaseOutputLocked(bytes, items, chunks, writes);
        }
    }

    internal void ReleaseOutput(VoiceResponseResources owner)
    {
        lock (_sync)
        {
            var released = owner.ReleaseAllLocked();
            ReleaseOutputLocked(released.Bytes, released.Items, released.Chunks, released.Writes);
        }
    }

    internal void ReleaseOutputContent(VoiceResponseResources owner)
    {
        lock (_sync)
        {
            var released = owner.ReleaseContentLocked();
            ReleaseOutputLocked(released.Bytes, 0, released.Chunks, released.Writes);
        }
    }

    internal void ReleaseOutputItems(VoiceResponseResources owner, int items)
    {
        lock (_sync)
        {
            owner.ReleaseItemsLocked(items);
            ReleaseOutputLocked(0, items, 0, 0);
        }
    }

    private VoiceResourceLease Acquire(
        string resource,
        Func<VoiceResourceGovernor, long> read,
        Action<VoiceResourceGovernor, long> write,
        long amount,
        long maximum)
    {
        lock (_sync)
        {
            var current = read(this);
            EnsureAvailable(current, amount, maximum, resource);
            write(this, checked(current + amount));
        }

        return new VoiceResourceLease(() =>
        {
            lock (_sync)
            {
                var current = read(this);
                if (current < amount)
                {
                    throw new InvalidOperationException($"Voice {resource} accounting underflowed.");
                }

                write(this, current - amount);
            }
        });
    }

    private long Read(Func<VoiceResourceGovernor, long> read)
    {
        lock (_sync)
        {
            return read(this);
        }
    }

    private void ReleaseOutputLocked(long bytes, long items, long chunks, long writes)
    {
        SubtractExact(ref _retainedOutputBytes, bytes, "retained output bytes");
        SubtractExact(ref _retainedOutputItems, items, "retained output items");
        SubtractExact(ref _retainedOutputChunks, chunks, "retained output chunks");
        SubtractExact(ref _outputWriteCount, writes, "output writes");
    }

    internal static void EnsureAvailable(long current, long amount, long maximum, string resource)
    {
        var updated = checked(current + amount);
        if (updated > maximum)
        {
            throw new VoiceResourceExhaustedException(resource);
        }
    }

    private static void SubtractExact(ref long current, long amount, string resource)
    {
        if (amount < 0 || current < amount)
        {
            throw new InvalidOperationException($"Voice {resource} accounting underflowed.");
        }

        current -= amount;
    }

    private static void ValidateLimits(VoiceResourceLimits limits)
    {
        var values = new long[]
        {
            limits.MaxConnections,
            limits.MaxCustomerTasks,
            limits.MaxTerminalCustomerTasks,
            limits.MaxCleanupTasks,
            limits.MaxPendingOperations,
            limits.MaxPreparedFrameBytes,
            limits.MaxPreparedFrames,
            limits.MaxControlFrameBytes,
            limits.MaxControlFrames,
            limits.MaxCallbackQueueBytes,
            limits.MaxCallbackQueueItems,
            limits.MaxTrackedIdentityBytes,
            limits.MaxRetainedOutputBytes,
            limits.MaxRetainedOutputItems,
            limits.MaxRetainedOutputChunks,
            limits.MaxOutputWrites,
            limits.MaxResponseOutputBytes,
            limits.MaxResponseOutputItems,
            limits.MaxResponseOutputChunks,
            limits.MaxResponseOutputWrites,
        };
        if (values.Any(value => value <= 0))
        {
            throw new ArgumentOutOfRangeException(nameof(limits), "Every Voice resource limit must be positive.");
        }
    }
}

/// <summary>One exactly-once transferable resource reservation.</summary>
internal sealed class VoiceResourceLease : IDisposable
{
    private Action? _release;

    internal VoiceResourceLease(Action release)
    {
        _release = release ?? throw new ArgumentNullException(nameof(release));
    }

    internal VoiceResourceLease Transfer()
    {
        var release = Interlocked.Exchange(ref _release, null) ??
            throw new InvalidOperationException("The Voice resource lease is no longer owned.");
        return new VoiceResourceLease(release);
    }

    public void Dispose()
    {
        var release = Interlocked.Exchange(ref _release, null);
        release?.Invoke();
    }
}

/// <summary>Committed and in-flight resource accounting for one response.</summary>
internal sealed class VoiceResponseResources
{
    private readonly VoiceResourceGovernor _governor;
    private readonly VoiceResourceLimits _limits;
    private long _bytes;
    private long _items;
    private long _chunks;
    private long _writes;
    private bool _released;

    internal VoiceResponseResources(VoiceResourceGovernor governor, VoiceResourceLimits limits)
    {
        _governor = governor;
        _limits = limits;
    }

    internal VoiceOutputReservation Reserve(long bytes = 0, int items = 0, int chunks = 0, int writes = 0)
    {
        if (bytes < 0 || items < 0 || chunks < 0 || writes < 0 ||
            bytes + items + chunks + writes == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bytes));
        }

        return _governor.ReserveOutput(this, bytes, items, chunks, writes);
    }

    internal void ReleaseAll() => _governor.ReleaseOutput(this);

    internal void ReleaseContent() => _governor.ReleaseOutputContent(this);

    internal void ReleaseItems(int items) => _governor.ReleaseOutputItems(this, items);

    internal void EnsureAvailable(long bytes, long items, long chunks, long writes)
    {
        if (_released)
        {
            throw new VoiceBridgeConnectionClosedException("The voice response no longer retains output resources.");
        }

        VoiceResourceGovernor.EnsureAvailable(_bytes, bytes, _limits.MaxResponseOutputBytes, "response output bytes");
        VoiceResourceGovernor.EnsureAvailable(_items, items, _limits.MaxResponseOutputItems, "response output items");
        VoiceResourceGovernor.EnsureAvailable(_chunks, chunks, _limits.MaxResponseOutputChunks, "response output chunks");
        VoiceResourceGovernor.EnsureAvailable(_writes, writes, _limits.MaxResponseOutputWrites, "response output writes");
    }

    internal void Commit(long bytes, long items, long chunks, long writes)
    {
        if (_released)
        {
            throw new InvalidOperationException("Released Voice response resources cannot be committed.");
        }

        _bytes = checked(_bytes + bytes);
        _items = checked(_items + items);
        _chunks = checked(_chunks + chunks);
        _writes = checked(_writes + writes);
    }

    internal (long Bytes, long Items, long Chunks, long Writes) ReleaseAllLocked()
    {
        if (_released)
        {
            return default;
        }

        _released = true;
        var released = (_bytes, _items, _chunks, _writes);
        _bytes = 0;
        _items = 0;
        _chunks = 0;
        _writes = 0;
        return released;
    }

    internal (long Bytes, long Chunks, long Writes) ReleaseContentLocked()
    {
        if (_released)
        {
            return default;
        }

        var released = (_bytes, _chunks, _writes);
        _bytes = 0;
        _chunks = 0;
        _writes = 0;
        return released;
    }

    internal void ReleaseItemsLocked(int items)
    {
        if (_released || items < 0 || _items < items)
        {
            throw new InvalidOperationException("Voice response item accounting underflowed.");
        }

        _items -= items;
    }
}

/// <summary>One rollback-unless-committed output reservation.</summary>
internal sealed class VoiceOutputReservation : IDisposable
{
    private readonly VoiceResourceGovernor _governor;
    private readonly VoiceResponseResources _owner;
    private readonly long _bytes;
    private readonly int _items;
    private readonly int _chunks;
    private readonly int _writes;
    private int _committed;
    private int _disposed;

    internal VoiceOutputReservation(
        VoiceResourceGovernor governor,
        VoiceResponseResources owner,
        long bytes,
        int items,
        int chunks,
        int writes)
    {
        _governor = governor;
        _owner = owner;
        _bytes = bytes;
        _items = items;
        _chunks = chunks;
        _writes = writes;
    }

    internal void Commit()
    {
        if (Volatile.Read(ref _disposed) != 0)
        {
            throw new ObjectDisposedException(nameof(VoiceOutputReservation));
        }

        if (Interlocked.Exchange(ref _committed, 1) != 0)
        {
            throw new InvalidOperationException("The Voice output reservation was already committed.");
        }

        try
        {
            _governor.CommitOutput(_owner, _bytes, _items, _chunks, _writes);
        }
        catch
        {
            Volatile.Write(ref _committed, 0);
            throw;
        }
    }

    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) != 0)
        {
            return;
        }

        if (Volatile.Read(ref _committed) == 0)
        {
            _governor.RollbackOutput(_bytes, _items, _chunks, _writes);
        }
    }
}
