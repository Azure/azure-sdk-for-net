// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport
    {
        internal static bool TryGetPipelineResponse(Response response, out PipelineResponse? pipelineResponse)
        {
            if (response is ResponseAdapter responseAdapter)
            {
                pipelineResponse = responseAdapter.PipelineResponse;
                return true;
            }

            pipelineResponse = null;
            return false;
        }

        // Adapts an internal ClientModel HttpPipelineResponse.  Doing this instead
        // of inheriting from HttpPipelineResponse allows us to keep HttpPipelineResponse
        // internal in ClientModel.
        private sealed class HttpClientTransportResponse : PipelineResponse
        {
            private readonly PipelineResponse _httpPipelineResponse;

            public HttpClientTransportResponse(string requestId, HttpResponseMessage httpResponse)
            {
                Argument.AssertNotNull(requestId, nameof(requestId));

                ClientRequestId = requestId;
                _httpPipelineResponse = Create(httpResponse);
            }

            public string ClientRequestId { get; internal set; }

            public override int Status => _httpPipelineResponse.Status;

            public override string ReasonPhrase => _httpPipelineResponse.ReasonPhrase;

            public override MessageHeaders Headers => _httpPipelineResponse.Headers;

            public override Stream? ContentStream
            {
                get => _httpPipelineResponse?.ContentStream;
                set => _httpPipelineResponse.ContentStream = value;
            }

            public override void Dispose() => _httpPipelineResponse.Dispose();
        }

        private sealed class ResponseAdapter : Response
        {
            private readonly HttpClientTransportResponse _pipelineResponse;

            public ResponseAdapter(HttpClientTransportResponse pipelineResponse)
            {
                _pipelineResponse = pipelineResponse;
            }

            internal PipelineResponse PipelineResponse => _pipelineResponse;

            public override int Status => _pipelineResponse.Status;

            public override string ReasonPhrase => _pipelineResponse.ReasonPhrase;

            public override string ClientRequestId
            {
                get => _pipelineResponse.ClientRequestId;
                set => _pipelineResponse.ClientRequestId = value;
            }

            public override Stream? ContentStream
            {
                get => _pipelineResponse.ContentStream;
                set => _pipelineResponse.ContentStream = value;
            }

            protected internal override bool ContainsHeader(string name)
                => _pipelineResponse.Headers.TryGetValue(name, out _);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                _pipelineResponse.Headers.TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers);

                foreach (KeyValuePair<string, string> header in headers)
                {
                    yield return new HttpHeader(header.Key, header.Value);
                }
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
                => _pipelineResponse.Headers.TryGetValue(name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
                => _pipelineResponse.Headers.TryGetValues(name, out values);

            public override void Dispose()
            {
                var response = _pipelineResponse;
                response?.Dispose();
            }
        }
    }
}
