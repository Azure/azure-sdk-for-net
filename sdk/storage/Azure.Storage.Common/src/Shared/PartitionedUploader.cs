// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Shared;

namespace Azure.Storage
{
    internal class PartitionedUploader<TServiceSpecificArgs, TCompleteUploadReturn>
    {
        #region Definitions
        public delegate DiagnosticScope CreateScope(string operationName);
        public delegate Task InitializeDestinationInternal(TServiceSpecificArgs args, bool async, CancellationToken cancellationToken);
        public delegate Task<Response<TCompleteUploadReturn>> SingleUploadInternal(Stream contentStream, TServiceSpecificArgs args, IProgress<long> progressHandler, string operationName, bool async, CancellationToken cancellationToken);
        public delegate Task UploadPartitionInternal(Stream contentStream, long offset, TServiceSpecificArgs args, IProgress<long> progressHandler, bool async, CancellationToken cancellationToken);
        public delegate Task<Response<TCompleteUploadReturn>> CommitPartitionedUploadInternal(List<(long Offset, long Size)> partitions, TServiceSpecificArgs args, bool async, CancellationToken cancellationToken);

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
            if (transferOptions.InitialTransferLength.HasValue
                && transferOptions.InitialTransferLength.Value > 0)
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
            await _initializeDestinationInternal(args, async, cancellationToken).ConfigureAwait(false);

            // If we can compute the size and it's small enough
            if (PartitionedUploadExtensions.TryGetLength(content, out long length) && length < _singleUploadThreshold)
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
            long blockSize =
                _blockSize != null ? _blockSize.Value :
                length < Constants.LargeUploadThreshold ?
                    Constants.DefaultBufferSize :
                    Constants.LargeBufferSize;

            // Otherwise stage individual blocks
            // TODO UploadInParallelAsync is a buffered upload. Introduce optimizations to avoid this buffer strategy when not needed.
            if (async)
            {
                return await UploadInParallelAsync(
                    content,
                    blockSize,
                    args,
                    progressHandler,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                return UploadInSequenceInternal(
                    content,
                    blockSize,
                    args,
                    progressHandler,
                    async: false,
                    cancellationToken).EnsureCompleted();
            }
        }

        private async Task<Response<TCompleteUploadReturn>> UploadInSequenceInternal(
            Stream content,
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

                // Partition the stream into individual blocks and stage them
                if (async)
                {
                    await foreach (PooledMemoryStream block in PartitionedUploadExtensions.GetBufferedBlocksAsync(
                            content, partitionSize, async: true, _arrayPool, cancellationToken).ConfigureAwait(false))
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
                    foreach (PooledMemoryStream block in PartitionedUploadExtensions.GetBufferedBlocksAsync(
                            content, partitionSize, async: false, _arrayPool, cancellationToken).EnsureSyncEnumerable())
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
                await foreach (PooledMemoryStream block in PartitionedUploadExtensions.GetBufferedBlocksAsync(
                    content,
                    blockSize,
                    async: true,
                    _arrayPool,
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
            PooledMemoryStream partition,
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
    }
}
