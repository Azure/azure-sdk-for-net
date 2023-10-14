// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace System.ServiceModel.Rest.Core.Pipeline;

public class HttpPipelineResponse : PipelineResponse, IDisposable
{
    private readonly HttpResponseMessage _httpResponse;
    private Stream? _contentStream;

    private bool _disposed;

    // TODO: why do we need content stream here?
    // TODO: why is constructor public?
    public HttpPipelineResponse(HttpResponseMessage httpResponse, Stream? contentStream)
    {
        _httpResponse = httpResponse ?? throw new ArgumentNullException(nameof(httpResponse));
        _contentStream = contentStream;
    }

    public override int Status => (int)_httpResponse.StatusCode;

    public override string ReasonPhrase
        => _httpResponse.ReasonPhrase ?? string.Empty;

    public override MessageHeaders Headers => new MessageResponseHeaders(_httpResponse);

    public override Stream? ContentStream
    {
        get => _contentStream;
        protected internal set
        {
            // Make sure we don't dispose the content if the stream was replaced
            _httpResponse.Content = null;

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
