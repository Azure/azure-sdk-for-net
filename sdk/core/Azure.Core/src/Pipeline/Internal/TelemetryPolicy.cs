// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;

namespace Azure.Core.Pipeline
{
    internal class TelemetryPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _defaultHeader;

        public TelemetryPolicy(Assembly assembly, string? applicationId)
        {
            _defaultHeader = HttpHeaderUtilities.GetUserAgentValue(assembly, applicationId);
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (!message.Request.Headers.Contains(HttpHeader.Names.UserAgent))
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, _defaultHeader);
            }
        }
    }
}
