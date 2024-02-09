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

        private bool _disposed;

        public HttpPipelineResponse(HttpResponseMessage httpResponse, Stream? stream) :
            base(stream)
        {
            _httpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
            _httpResponseContent = _httpResponse.Content;

            // Make sure we don't dispose the content if the stream was replaced
            _httpResponse.Content = null;
        }

        public override int Status => (int)_httpResponse.StatusCode;

        public override string ReasonPhrase
            => _httpResponse.ReasonPhrase ?? string.Empty;

        protected override PipelineResponseHeaders GetHeadersCore()
            => new HttpClientResponseHeaders(_httpResponse, _httpResponseContent);

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

                // TODO: Move to base type

                //Stream? contentStream = _contentStream;
                //if (contentStream is not null)
                //{
                //    // In this world, if we have a content stream, it's a network
                //    // stream.  Dispose it.

                //    contentStream?.Dispose();
                //    _contentStream = null;
                //}

                _disposed = true;
            }
        }
        #endregion
    }
}
