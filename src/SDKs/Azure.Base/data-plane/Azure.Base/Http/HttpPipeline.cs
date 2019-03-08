// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http.Pipeline;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Base.Http
{
    public partial struct HttpPipeline
    {
        static readonly HttpPipelineTransport s_defaultTransport = new HttpClientTransport();
        static readonly HttpPipelinePolicy s_defaultLoggingPolicy = new LoggingPolicy();
        // TODO (pri 1): I am not sure this should be here. Maybe we need retry policy per service
        static readonly HttpPipelinePolicy s_defaultRetryPolicy = RetryPolicy.CreateFixed(3, TimeSpan.Zero,
            500, // Internal Server Error 
            504  // Gateway Timeout
        );

        HttpPipelinePolicy[] _pipeline;

        ReadOnlyMemory<HttpPipelinePolicy> Pipeline => new ReadOnlyMemory<HttpPipelinePolicy>(_pipeline);

        HttpPipelineTransport Transport {
            get => (HttpPipelineTransport)_pipeline[_pipeline.Length - 1];
        }

        // TODO (pri 1): I am not sure this should be here. Maybe we need one per service, as they have different retry policies
        public static HttpPipeline Create(Options options, string sdkName, string sdkVersion)
        {
            var ua = HttpHeader.Common.CreateUserAgent(sdkName, sdkVersion, options.ApplicationId);

            HttpPipelinePolicy[] policies = new HttpPipelinePolicy[options.PolicyCount + 1];
            int index = 0;

            if (options.TelemetryPolicy != null) {
                policies[index++] = OptionOrDefault(options.TelemetryPolicy, defaultPolicy: new TelemetryPolicy(ua));
            }
            foreach (var policy in options.PerCallPolicies) {
                if (policy == null) throw new InvalidOperationException("null policy");
                policies[index++] = policy;
            }
            if (options.RetryPolicy != null) { 
                policies[index++] = OptionOrDefault(options.RetryPolicy, defaultPolicy: s_defaultRetryPolicy);
            }
            foreach (var policy in options.PerRetryPolicies) {
                if (policy == null) throw new InvalidOperationException("null policy");
                policies[index++] = policy;
            }
            if (options.LoggingPolicy != null) {
                policies[index++] = OptionOrDefault(options.LoggingPolicy, defaultPolicy: s_defaultLoggingPolicy);
            }
            policies[index++] = options.Transport==null? s_defaultTransport : options.Transport; 

            var pipeline = new HttpPipeline() { _pipeline = policies };
            return pipeline;
        }

        public HttpMessage CreateMessage(Options options, CancellationToken cancellation)
            => Transport.CreateMessage(options, cancellation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task SendMessageAsync(HttpMessage message)
            => await HttpPipelinePolicy.ProcessNextAsync(Pipeline, message).ConfigureAwait(false);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static HttpPipelinePolicy OptionOrDefault(HttpPipelinePolicy policy, HttpPipelinePolicy defaultPolicy)
            => Options.IsDefault(policy) ? defaultPolicy : policy;
    }
}

