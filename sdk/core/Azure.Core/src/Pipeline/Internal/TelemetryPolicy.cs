// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    internal class TelemetryPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _defaultHeader;

        public TelemetryPolicy(TelemetryDetails telemetryDetails)
        {
            _defaultHeader = telemetryDetails.ToString();
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.TryGetProperty(typeof(UserAgentValueKey), out var userAgent))
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, ((string)userAgent!));
            }
            else
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, _defaultHeader);
            }
        }
    }
}
