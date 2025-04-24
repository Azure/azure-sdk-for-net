// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Shared
{
    /// <summary>
    /// Functions like a readable <see cref="MemoryStream"/> but uses an ArrayPool to supply the backing memory.
    /// This stream support buffering long sizes.
    /// </summary>
    internal class PooledMemoryStream : Stream
    {
        private class BufferPartition
        {
            /// <summary>
            /// The buffer for this partition.
            /// </summary>
            public byte[] Buffer { get; set; }

            /// <summary>
            /// Offset at which known data stops and undefined state begins.
            /// </summary>
            public int DataLength { get; set; }
        }

        /// <summary>
        /// Size to rent from MemoryPool.
        /// </summary>
        private int _newBufferSize;

        /// <summary>
        /// The backing array pool.
        /// </summary>
        public ArrayPool<byte> ArrayPool { get; }

        /// <summary>
        /// List of arrays making up the overall buffer. Since ArrayPool may give us a larger array than needed,
        /// each array is paired with a count of the space actually used in the array. This <b>should</b> only
        /// be important for the final buffer.
        /// </summary>
        private List<BufferPartition> BufferSet { get; } = new List<BufferPartition>();

        /// <summary>
        /// Creates a new, empty memory stream based on the given ArrayPool.
        /// </summary>
        /// <param name="arrayPool">
        /// Pool to rent memory from.
        /// </param>
        /// <param name="bufferSize">
        /// Rental size for the individual buffers that will make up the total stream.
        /// </param>
        /// <param name="initialBufferSize">
        /// Size of an initial rental from the array pool. No initial buffer will be rented when default.
        /// </param>
        public PooledMemoryStream(ArrayPool<byte> arrayPool, int bufferSize, int? initialBufferSize = default)
        {
            ArrayPool = arrayPool;
            _newBufferSize = bufferSize;
            if (initialBufferSize.HasValue)
            {
                BufferSet.Add(new()
                {
                    Buffer = ArrayPool.Rent(initialBufferSize.Value),
                    DataLength = 0,
                });
            }
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => true;

        public override long Length => BufferSet.Sum(tuple => (long)tuple.DataLength);

        public override long Position { get; set; }

        public override void Flush()
        {
            // no-op, just like MemoryStream
        }

        public override int Read(byte[] buffer, int offset, int count)
            => ReadImpl(new Span<byte>(buffer, offset, count));

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            => Task.FromResult(ReadImpl(new Span<byte>(buffer, offset, count)));

#if NETCOREAPP3_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        public override int Read(Span<byte> buffer)
            => ReadImpl(buffer);

        public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
            => new(ReadImpl(buffer.Span));
#endif

        private int ReadImpl(Span<byte> destBuffer)
        {
            if (Position >= Length)
            {
                return 0;
            }

            int read = 0;
            while (read < destBuffer.Length && Position < Length)
            {
                (byte[] currentBuffer, int bufferCount, long offsetOfBuffer) = GetBufferFromPosition();

                int toCopy = (int)Min(
                    Length - Position,
                    bufferCount - (Position - offsetOfBuffer),
                    destBuffer.Length - read);
                new Span<byte>(currentBuffer, (int)(Position - offsetOfBuffer), toCopy).CopyTo(destBuffer.Slice(read));
                read += toCopy;
                Position += toCopy;
            }

            return read;
        }

        public override int ReadByte()
        {
            if (Position >= Length)
            {
                return -1;
            }

            (byte[] currentBuffer, int _, long offsetOfBuffer) = GetBufferFromPosition();

            byte result = currentBuffer[Position - offsetOfBuffer];
            Position += 1;

            return result;
        }

        /// <summary>
        /// According the the current <see cref="Position"/> of the stream, gets the correct buffer containing the byte
        /// at that position, as well as the stream position represented by the start of the array.
        /// Position - offsetOfBuffer is the index in the returned array of the current byte.
        /// </summary>
        /// <returns></returns>
        private (byte[] CurrentBuffer, int BufferCount, long OffsetOfBuffer) GetBufferFromPosition()
        {
            AssertPositionInBounds();

            long countingPosition = 0;
            foreach (var tuple in BufferSet)
            {
                if (countingPosition + tuple.DataLength <= Position)
                {
                    countingPosition += tuple.DataLength;
                }
                else
                {
                    return (tuple.Buffer, tuple.DataLength, countingPosition);
                }
            }

            /* this.Length is defined as the sum of all counts.
             * We already throw if this.Position >= this.Length.
             * We can only get here if this.Position is >= the sum of all counts.
             * We will never get here. */
            throw new InvalidOperationException("Incorrect stream partition length.");
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
            => WriteImpl(new ReadOnlySpan<byte>(buffer, offset, count));

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            WriteImpl(new ReadOnlySpan<byte>(buffer, offset, count));
            return Task.CompletedTask;
        }

#if NETCOREAPP3_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        public override void Write(ReadOnlySpan<byte> buffer)
            => WriteImpl(buffer);

        public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
        {
            WriteImpl(buffer.Span);
            return new ValueTask(Task.CompletedTask);
        }
#endif

        private void WriteImpl(ReadOnlySpan<byte> writeBuffer)
        {
            while (writeBuffer.Length > 0)
            {
                BufferPartition currentBuffer = GetLatestBufferWithAvailableSpaceOrDefault();

                if (currentBuffer == default)
                {
                    byte[] newBytes = ArrayPool.Rent(_newBufferSize);
                    currentBuffer = new BufferPartition
                    {
                        Buffer = newBytes,
                        DataLength = 0
                    };
                    BufferSet.Add(currentBuffer);
                }

                int copied = Math.Min(currentBuffer.Buffer.Length - currentBuffer.DataLength, writeBuffer.Length);
                writeBuffer.Slice(0, Math.Min(copied, writeBuffer.Length)).CopyTo(new Span<byte>(currentBuffer.Buffer, currentBuffer.DataLength, copied));
                currentBuffer.DataLength += copied;
                Position += copied;
                writeBuffer = writeBuffer.Slice(copied);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Clear();
        }

        public void Clear()
        {
            foreach (BufferPartition buffer in BufferSet)
            {
                ArrayPool.Return(buffer.Buffer);
            }
            BufferSet.Clear();
            Position = 0;
        }

        private void AssertPositionInBounds()
        {
            if (Position >= Length || Position < 0)
            {
                throw new InvalidOperationException("Cannot read outside the bounds of this stream.");
            }
        }

        private BufferPartition GetLatestBufferWithAvailableSpaceOrDefault()
        {
            BufferPartition latestBuffer = BufferSet.LastOrDefault();

            if (latestBuffer == default || latestBuffer.DataLength >= latestBuffer.Buffer.Length)
            {
                return default;
            }

            return latestBuffer;
        }

        private static long Min(long val1, long val2, long val3)
        {
            long result = Math.Min(val1, val2);
            result = Math.Min(result, val3);

            return result;
        }
    }
}
