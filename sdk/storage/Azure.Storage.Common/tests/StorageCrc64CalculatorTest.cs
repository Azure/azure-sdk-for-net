// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class StorageCrc64CalculatorTest
    {
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(10)]
        public void Compose(int numSegments)
        {
            const int blockSize = Constants.KB;
            var data = new byte[numSegments * blockSize];
            new Random().NextBytes(data);

            ulong wholeCrc = StorageCrc64Calculator.ComputeSlicedSafe(data, 0);
            Queue<ulong> blockCrcs = new(Enumerable.Range(0, numSegments)
                .Select(i => StorageCrc64Calculator.ComputeSlicedSafe(
                    new Span<byte>(data, i * blockSize, blockSize), 0)));

            ulong composedCrc = blockCrcs.Dequeue();
            int i = 1;
            while (blockCrcs.Count > 0)
            {
                ulong nextBlockCrc = blockCrcs.Dequeue();
                composedCrc = StorageCrc64Calculator.Concatenate(
                    uInitialCrcAB: 0,
                    uInitialCrcA: 0,
                    uFinalCrcA: composedCrc,
                    uSizeA: (ulong) (blockSize * i),
                    uInitialCrcB: 0,
                    uFinalCrcB: nextBlockCrc,
                    uSizeB: blockSize);
                i++;
            }

            Assert.AreEqual(wholeCrc, composedCrc);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(10)]
        public void ComposeDifferingBlockSizes(int numSegments)
        {
            const int minBlockSize = Constants.KB, maxBlockSize = 4 * Constants.KB;
            var random = new Random();

            List<int> blockLengths = Enumerable.Range(0, numSegments)
                .Select(_ => random.Next(minBlockSize, maxBlockSize))
                .ToList();
            var data = new byte[blockLengths.Sum()];
            random.NextBytes(data);

            ulong wholeCrc = StorageCrc64Calculator.ComputeSlicedSafe(data, 0);
            Queue<ulong> blockCrcs = new(Enumerable.Range(0, numSegments)
                .Select(i => StorageCrc64Calculator.ComputeSlicedSafe(
                    new Span<byte>(
                        data,
                        i == 0 ? 0 : blockLengths.Take(i).Sum(),
                        blockLengths[i]),
                    0)));

            ulong composedCrc = blockCrcs.Dequeue();
            int lengthIndex = 1;
            while (blockCrcs.Count > 0)
            {
                ulong nextBlockCrc = blockCrcs.Dequeue();
                composedCrc = StorageCrc64Calculator.Concatenate(
                    uInitialCrcAB: 0,
                    uInitialCrcA: 0,
                    uFinalCrcA: composedCrc,
                    uSizeA: (ulong) blockLengths[lengthIndex - 1],
                    uInitialCrcB: 0,
                    uFinalCrcB: nextBlockCrc,
                    uSizeB: (ulong) blockLengths[lengthIndex]);
                lengthIndex++;
            }

            Assert.AreEqual(wholeCrc, composedCrc);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(10)]
        public void ComposeWithHelper(int numSegments)
        {
            const int minBlockSize = Constants.KB, maxBlockSize = 4 * Constants.KB;
            var random = new Random();

            List<int> blockLengths = Enumerable.Range(0, numSegments)
                .Select(_ => random.Next(minBlockSize, maxBlockSize))
                .ToList();
            var data = new byte[blockLengths.Sum()];
            random.NextBytes(data);

            ulong wholeCrc = StorageCrc64Calculator.ComputeSlicedSafe(data, 0);
            List<ulong> blockCrcs = Enumerable.Range(0, numSegments)
                .Select(i => StorageCrc64Calculator.ComputeSlicedSafe(
                    new Span<byte>(
                        data,
                        i == 0 ? 0 : blockLengths.Take(i).Sum(),
                        blockLengths[i]), 0))
                .ToList();

            ulong composedCrc = StorageCrc64Composer.Compose(
                blockCrcs.Zip(blockLengths, (crc, len) => (crc, (long)len)));

            Assert.AreEqual(wholeCrc, composedCrc);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(10)]
        public void ComposeHelperIdenticalToStreamedHash(int numSegments)
        {
            const int minBlockSize = Constants.KB, maxBlockSize = 4 * Constants.KB;
            var random = new Random();

            List<ReadOnlyMemory<byte>> blocks = Enumerable.Range(0, numSegments)
                .Select(_ => {
                    var block = new byte[random.Next(minBlockSize, maxBlockSize)];
                    random.NextBytes(block);
                    return new ReadOnlyMemory<byte>(block);
                })
                .ToList();

            var wholeCrcCalculator = StorageCrc64HashAlgorithm.Create();
            foreach (var block in blocks)
            {
                wholeCrcCalculator.Append(block.Span);
            }
            var wholeCrc = wholeCrcCalculator.GetCurrentHash();

            var composedCrc = StorageCrc64Composer.Compose(blocks.Select(block =>
            {
                var blockCrcCalculator = StorageCrc64HashAlgorithm.Create();
                blockCrcCalculator.Append(block.Span);
                return (blockCrcCalculator.GetCurrentHash(), (long)block.Length);
            }));

            CollectionAssert.AreEqual(wholeCrc, composedCrc.ToArray());
        }
    }
}
