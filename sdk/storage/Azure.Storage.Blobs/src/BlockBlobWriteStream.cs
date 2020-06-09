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
    internal class BlockBlobWriteStream : WriteStream
    {
        private readonly BlockBlobClient _blockBlobClient;
        private readonly BlobRequestConditions _conditions;
        private readonly List<string> _blockIds;

        public BlockBlobWriteStream(
            BlockBlobClient blockBlobClient,
            int bufferSize,
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

        protected override async Task WriteInternal(bool async, byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            ValidateWriteParameters(buffer, offset, count);
            int remaining = count;

            // New bytes will fit in the buffer.
            if (count <= _buffer.Capacity - _buffer.Position)
            {
                await WriteToBuffer(async, buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                // Flush the buffer.
                await AppendInternal(async, cancellationToken).ConfigureAwait(false);

                while (remaining > 0)
                {
                    await WriteToBuffer(
                        async,
                        buffer,
                        offset,
                        Math.Min(remaining, _buffer.Capacity),
                        cancellationToken).ConfigureAwait(false);

                    // Renaming bytes won't fit in buffer.
                    if (remaining > _buffer.Capacity)
                    {
                        await AppendInternal(async, cancellationToken).ConfigureAwait(false);
                        remaining -= _buffer.Capacity;
                        offset += _buffer.Capacity;
                    }

                    // Remaining bytes will fit in buffer.
                    else
                    {
                        remaining = 0;
                    }
                }
            }
            _position += count;
        }

        protected override async Task AppendInternal(bool async, CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                string blockId = GenerateBlockId();

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
                _buffer.SetLength(0);
            }
        }

        protected override async Task FlushInternal(bool async, CancellationToken cancellationToken)
        {
            await AppendInternal(async, cancellationToken).ConfigureAwait(false);

            if (async)
            {
                await _blockBlobClient.CommitBlockListAsync(
                    base64BlockIds: _blockIds,
                    conditions: _conditions,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                _blockBlobClient.CommitBlockList(
                    base64BlockIds: _blockIds,
                    conditions: _conditions,
                    cancellationToken: cancellationToken);
            }
        }

        protected override void ValidateBufferSize(int bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be >= 1");
            }

            if (bufferSize > 100 * Constants.MB)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must <= 100 MB");
            }
        }

        private static string GenerateBlockId()
        {
            Guid guid = Guid.NewGuid();
            byte[] bytes = Encoding.UTF8.GetBytes(guid.ToString());
            return Convert.ToBase64String(bytes);
        }
    }
}
