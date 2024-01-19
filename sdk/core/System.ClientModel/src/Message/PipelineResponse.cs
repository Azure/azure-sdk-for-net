// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.ClientModel.Internal;
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

    public virtual BinaryData Content
    {
        get
        {
            if (ContentStream == null)
            {
                return s_emptyBinaryData;
            }

            if (!TryGetBufferedContent(out MemoryStream bufferedContent))
            {
                throw new InvalidOperationException($"The response is not buffered.");
            }

            if (bufferedContent.TryGetBuffer(out ArraySegment<byte> segment))
            {
                return new BinaryData(segment.AsMemory());
            }
            else
            {
                return new BinaryData(bufferedContent.ToArray());
            }
        }
    }

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

    #region Response Buffering

    // Same value as Stream.CopyTo uses by default
    private const int DefaultCopyBufferSize = 81920;

    internal bool TryGetBufferedContent(out MemoryStream bufferedContent)
    {
        if (ContentStream is MemoryStream content)
        {
            bufferedContent = content;
            return true;
        }

        bufferedContent = default!;
        return false;
    }

    internal void BufferContent(TimeSpan? timeout = default, CancellationTokenSource? cts = default)
    {
        Stream? responseContentStream = ContentStream;
        if (responseContentStream == null || TryGetBufferedContent(out _))
        {
            // No need to buffer content.
            return;
        }

        MemoryStream bufferStream = new();
        CopyTo(responseContentStream, bufferStream, timeout ?? NetworkTimeout, cts ?? new CancellationTokenSource());
        responseContentStream.Dispose();
        bufferStream.Position = 0;
        ContentStream = bufferStream;
    }

    internal async Task BufferContentAsync(TimeSpan? timeout = default, CancellationTokenSource? cts = default)
    {
        Stream? responseContentStream = ContentStream;
        if (responseContentStream == null || TryGetBufferedContent(out _))
        {
            // No need to buffer content.
            return;
        }

        MemoryStream bufferStream = new();
        await CopyToAsync(responseContentStream, bufferStream, timeout ?? NetworkTimeout, cts ?? new CancellationTokenSource()).ConfigureAwait(false);
        responseContentStream.Dispose();
        bufferStream.Position = 0;
        ContentStream = bufferStream;
    }

    private static async Task CopyToAsync(Stream source, Stream destination, TimeSpan timeout, CancellationTokenSource cancellationTokenSource)
    {
        byte[] buffer = ArrayPool<byte>.Shared.Rent(DefaultCopyBufferSize);
        try
        {
            while (true)
            {
                cancellationTokenSource.CancelAfter(timeout);
#pragma warning disable CA1835 // ReadAsync(Memory<>) overload is not available in all targets
                int bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token).ConfigureAwait(false);
#pragma warning restore // ReadAsync(Memory<>) overload is not available in all targets
                if (bytesRead == 0) break;
                await destination.WriteAsync(new ReadOnlyMemory<byte>(buffer, 0, bytesRead), cancellationTokenSource.Token).ConfigureAwait(false);
            }
        }
        finally
        {
            cancellationTokenSource.CancelAfter(Timeout.InfiniteTimeSpan);
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private static void CopyTo(Stream source, Stream destination, TimeSpan timeout, CancellationTokenSource cancellationTokenSource)
    {
        byte[] buffer = ArrayPool<byte>.Shared.Rent(DefaultCopyBufferSize);
        try
        {
            int read;
            while ((read = source.Read(buffer, 0, buffer.Length)) != 0)
            {
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                cancellationTokenSource.CancelAfter(timeout);
                destination.Write(buffer, 0, read);
            }
        }
        finally
        {
            cancellationTokenSource.CancelAfter(Timeout.InfiniteTimeSpan);
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    #endregion
}
