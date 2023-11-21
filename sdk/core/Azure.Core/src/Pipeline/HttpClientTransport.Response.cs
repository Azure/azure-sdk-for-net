// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        // TODO: is this static method still needed?
        internal static bool TryGetPipelineResponse(Response response, out PipelineResponse? pipelineResponse)
        {
            if (response is HttpClientTransportResponse responseAdapter)
            {
                pipelineResponse = responseAdapter.PipelineResponse;
                return true;
            }

            pipelineResponse = null;
            return false;
        }

        // Adapts a ClientModel PipelineResponse to an Azure.Core Response.
        private sealed class HttpClientTransportResponse : Response
        {
            private readonly PipelineResponse _httpPipelineResponse;

            public HttpClientTransportResponse(string requestId, PipelineResponse response)
            {
                Argument.AssertNotNull(requestId, nameof(requestId));

                ClientRequestId = requestId;
                _httpPipelineResponse = response;
            }

            internal PipelineResponse PipelineResponse => _httpPipelineResponse;

            public override int Status => _httpPipelineResponse.Status;

            public override string ReasonPhrase => _httpPipelineResponse.ReasonPhrase;

            public override string ClientRequestId { get; set; }

            public override Stream? ContentStream
            {
                get => _httpPipelineResponse.ContentStream;
                set => _httpPipelineResponse.ContentStream = value;
            }

            protected internal override bool ContainsHeader(string name)
                => _httpPipelineResponse.Headers.TryGetValue(name, out _);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                _httpPipelineResponse.Headers.TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers);

                foreach (KeyValuePair<string, string> header in headers)
                {
                    yield return new HttpHeader(header.Key, header.Value);
                }
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
                => _httpPipelineResponse.Headers.TryGetValue(name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
                => _httpPipelineResponse.Headers.TryGetValues(name, out values);

            public override void Dispose()
                => _httpPipelineResponse.Dispose();
        }
    }
}
