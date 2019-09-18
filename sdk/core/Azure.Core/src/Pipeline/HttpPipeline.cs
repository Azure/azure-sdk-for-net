// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;

namespace Azure.Core.Pipeline
{
    public class HttpPipeline
    {
        private readonly HttpPipelineTransport _transport;

        private readonly ReadOnlyMemory<HttpPipelinePolicy> _pipeline;

        public HttpPipeline(HttpPipelineTransport transport, HttpPipelinePolicy[]? policies = null, ResponseClassifier? responseClassifier = null, ClientDiagnostics? clientDiagnostics = null)
        {
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            ResponseClassifier = responseClassifier ?? new ResponseClassifier();

            Diagnostics = clientDiagnostics ?? new ClientDiagnostics(true);

            policies = policies ?? Array.Empty<HttpPipelinePolicy>();

            var all = new HttpPipelinePolicy[policies.Length + 1];
            all[policies.Length] = new HttpPipelineTransportPolicy(_transport);
            policies.CopyTo(all, 0);

            _pipeline = all;
        }

        public Request CreateRequest()
            => _transport.CreateRequest();

        public HttpPipelineMessage CreateMessage()
        {
            return new HttpPipelineMessage(CreateRequest(), ResponseClassifier);
        }

        public ResponseClassifier ResponseClassifier { get; }

        public ClientDiagnostics Diagnostics { get; }

        public ValueTask<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            message.CancellationToken = cancellationToken;
            return _pipeline.Span[0].ProcessAsync(message, _pipeline.Slice(1));
        }

        public async ValueTask<Response> SendRequestAsync(Request request, bool bufferResponse, CancellationToken cancellationToken)
        {
            message.CancellationToken = cancellationToken;
            _pipeline.Span[0].Process(message, _pipeline.Slice(1));
        }

        public async Task<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            HttpPipelineMessage message = BuildMessage(request);
            await SendAsync(message, cancellationToken).ConfigureAwait(false);
            return message.Response;
        }

        public Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            HttpPipelineMessage message = BuildMessage(request);
            Send(message, cancellationToken);
            return message.Response;
        }

        private HttpPipelineMessage BuildMessage(Request request)
        {
            return new HttpPipelineMessage(request, ResponseClassifier)
            {
                Request = request
            };
        }
    }
}
