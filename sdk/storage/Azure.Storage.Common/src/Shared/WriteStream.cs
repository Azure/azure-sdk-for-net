// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Shared
{
    internal abstract class WriteStream : Stream
    {
        protected long _position;
        protected readonly IProgress<long> _progressHandler;
        protected readonly MemoryStream _buffer;

        protected WriteStream(
            long position,
            int bufferSize,
            IProgress<long> progressHandler)
        {
            _position = position;
            _progressHandler = progressHandler;
            _buffer = new MemoryStream(bufferSize);
        }

        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => throw new NotSupportedException();

        public override long Position { get => _position; set => throw new NotSupportedException(); }

        public override int Read(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(
            byte[] buffer,
            int offset,
            int count)
            => WriteInternal(
                async: false,
                buffer,
                offset,
                count,
                cancellationToken: default)
            .EnsureCompleted();

        public override async Task WriteAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
            => await WriteInternal(
                async: true,
                buffer,
                offset,
                count,
                cancellationToken)
            .ConfigureAwait(false);

        protected abstract Task WriteInternal(
            bool async,
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken);

        public override void Flush()
            => FlushInternal(
                async: false,
                cancellationToken: default).EnsureCompleted();

        public override async Task FlushAsync(CancellationToken cancellationToken)
            => await FlushInternal(
                async: true,
                cancellationToken).ConfigureAwait(false);

        protected abstract Task FlushInternal(bool async, CancellationToken cancellationToken);

        protected abstract void ValidateBufferSize(int bufferSize);

        protected async Task WriteToBuffer(
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

        protected static void ValidateWriteParameters(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException($"{nameof(buffer)}", $"{nameof(buffer)} cannot be null.");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} cannot be less than 0.");
            }

            if (offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} cannot exceed {nameof(buffer)} length.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(count)} cannot be less than 0.");
            }

            if (offset + count > buffer.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} + {nameof(count)} cannot exceed {nameof(buffer)} length.");
            }
        }
    }
}
