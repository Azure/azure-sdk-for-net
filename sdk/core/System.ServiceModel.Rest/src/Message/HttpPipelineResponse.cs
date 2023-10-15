// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.Http;

namespace System.ServiceModel.Rest.Core.Pipeline;

public class HttpPipelineResponse : PipelineResponse, IDisposable
{
    private readonly HttpResponseMessage _httpResponse;
    private readonly HttpContent _httpResponseContent;

    private MessageContent? _content;

    // TODO: keeping this for now to make sure complex Dipose logic is respected,
    // but it would be nice to see if we can make this go away at some point.
    //private Stream? _contentStream;

    private bool _disposed;

    // TODO: why do we need content stream here?
    protected internal HttpPipelineResponse(HttpResponseMessage httpResponse /*, Stream? contentStream*/)
    {
        _httpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));

        //if (contentStream is not null)
        //{
        //    _content = MessageContent.CreateContent(contentStream);
        //}
        //else
        //{
        //    _content = MessageContent.CreateContent(MessageContent.EmptyBinaryData);
        //}

        // We need to back up the response content so we can read headers out of it later
        // if we set the content to null when we buffer the content stream.
        _httpResponseContent = _httpResponse.Content;
    }

    public override int Status => (int)_httpResponse.StatusCode;

    public override string ReasonPhrase
        => _httpResponse.ReasonPhrase ?? string.Empty;

    public override MessageHeaders Headers
        => new MessageResponseHeaders(_httpResponse, _httpResponseContent);

    public override MessageContent? Content
    {
        get
        {
            _content ??= MessageContent.Empty;
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

            MessageContent? content = _content;
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
