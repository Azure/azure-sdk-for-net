// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public partial class HttpClientTransport : HttpPipelineTransport
    {
        private sealed class HttpClientTransportResponse : Response
        {
            private string _clientRequestId;
            private readonly PipelineResponse _pipelineResponse;

            public HttpClientTransportResponse(string clientRequestId, PipelineResponse pipelineResponse)
            {
                _clientRequestId = clientRequestId;
                _pipelineResponse = pipelineResponse;
            }

            public override int Status => _pipelineResponse.Status;

            public override string ReasonPhrase => _pipelineResponse.ReasonPhrase;

            public override string ClientRequestId
            {
                get => _clientRequestId;
                set => _clientRequestId = value;
            }

            public override Stream? ContentStream
            {
                get => _pipelineResponse.ContentStream;
                set => _pipelineResponse.ContentStream = value;
            }

            public override BinaryData Content => _pipelineResponse.Content;

            public override BinaryData ReadContent(CancellationToken cancellationToken = default)
                => _pipelineResponse.ReadContent(cancellationToken);

            public override async ValueTask<BinaryData> ReadContentAsync(CancellationToken cancellationToken = default)
                => await base.ReadContentAsync(cancellationToken).ConfigureAwait(false);

            protected internal override bool ContainsHeader(string name)
                => _pipelineResponse.Headers.TryGetValue(name, out _);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                foreach (KeyValuePair<string, string> header in _pipelineResponse.Headers)
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
                PipelineResponse response = _pipelineResponse;
                response?.Dispose();
            }
        }
    }
}
