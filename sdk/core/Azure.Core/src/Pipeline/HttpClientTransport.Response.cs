// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private sealed class HttpClientTransportResponse : Response
        {
            private readonly HttpResponseMessage _responseMessage;

            private readonly HttpContent _responseContent;

#pragma warning disable CA2213 // Content stream is intentionally not disposed
            private Stream? _contentStream;
#pragma warning restore CA2213

            public HttpClientTransportResponse(string requestId, HttpResponseMessage responseMessage, Stream? contentStream)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
                _responseMessage = responseMessage ?? throw new ArgumentNullException(nameof(responseMessage));
                _contentStream = contentStream;
                _responseContent = _responseMessage.Content;
            }

            public override int Status => (int)_responseMessage.StatusCode;

            public override string ReasonPhrase => _responseMessage.ReasonPhrase ?? string.Empty;

            public override Stream? ContentStream
            {
                get => _contentStream;
                set
                {
                    // Make sure we don't dispose the content if the stream was replaced
                    _responseMessage.Content = null;

                    _contentStream = value;
                }
            }

            public override string ClientRequestId { get; set; }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value) => HttpClientTransport.TryGetHeader(_responseMessage.Headers, _responseContent, name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values) => HttpClientTransport.TryGetHeader(_responseMessage.Headers, _responseContent, name, out values);

            protected internal override bool ContainsHeader(string name) => HttpClientTransport.ContainsHeader(_responseMessage.Headers, _responseContent, name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders() => GetHeaders(_responseMessage.Headers, _responseContent);

            public override void Dispose()
            {
                _responseMessage?.Dispose();
                DisposeStreamIfNotBuffered(ref _contentStream);
            }

            public override string ToString() => _responseMessage.ToString();
        }
    }
}
