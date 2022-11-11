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
    internal class AppendBlobWriteStream : StorageWriteStream
    {
        private readonly AppendBlobClient _appendBlobClient;
        private readonly AppendBlobRequestConditions _conditions;

        public AppendBlobWriteStream(
            AppendBlobClient appendBlobClient,
            long bufferSize,
            long position,
            AppendBlobRequestConditions conditions,
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
            _appendBlobClient = appendBlobClient;
            _conditions = conditions ?? new AppendBlobRequestConditions();
        }

        protected override async Task AppendInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                Response<BlobAppendInfo> response = await _appendBlobClient.AppendBlockInternal(
                    content: _buffer,
                    _validationOptions,
                    _conditions,
                    _progressHandler,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                _conditions.IfMatch = response.Value.ETag;

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

            if (bufferSize > Constants.Blob.Append.MaxAppendBlockBytes)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), $"Must less than or equal to {Constants.Blob.Append.MaxAppendBlockBytes}");
            }
        }
    }
}
