// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;

namespace System.ServiceModel.Rest.Core.Pipeline;

public class HttpPipelineResponse : PipelineResponse, IDisposable
{
    private readonly HttpResponseMessage _httpResponse;

    // TODO: Add a comment saying why we need to hold out HttpContent
    // separate from the _httpResponse.Content property.  Do we really?
    private readonly HttpContent _httpResponseContent;

    private PipelineMessageContent? _content;

    private bool _disposed;

    protected internal HttpPipelineResponse(HttpResponseMessage httpResponse)
    {
        // TODO: why did we need to set content stream here before,
        // and do we still need to for some reason?

        _httpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));

        // We need to back up the response content so we can read headers out of it later
        // if we set the content to null when we buffer the content stream.
        _httpResponseContent = _httpResponse.Content;
    }

    public override int Status => (int)_httpResponse.StatusCode;

    public override string ReasonPhrase
        => _httpResponse.ReasonPhrase ?? string.Empty;

    public override MessageHeaders Headers
        => new MessageResponseHeaders(_httpResponse, _httpResponseContent);

    public override PipelineMessageContent? Content
    {
        get
        {
            _content ??= PipelineMessageContent.Empty;
            return _content;
        }

        protected internal set
        {
            // Make sure we don't dispose the content later since we're replacing
            // the content stream now.
            //_httpResponse.Content = null;

            // TODO: Why not?
            // Shouldn't we dispose it if the stream is replaced?  We're holding a
            // reference to it, so wouldn't we want to make sure it gets disposed
            // at some point?

            // TODO: we can test this by removing the part where we null out
            // httpResponse.Content and just alowing it to be disposed.  Where/when
            // is it used?

            _content = value;
        }
    }

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var httpResponse = _httpResponse;
            httpResponse?.Dispose();

            //// We want to keep the ContentStream readable
            //// even after the response is disposed but only if it's a
            //// buffered memory stream otherwise we can leave a network
            //// connection hanging open
            //if (_contentStream is not MemoryStream)
            //{
            //    var contentStream = _contentStream;
            //    contentStream?.Dispose();
            //    _contentStream = null;
            //}

            PipelineMessageContent? content = _content;
            if (content is not null && !content.IsBuffered)
            {
                content?.Dispose();
                _content = null;
            }

            //// TODO: work through dispose story for response content
            //// I think it means that the "when do I dipose stream" logic moves
            //// into MessageContent.StreamContent's Dipose method.
            //var content = _content;
            //content?.Dispose();
            //_content = null;

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
