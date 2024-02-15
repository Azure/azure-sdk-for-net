// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public abstract class PipelineRequest : IDisposable
{
    /// <summary>
    /// Gets or sets the request HTTP method.
    /// </summary>
    public string Method
    {
        get => MethodCore;
        set => MethodCore = value;
    }

    protected abstract string MethodCore { get; set; }

    public Uri? Uri
    {
        get => UriCore;
        set => UriCore = value;
    }

    protected abstract Uri? UriCore { get; set; }

    public PipelineRequestHeaders Headers => HeadersCore;

    protected abstract PipelineRequestHeaders HeadersCore { get; }

    public BinaryContent? Content
    {
        get => ContentCore;
        set => ContentCore = value;
    }

    protected abstract BinaryContent? ContentCore { get; set; }

    public abstract void Dispose();
}
