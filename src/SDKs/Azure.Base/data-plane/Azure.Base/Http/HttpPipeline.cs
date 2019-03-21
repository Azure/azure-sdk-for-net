// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http.Pipeline;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Base.Http
{
    public readonly struct HttpPipeline
    {
        readonly ReadOnlyMemory<HttpPipelinePolicy> _pipeline;
        readonly IServiceProvider _services;

        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[] policies = null, IServiceProvider services = null)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            if (policies == null) policies = Array.Empty<HttpPipelinePolicy>();

            var all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = transport;
            policies.CopyTo(all, 0);
            _pipeline = all;
            _services = services != null ? services: HttpPipelineOptions.EmptyServiceProvider.Singleton;
        }

        internal HttpPipeline(HttpPipelinePolicy[] policies, IServiceProvider services = default)
        {
            Debug.Assert(policies[policies.Length-1] is HttpPipelineTransport);

            _services = services != null ? services : HttpPipelineOptions.EmptyServiceProvider.Singleton;
            _pipeline = policies;
        }

        public HttpPipelineRequest CreateRequest()
            => Transport.CreateRequest(_services);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task<Response> SendMessageAsync(HttpPipelineRequest pipelineContext, CancellationToken cancellationToken)
        {
            if (_pipeline.IsEmpty) return default;

            using (var context = new HttpPipelineContext(cancellationToken))
            {
                context.Request = pipelineContext;
                await _pipeline.Span[0].ProcessAsync(context, _pipeline.Slice(1)).ConfigureAwait(false);
                return new Response(context.Response);
            }
        }

        HttpPipelineTransport Transport {
            get => (HttpPipelineTransport)_pipeline.Span[_pipeline.Length - 1];
        }
    }
}

