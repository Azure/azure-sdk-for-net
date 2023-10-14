// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Core.Pipeline;

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

        private sealed class HttpClientTransportResponse : HttpPipelineResponse
        {
            public HttpClientTransportResponse(string requestId, HttpResponseMessage httpResponse, Stream? contentStream)
                : base(httpResponse, contentStream)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
            }

            public string ClientRequestId { get; internal set; }

            internal void SetContentStream(Stream? stream)
            {
                ContentStream = stream;
            }
        }

        private sealed class ResponseAdapter : Response
        {
            private readonly HttpClientTransportResponse _response;

            public ResponseAdapter(HttpClientTransportResponse response)
            {
                _response = response;
            }

            internal PipelineResponse PipelineResponse => _response;

            public override int Status => _response.Status;

            public override string ReasonPhrase => _response.ReasonPhrase;

            public override Stream? ContentStream
            {
                get => _response.ContentStream;
                set => _response.SetContentStream(value);
            }

            public override string ClientRequestId
            {
                get => _response.ClientRequestId;
                set => _response.ClientRequestId = value;
            }

            protected internal override bool ContainsHeader(string name)
                => _response.Headers.TryGetValue(name, out _);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                _response.Headers.TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers);

                foreach (KeyValuePair<string, string> header in headers)
                {
                    yield return new HttpHeader(header.Key, header.Value);
                }
            }
            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
                => _response.Headers.TryGetValue(name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
                => _response.Headers.TryGetValues(name, out values);

            public override void Dispose()
            {
                // TODO: implement
            }
        }
    }
}
