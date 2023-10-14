// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.Http;

namespace System.ServiceModel.Rest.Core.Pipeline;

public class HttpPipelineResponse : PipelineResponse, IDisposable
{
    private readonly HttpResponseMessage _httpResponse;
    private readonly HttpContent _httpResponseContent;

    private Stream? _contentStream;

    private bool _disposed;

    // TODO: why do we need content stream here?
    protected internal HttpPipelineResponse(HttpResponseMessage httpResponse, Stream? contentStream)
    {
        _httpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
        _contentStream = contentStream;

        // We need to back up the response content so we can read headers out of it later
        // if we set the content to null when we buffer the content stream.
        _httpResponseContent = _httpResponse.Content;
    }

    public override int Status => (int)_httpResponse.StatusCode;

    public override string ReasonPhrase
        => _httpResponse.ReasonPhrase ?? string.Empty;

    public override MessageHeaders Headers
        => new MessageResponseHeaders(_httpResponse, _httpResponseContent);

    public override Stream? ContentStream
    {
        // TODO: Why would we set the content in the constructor and then overwrite it later?
        // Is this the contract we want in this type?  It feels error prone, but I'm not sure I understand it very well.
        get => _contentStream;
        protected internal set
        {
            // Make sure we don't dispose the content if the stream was replaced
            _httpResponse.Content = null;

            // TODO: Why not?
            // Shouldn't we dispose it if the stream is replaced?  We're holding a
            // reference to it, so wouldn't we want to make sure it gets disposed
            // at some point?

            _contentStream = value;
        }
    }

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var httpResponse = _httpResponse;
            httpResponse?.Dispose();

            // We want to keep the ContentStream readable
            // even after the response is disposed but only if it's a
            // buffered memory stream otherwise we can leave a network
            // connection hanging open
            if (_contentStream is not MemoryStream)
            {
                var contentStream = _contentStream;
                contentStream?.Dispose();
                _contentStream = null;
            }

            _disposed = true;
        }
    }

    public override void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
