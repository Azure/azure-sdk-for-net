// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.ChangeFeed.Models;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Core;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class ShardTests : ChangeFeedTestBase
    {
        public ShardTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void GetCursor()
        {
            // Arrange
            long chunkIndex = 5;
            long blockOffset = 100;
            long eventIndex = 200;

            Mock<Chunk> chunk = new Mock<Chunk>(MockBehavior.Strict);

            chunk.Setup(r => r.BlockOffset).Returns(blockOffset);
            chunk.Setup(r => r.EventIndex).Returns(eventIndex);

            Shard shard = new Shard(chunk.Object, chunkIndex);

            // Act
            ShardCursor cursor = shard.GetCursor();

            // Assert
            Assert.AreEqual(chunkIndex, cursor.ChunkIndex);
            Assert.AreEqual(blockOffset, cursor.BlockOffset);
            Assert.AreEqual(eventIndex, cursor.EventIndex);

            chunk.Verify(r => r.BlockOffset);
            chunk.Verify(r => r.EventIndex);
        }

        [Test]
        public void HasNext_NotInitalizes()
        {
            // Arrange
            Shard shard = new Shard(isInitalized: false);

            // Act
            bool hasNext = shard.HasNext();

            // Assert
            Assert.IsTrue(hasNext);
        }

        [Test]
        public void HasNext_False()
        {
            // Arrange
            Mock<Chunk> chunk = new Mock<Chunk>(MockBehavior.Strict);
            chunk.Setup(r => r.HasNext()).Returns(false);

            Queue<string> chunks = new Queue<string>();
            Shard shard = new Shard(
                chunk.Object,
                isInitalized: true,
                chunks: chunks);

            // Act
            bool hasNext = shard.HasNext();

            // Assert
            Assert.IsFalse(hasNext);

            chunk.Verify(r => r.HasNext());
        }

        [Test]
        public void HasNext_ChunksLeft()
        {
            // Arrange
            Queue<string> chunks = new Queue<string>();
            chunks.Enqueue("chunk");
            Shard shard = new Shard(
                isInitalized: true,
                chunks: chunks);

            // Act
            bool hasNext = shard.HasNext();

            // Assert
            Assert.IsTrue(hasNext);
        }

        [Test]
        public void HasNext_CurrentChunkHasNext()
        {
            // Arrange
            Mock<Chunk> chunk = new Mock<Chunk>(MockBehavior.Strict);
            chunk.Setup(r => r.HasNext()).Returns(true);

            Shard shard = new Shard(
                chunk: chunk.Object,
                isInitalized: true,
                chunks: new Queue<string>());

            // Act
            bool hasNext = shard.HasNext();

            // Assert
            Assert.IsTrue(hasNext);

            chunk.Verify(r => r.HasNext());
        }

        [Test]
        public async Task Next()
        {
            // Arrange
            Guid eventId = Guid.NewGuid();
            BlobChangeFeedEvent expectedChangeFeedEvent = new BlobChangeFeedEvent
            {
                Id = eventId
            };
            string secondChunkName = "chunk";

            Mock<Chunk> chunk = new Mock<Chunk>(MockBehavior.Strict);
            chunk.Setup(r => r.HasNext()).Returns(true);
            chunk.Setup(r => r.Next(It.IsAny<bool>(), default)).Returns(Task.FromResult(expectedChangeFeedEvent));
            chunk.Setup(r => r.HasNext()).Returns(false);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns((new Mock<BlobClient>()).Object);

            Queue<string> chunks = new Queue<string>();
            chunks.Enqueue(secondChunkName);
            Shard shard = new Shard(
                chunk: chunk.Object,
                isInitalized: true,
                chunks: chunks,
                containerClient: containerClient.Object);

            // Act
            BlobChangeFeedEvent changeFeedEvent = await shard.Next(IsAsync);
            ShardCursor cursor = shard.GetCursor();

            // Assert
            Assert.AreEqual(eventId, changeFeedEvent.Id);
            Assert.AreEqual(1, cursor.ChunkIndex);

            chunk.Verify(r => r.HasNext());
            chunk.Verify(r => r.Next(IsAsync, default));
            chunk.Verify(r => r.HasNext());

            containerClient.Verify(r => r.GetBlobClient(secondChunkName));
        }
    }
}
