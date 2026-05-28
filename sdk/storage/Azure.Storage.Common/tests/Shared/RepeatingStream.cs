// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage.Tests.Shared
{
    /// <summary>
    /// Stream with a defined buffer and length that loops over the buffer for
    /// a given read at any position. The byte at stream position n is
    /// buffer[n % buffer.Length].
    /// </summary>
    internal class RepeatingStream : Stream
    {
        private readonly ReadOnlyMemory<byte> _data;
        private readonly bool _revealsLength;
        private readonly long _length;

        public override bool CanRead => true;

        public override bool CanSeek => _revealsLength;

        public override bool CanWrite => false;
        public override long Length => _revealsLength
            ? _length
            : throw new NotSupportedException();

        public override long Position { get; set; } = 0;

        public RepeatingStream(int bufferSize, long streamLength, bool revealsLength)
        {
            var buf = new byte[bufferSize];
            new Random().NextBytes(buf);
            _data = new ReadOnlyMemory<byte>(buf);
            _length = streamLength;
            _revealsLength = revealsLength;
        }

        public override void Flush()
        { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (offset < 0 || offset > buffer.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            if (count < 0 || count > buffer.Length - offset)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            int dataOffset = (int) (Position % _data.Length);
            int toRead = (int)Math.Min(Math.Min(count, _length - Position), _data.Length - dataOffset);
            _data.Slice(dataOffset, toRead).CopyTo(new Memory<byte>(buffer, offset, count));

            Position += toRead;
            return toRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset;
                    break;
                case SeekOrigin.Current:
                    Position += offset;
                    break;
                case SeekOrigin.End:
                    Position = Length + offset;
                    break;
            }

            return Position;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
    }
}
