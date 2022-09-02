// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Shared;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture]
    public class StageBlockStreamTests
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
            StageBlockStream arrayPoolStream = new StageBlockStream(
                arrayPool: _pool,
                absolutePosition: 0,
                maxArraySize: dataSize);
            await arrayPoolStream.SetStreamPartitionInternal(
                originalStream,
                bufferPartitionSize,
                dataSize,
                default);
            originalStream.Position = 0;

            byte[] originalStreamData = new byte[dataSize];
            byte[] poolStreamData = new byte[dataSize];
            originalStream.Read(originalStreamData, 0, dataSize);
            arrayPoolStream.Read(poolStreamData, 0, dataSize);

            CollectionAssert.AreEqual(originalStreamData, poolStreamData);
        }

        [TestCase(Constants.KB, 256, Constants.KB - 5, 5)] // buffer split size smaller than data
        [TestCase(Constants.KB, 256, Constants.KB - 256, 256)] // buffer split size smaller than data
        [TestCase(Constants.KB, 24, 24, 1000)] // last bit of the buffer
        [TestCase(Constants.KB * 10, 2 * Constants.KB, 256, 256)] // Middle of the buffer
        //[TestCase(Constants.KB + 11, 256)] // content doesn't line up with buffers (extremely unlikely any array pool implementation will add exactly 11 bytes more than requested across 4 buffers)
        public async Task ReadStream(int originalLength, int bufferPartitionSize, int blockLength, int offset)
        {
            PredictableStream originalStream = new PredictableStream();
            StageBlockStream arrayPoolStream = new StageBlockStream(
                arrayPool: _pool,
                absolutePosition: offset,
                maxArraySize: originalLength);
            await arrayPoolStream.SetStreamPartitionInternal(
                originalStream,
                blockLength,
                blockLength,
                default);
            originalStream.Position = 0;

            byte[] originalStreamData = new byte[originalLength];
            byte[] poolStreamData = new byte[originalLength];
            originalStream.Position = offset;
            originalStream.Read(originalStreamData, 0, blockLength);
            arrayPoolStream.Read(poolStreamData, 0, blockLength);

            CollectionAssert.AreEqual(originalStreamData, poolStreamData);
        }

        [Test]
        [LiveOnly]
        public async Task StreamCanHoldLongData()
        {
            const long dataSize = (long)int.MaxValue + Constants.MB;
            const int bufferPartitionSize = 512 * Constants.MB;
            PredictableStream originalStream = new PredictableStream();
            StageBlockStream arrayPoolStream = new StageBlockStream(
                arrayPool: _pool,
                absolutePosition: 0,
                maxArraySize: bufferPartitionSize);
            await arrayPoolStream.SetStreamPartitionInternal(
                originalStream,
                bufferPartitionSize,
                bufferPartitionSize,
                default);
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

        private static byte[] GetRandomBuffer(long size)
        {
            Random random = new Random(Environment.TickCount);
            var buffer = new byte[size];
            random.NextBytes(buffer);
            return buffer;
        }

        public static void AssertSequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.AreEqual(expected.Count(), actual.Count(), "Actual sequence length does not match expected sequence length");
            (int Index, T Expected, T Actual)[] firstErrors = expected.Zip(actual, (e, a) => (Expected: e, Actual: a)).Select((x, i) => (Index: i, x.Expected, x.Actual)).Where(x => !x.Expected.Equals(x.Actual)).Take(5).ToArray();
            Assert.IsFalse(firstErrors.Any(), $"Actual sequence does not match expected sequence at locations\n{string.Join("\n", firstErrors.Select(e => $"{e.Index} => expected = {e.Expected}, actual = {e.Actual}"))}");
        }
    }
}
