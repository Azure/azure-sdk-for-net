// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Tests for <see cref="ShardBase{TEvent}"/> covering cursor management,
    /// HasNext logic, and chunk iteration.
    /// </summary>
    public class ShardBaseTests : ChangeFeedCommonTestBase
    {
        public ShardBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies GetCursor() returns the current chunk's path, block offset, and event index.
        /// </summary>
        [Test]
        public void GetCursor_ReturnsCurrentChunkPosition()
        {
            Mock<ChunkBase<TestEvent>> mockChunk = new Mock<ChunkBase<TestEvent>>(MockBehavior.Strict);
            mockChunk.Setup(c => c.ChunkPath).Returns("log/00/2024/01/15/0800/00000.avro");
            mockChunk.Setup(c => c.BlockOffset).Returns(128);
            mockChunk.Setup(c => c.EventIndex).Returns(3);

            ShardBase<TestEvent> shard = new ShardBase<TestEvent>(
                new Mock<BlobContainerClient>().Object,
                new Mock<ChunkFactoryBase<TestEvent>>().Object,
                new Queue<BlobItem>(),
                mockChunk.Object,
                chunkIndex: 0,
                shardPath: "log/00/2024/01/15/0800/");

            ShardCursor cursor = shard.GetCursor();

            Assert.IsNotNull(cursor);
            Assert.AreEqual("log/00/2024/01/15/0800/00000.avro", cursor.CurrentChunkPath);
            Assert.AreEqual(128, cursor.BlockOffset);
            Assert.AreEqual(3, cursor.EventIndex);
        }

        /// <summary>
        /// Verifies GetCursor() returns null when there is no current chunk.
        /// </summary>
        [Test]
        public void GetCursor_NullWhenNoCurrentChunk()
        {
            ShardBase<TestEvent> shard = new ShardBase<TestEvent>(
                new Mock<BlobContainerClient>().Object,
                new Mock<ChunkFactoryBase<TestEvent>>().Object,
                new Queue<BlobItem>(),
                currentChunk: null,
                chunkIndex: 0,
                shardPath: "log/00/");

            Assert.IsNull(shard.GetCursor());
        }

        /// <summary>
        /// Verifies HasNext() returns false when the current chunk is exhausted and no chunks remain.
        /// </summary>
        [Test]
        public void HasNext_False_WhenExhausted()
        {
            Mock<ChunkBase<TestEvent>> mockChunk = new Mock<ChunkBase<TestEvent>>(MockBehavior.Strict);
            mockChunk.Setup(c => c.HasNext()).Returns(false);

            ShardBase<TestEvent> shard = new ShardBase<TestEvent>(
                new Mock<BlobContainerClient>().Object,
                new Mock<ChunkFactoryBase<TestEvent>>().Object,
                new Queue<BlobItem>(),
                mockChunk.Object,
                chunkIndex: 0,
                shardPath: "log/00/");

            Assert.IsFalse(shard.HasNext());
        }

        /// <summary>
        /// Verifies HasNext() returns true when the current chunk is exhausted but more chunks are queued.
        /// </summary>
        [Test]
        public void HasNext_True_WhenChunksRemain()
        {
            Mock<ChunkBase<TestEvent>> mockChunk = new Mock<ChunkBase<TestEvent>>(MockBehavior.Strict);
            mockChunk.Setup(c => c.HasNext()).Returns(false);

            Queue<BlobItem> chunks = new Queue<BlobItem>();
            chunks.Enqueue(BlobsModelFactory.BlobItem("log/00/2024/01/15/0800/00001.avro"));

            ShardBase<TestEvent> shard = new ShardBase<TestEvent>(
                new Mock<BlobContainerClient>().Object,
                new Mock<ChunkFactoryBase<TestEvent>>().Object,
                chunks,
                mockChunk.Object,
                chunkIndex: 0,
                shardPath: "log/00/");

            Assert.IsTrue(shard.HasNext());
        }

        /// <summary>
        /// Verifies HasNext() returns true when the current chunk still has events.
        /// </summary>
        [Test]
        public void HasNext_True_WhenCurrentChunkHasNext()
        {
            Mock<ChunkBase<TestEvent>> mockChunk = new Mock<ChunkBase<TestEvent>>(MockBehavior.Strict);
            mockChunk.Setup(c => c.HasNext()).Returns(true);

            ShardBase<TestEvent> shard = new ShardBase<TestEvent>(
                new Mock<BlobContainerClient>().Object,
                new Mock<ChunkFactoryBase<TestEvent>>().Object,
                new Queue<BlobItem>(),
                mockChunk.Object,
                chunkIndex: 0,
                shardPath: "log/00/");

            Assert.IsTrue(shard.HasNext());
        }

        /// <summary>
        /// Verifies Next() throws when the shard is exhausted.
        /// </summary>
        [Test]
        public void Next_ThrowsWhenExhausted()
        {
            Mock<ChunkBase<TestEvent>> mockChunk = new Mock<ChunkBase<TestEvent>>(MockBehavior.Strict);
            mockChunk.Setup(c => c.HasNext()).Returns(false);

            ShardBase<TestEvent> shard = new ShardBase<TestEvent>(
                new Mock<BlobContainerClient>().Object,
                new Mock<ChunkFactoryBase<TestEvent>>().Object,
                new Queue<BlobItem>(),
                mockChunk.Object,
                chunkIndex: 0,
                shardPath: "log/00/");

            Assert.ThrowsAsync<InvalidOperationException>(async () => await shard.Next(IsAsync));
        }
    }
}
