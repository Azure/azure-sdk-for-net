// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    internal class TelemetryPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _defaultHeader;

        public TelemetryPolicy(UserAgentString userAgentString)
        {
            _defaultHeader = userAgentString.ToString();
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.TryGetInternalProperty(typeof(UserAgentString), out var userAgent))
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, ((UserAgentString)userAgent!).ToString());
            }
            else
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, _defaultHeader);
            }
        }
    }
}
