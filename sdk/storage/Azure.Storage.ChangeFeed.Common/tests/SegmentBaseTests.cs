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
    /// Tests for <see cref="SegmentBase{TEvent}"/> covering cursor management,
    /// round-robin shard iteration, and page retrieval.
    /// </summary>
    public class SegmentBaseTests : ChangeFeedCommonTestBase
    {
        public SegmentBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies GetPage returns an empty list when all shards are exhausted.
        /// </summary>
        [Test]
        public async Task GetPage_NoMoreEvents_ReturnsEmptyList()
        {
            // Create a segment with no shards
            SegmentBase<TestEvent> segment = new SegmentBase<TestEvent>(
                new List<ShardBase<TestEvent>>(),
                shardIndex: 0,
                dateTime: new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                manifestPath: "idx/segments/2024/01/15/0800/meta.json");

            List<TestEvent> events = await segment.GetPage(IsAsync, pageSize: 10, startTime: null, endTime: null);

            Assert.IsEmpty(events);
            Assert.IsFalse(segment.HasNext());
        }

        /// <summary>
        /// Verifies round-robin event retrieval across multiple shards.
        /// With 2 shards each having 1 event, a page request for 10 should return 2 events.
        /// </summary>
        [Test]
        public async Task GetPage_RoundRobinAcrossShards()
        {
            TestEvent event1 = new TestEvent { Reason = "SmbCreate", Id = "1" };
            TestEvent event2 = new TestEvent { Reason = "SmbWrite", Id = "2" };

            // Shard 0: returns true for HasNext, then false after one event is read.
            // The segment calls HasNext() before reading and again after to check if shard is exhausted.
            Mock<ShardBase<TestEvent>> shard0 = new Mock<ShardBase<TestEvent>>();
            int shard0Count = 0;
            shard0.Setup(s => s.HasNext()).Returns(() => shard0Count < 1);
            shard0.Setup(s => s.Next(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => { shard0Count++; return event1; });
            shard0.Setup(s => s.ShardPath).Returns("log/00/");
            shard0.Setup(s => s.GetCursor()).Returns(new ShardCursor("chunk0", 0, 0));

            // Shard 1: same pattern, 1 event then exhausted.
            Mock<ShardBase<TestEvent>> shard1 = new Mock<ShardBase<TestEvent>>();
            int shard1Count = 0;
            shard1.Setup(s => s.HasNext()).Returns(() => shard1Count < 1);
            shard1.Setup(s => s.Next(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => { shard1Count++; return event2; });
            shard1.Setup(s => s.ShardPath).Returns("log/01/");
            shard1.Setup(s => s.GetCursor()).Returns(new ShardCursor("chunk1", 0, 0));

            SegmentBase<TestEvent> segment = new SegmentBase<TestEvent>(
                new List<ShardBase<TestEvent>> { shard0.Object, shard1.Object },
                shardIndex: 0,
                dateTime: new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                manifestPath: "idx/segments/2024/01/15/0800/meta.json");

            List<TestEvent> events = await segment.GetPage(IsAsync, pageSize: 10, startTime: null, endTime: null);

            // Should have round-robined: shard0 event, shard1 event
            Assert.AreEqual(2, events.Count);
            Assert.AreEqual("SmbCreate", events[0].Reason);
            Assert.AreEqual("SmbWrite", events[1].Reason);
            Assert.IsFalse(segment.HasNext());
        }

        /// <summary>
        /// Builds a single-shard <see cref="SegmentBase{TEvent}"/> backed by a queued list of
        /// <see cref="TestEvent"/> instances. Used to drive event-time filter tests.
        /// </summary>
        private static SegmentBase<TestEvent> BuildSingleShardSegment(List<TestEvent> events)
        {
            int index = 0;
            Mock<ShardBase<TestEvent>> shard = new Mock<ShardBase<TestEvent>>();
            shard.Setup(s => s.HasNext()).Returns(() => index < events.Count);
            shard.Setup(s => s.Next(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => events[index++]);
            shard.Setup(s => s.ShardPath).Returns("log/00/");
            shard.Setup(s => s.GetCursor()).Returns(new ShardCursor("chunk0", 0, 0));

            return new SegmentBase<TestEvent>(
                new List<ShardBase<TestEvent>> { shard.Object },
                shardIndex: 0,
                dateTime: new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero),
                manifestPath: "idx/segments/2024/01/15/0900/meta.json");
        }

        /// <summary>
        /// Verifies the per-event start-time filter at <c>SegmentBase.GetPage</c> drops events
        /// with <c>EventTime &lt; startTime</c>.
        /// </summary>
        [Test]
        public async Task GetPage_DropsEventsBelowStartTime()
        {
            DateTimeOffset t0900 = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero);
            DateTimeOffset t0930 = new DateTimeOffset(2024, 1, 15, 9, 30, 0, TimeSpan.Zero);
            DateTimeOffset t1000 = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);

            List<TestEvent> events = new List<TestEvent>
            {
                new TestEvent { Id = "evt-0900", EventTime = t0900 },
                new TestEvent { Id = "evt-0930", EventTime = t0930 },
                new TestEvent { Id = "evt-1000", EventTime = t1000 },
            };

            SegmentBase<TestEvent> segment = BuildSingleShardSegment(events);

            List<TestEvent> result = await segment.GetPage(IsAsync, pageSize: 10, startTime: t0930, endTime: null);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("evt-0930", result[0].Id);
            Assert.AreEqual("evt-1000", result[1].Id);
        }

        /// <summary>
        /// Verifies the per-event end-time filter at <c>SegmentBase.GetPage</c> drops events
        /// with <c>EventTime &gt; endTime</c> (inclusive end).
        /// </summary>
        [Test]
        public async Task GetPage_DropsEventsAboveEndTime()
        {
            DateTimeOffset t0900 = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero);
            DateTimeOffset t0930 = new DateTimeOffset(2024, 1, 15, 9, 30, 0, TimeSpan.Zero);
            DateTimeOffset t1000 = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);
            DateTimeOffset t1030 = new DateTimeOffset(2024, 1, 15, 10, 30, 0, TimeSpan.Zero);

            List<TestEvent> events = new List<TestEvent>
            {
                new TestEvent { Id = "evt-0900", EventTime = t0900 },
                new TestEvent { Id = "evt-0930", EventTime = t0930 },
                new TestEvent { Id = "evt-1000", EventTime = t1000 },
                new TestEvent { Id = "evt-1030", EventTime = t1030 },
            };

            SegmentBase<TestEvent> segment = BuildSingleShardSegment(events);

            // endTime is inclusive: events at exactly t1000 are kept; events past t1000 are dropped.
            List<TestEvent> result = await segment.GetPage(IsAsync, pageSize: 10, startTime: null, endTime: t1000);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("evt-0900", result[0].Id);
            Assert.AreEqual("evt-0930", result[1].Id);
            Assert.AreEqual("evt-1000", result[2].Id);
        }

        /// <summary>
        /// Verifies that with both filters null, every event is returned. Pins the no-filter
        /// happy path so a regression that always filters cannot slip through unnoticed.
        /// </summary>
        [Test]
        public async Task GetPage_NoTimeFilters_ReturnsAllEvents()
        {
            DateTimeOffset t0900 = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero);
            DateTimeOffset t0930 = new DateTimeOffset(2024, 1, 15, 9, 30, 0, TimeSpan.Zero);
            DateTimeOffset t1000 = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);

            List<TestEvent> events = new List<TestEvent>
            {
                new TestEvent { Id = "evt-0900", EventTime = t0900 },
                new TestEvent { Id = "evt-0930", EventTime = t0930 },
                new TestEvent { Id = "evt-1000", EventTime = t1000 },
            };

            SegmentBase<TestEvent> segment = BuildSingleShardSegment(events);

            List<TestEvent> result = await segment.GetPage(IsAsync, pageSize: 10, startTime: null, endTime: null);

            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// Verifies GetCursor builds a SegmentCursor with shard cursors for all shards.
        /// </summary>
        [Test]
        public void GetCursor_IncludesAllShardCursors()
        {
            Mock<ShardBase<TestEvent>> shard0 = new Mock<ShardBase<TestEvent>>(MockBehavior.Strict);
            shard0.Setup(s => s.ShardPath).Returns("log/00/");
            shard0.Setup(s => s.GetCursor()).Returns(new ShardCursor("chunk0", 10, 2));

            Mock<ShardBase<TestEvent>> shard1 = new Mock<ShardBase<TestEvent>>(MockBehavior.Strict);
            shard1.Setup(s => s.ShardPath).Returns("log/01/");
            shard1.Setup(s => s.GetCursor()).Returns(new ShardCursor("chunk1", 20, 5));

            SegmentBase<TestEvent> segment = new SegmentBase<TestEvent>(
                new List<ShardBase<TestEvent>> { shard0.Object, shard1.Object },
                shardIndex: 0,
                dateTime: new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                manifestPath: "idx/segments/2024/01/15/0800/meta.json");

            SegmentCursor cursor = segment.GetCursor();

            Assert.AreEqual("idx/segments/2024/01/15/0800/meta.json", cursor.SegmentPath);
            Assert.AreEqual(2, cursor.ShardCursors.Count);
            Assert.AreEqual("log/00/", cursor.CurrentShardPath);
        }
    }
}
