// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        public static Task CopyToInternal(
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
    }
}
