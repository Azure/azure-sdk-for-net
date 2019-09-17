// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Storage.Common;

namespace Azure.Storage
{
    /// <summary>
    /// Helper to download content in parallel by range, and recombine the partitions in order.
    /// </summary>
    internal static class PartitionedDownloader
    {
        /// <summary>
        /// Download a <see cref="Stream"/> in partitions.
        /// </summary>
        /// <typeparam name="T">
        /// Response type when downloading the entire stream.
        /// </typeparam>
        /// <typeparam name="P">
        /// Response type when downloading a single partition.
        /// </typeparam>
        /// <typeparam name="TProperties">
        /// Response type when fetching properties.
        /// </typeparam>
        /// <param name="destinationStream">
        /// The stream to write content into.
        /// </param>
        /// <param name="downloadStreamAsync">
        /// Returns a Task that will download the entire stream (given the stream,
        /// whether to execute it async, and a cancellation token).
        /// </param>
        /// <param name="getPropertiesAsync"></param>
        /// <param name="getEtag">
        /// Accepts properties and returns the content ETag.
        /// </param>
        /// <param name="getLength">
        /// Accepts properties and return the content length.
        /// </param>
        /// <param name="downloadPartitionAsync">
        /// Returns a Task that will download a single partition of a stream (given the
        /// partition's stream, sequence number, whether to execute it
        /// async, and a cancellation token).
        /// </param>
        /// <param name="writePartitionAsync">
        /// Returns a Task that writes the content stream into the destination stream (given the
        /// download response return by <paramref name="downloadPartitionAsync"/> and 
        /// <paramref name="destinationStream"/>).
        /// </param>
        /// <param name="singleDownloadThreshold">
        /// The maximum size of the stream to allow using
        /// <paramref name="downloadStreamAsync"/>.
        /// </param>
        /// <param name="parallelTransferOptions">
        /// Optional <see cref="ParallelTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="async">
        /// Whether to perform the download asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public static async Task<Response<TProperties>> DownloadAsync<T, P, TProperties>(
            Stream destinationStream,
            Func<bool, CancellationToken, Task<Response<TProperties>>> getPropertiesAsync,
            Func<TProperties, ETag> getEtag,
            Func<TProperties, long> getLength,
            Func<bool, CancellationToken, Task<Response<T>>> downloadStreamAsync,
            Func<ETag, HttpRange, bool, CancellationToken, Task<Response<P>>> downloadPartitionAsync,
            Func<Response<P>, Stream, bool, CancellationToken, Task> writePartitionAsync,
            long singleDownloadThreshold,
            ParallelTransferOptions? parallelTransferOptions = default,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            var properties =
                async
                ? await getPropertiesAsync(async, cancellationToken).ConfigureAwait(false)
                : getPropertiesAsync(async, cancellationToken).EnsureCompleted();

            var etag = getEtag(properties);
            var length = getLength(properties);

            // if zero length is reported, there's nothing to write
            if (length == 0)
            {
                return properties;
            }

            // TODO Checksum range size validation can happen here

            singleDownloadThreshold = Math.Min(singleDownloadThreshold, Constants.Blob.Block.MaxDownloadBytes);

            // wrap the destination stream with a stream that will time out if time passes without a read/write
            // TODO Wrap this in a crypto stream for decryption
            using (destinationStream = new IdleCancellingStream(destinationStream, Constants.MaxIdleTimeMs))
            {
                if (length <= singleDownloadThreshold)
                {
                    // When possible, download as a single partition

                    var downloadTask = downloadStreamAsync(async, cancellationToken);

                    if (async)
                    {
                        var response = await downloadTask.ConfigureAwait(false);
                    }
                    else
                    {
                        var response = downloadTask.EnsureCompleted();
                    }

                    return properties;
                }
                else
                {
                    // Split the source content into ranges and download by range

                    parallelTransferOptions ??= new ParallelTransferOptions();

                    var maximumThreadCount =
                        parallelTransferOptions.Value.MaximumThreadCount ?? Constants.Blob.Block.DefaultConcurrentTransfersCount;
                    var maximumPartitionLength =
                        Math.Min(
                            Constants.Blob.Block.MaxDownloadBytes,
                            parallelTransferOptions.Value.MaximumTransferLength ?? Constants.DefaultBufferSize
                            );

                    var maximumActivePartitionCount = maximumThreadCount;
                    var maximumLoadedPartitionCount = 2 * maximumThreadCount;

                    var ranges = GetRanges(length, maximumPartitionLength);

                    var downloadTask =
                        DownloadRangesImplAsync(
                        destinationStream,
                            etag,
                            ranges,
                            downloadPartitionAsync,
                            writePartitionAsync,
                            maximumActivePartitionCount,
                            maximumLoadedPartitionCount,
                            async,
                            cancellationToken);

                    if (async)
                    {
                        await downloadTask.ConfigureAwait(false);
                    }
                    else
                    {
                        downloadTask.EnsureCompleted();
                    }
                }
            }

            return properties;
        }

