// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class StorageCrc64NonCryptographicHashAlgorithmTests
    {
        private static readonly byte[] TestVectorBytes = Encoding.UTF8.GetBytes("Hello, World!");
        private const ulong TestVectorExpectedCrc64 = 0xd4a9be4326add24d;

        [Test]
        public void StorageHashAlgorithm_GetCurrentHash()
        {
            var calculator = StorageCrc64HashAlgorithm.Create();
            calculator.Append(TestVectorBytes);

            byte[] actual = calculator.GetCurrentHash();
            byte[] expected = BitConverter.GetBytes(TestVectorExpectedCrc64);

            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [Test]
        public void StorageHashAlgorithm_GetCurrentHashAsUInt64()
        {
            var calculator = StorageCrc64HashAlgorithm.Create();
            calculator.Append(TestVectorBytes);

            ulong actual = calculator.GetCurrentHashAsUInt64();

            Assert.AreEqual(TestVectorExpectedCrc64, actual);
        }

        [Test]
        public void StorageHashAlgorithm_HashToUInt64()
        {
            ulong actual = StorageCrc64HashAlgorithm.HashToUInt64(TestVectorBytes);

            Assert.AreEqual(TestVectorExpectedCrc64, actual);
        }

        [Test]
        public void UpdateHashManualAppends()
        {
            var random = new Random();

            var minBatchSize = 1 * Constants.KB;
            var maxBatchSize = 100 * Constants.KB;

            var data = new byte[17 * Constants.MB];
            random.NextBytes(data);

            // computes hash on data with random buffer sizes
            // should produce same result every time regardless of randomness
            byte[] ComputeHash()
            {
                var calculator = StorageCrc64HashAlgorithm.Create();
                var position = 0;

                do
                {
                    // random buffer size every time
                    var bufferSize = random.Next(minBatchSize, maxBatchSize);
                    bufferSize = Math.Min(bufferSize, data.Length - position);
                    var buffer = new byte[bufferSize];

                    Array.Copy(data, position, buffer, 0, bufferSize);
                    position += bufferSize;

                    calculator.Append(buffer);
                }
                while (position < data.Length);

                return calculator.GetCurrentHash();
            }

            var crc0 = ComputeHash();
            var crc1 = ComputeHash();

            Assert.IsTrue(Enumerable.SequenceEqual(crc0, crc1));
        }
    }
}
