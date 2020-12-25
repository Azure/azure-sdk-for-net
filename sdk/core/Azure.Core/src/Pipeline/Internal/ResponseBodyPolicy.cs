// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Buffers;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Pipeline policy to buffer response content or add a timeout to response content managed by the client
    /// </summary>
    internal class ResponseBodyPolicy : HttpPipelinePolicy
    {
        // Same value as Stream.CopyTo uses by default
        private const int DefaultCopyBufferSize = 81920;

        private readonly TimeSpan _networkTimeout;

        public ResponseBodyPolicy(TimeSpan networkTimeout)
        {
            _networkTimeout = networkTimeout;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessAsync(message, pipeline, true).ConfigureAwait(false);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            CancellationToken oldToken = message.CancellationToken;
            using CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(oldToken);

            cts.CancelAfter(_networkTimeout);
            try
            {
                message.CancellationToken = cts.Token;
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
            }
            finally
            {
                message.CancellationToken = oldToken;
                cts.CancelAfter(Timeout.Infinite);
            }

            Stream? responseContentStream = message.Response.ContentStream;
            if (responseContentStream == null || responseContentStream.CanSeek)
            {
                return;
            }

            if (message.BufferResponse)
            {
                if (_networkTimeout != Timeout.InfiniteTimeSpan)
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
                // We dispose stream on timeout so catch and check if cancellation token was cancelled
                catch (ObjectDisposedException)
                {
                    cts.Token.ThrowIfCancellationRequested();
                    throw;
                }
            }
            else if (_networkTimeout != Timeout.InfiniteTimeSpan)
            {
                message.Response.ContentStream = new ReadTimeoutStream(responseContentStream, _networkTimeout);
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
    }
}