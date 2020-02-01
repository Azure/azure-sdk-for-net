// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using Azure.Storage.Common;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Cryptography.Tests
{
    public class RollingBufferStreamTests // pure local tests; don't inherit recording bulk
    {
        public RollingBufferStreamTests()
        { }

        private Stream GetBufferStream(int bufferSize) => new RollingBufferStream(new MockStream(), bufferSize);

        [Test]
        public void ReadNormalTest()
        {
            var stream = GetBufferStream(21);

            Assert.AreEqual(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, stream.FluentRead(10));
            Assert.AreEqual(new byte[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }, stream.FluentRead(10));

            stream.Position = 0;

            Assert.AreEqual(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 }, stream.FluentRead(8));
            Assert.AreEqual(new byte[] { 8, 9, 10, 11, 12, 13, 14, 15 }, stream.FluentRead(8));
            Assert.AreEqual(new byte[] { 16, 17, 18, 19, 20, 21, 22, 23 }, stream.FluentRead(8));
        }

        [Test]
        public void ReadMoreThanBufferTest()
        {
            var stream = GetBufferStream(5);

            Assert.AreEqual(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, stream.FluentRead(10));
            Assert.AreEqual(new byte[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }, stream.FluentRead(10));
        }

        [Test]
        public void ReadMoreThanBufferUnallignedTest()
        {
            var stream = GetBufferStream(8);

            Assert.AreEqual(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, stream.FluentRead(10));
            Assert.AreEqual(new byte[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }, stream.FluentRead(10));
        }

        [Test]
        public void ReadHistoryCrossBufferBoundary()
        {
            var stream = GetBufferStream(12);

            Assert.AreEqual(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, stream.FluentRead(10));
            Assert.AreEqual(new byte[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }, stream.FluentRead(10));
            stream.Position = 9;
            Assert.AreEqual(
                new byte[] { 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 },
                stream.FluentRead(11));
        }

        [Test]
        public void ReadManyCombinations()
        {
            for (int bufferSize = 10; bufferSize < 20; bufferSize++)
            {
                for (int readChunkSize = 5; readChunkSize < 25; readChunkSize++)
                {
                    for (int rewindSize = 1; rewindSize < bufferSize - 1 && rewindSize < readChunkSize; rewindSize++)
                    {
                        var stream = GetBufferStream(bufferSize);

                        while (stream.Position < 3 * bufferSize)
                        {
                            Assert.AreEqual(
                                Enumerable.Range((int)stream.Position, readChunkSize).Select(num => (byte)num).ToArray(),
                                stream.FluentRead(readChunkSize));
                            stream.Position -= rewindSize;
                        }
                    }
                }
            }
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal static class StreamExtensions
#pragma warning restore SA1402 // File may only contain a single type
    {
        public static byte[] FluentRead(this Stream stream, int count)
        {
            var buffer = new byte[count];
            stream.Read(buffer, 0, count);
            return buffer;
        }
    }
}
