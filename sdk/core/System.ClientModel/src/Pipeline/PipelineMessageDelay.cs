// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class PipelineMessageDelay
{
    internal static readonly PipelineMessageDelay Default = new PipelineMessageDelay();

    private static readonly TimeSpan DefaultInitialDelay = TimeSpan.FromSeconds(0.8);
    private static readonly TimeSpan DefaultMaxDelay = TimeSpan.FromMinutes(1);

    private readonly TimeSpan _initialDelay;

    public PipelineMessageDelay()
    {
        _initialDelay = DefaultInitialDelay;
    }

    public void Wait(PipelineMessage message, CancellationToken cancellationToken)
    {
        TimeSpan delay = GetNextDelay(message, message.RetryCount);
        if (delay > TimeSpan.Zero)
        {
            WaitCore(delay, cancellationToken);
        }

        OnWaitComplete(message);
    }

    public async Task WaitAsync(PipelineMessage message, CancellationToken cancellationToken)
    {
        TimeSpan delay = GetNextDelay(message, message.RetryCount);
        if (delay > TimeSpan.Zero)
        {
            await WaitCoreAsync(delay, cancellationToken).ConfigureAwait(false);
        }

        OnWaitComplete(message);
    }

    protected virtual void WaitCore(TimeSpan delay, CancellationToken cancellationToken)
    {
        cancellationToken.WaitHandle.WaitOne(delay);
    }

    protected virtual async Task WaitCoreAsync(TimeSpan delay, CancellationToken cancellationToken)
    {
        await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
    }

    protected virtual TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
    {
        // Default implementation is exponential backoff
        return TimeSpan.FromMilliseconds((1 << (tryCount - 1)) * _initialDelay.TotalMilliseconds);
    }

    protected virtual void OnWaitComplete(PipelineMessage message) { }
}
