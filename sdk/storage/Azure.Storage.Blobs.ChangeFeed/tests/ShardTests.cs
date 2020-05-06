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
                It.IsAny<BlobContainerClient>(),
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunk.Object);

            chunk.Setup(r => r.BlockOffset).Returns(blockOffset);
            chunk.Setup(r => r.EventIndex).Returns(eventIndex);

            ShardFactory shardFactory = new ShardFactory(chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                containerClient.Object,
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
                containerClient.Object,
                "chunk2",
                blockOffset,
                eventIndex));

            chunk.Verify(r => r.BlockOffset);
            chunk.Verify(r => r.EventIndex);
        }

        [Test]
        public async Task HasNext_False()
        {
            // Arrange
            string shardPath = "shardPath";
            long chunkIndex = 4;
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
                It.IsAny<BlobContainerClient>(),
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunk.Object);

            chunk.Setup(r => r.HasNext()).Returns(false);

            ShardFactory shardFactory = new ShardFactory(chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                containerClient.Object,
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
                containerClient.Object,
                "chunk4",
                blockOffset,
                eventIndex));

            chunk.Verify(r => r.HasNext());
        }

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
                It.IsAny<BlobContainerClient>(),
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunk.Object);

            ShardFactory shardFactory = new ShardFactory(chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                containerClient.Object,
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
                containerClient.Object,
                "chunk2",
                blockOffset,
                eventIndex));
        }

        [Test]
        public async Task HasNext_CurrentChunkHasNext()
        {
            // Arrange
            string shardPath = "shardPath";
            long chunkIndex = 4;
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
                It.IsAny<BlobContainerClient>(),
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunk.Object);

            chunk.Setup(r => r.HasNext()).Returns(true);

            ShardFactory shardFactory = new ShardFactory(chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                containerClient.Object,
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
                containerClient.Object,
                "chunk4",
                blockOffset,
                eventIndex));

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
                It.IsAny<BlobContainerClient>(),
                It.IsAny<string>(),
                It.IsAny<long?>(),
                It.IsAny<long?>()))
                .Returns(chunk.Object);

            chunk.Setup(r => r.Next(
                It.IsAny<bool>(),
                default))
                .Returns(Task.FromResult(expectedChangeFeedEvent));

            chunk.SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(true);

            chunk.Setup(r => r.BlockOffset).Returns(blockOffset);
            chunk.Setup(r => r.EventIndex).Returns(eventIndex);

            ShardFactory shardFactory = new ShardFactory(chunkFactory.Object);

            // Act
            Shard shard = await shardFactory.BuildShard(
                IsAsync,
                containerClient.Object,
                shardPath,
                shardCursor)
                .ConfigureAwait(false);

            BlobChangeFeedEvent changeFeedEvent = await shard.Next(IsAsync);
            ShardCursor cursor = shard.GetCursor();

            // Assert
            Assert.AreEqual(eventId, changeFeedEvent.Id);
            Assert.AreEqual(2, cursor.ChunkIndex);

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
                containerClient.Object,
                "chunk2",
                blockOffset,
                eventIndex));

            chunk.Verify(r => r.HasNext());
            chunk.Verify(r => r.Next(IsAsync, default));
            chunk.Verify(r => r.HasNext());
            chunk.Verify(r => r.BlockOffset);
            chunk.Verify(r => r.EventIndex);
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
            });
    }
}
