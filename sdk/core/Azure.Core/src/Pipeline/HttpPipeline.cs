// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core.Pipeline
{
    public class HttpPipeline
    {
        private readonly HttpPipelineTransport _transport;
        private readonly ResponseClassifier _responseClassifier;
        private readonly ReadOnlyMemory<HttpPipelinePolicy> _pipeline;
        private readonly IServiceProvider _services;

        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[] policies = null, ResponseClassifier responseClassifier = null, IServiceProvider services = null)
        {
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            _responseClassifier = responseClassifier ?? new ResponseClassifier();

            policies = policies ?? Array.Empty<HttpPipelinePolicy>();

            var all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = new HttpPipelineTransportPolicy(_transport);
            policies.CopyTo(all, 0);

            _pipeline = all;
            _services = services ?? HttpClientOptions.EmptyServiceProvider.Singleton;
        }

        public Request CreateRequest()
            => _transport.CreateRequest(_services);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            using (var message = new HttpPipelineMessage(cancellationToken))
            {
                message.Request = request;
                message.ResponseClassifier = _responseClassifier;
                await _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1)).ConfigureAwait(false);
                return message.Response;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            using (var message = new HttpPipelineMessage(cancellationToken))
            {
                message.Request = request;
                message.ResponseClassifier = _responseClassifier;
                _pipeline.Span[0].Process(message, _pipeline.Slice(1));
                return message.Response;
            }
        }

        public static HttpPipeline Build(HttpClientOptions options, ResponseClassifier responseClassifier, params HttpPipelinePolicy[] clientPolicies)
        {
            var policies = new List<HttpPipelinePolicy>();

            policies.AddRange(options.PerCallPolicies);

            policies.Add(options.Telemetry);

            policies.AddRange(clientPolicies);

            policies.AddRange(options.PerRetryPolicies);

            policies.RemoveAll(policy => policy == null);

            return new HttpPipeline(options.Transport, policies.ToArray(), options.ResponseClassifier, options.ServiceProvider);
        }
    }
}

