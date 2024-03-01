// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    public partial class HttpClientTransport : HttpPipelineTransport
    {
        /// <summary>
        /// This is a transport-specific implementation of <see cref="Response"/>.
        ///
        /// It uses the System.ClientModel HttpClient-based transport
        /// implementation <see cref="HttpClientPipelineTransport"/> and adapts
        /// that transport's private nested HttpClientPipelineTransportResponse
        /// type to the Azure.Core <see cref="Response"/> interface so that it
        /// can reuse the ClientModel implementation but treat it as an
        /// Azure.Core Response in Azure.Core-based clients.
        /// </summary>
        private sealed class HttpClientTransportResponse : Response
        {
            private readonly PipelineResponse _pipelineResponse;
            private string _clientRequestId;

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

            public override BinaryData Content
            {
                get
                {
                    ResetContentStreamPosition(_pipelineResponse);
                    return _pipelineResponse.Content;
                }
            }

            public override BinaryData BufferContent(CancellationToken cancellationToken = default)
                => _pipelineResponse.BufferContent(cancellationToken);

            public override async ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
                => await _pipelineResponse.BufferContentAsync(cancellationToken).ConfigureAwait(false);

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

            private static void ResetContentStreamPosition(PipelineResponse response)
            {
                if (response.ContentStream is MemoryStream &&
                    response.ContentStream.CanSeek &&
                    response.ContentStream.Position != 0)
                {
                    // Azure.Core Response has a contract that ContentStream can
                    // be read without setting position back to 0.  This means
                    // that if BufferContent is called after such a read, the
                    // buffer will contain empty BinaryData.

                    // So that the ClientModel response implementations don't
                    // throw, we must set the position back to 0 if Azure.Core
                    // Response BufferContent was called.
                    response.ContentStream.Position = 0;
                }
            }

            public override void Dispose()
            {
                PipelineResponse response = _pipelineResponse;
                ResetContentStreamPosition(response);
                response?.Dispose();
            }
        }
    }
}
