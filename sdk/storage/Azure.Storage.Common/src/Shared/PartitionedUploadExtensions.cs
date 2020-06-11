// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
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
        /// Partition a stream into a series of blocks buffered as needed by an array pool.
        /// </summary>
        internal static async IAsyncEnumerable<PooledMemoryStream> GetBufferedBlocksAsync(
            Stream stream,
            long blockSize,
            bool async,
            ArrayPool<byte> arrayPool,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            long read;
            long absolutePosition = 0;

            // The minimum amount of data we'll accept from a stream before
            // splitting another block.
            long acceptableBlockSize = blockSize / 2;

            // if we know the data length, assert boundaries before spending resources uploading beyond service capabilities
            if (stream.CanSeek)
            {
                // service has a max block count per blob
                // block size * block count limit = max data length to upload
                // if stream length is longer than specified max block size allows, can't upload
                long minRequiredBlockSize = (long)Math.Ceiling((double)stream.Length / Constants.Blob.Block.MaxBlocks);
                if (blockSize < minRequiredBlockSize)
                {
                    throw Errors.InsufficientStorageTransferOptions(stream.Length, blockSize, minRequiredBlockSize);
                }
                // bring min up to our min required by the service
                acceptableBlockSize = Math.Max(acceptableBlockSize, minRequiredBlockSize);
            }

            do
            {
                PooledMemoryStream partition = await PooledMemoryStream.BufferStreamPartitionInternal(
                    stream,
                    acceptableBlockSize,
                    blockSize,
                    absolutePosition,
                    arrayPool,
                    maxArrayPoolRentalSize: default,
                    async,
                    cancellationToken).ConfigureAwait(false);
                read = partition.Length;
                absolutePosition += read;

                // If we read anything, turn it into a StreamPartition and
                // return it for staging
                if (partition.Length != 0)
                {
                    // The StreamParitition is disposable and it'll be the
                    // user's responsibility to return the bytes used to our
                    // ArrayPool
                    yield return partition;
                }

            // Continue reading blocks until we've exhausted the stream
            } while (read != 0);
        }
    }
}
