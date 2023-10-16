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

    private PipelineContent? _content;

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

    public override PipelineContent? Content
    {
        get
        {
            _content ??= PipelineContent.Empty;
            return _content;
        }

        protected internal set
        {
            _content = value;

            // Setting _httpResponse.Content to null makes it so when this type
            // disposes _httpResponse later, the content is not also disposed.
            // This works because the transport sets _content to the value of
            // _httpResponse.Content initially, so if this object is disposed
            // without its content being buffered, calling dispose on _content will
            // dispose the network stream.

            // TODO: We can potentially leak a network resource if this setter
            // is called without the caller taking ownership of and disposing the
            // network stream, since at that point, no one is holding a reference
            // to it anymore.  Today, ResponseBufferingPolicy takes care of this.

            _httpResponse.Content = null;
        }
    }

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var httpResponse = _httpResponse;
            httpResponse?.Dispose();

            var content = _content;
            if (content is not null && !content.IsBuffered)
            {
                content?.Dispose();
                _content = null;
            }

            _disposed = true;
        }
    }

    // Called by end-user of client, not the pipeline
    public override void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
