// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    internal class TelemetryPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _defaultHeader;

        public TelemetryPolicy(UserAgentValue userAgentValue)
        {
            _defaultHeader = userAgentValue.ToString();
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.TryGetInternalProperty(typeof(UserAgentValue), out var userAgent))
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, ((UserAgentValue)userAgent!).ToString());
            }
            else
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, _defaultHeader);
            }
        }
    }
}
