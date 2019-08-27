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

        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[]? policies = null, ResponseClassifier? responseClassifier = null, ClientDiagnostics? clientDiagnostics = null)
        {
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            _responseClassifier = responseClassifier ?? new ResponseClassifier();

            Diagnostics = clientDiagnostics ?? new ClientDiagnostics(true);

            policies = policies ?? Array.Empty<HttpPipelinePolicy>();

            var all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = new HttpPipelineTransportPolicy(_transport);
            policies.CopyTo(all, 0);

            _pipeline = all;
        }

        public Request CreateRequest()
            => _transport.CreateRequest();

        public ClientDiagnostics Diagnostics { get; }

        public Task<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            return SendRequestAsync(request, true, cancellationToken);
        }

        public async Task<Response> SendRequestAsync(Request request, bool bufferResponse, CancellationToken cancellationToken)
        {
            HttpPipelineMessage message = BuildMessage(request, bufferResponse, cancellationToken);
            await _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1)).ConfigureAwait(false);
            return message.Response;
        }

        public Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            return SendRequest(request, true, cancellationToken);
        }

        public Response SendRequest(Request request, bool bufferResponse, CancellationToken cancellationToken)
        {
            HttpPipelineMessage message = BuildMessage(request, bufferResponse, cancellationToken);
            _pipeline.Span[0].Process(message, _pipeline.Slice(1));
            return message.Response;
        }

        private HttpPipelineMessage BuildMessage(Request request, bool bufferResponse, CancellationToken cancellationToken)
        {
            var message = new HttpPipelineMessage(request, _responseClassifier, cancellationToken);
            message.Request = request;
            message.BufferResponse = bufferResponse;
            message.ResponseClassifier = _responseClassifier;
            return message;
        }
    }
}
