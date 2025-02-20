// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage;

internal class ExpectContinueOnThrottlePolicy : HttpPipelineSynchronousPolicy
{
    private long _lastThrottleTicks = 0;

    private long _throttleIntervalTicks = TimeSpan.TicksPerMinute;
    public TimeSpan ThrottleInterval
    {
        get => TimeSpan.FromTicks(_throttleIntervalTicks);
        set => _throttleIntervalTicks = value.Ticks;
    }

    public long ContentLengthThreshold { get; set; }

    public override void OnSendingRequest(HttpMessage message)
    {
        if (message.Request.Content == null ||
            (message.Request.Content.TryComputeLength(out long contentLength) && contentLength < ContentLengthThreshold) ||
            CompatSwitches.DisableExpectContinueHeader)
        {
            return;
        }
        long lastThrottleTicks = Interlocked.Read(ref _lastThrottleTicks);
        if (DateTimeOffset.UtcNow.Ticks - lastThrottleTicks < _throttleIntervalTicks)
        {
            message.Request.Headers.SetValue("Expect", "100-continue");
        }
    }

    public override void OnReceivedResponse(HttpMessage message)
    {
        base.OnReceivedResponse(message);
        if (message.HasResponse && (
            message.Response.Status == 429 ||
            message.Response.Status == 500 ||
            message.Response.Status == 503))
        {
            Interlocked.Exchange(ref _lastThrottleTicks, DateTimeOffset.UtcNow.Ticks);
        }
    }
}
