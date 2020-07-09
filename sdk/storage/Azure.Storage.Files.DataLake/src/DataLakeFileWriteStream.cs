// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeFileWriteStream : WriteStream
    {
        private readonly DataLakeFileClient _fileClient;
        private readonly DataLakeRequestConditions _conditions;
        private long _writeIndex;

        public DataLakeFileWriteStream(
            DataLakeFileClient fileClient,
            long bufferSize,
            long position,
            DataLakeRequestConditions conditions,
            IProgress<long> progressHandler) : base(
                position,
                bufferSize,
                progressHandler)
        {
            ValidateBufferSize(bufferSize);
            _fileClient = fileClient;
            _conditions = conditions;
            _writeIndex = position;
        }

        protected override async Task AppendInternal(bool async, CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                if (async)
                {
                    await _fileClient.AppendAsync(
                        content: _buffer,
                        offset: _writeIndex,
                        leaseId: _conditions?.LeaseId,
                        progressHandler: _progressHandler,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    _fileClient.Append(
                        content: _buffer,
                        offset: _writeIndex,
                        leaseId: _conditions?.LeaseId,
                        progressHandler: _progressHandler,
                        cancellationToken: cancellationToken);
                }

                _writeIndex += _buffer.Length;
                _buffer.Clear();
            }
        }

        protected override async Task FlushInternal(bool async, CancellationToken cancellationToken)
        {
            await AppendInternal(async, cancellationToken).ConfigureAwait(false);

            if (async)
            {
                await _fileClient.FlushAsync(
                    position: _writeIndex,
                    conditions: _conditions,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                _fileClient.Flush(
                    position: _writeIndex,
                    conditions: _conditions,
                    cancellationToken: cancellationToken);
            }
        }

        protected override void ValidateBufferSize(long bufferSize)
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
    }
}
