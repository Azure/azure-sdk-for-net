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
    internal class PooledMemoryStream : SlicedStream
    {
        private const int DefaultMaxArrayPoolRentalSize = 128 * Constants.MB;

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
        public int MaxArraySize { get; }

        /// <summary>
        /// The backing array pool.
        /// </summary>
        public ArrayPool<byte> ArrayPool { get; }

        /// <summary>
        /// Absolute position of this stream in the larger stream it was chunked from.
        /// </summary>
        public override long AbsolutePosition { get; }

        /// <summary>
        /// List of arrays making up the overall buffer. Since ArrayPool may give us a larger array than needed,
        /// each array is paired with a count of the space actually used in the array. This <b>should</b> only
        /// be important for the final buffer.
        /// </summary>
        private List<BufferPartition> BufferSet { get; } = new List<BufferPartition>();

        public PooledMemoryStream(ArrayPool<byte> arrayPool, long absolutePosition, int maxArraySize)
        {
            AbsolutePosition = absolutePosition;
            ArrayPool = arrayPool;
            MaxArraySize = maxArraySize;
        }

        /// <summary>
        /// Parameterless constructor for mocking.
        /// </summary>
        public PooledMemoryStream() { }

        /// <summary>
        /// Buffers a portion of the given stream, returning the buffered stream partition.
        /// </summary>
        /// <param name="stream">
        /// Stream to buffer from.
        /// </param>
        /// <param name="minCount">
        /// Minimum number of bytes to buffer. This method will not return until at least this many bytes have been read from <paramref name="stream"/> or the stream completes.
        /// </param>
        /// <param name="maxCount">
        /// Maximum number of bytes to buffer.
        /// </param>
        /// <param name="absolutePosition">
        /// Current position of the stream, since <see cref="Stream.Position"/> throws if not seekable.
        /// </param>
        /// <param name="arrayPool">
        /// Pool to rent buffer space from.
        /// </param>
        /// <param name="maxArrayPoolRentalSize">
        /// Max size we can request from the array pool.
        /// </param>
        /// <param name="async">
        /// Whether to perform this operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The buffered stream partition with memory backed by an array pool.
        /// </returns>
        internal static async Task<PooledMemoryStream> BufferStreamPartitionInternal(
            Stream stream,
            long minCount,
            long maxCount,
            long absolutePosition,
            ArrayPool<byte> arrayPool,
            int? maxArrayPoolRentalSize,
            bool async,
            CancellationToken cancellationToken)
        {
            long totalRead = 0;
            var streamPartition = new PooledMemoryStream(arrayPool, absolutePosition, maxArrayPoolRentalSize ?? DefaultMaxArrayPoolRentalSize);

            // max count to write into a single array
            int maxCountIndividualBuffer;
            // min count to write into a single array
            int minCountIndividualBuffer;
            // the amount that was written into the current array
            int readIndividualBuffer;
            do
            {
                // buffer to write to
                byte[] buffer;
                // offset to start writing at
                int offset;
                BufferPartition latestBuffer = streamPartition.GetLatestBufferWithAvailableSpaceOrDefault();
                // whether we got a brand new buffer to write into
                bool newbuffer;
                if (latestBuffer != default)
                {
                    buffer = latestBuffer.Buffer;
                    offset = latestBuffer.DataLength;
                    newbuffer = false;
                }
                else
                {
                    buffer = arrayPool.Rent((int)Math.Min(maxCount - totalRead, streamPartition.MaxArraySize));
                    offset = 0;
                    newbuffer = true;
                }

                // limit max and min count for this buffer by buffer length
                maxCountIndividualBuffer = (int)Math.Min(maxCount - totalRead, buffer.Length - offset);
                // definitionally limited by max; we won't ever have a swapped min/max range
                minCountIndividualBuffer = (int)Math.Min(minCount - totalRead, maxCountIndividualBuffer);

                readIndividualBuffer = await ReadLoopInternal(
                    stream,
                    buffer,
                    offset: offset,
                    minCountIndividualBuffer,
                    maxCountIndividualBuffer,
                    async,
                    cancellationToken).ConfigureAwait(false);
                // if nothing was placed in a brand new array
                if (readIndividualBuffer == 0 && newbuffer)
                {
                    arrayPool.Return(buffer);
                }
                // if brand new array and we did place data in it
                else if (newbuffer)
                {
                    streamPartition.BufferSet.Add(new BufferPartition
                    {
                        Buffer = buffer,
                        DataLength = readIndividualBuffer
                    });
                }
                // added to an existing array that was not entirely filled
                else
                {
                    latestBuffer.DataLength += readIndividualBuffer;
                }

                totalRead += readIndividualBuffer;

            /* If we filled the buffer this loop, then quitting on min count is pointless. The point of quitting
             * on min count is when the source stream doesn't have available bytes and we've reached an amount worth
             * sending instead of blocking on. If we filled the available array, we don't actually know whether more
             * data is available yet, as we limited our read for reasons outside the stream state. We should therefore
             * try another read regardless of whether we hit min count.
             */
            } while (
                // stream is done if this value is zero; no other check matters
                readIndividualBuffer != 0 &&
                // stop filling the partition if we've hit the max size of the partition
                totalRead < maxCount &&
                // stop filling the partition if we've reached min count and we know we've hit at least a pause in the stream
                (totalRead < minCount || readIndividualBuffer == maxCountIndividualBuffer));

            return streamPartition;
        }

        /// <summary>
        /// Loops Read() calls into buffer until minCount is reached or stream returns 0.
        /// </summary>
        /// <returns>Bytes read.</returns>
        /// <remarks>
        /// This method may have read bytes even if it has reached the confirmed end of stream. You will have to call
        /// this method again and read zero bytes to get that confirmation.
        /// </remarks>
        private static async Task<int> ReadLoopInternal(Stream stream, byte[] buffer, int offset, int minCount, int maxCount, bool async, CancellationToken cancellationToken)
        {
            if (minCount > maxCount)
            {
                throw new ArgumentException($"{nameof(minCount)} cannot be greater than {nameof(maxCount)}.");
            }
            if (maxCount <= 0)
            {
                throw new ArgumentException("Cannot read a non-positive number of bytes.");
            }

            int totalRead = 0;
            do
            {
                int read = async
                    ? await stream.ReadAsync(buffer, offset + totalRead, maxCount - totalRead, cancellationToken).ConfigureAwait(false)
                    : stream.Read(buffer, offset + totalRead, maxCount - totalRead);
                // either we have read maxCount in total or the stream has ended
                if (read == 0)
                {
                    break;
                }
                totalRead += read;
            // we always request the number that will bring our total read to maxCount
            // if the stream can only give us so much at the moment and we've at least hit minCount, we can exit
            } while (totalRead < minCount);
            return totalRead;
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
        {
            if (Position >= Length)
            {
                return 0;
            }

            int read = 0;
            while (read < count && Position < Length)
            {
                (byte[] currentBuffer, int bufferCount, long offsetOfBuffer) = GetBufferFromPosition();

                int toCopy = (int)Min(
                    Length - Position,
                    bufferCount - (Position - offsetOfBuffer),
                    count - read);
                Array.Copy(currentBuffer, Position - offsetOfBuffer, buffer, read, toCopy);
                read += toCopy;
                Position += toCopy;
            }

            return read;
        }

        /// <summary>
        /// According the the current <see cref="Position"/> of the stream, gets the correct buffer containing the byte
        /// at that position, as well as the stream position represented by the start of the array.
        /// Position - offsetOfBuffer is the index in the returned array of the current byte.
        /// </summary>
        /// <returns></returns>
        private (byte[] currentBuffer, int bufferCount, long offsetOfBuffer) GetBufferFromPosition()
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
        {
            while (count > 0)
            {
                BufferPartition currentBuffer = GetLatestBufferWithAvailableSpaceOrDefault();

                if (currentBuffer == default)
                {
                    byte[] newBytes = ArrayPool.Rent(MaxArraySize);
                    currentBuffer = new BufferPartition
                    {
                        Buffer = newBytes,
                        DataLength = 0
                    };
                    BufferSet.Add(currentBuffer);
                }

                int copied = Math.Min(currentBuffer.Buffer.Length - currentBuffer.DataLength, count);
                Array.Copy(buffer, offset, currentBuffer.Buffer, currentBuffer.DataLength, copied);
                currentBuffer.DataLength += copied;
                count -= copied;
                offset += copied;
                Position += copied;
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
