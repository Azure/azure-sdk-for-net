// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Shared;

namespace Azure.Storage
{
    internal class PartitionedUploader<TServiceSpecificArgs, TCompleteUploadReturn>
    {
        #region Definitions
        // delegte for getting a partition from a stream based on the selected data management stragegy
        private delegate Task<StreamSlice> GetNextStreamPartition(
            Stream stream,
            long minCount,
            long maxCount,
            long absolutePosition,
            bool async,
            CancellationToken cancellationToken);

        // injected behaviors for services to use partitioned uploads
        public delegate DiagnosticScope CreateScope(string operationName);
        public delegate Task InitializeDestinationInternal(TServiceSpecificArgs args, bool async, CancellationToken cancellationToken);
        public delegate Task<Response<TCompleteUploadReturn>> SingleUploadInternal(
            Stream contentStream,
            TServiceSpecificArgs args,
            IProgress<long> progressHandler,
            string operationName,
            bool async,
            CancellationToken cancellationToken);
        public delegate Task UploadPartitionInternal(Stream contentStream,
            long offset,
            TServiceSpecificArgs args,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken);
        public delegate Task<Response<TCompleteUploadReturn>> CommitPartitionedUploadInternal(
            List<(long Offset, long Size)> partitions,
            TServiceSpecificArgs args,
            bool async,
            CancellationToken cancellationToken);

        public struct Behaviors
        {
            public InitializeDestinationInternal InitializeDestination { get; set; }
            public SingleUploadInternal SingleUpload { get; set; }
            public UploadPartitionInternal UploadPartition { get; set; }
            public CommitPartitionedUploadInternal CommitPartitionedUpload { get; set; }
            public CreateScope Scope { get; set; }
        }

        public static readonly InitializeDestinationInternal InitializeNoOp = (args, async, cancellationToken) => Task.CompletedTask;
        #endregion

        private readonly InitializeDestinationInternal _initializeDestinationInternal;
        private readonly SingleUploadInternal _singleUploadInternal;
        private readonly UploadPartitionInternal _uploadPartitionInternal;
        private readonly CommitPartitionedUploadInternal _commitPartitionedUploadInternal;
        private readonly CreateScope _createScope;

        /// <summary>
        /// The maximum number of simultaneous workers.
        /// </summary>
        private readonly int _maxWorkerCount;

        /// <summary>
        /// A pool of memory we use to partition the stream into blocks.
        /// </summary>
        private readonly ArrayPool<byte> _arrayPool;

        /// <summary>
        /// The size we use to determine whether to upload as a one-off request or
        /// a partitioned/committed upload
        /// </summary>
        private readonly long _singleUploadThreshold;

        /// <summary>
        /// The size of each staged block.  If null, we'll change between 4MB
        /// and 8MB depending on the size of the content.
        /// </summary>
        private readonly long? _blockSize;

        /// <summary>
        /// The name of the calling operaiton.
        /// </summary>
        private readonly string _operationName;

