// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;

namespace System.ClientModel.Primitives;

public abstract class PipelineRequest : IDisposable
{
    // TODO: if we decide to implement more of Http rather than copy,
    // Will more of this need to be abstract instead of virtual?
    private readonly PipelineRequestHeaders _headers;

    private Uri? _uri;
    private InputContent? _content;

    public PipelineRequest()
    {
        Method = HttpMethod.Get.Method;
        _headers = new PipelineRequestHeaders();
    }

    public virtual string Method { get; set; }

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

    public virtual MessageHeaders Headers => _headers;

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