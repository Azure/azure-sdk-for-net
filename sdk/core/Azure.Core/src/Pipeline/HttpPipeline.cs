// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    public class HttpPipeline
    {
        private readonly HttpPipelineTransport _transport;

        private readonly ReadOnlyMemory<HttpPipelinePolicy> _pipeline;

        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[]? policies = null, ResponseClassifier? responseClassifier = null)
        {
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            ResponseClassifier = responseClassifier ?? new ResponseClassifier();

            policies = policies ?? Array.Empty<HttpPipelinePolicy>();

            var all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = new HttpPipelineTransportPolicy(_transport);
            policies.CopyTo(all, 0);

            _pipeline = all;
        }

        public Request CreateRequest()
            => _transport.CreateRequest();

        public HttpMessage CreateMessage()
        {
            return new HttpMessage(CreateRequest(), ResponseClassifier);
        }

        public ResponseClassifier ResponseClassifier { get; }

        public ValueTask SendAsync(HttpMessage message, CancellationToken cancellationToken)
        {
            message.CancellationToken = cancellationToken;
            return _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1));
        }

        public void Send(HttpMessage message, CancellationToken cancellationToken)
        {
            message.CancellationToken = cancellationToken;
            _pipeline.Span[0].Process(message, _pipeline.Slice(1));
        }

        public async ValueTask<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            HttpMessage message = new HttpMessage(request, ResponseClassifier);
            await SendAsync(message, cancellationToken).ConfigureAwait(false);
            return message.Response;
        }

        public Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            HttpMessage message = new HttpMessage(request, ResponseClassifier);
            Send(message, cancellationToken);
            return message.Response;
        }
    }
}
