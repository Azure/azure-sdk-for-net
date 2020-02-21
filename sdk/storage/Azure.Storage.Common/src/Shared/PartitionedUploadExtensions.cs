// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Azure.Storage.Shared
{
    internal static class PartitionedUploadExtensions
    {
        /// <summary>
        /// Some streams will throw if you try to access their length so we wrap
        /// the check in a TryGet helper.
        /// </summary>
        internal static bool TryGetLength(Stream content, out long length)
        {
            length = 0;
            if (content == null)
            {
                return true;
            }
            try
            {
                if (content.CanSeek)
                {
                    length = content.Length;
                    return true;
                }
            }
            catch (NotSupportedException)
            {
            }
            return false;
        }

        /// <summary>
        /// Partition a stream into a series of blocks using our ArrayPool.
        /// </summary>
        internal static async IAsyncEnumerable<ChunkedStream> GetBlocksAsync(
            Stream stream,
            int blockSize,
            bool async,
            ArrayPool<byte> arrayPool,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            int read;
            long absolutePosition = 0;

            // The minimum amount of data we'll accept from a stream before
            // splitting another block.
            int minimumBlockSize = blockSize / 2;

            // Read the next block
            do
            {
                // Reserve a block's worth of memory
                byte[] bytes = arrayPool.Rent(blockSize);
                try
                {
                    int offset = 0;
                    do
                    {
                        // You can ask a stream to read however many bytes, but
                        // it's only going to read as much as it wants.  We're
                        // trying to saturate the network so we can live with
                        // sending more, smaller blocks rather than fewer
                        // perfectly sized blocks that are bound by local I/O.
                        if (async)
                        {
                            read = await stream.ReadAsync(
                                bytes,
                                offset,
                                blockSize - offset,
                                cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            read = stream.Read(bytes, offset, blockSize - offset);
                        }
                        offset += read;
                        absolutePosition += read;

                        // Keep reading until we've got enough to fill a block or
                        // until we can't read any more
                    } while (offset < minimumBlockSize && read != 0);

                    // If we read anything, turn it into a StreamPartition and
                    // return it for staging
                    if (offset != 0)
                    {
                        // The StreamParitition is disposable and it'll be the
                        // user's responsibility to return the bytes used to our
                        // ArrayPool
                        yield return new ChunkedStream(absolutePosition, bytes, offset, arrayPool);

                        // Clear the bytes reference so we don't return any
                        // memory that we've handed off to users in our finally
                        // block below
                        bytes = null;
                    }
                }
                finally
                {
                    // If we have memory that wasn't returned as a block, give
                    // it back to the ArrayPool
                    if (bytes != null)
                    {
                        arrayPool.Return(bytes);
                    }
                }

                // Continue reading blocks until we've exhausted the stream
            } while (read != 0);
        }
    }
}
