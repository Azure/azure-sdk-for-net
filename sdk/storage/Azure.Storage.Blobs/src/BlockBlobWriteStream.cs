// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    internal class BlockBlobWriteStream : StorageWriteStream
    {
        private readonly BlockBlobClient _blockBlobClient;
        private readonly BlobRequestConditions _conditions;
        private readonly List<string> _blockIds;

        public BlockBlobWriteStream(
            BlockBlobClient blockBlobClient,
            long bufferSize,
            long position,
            BlobRequestConditions conditions,
            IProgress<long> progressHandler) : base(
                position,
                bufferSize,
                progressHandler)
        {
            ValidateBufferSize(bufferSize);
            _blockBlobClient = blockBlobClient;
            _conditions = conditions;
            _blockIds = new List<string>();
        }

        protected override async Task AppendInternal(bool async, CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                string blockId = StorageExtensions.GenerateBlockId(_position + _buffer.Length);

                if (async)
                {
                    await _blockBlobClient.StageBlockAsync(
                        base64BlockId: blockId,
                        content: _buffer,
                        conditions: _conditions,
                        progressHandler: _progressHandler,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    _blockBlobClient.StageBlock(
                        base64BlockId: blockId,
                        content: _buffer,
                        conditions: _conditions,
                        progressHandler: _progressHandler,
                        cancellationToken: cancellationToken);
                }

                _blockIds.Add(blockId);
                _buffer.Clear();
            }
        }

        protected override async Task FlushInternal(bool async, CancellationToken cancellationToken)
        {
            await AppendInternal(async, cancellationToken).ConfigureAwait(false);

            await _blockBlobClient.CommitBlockListInternal(
                base64BlockIds: _blockIds,
                blobHttpHeaders: default,
                metadata: default,
                tags: default,
                conditions: _conditions,
                accessTier: default,
                async: async,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }

        protected override void ValidateBufferSize(long bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be >= 1");
            }

            if (bufferSize > Constants.Blob.Block.MaxStageBytes)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), $"Must <= {Constants.Blob.Block.MaxStageBytes}");
            }
        }
    }
}
