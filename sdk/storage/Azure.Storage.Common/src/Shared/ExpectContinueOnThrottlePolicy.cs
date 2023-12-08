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

    private long _autoEnabledIntervalTicks = TimeSpan.TicksPerMinute;
    public TimeSpan AutoEnabledInterval
    {
        get => TimeSpan.FromTicks(_autoEnabledIntervalTicks);
        set => _autoEnabledIntervalTicks = value.Ticks;
    }

    public long ContentLengthThreshold { get; set; }

    public override void OnSendingRequest(HttpMessage message)
    {
        if (message.Request.Content == null ||
            (message.Request.Content.TryComputeLength(out long contentLength) && contentLength < ContentLengthThreshold))
        {
            return;
        }
        long lastThrottleTicks = Interlocked.Read(ref _lastThrottleTicks);
        if (DateTimeOffset.UtcNow.Ticks - lastThrottleTicks < _autoEnabledIntervalTicks)
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
