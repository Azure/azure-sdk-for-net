﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;

namespace System.Net.ClientModel.Core;

public class HttpPipelineResponse : PipelineResponse, IDisposable
{
    private readonly HttpResponseMessage _httpResponse;

    // We keep a reference to the http response content so it will be available
    // for reading headers, even if we set _httpResponse.Content to null when we
    // buffer the content.  Since we handle disposing the content separately, we
    // don't believe there is a concern about rooting objects that are holding
    // references to network resources.
    private readonly HttpContent _httpResponseContent;

    private MessageBody? _content;

    private bool _disposed;

    protected internal HttpPipelineResponse(HttpResponseMessage httpResponse)
    {
        _httpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
        _httpResponseContent = _httpResponse.Content;
    }

    public override int Status => (int)_httpResponse.StatusCode;

    public override string ReasonPhrase
        => _httpResponse.ReasonPhrase ?? string.Empty;

    public override PipelineMessageHeaders Headers
        => new MessageResponseHeaders(_httpResponse, _httpResponseContent);

    public override MessageBody? Content
    {
        get
        {
            _content ??= MessageBody.Empty;
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

            // TODO: We could feasibly leak a network resource if this setter
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

            // Some notes on this:
            //
            // 1. If the content is buffered, we want it to remain available to the
            // client for model deserialization and in case the end user of the
            // client calls Result.GetRawResponse. So, we don't dispose it.
            //
            // If the content is buffered, we assume that the entity that did the
            // buffering took responsibility for disposing the network stream.
            //
            // 2. If the content is not buffered, we dispose it so that we don't leave
            // a network connection open.
            //
            // One tricky piece here is that in some cases, we may not have buffered
            // the content because we  wanted to pass the live network stream out of
            // the client method and back to the end-user caller of the client e.g.
            // for a streaming API.  If the latter is the case, the client should have
            // called the HttpMessage.ExtractResponseContent method to obtain a reference
            // to the network stream, and the response content was replaced by a stream
            // that we are ok to dispose here.  In this case, the network stream is
            // not disposed, because the entity that replaced the response content
            // intentionally left the network stream undisposed.

            var content = _content;
            if (content is not null && !content.IsBuffered)
            {
                content?.Dispose();
                _content = null;
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
