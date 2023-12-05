// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System;
using Azure.Core;
using Azure.Core.Pipeline;

internal class ExpectContinuePolicy : HttpPipelineSynchronousPolicy
{
    public override void OnSendingRequest(HttpMessage message)
    {
        if (message.Request.Method == RequestMethod.Put)
        {
            message.Request.Headers.SetValue("Expect", "100-continue");
        }
        base.OnSendingRequest(message);
    }
}
