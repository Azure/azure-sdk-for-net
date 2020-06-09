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
    internal class PageBlobWriteStream : WriteStream
    {
        private readonly PageBlobClient _pageBlobClient;
        private readonly PageBlobRequestConditions _conditions;
        private long _writeIndex;

        public PageBlobWriteStream(
            PageBlobClient pageBlobClient,
            int bufferSize,
            long position,
            PageBlobRequestConditions conditions,
            IProgress<long> progressHandler) : base(
                position,
                bufferSize,
                progressHandler)
        {
            ValidateBufferSize(bufferSize);
            _pageBlobClient = pageBlobClient;
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
                // We need a multiple of 512 to flush.
                if (_buffer.Length % 512 != 0)
                {
                    int bytesToWrite = (int)(512 - _buffer.Length % 512);
                    await WriteToBuffer(async, buffer, offset, bytesToWrite, cancellationToken).ConfigureAwait(false);
                    remaining -= bytesToWrite;
                    offset += bytesToWrite;
                }

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

                if (async)
                {
                    await _pageBlobClient.UploadPagesAsync(
                        _buffer,
                        _writeIndex,
                        conditions: _conditions,
                        progressHandler: _progressHandler,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    _pageBlobClient.UploadPages(
                        _buffer,
                        _writeIndex,
                        conditions: _conditions,
                        progressHandler: _progressHandler,
                        cancellationToken: cancellationToken);
                }

                _writeIndex += _buffer.Length;
                _buffer.SetLength(0);
            }
        }

        protected override void ValidateBufferSize(int bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be >= 1");
            }

            if (bufferSize > 4 * Constants.MB)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must <= 4 MB");
            }

            if (bufferSize % 512 != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be a multiple of 512");
            }
        }
    }
}
