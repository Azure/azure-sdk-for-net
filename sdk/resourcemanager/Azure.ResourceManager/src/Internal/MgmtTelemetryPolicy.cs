// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    internal class MgmtTelemetryPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _defaultHeader;

        public MgmtTelemetryPolicy(object source, ClientOptions options)
        {
            _defaultHeader = HttpMessageUtilities.GetUserAgentName(source, options.Diagnostics.ApplicationId);
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            var header = message.TryGetProperty("SDKUserAgent", out var userAgent) ? userAgent as string : _defaultHeader;
            if (message.Request.Headers.TryGetValues(HttpHeader.Names.UserAgent, out var customHeaders))
            {
                // append custom "user-agent" headers
                header = $"{header} {string.Join(" ", customHeaders)}";
            }
            message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, header);
        }
    }
}
