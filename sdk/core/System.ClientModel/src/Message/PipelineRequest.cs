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
        get => GetMethodCore();
        set => SetMethodCore(value);
    }

    protected abstract string GetMethodCore();

    protected abstract void SetMethodCore(string method);

    public Uri Uri
    {
        get => GetUriCore();
        set => SetUriCore(value);
    }

    protected abstract Uri GetUriCore();

    protected abstract void SetUriCore(Uri uri);

    public PipelineRequestHeaders Headers { get => GetHeadersCore(); }

    protected abstract PipelineRequestHeaders GetHeadersCore();

    public BinaryContent? Content
    {
        get => GetContentCore();
        set => SetContentCore(value);
    }

    protected abstract BinaryContent? GetContentCore();

    protected abstract void SetContentCore(BinaryContent? content);

    public abstract void Dispose();
}