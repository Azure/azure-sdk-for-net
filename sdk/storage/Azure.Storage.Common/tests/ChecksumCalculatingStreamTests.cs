// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Hashing;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

using ChecksumCallback = Azure.Storage.ChecksumCalculatingStream.AppendChecksumCalculation;

namespace Azure.Storage.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    internal class ChecksumCalculatingStreamTests
    {
        private readonly bool IsAsync;

        public ChecksumCalculatingStreamTests(bool async)
        {
            IsAsync = async;
        }

        [Test]
        public void MakeReadStream(
            [Values(true, false)] bool innerStreamCanWrite,
            [Values(true, false)] bool innerStreamCanSeek)
        {
            // Given a mock stream with various write/seek capabilities
            var innerStream = new Mock<Stream>();
            innerStream.BasicSetup(canRead: true, innerStreamCanWrite, innerStreamCanSeek);

            // Create the checksum stream
            Stream checksumStream = null;
            Assert.DoesNotThrow(() => checksumStream = ChecksumCalculatingStream.GetReadStream(
                innerStream.Object, new Mock<ChecksumCallback>().Object));
            Assert.IsNotNull(checksumStream);

            // Assert read-only
            Assert.IsTrue(checksumStream.CanRead);
            Assert.IsFalse(checksumStream.CanWrite);
            Assert.DoesNotThrowAsync(
                async () => await checksumStream.ReadInternal(new byte[1], 0, 1, IsAsync, default));
            Assert.ThrowsAsync<NotSupportedException>(
                async () => await checksumStream.WriteInternal(new byte[1], 0, 1, IsAsync, default));

            // Assert maintain seekability
            Assert.AreEqual(innerStreamCanSeek, checksumStream.CanSeek);
            foreach (TestDelegate del in new List<TestDelegate>()
            {
                () => checksumStream.Seek(0, SeekOrigin.Begin),
                () => _ = checksumStream.Position,
                () => checksumStream.Position = 0,
                () => _ = checksumStream.Length
            })
            {
                if (innerStreamCanSeek)
                    Assert.DoesNotThrow(del);
                else
                    Assert.Throws<NotSupportedException>(del);
            }
        }

        [Test]
        public void MakeReadStream_Fail()
        {
            var innerStream = new Mock<Stream>();
            innerStream.BasicSetup(canRead: false, canWrite: true, canSeek: true);

            Assert.Throws<ArgumentException>(() => ChecksumCalculatingStream.GetReadStream(
                innerStream.Object, new Mock<ChecksumCallback>().Object));
        }

        [Test]
        public void MakeWriteStream(
            [Values(true, false)] bool innerStreamCanRead,
            [Values(true, false)] bool innerStreamCanSeek)
        {
            // Given a mock stream with various read/seek capabilities
            var innerStream = new Mock<Stream>();
            innerStream.BasicSetup(innerStreamCanRead, canWrite: true, innerStreamCanSeek);

            // Create the checksum stream
            Stream checksumStream = null;
            Assert.DoesNotThrow(() => checksumStream = ChecksumCalculatingStream.GetWriteStream(
                innerStream.Object, new Mock<ChecksumCallback>().Object));
            Assert.IsNotNull(checksumStream);

            // Assert write-only
            Assert.IsFalse(checksumStream.CanRead);
            Assert.IsTrue(checksumStream.CanWrite);
            Assert.ThrowsAsync<NotSupportedException>(
                async () => await checksumStream.ReadInternal(new byte[1], 0, 1, IsAsync, default));
            Assert.DoesNotThrowAsync(
                async () => await checksumStream.WriteInternal(new byte[1], 0, 1, IsAsync, default));

            // Assert seeking not supported
            Assert.IsFalse(checksumStream.CanSeek);
            Assert.Throws<NotSupportedException>(
                () => checksumStream.Seek(0, SeekOrigin.Begin));
            Assert.Throws<NotSupportedException>(
                () => checksumStream.Position = 0);

            // Assert maintains existing info traditionally locked behind seeking
            foreach (TestDelegate del in new List<TestDelegate>()
            {
                () => _ = checksumStream.Position,
                () => _ = checksumStream.Length
            })
            {
                if (innerStreamCanSeek)
                    Assert.DoesNotThrow(del);
                else
                    Assert.Throws<NotSupportedException>(del);
            }
        }

        [Test]
        public void MakeWriteStream_Fail()
        {
            var innerStream = new Mock<Stream>();
            innerStream.BasicSetup(canRead: true, canWrite: false, canSeek: true);

            Assert.Throws<ArgumentException>(() => ChecksumCalculatingStream.GetWriteStream(
                innerStream.Object, new Mock<ChecksumCallback>().Object));
        }

        [TestCase(Constants.KB, 16, default)]
        [TestCase(Constants.KB, 10, default)]
        [TestCase(Constants.KB, 16, 13)]
        public async Task CalculateOnSequentialRead(int dataSize, int copyBuffer, int? readReturnLimit)
        {
            // Given data and it's checksum
            var data = new byte[dataSize];
            new Random().NextBytes(data);
            var dataChecksum = ChecksumInlineStorageCrc64(data, StorageCrc64HashAlgorithm.Create());

            // and a checksumming stream
            var streamChecksumCalculator = StorageCrc64HashAlgorithm.Create();
            var checksumStream = ChecksumCalculatingStream.GetReadStream(
                readReturnLimit.HasValue
                    ? ReadCountLimitingStream.Create(new MemoryStream(data), readReturnLimit.Value)
                    : new MemoryStream(data),
                streamChecksumCalculator.Append);

            // Read the data through the checksumming stream and get the checksum
            var destStream = new MemoryStream();
            await checksumStream.CopyToInternal(destStream, copyBuffer, IsAsync, cancellationToken: default);
            var streamChecksum = streamChecksumCalculator.GetCurrentHash();

            // Assert output data and checksum are expected
            CollectionAssert.AreEqual(data, destStream.ToArray());
            CollectionAssert.AreEqual(dataChecksum, streamChecksum);
        }

        [TestCase(Constants.KB, 16)]
        [TestCase(Constants.KB, 10)]
        [TestCase(Constants.KB, 16)]
        public async Task CalculateOnSequentialWrite(int dataSize, int copyBuffer)
        {
            // Given data and it's checksum
            var data = new byte[dataSize];
            new Random().NextBytes(data);
            var dataChecksum = ChecksumInlineStorageCrc64(data, StorageCrc64HashAlgorithm.Create());

            // and a checksumming stream
            var streamChecksumCalculator = StorageCrc64HashAlgorithm.Create();
            var destStream = new MemoryStream();
            var checksumStream = ChecksumCalculatingStream.GetWriteStream(destStream, streamChecksumCalculator.Append);

            // Write the data through the checksumming stream and get the checksum
            await new MemoryStream(data).CopyToInternal(checksumStream, copyBuffer, IsAsync, cancellationToken: default);
            var streamChecksum = streamChecksumCalculator.GetCurrentHash();

            // Assert output data and checksum are expected
            CollectionAssert.AreEqual(data, destStream.ToArray());
            CollectionAssert.AreEqual(dataChecksum, streamChecksum);
        }

        private static byte[] ChecksumInlineStorageCrc64(Span<byte> data, NonCryptographicHashAlgorithm algorithm)
        {
            algorithm.Append(data);
            return algorithm.GetCurrentHash();
        }
    }
}
