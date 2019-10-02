// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage.Blobs.Cryptography.Models
{
    internal class RollingBufferStream : Stream
    {
        /// <summary>
        /// Stream to read from and buffer recent data.
        /// </summary>
        private readonly Stream _underlyingStream;

        /// <summary>
        /// How many bytes have been read from the underlying stream.
        /// </summary>
        private long _underlyingStreamBytesRead = 0;

        /// <summary>
        /// The rolling buffer to hold the last <see cref="BufferSize"/>-many bytes read from the underlying stream.
        /// </summary>
        private readonly byte[] _rollingBuffer;

        /// <summary>
        /// Index of last byte read from buffer.
        /// </summary>
        private int _rollingBufferPos = 0;

        /// <summary>
        /// The index where the sequential data begins.
        /// </summary>
        private int _rollingBufferBreakPos = 0;

        /// <summary>
        /// Size of the buffer in bytes.
        /// </summary>
        public int BufferSize => _rollingBuffer.Length;

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _underlyingStreamBytesRead;

        private long _position = 0;
        public override long Position
        {
            get => _position;
            set => throw new System.NotImplementedException();
        }

        public RollingBufferStream(Stream stream, int bufferSize)
        {
            this._underlyingStream = stream;
            this._rollingBuffer = new byte[BufferSize];
        }

        public override void Flush()
        {
            throw new System.NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalRead = 0;

            // read pre-buffered bytes if we've rewound and not caught up

            // wrap-around read; read bytes at end of array if necessary
            if (_rollingBufferPos + 1 < BufferSize                 // not at end of array
                && _rollingBufferPos + 1 != _rollingBufferBreakPos // not caught up with buffer
                &&_rollingBufferPos >= _rollingBufferBreakPos)     // might need to cross the loop
            {
                var readFromBufferEnd = Math.Min(BufferSize - _rollingBufferPos - 1, count);
                totalRead += readFromBufferEnd;
                Array.Copy(_rollingBuffer, _rollingBufferPos + 1, buffer, offset, readFromBufferEnd);
                _rollingBufferPos += readFromBufferEnd;

                // read all we needed to
                if (totalRead == count)
                {
                    return totalRead;
                }
            }
            // not caught up but no more loop to cross
            if ((_rollingBufferPos + 1) % BufferSize != _rollingBufferBreakPos)
            {
                var readFromBufferStart = Math.Min(_rollingBufferBreakPos, count - totalRead);
                totalRead += readFromBufferStart;
                Array.Copy(_rollingBuffer, (_rollingBufferPos + 1) % BufferSize,
                    buffer, offset + totalRead, readFromBufferStart);
                _rollingBufferPos = (_rollingBufferPos + readFromBufferStart) % BufferSize;

                // read all we needed to
                if (totalRead == count)
                {
                    return totalRead;
                }
            }

            // caught up; read bytes from underlying stream

            var liveStartingPoint = totalRead;
            var bytesReadFromStream = _underlyingStream.Read(buffer, liveStartingPoint, count - liveStartingPoint);
            _underlyingStreamBytesRead += bytesReadFromStream;
            totalRead += bytesReadFromStream;

            // save new bytes in rolling buffer

            // shortcut when we read more bytes at once than the buffer can hold
            if (bytesReadFromStream >= BufferSize)
            {
                // write the last BufferSize bytes read to the buffer and reset index pointers accordingly
                Array.Copy(buffer, bytesReadFromStream - BufferSize, _rollingBuffer, 0, BufferSize);
                _rollingBufferPos = BufferSize - 1;
                _rollingBufferBreakPos = 0;
                _position = _underlyingStreamBytesRead;
            }
            // wrap-around write
            else if ()
            {

            }

            // if bufferPos is at the "end" of the rolling buffer
            //else if ((_rollingBufferPos + 1) % BufferSize == _rollingBufferBreakPos)
            {
                
            }

            return bytesReadFromStream;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new System.NotImplementedException();
        }

        public override void SetLength(long value) => throw new System.NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) => throw new System.NotSupportedException();
    }
}
