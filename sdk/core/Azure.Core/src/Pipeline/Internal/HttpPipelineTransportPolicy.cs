// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class HttpPipelineTransportPolicy : HttpPipelinePolicy
    {
        private readonly HttpPipelineTransport _transport;

        public HttpPipelineTransportPolicy(HttpPipelineTransport transport)
        {
            _transport = transport;
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Debug.Assert(pipeline.IsEmpty);

            return _transport.ProcessAsync(message);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Debug.Assert(pipeline.IsEmpty);

            _transport.Process(message);
        }
    }
}
