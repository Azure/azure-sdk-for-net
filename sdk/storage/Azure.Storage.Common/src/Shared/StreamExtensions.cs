// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Extension methods for working with Streams.
    /// </summary>
    internal static partial class StreamExtensions
    {
        private const int DefaultCopyBufferSize = 81920; // default from .NET documentation

        public static async Task<int> ReadInternal(
            this Stream stream,
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            if (async)
            {
                return await stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return stream.Read(buffer, offset, count);
            }
        }

        public static async Task WriteInternal(
            this Stream stream,
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            if (async)
            {
                await stream.WriteAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                stream.Write(buffer, offset, count);
            }
        }

        public static Task CopyToInternal(
            this Stream src,
            Stream dest,
            bool async,
            CancellationToken cancellationToken)
            => CopyToInternal(
                src,
                dest,
                DefaultCopyBufferSize,
                async,
                cancellationToken);

        /// <summary>
        /// Reads the bytes from the source stream and writes them to the destination stream.
        /// </summary>
        /// <param name="src">
        /// Stream to copy from.
        /// </param>
        /// <param name="dest">
        /// Stream to copy to.
        /// </param>
        /// <param name="bufferSize">
        /// The size, in bytes, of the buffer. This value must be greater than zero.
        /// </param>
        /// <param name="async">
        /// Whether to perform the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token for the operation.
        /// </param>
        /// <returns></returns>
        public static async Task CopyToInternal(
            this Stream src,
            Stream dest,
            int bufferSize,
            bool async,
            CancellationToken cancellationToken)
        {
            if (async)
            {
                await src.CopyToAsync(dest, bufferSize, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                src.CopyTo(dest, bufferSize);
            }
        }

        public static async Task<long> CopyToExactInternal(
            this Stream src,
            Stream dst,
            long count,
            bool async,
            CancellationToken cancellationToken)
            => await CopyToExactInternal(
                src,
                dst,
                count,
                DefaultCopyBufferSize,
                async,
                cancellationToken)
                .ConfigureAwait(false);

        public static async Task<long> CopyToExactInternal(
            this Stream src,
            Stream dst,
            long count,
            int copyBufferSize,
            bool async,
            CancellationToken cancellationToken)
        {
            using IDisposable _ = ArrayPool<byte>.Shared.RentDisposable(copyBufferSize, out byte[] copyBuffer);
            long totalCopied = 0;
            while (totalCopied < count)
            {
                int read = await src.ReadInternal(copyBuffer, 0, (int)Math.Min(count - totalCopied, copyBuffer.Length), async, cancellationToken).ConfigureAwait(false);
                if (read == 0)
                {
                    break;
                }
                await dst.WriteInternal(copyBuffer, 0, read, async, cancellationToken).ConfigureAwait(false);
                totalCopied += read;
            }
            return totalCopied;
        }
    }
}
