// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.Http;

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

        public override bool TryGetContentStream(out Stream? stream)
        {
            stream = _contentStream;
            return _contentStream is not null;
        }

        protected internal override void SetContentStream(Stream? stream)
        {
            // Make sure we don't dispose the content if the stream was replaced
            _httpResponse.Content = null;

            _contentStream = stream;

            // Invalidate any cached content
            _bufferedContent = null;
        }

        public override BinaryData Content
        {
            get
            {
                if (_bufferedContent is not null)
                {
                    return _bufferedContent;
                }

                if (_contentStream == null)
                {
                    return s_emptyBinaryData;
                }

                if (_contentStream is not MemoryStream memoryStream)
                {
                    throw new InvalidOperationException($"The response is not buffered.");
                }

                if (memoryStream.TryGetBuffer(out ArraySegment<byte> segment))
                {
                    _bufferedContent = new BinaryData(segment.AsMemory());
                }
                else
                {
                    _bufferedContent = new BinaryData(memoryStream.ToArray());
                }

                // Note: Call to Content will transition to "buffered" state if
                // source stream is a MemoryStream.  This supports mocking.
                _contentStream = null;
                return _bufferedContent;
            }
        }

        protected override void SetContent(BinaryData content)
        {
            _bufferedContent = content;
        }

        #region IDisposable

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

                Stream? contentStream = _contentStream;
                contentStream?.Dispose();
                _contentStream = null;

                _disposed = true;
            }
        }
        #endregion
    }
}
