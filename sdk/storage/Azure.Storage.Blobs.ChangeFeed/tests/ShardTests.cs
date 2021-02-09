// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Core;
using System.Threading;

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
            string currentChunkPath = "chunk2";
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                currentChunkPath,
                blockOffset,
                eventIndex);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<ChunkFactory> chunkFactory = new Mock<ChunkFactory>(MockBehavior.Strict);
            Dictionary<string, Mock<Chunk>> chunks = GetChunkMocks(blockOffset, eventIndex);

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
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<CancellationToken>()))
                .Returns((bool _, string path, long __, long ___, CancellationToken ____) => Task.FromResult(chunks[path].Object));

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
            Assert.AreEqual(currentChunkPath, cursor.CurrentChunkPath);
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
                It.IsAny<bool>(),
                "chunk2",
                blockOffset,
                eventIndex,
                It.IsAny<CancellationToken>()));

            chunks["chunk2"].Verify(r => r.BlockOffset);
            chunks["chunk2"].Verify(r => r.EventIndex);
            chunks["chunk2"].Verify(r => r.ChunkPath);
        }

        /// <summary>
        /// Tests Shard.HasNext().
        /// </summary>
        [Test]
        public async Task HasNext_False()
        {
            // Arrange
            string shardPath = "shardPath";
            string currentChunkPath = "chunk5";
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                currentChunkPath,
                blockOffset,
                eventIndex);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<ChunkFactory> chunkFactory = new Mock<ChunkFactory>(MockBehavior.Strict);
            Dictionary<string, Mock<Chunk>> chunks = GetChunkMocks(blockOffset, eventIndex);

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
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<CancellationToken>()))
                .Returns((bool _, string path, long __, long ___, CancellationToken ____) => Task.FromResult(chunks[path].Object));

            chunks["chunk5"].Setup(r => r.HasNext()).Returns(false);

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
                It.IsAny<bool>(),
                "chunk5",
                blockOffset,
                eventIndex,
                It.IsAny<CancellationToken>()));

            chunks["chunk5"].Verify(r => r.HasNext());
        }

        /// <summary>
        /// Tests Shard.HasNext().
        /// </summary>
        [Test]
        public async Task HasNext_ChunksLeft()
        {
            // Arrange
            string shardPath = "shardPath";
            string currentChunkPath = "chunk2";
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                currentChunkPath,
                blockOffset,
                eventIndex);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<ChunkFactory> chunkFactory = new Mock<ChunkFactory>(MockBehavior.Strict);
            Dictionary<string, Mock<Chunk>> chunks = GetChunkMocks(blockOffset, eventIndex);

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
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<CancellationToken>()))
                .Returns((bool _, string path, long __, long ___, CancellationToken ____) => Task.FromResult(chunks[path].Object));

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
                It.IsAny<bool>(),
                "chunk2",
                blockOffset,
                eventIndex,
                It.IsAny<CancellationToken>()));
        }

        /// <summary>
        /// Tests Shard.HasNext().
        /// </summary>
        [Test]
        public async Task HasNext_CurrentChunkHasNext()
        {
            // Arrange
            string shardPath = "shardPath";
            string currentChunkPath = "chunk5";
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                currentChunkPath,
                blockOffset,
                eventIndex);

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<ChunkFactory> chunkFactory = new Mock<ChunkFactory>(MockBehavior.Strict);
            Dictionary<string, Mock<Chunk>> chunks = GetChunkMocks(blockOffset, eventIndex);

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
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<CancellationToken>()))
                .Returns((bool _, string path, long __, long ___, CancellationToken ____) => Task.FromResult(chunks[path].Object));

            chunks["chunk5"].Setup(r => r.HasNext()).Returns(true);

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
                It.IsAny<bool>(),
                "chunk5",
                blockOffset,
                eventIndex,
                It.IsAny<CancellationToken>()));

            chunks["chunk5"].Verify(r => r.HasNext());
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
            Dictionary<string, Mock<Chunk>> chunks = new Dictionary<string, Mock<Chunk>>();

            List<BlobChangeFeedEvent> expectedChangeFeedEvents = new List<BlobChangeFeedEvent>();
            for (int i = 0; i < eventCount; i++)
            {
                var chunkPath = $"chunk{i + 2}";
                var mock = new Mock<Chunk>(MockBehavior.Strict);
                mock.Setup(x => x.ChunkPath).Returns(chunkPath);
                chunks.Add(chunkPath, mock);
                expectedChangeFeedEvents.Add(new BlobChangeFeedEvent
                {
                    Id = Guid.NewGuid()
                });
            }

            string shardPath = "shardPath";
            string currentChunkPath = "chunk2";
            long blockOffset = 100;
            long eventIndex = 200;

            ShardCursor shardCursor = new ShardCursor(
                currentChunkPath,
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

            chunkFactory.Setup(r => r.BuildChunk(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<CancellationToken>()))
                .Returns((bool _, string path, long __, long ___, CancellationToken ____) => Task.FromResult(chunks[path].Object));

            chunks["chunk2"].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            chunks["chunk3"].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            chunks["chunk4"].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            chunks["chunk5"].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(true)
                .Returns(true)
                .Returns(false);

            for (int i = 0; i < chunkCount; i++)
            {
                chunks[$"chunk{2 + i}"].SetupSequence(r => r.Next(
                    It.IsAny<bool>(),
                    default))
                    .Returns(Task.FromResult(expectedChangeFeedEvents[2 * i]))
                    .Returns(Task.FromResult(expectedChangeFeedEvents[2 * i + 1]));
            }

            chunks["chunk4"].Setup(r => r.BlockOffset).Returns(blockOffset);
            chunks["chunk4"].Setup(r => r.EventIndex).Returns(eventIndex);

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

            Assert.AreEqual("chunk4", cursor.CurrentChunkPath);
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
                It.IsAny<bool>(),
                "chunk2",
                blockOffset,
                eventIndex,
                It.IsAny<CancellationToken>()));
            chunkFactory.Verify(r => r.BuildChunk(
                It.IsAny<bool>(),
                "chunk3",
                default,
                default,
                It.IsAny<CancellationToken>()));
            chunkFactory.Verify(r => r.BuildChunk(
                It.IsAny<bool>(),
                "chunk4",
                default,
                default,
                It.IsAny<CancellationToken>()));
            chunkFactory.Verify(r => r.BuildChunk(
                It.IsAny<bool>(),
                "chunk5",
                default,
                default,
                It.IsAny<CancellationToken>()));

            for (int i = 0; i < chunkCount; i++)
            {
                chunks[$"chunk{2 + i}"].Verify(r => r.Next(IsAsync, default), Times.Exactly(2));
            }

            chunks["chunk2"].Verify(r => r.HasNext(), Times.Exactly(2));
            chunks["chunk3"].Verify(r => r.HasNext(), Times.Exactly(2));
            chunks["chunk4"].Verify(r => r.HasNext(), Times.Exactly(2));
            chunks["chunk5"].Verify(r => r.HasNext(), Times.Exactly(4));

            chunks["chunk4"].Verify(r => r.BlockOffset);
            chunks["chunk4"].Verify(r => r.EventIndex);
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
                    BlobsModelFactory.BlobItem("chunk0", false, BlobsModelFactory.BlobItemProperties(true, contentLength: long.MaxValue))),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk1", false, BlobsModelFactory.BlobItemProperties(true, contentLength: long.MaxValue))),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk2", false, BlobsModelFactory.BlobItemProperties(true, contentLength: long.MaxValue))),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk3", false, BlobsModelFactory.BlobItemProperties(true, contentLength: long.MaxValue))),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk4", false, BlobsModelFactory.BlobItemProperties(true, contentLength: long.MaxValue))),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("chunk5", false, BlobsModelFactory.BlobItemProperties(true, contentLength: long.MaxValue)))
            });

        private static Dictionary<string, Mock<Chunk>> GetChunkMocks(long blockOffset, long eventIndex)
        {
            Dictionary<string, Mock<Chunk>> mocks = new Dictionary<string, Mock<Chunk>>();
            for (int i = 0; i < 6; i++)
            {
                var chunkPath = $"chunk{i}";
                Mock<Chunk> chunkMock = new Mock<Chunk>(MockBehavior.Strict);
                chunkMock.Setup(r => r.BlockOffset).Returns(blockOffset);
                chunkMock.Setup(r => r.EventIndex).Returns(eventIndex);
                chunkMock.Setup(r => r.ChunkPath).Returns(chunkPath);
                mocks.Add(chunkPath, chunkMock);
            }
            return mocks;
        }
    }
}