        /// <summary>
        /// Given <paramref name="ranges"/>, download content and write it to <paramref name="destinationStream"/>.
        /// </summary>
        /// <typeparam name="P">
        /// Response type when downloading a single partition.
        /// </typeparam>
        /// <param name="destinationStream">
        /// The stream to write content into.
        /// </param>
        /// <param name="etag">
        /// The ETag of the content, for concurrency detection.
        /// </param>
        /// <param name="ranges">
        /// The ordered set of ranges to download.
        /// </param>
        /// <param name="downloadPartitionAsync">
        /// Returns a Task that will download a single partition of a stream (given the
        /// partition's stream, sequence number, whether to execute it
        /// async, and a cancellation token).
        /// </param>
        /// <param name="writePartitionAsync">
        /// Returns a Task that writes the content stream into the destination stream (given the
        /// download response return by <paramref name="downloadPartitionAsync"/> and 
        /// <paramref name="destinationStream"/>).
        /// </param>
        /// <param name="maximumActivePartitionCount">
        /// The maximum number of partitions to download in parallel.
        /// </param>
        /// <param name="maximumLoadedPartitionCount">
        /// The maximum number of partitions to retain in memory.
        /// </param>
        /// <param name="async">
        /// Whether to perform the download asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// This method assumes that individual downloads are automatically retried.
        /// </remarks>
        static async Task DownloadRangesImplAsync<P>(
            Stream destinationStream,
            ETag etag,
            IEnumerable<HttpRange> ranges,
            Func<ETag, HttpRange, bool, CancellationToken, Task<Response<P>>> downloadPartitionAsync,
            Func<Response<P>, Stream, bool, CancellationToken, Task> writePartitionAsync,
            int maximumActivePartitionCount,
            int maximumLoadedPartitionCount,
            bool async,
            CancellationToken cancellationToken)
        {
            // Use a queue to accumulate download tasks and return them in FIFO order.
            // Not using a ConcurrentQueue, since we aren't going to write using multiple threads here.

            // Based on prior research, we are better off just downloading the ranges, and writing them in order:
            // - Required for a non-seekable destination stream;
            // - Better performance than a MemoryMappedViewStream, because the file system won't have to zero out
            //   spans skipped during random writes;
            // - Not necessarily as performant as an in-memory seekable stream, but memory streams probably aren't in the
            //   size range where parallel download is really going to be useful anyway.
            //
            // We will still download in parallel, but limit ourselves to a maximum number of responses retained in memory, 
            // and only await the head of the queue.

            var activeTaskQueue = new Queue<Task<Response<P>>>();
            var loadedResponseQueue = new Queue<Response<P>>();

            var rangesEnumerator = ranges.GetEnumerator();

            while (true)
            {
                // Keep the queues filled.  We could be more interesting with background threads and various semaphores or locks,
                // but this should be good-enough for the download case, given the ordering restriction.

                while (activeTaskQueue.Any() && activeTaskQueue.Peek().Status != TaskStatus.Running)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var responseTask = activeTaskQueue.Dequeue();

                    var response =
                        async
                        ? await responseTask.ConfigureAwait(false)
                        : responseTask.EnsureCompleted();

                    loadedResponseQueue.Enqueue(response);
                }

                while (
                    activeTaskQueue.Count < maximumActivePartitionCount
                    && (activeTaskQueue.Count + loadedResponseQueue.Count < maximumLoadedPartitionCount)
                    )
                {
                    if (!rangesEnumerator.MoveNext())
                    {
                        break;
                    }

                    var currentRange = rangesEnumerator.Current;

                    cancellationToken.ThrowIfCancellationRequested();

                    var newTask = Task.Factory.StartNew(
                        async () => await downloadPartitionAsync(etag, currentRange, async, cancellationToken).ConfigureAwait(false),
                        cancellationToken,
                        TaskCreationOptions.None,
                        TaskScheduler.Default
                        );

                    activeTaskQueue.Enqueue(newTask.Unwrap());
                }

                if (loadedResponseQueue.Any())
                {
                    // await the completion of the head task, then write it to the destination

                    cancellationToken.ThrowIfCancellationRequested();

                    var response = loadedResponseQueue.Dequeue();

                    var writePartitionTask = writePartitionAsync(response, destinationStream, async, cancellationToken);

                    if (async)
                    {
                        await writePartitionTask.ConfigureAwait(false);
                    }
                    else
                    {
                        writePartitionTask.EnsureCompleted();
                    }

                    response.GetRawResponse().Dispose();
                }
                else if (!activeTaskQueue.Any())
                {
                    // all downloads are completed

                    break;
                }
            }
        }

        /// <summary>
        /// Returns a sequence of contiguous HttpRange starting at offset 0,
        /// ending at offset <paramref name="length"/> - 1, each of maximum
        /// length <paramref name="maximumPartitionLength"/>.
        /// </summary>
        /// <param name="length">Length of the content to be partitioned.</param>
        /// <param name="maximumPartitionLength">Maximum number of bytes in each partition.</param>
        /// <returns></returns>
        static IEnumerable<HttpRange> GetRanges(long length, long maximumPartitionLength)
        {
            for (var i = 0L; i < length; i += maximumPartitionLength)
            {
                yield return new HttpRange(i, Math.Min(length - i, maximumPartitionLength));
            }
        }
    }
}
