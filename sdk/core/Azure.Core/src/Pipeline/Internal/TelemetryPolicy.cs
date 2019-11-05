// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;

namespace Azure.Core.Pipeline
{
    internal class TelemetryPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _header;

        public TelemetryPolicy(string componentName, string componentVersion, string? applicationId)
        {
            var platformInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";
            if (applicationId != null)
            {
                _header = $"{applicationId} azsdk-net-{componentName}/{componentVersion} {platformInformation}";
            }
            else
            {
                _header = $"azsdk-net-{componentName}/{componentVersion} {platformInformation}";
            }
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.Add(HttpHeader.Names.UserAgent, _header);
        }
    }
}
