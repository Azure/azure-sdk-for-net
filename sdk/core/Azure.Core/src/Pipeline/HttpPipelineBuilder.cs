// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core.Pipeline
{
    public class HttpPipelineBuilder
    {
        private readonly HttpClientOptions _options;
        private readonly List<PolicyHolder> _policies;

        public HttpPipelineBuilder(HttpClientOptions options)
        {
            _options = options;
            _policies = new List<PolicyHolder>(5)
            {
                new PolicyHolder(HttpClientOptions.TelemetryPolicy, new TelemetryPolicy(options.Telemetry, options.GetType().Assembly)),
                new PolicyHolder(HttpClientOptions.ClientRequestIdPolicy, ClientRequestIdPolicy.Singleton),
                new PolicyHolder(HttpClientOptions.RetryPolicy, null),
                new PolicyHolder(HttpClientOptions.LoggingPolicy, LoggingPolicy.Shared),
                new PolicyHolder(HttpClientOptions.TransportPolicy, new HttpPipelineTransportPolicy(options.Transport))
            };
        }

        public void InsertBefore(string beforePolicy, string policyName, HttpPipelinePolicy policy)
        {
            var index = FindPolicy(beforePolicy);
            _policies.Insert(index, new PolicyHolder(policyName, policy));
        }

        public void InsertAfter(string afterPolicy, string policyName, HttpPipelinePolicy policy)
        {
            var index = FindPolicy(afterPolicy);
            _policies.Insert(index + 1, new PolicyHolder(policyName, policy));
        }

        public void Replace(string policyName, HttpPipelinePolicy policy)
        {
            var index = FindPolicy(policyName);
            _policies[index] = new PolicyHolder(policyName, policy);
        }

        public HttpPipeline Build()
        {
            _options.ConfigurePipeline?.Invoke(this);
            HttpPipelinePolicy[] policies = _policies.Select(p=>p.Policy).Where(p=>p != null).ToArray();
            return new HttpPipeline(_options.Transport, policies, _options.ResponseClassifier, _options.ServiceProvider);
        }

        private int FindPolicy(string name)
        {
            return _policies.FindIndex(p => p.Name == name);
        }

        private readonly struct PolicyHolder
        {
            public PolicyHolder(string name, HttpPipelinePolicy policy)
            {
                Name = name;
                Policy = policy;
            }

            public string Name { get; }
            public HttpPipelinePolicy Policy { get; }
        }
    }
}
