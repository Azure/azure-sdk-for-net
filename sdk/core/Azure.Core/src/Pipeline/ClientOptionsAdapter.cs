// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    public static partial class HttpPipelineBuilder
    {
        private class ClientOptionsAdapter : ClientOptions
        {
            private PipelineOptions _options;
            public ClientOptionsAdapter(PipelineOptions options)
                => _options = options;
        }

        private class PolicyAdapter : HttpPipelinePolicy
        {
            private PipelinePolicy _policy;

            public PolicyAdapter(PipelinePolicy policy) => _policy = policy;
            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                _policy.Process(message, )
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                throw new NotImplementedException();
            }
        }
    }
}
