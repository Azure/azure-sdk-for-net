// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading.Tasks;

namespace Azure.Core.Http.Pipeline
{
    public class TelemetryPolicy : PipelinePolicy
    {
        HttpHeader _uaHeader;

        public TelemetryPolicy(HttpHeader userAgentHeader)
            => _uaHeader = userAgentHeader;

        public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
        {
            message.AddHeader(_uaHeader);
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
        }
    }
}
