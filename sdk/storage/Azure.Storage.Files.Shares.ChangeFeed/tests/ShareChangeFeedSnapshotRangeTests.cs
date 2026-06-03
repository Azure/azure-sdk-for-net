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
    /// Regression coverage for the snapshot-range reader (<see cref="ShareChangeFeedSnapshotPageable"/> /
    /// <see cref="ShareChangeFeedSnapshotAsyncPageable"/>). Drives the real
    /// <see cref="ChangeFeedFactoryBase{TEvent}"/> + <see cref="ChangeFeedBase{TEvent}"/> orchestration
    /// through an injected segment-factory seam (the established pattern in this test project),
    /// then applies the same container-version filter the pageables use.
    ///
    /// Reproduces the Change Feed team's functional repro: the begin/end share snapshots land in
    /// the same one-minute log window, so the derived start/end times collapse to a single
    /// minute-bucket boundary while the actual events live strictly inside that minute. Before the
    /// fix the per-event EventTime predicate (and the segment-boundary end gate) dropped every row
    /// before the container-version filter could see it, so GetChangesBetweenSnapshots returned
    /// nothing.
    /// </summary>
    public class ShareChangeFeedSnapshotRangeTests : ShareChangeFeedTestBase
    {
        public ShareChangeFeedSnapshotRangeTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        // The begin/end snapshots fall in the same minute window (see repro):
        //   begin.MinLogWindowForNextSnapshot == end.MaxLogWindowForCurrentSnapshot == 13:12:00
        private static readonly DateTimeOffset Window = new DateTimeOffset(2026, 5, 16, 13, 12, 0, TimeSpan.Zero);
        private const string SegmentPath = "idx/segments/2026/05/16/1312/meta.json";
        private const long BeginCvId = 0;
        private const long EndCvId = 1;

        /// <summary>
        /// With the snapshot reader's no-event-time-filter mode, every row in the selected
        /// log-window segment is produced, so the container-version filter returns the delete.
        /// </summary>
        [Test]
        public async Task SnapshotRange_SameMinuteWindow_ReturnsDelete()
        {
            List<ShareChangeFeedEvent> collected = await ReadSnapshotRangeAsync(disableEventTimeFilter: true);

            Assert.AreEqual(1, collected.Count, "Expected the RestDelete (Cvnt=1) to survive the (0,1] filter.");
            Assert.AreEqual("delete-baseline.txt", collected[0].Id);
            Assert.AreEqual(EndCvId, collected[0].ContainerVersionNumber);
        }

        /// <summary>
        /// Pins that the default (event-time-filtered) contract used by GetChanges(start, end) is
        /// unchanged: with start == end == the minute-bucket boundary, the boundary segment is
        /// gated out and nothing is read. This is exactly the bug — and it must stay reproducible
        /// for the default path so the fix remains scoped to the snapshot reader.
        /// </summary>
        [Test]
        public async Task SnapshotRange_DefaultEventTimeFilter_DropsEverything()
        {
            List<ShareChangeFeedEvent> collected = await ReadSnapshotRangeAsync(disableEventTimeFilter: false);

            Assert.IsEmpty(collected);
        }

        /// <summary>
        /// Builds the real change-feed reader over a single log-window segment and runs the same
        /// loop the snapshot pageables run (drain pages, keep events whose container version is in
        /// the half-open <c>(BeginCvId, EndCvId]</c> range).
        /// </summary>
        private async Task<List<ShareChangeFeedEvent>> ReadSnapshotRangeAsync(bool disableEventTimeFilter)
        {
            Mock<SegmentFactoryBase<ShareChangeFeedEvent>> segmentFactory = new Mock<SegmentFactoryBase<ShareChangeFeedEvent>>();
            segmentFactory
                .Setup(f => f.BuildSegment(It.IsAny<bool>(), SegmentPath, It.IsAny<SegmentCursor>()))
                .Returns<bool, string, SegmentCursor>((_, path, _) => Task.FromResult(BuildSegment(path)));

            Mock<BlobContainerClient> container = SetupContainer();

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                container.Object,
                segmentFactory.Object,
                ShareChangeFeedClient.CreateConfiguration("$fileschangefeed-testguid"));

            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime: Window,
                endTime: Window,
                continuation: null,
                async: IsAsync,
                cancellationToken: CancellationToken.None,
                disableEventTimeFilter: disableEventTimeFilter);

            List<ShareChangeFeedEvent> collected = new List<ShareChangeFeedEvent>();
            while (changeFeed.HasNext())
            {
                Page<ShareChangeFeedEvent> rawPage = await changeFeed.GetPage(IsAsync, pageSize: 5000, CancellationToken.None);

                foreach (ShareChangeFeedEvent evt in rawPage.Values)
                {
                    if (SnapshotEventFilter.IsInRange(evt, BeginCvId, EndCvId))
                        collected.Add(evt);
                }
            }

            return collected;
        }

        // The segment's bucket DateTime is 13:12:00; the rows live strictly inside the minute,
        // mirroring the repro (two RestCreate at Cvnt=0, one RestDelete at Cvnt=1).
        private static SegmentBase<ShareChangeFeedEvent> BuildSegment(string manifestPath)
        {
            List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>
            {
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(
                    reason: ShareChangeFeedReasonType.RestCreate, eventTime: Window.AddSeconds(2),
                    containerVersionNumber: 0, id: "create-snapshotBaselineDir"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(
                    reason: ShareChangeFeedReasonType.RestCreate, eventTime: Window.AddSeconds(2.1),
                    containerVersionNumber: 0, id: "create-baseline.txt"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(
                    reason: ShareChangeFeedReasonType.RestDelete, eventTime: Window.AddSeconds(9),
                    containerVersionNumber: 1, id: "delete-baseline.txt"),
            };

            int index = 0;
            Mock<ShardBase<ShareChangeFeedEvent>> shard = new Mock<ShardBase<ShareChangeFeedEvent>>();
            shard.Setup(s => s.HasNext()).Returns(() => index < events.Count);
            shard.Setup(s => s.Next(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => events[index++]);
            shard.Setup(s => s.ShardPath).Returns("log/00/" + manifestPath);
            shard.Setup(s => s.GetCursor()).Returns(new ShardCursor("chunk0", 0, 0));

            return new SegmentBase<ShareChangeFeedEvent>(
                new List<ShardBase<ShareChangeFeedEvent>> { shard.Object },
                shardIndex: 0,
                dateTime: ChangeFeedExtensionsBase.ToDateTimeOffset(manifestPath).Value,
                manifestPath: manifestPath);
        }

        private Mock<BlobContainerClient> SetupContainer()
        {
            Mock<BlobContainerClient> container = new Mock<BlobContainerClient>(MockBehavior.Strict);
            container.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/$fileschangefeed-testguid"));

            if (IsAsync)
                container.Setup(c => c.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            else
                container.Setup(c => c.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

            // Finalized through the snapshot window.
            Mock<BlobClient> metaBlob = new Mock<BlobClient>(MockBehavior.Strict);
            container.Setup(c => c.GetBlobClient("meta/segments.json")).Returns(metaBlob.Object);
            byte[] metaBytes = Encoding.UTF8.GetBytes($@"{{""lastConsumable"":""{Window:O}""}}");
            if (IsAsync)
                metaBlob.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() => Task.FromResult(Response.FromValue(
                        BlobsModelFactory.BlobDownloadStreamingResult(content: new MemoryStream(metaBytes)), (Response)null)));
            else
                metaBlob.Setup(b => b.DownloadStreaming(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() => Response.FromValue(
                        BlobsModelFactory.BlobDownloadStreamingResult(content: new MemoryStream(metaBytes)), (Response)null));

            // First hierarchy call: the year listing. Subsequent calls: the single 13:12 segment.
            int callCount = 0;
            if (IsAsync)
            {
                container.Setup(c => c.GetBlobsByHierarchyAsync(It.IsAny<GetBlobsByHierarchyOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() =>
                    {
                        callCount++;
                        return callCount == 1
                            ? new MockAsyncPageable(YearListingAsync)
                            : new MockAsyncPageable(SegmentListingAsync);
                    });
            }
            else
            {
                container.Setup(c => c.GetBlobsByHierarchy(It.IsAny<GetBlobsByHierarchyOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() =>
                    {
                        callCount++;
                        return callCount == 1
                            ? new MockSyncPageable(YearListing)
                            : new MockSyncPageable(SegmentListing);
                    });
            }

            return container;
        }

        private static Page<BlobHierarchyItem> YearListing(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2026/", null),
            });

        private static Page<BlobHierarchyItem> SegmentListing(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(null, BlobsModelFactory.BlobItem(SegmentPath, false, null)),
            });

        private static Task<Page<BlobHierarchyItem>> YearListingAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(YearListing(continuation, pageSizeHint));

        private static Task<Page<BlobHierarchyItem>> SegmentListingAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(SegmentListing(continuation, pageSizeHint));

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
