// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.ChangeFeed.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class SegmentTests
    {
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
    }
}
