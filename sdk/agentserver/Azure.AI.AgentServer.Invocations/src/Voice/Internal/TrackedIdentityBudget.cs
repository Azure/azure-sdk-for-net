// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// Thread-safe byte budget shared by receive-pump and callback/send identity
/// tracking paths for one voice connection.
/// </summary>
internal sealed class TrackedIdentityBudget
{
    private readonly long _maximumBytes;
    private readonly VoiceResourceGovernor? _resourceGovernor;
    private long _bytes;

    public TrackedIdentityBudget(
        long maximumBytes,
        VoiceResourceGovernor? resourceGovernor = null)
    {
        if (maximumBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumBytes));
        }

        _maximumBytes = maximumBytes;
        _resourceGovernor = resourceGovernor;
    }

    public long Bytes => Interlocked.Read(ref _bytes);

    public void Reserve(int bytes)
    {
        if (bytes < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bytes));
        }

        _resourceGovernor?.ReserveIdentityBytes(bytes);
        try
        {
            while (true)
            {
                var current = Interlocked.Read(ref _bytes);
                var updated = checked(current + bytes);
                if (updated > _maximumBytes)
                {
                    throw new VoiceResourceExhaustedException("connection identity tracking bytes");
                }

                if (Interlocked.CompareExchange(ref _bytes, updated, current) == current)
                {
                    return;
                }
            }
        }
        catch
        {
            _resourceGovernor?.ReleaseIdentityBytes(bytes);
            throw;
        }
    }

    public void Release(int bytes)
    {
        if (bytes < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bytes));
        }

        while (true)
        {
            var current = Interlocked.Read(ref _bytes);
            if (current < bytes)
            {
                throw new InvalidOperationException("Voice identity accounting underflowed.");
            }

            var updated = current - bytes;
            if (Interlocked.CompareExchange(ref _bytes, updated, current) == current)
            {
                _resourceGovernor?.ReleaseIdentityBytes(bytes);
                return;
            }
        }
    }

    public void Reset()
    {
        var released = Interlocked.Exchange(ref _bytes, 0);
        if (released > 0)
        {
            _resourceGovernor?.ReleaseIdentityBytes(released);
        }
    }
}
