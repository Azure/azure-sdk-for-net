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

        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[] policies = null, IServiceProvider services = default)
        {
            if (policies == null) policies = Array.Empty<HttpPipelinePolicy>();
            var all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = transport;
            policies.CopyTo(all, 0);
            _pipeline = all;
            _services = services == null ? EmptyServiceProvider.Singleton:services;
        }

        internal HttpPipeline(HttpPipelinePolicy[] policies, IServiceProvider services = default)
        {
            Debug.Assert(policies[policies.Length-1] is HttpPipelineTransport);
            _pipeline = policies;
            _services = services == null ? EmptyServiceProvider.Singleton : services;
        }

        public HttpMessage CreateMessage(CancellationToken cancellation)
            => Transport.CreateMessage(_services, cancellation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task SendMessageAsync(HttpMessage message)
        {
            if (_pipeline.IsEmpty) return;
            await _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1)).ConfigureAwait(false);
        }

        HttpPipelineTransport Transport {
            get => (HttpPipelineTransport)_pipeline.Span[_pipeline.Length - 1];
        }

        sealed class EmptyServiceProvider : IServiceProvider
        {
            public static IServiceProvider Singleton { get; } = new EmptyServiceProvider(); 
            private EmptyServiceProvider() { }

            public object GetService(Type serviceType) => null;
        }
    }
}

