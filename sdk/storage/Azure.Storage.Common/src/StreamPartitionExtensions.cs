// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Common
{
    /// <summary>
    /// Given a source of StreamPartitions, optionally collate them.
    /// </summary>
    internal static class StreamPartitionExtensions
    {
        public static async Task CopyToAsync(
            this IAsyncEnumerable<StreamPartition> partitions,
            Stream destination,
            bool async,
            CancellationToken cancellationToken)
        {
            var destinationOffset = destination.Position;

            await foreach (StreamPartition partition in partitions)
            {
                if (async)
                {
                    await copyImpl(partition).ConfigureAwait(false);
                }
                else
                {
                    copyImpl(partition).EnsureCompleted();
                }
            }

            async Task copyImpl(StreamPartition partition)
            {
                // if the destination is seekable, ensure we position it correctly,
                // else we trust the partitions are received in order and just write
                // blindly

                if (destination.CanSeek)
                {
                    destination.Position = partition.ParentPosition;
                }
                else
                {
                    Debug.Assert(
                        partition.ParentPosition == destination.Position - destinationOffset,
                        "Stream partitions received out of order for a non-seekable stream."
                        );
                }

                if (async)
                {
                    await
                        partition
                        .CopyToAsync(destination, Constants.DefaultBufferSize, cancellationToken)
                        .ConfigureAwait(false)
                        ;
                }
                else
                {
                    partition.CopyTo(destination, Constants.DefaultBufferSize);
                }

                partition.Dispose();
            }
        }

        public static Task CopyToAsync(
            this IAsyncEnumerable<StreamPartition> partitions,
            FileInfo destination,
            bool async,
            CancellationToken cancellationToken)
            => partitions.CopyToAsync(destination.OpenWrite(), async, cancellationToken);
    }
}
