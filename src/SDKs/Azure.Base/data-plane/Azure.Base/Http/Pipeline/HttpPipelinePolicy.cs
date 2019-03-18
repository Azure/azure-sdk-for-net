// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Diagnostics;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public abstract class HttpPipelineOption
    {
        public abstract void Register(HttpPipelineOptions options);

        public static HttpPipelineOption CreateService(object service, Type serviceType)
            => new Service(service, serviceType);

        public static HttpPipelineOption CreateFixedRetryPolicy(int maxRetries, TimeSpan delay, params int[] retriableCodes)
            => RetryPolicy.CreateFixed(maxRetries, delay, retriableCodes);

        public static HttpPipelineOption CreateHttpClientTransport(HttpClient client)
            => new HttpClientTransport(client);

        sealed class Service : HttpPipelineOption
        {
            object _service;
            Type _serviceType;

            public Service(object service, Type serviceType)
            {
                _service = service;
                _serviceType = serviceType;
            }
            public override void Register(HttpPipelineOptions options)
                => options.AddService(_service, _serviceType);
        }
    }

    public abstract class HttpPipelinePolicy : HttpPipelineOption
    {
        public abstract Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline);

        protected HttpPipelineEventSource Log = HttpPipelineEventSource.Singleton;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static async Task ProcessNextAsync(ReadOnlyMemory<HttpPipelinePolicy> pipeline, HttpMessage message)
        {
            if (pipeline.IsEmpty) throw new InvalidOperationException("last policy in the pipeline must be a transport"); 
            var next = pipeline.Span[0];
            await next.ProcessAsync(message, pipeline.Slice(1)).ConfigureAwait(false);
        }
    }
}
