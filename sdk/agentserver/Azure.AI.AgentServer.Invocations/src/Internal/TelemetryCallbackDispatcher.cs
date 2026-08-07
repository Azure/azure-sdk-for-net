// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Invocations.Internal;

internal enum CriticalTelemetryEnqueueResult
{
    Accepted,
    DeadlineExpired,
    DispatcherCompleted,
}

/// <summary>
/// Isolates synchronous telemetry callbacks from protocol and teardown paths.
/// A bounded, fixed-size background worker pool prevents one blocked listener
/// or exporter from consuming the host's only telemetry execution slot without
/// allowing unbounded threads or an unbounded work queue. Callback completion
/// order is not guaranteed when more than one worker is configured.
/// </summary>
internal sealed class TelemetryCallbackDispatcher : IDisposable
{
    private const int QueueCapacity = 256;
    private const int CriticalQueueCapacity = 256;
    private const int ActivityCapacity = 128;

    private readonly Queue<Action> _callbacks = new();
    private readonly Queue<Action> _criticalCallbacks = new();
    private readonly Queue<Action> _activityStops = new();
    private readonly SemaphoreSlim _criticalSlots = new(CriticalQueueCapacity, CriticalQueueCapacity);
    private readonly object _sync = new();
    private readonly TaskCompletionSource _workerCompletion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly int _workerCount;
    private int _started;
    private int _completed;
    private int _workersRemaining;
    private int _activityReservations;
    private long _droppedCallbacks;

    public TelemetryCallbackDispatcher()
        : this(workerCount: 1)
    {
    }

    internal TelemetryCallbackDispatcher(int workerCount)
    {
        if (workerCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(workerCount));
        }

        _workerCount = workerCount;
    }

    internal long DroppedCallbackCount => Interlocked.Read(ref _droppedCallbacks);

    internal Task WorkerCompletion => _workerCompletion.Task;

    public bool TryQueue(Action callback)
    {
        ArgumentNullException.ThrowIfNull(callback);
        lock (_sync)
        {
            if (_completed != 0 || _callbacks.Count >= QueueCapacity)
            {
                Interlocked.Increment(ref _droppedCallbacks);
                InvocationsTelemetry.RecordDroppedCallback();
                return false;
            }

            _callbacks.Enqueue(callback);
            System.Threading.Monitor.Pulse(_sync);
        }

        EnsureStarted();
        return true;
    }

    public bool TryQueueCritical(Action callback)
    {
        ArgumentNullException.ThrowIfNull(callback);
        if (!_criticalSlots.Wait(0))
        {
            RecordDroppedCallback();
            return false;
        }

        lock (_sync)
        {
            if (_completed != 0)
            {
                _criticalSlots.Release();
                RecordDroppedCallback();
                return false;
            }

            _criticalCallbacks.Enqueue(callback);
            System.Threading.Monitor.Pulse(_sync);
        }

        EnsureStarted();
        return true;
    }

    public async ValueTask<CriticalTelemetryEnqueueResult> QueueCriticalAsync(
        Action callback,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(callback);
        try
        {
            await _criticalSlots.WaitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            RecordDroppedCallback();
            return CriticalTelemetryEnqueueResult.DeadlineExpired;
        }

        lock (_sync)
        {
            if (_completed != 0)
            {
                _criticalSlots.Release();
                RecordDroppedCallback();
                return CriticalTelemetryEnqueueResult.DispatcherCompleted;
            }

            _criticalCallbacks.Enqueue(callback);
            System.Threading.Monitor.Pulse(_sync);
        }

        EnsureStarted();
        return CriticalTelemetryEnqueueResult.Accepted;
    }

    public bool TryReserveActivity()
    {
        lock (_sync)
        {
            if (_completed != 0 || _activityReservations >= ActivityCapacity)
            {
                return false;
            }

            _activityReservations++;
            return true;
        }
    }

    public bool TryQueueActivityStop(Action callback)
    {
        ArgumentNullException.ThrowIfNull(callback);
        lock (_sync)
        {
            if (_activityReservations == 0)
            {
                return false;
            }

            // Every activity stop consumes a reservation acquired before its
            // corresponding start. Therefore this queue cannot exceed the
            // fixed ActivityCapacity and never needs to drop lifecycle work.
            _activityStops.Enqueue(callback);
            System.Threading.Monitor.Pulse(_sync);
        }

        EnsureStarted();
        return true;
    }

    public void ReleaseActivity()
    {
        lock (_sync)
        {
            if (_activityReservations > 0)
            {
                _activityReservations--;
                if (_activityReservations == 0 && _completed != 0)
                {
                    CompleteOrWakeWorkersLocked();
                }
            }
        }
    }

    public void Dispose()
    {
        lock (_sync)
        {
            if (_completed != 0)
            {
                return;
            }

            _completed = 1;
            if (_activityReservations == 0)
            {
                CompleteOrWakeWorkersLocked();
            }
        }
    }

    private void CompleteOrWakeWorkersLocked()
    {
        if (_started == 0 &&
            _activityStops.Count == 0 &&
            _criticalCallbacks.Count == 0 &&
            _callbacks.Count == 0)
        {
            _workerCompletion.TrySetResult();
        }
        else
        {
            System.Threading.Monitor.PulseAll(_sync);
        }
    }

    private void EnsureStarted()
    {
        if (Interlocked.CompareExchange(ref _started, 1, 0) != 0)
        {
            return;
        }

        Volatile.Write(ref _workersRemaining, _workerCount);
        for (var index = 0; index < _workerCount; index++)
        {
            var thread = new Thread(Run)
            {
                IsBackground = true,
                Name = _workerCount == 1
                    ? "AgentServer telemetry callbacks"
                    : $"AgentServer telemetry callbacks {index + 1}",
            };
            try
            {
                thread.Start();
            }
            catch
            {
                if (Interlocked.Add(ref _workersRemaining, index - _workerCount) == 0)
                {
                    _workerCompletion.TrySetResult();
                }
                throw;
            }
        }
    }

    private void Run()
    {
        try
        {
            while (true)
            {
                Action callback;
                lock (_sync)
                {
                    while (_activityStops.Count == 0 &&
                        _criticalCallbacks.Count == 0 &&
                        _callbacks.Count == 0)
                    {
                        if (_completed != 0 && _activityReservations == 0)
                        {
                            return;
                        }

                        System.Threading.Monitor.Wait(_sync);
                    }

                    if (_activityStops.Count > 0)
                    {
                        callback = _activityStops.Dequeue();
                    }
                    else if (_criticalCallbacks.Count > 0)
                    {
                        callback = _criticalCallbacks.Dequeue();
                        _criticalSlots.Release();
                    }
                    else
                    {
                        callback = _callbacks.Dequeue();
                    }
                }

                var previousActivity = Activity.Current;
                try
                {
                    callback();
                }
#pragma warning disable CA1031 // Telemetry must never fault the protocol runtime.
                catch (Exception)
#pragma warning restore CA1031
                {
                }
                finally
                {
                    Activity.Current = previousActivity;
                }
            }
        }
        finally
        {
            WorkerExited();
        }
    }

    private void WorkerExited()
    {
        if (Interlocked.Decrement(ref _workersRemaining) == 0)
        {
            _workerCompletion.TrySetResult();
        }
    }

    private void RecordDroppedCallback()
    {
        Interlocked.Increment(ref _droppedCallbacks);
        InvocationsTelemetry.RecordDroppedCallback();
    }
}
