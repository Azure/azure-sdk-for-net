// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeFileWriteStream : StorageWriteStream
    {
        private readonly DataLakeFileClient _fileClient;
        private readonly DataLakeRequestConditions _conditions;
        private readonly bool? _closeEvent;
        private long _writeIndex;

        public DataLakeFileWriteStream(
            DataLakeFileClient fileClient,
            long bufferSize,
            long position,
            DataLakeRequestConditions conditions,
            IProgress<long> progressHandler,
            UploadTransferValidationOptions validationOptions,
            bool? closeEvent) : base(
                position,
                bufferSize,
                progressHandler,
                transferValidation: validationOptions
                )
        {
            ValidateBufferSize(bufferSize);
            _fileClient = fileClient;
            _conditions = conditions ?? new DataLakeRequestConditions();
            _writeIndex = position;
            _closeEvent = closeEvent;
        }

        protected override async Task AppendInternal(bool async, CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                await _fileClient.AppendInternal(
                    content: _buffer,
                    offset: _writeIndex,
                    validationOptionsOverride: _validationOptions,
                    leaseId: _conditions.LeaseId,
                    leaseAction: null,
                    leaseDuration: null,
                    proposedLeaseId: null,
                    progressHandler: _progressHandler,
                    flush: null,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                _writeIndex += _buffer.Length;
                _buffer.Clear();
            }
        }

        protected override async Task FlushInternal(bool async, CancellationToken cancellationToken)
        {
            await AppendInternal(async, cancellationToken).ConfigureAwait(false);

            Response<PathInfo> response = await _fileClient.FlushInternal(
                position: _writeIndex,
                retainUncommittedData: default,
                close: _closeEvent,
                httpHeaders: default,
                conditions: _conditions,
                leaseAction: null,
                leaseDuration: null,
                proposedLeaseId: null,
                async: async,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            _conditions.IfMatch = response.Value.ETag;
        }

        protected override void ValidateBufferSize(long bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be >= 1");
            }

            if (bufferSize > Constants.DataLake.MaxAppendBytes)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), $"Must <= {Constants.DataLake.MaxAppendBytes}");
            }
        }
    }
}
