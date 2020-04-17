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
            public byte[] Buffer { get; set; }
            public int Count { get; set; }
        }

        /// <summary>
        /// Boundary at which point we start requesting multiple arrays for our buffer.
        /// </summary>
        public int MaxArraySize { get; }

        /// <summary>
        /// The backing array pool.
        /// </summary>
        public ArrayPool<byte> ArrayPool { get; }

        /// <summary>
        /// Absolute position of this stream in the larger stream it was chunked from.
        /// </summary>
        public long AbsolutePosition { get; }

        /// <summary>
        /// List of arrays making up the overall buffer. Since ArrayPool may give us a larger array than needed,
        /// each array is paired with a count of the space actually used in the array. This <b>should</b> only
        /// be important for the final buffer.
        /// </summary>
        private List<(byte[] Buffer, int Count)> BufferSet { get; } = new List<(byte[], int)>();

        private PooledMemoryStream(ArrayPool<byte> arrayPool, long absolutePosition, int maxArraySize)
        {
            AbsolutePosition = absolutePosition;
            ArrayPool = arrayPool;
            MaxArraySize = maxArraySize;
        }

        /// <summary>
        /// Buffers a portion of the given stream, returning the buffered stream partition.
        /// </summary>
        /// <param name="stream">Stream to buffer from.</param>
        /// <param name="count">Maximum number of bytes to buffer.</param>
        /// <param name="absolutePosition">Current position of the stream, since <see cref="Stream.Position"/> throws if not seekable.</param>
        /// <param name="arrayPool">Pool to rent buffer space from.</param>
        /// <param name="maxArrayPoolRentalSize">Max size we can request from the array pool.</param>
        /// <param name="async">Whether to perform this operation asynchronously</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The buffered stream partition with memory backed by an array pool.</returns>
        internal static async Task<PooledMemoryStream> BufferStreamPartitionInternal(Stream stream, long count, long absolutePosition, ArrayPool<byte> arrayPool, int maxArrayPoolRentalSize, bool async, CancellationToken cancellationToken)
        {
            int totalRead = 0;
            var streamPartition = new PooledMemoryStream(arrayPool, absolutePosition, maxArrayPoolRentalSize);

            while (totalRead < count)
            {
                var array = arrayPool.Rent((int)Math.Min(count - totalRead, streamPartition.MaxArraySize));
                // array might be larger than what was requested; must recalculate how much to read
                int read = await ReadLoopInternal(stream, array, (int)Math.Min(array.Length, count - totalRead), async, cancellationToken).ConfigureAwait(false);
                if (read == 0) // stream fininished and didn't put anything in the array
                {
                    arrayPool.Return(array);
                    break;
                }

                streamPartition.BufferSet.Add((array, read));
                totalRead += read;
            }

            return streamPartition;
        }

        /// <summary>
        /// Loops Read() calls until count is reached or stream returns 0.
        /// </summary>
        /// <returns>Bytes read.</returns>
        private static async Task<int> ReadLoopInternal(Stream stream, byte[] array, int count, bool async, CancellationToken cancellationToken)
        {
            int totalRead = 0;
            while (totalRead < count)
            {
                int read = async
                    ? await stream.ReadAsync(array, totalRead, count - totalRead, cancellationToken).ConfigureAwait(false)
                    : stream.Read(array, totalRead, count - totalRead);
                if (read == 0)
                {
                    break;
                }
                totalRead += read;
            }

            return totalRead;
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => BufferSet.Sum(tuple => tuple.Count);

        public override long Position { get; set; }

        public override void Flush()
        {
            // no-op, just like MemoryStream
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            AssertPositionInBounds();

            int read = 0;
            while (read < count && Position < Length)
            {
                (byte[] currentBuffer, int bufferCount, long offsetOfBuffer) = GetBufferFromPosition();

                int toCopy = (int)Math.Min(Math.Min(Length - Position, bufferCount), count);
                Array.Copy(currentBuffer, Position - offsetOfBuffer, buffer, read, toCopy);
                read += toCopy;
                Position += toCopy;
            }

            return read;
        }

        private (byte[] currentBuffer, int bufferCount, long offsetOfBuffer) GetBufferFromPosition()
        {
            AssertPositionInBounds();

            long countingPosition = 0;
            foreach (var tuple in BufferSet)
            {
                if (countingPosition + tuple.Count <= Position)
                {
                    countingPosition += tuple.Count;
                }
                else
                {
                    return (tuple.Buffer, tuple.Count, countingPosition);
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
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            foreach ((var array, _) in BufferSet)
            {
                ArrayPool.Return(array);
            }
            BufferSet.Clear();
        }

        private void AssertPositionInBounds()
        {
            if (Position >= Length || Position < 0)
            {
                throw new InvalidOperationException("Cannot read outside the bounds of this stream.");
            }
        }
    }
}
