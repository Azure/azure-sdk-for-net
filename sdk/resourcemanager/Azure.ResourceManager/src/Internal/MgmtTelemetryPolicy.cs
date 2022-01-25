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
            _defaultHeader = HttpMessageUtilities.GetUserAgentName(source, options);
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            var header = message.TryGetProperty("SDKUserAgent", out var userAgent) ? userAgent as string : _defaultHeader;
            if (message.Request.Headers.TryGetValues(HttpHeader.Names.UserAgent, out var customHeaders))
            {
                // append custom "user-agent" headers
                var strBuilder = new StringBuilder(header);
                foreach (var customHeader in customHeaders)
                {
                    strBuilder.Append(' ');
                    strBuilder.Append(customHeader);
                }
                header = strBuilder.ToString();
            }
            message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, header);
        }
    }
}
