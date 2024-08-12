// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal class PollingInterval
{
    private const string RetryAfterHeaderName = "Retry-After";
    private static readonly TimeSpan DefaultDelay = TimeSpan.FromSeconds(0.8);

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
        => TryGetRetryAfter(response, out TimeSpan retryAfter) && retryAfter > _interval ?
            retryAfter : _interval;

    private static bool TryGetRetryAfter(PipelineResponse response, out TimeSpan value)
    {
        // See: https://www.rfc-editor.org/rfc/rfc7231#section-7.1.3
        if (response.Headers.TryGetValue(RetryAfterHeaderName, out string? retryAfter))
        {
            if (int.TryParse(retryAfter, out var delaySeconds))
            {
                value = TimeSpan.FromSeconds(delaySeconds);
                return true;
            }

            if (DateTimeOffset.TryParse(retryAfter, out DateTimeOffset retryAfterDate))
            {
                value = retryAfterDate - DateTimeOffset.Now;
                return true;
            }
        }

        value = default;
        return false;
    }
}
