// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelineResponse : IDisposable
{
    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    private static readonly BinaryData s_emptyBinaryData = new(Array.Empty<byte>());

    private bool _isError = false;

    /// <summary>
    /// Gets the HTTP status code.
    /// </summary>
    public abstract int Status { get; }

    /// <summary>
    /// Gets the HTTP reason phrase.
    /// </summary>
    public abstract string ReasonPhrase { get; }

    public PipelineResponseHeaders Headers => GetHeadersCore();

    protected abstract PipelineResponseHeaders GetHeadersCore();

    /// <summary>
    /// Gets the contents of HTTP response. Returns <c>null</c> for responses without content.
    /// </summary>
    public abstract Stream? ContentStream { get; set; }

    public abstract BinaryData Content { get; }

    public abstract BinaryData ReadContent(CancellationToken cancellationToken = default);

    public abstract ValueTask<BinaryData> ReadContentAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    // IsError must be virtual in order to maintain Azure.Core back-compatibility.
    public virtual bool IsError => _isError;

    // We have to have a separate method for setting IsError so that the IsError
    // setter doesn't become virtual when we make the getter virtual.
    internal void SetIsError(bool isError) => SetIsErrorCore(isError);

    protected virtual void SetIsErrorCore(bool isError) => _isError = isError;

    internal TimeSpan NetworkTimeout { get; set; } = ClientPipeline.DefaultNetworkTimeout;

    public abstract void Dispose();

    //internal void BufferContent(TimeSpan? timeout = default, CancellationTokenSource? cts = default)
    //{
    //    Stream? responseContentStream = ContentStream;
    //    if (responseContentStream == null || TryGetBufferedContent(out _))
    //    {
    //        // No need to buffer content.
    //        return;
    //    }

    //    MemoryStream bufferStream = new();
    //    CopyTo(responseContentStream, bufferStream, timeout ?? NetworkTimeout, cts ?? new CancellationTokenSource());
    //    responseContentStream.Dispose();
    //    bufferStream.Position = 0;
    //    ContentStream = bufferStream;
    //}

    //internal async Task BufferContentAsync(TimeSpan? timeout = default, CancellationTokenSource? cts = default)
    //{
    //    Stream? responseContentStream = ContentStream;
    //    if (responseContentStream == null || TryGetBufferedContent(out _))
    //    {
    //        // No need to buffer content.
    //        return;
    //    }

    //    MemoryStream bufferStream = new();
    //    await CopyToAsync(responseContentStream, bufferStream, timeout ?? NetworkTimeout, cts ?? new CancellationTokenSource()).ConfigureAwait(false);
    //    responseContentStream.Dispose();
    //    bufferStream.Position = 0;
    //    ContentStream = bufferStream;
    //}
}
