// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Test.Perf
{
    public class CircularStream : Stream
    {
        private readonly Stream _innerStream;
        private readonly long _length;

        private long _position;

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _length;

        public override long Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value < 0 || value > Length)
                {
                    throw new ArgumentException("Position must be between 0 and Length inclusive");
                }

                _position = value;
                _innerStream.Position = _position % _innerStream.Length;
            }
        }

        public CircularStream(Stream innerStream, long length)
        {
            _innerStream = innerStream;
            _length = length;
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var bytesAvailable = (Length - Position);
            var bytesToRead = (int)Math.Min((long)count, bytesAvailable);

            var bytesRead = _innerStream.Read(buffer, offset, bytesToRead);

            if (_innerStream.Position == _innerStream.Length)
            {
                _innerStream.Seek(0, SeekOrigin.Begin);
            }

            Position += bytesRead;

            return bytesRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            Position = origin switch
            {
                SeekOrigin.Begin => offset,
                SeekOrigin.End => Length - offset,
                SeekOrigin.Current => Position + offset,
                _ => throw new InvalidOperationException()
            };

            return Position;
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            _innerStream.Dispose();
            base.Dispose(disposing);
        }
    }
}
