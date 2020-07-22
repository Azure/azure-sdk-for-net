// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Linq;
using Azure.Core.Pipeline;
using Azure.Storage.Shared;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture]
    public class PooledMemoryStreamTests
    {
        private readonly ArrayPool<byte> _pool = ArrayPool<byte>.Shared;

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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/12312")]
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
