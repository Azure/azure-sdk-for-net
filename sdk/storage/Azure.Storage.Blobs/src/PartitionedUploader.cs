// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    internal class PartitionedUploader
    {
        /// <summary>
        /// The client we use to do the actual uploading.
        /// </summary>
        private readonly BlockBlobClient _client;

        /// <summary>
        /// The maximum number of simultaneous workers.
        /// </summary>
        private readonly int _maxWorkerCount;

        /// <summary>
        /// A pool of memory we use to partition the stream into blocks.
        /// </summary>
        private readonly ArrayPool<byte> _arrayPool;

        /// <summary>
        /// The size we use to determine whether to upload as a single PUT BLOB
        /// request or stage as multiple blocks.
        /// </summary>
        private readonly long _singleUploadThreshold;

        /// <summary>
        /// The size of each staged block.  If null, we'll change between 4MB
        /// and 8MB depending on the size of the content.
        /// </summary>
        private readonly int? _blockSize;

        /// <summary>
        /// The name of the calling operaiton.
        /// </summary>
        private readonly string _operationName;

        public PartitionedUploader(
            BlockBlobClient client,
            StorageTransferOptions transferOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
        {
            _client = client;
            _arrayPool = arrayPool ?? ArrayPool<byte>.Shared;

            // Set _maxWorkerCount
            if (transferOptions.MaximumConcurrency.HasValue)
            {
                if (transferOptions.MaximumConcurrency < 1)
                {
                    _maxWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
                }
                else
                {
                    _maxWorkerCount = transferOptions.MaximumConcurrency.Value;
                }
            }
            else
            {
                _maxWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }

            // Set _singleUploadThreshold
            if (transferOptions.InitialTransferLength.HasValue)
            {
                if (transferOptions.InitialTransferLength.Value < 1)
                {
                    _singleUploadThreshold = Constants.Blob.Block.MaxUploadBytes;
                }
                else
                {
                    _singleUploadThreshold = Math.Min(transferOptions.InitialTransferLength.Value, Constants.Blob.Block.MaxUploadBytes);
                }
            }
            else
            {
                _singleUploadThreshold = Constants.Blob.Block.MaxUploadBytes;
            }

            // Set _blockSize
            if (transferOptions.MaximumTransferLength.HasValue)
            {
                if (transferOptions.MaximumTransferLength < 1)
                {
                    _blockSize = Constants.Blob.Block.MaxStageBytes;
                }
                else
                {
                    _blockSize = Math.Min(
                        Constants.Blob.Block.MaxStageBytes,
                        transferOptions.MaximumTransferLength.Value);
                }
            }
            else
            {
                _blockSize = Constants.Blob.Block.MaxStageBytes;
            }

            _operationName = operationName;
        }

        public async Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobHttpHeaders blobHttpHeaders,
            IDictionary<string, string> metadata,
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
            AccessTier? accessTier = default,
            CancellationToken cancellationToken = default)
        {
            // If we can compute the size and it's small enough
            if (PartitionedUploadExtensions.TryGetLength(content, out long length) && length < _singleUploadThreshold)
            {
                // Upload it in a single request
                return await _client.UploadInternal(
                    content,
                    blobHttpHeaders,
                    metadata,
                    conditions,
                    accessTier,
                    progressHandler,
                    _operationName,
                    async: true,
                    cancellationToken)
                    .ConfigureAwait(false);
            }

            // If the caller provided an explicit block size, we'll use it.
            // Otherwise we'll adjust dynamically based on the size of the
            // content.
            int blockSize =
                _blockSize != null ? _blockSize.Value :
                length < Constants.LargeUploadThreshold ?
                    Constants.DefaultBufferSize :
                    Constants.LargeBufferSize;

            // Otherwise stage individual blocks in parallel
            return await UploadInParallelAsync(
                content,
                blockSize,
                blobHttpHeaders,
                metadata,
                conditions,
                progressHandler,
                accessTier,
                cancellationToken)
                .ConfigureAwait(false);
        }

        public Response<BlobContentInfo> Upload(
            Stream content,
            BlobHttpHeaders blobHttpHeaders,
            IDictionary<string, string> metadata,
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
            AccessTier? accessTier = default,
            CancellationToken cancellationToken = default)
        {
            // If we can compute the size and it's small enough
            if (PartitionedUploadExtensions.TryGetLength(content, out long length) && length < _singleUploadThreshold)
            {
                // Upload it in a single request
                return _client.UploadInternal(
                    content,
                    blobHttpHeaders,
                    metadata,
                    conditions,
                    accessTier,
                    progressHandler,
                    _operationName,
                    false,
                    cancellationToken).EnsureCompleted();
            }

            // If the caller provided an explicit block size, we'll use it.
            // Otherwise we'll adjust dynamically based on the size of the
            // content.
            int blockSize =
                _blockSize != null ? _blockSize.Value :
                length < Constants.LargeUploadThreshold ?
                    Constants.DefaultBufferSize :
                    Constants.LargeBufferSize;

            // Otherwise stage individual blocks one at a time.  It's not as
            // fast as a parallel upload, but you get the benefit of the retry
            // policy working on a single block instead of the entire stream.
            return UploadInSequence(
                content,
                blockSize,
                blobHttpHeaders,
                metadata,
                conditions,
                progressHandler,
                accessTier,
                cancellationToken);
        }

        private Response<BlobContentInfo> UploadInSequence(
            Stream content,
            int blockSize,
            BlobHttpHeaders blobHttpHeaders,
            IDictionary<string, string> metadata,
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
            AccessTier? accessTier,
            CancellationToken cancellationToken)
        {
            // Wrap the staging and commit calls in an Upload span for
            // distributed tracing
            DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(
                _operationName ?? $"{nameof(Azure)}.{nameof(Storage)}.{nameof(Blobs)}.{nameof(BlobClient)}.{nameof(BlobClient.Upload)}");
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
                List<string> blockIds = new List<string>();

                // Partition the stream into individual blocks and stage them
                IAsyncEnumerator<ChunkedStream> enumerator =
                    PartitionedUploadExtensions.GetBlocksAsync(content, blockSize, async: false, _arrayPool, cancellationToken)
                    .GetAsyncEnumerator(cancellationToken);
#pragma warning disable AZC0107
                while (enumerator.MoveNextAsync().EnsureCompleted())
#pragma warning restore AZC0107
                {
                    // Dispose the block after the loop iterates and return its
                    // memory to our ArrayPool
                    using ChunkedStream block = enumerator.Current;

                    // Stage the next block
                    string blockId = GenerateBlockId(block.AbsolutePosition);
                    _client.StageBlock(
                        blockId,
                        new MemoryStream(block.Bytes, 0, block.Length, writable: false),
                        conditions: conditions,
                        progressHandler: progressHandler,
                        cancellationToken: cancellationToken);

                    blockIds.Add(blockId);
                }

                // Commit the block list after everything has been staged to
                // complete the upload
                return _client.CommitBlockList(
                    blockIds,
                    blobHttpHeaders,
                    metadata,
                    conditions,
                    accessTier,
                    cancellationToken);
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

        private async Task<Response<BlobContentInfo>> UploadInParallelAsync(
            Stream content,
            int blockSize,
            BlobHttpHeaders blobHttpHeaders,
            IDictionary<string, string> metadata,
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
            AccessTier? accessTier,
            CancellationToken cancellationToken)
        {
            // Wrap the staging and commit calls in an Upload span for
            // distributed tracing
            DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(
                _operationName ?? $"{nameof(Azure)}.{nameof(Storage)}.{nameof(Blobs)}.{nameof(BlobClient)}.{nameof(BlobClient.Upload)}");
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
                List<string> blockIds = new List<string>();

                // A list of tasks that are currently executing which will
                // always be smaller than _maxWorkerCount
                List<Task> runningTasks = new List<Task>();

                // Partition the stream into individual blocks
                await foreach (ChunkedStream block in PartitionedUploadExtensions.GetBlocksAsync(
                    content,
                    blockSize,
                    async: true,
                    _arrayPool,
                    cancellationToken).ConfigureAwait(false))
                {
                    // Start staging the next block (but don't await the Task!)
                    string blockId = GenerateBlockId(block.AbsolutePosition);
                    Task task = StageBlockAsync(
                        block,
                        blockId,
                        conditions,
                        progressHandler,
                        cancellationToken);

                    // Add the block to our task and commit lists
                    runningTasks.Add(task);
                    blockIds.Add(blockId);

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
                return await _client.CommitBlockListAsync(
                    blockIds,
                    blobHttpHeaders,
                    metadata,
                    conditions,
                    accessTier,
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

        private async Task StageBlockAsync(
            ChunkedStream block,
            string blockId,
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            try
            {
                await _client.StageBlockAsync(
                    blockId,
                    new MemoryStream(block.Bytes, 0, block.Length, writable: false),
                    conditions: conditions,
                    progressHandler: progressHandler,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            finally
            {
                // Return the memory used by the block to our ArrayPool as soon
                // as we've staged it
                block.Dispose();
            }
        }

        // Block IDs must be 64 byte Base64 encoded strings
        private static string GenerateBlockId(long offset)
        {
            // TODO #8162 - Add in a random GUID so multiple simultaneous
            // uploads won't stomp on each other and the first to commit wins.
            // This will require some changes to our test framework's
            // RecordedClientRequestIdPolicy.
            byte[] id = new byte[48]; // 48 raw bytes => 64 byte string once Base64 encoded
            BitConverter.GetBytes(offset).CopyTo(id, 0);
            return Convert.ToBase64String(id);
        }
    }
}
