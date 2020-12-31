// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage.Tests.Shared
{
    /// <summary>
    /// Stream who's byte at position n is n % <see cref="byte.MaxValue"/>.
    /// Note this means we have 255 possibilities, not 256, giving variation at likely buffer boundaries.
    /// </summary>
    internal class PredictableStream : Stream
    {
        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        private readonly bool _revealsLength;
        private readonly long? _length;
        public override long Length => _revealsLength
            ? _length ?? throw new NotSupportedException()
            : throw new NotSupportedException();

        public override long Position { get; set; } = 0;

        public PredictableStream(long? length = default, bool revealsLength = true)
        {
            _length = length;
            _revealsLength = revealsLength;
        }

        public override void Flush()
        { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int toRead = _length.HasValue
                ? (int)Math.Min(count, _length.Value - Position)
                : count;
            for (int i = 0; i < toRead; i++)
            {
                buffer[offset + i] = (byte)((Position + i) % byte.MaxValue);
            }

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
