// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;

namespace System.ClientModel.Primitives;

public abstract class PipelineRequest : IDisposable
{
    private string _method;
    private Uri? _uri;
    private InputContent? _content;
    private readonly PipelineRequestHeaders _headers;

    protected PipelineRequest()
    {
        _method = HttpMethod.Get.Method;
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

    public virtual Uri Uri
    {
        get
        {
            if (_uri is null)
            {
                throw new InvalidOperationException("Uri has not be set on HttpMessageRequest instance.");
            }

            return _uri;
        }

        set => _uri = value;
    }

    public virtual InputContent? Content { get; set; }

    public MessageHeaders Headers => _headers;

    public virtual void Dispose()
    {
        var content = _content;
        if (content != null)
        {
            _content = null;
            content.Dispose();
        }

        GC.SuppressFinalize(this);
    }
}