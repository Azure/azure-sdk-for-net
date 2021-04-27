// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Internal.Avro
{
    /// <summary>
    /// Wrapper for HttpContentStream that provides the current position.
    /// </summary>
    internal class StreamWithPosition : Stream
    {
        /// <summary>
        /// Backing stream.
        /// </summary>
        private readonly Stream _stream;

        /// <summary>
        /// Position.
        /// </summary>
        private long _position;

        /// <summary>
        /// To detect redundant calls.
        /// </summary>
        private bool _disposed;

        public StreamWithPosition(
            Stream stream,
            long position = 0)
        {
            _stream = stream;
            _position = position;
        }

        /// <inheritdoc/>
        public override long Position
        {
            get => _position;
            set => throw new NotImplementedException();
        }

        public override int ReadByte()
        {
            int val = _stream.ReadByte();
            if (val != -1)
            {
                _position++;
            }
            return val;
        }

        /// <inheritdoc/>
        public override int Read(byte[] buffer,
            int offset,
            int count)
            => ReadInternal(
                buffer,
                offset,
                count,
                async: false,
                cancellationToken: default).EnsureCompleted();

        public override async Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
            => await ReadInternal(
                buffer,
                offset,
                count,
                async: true,
                cancellationToken).ConfigureAwait(false);

        private async Task<int> ReadInternal(
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            int read = async
                ? await _stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false)
                : _stream.Read(buffer, offset, count);

            _position += read;

            return read;
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _stream.BeginRead(buffer, offset, count, callback, state);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            var read = _stream.EndRead(asyncResult);
            _position += read;
            return read;
        }

        /// <inheritdoc/>
        public override bool CanRead
            => _stream.CanRead;

        /// <inheritdoc/>
        public override bool CanSeek
            => _stream.CanSeek;

        /// <inheritdoc/>
        public override bool CanWrite
            => _stream.CanWrite;

        /// <inheritdoc/>
        public override long Length
            => _stream.Length;

        /// <inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin)
            => _stream.Seek(offset, origin);

        /// <inheritdoc/>
        public override void SetLength(long value)
            => _stream.SetLength(value);

        /// <inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count)
            => _stream.Write(buffer, offset, count);

        /// <inheritdoc/>
        public override void Flush()
            => _stream.Flush();

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _stream.Dispose();
                _disposed = true;
            }
        }
    }
}
