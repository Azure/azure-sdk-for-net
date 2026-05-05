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
    /// Mocked unit tests verifying that <see cref="ShareChangeFeedClientOptions.IncludeNonFinalizedEvents"/>
    /// causes <see cref="ChangeFeedFactoryBase{TEvent}"/> to bypass the lastConsumable cap when enumerating segments.
    /// </summary>
    public class ShareChangeFeedNonFinalizedTests : ShareChangeFeedTestBase
    {
        public ShareChangeFeedNonFinalizedTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
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
        public async Task BuildChangeFeed_FlagOn_ReturnsSegmentsPastLastConsumable()
        {
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
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
                includeNonFinalizedEvents: true);

            await DrainAsync(factory);

            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Once());
        }

        // Gap 37: multi-year navigation. Ensures the year-prefix queue correctly skips years
        // whose round-down-to-year value is before startTime, and enumerates remaining years.
        [Test]
        public async Task BuildChangeFeed_MultipleYears_SkipsYearsBeforeStartTime()
        {
            // Track which year prefixes are queried for segments. The first GetBlobsByHierarchy
            // call returns the year listing; subsequent calls list segments inside one year each.
            List<string> requestedSegmentPrefixes = new List<string>();

            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = new Mock<SegmentFactoryBase<ShareChangeFeedEvent>>();
            segmentFactory.Setup(f => f.BuildSegment(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<SegmentCursor>()))
                .Returns<bool, string, SegmentCursor>((_, path, _) =>
                    Task.FromResult(new SegmentBase<ShareChangeFeedEvent>(
                        new List<ShardBase<ShareChangeFeedEvent>>(),
                        0,
                        ChangeFeedExtensionsBase.ToDateTimeOffset(path).Value,
                        path)));

            Mock<BlobContainerClient> container = new Mock<BlobContainerClient>(MockBehavior.Strict);
            container.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/$fileschangefeed-testguid"));
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

            // Hierarchy listings.
            int callCount = 0;
            Page<BlobHierarchyItem> YearListing() => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2023/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2024/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2025/", null),
            });
            // For any segment-listing call, return empty (we only care which year prefix was queried).
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

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                container.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
                includeNonFinalizedEvents: false);

            DateTimeOffset startTime = new DateTimeOffset(2024, 6, 15, 0, 0, 0, TimeSpan.Zero);
            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: startTime, endTime: null, continuation: null, async: IsAsync, cancellationToken: CancellationToken.None);
            while (changeFeed.HasNext()) await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);

            // 2023/ should NOT appear (year is rounded down to 2023, which is before startTime's year 2024).
            CollectionAssert.DoesNotContain(requestedSegmentPrefixes, "idx/segments/2023/");
            // 2024/ and 2025/ should both have been queried because both are at or after startTime's year.
            CollectionAssert.Contains(requestedSegmentPrefixes, "idx/segments/2024/");
            CollectionAssert.Contains(requestedSegmentPrefixes, "idx/segments/2025/");
        }

        // Gap 31: flag interaction with user-supplied endTime. The existing tests cover null endTime;
        // these cover the case where endTime is explicitly past lastConsumable (08:30).

        [Test]
        public async Task BuildChangeFeed_FlagOn_UserEndTimePastLastConsumable_UsesUserEndTime()
        {
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
                includeNonFinalizedEvents: true);

            DateTimeOffset endTime = new DateTimeOffset(2024, 1, 15, 8, 45, 0, TimeSpan.Zero);
            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: null, endTime: endTime, continuation: null, async: IsAsync, cancellationToken: CancellationToken.None);
            while (changeFeed.HasNext()) await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);

            // With flag on and user endTime=08:45, segments at 08:00, 08:15, 08:30, 08:45 should be visited;
            // segment at 09:00 should NOT be visited (past user's endTime).
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0815/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0830/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0845/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Never());
        }

        [Test]
        public async Task BuildChangeFeed_FlagOff_UserEndTimePastLastConsumable_StillCapsAtLastConsumable()
        {
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
                includeNonFinalizedEvents: false);

            DateTimeOffset endTime = new DateTimeOffset(2024, 1, 15, 8, 45, 0, TimeSpan.Zero);
            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: null, endTime: endTime, continuation: null, async: IsAsync, cancellationToken: CancellationToken.None);
            while (changeFeed.HasNext()) await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);

            // With flag off, MinDateTime(lastConsumable=08:30, endTime=08:45) = 08:30 caps the effective endTime.
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0800/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0815/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0830/meta.json", Times.Once());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0845/meta.json", Times.Never());
            VerifyBuildSegment(segmentFactory, "idx/segments/2024/01/15/0900/meta.json", Times.Never());
        }

        // Cursor flag transition tests (gaps 25-29). The asymmetric rule:
        //   cursor false + current any  → allowed
        //   cursor true  + current true → allowed
        //   cursor true  + current false → throws ArgumentException
        // A cursor produced with the flag on records that the run already consumed events past
        // the watermark; replaying it with the flag off would silently skip those events.

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public async Task CursorFlagTransition_Compatible_Allowed(bool cursorFlag, bool currentFlag)
        {
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
                includeNonFinalizedEvents: currentFlag);

            string continuation = SerializeCursor(cursorFlag);

            // Should not throw — drain to confirm the entire pipeline is happy.
            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: null,
                endTime: null,
                continuation: continuation,
                async: IsAsync,
                cancellationToken: CancellationToken.None);

            Assert.IsNotNull(changeFeed);
        }

        [Test]
        public void CursorFlagTrue_ReplayWithFlagFalse_Throws()
        {
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
            Mock<BlobContainerClient> containerClient = SetupContainer();

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
                includeNonFinalizedEvents: false);

            string continuation = SerializeCursor(includeNonFinalizedEvents: true);

            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await factory.BuildChangeFeed(
                    startTime: null,
                    endTime: null,
                    continuation: continuation,
                    async: IsAsync,
                    cancellationToken: CancellationToken.None));

            StringAssert.Contains("IncludeNonFinalizedEvents", ex.Message);
        }

        [Test]
        public void V1Cursor_TreatedAsFlagFalse_AllowedWithEitherCurrentFlag()
        {
            // A cursor JSON without IncludeNonFinalizedEvents (v1 schema) deserializes to flag=false.
            // Forward-compat: such cursors must replay successfully under either current-flag value.
            string v1Json = System.Text.Json.JsonSerializer.Serialize(new
            {
                CursorVersion = 1,
                UrlHost = "account.blob.core.windows.net",
                EndTime = (DateTimeOffset?)null,
                CurrentSegmentCursor = new SegmentCursor("idx/segments/2024/01/15/0800/meta.json", new List<ShardCursor>(), null),
            });

            foreach (bool currentFlag in new[] { false, true })
            {
                Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = SetupRecordingSegmentFactory();
                Mock<BlobContainerClient> containerClient = SetupContainer();

                ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                    containerClient.Object,
                    segmentFactory.Object,
                    ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"),
                    includeNonFinalizedEvents: currentFlag);

                Assert.DoesNotThrowAsync(
                    async () => await factory.BuildChangeFeed(
                        startTime: null,
                        endTime: null,
                        continuation: v1Json,
                        async: IsAsync,
                        cancellationToken: CancellationToken.None),
                    $"V1 cursor should replay with currentFlag={currentFlag}");
            }
        }

        private static string SerializeCursor(bool includeNonFinalizedEvents)
        {
            ChangeFeedCursor cursor = new ChangeFeedCursor(
                urlHost: "account.blob.core.windows.net",
                endDateTime: null,
                currentSegmentCursor: new SegmentCursor("idx/segments/2024/01/15/0800/meta.json", new List<ShardCursor>(), null),
                includeNonFinalizedEvents: includeNonFinalizedEvents);
            return System.Text.Json.JsonSerializer.Serialize(cursor);
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
