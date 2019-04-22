// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Attributes;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core.Pipeline
{
    public class HttpPipeline
    {
        private readonly HttpPipelineTransport _transport;
        private readonly ReadOnlyMemory<HttpPipelinePolicy> _pipeline;
        private readonly IServiceProvider _services;

        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[] policies = null, IServiceProvider services = null)
        {
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));

            policies = policies ?? Array.Empty<HttpPipelinePolicy>();

            var all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = new HttpPipelineTransportPolicy(_transport);
            policies.CopyTo(all, 0);

            _pipeline = all;
            _services = services ?? HttpClientOptions.EmptyServiceProvider.Singleton;
        }

        public HttpPipelineRequest CreateRequest()
            => _transport.CreateRequest(_services);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task<Response> SendRequestAsync(HttpPipelineRequest request, CancellationToken cancellationToken)
        {
            if (_pipeline.IsEmpty) return default;

            using (var message = new HttpPipelineMessage(cancellationToken))
            {
                message.Request = request;
                await _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1)).ConfigureAwait(false);
                return new Response(message.Response);
            }
        }

        public static HttpPipeline Build(HttpClientOptions options, params HttpPipelinePolicy[] clientPolicies)
        {
            var policies = new List<HttpPipelinePolicy>();

            policies.AddRange(options.PerCallPolicies);

            if (!options.DisableTelemetry)
            {
                policies.Add(new TelemetryPolicy(options.GetType().Assembly, options.ApplicationId));
            }

            policies.AddRange(clientPolicies);

            policies.AddRange(options.PerRetryPolicies);

            policies.RemoveAll(policy => policy == null);

            return new HttpPipeline(options.Transport, policies.ToArray(), options.ServiceProvider);
        }
    }
}

