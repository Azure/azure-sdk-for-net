// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task ReadStream(int dataSize, int bufferPartitionSize)
        {
            PredictableStream originalStream = new PredictableStream();
            PooledMemoryStream arrayPoolStream = await PooledMemoryStream.BufferStreamPartitionInternal(originalStream, dataSize, dataSize, 0, _pool, bufferPartitionSize, true, default);
            originalStream.Position = 0;

            byte[] originalStreamData = new byte[dataSize];
            byte[] poolStreamData = new byte[dataSize];
            originalStream.Read(originalStreamData, 0, dataSize);
            arrayPoolStream.Read(poolStreamData, 0, dataSize);

            CollectionAssert.AreEqual(originalStreamData, poolStreamData);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/12312")]
        public void StreamCanHoldLongData()
        {
            const long dataSize = 4000L * Constants.MB;
            const int bufferPartitionSize = 512 * Constants.MB;
            PredictableStream originalStream = new PredictableStream();
            PooledMemoryStream arrayPoolStream = PooledMemoryStream.BufferStreamPartitionInternal(originalStream, dataSize, dataSize, 0, _pool, bufferPartitionSize, false, default).EnsureCompleted();
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

        [TestCase(Constants.KB, 256)] // buffer split size smaller than data
        [TestCase(Constants.KB, 2 * Constants.KB)] // buffer split size larger than data.
        [TestCase(Constants.KB + 11, 256)] // content doesn't line up with buffers (extremely unlikely any array pool implementation will add exactly 11 bytes more than requested across 4 buffers)
        public async Task WriteStream(int dataSize, int bufferPartitionSize)
        {
            // Arrange
            byte[] originalData = GetRandomBuffer(dataSize);
            byte[] readData = new byte[dataSize];
            PooledMemoryStream pooledMemoryStream = new PooledMemoryStream(ArrayPool<byte>.Shared, 0, bufferPartitionSize);

            // Act
            await pooledMemoryStream.WriteAsync(originalData, 0, dataSize);
            pooledMemoryStream.Position = 0;
            await pooledMemoryStream.ReadAsync(readData, 0, dataSize);

            // Also testing that clear works.
            pooledMemoryStream.Clear();

            // Assert
            AssertSequenceEqual(originalData, readData);
            Assert.AreEqual(0, pooledMemoryStream.Position);
        }

        private static byte[] GetRandomBuffer(long size)
        {
            Random random = new Random(Environment.TickCount);
            var buffer = new byte[size];
            random.NextBytes(buffer);
            return buffer;
        }

        private static void AssertSequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.AreEqual(expected.Count(), actual.Count(), "Actual sequence length does not match expected sequence length");
            (int index, T expected, T actual)[] firstErrors = expected.Zip(actual, (e, a) => (expected: e, actual: a)).Select((x, i) => (index: i, x.expected, x.actual)).Where(x => !x.expected.Equals(x.actual)).Take(5).ToArray();
            Assert.IsFalse(firstErrors.Any(), $"Actual sequence does not match expected sequence at locations\n{string.Join("\n", firstErrors.Select(e => $"{e.index} => expected = {e.expected}, actual = {e.actual}"))}");
        }
    }
}
