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

    private readonly TimeSpan _initialDelay;

    public MessageDelay()
    {
        _initialDelay = DefaultInitialDelay;
    }

    public void Delay(PipelineMessage message, CancellationToken cancellationToken)
    {
        TimeSpan delay = GetDelayCore(message, message.RetryCount);
        if (delay > TimeSpan.Zero)
        {
            WaitCore(delay, cancellationToken);
        }

        OnDelayComplete(message);
    }

    public async Task DelayAsync(PipelineMessage message, CancellationToken cancellationToken)
    {
        TimeSpan delay = GetDelayCore(message, message.RetryCount);
        if (delay > TimeSpan.Zero)
        {
            await WaitCoreAsync(delay, cancellationToken).ConfigureAwait(false);
        }

        OnDelayComplete(message);
    }

    protected virtual void WaitCore(TimeSpan duration, CancellationToken cancellationToken)
    {
        cancellationToken.WaitHandle.WaitOne(duration);
    }

    protected virtual async Task WaitCoreAsync(TimeSpan duration, CancellationToken cancellationToken)
    {
        await Task.Delay(duration, cancellationToken).ConfigureAwait(false);
    }

    protected virtual TimeSpan GetDelayCore(PipelineMessage message, int delayCount)
    {
        // Default implementation is exponential backoff
        return TimeSpan.FromMilliseconds((1 << (delayCount - 1)) * _initialDelay.TotalMilliseconds);
    }

    protected virtual void OnDelayComplete(PipelineMessage message) { }
}
