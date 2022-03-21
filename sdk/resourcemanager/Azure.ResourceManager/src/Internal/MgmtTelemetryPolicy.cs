// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager
{
    internal class MgmtTelemetryPolicy : HttpPipelineSynchronousPolicy
    {
#pragma warning disable CA1801
        public MgmtTelemetryPolicy(object source, ClientOptions options)
#pragma warning restore CA1801
        {
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.TryGetProperty("UserAgentOverride", out var userAgent))
            {
                message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, userAgent as string);
            }
        }
    }
}
