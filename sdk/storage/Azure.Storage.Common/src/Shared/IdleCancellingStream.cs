// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    internal class IdleCancellingStream : Stream
    {
        /// <summary>
        /// The <see cref="Stream"/> wrapped stream that is being read or written to.
        /// </summary>
        private readonly Stream _stream;

        /// <summary>
        /// A <see cref="System.Threading.CancellationToken"/> which fires if the stream has
        /// not been read from or written to within the idle timeout.
        /// </summary>
        public CancellationToken CancellationToken => _cancellationTokenSource.Token;

        private readonly int _maxIdleTimeInMs;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position
        {
            get => _stream.Position;
            set => _stream.Position = value;
        }

        public override int ReadTimeout
        {
            get => _stream.ReadTimeout;
            set => _stream.ReadTimeout = value;
        }

        public override int WriteTimeout
        {
            get => _stream.WriteTimeout;
            set => _stream.WriteTimeout = value;
        }

        public IdleCancellingStream(Stream downloadStream, int maxIdleTimeInMs)
        {
            _stream = downloadStream;
            _maxIdleTimeInMs = maxIdleTimeInMs;
            _cancellationTokenSource = new CancellationTokenSource(_maxIdleTimeInMs);
        }

        public override long Seek(long offset, SeekOrigin origin) => _stream.Seek(offset, origin);

        public override void SetLength(long value) => _stream.SetLength(value);

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            _cancellationTokenSource.CancelAfter(_maxIdleTimeInMs);
            return _stream.CopyToAsync(destination, bufferSize, cancellationToken);
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            _cancellationTokenSource.CancelAfter(_maxIdleTimeInMs);
            return _stream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            _cancellationTokenSource.CancelAfter(_maxIdleTimeInMs);
            return _stream.Read(buffer, offset, count);
        }

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            _cancellationTokenSource.CancelAfter(_maxIdleTimeInMs);
            return _stream.WriteAsync(buffer, offset, count, cancellationToken);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _cancellationTokenSource.CancelAfter(_maxIdleTimeInMs);
            _stream.Write(buffer, offset, count);
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.CancelAfter(_maxIdleTimeInMs);
            return _stream.FlushAsync(cancellationToken);
        }

        public override void Flush()
        {
            _cancellationTokenSource.CancelAfter(_maxIdleTimeInMs);
            _stream.Flush();
        }

        public override void Close() => _cancellationTokenSource.Dispose();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // this.stream.Dispose(); // We don't dispose of the inner stream, because we didn't create it.
                _cancellationTokenSource.Dispose();
            }
        }
    }
}
