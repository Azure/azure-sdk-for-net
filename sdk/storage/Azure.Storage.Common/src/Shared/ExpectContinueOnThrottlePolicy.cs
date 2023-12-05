// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System;
using Azure.Core;
using Azure.Core.Pipeline;

internal class ExpectContinueOnThrottlePolicy : HttpPipelineSynchronousPolicy
{
    private long _lastThrottleTicks = 0;

    private long _backoffTicks = TimeSpan.TicksPerMinute;
    public TimeSpan Backoff
    {
        get => TimeSpan.FromTicks(_backoffTicks);
        set => _backoffTicks = value.Ticks;
    }

    public override void OnSendingRequest(HttpMessage message)
    {
        if (message.Request.Method == RequestMethod.Put)
        {
            long lastThrottleTicks = Interlocked.Read(ref _lastThrottleTicks);
            if (DateTimeOffset.UtcNow.Ticks - lastThrottleTicks < _backoffTicks)
            {
                message.Request.Headers.SetValue("Expect", "100-continue");
            }
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