        public PartitionedUploader(
            Behaviors behaviors,
            StorageTransferOptions transferOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
        {
            // initialize isn't required for all services and can use a no-op; rest are required
            _initializeDestinationInternal = behaviors.InitializeDestination ?? InitializeNoOp;
            _singleUploadInternal = behaviors.SingleUpload
                ?? throw Errors.ArgumentNull(nameof(behaviors.SingleUpload));
            _uploadPartitionInternal = behaviors.UploadPartition
                ?? throw Errors.ArgumentNull(nameof(behaviors.UploadPartition));
            _commitPartitionedUploadInternal = behaviors.CommitPartitionedUpload
                ?? throw Errors.ArgumentNull(nameof(behaviors.CommitPartitionedUpload));
            _createScope = behaviors.Scope
                ?? throw Errors.ArgumentNull(nameof(behaviors.Scope));

            _arrayPool = arrayPool ?? ArrayPool<byte>.Shared;

            // Set _maxWorkerCount
            if (transferOptions.MaximumConcurrency.HasValue
                && transferOptions.MaximumConcurrency > 0)
            {
                _maxWorkerCount = transferOptions.MaximumConcurrency.Value;
            }
            else
            {
                _maxWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }

            // Set _singleUploadThreshold
            if (transferOptions.InitialTransferSize.HasValue
                && transferOptions.InitialTransferSize.Value > 0)
            {
                _singleUploadThreshold = Math.Min(transferOptions.InitialTransferSize.Value, Constants.Blob.Block.MaxUploadBytes);
            }
            else
            {
                _singleUploadThreshold = Constants.Blob.Block.MaxUploadBytes;
            }

            // Set _blockSize
            if (transferOptions.MaximumTransferSize.HasValue
                && transferOptions.MaximumTransferSize > 0)
            {
                _blockSize = Math.Min(
                    Constants.Blob.Block.MaxStageBytes,
                    transferOptions.MaximumTransferSize.Value);
            }

            _operationName = operationName;
        }

        public async Task<Response<TCompleteUploadReturn>> UploadInternal(
            Stream content,
            TServiceSpecificArgs args,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken = default)
        {
            if (content == default)
            {
                throw Errors.ArgumentNull(nameof(content));
            }

            await _initializeDestinationInternal(args, async, cancellationToken).ConfigureAwait(false);

            // some strategies are unavailable if we don't know the stream length, and some can still work
            // we may introduce separately provided stream lengths in the future for unseekable streams with
            // an expected length
            long? length = GetLengthOrDefault(content);

            // If we know the length and it's small enough
            if (length < _singleUploadThreshold)
            {
                // Upload it in a single request
                return await _singleUploadInternal(
                    content,
                    args,
                    progressHandler,
                    _operationName,
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);
            }

            // If the caller provided an explicit block size, we'll use it.
            // Otherwise we'll adjust dynamically based on the size of the
            // content.
            long blockSize = _blockSize != null
                ? _blockSize.Value
                : length < Constants.LargeUploadThreshold ?
                    Constants.DefaultBufferSize :
                    Constants.LargeBufferSize;

            // Otherwise stage individual blocks

            /* We only support parallel upload in an async context to avoid issues in our overall sync story.
             * We're branching on both async and max worker count, where 3 combinations lead to
             * UploadInSequenceInternal and 1 combination leads to UploadInParallelAsync. We are guaranteed
             * to be in an async context when we call UploadInParallelAsync, even though the analyzer can't
             * detext this, and we properly pass in the async context in the else case when we haven't
             * explicitly checked.
             */
#pragma warning disable AZC0109 // Misuse of 'async' parameter.
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            if (async && _maxWorkerCount > 1)
            {
                return await UploadInParallelAsync(
                    content,
                    length,
                    blockSize,
                    args,
                    progressHandler,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
#pragma warning restore AZC0109 // Misuse of 'async' parameter.
            else
            {
                return await UploadInSequenceInternal(
                    content,
                    length,
                    blockSize,
                    args,
                    progressHandler,
                    async: async,
                    cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task<Response<TCompleteUploadReturn>> UploadInSequenceInternal(
            Stream content,
            long? contentLength,
            long partitionSize,
            TServiceSpecificArgs args,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            // Wrap the staging and commit calls in an Upload span for
            // distributed tracing
            DiagnosticScope scope = _createScope(_operationName);
            try
            {
                scope.Start();

                // Wrap progressHandler in a AggregatingProgressIncrementer to prevent
                // progress from being reset with each stage blob operation.
                if (progressHandler != null)
                {
                    progressHandler = new AggregatingProgressIncrementer(progressHandler);
                }

                // The list tracking blocks IDs we're going to commit
                List<(long Offset, long Size)> partitions = new List<(long, long)>();

                /* Streamed partitions only work if we can seek the stream; we need retries on
                 * individual uploads.
                 */
                GetNextStreamPartition partitionGetter = content.CanSeek
                            ? (GetNextStreamPartition)GetStreamedPartitionInternal
                            : /*   redundant cast   */GetBufferedPartitionInternal;

                // Partition the stream into individual blocks and stage them
                if (async)
                {
                    await foreach (StreamSlice block in GetPartitionsAsync(
                        content,
                        contentLength,
                        partitionSize,
                        partitionGetter,
                        async: true,
                        cancellationToken).ConfigureAwait(false))
                    {
                        await StagePartitionAndDisposeInternal(
                            block,
                            block.AbsolutePosition,
                            args,
                            progressHandler,
                            async: true,
                            cancellationToken).ConfigureAwait(false);

                        partitions.Add((block.AbsolutePosition, block.Length));
                    }
                }
                else
                {
                    foreach (StreamSlice block in GetPartitionsAsync(
                        content,
                        contentLength,
                        partitionSize,
                        partitionGetter,
                        async: false,
                        cancellationToken).EnsureSyncEnumerable())
                    {
                        StagePartitionAndDisposeInternal(
                            block,
                            block.AbsolutePosition,
                            args,
                            progressHandler,
                            async: false,
                            cancellationToken).EnsureCompleted();

                        partitions.Add((block.AbsolutePosition, block.Length));
                    }
                }

                // Commit the block list after everything has been staged to
                // complete the upload
                return await _commitPartitionedUploadInternal(
                    partitions,
                    args,
                    async,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        private async Task<Response<TCompleteUploadReturn>> UploadInParallelAsync(
            Stream content,
            long? contentLength,
            long blockSize,
            TServiceSpecificArgs args,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            // Wrap the staging and commit calls in an Upload span for
            // distributed tracing
            DiagnosticScope scope = _createScope(_operationName);
            try
            {
                scope.Start();

                // Wrap progressHandler in a AggregatingProgressIncrementer to prevent
                // progress from being reset with each stage blob operation.
                if (progressHandler != null)
                {
                    progressHandler = new AggregatingProgressIncrementer(progressHandler);
                }

                // The list tracking blocks IDs we're going to commit
                List<(long Offset, long Size)> partitions = new List<(long, long)>();

                // A list of tasks that are currently executing which will
                // always be smaller than _maxWorkerCount
                List<Task> runningTasks = new List<Task>();

                // Partition the stream into individual blocks
                await foreach (StreamSlice block in GetPartitionsAsync(
                    content,
                    contentLength,
                    blockSize,
                    GetBufferedPartitionInternal, // we always buffer for upload in parallel from stream
                    async: true,
                    cancellationToken).ConfigureAwait(false))
                {
                    // Start staging the next block (but don't await the Task!)
                    Task task = StagePartitionAndDisposeInternal(
                        block,
                        block.AbsolutePosition,
                        args,
                        progressHandler,
                        async: true,
                        cancellationToken);

                    // Add the block to our task and commit lists
                    runningTasks.Add(task);
                    partitions.Add((block.AbsolutePosition, block.Length));

                    // If we run out of workers
                    if (runningTasks.Count >= _maxWorkerCount)
                    {
                        // Wait for at least one of them to finish
                        await Task.WhenAny(runningTasks).ConfigureAwait(false);

                        // Clear any completed blocks from the task list
                        for (int i = 0; i < runningTasks.Count; i++)
                        {
                            Task runningTask = runningTasks[i];
                            if (!runningTask.IsCompleted)
                            {
                                continue;
                            }

                            await runningTask.ConfigureAwait(false);
                            runningTasks.RemoveAt(i);
                            i--;
                        }
                    }
                }

                // Wait for all the remaining blocks to finish staging and then
                // commit the block list to complete the upload
                await Task.WhenAll(runningTasks).ConfigureAwait(false);

                // Calling internal method for easier mocking in PartitionedUploaderTests
                return await _commitPartitionedUploadInternal(
                    partitions,
                    args,
                    async: true,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        /// <summary>
        /// Wraps both the async method and dispose call in one task.
        /// </summary>
        private async Task StagePartitionAndDisposeInternal(
            StreamSlice partition,
            long offset,
            TServiceSpecificArgs args,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            try
            {
                await _uploadPartitionInternal(
                    partition,
                    offset,
                    args,
                    progressHandler,
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            finally
            {
                // Return the memory used by the block to our ArrayPool as soon
                // as we've staged it
                partition.Dispose();
            }
        }

        /// <summary>
        /// Some streams will throw if you try to access their length so we wrap
        /// the check in a TryGet helper.
        /// </summary>
        private static long? GetLengthOrDefault(Stream content)
        {
            try
            {
                if (content.CanSeek)
                {
                    return content.Length;
                }
            }
            catch (NotSupportedException)
            {
            }
            return default;
        }

        #region Stream Splitters
        /// <summary>
        /// Partition a stream into a series of blocks buffered as needed by an array pool.
        /// </summary>
        private static async IAsyncEnumerable<StreamSlice> GetPartitionsAsync(
            Stream stream,
            long? streamLength,
            long blockSize,
            GetNextStreamPartition getNextPartition,
            bool async,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            // The minimum amount of data we'll accept from a stream before
            // splitting another block. Code that sets `blockSize` will always
            // set it to a positive number. Min() only avoids edge case where
            // user sets their block size to 1.
            long acceptableBlockSize = Math.Max(1, blockSize / 2);

            // if we know the data length, assert boundaries before spending resources uploading beyond service capabilities
            if (streamLength.HasValue)
            {
                // service has a max block count per blob
                // block size * block count limit = max data length to upload
                // if stream length is longer than specified max block size allows, can't upload
                long minRequiredBlockSize = (long)Math.Ceiling((double)streamLength.Value / Constants.Blob.Block.MaxBlocks);
                if (blockSize < minRequiredBlockSize)
                {
                    throw Errors.InsufficientStorageTransferOptions(streamLength.Value, blockSize, minRequiredBlockSize);
                }
                // bring min up to our min required by the service
                acceptableBlockSize = Math.Max(acceptableBlockSize, minRequiredBlockSize);
            }

            long read;
            long absolutePosition = 0;
            do
            {
                StreamSlice partition = await getNextPartition(
                    stream,
                    acceptableBlockSize,
                    blockSize,
                    absolutePosition,
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

        /// <summary>
        /// Gets a partition from the current location of the given stream.
        ///
        /// This partition is buffered and it is safe to get many before using any of them.
        /// </summary>
        /// <param name="stream">
        /// Stream to buffer a partition from.
        /// </param>
        /// <param name="minCount">
        /// Minimum amount of data to wait on before finalizing buffer.
        /// </param>
        /// <param name="maxCount">
        /// Max amount of data to buffer before cutting off for the next.
        /// </param>
        /// <param name="absolutePosition">
        /// Offset of this stream relative to the large stream.
        /// </param>
        /// <param name="async">
        /// Whether to buffer this partition asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Task containing the buffered stream partition.
        /// </returns>
        private async Task<StreamSlice> GetBufferedPartitionInternal(
            Stream stream,
            long minCount,
            long maxCount,
            long absolutePosition,
            bool async,
            CancellationToken cancellationToken)
            => await PooledMemoryStream.BufferStreamPartitionInternal(
                stream,
                minCount,
                maxCount,
                absolutePosition,
                _arrayPool,
                maxArrayPoolRentalSize: default,
                async,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets a partition from the current location of the given stream.
        ///
        /// This partition is a facade over the existing stream, and the
        /// previous partition should be consumed before using the next.
        /// </summary>
        /// <param name="stream">
        /// Stream to wrap.
        /// </param>
        /// <param name="minCount">
        /// Unused, but part of <see cref="GetNextStreamPartition"/> definition.
        /// </param>
        /// <param name="maxCount">
        /// Length of this facade stream.
        /// </param>
        /// <param name="absolutePosition">
        /// Offset of this stream relative to the large stream.
        /// </param>
        /// <param name="async">
        /// Unused, but part of <see cref="GetNextStreamPartition"/> definition.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Task containing the stream facade.
        /// </returns>
        private static Task<StreamSlice> GetStreamedPartitionInternal(
            Stream stream,
            long minCount,
            long maxCount,
            long absolutePosition,
            bool async,
            CancellationToken cancellationToken)
            => Task.FromResult((StreamSlice)WindowStream.GetWindow(stream, maxCount, absolutePosition));
        #endregion
    }
}
