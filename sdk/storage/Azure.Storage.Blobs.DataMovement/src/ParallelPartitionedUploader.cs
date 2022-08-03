// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.DataMovement;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blob.Experiemental
{
    internal class ParallelPartitionedUploader<TServiceSpecificData, TCompleteUploadReturn>
    {
        #region Definitions
        // delegte for getting a partition from a stream based on the selected data management stragegy
        private delegate Task<SlicedStream> GetNextStreamPartition(
            Stream stream,
            long minCount,
            long maxCount,
            long absolutePosition,
            bool async,
            CancellationToken cancellationToken);

        // injected behaviors for services to use partitioned uploads
        public delegate DiagnosticScope CreateScope(string operationName);
        public delegate Task InitializeDestinationInternal(TServiceSpecificData args, bool async, CancellationToken cancellationToken);
        public delegate Task<Response<TCompleteUploadReturn>> SingleUploadInternal(
            string filePath,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            // TODO #27253
            //UploadTransactionalHashingOptions hashingOptions,
            string operationName,
            bool async,
            CancellationToken cancellationToken);
        public delegate Task UploadPartitionInternal(Stream contentStream,
            long offset,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            // TODO #27253
            //UploadTransactionalHashingOptions hashingOptions,
            bool async,
            CancellationToken cancellationToken);
        public delegate Task<Response<TCompleteUploadReturn>> CommitPartitionedUploadInternal(
            List<(long Offset, long Size)> partitions,
            TServiceSpecificData args,
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

        ///// <summary>
        ///// Hashing options to use for paritioned upload calls.
        ///// </summary>
        // TODO #27253
        //private readonly UploadTransactionalHashingOptions _hashingOptions;

        /// <summary>
        /// The name of the calling operaiton.
        /// </summary>
        private readonly string _operationName;

        /// <summary>
        /// The name of the filePath being transferred.
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Length of the File
        /// </summary>
        private readonly long _fileLength;

        /// <summary>
        /// Length of the file.
        /// </summary>
        public long FileLength => _fileLength;

        /// <summary>
        /// Commit Ranges gathered from staging blocks
        /// </summary>
        private ConcurrentBag<(long Offset, long Size)> _blockList;

        public ParallelPartitionedUploader(
            string filePath,
            Behaviors behaviors,
            StorageTransferOptions transferOptions,
            //UploadTransactionalHashingOptions hashingOptions,
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
                _singleUploadThreshold = Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes;
            }

            // Set _blockSize
            if (transferOptions.MaximumTransferSize.HasValue
                && transferOptions.MaximumTransferSize > 0)
            {
                _blockSize = Math.Min(
                    Constants.Blob.Block.MaxStageBytes,
                    transferOptions.MaximumTransferSize.Value);
            }

            // TODO #27253
            //_hashingOptions = hashingOptions;
            // partitioned uploads don't support pre-calculated hashes
            //if (_hashingOptions?.PrecalculatedHash != default)
            //{
            //    throw Errors.PrecalculatedHashNotSupportedOnSplit();
            //}

            _operationName = operationName;

            if (string.IsNullOrEmpty(filePath))
            {
                throw Errors.ArgumentNull(nameof(filePath));
            }
            _filePath = filePath;
            FileInfo fileInfo = new FileInfo(filePath);
            _fileLength = fileInfo.Length;
        }

        public bool IsPutBlockRequest() => _fileLength < _singleUploadThreshold;

        /*
        public IEnumerable<Task> Upload(
            Stream content,
            long? expectedContentLength,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken = default)
        => UploadInternal(
            content,
            expectedContentLength,
            args,
            progressHandler,
            false,
            cancellationToken).EnsureCompleted();

        public async IAsyncEnumerable<Task> UploadAsync(
            Stream content,
            long? expectedContentLength,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken = default)
        => return UploadInternal(
            content,
            expectedContentLength,
            args,
            progressHandler,
            true,
            cancellationToken);
        */

        public async Task UploadInternal(
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken = default)
        {
            if (_initializeDestinationInternal != InitializeNoOp)
            {
                await _initializeDestinationInternal(args, true, cancellationToken).ConfigureAwait(false);
            }

            // If we know the length and it's small enough
            if (IsPutBlockRequest())
            {
                // Upload it in a single request
                await _singleUploadInternal(
                            _filePath,
                            args,
                            progressHandler,
                            // TODO #27253
                            //_hashingOptions,
                            _operationName,
                            async: true,
                            cancellationToken).ConfigureAwait(false);
                // default on empty bag
                _blockList = default;
            }
            else
            {
                // If the caller provided an explicit block size, we'll use it.
                // Otherwise we'll adjust dynamically based on the size of the
                // content.
                long blockSize = _blockSize != null
                    ? _blockSize.Value
                    : _fileLength < Constants.LargeUploadThreshold ?
                        Constants.DefaultBufferSize :
                        Constants.LargeBufferSize;

                // Otherwise stage individual blocks
                _blockList = await CreateStageBlocks(
                    blockSize,
                    args,
                    progressHandler,
                    true,
                    cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task<ConcurrentBag<(long Offset, long Size)>> CreateStageBlocks(
            long blockSize,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            // Wrap the staging and commit calls in an Upload span for
            // distributed tracing
            DiagnosticScope scope = _createScope(_operationName);
            scope.Start();

            // Wrap progressHandler in a AggregatingProgressIncrementer to prevent
            // progress from being reset with each stage blob operation.
            if (progressHandler != null)
            {
                progressHandler = new AggregatingProgressIncrementer(progressHandler);
            }

            // The list tracking blocks IDs we're going to commit
            ConcurrentBag<(long Offset, long Size)> partitions = new ConcurrentBag<(long, long)>();

            // A list of tasks that are currently executing which will
            // always be smaller than _maxWorkerCount
            ConcurrentBag<Func<Task>> runningTasks = new ConcurrentBag<Func<Task>>();

            // Partition the stream into individual blocks
            using (FileStream stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                await foreach (SlicedStream block in GetPartitionsAsync(
                stream,
                _fileLength,
                blockSize,
                GetBufferedPartitionInternal, // we always buffer for upload in parallel from stream
                async: async,
                cancellationToken).ConfigureAwait(false))
                {
                    /* We need to do this first! Length is calculated on the fly based on stream buffer
                        * contents; We need to record the partition data first before consuming the stream
                        * asynchronously. */
                    partitions.Add((block.AbsolutePosition, block.Length));

                    // Start staging the next block (but don't await the Task!)
                    Func<Task> func = async () =>
                    {
                        await StagePartitionAndDisposeInternal(
                              block,
                              block.AbsolutePosition,
                              args,
                              progressHandler,
                              async: async,
                              cancellationToken).ConfigureAwait(false);
                    };
                }
            }
            return partitions;
        }

        public async Task CommitBlockList(
            TServiceSpecificData args,
            CancellationToken cancellationToken)
        {
            if (_blockList != null && !(_blockList.IsEmpty))
            {
                await _commitPartitionedUploadInternal(
                    _blockList.ToList(),
                    args,
                    true,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Wraps both the async method and dispose call in one task.
        /// </summary>
        private async Task StagePartitionAndDisposeInternal(
            SlicedStream partition,
            long offset,
            TServiceSpecificData args,
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
                    // TODO #27253
                    //_hashingOptions,
                    async,
                    cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                // Return the memory used by the block to our ArrayPool as soon
                // as we've staged it
                partition.Dispose();
            }
        }

        #region Stream Splitters
        /// <summary>
        /// Partition a stream into a series of blocks buffered as needed by an array pool.
        /// </summary>
        private static async IAsyncEnumerable<SlicedStream> GetPartitionsAsync(
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
                SlicedStream partition = await getNextPartition(
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
        private async Task<SlicedStream> GetBufferedPartitionInternal(
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
        #endregion
    }

    internal static partial class StreamExtensions
    {
        /// <summary>
        /// Some streams will throw if you try to access their length so we wrap
        /// the check in a TryGet helper.
        /// </summary>
        public static long? GetLengthOrDefault(this Stream content)
        {
            try
            {
                if (content.CanSeek)
                {
                    return content.Length - content.Position;
                }
            }
            catch (NotSupportedException)
            {
            }
            return default;
        }
    }
}
