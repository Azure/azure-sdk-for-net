// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents an HTTP request to be sent to a cloud service.
/// The type of a <see cref="PipelineRequest"/> is specific to the type of the
/// <see cref="PipelineTransport"/> used by the <see cref="ClientPipeline"/>
/// that sends the request.  Because of this,
/// <see cref="ClientPipeline.CreateMessage"/> is used to create an instance of
/// <see cref="PipelineRequest"/> for a given pipeline.
/// </summary>
public abstract class PipelineRequest : IDisposable
{
    /// <summary>
    /// Gets or sets the HTTP method used by the HTTP request.
    /// </summary>
    public string Method
    {
        get => MethodCore;
        set => MethodCore = value;
    }

    /// <summary>
    /// Gets or sets the derived-type's value of the request's
    /// <see cref="Method"/>.
    /// </summary>
    protected abstract string MethodCore { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="System.Uri"/> used for the HTTP request.
    /// </summary>
    public Uri? Uri
    {
        get => UriCore;
        set => UriCore = value;
    }

    /// <summary>
    /// Gets or sets the derived-type's value of the request's <see cref="Uri"/>.
    /// </summary>
    protected abstract Uri? UriCore { get; set; }

    /// <summary>
    /// Gets the collection of HTTP request headers.
    /// </summary>
    public PipelineRequestHeaders Headers => HeadersCore;

    /// <summary>
    /// Gets or sets the derived-type's value of the request's
    /// <see cref="Headers"/> collection.
    /// </summary>
    protected abstract PipelineRequestHeaders HeadersCore { get; }

    /// <summary>
    /// Gets or sets the contents of the HTTP request.
    /// </summary>
    public BinaryContent? Content
    {
        get => ContentCore;
        set => ContentCore = value;
    }

    /// <summary>
    /// Gets or sets the derived-type's value of the request's
    /// <see cref="Content"/>.
    /// </summary>
    protected abstract BinaryContent? ContentCore { get; set; }

    /// <inheritdoc/>
    public abstract void Dispose();
}
