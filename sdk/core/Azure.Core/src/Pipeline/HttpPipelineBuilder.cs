// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core.Pipeline
{
    public static class HttpPipelineBuilder
    {
        public static HttpPipeline Build(ClientOptions options, bool bufferResponse = true, params HttpPipelinePolicy[] clientPolicies)
        {
            var policies = new List<HttpPipelinePolicy>();

            policies.AddRange(options.PerCallPolicies);

            policies.Add(ClientRequestIdPolicy.Shared);

            policies.Add(options.TelemetryPolicy);

            policies.AddRange(clientPolicies);

            policies.AddRange(options.PerRetryPolicies);

            policies.Add(options.LoggingPolicy);

            if (bufferResponse)
            {
                policies.Add(BufferResponsePolicy.Shared);
            }

            policies.RemoveAll(policy => policy == null);

            return new HttpPipeline(options.Transport, policies.ToArray(), options.ResponseClassifier);
        }
    }
}
