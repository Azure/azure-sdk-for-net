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
        private readonly BlobHttpHeaders _blobHttpHeaders;
        private readonly IDictionary<string, string> _metadata;
        private readonly IDictionary<string, string> _tags;

        public BlockBlobWriteStream(
            BlockBlobClient blockBlobClient,
            long bufferSize,
            long position,
            BlobRequestConditions conditions,
            IProgress<long> progressHandler,
            BlobHttpHeaders blobHttpHeaders,
            IDictionary<string, string> metadata,
            IDictionary<string, string> tags,
            UploadTransferValidationOptions transferValidation
            ) : base(
                position,
                bufferSize,
                progressHandler,
                transferValidation
                )
        {
            ValidateBufferSize(bufferSize);
            _blockBlobClient = blockBlobClient;
            _conditions = conditions ?? new BlobRequestConditions();
            _blockIds = new List<string>();
            _blobHttpHeaders = blobHttpHeaders;
            _metadata = metadata;
            _tags = tags;
        }

        protected override async Task AppendInternal(
            UploadTransferValidationOptions validationOptions,
            bool async,
            CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                string blockId = Shared.StorageExtensions.GenerateBlockId(_position);

                // Stage Block only supports LeaseId.
                BlobRequestConditions conditions = null;
                if (_conditions != null)
                {
                    conditions = new BlobRequestConditions
                    {
                        LeaseId = _conditions.LeaseId
                    };
                }

                await _blockBlobClient.StageBlockInternal(
                    base64BlockId: blockId,
                    content: _buffer,
                    validationOptions,
                    conditions: conditions,
                    progressHandler: _progressHandler,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                _blockIds.Add(blockId);
            }
        }

        protected override async Task CommitInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            Response<BlobContentInfo> response = await _blockBlobClient.CommitBlockListInternal(
                base64BlockIds: _blockIds,
                blobHttpHeaders: _blobHttpHeaders,
                metadata: _metadata,
                tags: _tags,
                conditions: _conditions,
                accessTier: default,
                immutabilityPolicy: default,
                legalHold: default,
                async: async,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            _conditions.IfMatch = response.Value.ETag;
        }

        protected override void ValidateBufferSize(long bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be greater than 1");
            }

            if (bufferSize > Constants.Blob.Block.MaxStageBytes)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), $"Must be less than or equal to {Constants.Blob.Block.MaxStageBytes}");
            }
        }
    }
}
