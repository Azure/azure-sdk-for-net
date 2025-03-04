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

        public static Task<long> CopyToInternal(
            this Stream src,
            Stream dest,
            bool async,
            CancellationToken cancellationToken)
            => CopyToInternal(
                src,
                dest,
                bufferSize: 81920, // default from .NET documentation
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
        public static async Task<long> CopyToInternal(
            this Stream src,
            Stream dest,
            int bufferSize,
            bool async,
            CancellationToken cancellationToken)
        {
            using IDisposable _ = ArrayPool<byte>.Shared.RentDisposable(bufferSize, out byte[] buffer);
            long totalRead = 0;
            int read;
            if (async)
            {
                while (0 < (read = await src.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)))
                {
                    totalRead += read;
                    await dest.WriteAsync(buffer, 0, read, cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {
                while (0 < (read = src.Read(buffer, 0, buffer.Length)))
                {
                    totalRead += read;
                    dest.Write(buffer, 0, read);
                }
            }
            return totalRead;
        }
    }
}
