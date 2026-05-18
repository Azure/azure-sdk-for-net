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
