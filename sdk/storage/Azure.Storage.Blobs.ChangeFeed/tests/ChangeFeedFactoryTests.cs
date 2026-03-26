// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class ChangeFeedFactoryTests : ChangeFeedTestBase
    {
        public ChangeFeedFactoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Tests retrieving year paths from the change feed index, filtering out the initialization segment.
        /// </summary>
        [RecordedTest]
        public async Task GetYearPathsTest()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetYearsPathFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetYearPathFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(pageable);
            }

            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>();
            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object, segmentFactory.Object);

            // Act
            Queue<string> years = await changeFeedFactory.GetYearPathsInternal(
                IsAsync,
                default).ConfigureAwait(false);

            // Assert
            Queue<string> expectedYears = new Queue<string>();
            expectedYears.Enqueue("idx/segments/2019/");
            expectedYears.Enqueue("idx/segments/2020/");
            expectedYears.Enqueue("idx/segments/2022/");
            expectedYears.Enqueue("idx/segments/2023/");
            Assert.AreEqual(expectedYears, years);
        }

        /// <summary>
        /// Tests that BuildChangeFeed throws ArgumentException when $blobchangefeed container doesn't exist.
        /// </summary>
        [RecordedTest]
        public async Task ChangeFeedNotEnabled()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);
            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object,
                segmentFactory.Object);

            if (IsAsync)
            {
                containerClient.Setup(r => r.ExistsAsync(default)).ReturnsAsync(Response.FromValue(false, new MockResponse(404)));
            }
            else
            {
                containerClient.Setup(r => r.Exists(default)).Returns(Response.FromValue(false, new MockResponse(404)));
            }

            // Act / Assert
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await changeFeedFactory.BuildChangeFeed(
                    startTime: null,
                    endTime: null,
                    continuation: null,
                    async: IsAsync,
                    cancellationToken: CancellationToken.None));

            Assert.That(ex.Message, Does.Contain("Change Feed hasn't been enabled"));
        }

        /// <summary>
        /// Tests that BuildChangeFeed throws ArgumentException when cursor URL host doesn't match container URL host.
        /// </summary>
        [RecordedTest]
        public async Task ValidateCursor_HostMismatch()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);
            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object,
                segmentFactory.Object);

            Uri containerUri = new Uri("https://account.blob.core.windows.net/$blobchangefeed");
            containerClient.Setup(r => r.Uri).Returns(containerUri);

            if (IsAsync)
            {
                containerClient.Setup(r => r.ExistsAsync(default)).ReturnsAsync(Response.FromValue(true, new MockResponse(200)));
            }
            else
            {
                containerClient.Setup(r => r.Exists(default)).Returns(Response.FromValue(true, new MockResponse(200)));
            }

            SegmentCursor segmentCursor = new SegmentCursor(
                "idx/segments/2020/01/16/2300/meta.json",
                new List<ShardCursor>(),
                "log/00/2020/01/16/2300/");
            ChangeFeedCursor cursor = new ChangeFeedCursor(
                urlHost: "different-account.blob.core.windows.net",
                endDateTime: null,
                currentSegmentCursor: segmentCursor);

            string continuation = System.Text.Json.JsonSerializer.Serialize(cursor);

            // Act / Assert
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await changeFeedFactory.BuildChangeFeed(
                    startTime: null,
                    endTime: null,
                    continuation: continuation,
                    async: IsAsync,
                    cancellationToken: CancellationToken.None));

            Assert.That(ex.Message, Does.Contain("Cursor URL Host does not match"));
        }

        /// <summary>
        /// Tests that BuildChangeFeed throws ArgumentException when cursor version is not supported.
        /// </summary>
        [RecordedTest]
        public async Task ValidateCursor_UnsupportedVersion()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);
            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object,
                segmentFactory.Object);

            Uri containerUri = new Uri("https://account.blob.core.windows.net/$blobchangefeed");
            containerClient.Setup(r => r.Uri).Returns(containerUri);

            if (IsAsync)
            {
                containerClient.Setup(r => r.ExistsAsync(default)).ReturnsAsync(Response.FromValue(true, new MockResponse(200)));
            }
            else
            {
                containerClient.Setup(r => r.Exists(default)).Returns(Response.FromValue(true, new MockResponse(200)));
            }

            SegmentCursor segmentCursor = new SegmentCursor(
                "idx/segments/2020/01/16/2300/meta.json",
                new List<ShardCursor>(),
                "log/00/2020/01/16/2300/");
            ChangeFeedCursor cursor = new ChangeFeedCursor
            {
                CursorVersion = 2,
                UrlHost = containerUri.Host,
                EndTime = null,
                CurrentSegmentCursor = segmentCursor
            };

            string continuation = System.Text.Json.JsonSerializer.Serialize(cursor);

            // Act / Assert
            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await changeFeedFactory.BuildChangeFeed(
                    startTime: null,
                    endTime: null,
                    continuation: continuation,
                    async: IsAsync,
                    cancellationToken: CancellationToken.None));

            Assert.That(ex.Message, Does.Contain("Unsupported cursor version"));
        }

        /// <summary>
        /// Tests that BuildChangeFeed returns an empty ChangeFeed when the meta segments blob does not exist.
        /// </summary>
        [RecordedTest]
        public async Task ChangeFeedEnabledNoMetaSegmentsBlob()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);
            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object,
                segmentFactory.Object);

            if (IsAsync)
            {
                containerClient.Setup(r => r.ExistsAsync(default)).ReturnsAsync(Response.FromValue(true, new MockResponse(200)));
            }
            else
            {
                containerClient.Setup(r => r.Exists(default)).Returns(Response.FromValue(true, new MockResponse(200)));
            }

            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);

            RequestFailedException ex = new RequestFailedException(
                status: 404,
                message: "The specified blob does not exist.",
                errorCode: BlobErrorCode.BlobNotFound.ToString(),
                innerException: null);

            if (IsAsync)
            {
                blobClient.Setup(r => r.DownloadStreamingAsync(
                    default,
                    CancellationToken.None)).ThrowsAsync(ex);
            }
            else
            {
                blobClient.Setup(r => r.DownloadStreaming(
                    default,
                    CancellationToken.None)).Throws(ex);
            }

            // Act
            ChangeFeed changeFeed = await changeFeedFactory.BuildChangeFeed(
                startTime: null,
                endTime: null,
                continuation: null,
                async: IsAsync,
                cancellationToken: CancellationToken.None);

            // Assert
            Assert.IsFalse(changeFeed.HasNext());

            if (IsAsync)
            {
                containerClient.Verify(r => r.ExistsAsync(default));
            }
            else
            {
                containerClient.Verify(r => r.Exists(default));
            }

            containerClient.Verify(r => r.GetBlobClient(Constants.ChangeFeed.MetaSegmentsPath));

            if (IsAsync)
            {
                blobClient.Verify(r => r.DownloadStreamingAsync(
                    default,
                    CancellationToken.None));
            }
            else
            {
                blobClient.Verify(r => r.DownloadStreaming(
                    default,
                    CancellationToken.None));
            }
        }
    }
}
