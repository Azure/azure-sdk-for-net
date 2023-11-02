// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Net.ClientModel.Internal.Core;
using System.Net.Http;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport
    {
        internal static bool TryGetPipelineResponse(Response response, out MessageResponse? pipelineResponse)
        {
            if (response is ResponseAdapter responseAdapter)
            {
                pipelineResponse = responseAdapter.PipelineResponse;
                return true;
            }

            pipelineResponse = null;
            return false;
        }

        private sealed class HttpClientTransportResponse : HttpMessageResponse
        {
            public HttpClientTransportResponse(string requestId, HttpResponseMessage httpResponse)
                : base(httpResponse)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
            }

            public string ClientRequestId { get; internal set; }
        }

        private sealed class ResponseAdapter : Response
        {
            private readonly HttpClientTransportResponse _pipelineResponse;

            public ResponseAdapter(HttpClientTransportResponse pipelineResponse)
            {
                _pipelineResponse = pipelineResponse;
            }

            internal MessageResponse PipelineResponse => _pipelineResponse;

            public override int Status => _pipelineResponse.Status;

            public override string ReasonPhrase => _pipelineResponse.ReasonPhrase;

            public override string ClientRequestId
            {
                get => _pipelineResponse.ClientRequestId;
                set => _pipelineResponse.ClientRequestId = value;
            }

            public override Stream? ContentStream
            {
                get => _pipelineResponse.Body.ToStream();
                set => throw new InvalidOperationException("Shouldn't set ContentStream on MessageResponse.");
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
