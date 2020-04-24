﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Storage.Shared;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture]
    public class PooledMemoryStreamTests
    {
        private readonly ArrayPool<byte> _pool = ArrayPool<byte>.Shared;

        /// <summary>
        /// Stream who's byte at position n is n % <see cref="byte.MaxValue"/>.
        /// Note this means we have 255 possibilities, not 256, giving variation at likely buffer boundaries.
        /// </summary>
        private class PredictableStream : Stream
        {
            public override bool CanRead => true;

            public override bool CanSeek => true;

            public override bool CanWrite => false;

            public override long Length => throw new NotSupportedException();

            public override long Position { get; set; } = 0;

            public override void Flush()
            { }

            public override int Read(byte[] buffer, int offset, int count)
            {
                for (int i = 0; i < count; i++)
                {
                    buffer[offset + i] = (byte)((Position + i) % byte.MaxValue);
                }

                Position += count;
                return count;
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

        /// <summary>
        /// Sanity check for our test helper stream implementation.
        /// </summary>
        [Test]
        public void PredictableStreamIsPredictable()
        {
            const int dataSize = 257;

            var buffer = new byte[dataSize];
            var predictableStream = new PredictableStream();
            predictableStream.Read(buffer, 0, dataSize);
            Assert.AreEqual(dataSize, predictableStream.Position);

            var expected = Enumerable.Range(0, dataSize).Select(val => (byte)(val % byte.MaxValue)).ToArray();
            for (int i = 0; i < dataSize; i++)
            {
                Assert.AreEqual(buffer[i], expected[i]);
            }
        }

        [TestCase(Constants.KB, 256)] // buffer split size smaller than data
        [TestCase(Constants.KB, 2 * Constants.KB)] // buffer split size larger than data.
        [TestCase(Constants.KB + 11, 256)] // content doesn't line up with buffers (extremely unlikely any array pool implementation will add exactly 11 bytes more than requested across 4 buffers)
        public void ReadStream(int dataSize, int bufferPartitionSize)
        {
            var originalStream = new PredictableStream();
            var arrayPoolStream = PooledMemoryStream.BufferStreamPartitionInternal(originalStream, dataSize, dataSize, 0, _pool, bufferPartitionSize, false, default).EnsureCompleted();
            originalStream.Position = 0;

            var originalStreamData = new byte[dataSize];
            var poolStreamData = new byte[dataSize];
            originalStream.Read(originalStreamData, 0, dataSize);
            arrayPoolStream.Read(poolStreamData, 0, dataSize);

            CollectionAssert.AreEqual(originalStreamData, poolStreamData);
        }

        [Test]
        [Explicit]
        public void StreamCanHoldLongData()
        {
            const long dataSize = 4000L * Constants.MB;
            const int bufferPartitionSize = 512 * Constants.MB;
            var originalStream = new PredictableStream();
            var arrayPoolStream = PooledMemoryStream.BufferStreamPartitionInternal(originalStream, dataSize, dataSize, 0, _pool, bufferPartitionSize, false, default).EnsureCompleted();
            originalStream.Position = 0;


            // assert it holds the correct amount of data. other tests assert data validity and it's so expensive to do that here.
            // test without blowing up memory
            const int testSize = 256 * Constants.MB;
            var pooledStreamBuffer = new byte[testSize];
            long totalRead = 0;
            int read;
            do
            {
                // both these streams are backed in memory and will always read what is asked until the pooled stream hits the end
                read = arrayPoolStream.Read(pooledStreamBuffer, 0, testSize);
                totalRead += read;
            } while (read != 0);

            Assert.AreEqual(dataSize, totalRead);
        }
    }
}
