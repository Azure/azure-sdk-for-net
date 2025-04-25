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
using Azure.Storage.Common;
using Azure.Storage.Shared;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage
{
    internal class PartitionedUploader<TServiceSpecificData, TCompleteUploadReturn>
    {
        #region Definitions

        #region Content Partitioning Types and Delegates
        /// <summary>
        /// Generic wrapper for a content data structure.
        /// </summary>
        /// <typeparam name="TContent">
        /// Data structure housing the content to upload.
        /// </typeparam>
        private readonly struct ContentPartition<TContent>
        {
            public long AbsolutePosition { get; }
            public long Length { get; }
            public TContent Content { get; }
            public ReadOnlyMemory<byte> ContentChecksum { get; }

            public ContentPartition(long position, long length, TContent content, ReadOnlyMemory<byte> contentChecksum)
            {
                AbsolutePosition = position;
                Length = length;
                Content = content;
                ContentChecksum = contentChecksum;
            }
        }

        /// <summary>
        /// Generic delegate to upload and individual content partition.
        /// </summary>
        /// <typeparam name="TContent"></typeparam>
        /// <param name="content">
        /// Content partition.
        /// </param>
        /// <param name="offset">
        /// Absolute offset of this partition.
        /// </param>
        /// <param name="args">
        /// Service-specific args for upload.
        /// </param>
        /// <param name="validationOptions">
        /// Transfer validation options for uploading this partition.
        /// </param>
        /// <param name="progressHandler">
        /// Progress handler for this partition's upload.
        /// </param>
        /// <param name="async">
        /// Whether to perform this operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Task for partition upload completion.
        /// </returns>
        private delegate Task StageContentPartitionAsync<TContent>(
            TContent content,
            long offset,
            TServiceSpecificData args,
            UploadTransferValidationOptions validationOptions,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken);

        /// <summary>
        /// Delegte for getting a partition from a stream based on the selected data management stragegy.
        /// </summary>
        private delegate Task<(Stream PartitionContent, ReadOnlyMemory<byte> PartitionChecksum)> GetNextStreamPartition(
            Stream stream,
            long count,
            long absolutePosition,
            bool async,
            CancellationToken cancellationToken);
        #endregion

        #region Injected Client Behaviors
        public delegate DiagnosticScope CreateScope(string operationName);
        public delegate Task InitializeDestinationInternal(TServiceSpecificData args, bool async, CancellationToken cancellationToken);
        public delegate Task<Response<TCompleteUploadReturn>> SingleUploadStreamingInternal(
            Stream contentStream,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            UploadTransferValidationOptions transferValidation,
            string operationName,
            bool async,
            CancellationToken cancellationToken);
        public delegate Task<Response<TCompleteUploadReturn>> SingleUploadBinaryDataInternal(
            BinaryData content,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            UploadTransferValidationOptions transferValidation,
            string operationName,
            bool async,
            CancellationToken cancellationToken);
        public delegate Task UploadPartitionStreamingInternal(
            Stream contentStream,
            long offset,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            UploadTransferValidationOptions transferValidation,
            bool async,
            CancellationToken cancellationToken);
        public delegate Task UploadPartitionBinaryDataInternal(
            BinaryData content,
            long offset,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            UploadTransferValidationOptions transferValidation,
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
            public SingleUploadStreamingInternal SingleUploadStreaming { get; set; }
            public SingleUploadBinaryDataInternal SingleUploadBinaryData { get; set; }
            public UploadPartitionStreamingInternal UploadPartitionStreaming { get; set; }
            public UploadPartitionBinaryDataInternal UploadPartitionBinaryData { get; set; }
            public CommitPartitionedUploadInternal CommitPartitionedUpload { get; set; }
            public CreateScope Scope { get; set; }
        }

        public static readonly InitializeDestinationInternal InitializeNoOp = (args, async, cancellationToken) => Task.CompletedTask;
        #endregion
        #endregion

        private readonly InitializeDestinationInternal _initializeDestinationInternal;
        private readonly SingleUploadStreamingInternal _singleUploadStreamingInternal;
        private readonly SingleUploadBinaryDataInternal _singleUploadBinaryDataInternal;
        private readonly UploadPartitionStreamingInternal _uploadPartitionStreamingInternal;
        private readonly UploadPartitionBinaryDataInternal _uploadPartitionBinaryDataInternal;
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
        /// Checksum algorithm to use for transfer validation.
        /// </summary>
        private readonly StorageChecksumAlgorithm _validationAlgorithm;
        private bool UseMasterCrc => _validationAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64;

        /// <summary>
        /// CRC calculation over the entire upload contents. This may be calculated upfront with in-memory data
        /// or calculated over the course of upload with streamed data.
        /// This is NOT a composed value. Composition happens locally in the upload to validate against this value.
        /// </summary>
        private Func<Memory<byte>> _masterCrcSupplier = default;

        /// <summary>
        /// Gets <see cref="_validationAlgorithm"/> as <see cref="UploadTransferValidationOptions"/>.
        /// </summary>
        private UploadTransferValidationOptions ValidationOptions => new UploadTransferValidationOptions
        {
            ChecksumAlgorithm = _validationAlgorithm,
        };

        /// <summary>
        /// The name of the calling operaiton.
        /// </summary>
        private readonly string _operationName;

        public PartitionedUploader(
            Behaviors behaviors,
            StorageTransferOptions transferOptions,
            UploadTransferValidationOptions transferValidation,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
        {
            // initialize isn't required for all services and can use a no-op; rest are required
            _initializeDestinationInternal = behaviors.InitializeDestination ?? InitializeNoOp;
            _singleUploadStreamingInternal = Argument.CheckNotNull(
                behaviors.SingleUploadStreaming, nameof(behaviors.SingleUploadStreaming));
            _singleUploadBinaryDataInternal = Argument.CheckNotNull(
                behaviors.SingleUploadBinaryData, nameof(behaviors.SingleUploadBinaryData));
            _uploadPartitionStreamingInternal = Argument.CheckNotNull(
                behaviors.UploadPartitionStreaming, nameof(behaviors.UploadPartitionStreaming));
            _uploadPartitionBinaryDataInternal = Argument.CheckNotNull(
                behaviors.UploadPartitionBinaryData, nameof(behaviors.UploadPartitionBinaryData));
            _commitPartitionedUploadInternal = Argument.CheckNotNull(
                behaviors.CommitPartitionedUpload, nameof(behaviors.CommitPartitionedUpload));
            _createScope = Argument.CheckNotNull(
                behaviors.Scope, nameof(behaviors.Scope));

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

            _validationAlgorithm = Argument.CheckNotNull(transferValidation, nameof(transferValidation))
                .ChecksumAlgorithm.ResolveAuto();
            if (!transferValidation.PrecalculatedChecksum.IsEmpty)
            {
                if (UseMasterCrc)
                {
                    var userSuppliedMasterCrc = new Memory<byte>(new byte[transferValidation.PrecalculatedChecksum.Length]);
                    transferValidation.PrecalculatedChecksum.CopyTo(userSuppliedMasterCrc);
                    _masterCrcSupplier = () => userSuppliedMasterCrc;
                }
                else
                {
                    throw Errors.PrecalculatedHashNotSupportedOnSplit();
                }
            }

            _operationName = operationName;
        }

        public async Task<Response<TCompleteUploadReturn>> UploadInternal(
            BinaryData content,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            await _initializeDestinationInternal(args, async, cancellationToken).ConfigureAwait(false);
            long length = content.ToMemory().Length;

            if (length < _singleUploadThreshold)
            {
                UploadTransferValidationOptions validationOptions;
                if (UseMasterCrc && _masterCrcSupplier != default)
                {
                    validationOptions = new UploadTransferValidationOptions
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64,
                        PrecalculatedChecksum = _masterCrcSupplier(),
                    };
                }
                else
                {
                    validationOptions = ContentHasher.GetHashOrDefault(
                    content,
                    ValidationOptions)
                    .ToUploadTransferValidationOptions();
                }
                return await _singleUploadBinaryDataInternal(
                    content,
                    args,
                    progressHandler,
                    validationOptions,
                    _operationName,
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);
            }

            // can get master crc upfront in place
            if (UseMasterCrc && _masterCrcSupplier == default)
            {
                var masterCrc = new NonCryptographicHashAlgorithmHasher(StorageCrc64HashAlgorithm.Create());
                masterCrc.AppendHash(content);
                _masterCrcSupplier = () => masterCrc.GetFinalHash();
            }

            return await UploadPartitionsInternal(
                GetContentPartitionsBinaryDataInternal(content, length, GetActualBlockSize(_blockSize, length), async, cancellationToken),
                args,
                progressHandler,
                StageBinaryDataPartitionInternal,
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<Response<TCompleteUploadReturn>> UploadInternal(
            Stream content,
            long? expectedContentLength,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));
            Errors.VerifyStreamPosition(content, nameof(content));

            if (content.CanSeek && content.Position > 0)
            {
                content = WindowStream.GetWindow(content, content.Length - content.Position);
            }

            await _initializeDestinationInternal(args, async, cancellationToken).ConfigureAwait(false);

            // some strategies are unavailable if we don't know the stream length, and some can still work
            // we may introduce separately provided stream lengths in the future for unseekable streams with
            // an expected length
            long? length = expectedContentLength ?? content.GetLengthOrDefault();

            // If we know the length and it's small enough
            if (length < _singleUploadThreshold)
            {
                using var bucket = new DisposableBucket();
                UploadTransferValidationOptions oneshotValidationOptions = ValidationOptions;
                oneshotValidationOptions.PrecalculatedChecksum = _masterCrcSupplier?.Invoke() ?? default;

                // If not seekable, buffer and checksum if necessary.
                if (!content.CanSeek)
                {
                    Stream bufferedContent;
                    if (UseMasterCrc && _masterCrcSupplier != default)
                    {
                        bufferedContent = new PooledMemoryStream(_arrayPool, Constants.MB);
                        await content.CopyToInternal(bufferedContent, async, cancellationToken).ConfigureAwait(false);
                        bufferedContent.Position = 0;
                    }
                    else
                    {
                        (bufferedContent, oneshotValidationOptions) = await BufferAndOptionalChecksumStreamInternal(
                            content, length.Value, oneshotValidationOptions, async, cancellationToken)
                            .ConfigureAwait(false);
                    }
                    bucket.Add(bufferedContent);
                    content = bufferedContent;
                }

                // Upload it in a single request
                var result = await _singleUploadStreamingInternal(
                    content,
                    args,
                    progressHandler,
                    oneshotValidationOptions,
                    _operationName,
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);

                return result;
            }

            // configure content stream to calculate master crc as it is read
            if (UseMasterCrc && _masterCrcSupplier == default)
            {
                var masterCrc = new NonCryptographicHashAlgorithmHasher(StorageCrc64HashAlgorithm.Create());
                content = ChecksumCalculatingStream.GetReadStream(content, masterCrc.AppendHash);
                _masterCrcSupplier = () => masterCrc.GetFinalHash();
            }

            // Streamed partitions only work if we can seek the stream and don't need parallel access to it.
            GetNextStreamPartition partitionGetter = content.CanSeek && _maxWorkerCount == 1
                ? (GetNextStreamPartition)GetStreamedPartitionInternal
                : /*   redundant cast   */GetBufferedPartitionInternal;

            return await UploadPartitionsInternal(
                GetStreamPartitionsAsync(content, length, GetActualBlockSize(_blockSize, length), partitionGetter, async, cancellationToken),
                args,
                progressHandler,
                StageStreamPartitionInternal,
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private static long GetActualBlockSize(long? blockSize, long? totalLength)
            // If the caller provided an explicit block size, we'll use it.
            // Otherwise we'll adjust dynamically based on the size of the
            // content.
            => blockSize ?? (totalLength < Constants.LargeUploadThreshold ?
                    Constants.DefaultBufferSize :
                    Constants.LargeBufferSize);

        /// <summary>
        /// Buffers the given stream and optionally checksums the stream contents as they are buffered.
        /// </summary>
        /// <param name="source">
        /// Stream to buffer.
        /// </param>
        /// <param name="count">
        /// Exact count to buffer from the stream.
        /// </param>
        /// <param name="validationOptions">
        /// Validation options for the upload to determine if buffering is needed.
        /// </param>
        /// <param name="async">
        /// Whether to perform the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A tuple containing:
        /// <list type="number">
        /// <item>
        /// The buffered contents of <paramref name="source"/>, exposed as a <see cref="Stream"/>.
        /// </item>
        /// <item>
        /// Updated transfer validation options for this upload. Will contain the calculated checksum, if any.
        /// </item>
        /// </list>
        /// </returns>
        private async Task<(Stream Stream, UploadTransferValidationOptions ValidationOptions)>
            BufferAndOptionalChecksumStreamInternal(
                Stream source,
                long? count,
                UploadTransferValidationOptions validationOptions,
                bool async,
                CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(validationOptions, nameof(validationOptions));

            bool usingChecksumStream =
                validationOptions.ChecksumAlgorithm != StorageChecksumAlgorithm.None &&
                validationOptions.PrecalculatedChecksum.IsEmpty;
            ContentHasher.GetFinalStreamHash checksumCallback = null;
            int checksumSize = 0;
            IDisposable hashCalculatorDisposable = null;
            if (usingChecksumStream)
            {
                (source, checksumCallback, checksumSize, hashCalculatorDisposable) = ContentHasher
                    .SetupChecksumCalculatingReadStream(source, validationOptions.ChecksumAlgorithm);
            }

            Stream bufferedContent = new PooledMemoryStream(_arrayPool, Constants.MB);
            if (count.HasValue)
            {
                await source.CopyToExactInternal(bufferedContent, count.Value, async, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                await source.CopyToInternal(bufferedContent, async, cancellationToken).ConfigureAwait(false);
            }
            bufferedContent.Position = 0;

            if (usingChecksumStream)
            {
                var checksum = new Memory<byte>(new byte[checksumSize]);
                checksumCallback(checksum.Span);
                validationOptions = new UploadTransferValidationOptions
                {
                    ChecksumAlgorithm = validationOptions.ChecksumAlgorithm,
                    PrecalculatedChecksum = checksum,
                };
            }

            hashCalculatorDisposable?.Dispose();
            return (bufferedContent, validationOptions);
        }

        private async Task<Response<TCompleteUploadReturn>> UploadPartitionsInternal<TContent>(
            IAsyncEnumerable<ContentPartition<TContent>> contentPartitions,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            StageContentPartitionAsync<TContent> stageContentAsync,
            bool async,
            CancellationToken cancellationToken)
        {
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
                    contentPartitions,
                    args,
                    progressHandler,
                    stageContentAsync,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
#pragma warning restore AZC0109 // Misuse of 'async' parameter.
            else
            {
                return await UploadInSequenceInternal(
                    contentPartitions,
                    args,
                    progressHandler,
                    stageContentAsync,
                    async: async,
                    cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task<Response<TCompleteUploadReturn>> UploadInSequenceInternal<TContent>(
            IAsyncEnumerable<ContentPartition<TContent>> contentPartitions,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            StageContentPartitionAsync<TContent> stageContentAsync,
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
                List<(long Offset, long Size)> partitions = new();

                Memory<byte> _composedBlockCrc64 = UseMasterCrc
                    ? new Memory<byte>(new byte[Constants.StorageCrc64SizeInBytes])
                    : Memory<byte>.Empty;
                long composedOriginalDataLength = 0;

                // Partition the stream into individual blocks and stage them
                async Task StageAsync(ContentPartition<TContent> block, bool async, CancellationToken cancellationToken)
                {
                    await stageContentAsync(
                            block.Content,
                            block.AbsolutePosition,
                            args,
                            new UploadTransferValidationOptions
                            {
                                ChecksumAlgorithm = _validationAlgorithm,
                                PrecalculatedChecksum = block.ContentChecksum,
                            },
                            progressHandler,
                            async,
                            cancellationToken).ConfigureAwait(false);

                    partitions.Add((block.AbsolutePosition, block.Length));
                    if (UseMasterCrc)
                    {
                        _composedBlockCrc64 = StorageCrc64Composer.Compose(
                            (_composedBlockCrc64.ToArray(), composedOriginalDataLength),
                            (block.ContentChecksum.ToArray(), block.Length));
                    }
                }
                if (async)
                {
                    await foreach (ContentPartition<TContent> block in contentPartitions.ConfigureAwait(false))
                    {
                        await StageAsync(block, true, cancellationToken).ConfigureAwait(false);
                    }
                }
                else
                {
                    foreach (ContentPartition<TContent> block in contentPartitions.EnsureSyncEnumerable())
                    {
                        StageAsync(block, false, cancellationToken).EnsureCompleted();
                    }
                }

                if (UseMasterCrc)
                {
                    Memory<byte> wholeCrc = _masterCrcSupplier();
                    if (!_composedBlockCrc64.Span.SequenceEqual(wholeCrc.Span))
                    {
                        throw Errors.ChecksumMismatch(wholeCrc.Span, _composedBlockCrc64.Span);
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

        private async Task<Response<TCompleteUploadReturn>> UploadInParallelAsync<TContent>(
            IAsyncEnumerable<ContentPartition<TContent>> contentPartitions,
            TServiceSpecificData args,
            IProgress<long> progressHandler,
            StageContentPartitionAsync<TContent> stageContentAsync,
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

                Memory<byte> _composedBlockCrc64 = UseMasterCrc
                    ? new Memory<byte>(new byte[Constants.StorageCrc64SizeInBytes])
                    : Memory<byte>.Empty;
                long composedOriginalDataLength = 0;

                // Partition the stream into individual blocks
                await foreach (ContentPartition<TContent> block in contentPartitions.ConfigureAwait(false))
                {
                    /* We need to do this first! Length is calculated on the fly based on stream buffer
                     * contents; We need to record the partition data first before consuming the stream
                     * asynchronously. */
                    partitions.Add((block.AbsolutePosition, block.Length));

                    if (UseMasterCrc)
                    {
                        _composedBlockCrc64 = StorageCrc64Composer.Compose(
                            (_composedBlockCrc64.ToArray(), composedOriginalDataLength),
                            (block.ContentChecksum.ToArray(), block.Length));
                    }

                    // Start staging the next block (but don't await the Task!)
                    Task task = stageContentAsync(
                        block.Content,
                        block.AbsolutePosition,
                        args,
                        new UploadTransferValidationOptions
                        {
                            ChecksumAlgorithm = _validationAlgorithm,
                            PrecalculatedChecksum = block.ContentChecksum
                        },
                        progressHandler,
                        async: true,
                        cancellationToken);

                    // Add the block to our task and commit lists
                    runningTasks.Add(task);

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

                if (UseMasterCrc)
                {
                    Memory<byte> wholeCrc = _masterCrcSupplier();
                    if (!_composedBlockCrc64.Span.SequenceEqual(wholeCrc.Span))
                    {
                        throw Errors.ChecksumMismatch(wholeCrc.Span, _composedBlockCrc64.Span);
                    }
                }

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
        /// Implementation of <see cref="StageContentPartitionAsync{TContent}"/>
        /// for <see cref="Stream"/>.
        /// Wraps both the async method and dispose call in one task.
        /// </summary>
        private async Task StageStreamPartitionInternal(
            Stream partition,
            long offset,
            TServiceSpecificData args,
            UploadTransferValidationOptions validationOptions,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            try
            {
                await _uploadPartitionStreamingInternal(
                    partition,
                    offset,
                    args,
                    progressHandler,
                    validationOptions,
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
        /// Implementation of <see cref="StageContentPartitionAsync{TContent}"/>
        /// for <see cref="BinaryData"/>.
        /// </summary>
        private async Task StageBinaryDataPartitionInternal(
            BinaryData content,
            long offset,
            TServiceSpecificData args,
            UploadTransferValidationOptions validationOptions,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            await _uploadPartitionBinaryDataInternal(
                content,
                offset,
                args,
                progressHandler,
                validationOptions,
                async,
                cancellationToken).ConfigureAwait(false);
        }

        #region Content Slicing Impl
        /// <remarks>
        /// Async wrapper over a synchronous operation to satisfy delegate definitions.
        /// </remarks>
        private async IAsyncEnumerable<ContentPartition<BinaryData>> GetContentPartitionsBinaryDataInternal(
#pragma warning disable CA1801 // Review unused parameters; unused paramters satisfy delegate GetContentPartitionsAsync<T>
            BinaryData content,
            long? contentLength,
            long blockSize,
            bool async,
            [EnumeratorCancellation] CancellationToken cancellationToken)
#pragma warning restore CA1801 // Review unused parameters
        {
            foreach (ContentPartition<BinaryData> slice in GetBinaryDataPartitions(
                content, (int)blockSize))
            {
                // method returning IAsyncEnumerable must be async
                // async method must use await at some point
                yield return async
                    ? await Task.FromResult(slice).ConfigureAwait(false)
                    : slice;
            }
        }

        private IEnumerable<ContentPartition<BinaryData>> GetBinaryDataPartitions(
            BinaryData content,
            int blockSize)
        {
            int position = 0;
            ReadOnlyMemory<byte> remaining = content.ToMemory();
            while (!remaining.IsEmpty)
            {
                ReadOnlyMemory<byte> next;
                if (remaining.Length <= blockSize)
                {
                    next = remaining;
                    remaining = ReadOnlyMemory<byte>.Empty;
                }
                else
                {
                    next = remaining.Slice(0, blockSize);
                    remaining = remaining.Slice(blockSize);
                }

                var partition = BinaryData.FromBytes(next);
                var checksum = ContentHasher.GetHashOrDefault(partition, ValidationOptions);

                yield return new ContentPartition<BinaryData>(
                    position,
                    next.Length,
                    partition,
                    checksum?.Checksum ?? ReadOnlyMemory<byte>.Empty);
                position += next.Length;
            }
        }

        /// <summary>
        /// Partition a stream into a series of blocks buffered as needed by an array pool.
        /// </summary>
        private static async IAsyncEnumerable<ContentPartition<Stream>> GetStreamPartitionsAsync(
            Stream stream,
            long? streamLength,
            long blockSize,
            GetNextStreamPartition getNextPartition,
            bool async,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
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
            }

            long read;
            long absolutePosition = 0;
            do
            {
                (Stream partition, ReadOnlyMemory<byte> partitionChecksum) = await getNextPartition(
                    stream,
                    blockSize,
                    absolutePosition,
                    async,
                    cancellationToken).ConfigureAwait(false);
                read = partition.Length;

                // If we read anything, turn it into a StreamPartition and
                // return it for staging
                if (partition.Length != 0)
                {
                    // The StreamParitition is disposable and it'll be the
                    // user's responsibility to return the bytes used to our
                    // ArrayPool
                    yield return new ContentPartition<Stream>(
                        absolutePosition,
                        partition.Length,
                        partition,
                        partitionChecksum);
                }

                absolutePosition += read;
                // Continue reading blocks until we've exhausted the stream
            } while (read != 0);
        }

        /// <summary>
        /// Implementation of <see cref="GetNextStreamPartition"/> for a buffering strategy.
        /// Gets a partition from the current location of the given stream.
        /// This partition is buffered and it is safe to get many before using any of them.
        /// </summary>
        /// <param name="stream">
        /// Stream to buffer a partition from.
        /// </param>
        /// <param name="count">
        /// Amount of data to wait on before finalizing buffer.
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
        private async Task<(Stream PartitionContent, ReadOnlyMemory<byte> PartitionChecksum)> GetBufferedPartitionInternal(
            Stream stream,
            long count,
            long absolutePosition,
            bool async,
            CancellationToken cancellationToken)
        {
            // also calculate checksum here for the partition checksum
            (Stream slicedStream, UploadTransferValidationOptions validationOptions)
                = await BufferAndOptionalChecksumStreamInternal(
                    stream,
                    count,
                    new UploadTransferValidationOptions { ChecksumAlgorithm = _validationAlgorithm },
                    async,
                    cancellationToken).ConfigureAwait(false);

            return (slicedStream, validationOptions.PrecalculatedChecksum);
        }

        /// <summary>
        /// Implementation of <see cref="GetNextStreamPartition"/> for a slicing strategy.
        /// Gets a partition from the current location of the given stream.
        /// This partition is a facade over the existing stream, and the
        /// previous partition should be consumed before using the next.
        /// </summary>
        /// <param name="stream">
        /// Stream to wrap.
        /// </param>
        /// <param name="count">
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
        private async Task<(Stream PartitionContent, ReadOnlyMemory<byte> PartitionChecksum)> GetStreamedPartitionInternal(
            Stream stream,
            long count,
            long absolutePosition,
            bool async,
            CancellationToken cancellationToken)
        {
            if (!stream.CanSeek)
            {
                throw Errors.InvalidArgument(nameof(stream));
            }
            var partitionStream = WindowStream.GetWindow(stream, count);
            // this resets stream position for us
            var checksum = await ContentHasher.GetHashOrDefaultInternal(
                partitionStream,
                ValidationOptions,
                async,
                cancellationToken)
                .ConfigureAwait(false);
            return (partitionStream, checksum?.Checksum ?? ReadOnlyMemory<byte>.Empty);
        }
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
