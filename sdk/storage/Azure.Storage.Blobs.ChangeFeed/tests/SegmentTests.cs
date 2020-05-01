// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.ChangeFeed.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class SegmentTests : ChangeFeedTestBase
    {
        public SegmentTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void HasNext_NotInitalized()
        {
            // Arrange
            Segment segment = new Segment(isInitalized: false);

            // Act
            bool hasNext = segment.HasNext();

            // Assert
            Assert.IsTrue(hasNext);
        }

        [Test]
        public void HasNext_False()
        {
            // Arrange
            List<Shard> shards = new List<Shard>();
            Segment segment = new Segment(
                isInitalized: true,
                shards: shards);

            // Act
            bool hasNext = segment.HasNext();

            // Assert
            Assert.IsFalse(hasNext);
        }

        [Test]
        public void GetCursor()
        {
            // Arrange
            DateTimeOffset dateTime = DateTimeOffset.UtcNow;
            int shardIndex = 4;
            Mock<Shard> shard = new Mock<Shard>(MockBehavior.Strict);
            Mock<ShardCursor> shardCursor = new Mock<ShardCursor>(MockBehavior.Strict);
            shard.Setup(r => r.GetCursor()).Returns(shardCursor.Object);
            List<Shard> shards = new List<Shard>
            {
                shard.Object
            };
            Segment segment = new Segment(
                isInitalized: true,
                shards: shards,
                shardIndex: shardIndex,
                dateTime: dateTime);

            // Act
            SegmentCursor cursor = segment.GetCursor();

            // Assert
            Assert.AreEqual(dateTime, cursor.SegmentTime);
            Assert.AreEqual(1, cursor.ShardCursors.Count);
            Assert.AreEqual(shardCursor.Object, cursor.ShardCursors[0]);
            Assert.AreEqual(shardIndex, cursor.ShardIndex);
        }

        /// <summary>
        /// In this test, the Segment has 3 Shards and 5 total Events.
        /// Shard index 0 and 1 have 2 Events, and Shard index 2 has 1 Event.
        /// We are round-robining the Shards, so we will return the events for
        /// the shards indexes: 0 1 2 0 1.
        /// </summary>
        [Test]
        public async Task GetPage()
        {
            // Arrange
            int eventCount = 5;
            int shardCount = 3;

            List<Guid> eventIds = new List<Guid>();
            for (int i = 0; i < eventCount; i++)
            {
                eventIds.Add(Guid.NewGuid());
            }

            List<Mock<Shard>> mockShards = new List<Mock<Shard>>();

            for (int i = 0; i <shardCount; i++)
            {
                mockShards.Add(new Mock<Shard>(MockBehavior.Strict));
            }

            // Set up Shards
            mockShards[0].SetupSequence(r => r.Next(It.IsAny<bool>(), default))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[0]
                }))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[3]
                }));

            mockShards[0].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            mockShards[1].SetupSequence(r => r.Next(It.IsAny<bool>(), default))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[1]
                }))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[4]
                }));

            mockShards[1].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            mockShards[2].Setup(r => r.Next(It.IsAny<bool>(), default))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[2]
                }));

            mockShards[2].Setup(r => r.HasNext())
                .Returns(false);

            List<Shard> shards = new List<Shard>();
            for (int i = 0; i < shardCount; i++)
            {
                shards.Add(mockShards[i].Object);
            }

            Segment segment = new Segment(
                isInitalized: true,
                shards: shards);

            // Act
            List<BlobChangeFeedEvent> events = await segment.GetPage(IsAsync, 25);

            // Assert
            Assert.AreEqual(eventCount, events.Count);
            for (int i = 0; i < eventCount; i++)
            {
                Assert.AreEqual(eventIds[i], events[i].Id);
            }

            mockShards[0].Verify(r => r.Next(IsAsync, default));
            mockShards[0].Verify(r => r.HasNext());
            mockShards[1].Verify(r => r.Next(IsAsync, default));
            mockShards[1].Verify(r => r.HasNext());
            mockShards[2].Verify(r => r.Next(IsAsync, default));
            mockShards[2].Verify(r => r.HasNext());
            mockShards[0].Verify(r => r.Next(IsAsync, default));
            mockShards[0].Verify(r => r.HasNext());
            mockShards[1].Verify(r => r.Next(IsAsync, default));
            mockShards[1].Verify(r => r.HasNext());
        }
    }
}
