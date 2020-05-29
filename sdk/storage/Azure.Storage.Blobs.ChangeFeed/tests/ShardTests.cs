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

        /// <summary>
        /// Tests creating a Shard with a ShardCursor, and then calling Shard.GetCursor().
        /// </summary>
        [Test]
        public async Task GetCursor()
        {
            // Arrange
            string shardPath = "shardPath";
            long chunkIndex = 2;
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                chunkIndex,
                blockOffset,
                eventIndex);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<ChunkFactory> chunkFactory = new Mock<ChunkFactory>(MockBehavior.Strict);
            Mock<Chunk> chunk = new Mock<Chunk>(MockBehavior.Strict);

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetChunkPagesFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable = PageResponseEnumerator.CreateEnumerable(GetChunkPagesFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(pageable);
            }

            chunkFactory.Setup(r => r.BuildChunk(
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunk.Object);

            chunk.Setup(r => r.BlockOffset).Returns(blockOffset);
            chunk.Setup(r => r.EventIndex).Returns(eventIndex);

            ShardFactory shardFactory = new ShardFactory(
                containerClient.Object,
                chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                shardPath,
                shardCursor)
                .ConfigureAwait(false);


            ShardCursor cursor = shard.GetCursor();

            // Assert
            Assert.AreEqual(chunkIndex, cursor.ChunkIndex);
            Assert.AreEqual(blockOffset, cursor.BlockOffset);
            Assert.AreEqual(eventIndex, cursor.EventIndex);

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }

            chunkFactory.Verify(r => r.BuildChunk(
                "chunk2",
                blockOffset,
                eventIndex));

            chunk.Verify(r => r.BlockOffset);
            chunk.Verify(r => r.EventIndex);
        }

        /// <summary>
        /// Tests Shard.HasNext().
        /// </summary>
        [Test]
        public async Task HasNext_False()
        {
            // Arrange
            string shardPath = "shardPath";
            long chunkIndex = 5;
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                chunkIndex,
                blockOffset,
                eventIndex);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<ChunkFactory> chunkFactory = new Mock<ChunkFactory>(MockBehavior.Strict);
            Mock<Chunk> chunk = new Mock<Chunk>(MockBehavior.Strict);

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetChunkPagesFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable = PageResponseEnumerator.CreateEnumerable(GetChunkPagesFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(pageable);
            }

            chunkFactory.Setup(r => r.BuildChunk(
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunk.Object);

            chunk.Setup(r => r.HasNext()).Returns(false);

            ShardFactory shardFactory = new ShardFactory(
                containerClient.Object,
                chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                shardPath,
                shardCursor)
                .ConfigureAwait(false);

            bool hasNext = shard.HasNext();

            // Assert
            Assert.IsFalse(hasNext);

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }

            chunkFactory.Verify(r => r.BuildChunk(
                "chunk5",
                blockOffset,
                eventIndex));

            chunk.Verify(r => r.HasNext());
        }

        /// <summary>
        /// Tests Shard.HasNext().
        /// </summary>
        [Test]
        public async Task HasNext_ChunksLeft()
        {
            // Arrange
            string shardPath = "shardPath";
            long chunkIndex = 2;
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                chunkIndex,
                blockOffset,
                eventIndex);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<ChunkFactory> chunkFactory = new Mock<ChunkFactory>(MockBehavior.Strict);
            Mock<Chunk> chunk = new Mock<Chunk>(MockBehavior.Strict);

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetChunkPagesFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable = PageResponseEnumerator.CreateEnumerable(GetChunkPagesFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(pageable);
            }

            chunkFactory.Setup(r => r.BuildChunk(
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunk.Object);

            ShardFactory shardFactory = new ShardFactory(
                containerClient.Object,
                chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                shardPath,
                shardCursor)
                .ConfigureAwait(false);

            bool hasNext = shard.HasNext();

            // Assert
            Assert.IsTrue(hasNext);

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }

            chunkFactory.Verify(r => r.BuildChunk(
                "chunk2",
                blockOffset,
                eventIndex));
        }

        /// <summary>
        /// Tests Shard.HasNext().
        /// </summary>
        [Test]
        public async Task HasNext_CurrentChunkHasNext()
        {
            // Arrange
            string shardPath = "shardPath";
            long chunkIndex = 5;
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                chunkIndex,
                blockOffset,
                eventIndex);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<ChunkFactory> chunkFactory = new Mock<ChunkFactory>(MockBehavior.Strict);
            Mock<Chunk> chunk = new Mock<Chunk>(MockBehavior.Strict);

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetChunkPagesFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable = PageResponseEnumerator.CreateEnumerable(GetChunkPagesFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(pageable);
            }

            chunkFactory.Setup(r => r.BuildChunk(
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunk.Object);

            chunk.Setup(r => r.HasNext()).Returns(true);

            ShardFactory shardFactory = new ShardFactory(
                containerClient.Object,
                chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                shardPath,
                shardCursor)
                .ConfigureAwait(false);

            bool hasNext = shard.HasNext();

            // Assert
            Assert.IsTrue(hasNext);

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }

            chunkFactory.Verify(r => r.BuildChunk(
                "chunk5",
                blockOffset,
                eventIndex));

            chunk.Verify(r => r.HasNext());
        }

        /// <summary>
        /// In this test, the Shard has 4 Chunks with 2 Events in each Chunk.
        /// We call ShardFactory.BuildShard() with a ShardCursor, to create the Shard,
        /// Shard.Next() 4 times, Shard.GetCursor(), and then Shard.Next 4 times.
        /// </summary>
        [Test]
        public async Task Next()
        {
            // Arrange
            int chunkCount = 4;
            int eventCount = 8;
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<ChunkFactory> chunkFactory = new Mock<ChunkFactory>(MockBehavior.Strict);
            List<Mock<Chunk>> chunks = new List<Mock<Chunk>>();

            List<BlobChangeFeedEvent> expectedChangeFeedEvents = new List<BlobChangeFeedEvent>();
            for (int i = 0; i < eventCount; i++)
            {
                chunks.Add(new Mock<Chunk>(MockBehavior.Strict));
                expectedChangeFeedEvents.Add(new BlobChangeFeedEvent
                {
                    Id = Guid.NewGuid()
                });
            }

            string shardPath = "shardPath";
            long chunkIndex = 2;
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                chunkIndex,
                blockOffset,
                eventIndex);

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetChunkPagesFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable = PageResponseEnumerator.CreateEnumerable(GetChunkPagesFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    It.IsAny<string>(),
                    default)).Returns(pageable);
            }

            chunkFactory.SetupSequence(r => r.BuildChunk(
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunks[0].Object)
                .Returns(chunks[1].Object)
                .Returns(chunks[2].Object)
                .Returns(chunks[3].Object);

            chunks[0].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            chunks[1].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            chunks[2].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            chunks[3].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(true)
                .Returns(true)
                .Returns(false);

            for (int i = 0; i < chunkCount; i++)
            {

                chunks[i].SetupSequence(r => r.Next(
                    It.IsAny<bool>(),
                    default))
                    .Returns(Task.FromResult(expectedChangeFeedEvents[2 * i]))
                    .Returns(Task.FromResult(expectedChangeFeedEvents[2 * i + 1]));
            }

            chunks[2].Setup(r => r.BlockOffset).Returns(blockOffset);
            chunks[2].Setup(r => r.EventIndex).Returns(eventIndex);

            ShardFactory shardFactory = new ShardFactory(
                containerClient.Object,
                chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                shardPath,
                shardCursor)
                .ConfigureAwait(false);

            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();
            for (int i = 0; i < 4; i++)
            {
                changeFeedEvents.Add(await shard.Next(IsAsync));
            }
            ShardCursor cursor = shard.GetCursor();
            for (int i = 0; i < 4; i++)
            {
                changeFeedEvents.Add(await shard.Next(IsAsync));
            }

            // Assert
            for (int i = 0; i < eventCount; i++)
            {
                Assert.AreEqual(expectedChangeFeedEvents[i].Id, changeFeedEvents[i].Id);
            }

            Assert.AreEqual(4, cursor.ChunkIndex);
            Assert.AreEqual(eventIndex, cursor.EventIndex);

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    shardPath,
                    default));
            }

            chunkFactory.Verify(r => r.BuildChunk(
                "chunk2",
                blockOffset,
                eventIndex));
            chunkFactory.Verify(r => r.BuildChunk(
                "chunk3",
                default,
                default));
            chunkFactory.Verify(r => r.BuildChunk(
                "chunk4",
                default,
                default));
            chunkFactory.Verify(r => r.BuildChunk(
                "chunk5",
                default,
                default));

            for (int i = 0; i < chunkCount; i++)
            {
                chunks[i].Verify(r => r.Next(IsAsync, default), Times.Exactly(2));
            }

            chunks[0].Verify(r => r.HasNext(), Times.Exactly(2));
            chunks[1].Verify(r => r.HasNext(), Times.Exactly(2));
            chunks[2].Verify(r => r.HasNext(), Times.Exactly(2));
            chunks[3].Verify(r => r.HasNext(), Times.Exactly(4));

            chunks[2].Verify(r => r.BlockOffset);
            chunks[2].Verify(r => r.EventIndex);
        }

        private static Task<Page<BlobHierarchyItem>> GetChunkPagesFuncAsync(
            string continuation,
            int? pageSizeHint)
            => Task.FromResult(GetChunkPagesFunc(continuation, pageSizeHint));

        private static Page<BlobHierarchyItem> GetChunkPagesFunc(
            string continuation,
            int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk0", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk1", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk2", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk3", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk4", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk5", false, null))
            });
    }
}
