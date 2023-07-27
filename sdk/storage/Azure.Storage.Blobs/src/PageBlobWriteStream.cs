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

        protected override async Task AppendInternal(
            UploadTransferValidationOptions validationOptions,
            bool async,
            CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                Response<PageInfo> response = await _pageBlobClient.UploadPagesInternal(
                    content: _buffer,
                    offset: _writeIndex,
                    validationOptions,
                    _conditions,
                    _progressHandler,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                _conditions.IfMatch = response.Value.ETag;

                _writeIndex += _buffer.Length;
            }
        }

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
