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
            Stream stream = null;
            Assert.DoesNotThrow(() => stream = ChecksumCalculatingStream.GetReadStream(
                innerStream.Object, buf => { }));
            Assert.IsNotNull(stream);

            // Assert read-only
            Assert.IsTrue(stream.CanRead);
            Assert.IsFalse(stream.CanWrite);
            Assert.DoesNotThrowAsync(
                async () => await stream.ReadInternal(new byte[1], 0, 1, IsAsync, default));
            Assert.ThrowsAsync<NotSupportedException>(
                async () => await stream.WriteInternal(new byte[1], 0, 1, IsAsync, default));

            // Assert maintain seekability
            Assert.AreEqual(innerStreamCanSeek, stream.CanSeek);
            foreach (TestDelegate del in new List<TestDelegate>()
            {
                () => stream.Seek(0, SeekOrigin.Begin),
                () => _ = stream.Position,
                () => stream.Position = 0,
                () => _ = stream.Length
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
                innerStream.Object, buf => { }));
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
            Stream stream = null;
            Assert.DoesNotThrow(() => stream = ChecksumCalculatingStream.GetWriteStream(
                innerStream.Object, buf => { }));
            Assert.IsNotNull(stream);

            // Assert write-only
            Assert.IsFalse(stream.CanRead);
            Assert.IsTrue(stream.CanWrite);
            Assert.ThrowsAsync<NotSupportedException>(
                async () => await stream.ReadInternal(new byte[1], 0, 1, IsAsync, default));
            Assert.DoesNotThrowAsync(
                async () => await stream.WriteInternal(new byte[1], 0, 1, IsAsync, default));

            // Assert seeking not supported
            Assert.IsFalse(stream.CanSeek);
            Assert.Throws<NotSupportedException>(
                () => stream.Seek(0, SeekOrigin.Begin));
            Assert.Throws<NotSupportedException>(
                () => stream.Position = 0);

            // Assert maintains existing info traditionally locked behind seeking
            foreach (TestDelegate del in new List<TestDelegate>()
            {
                () => _ = stream.Position,
                () => _ = stream.Length
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
                innerStream.Object, buf => { }));
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
            var stream = ChecksumCalculatingStream.GetReadStream(
                readReturnLimit.HasValue
                    ? ReadCountLimitingStream.Create(new MemoryStream(data), readReturnLimit.Value)
                    : new MemoryStream(data),
                streamChecksumCalculator.Append);

            // Read the data through the checksumming stream and get the checksum
            var destStream = new MemoryStream();
            await stream.CopyToInternal(destStream, copyBuffer, IsAsync, cancellationToken: default);
            var streamChecksum = streamChecksumCalculator.GetCurrentHash();

            // Assert output data and checksum are expected
            CollectionAssert.AreEqual(data, destStream.ToArray());
            CollectionAssert.AreEqual(dataChecksum, streamChecksum);
        }

        [TestCase(Constants.KB, 16)]
        [TestCase(Constants.KB, 10)]
        public async Task CalculateOnSequentialWrite(int dataSize, int copyBuffer)
        {
            // Given data and it's checksum
            var data = new byte[dataSize];
            new Random().NextBytes(data);
            var dataChecksum = ChecksumInlineStorageCrc64(data, StorageCrc64HashAlgorithm.Create());

            // and a checksumming stream
            var streamChecksumCalculator = StorageCrc64HashAlgorithm.Create();
            var destStream = new MemoryStream();
            var stream = ChecksumCalculatingStream.GetWriteStream(destStream, streamChecksumCalculator.Append);

            // Write the data through the checksumming stream and get the checksum
            await new MemoryStream(data).CopyToInternal(stream, copyBuffer, IsAsync, cancellationToken: default);
            var streamChecksum = streamChecksumCalculator.GetCurrentHash();

            // Assert output data and checksum are expected
            CollectionAssert.AreEqual(data, destStream.ToArray());
            CollectionAssert.AreEqual(dataChecksum, streamChecksum);
        }

        [Test]
        [Combinatorial]
        public async Task ReadModeCanSeekWithinChecksummedBounds(
            [Values(0, 20)] int startOffset,
            [Values(true, false)] bool seekViaMethod)
        {
            // given a stream at a given position wrapped in the checksumming read stream
            var data = new byte[Constants.KB];
            new Random().NextBytes(data);
            var stream = ChecksumCalculatingStream.GetReadStream(
                new MemoryStream(data) { Position = startOffset },
                buf => { });

            // and an upper bound of what has been checksummed so far
            int upperOffset = 800;
            await stream.ReadInternal(
                new byte[upperOffset - startOffset], 0, upperOffset - startOffset, IsAsync, default);

            // Assert the following target seek positions are successful and lead to a successful read
            var b = new byte[10];
            foreach (int l in new List<int> {
                512,
                600,
                upperOffset - b.Length,
                startOffset,
                startOffset + 1,
                upperOffset
            })
            {
                if (seekViaMethod)
                    Assert.DoesNotThrow(() => stream.Seek(l, SeekOrigin.Begin));
                else
                    Assert.DoesNotThrow(() => stream.Position = l);

                Assert.AreEqual(l, stream.Position);

                await stream.ReadInternal(b, 0, b.Length, IsAsync, default);
                CollectionAssert.AreEqual(new Span<byte>(data, l, b.Length).ToArray(), b);
            }
        }

        [Test]
        public async Task ReadModeCannotSeekChecksummedBounds([Values(true, false)] bool seekViaMethod)
        {
            // given a stream at a given position wrapped in the checksumming read stream
            int startOffset = 20;
            var data = new byte[Constants.KB];
            new Random().NextBytes(data);
            var stream = ChecksumCalculatingStream.GetReadStream(
                new MemoryStream(data) { Position = startOffset },
                buf => { });

            // and an upper bound of what has been checksummed so far
            int upperOffset = 800;
            await stream.ReadInternal(
                new byte[upperOffset - startOffset], 0, upperOffset - startOffset, IsAsync, default);

            // Assert the following target seek positions throw and stream position is unchanged
            long position = stream.Position;
            foreach (long l in new List<long> {
                0,
                startOffset - 1,
                upperOffset + 1,
                stream.Length
            })
            {
                if (seekViaMethod)
                    Assert.Throws<NotSupportedException>(() => stream.Seek(l, SeekOrigin.Begin));
                else
                    Assert.Throws<NotSupportedException>(() => stream.Position = l);

                Assert.AreEqual(position, stream.Position);
            }
        }

        [Test]
        public async Task ReadModeDoesNotDoubleCalculateChecksum()
        {
            // Given data and it's checksum
            var data = new byte[4 * Constants.KB];
            new Random().NextBytes(data);
            var dataChecksum = ChecksumInlineStorageCrc64(data, StorageCrc64HashAlgorithm.Create());

            // and a checksumming stream
            var streamChecksumCalculator = StorageCrc64HashAlgorithm.Create();
            var stream = ChecksumCalculatingStream.GetReadStream(
                new MemoryStream(data),
                streamChecksumCalculator.Append);

            // Read the data through the checksumming stream
            var destStream = new MemoryStream();
            await stream.CopyToInternal(destStream, bufferSize: 1000, IsAsync, cancellationToken: default);

            // Assert output data and checksum are expected
            CollectionAssert.AreEqual(data, destStream.ToArray());
            CollectionAssert.AreEqual(dataChecksum, streamChecksumCalculator.GetCurrentHash());

            // Rewind and reread the checksumming stream
            stream.Position = 0;
            destStream = new MemoryStream();
            await stream.CopyToInternal(destStream, bufferSize: 900, IsAsync, cancellationToken: default);

            // Assert output data as expected and checksum unaltered
            CollectionAssert.AreEqual(data, destStream.ToArray());
            CollectionAssert.AreEqual(dataChecksum, streamChecksumCalculator.GetCurrentHash());
        }

        [Test]
        public async Task ReadModeCanCalculateReadOverlapOnChecksumBoundary()
        {
            // Given data and it's checksum
            var data = new byte[4 * Constants.KB];
            new Random().NextBytes(data);
            var dataChecksum = ChecksumInlineStorageCrc64(data, StorageCrc64HashAlgorithm.Create());

            // and a checksumming stream that records its actions
            var callbacks = new List<byte[]>();
            var streamChecksumCalculator = StorageCrc64HashAlgorithm.Create();
            var stream = ChecksumCalculatingStream.GetReadStream(
                new MemoryStream(data),
                buf => {
                    streamChecksumCalculator.Append(buf);
                    var copy = new byte[buf.Length];
                    buf.CopyTo(copy);
                    callbacks.Add(copy);
                });

            // Read 2 KB
            int firstReadLength = 2 * Constants.KB;
            await stream.ReadInternal(new byte[firstReadLength], 0, firstReadLength, IsAsync, cancellationToken: default);

            // Assert expected checksum call on the whole read
            Assert.AreEqual(1, callbacks.Count);
            CollectionAssert.AreEqual(new Span<byte>(data, 0, firstReadLength).ToArray(), callbacks[0]);

            // Rewind to 1 KB and read another 2 KB, reading half checksummed contents and half unchecksummed
            int secondReadStartOffset = Constants.KB;
            int secondReadLength = 2 * Constants.KB;
            stream.Position = secondReadStartOffset;
            await stream.ReadInternal(new byte[secondReadLength], 0, secondReadLength, IsAsync, cancellationToken: default);

            // Assert expected checksum call on latter half of the read
            Assert.AreEqual(2, callbacks.Count);
            CollectionAssert.AreEqual(
                new Span<byte>(
                    data,
                    firstReadLength, // where the first checksum ended
                    secondReadStartOffset + secondReadLength - firstReadLength // amount of new data checksummed
                    ).ToArray(),
                callbacks[1]);

            // Finish consuming stream
            await stream.CopyToInternal(Stream.Null, 1000, IsAsync, cancellationToken: default);

            // Assert callback invocations and final checksum are as expected
            Assert.AreEqual(4, callbacks.Count);
            Assert.AreEqual(1000, callbacks[2].Length);
            Assert.AreEqual(24, callbacks[3].Length);
            CollectionAssert.AreEqual(dataChecksum, streamChecksumCalculator.GetCurrentHash());
        }

        private static byte[] ChecksumInlineStorageCrc64(Span<byte> data, NonCryptographicHashAlgorithm algorithm)
        {
            algorithm.Append(data);
            return algorithm.GetCurrentHash();
        }
    }
}
