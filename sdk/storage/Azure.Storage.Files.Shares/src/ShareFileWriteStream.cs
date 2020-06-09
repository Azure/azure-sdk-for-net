// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.Shares
{
    internal class ShareFileWriteStream : WriteStream
    {
        private readonly ShareFileClient _fileClient;
        private readonly ShareFileRequestConditions _conditions;
        private long _writeIndex;

        public ShareFileWriteStream(
            ShareFileClient fileClient,
            int bufferSize,
            long position,
            ShareFileRequestConditions conditions,
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

        protected override async Task AppendInternal(bool async, CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                HttpRange httpRange = new HttpRange(_writeIndex, _buffer.Length);

                if (async)
                {
                    await _fileClient.UploadRangeAsync(
                        range: httpRange,
                        content: _buffer,
                        progressHandler: _progressHandler,
                        conditions: _conditions,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    _fileClient.UploadRange(
                        range: httpRange,
                        content: _buffer,
                        progressHandler: _progressHandler,
                        conditions: _conditions,
                        cancellationToken: cancellationToken);
                }

                _writeIndex += _buffer.Length;
                _buffer.SetLength(0);
            }
        }

        protected override async Task FlushInternal(bool async, CancellationToken cancellationToken)
            => await AppendInternal(async, cancellationToken).ConfigureAwait(false);

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
