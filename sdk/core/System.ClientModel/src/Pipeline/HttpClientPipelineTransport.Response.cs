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
    private class HttpClientTransportResponse : PipelineResponse
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

        public HttpClientTransportResponse(HttpResponseMessage httpResponse)
        {
            _httpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
            _httpResponseContent = _httpResponse.Content;

            // Don't dispose the content so it remains available for reading headers.
            _httpResponse.Content = null;
        }

        public override int Status => (int)_httpResponse.StatusCode;

        public override string ReasonPhrase
            => _httpResponse.ReasonPhrase ?? string.Empty;

        protected override PipelineResponseHeaders HeadersCore
            => new HttpClientResponseHeaders(_httpResponse, _httpResponseContent);

        public override Stream? ContentStream
        {
            get
            {
                if (_contentStream is not null)
                {
                    return _contentStream;
                }

                return BufferContent().ToStream();
            }
            set
            {
                _contentStream = value;

                // Invalidate the cache since the source-stream has been replaced.
                _bufferedContent = null;
            }
        }

        public override BinaryData Content
        {
            get
            {
                if (_bufferedContent is not null)
                {
                    return _bufferedContent;
                }

                if (_contentStream is null || _contentStream is MemoryStream)
                {
                    return BufferContent();
                }

                throw new InvalidOperationException($"The response is not buffered.");
            }
        }

        public override BinaryData BufferContent(CancellationToken cancellationToken = default)
            => BufferContentSyncOrAsync(cancellationToken, async: false).EnsureCompleted();

        public override async ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
            => await BufferContentSyncOrAsync(cancellationToken, async: true).ConfigureAwait(false);

        private async ValueTask<BinaryData> BufferContentSyncOrAsync(CancellationToken cancellationToken, bool async)
        {
            if (_bufferedContent is not null)
            {
                // Content has already been buffered.
                return _bufferedContent;
            }

            if (_contentStream == null)
            {
                // Content is not buffered but there is no source stream.
                // Our contract from Azure.Core is to return BinaryData.Empty in this case.
                _bufferedContent = s_EmptyBinaryData;
                return _bufferedContent;
            }

            if (_contentStream.CanSeek && _contentStream.Position != 0)
            {
                throw new InvalidOperationException("Content stream position is not at beginning of stream.");
            }

            // ContentStream still holds the source stream.  Buffer the content
            // and dispose the source stream.
            BufferedContentStream bufferStream = new();

            if (async)
            {
                await _contentStream.CopyToAsync(bufferStream, cancellationToken).ConfigureAwait(false);
#if NETSTANDARD2_0
                _contentStream.Dispose();
#else
                await _contentStream.DisposeAsync().ConfigureAwait(false);
#endif
            }
            else
            {
                _contentStream.CopyTo(bufferStream, cancellationToken);
                _contentStream.Dispose();
            }

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

                if (ContentStream is MemoryStream)
                {
                    BufferContent();
                }

                Stream? contentStream = _contentStream;
                contentStream?.Dispose();
                _contentStream = null;

                _disposed = true;
            }
        }

        private class BufferedContentStream : MemoryStream { }
    }
}
