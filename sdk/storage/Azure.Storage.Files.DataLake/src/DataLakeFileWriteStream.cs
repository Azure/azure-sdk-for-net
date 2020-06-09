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
            int bufferSize,
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
                await FlushInternal(async, cancellationToken).ConfigureAwait(false);

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
                        await FlushInternal(async, cancellationToken).ConfigureAwait(false);
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

        private async Task AppendInternal(bool async, CancellationToken cancellationToken)
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
                _buffer.SetLength(0);
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

        protected override void ValidateBufferSize(int bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be >= 1");
            }

            if (bufferSize > 100 * Constants.MB)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must <= 4 MB");
            }
        }
    }
}
