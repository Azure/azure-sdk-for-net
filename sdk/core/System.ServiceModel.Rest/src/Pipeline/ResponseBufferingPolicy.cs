// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.IO;
using System.ServiceModel.Rest.Internal;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

/// <summary>
/// Pipeline policy to buffer response content or add a timeout to response content managed by the client
/// </summary>
public class ResponseBufferingPolicy : IPipelinePolicy<PipelineMessage, InvocationOptions>
{
    // Same value as Stream.CopyTo uses by default
    private const int DefaultCopyBufferSize = 81920;

    private readonly TimeSpan _networkTimeout;

    public ResponseBufferingPolicy(TimeSpan networkTimeout)
    {
        _networkTimeout = networkTimeout;
    }

    public void Process(PipelineMessage message, InvocationOptions options, IPipelineEnumerator pipeline)

#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        => ProcessSyncOrAsync(message, options, pipeline, async: false).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

    public async ValueTask ProcessAsync(PipelineMessage message, InvocationOptions options, IPipelineEnumerator pipeline)
        => await ProcessSyncOrAsync(message, options, pipeline, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, InvocationOptions options, IPipelineEnumerator pipeline, bool async)
    {
        CancellationToken oldToken = options.CancellationToken;
        using CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(oldToken);

        TimeSpan networkTimeout = _networkTimeout;
        if (options.NetworkTimeout is TimeSpan networkTimeoutOverride)
        {
            networkTimeout = networkTimeoutOverride;
        }

        cts.CancelAfter(networkTimeout);
        try
        {
            options.CancellationToken = cts.Token;
            if (async)
            {
                await pipeline.ProcessNextAsync().ConfigureAwait(false);
            }
            else
            {
                pipeline.ProcessNext();
            }
        }
        catch (OperationCanceledException ex)
        {
            ThrowIfCancellationRequestedOrTimeout(oldToken, cts.Token, ex, networkTimeout);
            throw;
        }
        finally
        {
            options.CancellationToken = oldToken;
            cts.CancelAfter(Timeout.Infinite);
        }

        Stream? responseContentStream = message.Response.ContentStream;
        if (responseContentStream == null || responseContentStream.CanSeek)
        {
            return;
        }

        if (options.BufferResponse)
        {
            // If cancellation is possible (whether due to network timeout or a user cancellation token being passed), then
            // register callback to dispose the stream on cancellation.
            if (networkTimeout != Timeout.InfiniteTimeSpan || oldToken.CanBeCanceled)
            {
                cts.Token.Register(state => ((Stream?)state)?.Dispose(), responseContentStream);
            }

            try
            {
                var bufferedStream = new MemoryStream();
                if (async)
                {
                    await CopyToAsync(responseContentStream, bufferedStream, cts).ConfigureAwait(false);
                }
                else
                {
                    CopyTo(responseContentStream, bufferedStream, cts);
                }

                responseContentStream.Dispose();
                bufferedStream.Position = 0;
                message.Response.ContentStream = bufferedStream;
            }
            // We dispose stream on timeout or user cancellation so catch and check if cancellation token was cancelled
            catch (Exception ex)
                when (ex is ObjectDisposedException
                          or IOException
                          or OperationCanceledException
                          or NotSupportedException)
            {
                ThrowIfCancellationRequestedOrTimeout(oldToken, cts.Token, ex, networkTimeout);
                throw;
            }
        }
    }

    private async Task CopyToAsync(Stream source, Stream destination, CancellationTokenSource cancellationTokenSource)
    {
        byte[] buffer = ArrayPool<byte>.Shared.Rent(DefaultCopyBufferSize);
        try
        {
            while (true)
            {
                cancellationTokenSource.CancelAfter(_networkTimeout);
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

    private void CopyTo(Stream source, Stream destination, CancellationTokenSource cancellationTokenSource)
    {
        byte[] buffer = ArrayPool<byte>.Shared.Rent(DefaultCopyBufferSize);
        try
        {
            int read;
            while ((read = source.Read(buffer, 0, buffer.Length)) != 0)
            {
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                cancellationTokenSource.CancelAfter(_networkTimeout);
                destination.Write(buffer, 0, read);
            }
        }
        finally
        {
            cancellationTokenSource.CancelAfter(Timeout.InfiniteTimeSpan);
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    /// <summary>Throws a cancellation exception if cancellation has been requested via <paramref name="originalToken"/> or <paramref name="timeoutToken"/>.</summary>
    /// <param name="originalToken">The customer provided token.</param>
    /// <param name="timeoutToken">The linked token that is cancelled on timeout provided token.</param>
    /// <param name="inner">The inner exception to use.</param>
    /// <param name="timeout">The timeout used for the operation.</param>
#pragma warning disable CA1068 // Cancellation token has to be the last parameter
    internal static void ThrowIfCancellationRequestedOrTimeout(CancellationToken originalToken, CancellationToken timeoutToken, Exception? inner, TimeSpan timeout)
#pragma warning restore CA1068
    {
        ClientUtilities.ThrowIfCancellationRequested(originalToken);

        if (timeoutToken.IsCancellationRequested)
        {
            // TODO: Make this error message correct
            throw ClientUtilities.CreateOperationCanceledException(
                inner,
                timeoutToken,
                $"The operation was cancelled because it exceeded the configured timeout of {timeout:g}. ");
        }
    }
}
