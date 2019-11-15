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
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs
{
    internal class PartitionedUploader
    {
        // The client we use to do the actual uploading
        private readonly BlockBlobClient _client;

        // The maximum number of simultaneous workers
        private readonly int _maxWorkerCount;

        // A pool of memory we use to partition the stream into blocks
        private readonly ArrayPool<byte> _arrayPool;

        // The size we use to determine whether to upload as a single PUT BLOB
        // request or stage as multiple blocks.
        private readonly long _singleUploadThreshold;

        // The size of each staged block.  If null, we'll change between 4MB
        // and 8MB depending on the size of the content.
        private readonly int? _blockSize;

        public PartitionedUploader(
            BlockBlobClient client,
            StorageTransferOptions transferOptions,
            long? singleUploadThreshold = null,
            ArrayPool<byte> arrayPool = null)
        {
            _client = client;
            _arrayPool = arrayPool ?? ArrayPool<byte>.Shared;
            _maxWorkerCount =
                transferOptions.MaximumConcurrency ??
                Constants.Blob.Block.DefaultConcurrentTransfersCount;
            _singleUploadThreshold = singleUploadThreshold ?? Constants.Blob.Block.MaxUploadBytes;
            _blockSize = null;
            if (transferOptions.MaximumTransferLength != null)
            {
                _blockSize = Math.Min(
                    Constants.Blob.Block.MaxStageBytes,
                    transferOptions.MaximumTransferLength.Value);
            }
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
            if (TryGetLength(content, out long length) && length < _singleUploadThreshold)
            {
                // Upload it in a single request
                return await _client.UploadAsync(
                    content,
                    blobHttpHeaders,
                    metadata,
                    conditions,
                    accessTier,
                    progressHandler,
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
            if (TryGetLength(content, out long length) && length < _singleUploadThreshold)
            {
                // Upload it in a single request
                return _client.Upload(
                    content,
                    blobHttpHeaders,
                    metadata,
                    conditions,
                    accessTier,
                    progressHandler,
                    cancellationToken);
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
            DiagnosticScope scope = _client.ClientDiagnostics.CreateScope($"{nameof(Azure)}.{nameof(Storage)}.{nameof(Blobs)}.{nameof(BlobClient)}.{nameof(BlobClient.Upload)}");
            try
            {
                scope.Start();

                // The list tracking blocks IDs we're going to commit
                List<string> blockIds = new List<string>();

                // Partition the stream into individual blocks and stage them
                IAsyncEnumerator<StreamPartition> enumerator =
                    GetBlocksAsync(content, blockSize, async: false, cancellationToken)
                    .GetAsyncEnumerator(cancellationToken);
                while (enumerator.MoveNextAsync().EnsureCompleted())
                {
                    // Dispose the block after the loop iterates and return its
                    // memory to our ArrayPool
                    using StreamPartition block = enumerator.Current;

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
            DiagnosticScope scope = _client.ClientDiagnostics.CreateScope($"{nameof(Azure)}.{nameof(Storage)}.{nameof(Blobs)}.{nameof(BlobClient)}.{nameof(BlobClient.Upload)}");
            try
            {
                scope.Start();

                // The list tracking blocks IDs we're going to commit
                List<string> blockIds = new List<string>();

                // A list of tasks that are currently executing which will
                // always be smaller than _maxWorkerCount
                List<Task> runningTasks = new List<Task>();

                // Partition the stream into individual blocks
                await foreach (StreamPartition block in GetBlocksAsync(content, blockSize, async: true, cancellationToken))
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
            StreamPartition block,
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

        // Some streams will throw if you try to access their length so we wrap
        // the check in a TryGet helper.
        private static bool TryGetLength(Stream content, out long length)
        {
            length = 0;
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

        // Partition a stream into a series of blocks using our ArrayPool
        private async IAsyncEnumerable<StreamPartition> GetBlocksAsync(
            Stream stream,
            int blockSize,
            bool async,
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
                byte[] bytes = _arrayPool.Rent(blockSize);
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
                        yield return new StreamPartition(absolutePosition, bytes, offset, _arrayPool);

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
                        _arrayPool.Return(bytes);
                    }
                }

            // Continue reading blocks until we've exhausted the stream
            } while (read != 0);
        }

        private readonly struct StreamPartition: IDisposable
        {
            public StreamPartition(long absolutePosition, byte[] bytes, int length, ArrayPool<byte> arrayPool)
            {
                AbsolutePosition = absolutePosition;
                Bytes = bytes;
                Length = length;
                ArrayPool = arrayPool;
            }

            public byte[] Bytes { get; }
            public int Length { get; }
            public ArrayPool<byte> ArrayPool { get; }
            public long AbsolutePosition { get; }

            public void Dispose()
            {
                ArrayPool.Return(Bytes);
            }
        }
    }
}
