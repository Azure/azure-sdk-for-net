// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;

namespace Azure
{
    public static class ClientPipelineBuilderExtensions
    {
        public static HttpPipeline Build(this HttpPipelineOptions options, string componentName, string componentVersion)
        {
            if (!options.DisableTelemetry)
            {
                options = options.Clone();
                options.AddHeaders(HttpHeader.Common.CreateUserAgent(componentName, componentVersion, options.ApplicationId));
            }

            var transport = options.TransportPolicy();

            HttpPipelinePolicy currentPolicy = transport;

            foreach (var section in options.PipelinePolicies.Reverse().GroupBy(registration => registration.Section))
            {
                foreach (var pipelineBuilderPipelinePolicy in section)
                {
                    currentPolicy = pipelineBuilderPipelinePolicy.PolicyFactory(currentPolicy);
                }
            }

            return new HttpPipeline(transport, currentPolicy);
        }

        public static HttpPipelineOptions AddLogging(this HttpPipelineOptions options, int[] excludeCodes = null)
        {
            return options.Append(HttpPipelineSection.PostRetry, next => new LoggingPolicy(next, excludeCodes));
        }

        public static HttpPipelineOptions AddFixedRetry(this HttpPipelineOptions options, int maxRetries, TimeSpan delay, params int[] retriableCodes)
        {
            return options.Replace(HttpPipelineSection.Retry, next => new FixedPolicy(next, maxRetries, delay, retriableCodes));
        }

        public static HttpPipelineOptions AddHeaders(this HttpPipelineOptions options, params HttpHeader[] headers)
        {
            return options.Replace(HttpPipelineSection.PreRetry, next => new AddHeadersPolicy(next, headers));
        }

        public static HttpPipelineOptions UseHttpClient(this HttpPipelineOptions options, HttpClient client)
        {
            options.TransportPolicy =  () => {
                return new HttpClientTransport()
                {
                    Client = client
                };
            };
            return options;
        }

        public static HttpPipelineOptions UseHttpClient(this HttpPipelineOptions options, Action<HttpClientHandler> configure)
        {
            options.TransportPolicy =  () => {
                var handler = new HttpClientHandler();
                configure(handler);
                return new HttpClientTransport()
                {
                    Client = new HttpClient(handler)
                };
            };

            return options;
        }

        public static HttpPipelineOptions Append(this HttpPipelineOptions options, HttpPipelineSection section, Func<HttpPipelinePolicy, HttpPipelinePolicy> policyFactory)
        {
            options.PipelinePolicies.Add(new PolicyRegistration(section, policyFactory));
            return options;
        }

        public static HttpPipelineOptions TryAppend(this HttpPipelineOptions options, HttpPipelineSection section, Func<HttpPipelinePolicy, HttpPipelinePolicy> policyFactory)
        {
            if (options.PipelinePolicies.All(p => p.Section != section))
            {
                options.PipelinePolicies.Add(new PolicyRegistration(section, policyFactory));
            }
            return options;
        }

        public static HttpPipelineOptions Replace(this HttpPipelineOptions options, HttpPipelineSection section, Func<HttpPipelinePolicy, HttpPipelinePolicy> policyFactory)
        {
            foreach (var registration in options.PipelinePolicies.Where(registration => registration.Section == section).ToArray())
            {
                options.PipelinePolicies.Remove(registration);
            }

            return options.Append(section, policyFactory);
        }
    }
}