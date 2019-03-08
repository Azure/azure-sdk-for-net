// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public class TelemetryPolicy : HttpPipelinePolicy
    {
        HttpHeader _uaHeader;

        public TelemetryPolicy(HttpHeader userAgentHeader)
            => _uaHeader = userAgentHeader;

        public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.AddHeader(_uaHeader);
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
        }
    }
}
