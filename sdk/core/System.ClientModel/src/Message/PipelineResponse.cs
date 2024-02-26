// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents an HTTP response received from a cloud service.
/// </summary>
public abstract class PipelineResponse : IDisposable
{
    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    internal static readonly BinaryData s_EmptyBinaryData = new(Array.Empty<byte>());

    /// <summary>
    /// Gets the status code of the HTTP response.
    /// </summary>
    public abstract int Status { get; }

    /// <summary>
    /// Gets the reason phrase that accompanies the status code on the HTTP
    /// reponse.
    /// </summary>
    public abstract string ReasonPhrase { get; }

    /// <summary>
    /// Gets the collection of HTTP request headers.
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
    /// contents transfered from the network stream that originally held the
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
    /// Gets the contents of the HTTP response.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the response is
    /// not buffered.</exception>
    /// <remarks>
    /// <see cref="Content"/> holds the in-memory contents of the HTTP response
    /// when <see cref="PipelineMessage.BufferResponse"/> is <c>true</c> on
    /// the message sent via <see cref="ClientPipeline.Send(PipelineMessage)"/>.
    /// If this <see cref="PipelineResponse"/> instance was obtained from the
    /// return value of a client's service method, please refer to the
    /// documentation for the service method to understand whether this property
    /// can be accessed without throwing an exception. If this instance is
    /// accessed from a <see cref="PipelinePolicy"/>, please check the value of
    /// <see cref="PipelineMessage.BufferResponse"/> to determine whether to
    /// obtain the response content from <see cref="Content"/> or
    /// <see cref="ContentStream"/>.
    /// </remarks>
    public abstract BinaryData Content { get; }

    /// <summary>
    /// Transfer the contents of the response network stream from
    /// <see cref="ContentStream"/> to a buffered cache on this
    /// <see cref="PipelineResponse"/> instance.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to
    /// use while buffering the content.</param>
    /// <returns>The buffered content.</returns>
    /// <remarks>
    /// This method will read the full content from the response cpntent
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
    /// This method will read the full content from the response cpntent
    /// network stream into memory. Please be sure the contents will fit into
    /// memory before calling this method.
    /// </remarks>
    public abstract ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    // IsError must be virtual in order to maintain Azure.Core back-compatibility.
    public virtual bool IsError => IsErrorCore;

    /// <summary>
    /// Gets or sets the derived-type's value of <see cref="IsError"/>.
    /// </summary>
    protected internal virtual bool IsErrorCore { get; set; }

    /// <inheritdoc/>
    public abstract void Dispose();
}
