// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Wraps a stream, and reports position updates to a progress incrementer
    /// </summary>
    internal class ProgressIncrementingStream : Stream
    {
        private readonly Stream _innerStream;
        private readonly AggregatingProgressIncrementer _incrementer;

        public ProgressIncrementingStream(Stream stream, AggregatingProgressIncrementer incrementer)
        {
            _innerStream = stream ?? throw Errors.ArgumentNull(nameof(stream));
            _incrementer = incrementer ?? throw Errors.ArgumentNull(nameof(incrementer));
        }

        public override bool CanRead => _innerStream.CanRead;

        public override bool CanSeek => _innerStream.CanSeek;

        public override bool CanTimeout => _innerStream.CanTimeout;

        public override bool CanWrite => _innerStream.CanWrite;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _innerStream.Dispose();
        }

        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            var oldPosition = _innerStream.Position;

            await _innerStream.FlushAsync(cancellationToken).ConfigureAwait(false);

            var newPosition = _innerStream.Position;

            _incrementer.Report(newPosition - oldPosition);
        }

        public override void Flush()
        {
            var oldPosition = _innerStream.Position;

            _innerStream.Flush();

            var newPosition = _innerStream.Position;

            _incrementer.Report(newPosition - oldPosition);
        }

        public override long Length => _innerStream.Length;

        public override long Position
        {
            get => _innerStream.Position;

            set
            {
                var delta = value - _innerStream.Position;

                _innerStream.Position = value;

                _incrementer.Report(delta);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var n = _innerStream.Read(buffer, offset, count);
            _incrementer.Report(n);
            return n;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var n = await _innerStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            _incrementer.Report(n);
            return n;
        }

        public override int ReadByte()
        {
            var b = _innerStream.ReadByte();

            if (b != -1) // -1 = end of stream sentinel
            {
                _incrementer.Report(1);
            }

            return b;
        }

        public override int ReadTimeout
        {
            get => _innerStream.ReadTimeout;

            set => _innerStream.ReadTimeout = value;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            var oldPosition = _innerStream.Position;

            var newPosition = _innerStream.Seek(offset, origin);

            _incrementer.Report(newPosition - oldPosition);

            return newPosition;
        }

        public override void SetLength(long value) => _innerStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count)
        {
            _innerStream.Write(buffer, offset, count);

            _incrementer.Report(count);
        }

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await _innerStream.WriteAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);

            _incrementer.Report(count);
        }

        public override void WriteByte(byte value)
        {
            _innerStream.WriteByte(value);

            _incrementer.Report(1);
        }

        public override int WriteTimeout
        {
            get => _innerStream.WriteTimeout;

            set => _innerStream.WriteTimeout = value;
        }
    }
}
