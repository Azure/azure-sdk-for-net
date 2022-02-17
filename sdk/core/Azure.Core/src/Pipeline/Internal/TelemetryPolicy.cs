// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;

namespace Azure.Core.Pipeline
{
    internal class TelemetryPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _defaultHeader;

        public TelemetryPolicy(TelemetryPackageInfo packageInfo)
        {
            _defaultHeader = packageInfo.UserAgentValue;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.TryGetInternalProperty(typeof(TelemetryPackageInfo), out var userAgent))
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, ((TelemetryPackageInfo)userAgent!).UserAgentValue);
            }
            else
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, _defaultHeader);
            }
        }
    }
}
