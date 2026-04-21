// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Tests for <see cref="ChangeFeedFactoryBase{TEvent}"/> covering container validation,
    /// cursor checks, and year path discovery.
    /// </summary>
    public class ChangeFeedFactoryBaseTests : ChangeFeedCommonTestBase
    {
        public ChangeFeedFactoryBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that BuildChangeFeed throws when the change feed container does not exist.
        /// </summary>
        [Test]
        public void ChangeFeedNotEnabled_Throws()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

            // Container does not exist
            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(false, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(false, null));

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                new Mock<SegmentFactoryBase<TestEvent>>().Object,
                CreateTestConfig());

            Assert.ThrowsAsync<ArgumentException>(
                async () => await factory.BuildChangeFeed(null, null, null, IsAsync, CancellationToken.None));
        }

        /// <summary>
        /// Verifies that cursor validation rejects a cursor whose UrlHost doesn't match the container.
        /// </summary>
        [Test]
        public void ValidateCursor_HostMismatch_Throws()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            containerClient.Setup(r => r.Uri).Returns(new Uri("https://account1.blob.core.windows.net/container"));

            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            // Build a continuation token with a different host
            ChangeFeedCursor cursor = new ChangeFeedCursor("account2.blob.core.windows.net", null,
                new SegmentCursor("idx/segments/2024/01/15/0800/meta.json", new List<ShardCursor>(), null));
            string continuation = System.Text.Json.JsonSerializer.Serialize(cursor);

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                new Mock<SegmentFactoryBase<TestEvent>>().Object,
                CreateTestConfig());

            Assert.ThrowsAsync<ArgumentException>(
                async () => await factory.BuildChangeFeed(null, null, continuation, IsAsync, CancellationToken.None));
        }

        /// <summary>
        /// Verifies that cursor validation rejects an unsupported cursor version.
        /// </summary>
        [Test]
        public void ValidateCursor_UnsupportedVersion_Throws()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            containerClient.Setup(r => r.Uri).Returns(new Uri("https://account.blob.core.windows.net/container"));

            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            ChangeFeedCursor cursor = new ChangeFeedCursor("account.blob.core.windows.net", null,
                new SegmentCursor("idx/segments/2024/01/15/0800/meta.json", new List<ShardCursor>(), null))
            {
                CursorVersion = 99  // Unsupported version
            };
            string continuation = System.Text.Json.JsonSerializer.Serialize(cursor);

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                new Mock<SegmentFactoryBase<TestEvent>>().Object,
                CreateTestConfig());

            Assert.ThrowsAsync<ArgumentException>(
                async () => await factory.BuildChangeFeed(null, null, continuation, IsAsync, CancellationToken.None));
        }

        #region GetLastConsumableInternal

        /// <summary>
        /// Verifies that GetLastConsumableInternal returns the lastConsumable timestamp
        /// when the metadata blob exists and contains valid JSON.
        /// </summary>
        [Test]
        public async Task GetLastConsumableInternal_BlobExists_ReturnsTimestamp()
        {
            // Arrange
            string json = @"{""lastConsumable"":""2024-01-15T08:00:00Z""}";

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            containerClient.Setup(c => c.GetBlobClient("meta/segments.json")).Returns(blobClient.Object);

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
            DateTimeOffset? result = await ChangeFeedFactoryBase<TestEvent>.GetLastConsumableInternal(
                containerClient.Object,
                "meta/segments.json",
                IsAsync,
                CancellationToken.None);

            // Assert
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(
                new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                result.Value);

            containerClient.Verify(c => c.GetBlobClient("meta/segments.json"));
        }

        /// <summary>
        /// Verifies that GetLastConsumableInternal returns null when the metadata blob does not exist.
        /// </summary>
        [Test]
        public async Task GetLastConsumableInternal_BlobNotFound_ReturnsNull()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);

            containerClient.Setup(c => c.GetBlobClient("meta/segments.json")).Returns(blobClient.Object);

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

            // Act
            DateTimeOffset? result = await ChangeFeedFactoryBase<TestEvent>.GetLastConsumableInternal(
                containerClient.Object,
                "meta/segments.json",
                IsAsync,
                CancellationToken.None);

            // Assert
            Assert.IsFalse(result.HasValue);
        }

        #endregion

        #region BuildChangeFeed happy path

        /// <summary>
        /// Verifies that BuildChangeFeed returns a populated ChangeFeedBase when the container exists,
        /// metadata is present, and year/segment paths are discoverable.
        /// </summary>
        [Test]
        public async Task BuildChangeFeed_HappyPath_ReturnsPopulatedChangeFeed()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<SegmentFactoryBase<TestEvent>> segmentFactory = new Mock<SegmentFactoryBase<TestEvent>>();

            containerClient.Setup(r => r.Uri).Returns(new Uri("https://account.blob.core.windows.net/container"));

            // Container exists
            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            // GetLastConsumable — metadata blob with valid JSON
            SetupMetadataDownload(containerClient, @"{""lastConsumable"":""2024-01-15T09:00:00Z""}");

            // Year paths
            SetupBlobHierarchy(containerClient);

            // Segment factory returns a real segment with empty shards
            SegmentBase<TestEvent> segment = new SegmentBase<TestEvent>(
                new List<ShardBase<TestEvent>>(),
                0,
                new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                "idx/segments/2024/01/15/0800/meta.json");

            segmentFactory.Setup(f => f.BuildSegment(
                IsAsync,
                "idx/segments/2024/01/15/0800/meta.json",
                null))
                .ReturnsAsync(segment);

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                segmentFactory.Object,
                CreateTestConfig());

            // Act
            ChangeFeedBase<TestEvent> changeFeed = await factory.BuildChangeFeed(
                null,
                null,
                null,
                IsAsync,
                CancellationToken.None);

            // Assert — returned a non-empty ChangeFeedBase
            Assert.IsNotNull(changeFeed);
            Assert.AreEqual(
                new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero),
                changeFeed.LastConsumable);
        }

        /// <summary>
        /// Verifies that BuildChangeFeed returns an empty ChangeFeedBase when the metadata blob
        /// does not exist (change feed enabled but no events yet).
        /// </summary>
        [Test]
        public async Task BuildChangeFeed_NoMetadata_ReturnsEmpty()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            // Metadata blob not found
            Mock<BlobClient> metaBlobClient = new Mock<BlobClient>(MockBehavior.Strict);
            containerClient.Setup(c => c.GetBlobClient("meta/segments.json")).Returns(metaBlobClient.Object);

            RequestFailedException blobNotFound = new RequestFailedException(
                status: 404,
                message: "The specified blob does not exist.",
                errorCode: BlobErrorCode.BlobNotFound.ToString(),
                innerException: null);

            if (IsAsync)
                metaBlobClient.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>())).ThrowsAsync(blobNotFound);
            else
                metaBlobClient.Setup(b => b.DownloadStreaming(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>())).Throws(blobNotFound);

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                new Mock<SegmentFactoryBase<TestEvent>>().Object,
                CreateTestConfig());

            // Act
            ChangeFeedBase<TestEvent> changeFeed = await factory.BuildChangeFeed(
                null, null, null, IsAsync, CancellationToken.None);

            // Assert
            Assert.IsNotNull(changeFeed);
            Assert.IsFalse(changeFeed.HasNext());
        }

        /// <summary>
        /// Verifies that BuildChangeFeed returns an empty ChangeFeedBase when the change feed
        /// container has metadata but no year paths.
        /// </summary>
        [Test]
        public async Task BuildChangeFeed_NoYears_ReturnsEmpty()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            SetupMetadataDownload(containerClient, @"{""lastConsumable"":""2024-01-15T09:00:00Z""}");

            // Empty year listing
            if (IsAsync)
            {
                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new MockPageable(EmptyPageFuncAsync));
            }
            else
            {
                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new MockSyncPageable(EmptyPageFunc));
            }

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                new Mock<SegmentFactoryBase<TestEvent>>().Object,
                CreateTestConfig());

            // Act
            ChangeFeedBase<TestEvent> changeFeed = await factory.BuildChangeFeed(
                null, null, null, IsAsync, CancellationToken.None);

            // Assert
            Assert.IsNotNull(changeFeed);
            Assert.IsFalse(changeFeed.HasNext());
        }

        /// <summary>
        /// Verifies that BuildChangeFeed returns an empty ChangeFeedBase when years exist
        /// but no segments match the time window.
        /// </summary>
        [Test]
        public async Task BuildChangeFeed_NoSegmentsInYear_ReturnsEmpty()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

            if (IsAsync)
                containerClient.Setup(r => r.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                containerClient.Setup(r => r.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            SetupMetadataDownload(containerClient, @"{""lastConsumable"":""2024-01-15T09:00:00Z""}");

            // Year paths call returns years, segment paths call returns empty
            int callCount = 0;
            if (IsAsync)
            {
                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(() =>
                    {
                        callCount++;
                        return callCount == 1
                            ? new MockPageable(GetYearPathFuncAsync)
                            : new MockPageable(EmptyPageFuncAsync);
                    });
            }
            else
            {
                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(() =>
                    {
                        callCount++;
                        return callCount == 1
                            ? new MockSyncPageable(GetYearPathFunc)
                            : new MockSyncPageable(EmptyPageFunc);
                    });
            }

            ChangeFeedFactoryBase<TestEvent> factory = new ChangeFeedFactoryBase<TestEvent>(
                containerClient.Object,
                new Mock<SegmentFactoryBase<TestEvent>>().Object,
                CreateTestConfig());

            // Act
            ChangeFeedBase<TestEvent> changeFeed = await factory.BuildChangeFeed(
                null, null, null, IsAsync, CancellationToken.None);

            // Assert
            Assert.IsNotNull(changeFeed);
            Assert.IsFalse(changeFeed.HasNext());
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Sets up the mock BlobContainerClient to return a metadata blob download with the given JSON content.
        /// </summary>
        private void SetupMetadataDownload(Mock<BlobContainerClient> containerClient, string json)
        {
            Mock<BlobClient> metaBlobClient = new Mock<BlobClient>(MockBehavior.Strict);
            containerClient.Setup(c => c.GetBlobClient("meta/segments.json")).Returns(metaBlobClient.Object);

            BlobDownloadStreamingResult streamingResult = BlobsModelFactory.BlobDownloadStreamingResult(
                content: new MemoryStream(Encoding.UTF8.GetBytes(json)));

            if (IsAsync)
            {
                metaBlobClient.Setup(b => b.DownloadStreamingAsync(
                    It.IsAny<BlobDownloadOptions>(),
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(streamingResult, null));
            }
            else
            {
                metaBlobClient.Setup(b => b.DownloadStreaming(
                    It.IsAny<BlobDownloadOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(Response.FromValue(streamingResult, null));
            }
        }

        /// <summary>
        /// Sets up mock blob hierarchy calls: first call returns year paths, second call returns segment paths.
        /// </summary>
        private void SetupBlobHierarchy(Mock<BlobContainerClient> containerClient)
        {
            int callCount = 0;

            if (IsAsync)
            {
                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(() =>
                    {
                        callCount++;
                        return callCount == 1
                            ? new MockPageable(GetYearPathFuncAsync)
                            : new MockPageable(GetSegmentsInYearFuncAsync);
                    });
            }
            else
            {
                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(() =>
                    {
                        callCount++;
                        return callCount == 1
                            ? new MockSyncPageable(GetYearPathFunc)
                            : new MockSyncPageable(GetSegmentsInYearFunc);
                    });
            }
        }

        private static Page<BlobHierarchyItem> EmptyPageFunc(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>());

        private static Task<Page<BlobHierarchyItem>> EmptyPageFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(EmptyPageFunc(continuation, pageSizeHint));

        /// <summary>
        /// Mock async pageable for blob hierarchy items.
        /// </summary>
        private class MockPageable : AsyncPageable<BlobHierarchyItem>
        {
            private readonly Func<string, int?, Task<Page<BlobHierarchyItem>>> _pageFunc;

            public MockPageable(Func<string, int?, Task<Page<BlobHierarchyItem>>> pageFunc)
            {
                _pageFunc = pageFunc;
            }

            public override async IAsyncEnumerable<Page<BlobHierarchyItem>> AsPages(
                string continuationToken = null, int? pageSizeHint = null)
            {
                yield return await _pageFunc(continuationToken, pageSizeHint);
            }
        }

        /// <summary>
        /// Mock sync pageable for blob hierarchy items.
        /// </summary>
        private class MockSyncPageable : Pageable<BlobHierarchyItem>
        {
            private readonly Func<string, int?, Page<BlobHierarchyItem>> _pageFunc;

            public MockSyncPageable(Func<string, int?, Page<BlobHierarchyItem>> pageFunc)
            {
                _pageFunc = pageFunc;
            }

            public override IEnumerable<Page<BlobHierarchyItem>> AsPages(
                string continuationToken = null, int? pageSizeHint = null)
            {
                yield return _pageFunc(continuationToken, pageSizeHint);
            }
        }

        #endregion
    }
}
