// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Tests intentionally use inexact reads to validate partial-read and multi-block behavior.
#pragma warning disable CA2022

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Tests for <see cref="LazyLoadingBlobStream"/> covering lazy initialization,
    /// block-based downloading, parameter validation, and stream property behavior.
    /// </summary>
    public class LazyLoadingBlobStreamTests : ChangeFeedCommonTestBase
    {
        public LazyLoadingBlobStreamTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Creates a mock <see cref="BlobDownloadStreamingResult"/> with the given content bytes
        /// and a Content-Range header in the format "bytes {offset}-{offset+length-1}/{totalBlobLength}".
        /// </summary>
        private static BlobDownloadStreamingResult CreateStreamingResult(
            byte[] content,
            long offset,
            long totalBlobLength)
        {
            long endByte = content.Length > 0 ? offset + content.Length - 1 : offset;
            string contentRange = $"bytes {offset}-{endByte}/{totalBlobLength}";

            BlobDownloadDetails details = BlobsModelFactory.BlobDownloadDetails(
                contentLength: content.Length,
                contentRange: contentRange);

            return BlobsModelFactory.BlobDownloadStreamingResult(
                content: new MemoryStream(content),
                details: details);
        }

        /// <summary>
        /// Sets up the mock <see cref="BlobClient"/> to return a streaming result for a download call
        /// matching the given <see cref="HttpRange"/>. Configures sync or async based on <see cref="IsAsync"/>.
        /// </summary>
        private void SetupDownload(
            Mock<BlobClient> blobClient,
            long expectedOffset,
            long expectedBlockSize,
            BlobDownloadStreamingResult result)
        {
            if (IsAsync)
            {
                blobClient.Setup(b => b.DownloadStreamingAsync(
                    It.Is<BlobDownloadOptions>(o => o.Range.Offset == expectedOffset && o.Range.Length == expectedBlockSize),
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(result, null));
            }
            else
            {
                blobClient.Setup(b => b.DownloadStreaming(
                    It.Is<BlobDownloadOptions>(o => o.Range.Offset == expectedOffset && o.Range.Length == expectedBlockSize),
                    It.IsAny<CancellationToken>()))
                    .Returns(Response.FromValue(result, null));
            }
        }

        #region Read — happy paths

        /// <summary>
        /// Verifies that the first Read call triggers lazy initialization and downloads the first block.
        /// </summary>
        [Test]
        public async Task Read_FirstCall_InitializesAndDownloadsBlock()
        {
            // Arrange
            byte[] blobData = new byte[] { 1, 2, 3, 4, 5 };
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            BlobDownloadStreamingResult result = CreateStreamingResult(blobData, offset: 0, totalBlobLength: 5);
            SetupDownload(blobClient, expectedOffset: 0, expectedBlockSize: 10, result);

            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(blobClient.Object, offset: 0, blockSize: 10);

            // Act
            byte[] buffer = new byte[10];
            int bytesRead = IsAsync
                ? await stream.ReadAsync(buffer, 0, buffer.Length, CancellationToken.None)
                : stream.Read(buffer, 0, buffer.Length);

            // Assert
            Assert.AreEqual(5, bytesRead);
            Assert.AreEqual(1, buffer[0]);
            Assert.AreEqual(5, buffer[4]);
        }

        /// <summary>
        /// Verifies that reading more data than a single block triggers sequential block downloads.
        /// </summary>
        [Test]
        public async Task Read_SpansMultipleBlocks_DownloadsSequentially()
        {
            // Arrange — blob is 10 bytes, block size is 5
            byte[] block1 = new byte[] { 1, 2, 3, 4, 5 };
            byte[] block2 = new byte[] { 6, 7, 8, 9, 10 };
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            BlobDownloadStreamingResult result1 = CreateStreamingResult(block1, offset: 0, totalBlobLength: 10);
            BlobDownloadStreamingResult result2 = CreateStreamingResult(block2, offset: 5, totalBlobLength: 10);

            SetupDownload(blobClient, expectedOffset: 0, expectedBlockSize: 5, result1);
            SetupDownload(blobClient, expectedOffset: 5, expectedBlockSize: 5, result2);

            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(blobClient.Object, offset: 0, blockSize: 5);

            // Act — read all 10 bytes in one call
            byte[] buffer = new byte[10];
            int totalRead = 0;
            while (totalRead < 10)
            {
                int bytesRead = IsAsync
                    ? await stream.ReadAsync(buffer, totalRead, buffer.Length - totalRead, CancellationToken.None)
                    : stream.Read(buffer, totalRead, buffer.Length - totalRead);

                if (bytesRead == 0) break;
                totalRead += bytesRead;
            }

            // Assert
            Assert.AreEqual(10, totalRead);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i + 1, buffer[i]);
            }
        }

        /// <summary>
        /// Verifies that Read returns 0 after all blob bytes have been consumed.
        /// </summary>
        [Test]
        public async Task Read_EndOfBlob_ReturnsZero()
        {
            // Arrange — blob is 3 bytes, block size is 10
            byte[] blobData = new byte[] { 1, 2, 3 };
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            BlobDownloadStreamingResult result = CreateStreamingResult(blobData, offset: 0, totalBlobLength: 3);
            SetupDownload(blobClient, expectedOffset: 0, expectedBlockSize: 10, result);

            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(blobClient.Object, offset: 0, blockSize: 10);

            // Act — first read consumes everything
            byte[] buffer = new byte[10];
            int firstRead = IsAsync
                ? await stream.ReadAsync(buffer, 0, buffer.Length, CancellationToken.None)
                : stream.Read(buffer, 0, buffer.Length);

            // Second read should return 0
            int secondRead = IsAsync
                ? await stream.ReadAsync(buffer, 0, buffer.Length, CancellationToken.None)
                : stream.Read(buffer, 0, buffer.Length);

            // Assert
            Assert.AreEqual(3, firstRead);
            Assert.AreEqual(0, secondRead);
        }

        /// <summary>
        /// Verifies that Read returns 0 immediately when the blob is empty (zero content length on first download).
        /// </summary>
        [Test]
        public async Task Read_EmptyBlob_ReturnsZero()
        {
            // Arrange
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            BlobDownloadDetails details = BlobsModelFactory.BlobDownloadDetails(
                contentLength: 0,
                contentRange: "bytes 0-0/0");

            BlobDownloadStreamingResult result = BlobsModelFactory.BlobDownloadStreamingResult(
                content: new MemoryStream(Array.Empty<byte>()),
                details: details);

            SetupDownload(blobClient, expectedOffset: 0, expectedBlockSize: 10, result);

            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(blobClient.Object, offset: 0, blockSize: 10);

            // Act
            byte[] buffer = new byte[10];
            int bytesRead = IsAsync
                ? await stream.ReadAsync(buffer, 0, buffer.Length, CancellationToken.None)
                : stream.Read(buffer, 0, buffer.Length);

            // Assert
            Assert.AreEqual(0, bytesRead);
        }

        #endregion

        #region Read — parameter validation

        /// <summary>
        /// Verifies that Read throws <see cref="ArgumentNullException"/> when the buffer is null.
        /// </summary>
        [Test]
        public void Read_NullBuffer_Throws()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentNullException>(
                    async () => await stream.ReadAsync(null, 0, 10, CancellationToken.None));
            }
            else
            {
                Assert.Throws<ArgumentNullException>(
                    () => stream.Read(null, 0, 10));
            }
        }

        /// <summary>
        /// Verifies that Read throws <see cref="ArgumentOutOfRangeException"/> when offset is negative.
        /// </summary>
        [Test]
        public void Read_NegativeOffset_Throws()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            byte[] buffer = new byte[10];

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                    async () => await stream.ReadAsync(buffer, -1, 5, CancellationToken.None));
            }
            else
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    () => stream.Read(buffer, -1, 5));
            }
        }

        /// <summary>
        /// Verifies that Read throws <see cref="ArgumentOutOfRangeException"/> when offset exceeds buffer length.
        /// </summary>
        [Test]
        public void Read_OffsetExceedsBuffer_Throws()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            byte[] buffer = new byte[5];

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                    async () => await stream.ReadAsync(buffer, 10, 1, CancellationToken.None));
            }
            else
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    () => stream.Read(buffer, 10, 1));
            }
        }

        /// <summary>
        /// Verifies that Read throws <see cref="ArgumentOutOfRangeException"/> when count is negative.
        /// </summary>
        [Test]
        public void Read_NegativeCount_Throws()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            byte[] buffer = new byte[10];

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                    async () => await stream.ReadAsync(buffer, 0, -1, CancellationToken.None));
            }
            else
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    () => stream.Read(buffer, 0, -1));
            }
        }

        /// <summary>
        /// Verifies that Read throws <see cref="ArgumentOutOfRangeException"/> when offset + count exceeds buffer length.
        /// </summary>
        [Test]
        public void Read_OffsetPlusCountExceedsBuffer_Throws()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            byte[] buffer = new byte[10];

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                    async () => await stream.ReadAsync(buffer, 5, 8, CancellationToken.None));
            }
            else
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    () => stream.Read(buffer, 5, 8));
            }
        }

        #endregion

        #region Stream properties

        /// <summary>
        /// Verifies that CanRead returns true.
        /// </summary>
        [Test]
        public void CanRead_ReturnsTrue()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            Assert.IsTrue(stream.CanRead);
        }

        /// <summary>
        /// Verifies that CanSeek returns false.
        /// </summary>
        [Test]
        public void CanSeek_ReturnsFalse()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            Assert.IsFalse(stream.CanSeek);
        }

        /// <summary>
        /// Verifies that CanWrite throws <see cref="NotSupportedException"/>.
        /// </summary>
        [Test]
        public void CanWrite_ThrowsNotSupportedException()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            Assert.Throws<NotSupportedException>(() => { bool _ = stream.CanWrite; });
        }

        /// <summary>
        /// Verifies that Length throws <see cref="NotSupportedException"/>.
        /// </summary>
        [Test]
        public void Length_ThrowsNotSupportedException()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            Assert.Throws<NotSupportedException>(() => { long _ = stream.Length; });
        }

        /// <summary>
        /// Verifies that setting Position throws <see cref="NotSupportedException"/>.
        /// </summary>
        [Test]
        public void Position_Set_ThrowsNotSupportedException()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            Assert.Throws<NotSupportedException>(() => stream.Position = 0);
        }

        /// <summary>
        /// Verifies that Seek throws <see cref="NotSupportedException"/>.
        /// </summary>
        [Test]
        public void Seek_ThrowsNotSupportedException()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            Assert.Throws<NotSupportedException>(() => stream.Seek(0, SeekOrigin.Begin));
        }

        /// <summary>
        /// Verifies that SetLength throws <see cref="NotSupportedException"/>.
        /// </summary>
        [Test]
        public void SetLength_ThrowsNotSupportedException()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            Assert.Throws<NotSupportedException>(() => stream.SetLength(10));
        }

        /// <summary>
        /// Verifies that Write throws <see cref="NotSupportedException"/>.
        /// </summary>
        [Test]
        public void Write_ThrowsNotSupportedException()
        {
            LazyLoadingBlobStream stream = new LazyLoadingBlobStream(
                new Mock<BlobClient>().Object,
                offset: 0,
                blockSize: 10);

            Assert.Throws<NotSupportedException>(() => stream.Write(new byte[5], 0, 5));
        }

        #endregion
    }
}
