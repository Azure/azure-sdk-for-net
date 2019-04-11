// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Attributes;
using Azure.Base.Pipeline.Policies;

namespace Azure.Base.Pipeline
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
            _responseClassifier = responseClassifier ?? DefaultResponseClassifier.Singleton;

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
                message.ResponseClassifier = _responseClassifier;
                await _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1)).ConfigureAwait(false);
                return new Response(message.Response);
            }
        }

        public static HttpPipeline Build(HttpClientOptions options, ResponseClassifier responseClassifier, params HttpPipelinePolicy[] clientPolicies)
        {
            var policies = new List<HttpPipelinePolicy>();

            policies.AddRange(options.PerCallPolicies);

            if (!options.DisableTelemetry)
            {
                policies.Add(CreateTelemetryPolicy(options));
            }

            policies.AddRange(clientPolicies);

            policies.AddRange(options.PerRetryPolicies);

            policies.RemoveAll(policy => policy == null);

            return new HttpPipeline(options.Transport, policies.ToArray(), responseClassifier, options.ServiceProvider);
        }

        private static AddHeadersPolicy CreateTelemetryPolicy(HttpClientOptions options)
        {
            var clientAssembly = options.GetType().Assembly;
            var componentAttribute = clientAssembly.GetCustomAttribute<AzureSdkClientLibraryAttribute>();
            if (componentAttribute == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(AzureSdkClientLibraryAttribute)} is required to be set on client SDK assembly '{clientAssembly.FullName}'.");
            }

            var assemblyVersion = clientAssembly.GetName().Version.ToString();
            var addHeadersPolicy = new AddHeadersPolicy();
            addHeadersPolicy.AddHeader(HttpHeader.Common.CreateUserAgent(componentAttribute.ComponentName, assemblyVersion, options.ApplicationId));
            return addHeadersPolicy;
        }
    }
}

