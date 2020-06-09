// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    internal class AppendBlobWriteStream : WriteStream
    {
        private readonly AppendBlobClient _appendBlobClient;
        private readonly AppendBlobRequestConditions _conditions;
        private readonly IProgress<long> _progressHandler;
        private readonly MemoryStream _buffer;

        public AppendBlobWriteStream(
            AppendBlobClient appendBlobClient,
            int bufferSize,
            long position,
            AppendBlobRequestConditions conditions = default,
            IProgress<long> progressHandler = default) : base(position)
        {
            ValidateBufferSize(bufferSize);
            _appendBlobClient = appendBlobClient;
            _conditions = conditions;
            _progressHandler = progressHandler;
            _buffer = new MemoryStream(bufferSize);
        }

        protected override async Task WriteInternal(
            bool async,
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
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
                    await WriteToBuffer(async, buffer, offset, Math.Min(remaining, _buffer.Capacity), cancellationToken).ConfigureAwait(false);

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

        protected override async Task FlushInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            if (_buffer.Length > 0)
            {
                _buffer.Position = 0;

                if (async)
                {
                    await _appendBlobClient.AppendBlockAsync(
                        _buffer,
                        conditions: _conditions,
                        progressHandler: _progressHandler,
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _appendBlobClient.AppendBlock(
                        _buffer,
                        conditions: _conditions,
                        progressHandler: _progressHandler,
                        cancellationToken: cancellationToken);
                }
            }

            _buffer.SetLength(0);
        }

        private async Task WriteToBuffer(
            bool async,
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
        {
            if (async)
            {
                await _buffer.WriteAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _buffer.Write(buffer, offset, count);
            }
        }

        private static void ValidateBufferSize(int bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be >= 1");
            }

            if (bufferSize > 4 * Constants.MB)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must <= 4 MB");
            }
        }
    }
}
