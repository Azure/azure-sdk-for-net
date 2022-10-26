// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    internal class PageBlobWriteStream : StorageWriteStream
    {
        private readonly PageBlobClient _pageBlobClient;
        private readonly PageBlobRequestConditions _conditions;
        private long _writeIndex;

        public PageBlobWriteStream(
            PageBlobClient pageBlobClient,
            long bufferSize,
            long position,
            PageBlobRequestConditions conditions,
            IProgress<long> progressHandler,
            UploadTransferValidationOptions transferValidation
            ) : base(
                position,
                bufferSize,
                progressHandler,
                transferValidation
                )
        {
            ValidateBufferSize(bufferSize);
            ValidatePosition(position);
            _pageBlobClient = pageBlobClient;
            _conditions = conditions ?? new PageBlobRequestConditions();
            _writeIndex = position;
        }

        protected override async Task WriteInternal(
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            ValidateWriteParameters(buffer, offset, count);
            int remaining = count;

            // New bytes will fit in the buffer.
            if (count <= _bufferSize - _buffer.Position)
            {
                await WriteToBufferInternal(buffer, offset, count, async, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                // We need a multiple of 512 to flush.
                if (_buffer.Length % Constants.Blob.Page.PageSizeBytes != 0)
                {
                    int bytesToWrite = (int)(Constants.Blob.Page.PageSizeBytes - _buffer.Length % Constants.Blob.Page.PageSizeBytes);
                    await WriteToBufferInternal(buffer, offset, bytesToWrite, async, cancellationToken).ConfigureAwait(false);
                    remaining -= bytesToWrite;
                    offset += bytesToWrite;
                }

                // Flush the buffer.
                await AppendInternal(async, cancellationToken).ConfigureAwait(false);

                while (remaining > 0)
                {
                    await WriteToBufferInternal(
                        buffer,
                        offset,
                        (int)Math.Min(remaining, _bufferSize),
                        async,
                        cancellationToken).ConfigureAwait(false);

                    // Remaining bytes won't fit in buffer.
                    if (remaining > _bufferSize)
                    {
                        await AppendInternal(async, cancellationToken).ConfigureAwait(false);
                        remaining -= (int)_bufferSize;
                        offset += (int)_bufferSize;
                    }

                    // Remaining bytes will fit in buffer.
                    else
                    {
                        remaining = 0;
                    }
                }
            }
        }

        protected override async Task AppendInternal(bool async, CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                Response<PageInfo> response = await _pageBlobClient.UploadPagesInternal(
                    content: _buffer,
                    offset: _writeIndex,
                    _validationOptions,
                    _conditions,
                    _progressHandler,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                _conditions.IfMatch = response.Value.ETag;

                _writeIndex += _buffer.Length;
                _buffer.Clear();
            }
        }

        protected override async Task FlushInternal(bool async, CancellationToken cancellationToken)
            => await AppendInternal(async, cancellationToken).ConfigureAwait(false);

        protected override void ValidateBufferSize(long bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be greater than or equal to 1");
            }

            if (bufferSize > 4 * Constants.MB)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), $"Must less than or equal to {Constants.DefaultBufferSize}");
            }

            if (bufferSize % 512 != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), $"Must be a multiple of {Constants.Blob.Page.PageSizeBytes}");
            }
        }

        private static void ValidatePosition(long position)
        {
            if (position % Constants.Blob.Page.PageSizeBytes != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position), $"Must be a multiple of {Constants.Blob.Page.PageSizeBytes}");
            }
        }
    }
}
