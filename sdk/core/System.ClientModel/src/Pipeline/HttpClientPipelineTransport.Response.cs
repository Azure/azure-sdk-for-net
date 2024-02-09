// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public partial class HttpClientPipelineTransport
{
    private class HttpPipelineResponse : PipelineResponse
    {
        private readonly HttpResponseMessage _httpResponse;

        // We keep a reference to the http response content so it will be available
        // for reading headers, even if we set _httpResponse.Content to null when we
        // buffer the content.  Since we handle disposing the content separately, we
        // don't believe there is a concern about rooting objects that are holding
        // references to network resources.
        private readonly HttpContent _httpResponseContent;

        private Stream? _contentStream;
        private BinaryData? _bufferedContent;

        private bool _disposed;

        public HttpPipelineResponse(HttpResponseMessage httpResponse)
        {
            _httpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
            _httpResponseContent = _httpResponse.Content;
        }

        public override int Status => (int)_httpResponse.StatusCode;

        public override string ReasonPhrase
            => _httpResponse.ReasonPhrase ?? string.Empty;

        protected override PipelineResponseHeaders GetHeadersCore()
            => new HttpClientResponseHeaders(_httpResponse, _httpResponseContent);

        public override Stream? ContentStream
        {
            get
            {
                if (_contentStream is not null)
                {
                    return _contentStream;
                }

                if (_bufferedContent is not null)
                {
                    return _bufferedContent.ToStream();
                }

                return null;
            }
            set
            {
                // Don't dispose the content if the stream is replaced.
                // This means the content remains available for reading headers.
                _httpResponse.Content = null;

                _contentStream = value;

                // Invalidate the cache since the source-stream has been replaced.
                _bufferedContent = null;
            }
        }

        public override BinaryData Content
        {
            get
            {
                // TODO: Consolidate with part of ReadContent implementation?
                if (_bufferedContent is not null)
                {
                    return _bufferedContent;
                }

                if (_contentStream == null)
                {
                    _bufferedContent = s_EmptyBinaryData;
                    return _bufferedContent;
                }

                if (_contentStream is not MemoryStream memoryStream)
                {
                    throw new InvalidOperationException($"The response is not buffered.");
                }

                // Support mock responses that don't use the transport to buffer.
                if (memoryStream.TryGetBuffer(out ArraySegment<byte> segment))
                {
                    _bufferedContent = new BinaryData(segment.AsMemory());
                }
                else
                {
                    _bufferedContent = new BinaryData(memoryStream.ToArray());
                }

                return _bufferedContent;
            }
        }

        protected internal override BinaryData ReadContent(CancellationToken cancellationToken = default)
            => ReadContentSyncOrAsync(cancellationToken, async: false).EnsureCompleted();

        protected internal override async ValueTask<BinaryData> ReadContentAsync(CancellationToken cancellationToken = default)
            => await ReadContentSyncOrAsync(cancellationToken, async: true).ConfigureAwait(false);

        private async ValueTask<BinaryData> ReadContentSyncOrAsync(CancellationToken cancellationToken, bool async)
        {
            if (_bufferedContent is not null)
            {
                // Content has already been buffered.
                return _bufferedContent;
            }

            if (_contentStream == null)
            {
                // Content is not buffered but there is no source stream.
                // Our contract from Azure.Core is to return empty BinaryData in this case.
                _bufferedContent = s_EmptyBinaryData;
                return _bufferedContent;
            }

            // ContentStream still holds the source stream.  Buffer the content
            // and dispose the source stream.
            BufferedContentStream bufferStream = new();

            if (async)
            {
                await _contentStream.CopyToAsync(bufferStream, NetworkTimeout, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _contentStream.CopyTo(bufferStream, NetworkTimeout, cancellationToken);
            }

            _contentStream.Dispose();
            _contentStream = null;

            bufferStream.Position = 0;

            _bufferedContent = bufferStream.TryGetBuffer(out ArraySegment<byte> segment) ?
                new BinaryData(segment.AsMemory()) :
                new BinaryData(bufferStream.ToArray());

            return _bufferedContent;
        }

        public override void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                HttpResponseMessage httpResponse = _httpResponse;
                httpResponse?.Dispose();

                // This response type has two states:
                //   1. _contentStream holds a "source stream" which has not
                //      been buffered; _bufferedContent is null.
                //   2. _bufferedContent is set and _contentStream is null.
                //
                // Given this, if _contentStream is not null, we are holding
                // a source stream and will dispose it.

                Stream? contentStream = _contentStream;
                contentStream?.Dispose();
                _contentStream = null;

                _disposed = true;
            }
        }

        private class BufferedContentStream : MemoryStream { }
    }
}
