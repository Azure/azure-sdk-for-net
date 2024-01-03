// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.ClientModel.Primitives.Pipeline;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport
    {
        private sealed class HttpClientTransportResponse : Response
        {
            private readonly HttpPipelineResponse _response;

            public HttpClientTransportResponse(string requestId, HttpResponseMessage responseMessage, Stream? contentStream)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
                _response = new HttpPipelineResponse(responseMessage, contentStream);
            }

            public override int Status => _response.Status;

            public override string ReasonPhrase =>
                _response.TryGetReasonPhrase(out string reasonPhrase)
                    ? reasonPhrase : string.Empty;

            public override string ClientRequestId { get; set; }

            public override BinaryData Content => _response.Content;

            public override Stream? ContentStream
            {
                get => _response.ContentStream;
                set => _response.ContentStream = value;
            }

            #region Header implementation
            public override bool TryGetHeaderValue(string name, out string? value)
                => _response.TryGetHeaderValue(name, out value);

            public override bool TryGetHeaderValue(string name, out IEnumerable<string>? value)
                => _response.TryGetHeaderValue(name, out value);

            public override bool TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers)
                => _response.TryGetHeaders(out headers);

            protected internal override bool ContainsHeader(string name)
                => _response.TryGetHeaderValue(name, out string? _);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers);
                foreach (KeyValuePair<string, string> header in headers)
                {
                    yield return new HttpHeader(header.Key, header.Value);
                }
            }

            protected internal override bool TryGetHeader(string name, out string? value)
                => _response.TryGetHeaderValue(name, out value);

            protected internal override bool TryGetHeaderValues(string name, out IEnumerable<string>? values)
                => _response.TryGetHeaderValue(name, out values);
            #endregion

            public override void Dispose()
            {
                HttpPipelineResponse response = _response;
                response.Dispose();
            }
        }
    }
}
