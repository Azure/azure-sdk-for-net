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
using Azure.Storage.ChangeFeed.Common;
using Azure.Storage.Files.Shares;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Mocked unit tests verifying that <see cref="ShareChangeFeedClientOptions.IncludeUnfinalizedEvents"/>
    /// causes <see cref="ChangeFeedFactoryBase{TEvent}"/> to bypass the lastConsumable cap when enumerating segments.
    /// </summary>
    public class ShareChangeFeedUnfinalizedTests : ShareChangeFeedTestBase
    {
        public ShareChangeFeedUnfinalizedTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        // lastConsumable falls in the middle of the mocked segment range. With cap on, segments
        // at or before this time should be returned (3 of 5). With cap off, all 5 should be returned.
        private static readonly DateTimeOffset LastConsumable = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);

        [Test]
        public async Task BuildChangeFeed_FlagOff_StopsAtLastConsumable()
        {
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
                includeUnfinalizedEvents: false);

            await DrainAsync(factory);

            // Segments at or before lastConsumable (08:30) should be visited.
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0815/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0830/meta.json", Times.Once());
            // Segments after lastConsumable should NOT be visited.
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0845/meta.json", Times.Never());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Never());
        }

        [Test]
        public async Task BuildChangeFeed_FlagOn_ReturnsSegmentsPastLastConsumable()
        {
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
                includeUnfinalizedEvents: true);

            await DrainAsync(factory);

            // All five segments — including those past lastConsumable (08:30) — should be visited.
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0815/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0830/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0845/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Once());
        }

        [Test]
        public async Task BuildChangeFeed_FlagOn_NoMetadata_StillScansSegments()
        {
            // When meta/segments.json is missing (brand-new change feed), the default reader returns
            // an empty change feed. With the flag on, we should still attempt to enumerate segments.
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer(metaBlobExists: false);

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
                includeUnfinalizedEvents: true);

            await DrainAsync(factory);

            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Once());
        }

        private async Task DrainAsync(ChangeFeedFactoryBase<ShareChangeFeedEvent> factory)
        {
            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: null,
                endTime: null,
                continuation: null,
                async: IsAsync,
                cancellationToken: CancellationToken.None);

            // Each iteration's GetPage internally drains every advanceable segment because the
            // mocked segments are empty, so a single GetPage call is sufficient — but loop
            // defensively to ensure all segments are visited regardless of internal page behavior.
            while (changeFeed.HasNext())
            {
                await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);
            }
        }

        private Mock<SegmentFactoryBase<ShareChangeFeedEvent>> SetupRecordingSegmentFactory()
        {
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> factory = new Mock<SegmentFactoryBase<ShareChangeFeedEvent>>();

            // For any segment path we are asked about, hand back an empty SegmentBase so iteration
            // advances through the queue without needing real Avro chunks.
            factory.Setup(f => f.BuildSegment(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<SegmentCursor>()))
                .Returns<bool, string, SegmentCursor>((_, path, _) =>
                    Task.FromResult(new SegmentBase<ShareChangeFeedEvent>(
                        new List<ShardBase<ShareChangeFeedEvent>>(),
                        0,
                        ChangeFeedExtensionsBase.ToDateTimeOffset(path).Value,
                        path)));

            return factory;
        }

        private Mock<BlobContainerClient> SetupContainer(bool metaBlobExists = true)
        {
            Mock<BlobContainerClient> container = new Mock<BlobContainerClient>(MockBehavior.Strict);

            container.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/$fileschangefeed-testguid"));

            if (IsAsync)
                container.Setup(c => c.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                container.Setup(c => c.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            // meta/segments.json — present or BlobNotFound depending on test scenario.
            Mock<BlobClient> metaBlob = new Mock<BlobClient>(MockBehavior.Strict);
            container.Setup(c => c.GetBlobClient("meta/segments.json")).Returns(metaBlob.Object);

            if (metaBlobExists)
            {
                BlobDownloadStreamingResult metaResult = BlobsModelFactory.BlobDownloadStreamingResult(
                    content: new MemoryStream(Encoding.UTF8.GetBytes(
                        $@"{{""lastConsumable"":""{LastConsumable:O}""}}")));

                if (IsAsync)
                {
                    metaBlob.Setup(b => b.DownloadStreamingAsync(
                        It.IsAny<BlobDownloadOptions>(),
                        It.IsAny<CancellationToken>()))
                        .ReturnsAsync(Response.FromValue(metaResult, null));
                }
                else
                {
                    metaBlob.Setup(b => b.DownloadStreaming(
                        It.IsAny<BlobDownloadOptions>(),
                        It.IsAny<CancellationToken>()))
                        .Returns(Response.FromValue(metaResult, null));
                }
            }
            else
            {
                RequestFailedException notFound = new RequestFailedException(
                    status: 404,
                    message: "The specified blob does not exist.",
                    errorCode: BlobErrorCode.BlobNotFound.ToString(),
                    innerException: null);

                if (IsAsync)
                    metaBlob.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>())).ThrowsAsync(notFound);
                else
                    metaBlob.Setup(b => b.DownloadStreaming(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>())).Throws(notFound);
            }

            // First hierarchy call returns a single year (2024). Subsequent calls return the segment listing.
            int callCount = 0;
            if (IsAsync)
            {
                container.Setup(c => c.GetBlobsByHierarchyAsync(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(() =>
                    {
                        callCount++;
                        return callCount == 1
                            ? new MockAsyncPageable(SingleYearAsync)
                            : new MockAsyncPageable(GetSegmentsInYearFuncAsync);
                    });
            }
            else
            {
                container.Setup(c => c.GetBlobsByHierarchy(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(() =>
                    {
                        callCount++;
                        return callCount == 1
                            ? new MockSyncPageable(SingleYear)
                            : new MockSyncPageable(GetSegmentsInYearFunc);
                    });
            }

            return container;
        }

        private static Page<BlobHierarchyItem> SingleYear(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2024/", null),
            });

        private static Task<Page<BlobHierarchyItem>> SingleYearAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(SingleYear(continuation, pageSizeHint));

        private static void VerifyBuildSegment(
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> factory,
            string path,
            Times times)
        {
            factory.Verify(
                f => f.BuildSegment(It.IsAny<bool>(), path, It.IsAny<SegmentCursor>()),
                times);
        }

        private class MockAsyncPageable : AsyncPageable<BlobHierarchyItem>
        {
            private readonly Func<string, int?, Task<Page<BlobHierarchyItem>>> _pageFunc;
            public MockAsyncPageable(Func<string, int?, Task<Page<BlobHierarchyItem>>> pageFunc) => _pageFunc = pageFunc;

            public override async IAsyncEnumerable<Page<BlobHierarchyItem>> AsPages(
                string continuationToken = null, int? pageSizeHint = null)
            {
                yield return await _pageFunc(continuationToken, pageSizeHint);
            }
        }

        private class MockSyncPageable : Pageable<BlobHierarchyItem>
        {
            private readonly Func<string, int?, Page<BlobHierarchyItem>> _pageFunc;
            public MockSyncPageable(Func<string, int?, Page<BlobHierarchyItem>> pageFunc) => _pageFunc = pageFunc;

            public override IEnumerable<Page<BlobHierarchyItem>> AsPages(
                string continuationToken = null, int? pageSizeHint = null)
            {
                yield return _pageFunc(continuationToken, pageSizeHint);
            }
        }
    }
}
