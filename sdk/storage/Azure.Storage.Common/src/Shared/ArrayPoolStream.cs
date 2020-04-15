// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Shared
{
    /// <summary>
    /// Functions like a readable <see cref="MemoryStream"/> but uses an ArrayPool to supply the backing memory.
    /// </summary>
    internal class ArrayPoolStream : Stream
    {
        /// <summary>
        /// The backing array pool.
        /// </summary>
        public ArrayPool<byte> ArrayPool { get; }

        /// <summary>
        /// Absolute position of this stream in the larger stream it was chunked from.
        /// </summary>
        public long AbsolutePosition { get; }

        private List<(byte[], int)> Buffer { get; }

        internal ArrayPoolStream(ArrayPool<byte> arrayPool, List<(byte[], int)> buffer, long absolutePosition)
        {
            Buffer = buffer;
            AbsolutePosition = absolutePosition;
            ArrayPool = arrayPool;
        }

        public static ArrayPoolStream BufferStreamPartition(Stream stream, long count, ArrayPool<byte> arrayPool, CancellationToken cancellationToken)
        {
            return BufferStreamPartitionInternal(stream, count, arrayPool, false, cancellationToken).EnsureCompleted();
        }
        public static Task<ArrayPoolStream> BufferStreamPartitionAsync(Stream stream, long count, ArrayPool<byte> arrayPool, CancellationToken cancellationToken)
        {
            return BufferStreamPartitionInternal(stream, count, arrayPool, true, cancellationToken);
        }
        private static async Task<ArrayPoolStream> BufferStreamPartitionInternal(Stream stream, long count, ArrayPool<byte> arrayPool, bool async, CancellationToken cancellationToken)
        {
            int totalRead
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length { get; }

        public override long Position { get; set; }

        public override void Flush()
        {
            // no-op, just like MemoryStream
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = 0;
            long readStartingPosition = Position;

            while (read < count && readStartingPosition + read < Length)
            {
                (byte[] currentBuffer, long currentBufferStartingPosition) = GetBufferFromPosition();
            }
        }

        private (byte[] currentBuffer, long currentBufferStartingPosition) GetBufferFromPosition()
        {
            if (Position >= Length || Position < 0)
            {
                throw new InvalidOperationException();
            }

            long currStartingPos = 0;
            foreach (byte[] currBuf in Bytes)
            {
                 
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset;
                    break;
                case SeekOrigin.Current:
                    Position = Position + offset;
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
            foreach (var array in Bytes)
            {
                ArrayPool.Return(array);
            }
        }
    }
}
