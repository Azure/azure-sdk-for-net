// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Buffers;
using System.IO;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    internal class ReadOnlySequenceStream : Stream
    {
        private readonly ReadOnlySequence<byte> _sequence;
        private SequencePosition _position;

        public ReadOnlySequenceStream(ReadOnlySequence<byte> sequence)
        {
            _sequence = sequence;
            _position = _sequence.Start;
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var remain = _sequence.Slice(_position);
            var result = remain.Slice(0, Math.Min(count, remain.Length));
            _position = result.End;
            result.CopyTo(buffer.AsSpan(offset, count));
            return (int)result.Length;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    _position = _sequence.GetPosition(offset);
                    break;
                case SeekOrigin.End:
                    if (offset >= 0)
                    {
                        _position = _sequence.GetPosition(offset, _sequence.End);
                    }
                    if (offset < 0)
                    {
                        _position = _sequence.GetPosition(offset + _sequence.Length);
                    }
                    break;
                case SeekOrigin.Current:
                    if (offset >= 0)
                    {
                        _position = _sequence.GetPosition(offset, _position);
                    }
                    else
                    {
                        _position = _sequence.GetPosition(offset + Position);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _sequence.Length;

        public override long Position
        {
            get => _sequence.Slice(0, _position).Length;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _position = _sequence.GetPosition(value);
            }
        }
    }
}