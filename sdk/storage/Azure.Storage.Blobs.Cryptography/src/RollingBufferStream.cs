// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Common
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
        /// Index of the next byte to read from buffer
        /// </summary>
        private int _nextBufferBytePos = 0;

        /// <summary>
        /// Index of the byte reserved for splitting the buffer "start" from "end".
        /// </summary>
        private int _reservedBytePos = 0;

        /// <summary>
        /// Whether the buffer has been filled enough to begin rolling.
        /// </summary>
        private bool _hasFilled = false;

        /// <summary>
        /// Size of the buffer in bytes.
        /// </summary>
        public int BufferSize => _rollingBuffer.Length;

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        /// <summary>
        /// Expected length of the underlying stream.
        /// </summary>
        /// <remarks>
        /// This class is to wrap unseekable streams, which, by nature, do not have a length to read.
        /// </remarks>
        private long? _expectedLength;
        public override long Length => _expectedLength ?? _underlyingStreamBytesRead;

        public override long Position
        {
            // easy to calculate position of stream if we haven't rolled over buffer
            // otherwise, math based on buffer position and counter on underlying stream
            get => _hasFilled
                ? _underlyingStreamBytesRead - ((_reservedBytePos - _nextBufferBytePos + BufferSize) % BufferSize)
                : _nextBufferBytePos;
            // set read position within rolling buffer
            set
            {
                if (value < 0 ||
                    value < _underlyingStreamBytesRead - BufferSize + 1 ||
                    value > _underlyingStreamBytesRead)
                {
                    long bufferStartPosInclusive = _hasFilled
                        ? _underlyingStreamBytesRead - BufferSize + 1
                        : 0;
                    long bufferEndPosExclusive = _underlyingStreamBytesRead + 1;

                    throw Errors.SeekOutsideBufferRange(value, bufferStartPosInclusive, bufferEndPosExclusive);
                }

                _nextBufferBytePos = (int)(value % BufferSize);
            }
        }

        public RollingBufferStream(Stream stream, int bufferSize, long? expectedLength = default)
        {
            this._underlyingStream = stream;
            this._rollingBuffer = new byte[bufferSize];
            this._expectedLength = expectedLength;
        }

        public override void Flush()
        {
            /* https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.flush
             * In a class derived from Stream that doesn't support writing, Flush is typically implemented
             * as an empty method to ensure full compatibility with other Stream types since it's valid to
             * flush a read-only stream.
             */
        }

        public override int Read(byte[] buffer, int offset, int count)
            => ReadImplAsync(false, buffer, offset, count, cancellationToken: default).EnsureCompleted();

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            => await ReadImplAsync(true, buffer, offset, count, cancellationToken).ConfigureAwait(false);

        private async Task<int> ReadImplAsync(bool async, byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            int totalRead = 0;

            // 1. read pre-buffered bytes if we've rewound and not caught up

            // potential wraparound read
            if (_nextBufferBytePos > _reservedBytePos)
            {
                var bytesToRead = Math.Min(BufferSize - _nextBufferBytePos, count);
                Array.Copy(_rollingBuffer, _nextBufferBytePos, buffer, offset, bytesToRead);
                totalRead += bytesToRead;
                _nextBufferBytePos = (_nextBufferBytePos + bytesToRead) % BufferSize;

                // read all we needed to
                if (totalRead == count)
                {
                    return totalRead;
                }
            }
            // not caught up but no loop to cross
            if (_nextBufferBytePos < _reservedBytePos)
            {
                var bytesToRead = Math.Min(_reservedBytePos - _nextBufferBytePos, count - totalRead);
                Array.Copy(_rollingBuffer, _nextBufferBytePos, buffer, offset + totalRead, bytesToRead);
                totalRead += bytesToRead;
                _nextBufferBytePos += bytesToRead;

                // read all we needed to
                if (totalRead == count)
                {
                    return totalRead;
                }
            }
            // _nextBufferBytePos == _reservedBytePos --> read from stream, as outlined below

            // 2. caught up, but more needed; read bytes from underlying stream to caller-provided buffer

            // index of first byte in caller-provided `buffer` that needs to be saved to rolling buffer
            var newBytesBeginning = offset + totalRead;
            var unsavedStreamBytes = async
                ? await _underlyingStream
                    .ReadAsync(buffer, newBytesBeginning, count - totalRead, cancellationToken)
                    .ConfigureAwait(false)
                : _underlyingStream.Read(buffer, newBytesBeginning, count - totalRead);
            _underlyingStreamBytesRead += unsavedStreamBytes;
            totalRead += unsavedStreamBytes;

            // 3. save new bytes in rolling buffer

            // shortcut when we read more bytes at once than the rollong buffer can hold
            if (unsavedStreamBytes >= BufferSize)
            {
                // write the last BufferSize bytes read to the buffer and reset index pointers accordingly
                Array.Copy(buffer, newBytesBeginning + unsavedStreamBytes - (BufferSize - 1),
                    _rollingBuffer, 0, BufferSize - 1);
                _nextBufferBytePos = BufferSize - 1;
                _reservedBytePos = BufferSize - 1;
                _hasFilled = true;
            }
            // normal save
            else
            {
                // will write up to loop
                if (unsavedStreamBytes >= BufferSize - _reservedBytePos)
                {
                    var bytesToCopy = BufferSize - _reservedBytePos;
                    Array.Copy(buffer, newBytesBeginning, _rollingBuffer, _reservedBytePos, bytesToCopy);
                    _reservedBytePos = 0;
                    _nextBufferBytePos = 0;
                    newBytesBeginning += bytesToCopy;
                    unsavedStreamBytes -= bytesToCopy;
                    _hasFilled = true;
                }
                // haven't written everything, but no loop to cross
                if (unsavedStreamBytes > 0)
                {
                    var bytesToCopy = unsavedStreamBytes;
                    Array.Copy(buffer, newBytesBeginning, _rollingBuffer, _nextBufferBytePos, bytesToCopy);
                    _nextBufferBytePos = (_nextBufferBytePos + bytesToCopy) % BufferSize;
                    _reservedBytePos = _nextBufferBytePos;
                }
            }

            return totalRead;
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

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
    }
}
