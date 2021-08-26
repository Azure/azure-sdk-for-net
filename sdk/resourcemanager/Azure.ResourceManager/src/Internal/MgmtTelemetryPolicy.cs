// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    internal class MgmtTelemetryPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _defaultHeader;

        public MgmtTelemetryPolicy(object source, ClientOptions options)
        {
            _defaultHeader = HttpMessageUtilities.GetUserAgentName(source, options);
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            var header = message.TryGetProperty("UserAgentOverride", out var userAgent) ? userAgent as string : _defaultHeader;
            message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, header);
        }
    }
}
