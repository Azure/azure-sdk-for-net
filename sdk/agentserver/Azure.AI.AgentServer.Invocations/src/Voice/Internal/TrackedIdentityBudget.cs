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
    private long _bytes;

    public TrackedIdentityBudget(long maximumBytes)
    {
        if (maximumBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumBytes));
        }

        _maximumBytes = maximumBytes;
    }

    public long Bytes => Interlocked.Read(ref _bytes);

    public void Reserve(int bytes)
    {
        if (bytes < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bytes));
        }

        while (true)
        {
            var current = Interlocked.Read(ref _bytes);
            var updated = checked(current + bytes);
            if (updated > _maximumBytes)
            {
                throw new VoiceBridgeProtocolException(
                    "Identity tracking byte limit exceeded.",
                    VoiceProtocolConstants.ClosePolicyViolation);
            }

            if (Interlocked.CompareExchange(ref _bytes, updated, current) == current)
            {
                return;
            }
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
            var updated = Math.Max(0, current - bytes);
            if (Interlocked.CompareExchange(ref _bytes, updated, current) == current)
            {
                return;
            }
        }
    }

    public void Reset() => Interlocked.Exchange(ref _bytes, 0);
}
