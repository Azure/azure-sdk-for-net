// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Extension methods for <see cref="Channel{T}"/>.
    /// </summary>
    internal static class ChannelExtensions
    {
        /// <summary>
        /// Write an item to a <see cref="ChannelWriter{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="writer">The ChannelWriter.</param>
        /// <param name="item">The item to write.</param>
        /// <param name="async">Whether to run sync or async.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task representing the operation.</returns>
        internal static async Task WriteInternal<T>(
            this ChannelWriter<T> writer,
            T item,
            bool async,
            CancellationToken cancellationToken = default)
        {
            // Send the message
            if (async)
            {
                await writer.WriteAsync(item, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                // It's an unbounded channel so TryWrite will always succeed
                // today.  Defaulting to WriteAsync will only ever come into
                // play if somebody puts a bound on the Channel in the future.
                if (!writer.TryWrite(item))
                {
                    #pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                    writer.WriteAsync(item, cancellationToken).AsTask().GetAwaiter().GetResult();
                    #pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
                }
            }
        }
    }
}
