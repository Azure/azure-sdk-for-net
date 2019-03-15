// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public class TelemetryPolicy : HttpPipelinePolicy
    {
        HttpHeader _header;

        public TelemetryPolicy(string componentName, string componentVersion)
            : this(componentName, componentVersion, ApplicationId)
        { }

        public TelemetryPolicy(string componentName, string componentVersion, string applicationId)
            => _header = HttpHeader.Common.CreateUserAgent(componentName, componentVersion, applicationId);

        public static string ApplicationId { get; set; }
        public static bool IsTelemetryEnabled { get; set; } = true;

        public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (IsTelemetryEnabled) {
                message.AddHeader(_header);
            }
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
        }

        public override void Register(HttpPipelineOptions options)
            => options.AddPerCallPolicy(this);
    }
}
