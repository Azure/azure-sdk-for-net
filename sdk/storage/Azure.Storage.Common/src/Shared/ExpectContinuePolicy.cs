// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage;

internal class ExpectContinuePolicy : HttpPipelineSynchronousPolicy
{
    public long ContentLengthThreshold { get; set; }

    public override void OnSendingRequest(HttpMessage message)
    {
        if (message.Request.Content == null || CompatSwitches.DisableExpectContinueHeader)
        {
            return;
        }
        if (!message.Request.Content.TryComputeLength(out long contentLength) || contentLength >= ContentLengthThreshold)
        {
            message.Request.Headers.SetValue("Expect", "100-continue");
        }
    }
}
