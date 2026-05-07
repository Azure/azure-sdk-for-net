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
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    /// <summary>
    /// Mocked unit tests verifying that <see cref="BlobChangeFeedClientOptions.IncludeNonFinalizedEvents"/>
    /// causes <see cref="ChangeFeedFactoryBase{TEvent}"/> to bypass the lastConsumable cap when enumerating
    /// segments, and that pages produced in that mode do not carry a continuation token.
    /// </summary>
    public class BlobChangeFeedNonFinalizedTests : ChangeFeedTestBase
    {
        public BlobChangeFeedNonFinalizedTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        // lastConsumable falls in the middle of the mocked segment range. With cap on, segments
        // at or before this time should be returned (3 of 5). With cap off, all 5 should be returned.
        private static readonly DateTimeOffset LastConsumable = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);

        [Test]
        public async Task BuildChangeFeed_IncludeNonFinalizedEventsFalse_StopsAtLastConsumable()
        {
            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<BlobChangeFeedEvent> factory = new ChangeFeedFactoryBase<BlobChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                BlobChangeFeedClient.CreateConfiguration(),
                includeNonFinalizedEvents: false);

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
        public async Task BuildChangeFeed_IncludeNonFinalizedEventsTrue_ReturnsSegmentsPastLastConsumable()
        {
            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<BlobChangeFeedEvent> factory = new ChangeFeedFactoryBase<BlobChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                BlobChangeFeedClient.CreateConfiguration(),
                includeNonFinalizedEvents: true);

            await DrainAsync(factory);

            // All five segments — including those past lastConsumable (08:30) — should be visited.
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0815/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0830/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0845/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Once());
        }

        [Test]
        public async Task BuildChangeFeed_IncludeNonFinalizedEventsTrue_NoMetadata_StillScansSegments()
        {
            // When meta/segments.json is missing (brand-new change feed), the default reader returns
            // an empty change feed. With IncludeNonFinalizedEvents=true, we should still attempt to
            // enumerate segments.
            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer(metaBlobExists: false);

            ChangeFeedFactoryBase<BlobChangeFeedEvent> factory = new ChangeFeedFactoryBase<BlobChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                BlobChangeFeedClient.CreateConfiguration(),
                includeNonFinalizedEvents: true);

            await DrainAsync(factory);

            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Once());
        }

        [Test]
        public async Task BuildChangeFeed_MultipleYears_SkipsYearsBeforeStartTime()
        {
            // Track which year prefixes are queried for segments. The first GetBlobsByHierarchy
            // call returns the year listing; subsequent calls list segments inside one year each.
            List<string> requestedSegmentPrefixes = new List<string>();

            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> segmentFactory = new Mock<SegmentFactoryBase<BlobChangeFeedEvent>>();
            segmentFactory.Setup(f => f.BuildSegment(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<SegmentCursor>()))
                .Returns<bool, string, SegmentCursor>((_, path, _) =>
                    Task.FromResult(new SegmentBase<BlobChangeFeedEvent>(
                        new List<ShardBase<BlobChangeFeedEvent>>(),
                        0,
                        ChangeFeedExtensionsBase.ToDateTimeOffset(path).Value,
                        path)));

            Mock<BlobContainerClient> container = new Mock<BlobContainerClient>(MockBehavior.Strict);
            container.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/$blobchangefeed"));
            container.Setup(c => c.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            container.Setup(c => c.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            // meta/segments.json: lastConsumable=2025-12-31T23:59:59Z so segments anywhere in 2024 or 2025 are eligible.
            Mock<BlobClient> metaBlob = new Mock<BlobClient>(MockBehavior.Strict);
            container.Setup(c => c.GetBlobClient("meta/segments.json")).Returns(metaBlob.Object);
            byte[] metaBytes = Encoding.UTF8.GetBytes(@"{""lastConsumable"":""2025-12-31T23:59:59Z""}");
            if (IsAsync)
                metaBlob.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() => Task.FromResult(Response.FromValue(BlobsModelFactory.BlobDownloadStreamingResult(content: new MemoryStream(metaBytes)), (Response)null)));
            else
                metaBlob.Setup(b => b.DownloadStreaming(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() => Response.FromValue(BlobsModelFactory.BlobDownloadStreamingResult(content: new MemoryStream(metaBytes)), (Response)null));

            int callCount = 0;
            Page<BlobHierarchyItem> YearListing() => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2023/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2024/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2025/", null),
            });
            Page<BlobHierarchyItem> EmptyListing() => new BlobHierarchyItemPage(new List<BlobHierarchyItem>());

            if (IsAsync)
            {
                container.Setup(c => c.GetBlobsByHierarchyAsync(It.IsAny<GetBlobsByHierarchyOptions>(), It.IsAny<CancellationToken>()))
                    .Returns((GetBlobsByHierarchyOptions opts, CancellationToken _) =>
                    {
                        callCount++;
                        if (callCount == 1) return new MockAsyncPageable((_, _) => Task.FromResult(YearListing()));
                        requestedSegmentPrefixes.Add(opts.Prefix);
                        return new MockAsyncPageable((_, _) => Task.FromResult(EmptyListing()));
                    });
            }
            else
            {
                container.Setup(c => c.GetBlobsByHierarchy(It.IsAny<GetBlobsByHierarchyOptions>(), It.IsAny<CancellationToken>()))
                    .Returns((GetBlobsByHierarchyOptions opts, CancellationToken _) =>
                    {
                        callCount++;
                        if (callCount == 1) return new MockSyncPageable((_, _) => YearListing());
                        requestedSegmentPrefixes.Add(opts.Prefix);
                        return new MockSyncPageable((_, _) => EmptyListing());
                    });
            }

            ChangeFeedFactoryBase<BlobChangeFeedEvent> factory = new ChangeFeedFactoryBase<BlobChangeFeedEvent>(
                container.Object,
                segmentFactory.Object,
                BlobChangeFeedClient.CreateConfiguration(),
                includeNonFinalizedEvents: false);

            DateTimeOffset startTime = new DateTimeOffset(2024, 6, 15, 0, 0, 0, TimeSpan.Zero);
            ChangeFeedBase<BlobChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: startTime, endTime: null, continuation: null, async: IsAsync, cancellationToken: CancellationToken.None);
            while (changeFeed.HasNext()) await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);

            // 2023/ should NOT appear (year is rounded down to 2023, which is before startTime's year 2024).
            CollectionAssert.DoesNotContain(requestedSegmentPrefixes, "idx/segments/2023/");
            // 2024/ and 2025/ should both have been queried because both are at or after startTime's year.
            CollectionAssert.Contains(requestedSegmentPrefixes, "idx/segments/2024/");
            CollectionAssert.Contains(requestedSegmentPrefixes, "idx/segments/2025/");
        }

        [Test]
        public async Task BuildChangeFeed_IncludeNonFinalizedEventsTrue_UserEndTimePastLastConsumable_UsesUserEndTime()
        {
            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<BlobChangeFeedEvent> factory = new ChangeFeedFactoryBase<BlobChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                BlobChangeFeedClient.CreateConfiguration(),
                includeNonFinalizedEvents: true);

            DateTimeOffset endTime = new DateTimeOffset(2024, 1, 15, 8, 45, 0, TimeSpan.Zero);
            ChangeFeedBase<BlobChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: null, endTime: endTime, continuation: null, async: IsAsync, cancellationToken: CancellationToken.None);
            while (changeFeed.HasNext()) await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);

            // With IncludeNonFinalizedEvents=true and user endTime=08:45, segments at 08:00, 08:15, 08:30,
            // 08:45 should be visited; segment at 09:00 should NOT be visited (past user's endTime).
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0815/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0830/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0845/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Never());
        }

        [Test]
        public async Task BuildChangeFeed_IncludeNonFinalizedEventsFalse_UserEndTimePastLastConsumable_StillCapsAtLastConsumable()
        {
            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<BlobChangeFeedEvent> factory = new ChangeFeedFactoryBase<BlobChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                BlobChangeFeedClient.CreateConfiguration(),
                includeNonFinalizedEvents: false);

            DateTimeOffset endTime = new DateTimeOffset(2024, 1, 15, 8, 45, 0, TimeSpan.Zero);
            ChangeFeedBase<BlobChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: null, endTime: endTime, continuation: null, async: IsAsync, cancellationToken: CancellationToken.None);
            while (changeFeed.HasNext()) await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);

            // With IncludeNonFinalizedEvents=false, MinDateTime(lastConsumable=08:30, endTime=08:45) = 08:30
            // caps the effective endTime.
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0815/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0830/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0845/meta.json", Times.Never());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Never());
        }

        [Test]
        public async Task GetPage_IncludeNonFinalizedEventsTrue_ContinuationTokenIsNull()
        {
            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<BlobChangeFeedEvent> factory = new ChangeFeedFactoryBase<BlobChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                BlobChangeFeedClient.CreateConfiguration(),
                includeNonFinalizedEvents: true);

            ChangeFeedBase<BlobChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: null,
                endTime: null,
                continuation: null,
                async: IsAsync,
                cancellationToken: CancellationToken.None);

            int pageCount = 0;
            while (changeFeed.HasNext())
            {
                Page<BlobChangeFeedEvent> page = await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);
                Assert.IsNull(page.ContinuationToken,
                    "Pages produced with IncludeNonFinalizedEvents=true must not carry a continuation token.");
                pageCount++;
            }

            Assert.Greater(pageCount, 0, "Expected at least one page to be produced.");
        }

        [Test]
        public async Task GetPage_IncludeNonFinalizedEventsFalse_ContinuationTokenIsNotNull()
        {
            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<BlobChangeFeedEvent> factory = new ChangeFeedFactoryBase<BlobChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                BlobChangeFeedClient.CreateConfiguration(),
                includeNonFinalizedEvents: false);

            ChangeFeedBase<BlobChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: null,
                endTime: null,
                continuation: null,
                async: IsAsync,
                cancellationToken: CancellationToken.None);

            int pageCount = 0;
            while (changeFeed.HasNext())
            {
                Page<BlobChangeFeedEvent> page = await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);
                Assert.IsNotNull(page.ContinuationToken,
                    "Pages produced with IncludeNonFinalizedEvents=false must carry a continuation token.");
                pageCount++;
            }

            Assert.Greater(pageCount, 0, "Expected at least one page to be produced.");
        }

        private async Task DrainAsync(ChangeFeedFactoryBase<BlobChangeFeedEvent> factory)
        {
            ChangeFeedBase<BlobChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: null,
                endTime: null,
                continuation: null,
                async: IsAsync,
                cancellationToken: CancellationToken.None);

            while (changeFeed.HasNext())
            {
                await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);
            }
        }

        private Mock<SegmentFactoryBase<BlobChangeFeedEvent>> SetupRecordingSegmentFactory()
        {
            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> factory = new Mock<SegmentFactoryBase<BlobChangeFeedEvent>>();

            // For any segment path we are asked about, hand back an empty SegmentBase so iteration
            // advances through the queue without needing real Avro chunks.
            factory.Setup(f => f.BuildSegment(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<SegmentCursor>()))
                .Returns<bool, string, SegmentCursor>((_, path, _) =>
                    Task.FromResult(new SegmentBase<BlobChangeFeedEvent>(
                        new List<ShardBase<BlobChangeFeedEvent>>(),
                        0,
                        ChangeFeedExtensionsBase.ToDateTimeOffset(path).Value,
                        path)));

            return factory;
        }

        private Mock<BlobContainerClient> SetupContainer(bool metaBlobExists = true)
        {
            Mock<BlobContainerClient> container = new Mock<BlobContainerClient>(MockBehavior.Strict);

            container.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/$blobchangefeed"));

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
                            : new MockAsyncPageable(SegmentsInJanuary15Async);
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
                            : new MockSyncPageable(SegmentsInJanuary15);
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

        private static Page<BlobHierarchyItem> SegmentsInJanuary15(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(null, BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0800/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(null, BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0815/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(null, BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0830/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(null, BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0845/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(null, BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0900/meta.json", false, null)),
            });

        private static Task<Page<BlobHierarchyItem>> SegmentsInJanuary15Async(string continuation, int? pageSizeHint)
            => Task.FromResult(SegmentsInJanuary15(continuation, pageSizeHint));

        private static void VerifyBuildSegment(
            Mock<SegmentFactoryBase<BlobChangeFeedEvent>> factory,
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
