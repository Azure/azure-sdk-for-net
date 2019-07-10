// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;

namespace Azure.Core.Pipeline
{
    public class HttpPipeline
    {
        private readonly HttpPipelineTransport _transport;
        private readonly ResponseClassifier _responseClassifier;
        private readonly ReadOnlyMemory<HttpPipelinePolicy> _pipeline;

        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[] policies = null, ResponseClassifier responseClassifier = null)
        {
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            _responseClassifier = responseClassifier ?? new ResponseClassifier();

            policies = policies ?? Array.Empty<HttpPipelinePolicy>();

            var all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = new HttpPipelineTransportPolicy(_transport);
            policies.CopyTo(all, 0);

            _pipeline = all;
        }

        public Request CreateRequest()
            => _transport.CreateRequest();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async Task<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            var message = new HttpPipelineMessage(cancellationToken);
            message.Request = request;
            message.ResponseClassifier = _responseClassifier;
            await _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1)).ConfigureAwait(false);
            return message.Response;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            var message = new HttpPipelineMessage(cancellationToken);
            message.Request = request;
            message.ResponseClassifier = _responseClassifier;
            _pipeline.Span[0].Process(message, _pipeline.Slice(1));
            return message.Response;
        }
    }
}

