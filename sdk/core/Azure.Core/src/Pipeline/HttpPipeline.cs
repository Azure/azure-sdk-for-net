// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    public class HttpPipeline
    {
        private readonly HttpPipelineTransport _transport;
        private readonly ResponseClassifier _responseClassifier;
        private readonly ReadOnlyMemory<HttpPipelinePolicy> _pipeline;
        private readonly IServiceProvider _services;

        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[] policies, ResponseClassifier responseClassifier = null, IServiceProvider services = null)
        {
            _pipeline = policies ?? throw new ArgumentNullException(nameof(transport));
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            _responseClassifier = responseClassifier ?? new ResponseClassifier();
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
    }
}

