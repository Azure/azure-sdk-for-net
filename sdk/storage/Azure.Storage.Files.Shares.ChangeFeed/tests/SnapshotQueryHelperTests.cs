// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.Shares;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Tests for <see cref="SnapshotQueryHelper"/> which converts ISO 8601 snapshot timestamps
    /// into hierarchical blob paths used to locate snapshot metadata.
    /// </summary>
    public class SnapshotQueryHelperTests : ShareChangeFeedTestBase
    {
        public SnapshotQueryHelperTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that a standard UTC timestamp on the hour is converted to the expected hierarchical path.
        /// </summary>
        [Test]
        public void SnapshotTimestampToPath()
        {
            string path = SnapshotQueryHelper.SnapshotTimestampToPath("2023-07-18T08:00:00.000Z");
            Assert.AreEqual("idx/snapshot/2023/07/18/08/00/00/meta.json", path);
        }

        /// <summary>
        /// Verifies that a timestamp with non-zero seconds preserves the seconds component in the path.
        /// </summary>
        [Test]
        public void SnapshotTimestampToPath_WithSeconds()
        {
            string path = SnapshotQueryHelper.SnapshotTimestampToPath("2024-01-15T14:30:45.000Z");
            Assert.AreEqual("idx/snapshot/2024/01/15/14/30/45/meta.json", path);
        }

        /// <summary>
        /// Verifies that a midnight timestamp produces zero-padded hour, minute, and second path segments.
        /// </summary>
        [Test]
        public void SnapshotTimestampToPath_Midnight()
        {
            string path = SnapshotQueryHelper.SnapshotTimestampToPath("2024-06-01T00:00:00.000Z");
            Assert.AreEqual("idx/snapshot/2024/06/01/00/00/00/meta.json", path);
        }

        /// <summary>
        /// Verifies that ReadSnapshotMetadataAsync correctly parses a snapshot meta.json blob
        /// and returns a populated <see cref="SnapshotMetadata"/> instance.
        /// </summary>
        [Test]
        public async Task ReadSnapshotMetadataAsync_HappyPath()
        {
            // Arrange
            string snapshotTimestamp = "2024-01-15T08:00:00.000Z";
            string expectedPath = "idx/snapshot/2024/01/15/08/00/00/meta.json";

            string json = @"{
                ""version"": 0,
                ""snapshotTimestamp"": ""2024-01-15T08:00:00.000Z"",
                ""cvId"": 100,
                ""minLogWindowForNextSnapshot"": ""2024-01-15T08:00:00.000Z"",
                ""maxLogWindowForCurrentSnapshot"": ""2024-01-15T09:00:00.000Z"",
                ""status"": ""Finalized""
            }";

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            containerClient.Setup(c => c.GetBlobClient(expectedPath)).Returns(blobClient.Object);

            BlobDownloadStreamingResult streamingResult = BlobsModelFactory.BlobDownloadStreamingResult(
                content: new MemoryStream(Encoding.UTF8.GetBytes(json)));

            if (IsAsync)
            {
                blobClient.Setup(b => b.DownloadStreamingAsync(
                    It.IsAny<BlobDownloadOptions>(),
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(streamingResult, null));
            }
            else
            {
                blobClient.Setup(b => b.DownloadStreaming(
                    It.IsAny<BlobDownloadOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(Response.FromValue(streamingResult, null));
            }

            // Act
            SnapshotMetadata metadata = await SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                containerClient.Object,
                snapshotTimestamp,
                IsAsync,
                CancellationToken.None);

            // Assert
            Assert.AreEqual(0, metadata.Version);
            Assert.AreEqual(100, metadata.CvId);
            Assert.AreEqual("Finalized", metadata.Status);
            Assert.AreEqual(
                new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                metadata.SnapshotTimestamp);
            Assert.AreEqual(
                new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                metadata.MinLogWindowForNextSnapshot);
            Assert.AreEqual(
                new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero),
                metadata.MaxLogWindowForCurrentSnapshot);

            containerClient.Verify(c => c.GetBlobClient(expectedPath));
        }

        /// <summary>
        /// Verifies that ReadSnapshotMetadataAsync throws an <see cref="ArgumentException"/>
        /// with a helpful message when the snapshot meta.json blob does not exist.
        /// </summary>
        [Test]
        public void ReadSnapshotMetadataAsync_BlobNotFound_ThrowsHelpfulMessage()
        {
            // Arrange
            string snapshotTimestamp = "2024-03-01T12:00:00.000Z";
            string expectedPath = "idx/snapshot/2024/03/01/12/00/00/meta.json";

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            containerClient.Setup(c => c.GetBlobClient(expectedPath)).Returns(blobClient.Object);

            // Simulate a BlobNotFound error from the storage service.
            RequestFailedException blobNotFound = new RequestFailedException(
                status: 404,
                message: "The specified blob does not exist.",
                errorCode: BlobErrorCode.BlobNotFound.ToString(),
                innerException: null);

            if (IsAsync)
            {
                blobClient.Setup(b => b.DownloadStreamingAsync(
                    It.IsAny<BlobDownloadOptions>(),
                    It.IsAny<CancellationToken>()))
                    .ThrowsAsync(blobNotFound);
            }
            else
            {
                blobClient.Setup(b => b.DownloadStreaming(
                    It.IsAny<BlobDownloadOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Throws(blobNotFound);
            }

            // Act & Assert
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                    containerClient.Object,
                    snapshotTimestamp,
                    IsAsync,
                    CancellationToken.None));

            StringAssert.Contains("Snapshot metadata not found", ex.Message);
            StringAssert.Contains(snapshotTimestamp, ex.Message);
            StringAssert.Contains(expectedPath, ex.Message);
            Assert.IsInstanceOf<RequestFailedException>(ex.InnerException);
        }
    }
}
