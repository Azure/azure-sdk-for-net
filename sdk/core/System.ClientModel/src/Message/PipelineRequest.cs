// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public abstract class PipelineRequest : IDisposable
{
    private string _method;
    private Uri? _uri;

    private readonly PipelineRequestHeaders _headers;

    protected PipelineRequest()
    {
        _method = "GET";
        _headers = new PipelineRequestHeaders();
    }

    /// <summary>
    /// Gets or sets the request HTTP method.
    /// </summary>
    public string Method
    {
        get => _method;
        set => _method = value;
    }

    public Uri Uri
    {
        get => GetUriCore();

        set => _uri = value;
    }

    protected virtual Uri GetUriCore()
    {
        if (_uri is null)
        {
            throw new InvalidOperationException("Uri has not be set on HttpMessageRequest instance.");
        }

        return _uri;
    }

    public InputContent? Content { get; set; }

    public MessageHeaders Headers => _headers;

    public virtual void Dispose()
    {
        var content = Content;
        if (content != null)
        {
            Content = null;
            content.Dispose();
        }

        GC.SuppressFinalize(this);
    }
}