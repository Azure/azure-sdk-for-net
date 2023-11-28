// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class MessageDelay
{
    internal static readonly MessageDelay Default = new MessageDelay();

    private static readonly TimeSpan DefaultInitialDelay = TimeSpan.FromSeconds(0.8);
    private static readonly TimeSpan DefaultMaxDelay = TimeSpan.FromMinutes(1);

    private int _delayCount;
    private readonly TimeSpan _initialDelay;

    public MessageDelay()
    {
        _initialDelay = DefaultInitialDelay;
    }

    internal void Delay(PipelineMessage message, CancellationToken cancellationToken)
    {
        TimeSpan delay = GetDelay(message, _delayCount++);
        if (delay > TimeSpan.Zero)
        {
            Wait(delay, cancellationToken);
        }

        OnDelayComplete(message);
    }

    internal virtual async Task DelayAsync(PipelineMessage message, CancellationToken cancellationToken)
    {
        TimeSpan delay = GetDelay(message, _delayCount++);
        if (delay > TimeSpan.Zero)
        {
            await WaitAsync(delay, cancellationToken).ConfigureAwait(false);
        }

        OnDelayComplete(message);
    }

    protected virtual void Wait(TimeSpan duration, CancellationToken cancellationToken)
    {
        cancellationToken.WaitHandle.WaitOne(duration);
    }

    protected virtual async Task WaitAsync(TimeSpan duration, CancellationToken cancellationToken)
    {
        await Task.Delay(duration, cancellationToken).ConfigureAwait(false);
    }

    protected virtual TimeSpan GetDelay(PipelineMessage message, int delayCount)
    {
        // Default implementation is exponential backoff.
        return TimeSpan.FromMilliseconds((1 << delayCount) * _initialDelay.TotalMilliseconds);
    }

    protected virtual void OnDelayComplete(PipelineMessage message) { }
}
