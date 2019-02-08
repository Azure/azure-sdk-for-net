// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Http.Pipeline;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Http
{
    public struct HttpPipeline
    {
        static readonly PipelineTransport s_defaultTransport = new HttpPipelineTransport();
        static readonly PipelinePolicy s_defaultLoggingPolicy = new LoggingPolicy();
        // TODO (pri 2): what are the default status codes to retry?
        static readonly PipelinePolicy s_defaultRetryPolicy = RetryPolicy.CreateFixed(3, TimeSpan.Zero,
            500, // Internal Server Error 
            504  // Gateway Timeout
        );

        PipelinePolicy[] _pipeline;

        ReadOnlyMemory<PipelinePolicy> Pipeline => new ReadOnlyMemory<PipelinePolicy>(_pipeline);

        PipelineTransport Transport {
            get => (PipelineTransport)_pipeline[_pipeline.Length - 1];
        }

        // TODO (pri 3): I am not sure this should be here. Maybe we need one per service, as they have different retry policies
        public static HttpPipeline Create(PipelineOptions options, string sdkName, string sdkVersion)
        {
            var ua = HttpHeader.Common.CreateUserAgent(sdkName, sdkVersion, options.ApplicationId);

            PipelinePolicy[] policies = new PipelinePolicy[options.PolicyCount + 1];
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

        public HttpMessage CreateMessage(PipelineOptions options, CancellationToken cancellation)
            => Transport.CreateMessage(options, cancellation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task ProcessAsync(HttpMessage message)
            => await PipelinePolicy.ProcessNextAsync(Pipeline, message).ConfigureAwait(false);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static PipelinePolicy OptionOrDefault(PipelinePolicy policy, PipelinePolicy defaultPolicy)
            => PipelineOptions.IsDefault(policy) ? defaultPolicy : policy;
    }
}

