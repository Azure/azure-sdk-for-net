// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs
{
    internal class PartitionedUploader
    {
        private readonly BlockBlobClient _client;

        private readonly long _singleBlockThreshold;

        private readonly ArrayPool<byte> _arrayPool;

        private readonly int _blockSize;
        private readonly int _minimumBlockFill;
        private readonly int _threadCount;

        public PartitionedUploader(BlockBlobClient client, StorageTransferOptions transferOptions, long? singleBlockThreshold = null, ArrayPool<byte> arrayPool = null)
        {
            _client = client;
            _singleBlockThreshold = singleBlockThreshold ?? Constants.Blob.Block.MaxUploadBytes;
            _threadCount =
                transferOptions.MaximumConcurrency ?? Constants.Blob.Block.DefaultConcurrentTransfersCount;
            _blockSize =
                Math.Min(
                    Constants.Blob.Block.MaxStageBytes,
                    transferOptions.MaximumTransferLength ?? Constants.DefaultBufferSize
                );
            _minimumBlockFill = _blockSize / 2;
            _arrayPool = arrayPool ?? ArrayPool<byte>.Shared;
        }

        public async Task<Response<BlobContentInfo>> UploadAsync(
            Stream content,
            BlobHttpHeaders blobHttpHeaders,
            IDictionary<string, string> metadata,
            BlobAccessConditions? blobAccessConditions,
            IProgress<long> progressHandler,
            AccessTier? accessTier = default,
            CancellationToken cancellationToken = default)
        {
            if (TryGetLength(content, out long length) && length < _singleBlockThreshold)
            {
                return await _client.UploadAsync(content, blobHttpHeaders, metadata, blobAccessConditions, accessTier, progressHandler, cancellationToken).ConfigureAwait(false);
            }

            return await UploadInParallelAsync(content, blobHttpHeaders, metadata, blobAccessConditions, progressHandler, accessTier, cancellationToken).ConfigureAwait(false);
        }

        public Response<BlobContentInfo> Upload(
            Stream content,
            BlobHttpHeaders blobHttpHeaders,
            IDictionary<string, string> metadata,
            BlobAccessConditions? blobAccessConditions,
            IProgress<long> progressHandler,
            AccessTier? accessTier = default,
            CancellationToken cancellationToken = default)
        {
            if (TryGetLength(content, out long length) && length < _singleBlockThreshold)
            {
                return _client.Upload(content, blobHttpHeaders, metadata, blobAccessConditions, accessTier, progressHandler, cancellationToken);
            }

            return UploadInSequence(content, blobHttpHeaders, metadata, blobAccessConditions, progressHandler, accessTier, cancellationToken);
        }

        private Response<BlobContentInfo> UploadInSequence(
            Stream content,
            BlobHttpHeaders blobHttpHeaders,
            IDictionary<string, string> metadata,
            BlobAccessConditions? blobAccessConditions,
            IProgress<long> progressHandler,
            AccessTier? accessTier,
            CancellationToken cancellationToken)
        {
            byte[] uploadId = Guid.NewGuid().ToByteArray();
            List<string> blocks = new List<string>();

            IAsyncEnumerator<StreamPartition> enumerator = GetBlocksAsync(content, async: false, cancellationToken).
                GetAsyncEnumerator(cancellationToken);

            while (enumerator.MoveNextAsync().EnsureCompleted())
            {
                using StreamPartition block = enumerator.Current;
                string blockId = GenerateBlockId(uploadId, block.AbsolutePosition);

                _client.StageBlock(
                    blockId,
                    new MemoryStream(block.Bytes, 0, block.Length, writable: false),
                    leaseAccessConditions: blobAccessConditions?.LeaseAccessConditions,
                    progressHandler: progressHandler,
                    cancellationToken: cancellationToken);

                blocks.Add(blockId);
            }

            return _client.CommitBlockList(blocks, blobHttpHeaders, metadata, blobAccessConditions, accessTier, cancellationToken);
        }

        private async Task<Response<BlobContentInfo>> UploadInParallelAsync(
            Stream content,
            BlobHttpHeaders blobHttpHeaders,
            IDictionary<string, string> metadata,
            BlobAccessConditions? blobAccessConditions,
            IProgress<long> progressHandler,
            AccessTier? accessTier,
            CancellationToken cancellationToken)
        {
            byte[] uploadId = Guid.NewGuid().ToByteArray();
            List<string> blocks = new List<string>();
            List<Task> runningTasks = new List<Task>();

            await foreach (StreamPartition block in GetBlocksAsync(content, async: true, cancellationToken))
            {
                string blockId = GenerateBlockId(uploadId, block.AbsolutePosition);

                Task task = StageBlobAsync(block, blockId, blobAccessConditions, progressHandler, cancellationToken);

                runningTasks.Add(task);
                blocks.Add(blockId);

                if (runningTasks.Count >= _threadCount)
                {
                    await Task.WhenAny(runningTasks).ConfigureAwait(false);

                    runningTasks.RemoveAll(t => t.IsCompleted);
                }
            }

            await Task.WhenAll(runningTasks).ConfigureAwait(false);

            return await _client.CommitBlockListAsync(blocks, blobHttpHeaders, metadata, blobAccessConditions, accessTier, cancellationToken)
                .ConfigureAwait(false);
        }

        private async Task StageBlobAsync(StreamPartition block, string blockId, BlobAccessConditions? blobAccessConditions, IProgress<long> progressHandler, CancellationToken cancellationToken)
        {
            try
            {
                await _client.StageBlockAsync(
                    blockId,
                    new MemoryStream(block.Bytes, 0, block.Length, writable: false),
                    leaseAccessConditions: blobAccessConditions?.LeaseAccessConditions,
                    progressHandler: progressHandler,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                block.Dispose();
            }
        }

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

        private static string GenerateBlockId(byte[] uploadId, long offset)
        {
            byte[] id = new byte[48];

            BitConverter.GetBytes(offset).CopyTo(id, 0);
            uploadId.CopyTo(id, id.Length - uploadId.Length);

            return Convert.ToBase64String(id);
        }

        private async IAsyncEnumerable<StreamPartition> GetBlocksAsync(Stream stream, bool async, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            int read;
            long absolutePosition = 0;
            do
            {
                byte[] bytes = _arrayPool.Rent(_blockSize);
                int offset = 0;

                do
                {
                    if (async)
                    {
                        read = await stream.ReadAsync(bytes, offset, _blockSize - offset, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        read = stream.Read(bytes, offset, _blockSize - offset);
                    }
                    offset += read;
                    absolutePosition += read;
                } while (offset < _minimumBlockFill && read != 0);

                if (offset != 0)
                {
                    yield return new StreamPartition(absolutePosition, bytes, offset, _arrayPool);
                }
                else
                {
                    // return the block immediately
                    _arrayPool.Return(bytes);
                }

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
