// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage
{
    /// <summary>
    /// Helper to upload a <see cref="Stream"/> in partitions.
    /// </summary>
    internal static class PartitionedUploader
    {
        /// <summary>
        /// Upload a <see cref="Stream"/> in partitions.
        /// </summary>
        /// <typeparam name="T">
        /// Response type when uploading the entire stream or commiting a
        /// sequence of partitions.
        /// </typeparam>
        /// <typeparam name="P">
        /// Response type when uploading a single partition.
        /// </typeparam>
        /// <param name="uploadStreamAsync">
        /// Returns a Task that will upload the entire stream (given the stream,
        /// whether to execute it async, and a cancellation token).
        /// </param>
        /// <param name="uploadPartitionAsync">
        /// Returns a Task that will upload a single partition of a stream (given the
        /// partition's stream, sequence number, whether to execute it
        /// async, and a cancellation token).
        /// </param>
        /// <param name="commitAsync">
        /// Returns a task that will commit a series of partition uploads (given
        /// whether to execute it async and a cancellation token).
        /// </param>
        /// <param name="uploadAsSinglePartition">
        /// Returns a bool indicating whether to upload the content as a single partition, instead of multiple.
        /// </param>
        /// <param name="getStreamPartitioner">
        /// Returns a StreamPartitioner for the content.
        /// </param>
        /// <param name="singleUploadThreshold">
        /// The maximum size of the stream to allow using
        /// <paramref name="uploadStreamAsync"/>.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="async">
        /// Whether to perform the upload asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// This method assumes that individual uploads are automatically retried.
        /// </remarks>
        public static async Task<Response<T>> UploadAsync<T, P>(
            Func<Task<Response<T>>> uploadStreamAsync,
            Func<Stream, long, bool, CancellationToken, Task<Response<P>>> uploadPartitionAsync,
            Func<bool, CancellationToken, Task<Response<T>>> commitAsync,
            Func<long, bool> uploadAsSinglePartition,
            Func<MemoryPool<byte>, StreamPartitioner> getStreamPartitioner,
            long singleUploadThreshold,
            ParallelTransferOptions? parallelTransferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            singleUploadThreshold = Math.Min(singleUploadThreshold, Constants.Blob.Block.MaxUploadBytes);

            if (uploadAsSinglePartition(singleUploadThreshold))
            {
                // When possible, upload as a single partition
                Task<Response<T>> uploadTask = uploadStreamAsync();
                return async ?
                    await uploadTask.ConfigureAwait(false) :
                    uploadTask.EnsureCompleted();
            }
            else
            {
                // Split the stream into partitions and upload in parallel

                parallelTransferOptions ??= new ParallelTransferOptions();

                var maximumThreadCount =
                    parallelTransferOptions.Value.MaximumThreadCount ?? Constants.Blob.Block.DefaultConcurrentTransfersCount;
                var maximumBlockLength =
                    Math.Min(
                        Constants.Blob.Block.MaxStageBytes,
                        parallelTransferOptions.Value.MaximumTransferLength ?? Constants.DefaultBufferSize
                        );

                var maximumActivePartitionCount = maximumThreadCount;
                var maximumLoadedPartitionCount = 2 * maximumThreadCount;

                var memoryPool = default(MemoryPool<byte>);

                try
                {
                    // Use the shared memory pool if our maximum block length will fit inside it

                    memoryPool =
                    (maximumBlockLength < MemoryPool<byte>.Shared.MaxBufferSize)
                    ? MemoryPool<byte>.Shared
                    : new StorageMemoryPool(maximumBlockLength, maximumLoadedPartitionCount);

                    using (StreamPartitioner partitioner = getStreamPartitioner(memoryPool))
                    {
                        await foreach (
                            StreamPartition partition
                            in partitioner.GetPartitionsAsync(
                                maximumActivePartitionCount,
                                maximumLoadedPartitionCount,
                                maximumBlockLength,
                                async,
                                cancellationToken
                                )
                            )
                        {
                            // execute on background task

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                            Task.Run(
                                async () =>
                                {
                                    //Console.WriteLine($"Partition {partition.ParentPosition} first bytes = {partition.ReadByte()} {partition.ReadByte()} {partition.ReadByte()} {partition.ReadByte()} {partition.ReadByte()} {partition.ReadByte()} {partition.ReadByte()} {partition.ReadByte()}");
                                    partition.Seek(0, SeekOrigin.Begin);
                                    await uploadPartitionAsync(partition, partition.ParentPosition, async, cancellationToken).ConfigureAwait(false);
                                    partition.Dispose();
                                }
                                );
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                        }
                    }

                    // Complete the upload
                    Task<Response<T>> commitTask = commitAsync(async, cancellationToken);
                    return async ?
                        await commitTask.ConfigureAwait(false) :
                        commitTask.EnsureCompleted();
                }
                finally
                {
                    if (memoryPool is StorageMemoryPool)
                    {
                        memoryPool.Dispose();
                    }
                }
            }
        }
    }
}
