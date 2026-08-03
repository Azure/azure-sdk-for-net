// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// One monotonic, non-restarting cleanup budget shared by every teardown phase.
/// </summary>
internal sealed class CleanupDeadline
{
    private const long NotStarted = long.MinValue;

    private readonly TimeSpan _budget;
    private readonly TimeProvider _timeProvider;
    private long _deadlineTimestamp = NotStarted;

    public CleanupDeadline(TimeSpan budget, TimeProvider? timeProvider = null)
    {
        if (budget <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(budget));
        }

        _budget = budget;
        _timeProvider = timeProvider ?? TimeProvider.System;
    }

    public TimeSpan Remaining
    {
        get
        {
            var deadline = Volatile.Read(ref _deadlineTimestamp);
            if (deadline == NotStarted)
            {
                return _budget;
            }

            var remainingTicks = deadline - _timeProvider.GetTimestamp();
            if (remainingTicks <= 0)
            {
                return TimeSpan.Zero;
            }

            return TimeSpan.FromSeconds((double)remainingTicks / _timeProvider.TimestampFrequency);
        }
    }

    public bool IsStarted => Volatile.Read(ref _deadlineTimestamp) != NotStarted;

    public void Start()
    {
        var durationTicks = checked((long)Math.Ceiling(_budget.TotalSeconds * _timeProvider.TimestampFrequency));
        var deadline = checked(_timeProvider.GetTimestamp() + durationTicks);
        Interlocked.CompareExchange(ref _deadlineTimestamp, deadline, NotStarted);
    }

    public CancellationTokenSource CreateCancellationTokenSource()
    {
        Start();
        var source = new CancellationTokenSource();
        var remaining = Remaining;
        if (remaining <= TimeSpan.Zero)
        {
            source.Cancel();
        }
        else
        {
            source.CancelAfter(remaining);
        }

        return source;
    }
}
