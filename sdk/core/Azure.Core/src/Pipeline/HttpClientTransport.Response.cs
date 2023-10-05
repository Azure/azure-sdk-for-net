// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.ServiceModel.Rest.Core.Pipeline;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport, IDisposable
    {
        private sealed class HttpClientTransportResponse : Response
        {
            private readonly HttpPipelineResponse _response;

            public HttpClientTransportResponse(string requestId, HttpResponseMessage responseMessage, Stream? contentStream)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
                _response = new HttpPipelineResponse(responseMessage, contentStream);
            }

            public override string ClientRequestId { get; set; }

            public override int Status => _response.Status;

            public override BinaryData Content => _response.Content;

            public override Stream? ContentStream
            {
                get => _response.ContentStream;
                set => _response.ContentStream = value;
            }

            public override string ReasonPhrase => _response.ReasonPhrase;

            public override void Dispose()
            {
                // TODO: implement correctly
                _response.Dispose();
            }

            public override bool TryGetHeaderValue(string name, out string? value)
                => _response.TryGetHeaderValue(name, out value);

            public override bool TryGetHeaderValue(string name, out IEnumerable<string>? value)
                => _response.TryGetHeaderValue(name, out value);

            public override IEnumerable<KeyValuePair<string, string>> GetHeaders()
                => _response.GetHeaders();

            protected internal override bool ContainsHeader(string name)
                => _response.TryGetHeaderValue(name, out string? _);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                foreach (KeyValuePair<string, string> header in GetHeaders())
                {
                    yield return new HttpHeader(header.Key, header.Value);
                }
            }

            // TODO: EBN some of these?
            protected internal override bool TryGetHeader(string name, out string? value)
                => _response.TryGetHeaderValue(name, out value);

            protected internal override bool TryGetHeaderValues(string name, out IEnumerable<string>? values)
                => _response.TryGetHeaderValue(name, out values);
        }
    }
}
