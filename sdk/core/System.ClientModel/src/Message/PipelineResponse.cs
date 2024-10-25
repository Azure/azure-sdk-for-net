// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents an HTTP response received from a cloud service.
/// </summary>
public abstract class PipelineResponse : ServiceMessage, IDisposable
{
    /// <summary>
    /// Gets the status code of the response.
    /// </summary>
    public abstract int Status { get; }

    /// <summary>
    /// Gets the reason phrase that accompanies the status code on the HTTP
    /// response.
    /// </summary>
    public abstract string ReasonPhrase { get; }

    /// <summary>
    /// Gets the collection of HTTP response headers.
    /// </summary>
    public PipelineResponseHeaders Headers => HeadersCore;

    /// <summary>
    /// Gets or sets the derived-type's value of the response's
    /// <see cref="Headers"/> collection.
    /// </summary>
    protected abstract PipelineResponseHeaders HeadersCore { get; }

    /// <summary>
    /// Gets or sets the contents of the HTTP response.
    /// </summary>
    /// <remarks>
    /// <see cref="ContentStream"/> may be a stream that contains the buffered
    /// contents transferred from the network stream that originally held the
    /// contents of the service response; or it may be the live network stream
    /// itself, depending on the value of
    /// <see cref="PipelineMessage.BufferResponse"/> on the message sent via
    /// <see cref="ClientPipeline.Send(PipelineMessage)"/>. Please refer to the
    /// documentation for a client's service method if needed to understand
    /// whether this <see cref="PipelineResponse"/> instance must be disposed
    /// to close the network stream.
    /// </remarks>
    public abstract Stream? ContentStream { get; set; }

    /// <summary>
    /// Transfer the contents of the response network stream from
    /// <see cref="ContentStream"/> to a buffered cache on this
    /// <see cref="PipelineResponse"/> instance.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to
    /// use while buffering the content.</param>
    /// <returns>The buffered content.</returns>
    /// <remarks>
    /// This method will read the full content from the response content
    /// network stream into memory. Please be sure the contents will fit into
    /// memory before calling this method.
    /// </remarks>
    public abstract BinaryData BufferContent(CancellationToken cancellationToken = default);

    /// <summary>
    /// Transfer the contents of the response network stream from
    /// <see cref="ContentStream"/> to a buffered cache on this
    /// <see cref="PipelineResponse"/> instance.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to
    /// use while buffering the content.</param>
    /// <returns>The buffered content.</returns>
    /// <remarks>
    /// This method will read the full content from the response content
    /// network stream into memory. Please be sure the contents will fit into
    /// memory before calling this method.
    /// </remarks>
    public abstract ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public abstract void Dispose();
}
