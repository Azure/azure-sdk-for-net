// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Pipeline
{
    public static class HttpPipelineBuilder
    {
        public static HttpPipeline Build(ClientOptions options, params HttpPipelinePolicy[] clientPolicies)
        {
            var policies = new List<HttpPipelinePolicy>();

            policies.AddRange(options.PerCallPolicies);

            policies.Add(options.TelemetryPolicy);

            policies.AddRange(clientPolicies);

            policies.AddRange(options.PerRetryPolicies);

            policies.Add(options.LoggingPolicy);

            policies.RemoveAll(policy => policy == null);

            return new HttpPipeline(options.Transport, policies.ToArray(), options.ResponseClassifier);
        }
    }
}
