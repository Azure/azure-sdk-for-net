// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Invocations.Voice;

internal sealed class VoiceActivityScope : IDisposable
{
    internal static VoiceActivityScope Empty { get; } = new(previous: null, isActive: false);

    private readonly Activity? _previous;
    private int _disposed;

    private VoiceActivityScope(Activity? previous, bool isActive)
    {
        _previous = previous;
        IsActive = isActive;
    }

    internal bool IsActive { get; }

    internal static VoiceActivityScope Activate(Activity? activity)
    {
        if (activity is null || activity.Duration != default)
        {
            return Empty;
        }

        var previous = Activity.Current;
        if (!TrySetCurrent(activity) || activity.Duration != default)
        {
            TrySetCurrent(previous);
            return Empty;
        }
        return new VoiceActivityScope(previous, isActive: true);
    }

    internal static bool TrySetCurrent(Activity? activity)
    {
        try
        {
            Activity.Current = activity;
            return true;
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
            return false;
        }
    }

    public void Dispose()
    {
        if (IsActive && Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            TrySetCurrent(_previous);
        }
    }

    private static bool ContainsOutOfMemoryException(Exception exception)
    {
        if (exception is OutOfMemoryException)
        {
            return true;
        }
        return exception is AggregateException aggregateException &&
            aggregateException.InnerExceptions.Any(ContainsOutOfMemoryException);
    }
}
