// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelineResponse : IDisposable
{
    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    internal static readonly BinaryData s_EmptyBinaryData = new(Array.Empty<byte>());

    /// <summary>
    /// Gets the HTTP status code.
    /// </summary>
    public abstract int Status { get; }

    /// <summary>
    /// Gets the HTTP reason phrase.
    /// </summary>
    public abstract string ReasonPhrase { get; }

    public PipelineResponseHeaders Headers => HeadersCore;

    protected abstract PipelineResponseHeaders HeadersCore { get; }

    /// <summary>
    /// Gets the contents of HTTP response. Returns <c>null</c> for responses without content.
    /// </summary>
    public abstract Stream? ContentStream { get; set; }

    public abstract BinaryData Content { get; }

    public abstract BinaryData BufferContent(CancellationToken cancellationToken = default);

    public abstract ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    // IsError must be virtual in order to maintain Azure.Core back-compatibility.
    public virtual bool IsError => IsErrorCore;

    protected internal virtual bool IsErrorCore { get; set; }

    public abstract void Dispose();
}
