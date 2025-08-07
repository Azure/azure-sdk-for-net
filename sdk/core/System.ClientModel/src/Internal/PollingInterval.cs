// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal sealed class PollingInterval
{
    private static readonly TimeSpan DefaultDelay = TimeSpan.FromSeconds(1.0);

    private readonly TimeSpan _interval;

    public PollingInterval(TimeSpan? interval = default)
    {
        _interval = interval ?? DefaultDelay;
    }

    public async Task WaitAsync(PipelineResponse response, CancellationToken cancellationToken)
    {
        TimeSpan delay = GetDelay(response);

        await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
    }

    public void Wait(PipelineResponse response, CancellationToken cancellationToken)
    {
        TimeSpan delay = GetDelay(response);

        if (!cancellationToken.CanBeCanceled)
        {
            Thread.Sleep(delay);
            return;
        }

        if (cancellationToken.WaitHandle.WaitOne(delay))
        {
            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    private TimeSpan GetDelay(PipelineResponse response)
        => PipelineResponseHeaders.TryGetRetryAfter(response, out TimeSpan retryAfter)
            && retryAfter > _interval ? retryAfter : _interval;
}
