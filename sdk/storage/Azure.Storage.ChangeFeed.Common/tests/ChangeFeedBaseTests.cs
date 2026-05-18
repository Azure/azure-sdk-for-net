// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Tests for <see cref="ChangeFeedBase{TEvent}"/> orchestration that the per-segment and
    /// per-shard test classes do not exercise — specifically, page assembly that spans
    /// segment boundaries.
    /// </summary>
    public class ChangeFeedBaseTests : ChangeFeedCommonTestBase
    {
        public ChangeFeedBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that a single <c>GetPage</c> call fills the requested page size from
        /// multiple segments when the first segment is exhausted before the page is full.
        /// This exercises the inner while loop and <c>AdvanceSegmentIfNecessary</c> path of
        /// <see cref="ChangeFeedBase{TEvent}.GetPage"/>: a regression that fails to advance
        /// to the next segment would silently lose events at every segment boundary.
        /// </summary>
        [Test]
        public async Task GetPage_PageSpansSegmentBoundary_FillsFromMultipleSegments()
        {
            // Segment 1: 2 events.
            SegmentBase<TestEvent> segment1 = BuildSegmentWithEvents(
                manifestPath: "idx/segments/2024/01/15/0800/meta.json",
                segmentTime: new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                eventIds: new[] { "evt-A", "evt-B" });

            // Segment 2: 3 events (only 2 will be drawn into this page; 1 left over).
            SegmentBase<TestEvent> segment2 = BuildSegmentWithEvents(
                manifestPath: "idx/segments/2024/01/15/0815/meta.json",
                segmentTime: new DateTimeOffset(2024, 1, 15, 8, 15, 0, TimeSpan.Zero),
                eventIds: new[] { "evt-C", "evt-D", "evt-E" });

            Mock<SegmentFactoryBase<TestEvent>> segmentFactory = new Mock<SegmentFactoryBase<TestEvent>>();
            segmentFactory
                .Setup(f => f.BuildSegment(IsAsync, "idx/segments/2024/01/15/0815/meta.json", null))
                .ReturnsAsync(segment2);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Loose);
            // GetCursor() reads container Uri.Host to populate the cursor — supply one.
            containerClient.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/container"));

            ChangeFeedBase<TestEvent> changeFeed = new ChangeFeedBase<TestEvent>(
                containerClient: containerClient.Object,
                segmentFactory: segmentFactory.Object,
                years: new Queue<string>(),
                segments: new Queue<string>(new[] { "idx/segments/2024/01/15/0815/meta.json" }),
                currentSegment: segment1,
                lastConsumable: new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero),
                startTime: null,
                endTime: null,
                config: CreateTestConfig());

            Page<TestEvent> page = await changeFeed.GetPage(IsAsync, pageSize: 4);

            Assert.AreEqual(4, page.Values.Count);
            Assert.AreEqual("evt-A", page.Values[0].Id);
            Assert.AreEqual("evt-B", page.Values[1].Id);
            Assert.AreEqual("evt-C", page.Values[2].Id);
            Assert.AreEqual("evt-D", page.Values[3].Id);

            // Segment 2 still holds evt-E — feed must report more events available.
            Assert.IsTrue(changeFeed.HasNext());

            // Verify the segment factory was called exactly once for the second segment.
            segmentFactory.Verify(
                f => f.BuildSegment(IsAsync, "idx/segments/2024/01/15/0815/meta.json", null),
                Times.Once);
        }

        /// <summary>
        /// Reproduces the Files snapshot-range bug at the orchestration seam: the begin/end log
        /// windows fall in the same minute bucket, so <c>startTime == endTime == segment.DateTime</c>,
        /// and every row's <c>EventTime</c> is strictly inside that minute. With the default
        /// (event-time-filtered) contract the boundary segment is skipped entirely — pinning that
        /// <c>GetChanges(start, end)</c> semantics are unchanged. With
        /// <c>disableEventTimeFilter: true</c> (the snapshot reader's mode) every row is produced,
        /// so the downstream container-version filter can see the events.
        /// </summary>
        [Test]
        public async Task GetPage_DisableEventTimeFilter_SameMinuteWindow_ReturnsAllRows()
        {
            DateTimeOffset window = new DateTimeOffset(2026, 5, 16, 13, 12, 0, TimeSpan.Zero);

            // Rows live strictly inside the 13:12 minute; the segment bucket is 13:12:00.
            List<TestEvent> rows = new List<TestEvent>
            {
                new TestEvent { Id = "create-snapshotBaselineDir", Cvnt = 0, EventTime = window.AddSeconds(2) },
                new TestEvent { Id = "create-baseline.txt", Cvnt = 0, EventTime = window.AddSeconds(2.1) },
                new TestEvent { Id = "delete-baseline.txt", Cvnt = 1, EventTime = window.AddSeconds(9) },
            };

            ChangeFeedBase<TestEvent> filtered = BuildSingleSegmentFeed(window, rows, disableEventTimeFilter: false);
            ChangeFeedBase<TestEvent> unfiltered = BuildSingleSegmentFeed(window, rows, disableEventTimeFilter: true);

            // Default contract: the boundary segment (DateTime == endTime) is gated out, which is
            // exactly the bug the snapshot reader hit before the fix. Behavior is intentionally
            // unchanged for GetChanges(start, end).
            Assert.IsFalse(
                filtered.HasNext(),
                "Default event-time-filtered path must still gate the boundary segment.");

            // Snapshot mode: every row in the selected segment is produced.
            Assert.IsTrue(unfiltered.HasNext());
            Page<TestEvent> page = await unfiltered.GetPage(IsAsync, pageSize: 10);

            Assert.AreEqual(3, page.Values.Count);
            Assert.AreEqual("create-snapshotBaselineDir", page.Values[0].Id);
            Assert.AreEqual("create-baseline.txt", page.Values[1].Id);
            Assert.AreEqual("delete-baseline.txt", page.Values[2].Id);
            Assert.IsFalse(unfiltered.HasNext());
        }

        /// <summary>
        /// Builds a <see cref="ChangeFeedBase{TEvent}"/> over a single in-memory segment whose
        /// bucket <c>DateTime</c>, <c>startTime</c>, and <c>endTime</c> all equal
        /// <paramref name="window"/> — the degenerate same-minute window the snapshot reader hits.
        /// </summary>
        private ChangeFeedBase<TestEvent> BuildSingleSegmentFeed(
            DateTimeOffset window,
            List<TestEvent> rows,
            bool disableEventTimeFilter)
        {
            // HHmm-encoded minute bucket, e.g. 13:12 -> "1312".
            string manifestPath = $"idx/segments/{window:yyyy/MM/dd}/{window:HHmm}/meta.json";
            SegmentBase<TestEvent> segment = BuildSegmentWithEvents(manifestPath, window, rows);

            Mock<SegmentFactoryBase<TestEvent>> segmentFactory = new Mock<SegmentFactoryBase<TestEvent>>();
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Loose);
            containerClient.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/container"));

            return new ChangeFeedBase<TestEvent>(
                containerClient: containerClient.Object,
                segmentFactory: segmentFactory.Object,
                years: new Queue<string>(),
                segments: new Queue<string>(),
                currentSegment: segment,
                lastConsumable: window.AddHours(1),
                startTime: window,
                endTime: window,
                config: CreateTestConfig(),
                includeNonFinalizedEvents: false,
                disableEventTimeFilter: disableEventTimeFilter);
        }

        /// <summary>
        /// Builds a real <see cref="SegmentBase{TEvent}"/> backed by a single mock shard that
        /// yields the supplied <paramref name="events"/> in order (preserving <c>EventTime</c>).
        /// </summary>
        private static SegmentBase<TestEvent> BuildSegmentWithEvents(
            string manifestPath,
            DateTimeOffset segmentTime,
            List<TestEvent> events)
        {
            int index = 0;
            Mock<ShardBase<TestEvent>> shard = new Mock<ShardBase<TestEvent>>();
            shard.Setup(s => s.HasNext()).Returns(() => index < events.Count);
            shard.Setup(s => s.Next(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => events[index++]);
            shard.Setup(s => s.ShardPath).Returns("log/00/" + manifestPath);
            shard.Setup(s => s.GetCursor()).Returns(new ShardCursor("chunk0", 0, 0));

            return new SegmentBase<TestEvent>(
                new List<ShardBase<TestEvent>> { shard.Object },
                shardIndex: 0,
                dateTime: segmentTime,
                manifestPath: manifestPath);
        }

        /// <summary>
        /// Builds a real <see cref="SegmentBase{TEvent}"/> backed by a single mock shard that
        /// yields the supplied events in order.
        /// </summary>
        private static SegmentBase<TestEvent> BuildSegmentWithEvents(
            string manifestPath,
            DateTimeOffset segmentTime,
            string[] eventIds)
        {
            int index = 0;
            Mock<ShardBase<TestEvent>> shard = new Mock<ShardBase<TestEvent>>();
            shard.Setup(s => s.HasNext()).Returns(() => index < eventIds.Length);
            shard.Setup(s => s.Next(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new TestEvent { Id = eventIds[index++] });
            shard.Setup(s => s.ShardPath).Returns("log/00/" + manifestPath);
            shard.Setup(s => s.GetCursor()).Returns(new ShardCursor("chunk0", 0, 0));

            return new SegmentBase<TestEvent>(
                new List<ShardBase<TestEvent>> { shard.Object },
                shardIndex: 0,
                dateTime: segmentTime,
                manifestPath: manifestPath);
        }
    }
}
