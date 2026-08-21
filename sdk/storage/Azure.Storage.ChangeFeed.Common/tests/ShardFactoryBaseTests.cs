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
    /// Tests for <see cref="ShardFactoryBase{TEvent}"/> covering cursor-driven fast-forward,
    /// block-offset alignment with chunk content length, and the no-cursor happy path.
    /// These tests pin the cursor-acceptance plumbing that <see cref="ChangeFeedFactoryBase{TEvent}"/>
    /// relies on for resumption — the rejection paths are covered separately.
    /// </summary>
    public class ShardFactoryBaseTests : ChangeFeedCommonTestBase
    {
        private const string ShardPath = "log/00/2024/01/15/0800/";

        public ShardFactoryBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Wires <paramref name="containerClient"/> so a hierarchy listing under the shard prefix
        /// returns the supplied chunk blobs. <paramref name="chunks"/> tuples are (path, contentLength).
        /// </summary>
        private void SetupChunkListing(
            Mock<BlobContainerClient> containerClient,
            IEnumerable<(string Path, long ContentLength)> chunks)
        {
            List<BlobHierarchyItem> items = new List<BlobHierarchyItem>();
            foreach ((string path, long contentLength) in chunks)
            {
                BlobItemProperties properties = BlobsModelFactory.BlobItemProperties(
                    accessTierInferred: false,
                    contentLength: contentLength);
                items.Add(BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem(path, false, properties)));
            }

            BlobHierarchyItemPage page = new BlobHierarchyItemPage(items);

            if (IsAsync)
            {
                containerClient.Setup(c => c.GetBlobsByHierarchyAsync(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new SingleAsyncPageable(page));
            }
            else
            {
                containerClient.Setup(c => c.GetBlobsByHierarchy(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new SingleSyncPageable(page));
            }
        }

        /// <summary>
        /// Wires <paramref name="containerClient"/> so <c>GetBlobClient(path).GetProperties()</c>
        /// reports <paramref name="authoritativeLength"/>. This models the authoritative blob length
        /// re-read that <see cref="ShardFactoryBase{TEvent}"/> performs when the container listing's
        /// <c>ContentLength</c> lags the true length of a still-appending (non-finalized) chunk blob.
        /// </summary>
        private void SetupChunkProperties(
            Mock<BlobContainerClient> containerClient,
            string path,
            long authoritativeLength)
        {
            BlobProperties properties = BlobsModelFactory.BlobProperties(contentLength: authoritativeLength);
            Mock<BlobClient> blobClient = new Mock<BlobClient>();

            if (IsAsync)
            {
                blobClient.Setup(b => b.GetPropertiesAsync(
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(properties, Mock.Of<Response>()));
            }
            else
            {
                blobClient.Setup(b => b.GetProperties(
                    It.IsAny<BlobRequestConditions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(Response.FromValue(properties, Mock.Of<Response>()));
            }

            containerClient.Setup(c => c.GetBlobClient(path)).Returns(blobClient.Object);
        }

        /// <summary>
        /// Returns a chunk-factory mock that responds to any <c>BuildChunk</c> call by returning
        /// a non-empty <see cref="ChunkBase{TEvent}"/> mock with a stable <c>ChunkPath</c>.
        /// </summary>
        private static Mock<ChunkFactoryBase<TestEvent>> BuildChunkFactoryMock()
        {
            Mock<ChunkFactoryBase<TestEvent>> chunkFactory = new Mock<ChunkFactoryBase<TestEvent>>();
            chunkFactory.Setup(f => f.BuildChunk(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<CancellationToken>()))
                .Returns((bool _, string path, long offset, long index, CancellationToken __) =>
                {
                    Mock<ChunkBase<TestEvent>> chunk = new Mock<ChunkBase<TestEvent>>();
                    chunk.Setup(c => c.HasNext()).Returns(true);
                    chunk.Setup(c => c.ChunkPath).Returns(path);
                    chunk.Setup(c => c.BlockOffset).Returns(offset);
                    chunk.Setup(c => c.EventIndex).Returns(index);
                    return Task.FromResult(chunk.Object);
                });
            return chunkFactory;
        }

        /// <summary>
        /// With no cursor supplied, the first chunk in the listing is loaded with offsets 0/0.
        /// </summary>
        [Test]
        public async Task BuildShard_NoCursor_StartsFromFirstChunkWithZeroOffsets()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupChunkListing(containerClient, new[]
            {
                ("log/00/2024/01/15/0800/00000.avro", 1000L),
                ("log/00/2024/01/15/0800/00001.avro", 1000L),
            });

            Mock<ChunkFactoryBase<TestEvent>> chunkFactory = BuildChunkFactoryMock();

            ShardFactoryBase<TestEvent> factory = new ShardFactoryBase<TestEvent>(
                containerClient.Object,
                chunkFactory.Object);

            ShardBase<TestEvent> shard = await factory.BuildShard(IsAsync, ShardPath);

            Assert.IsTrue(shard.HasNext());
            chunkFactory.Verify(f => f.BuildChunk(
                It.IsAny<bool>(),
                "log/00/2024/01/15/0800/00000.avro",
                0L,
                0L,
                It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// When a cursor names <c>chunk2</c> as the current chunk, earlier chunks are dequeued
        /// and skipped, and <c>chunk2</c> is loaded with the cursor's offsets propagated through.
        /// </summary>
        [Test]
        public async Task BuildShard_WithCursor_FastForwardsToCurrentChunk()
        {
            const long blockOffset = 100;
            const long eventIndex = 5;

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupChunkListing(containerClient, new[]
            {
                ("chunk1.avro", 1000L),
                ("chunk2.avro", 1000L),
                ("chunk3.avro", 1000L),
            });

            Mock<ChunkFactoryBase<TestEvent>> chunkFactory = BuildChunkFactoryMock();

            ShardCursor cursor = new ShardCursor("chunk2.avro", blockOffset, eventIndex);

            ShardFactoryBase<TestEvent> factory = new ShardFactoryBase<TestEvent>(
                containerClient.Object,
                chunkFactory.Object);

            ShardBase<TestEvent> shard = await factory.BuildShard(IsAsync, ShardPath, cursor);

            // chunk2 must be loaded with the cursor offsets intact.
            chunkFactory.Verify(f => f.BuildChunk(
                It.IsAny<bool>(),
                "chunk2.avro",
                blockOffset,
                eventIndex,
                It.IsAny<CancellationToken>()), Times.Once);

            // chunk1 was earlier in the listing — it must NOT have been loaded.
            chunkFactory.Verify(f => f.BuildChunk(
                It.IsAny<bool>(),
                "chunk1.avro",
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<CancellationToken>()), Times.Never);

            // The cursor returned by the shard reflects the resumed chunk, offset, and index.
            ShardCursor outCursor = shard.GetCursor();
            Assert.AreEqual("chunk2.avro", outCursor.CurrentChunkPath);
            Assert.AreEqual(blockOffset, outCursor.BlockOffset);
            Assert.AreEqual(eventIndex, outCursor.EventIndex);
        }

        /// <summary>
        /// When the cursor's <c>BlockOffset</c> exceeds the chunk's authoritative length (confirmed
        /// by a fresh GetProperties re-read, not just the container listing), the factory throws.
        /// This guards against silently skipping past the end of a chunk when a cursor was generated
        /// against a different (longer) version of the blob.
        /// </summary>
        [Test]
        public void BuildShard_BlockOffsetExceedsContentLength_Throws()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupChunkListing(containerClient, new[]
            {
                ("chunk1.avro", 50L),  // smaller than the cursor's BlockOffset
            });
            // Authoritative length is also below the offset, so the offset is genuinely invalid.
            SetupChunkProperties(containerClient, "chunk1.avro", authoritativeLength: 50L);

            Mock<ChunkFactoryBase<TestEvent>> chunkFactory = BuildChunkFactoryMock();

            ShardCursor cursor = new ShardCursor("chunk1.avro", blockOffset: 100, eventIndex: 0);

            ShardFactoryBase<TestEvent> factory = new ShardFactoryBase<TestEvent>(
                containerClient.Object,
                chunkFactory.Object);

            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await factory.BuildShard(IsAsync, ShardPath, cursor));
            StringAssert.Contains("blockOffset", ex.Message, "Exception should mention the offending offset.");
        }

        /// <summary>
        /// When the cursor sits exactly at the end of a chunk (<c>BlockOffset == ContentLength</c>),
        /// the factory advances to the next chunk and loads it from offset 0. This is the cursor
        /// position immediately after a chunk has been fully consumed.
        /// </summary>
        [Test]
        public async Task BuildShard_BlockOffsetEqualsContentLength_AdvancesToNextChunk()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupChunkListing(containerClient, new[]
            {
                ("chunk1.avro", 100L),
                ("chunk2.avro", 1000L),
            });
            // Authoritative length confirms the cursor sits exactly at the end of chunk1.
            SetupChunkProperties(containerClient, "chunk1.avro", authoritativeLength: 100L);

            Mock<ChunkFactoryBase<TestEvent>> chunkFactory = BuildChunkFactoryMock();

            ShardCursor cursor = new ShardCursor("chunk1.avro", blockOffset: 100, eventIndex: 0);

            ShardFactoryBase<TestEvent> factory = new ShardFactoryBase<TestEvent>(
                containerClient.Object,
                chunkFactory.Object);

            ShardBase<TestEvent> shard = await factory.BuildShard(IsAsync, ShardPath, cursor);

            // chunk1 is exhausted — the next chunk in the listing is loaded with default offsets.
            chunkFactory.Verify(f => f.BuildChunk(
                It.IsAny<bool>(),
                "chunk2.avro",
                0L,
                0L,
                It.IsAny<CancellationToken>()), Times.Once);

            // chunk1 itself must never have been instantiated as a chunk reader.
            chunkFactory.Verify(f => f.BuildChunk(
                It.IsAny<bool>(),
                "chunk1.avro",
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        /// <summary>
        /// Reproduces the non-finalized resume bug: the container listing reports a stale
        /// <c>ContentLength</c> (smaller than the cursor's <c>BlockOffset</c>) because the chunk
        /// append blob is still being appended to, but the authoritative GetProperties re-read
        /// reports the true, larger length. The factory must resume the chunk at the cursor offset
        /// instead of falsely throwing <see cref="ArgumentException"/>.
        /// </summary>
        [Test]
        public async Task BuildShard_StaleListingBelowOffset_ResumesFromAuthoritativeLength()
        {
            const long blockOffset = 12592;
            const long eventIndex = 3;

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupChunkListing(containerClient, new[]
            {
                ("chunk1.avro", 8000L),  // stale: lags behind the true blob length
            });
            // The blob has actually grown past the cursor offset.
            SetupChunkProperties(containerClient, "chunk1.avro", authoritativeLength: 20000L);

            Mock<ChunkFactoryBase<TestEvent>> chunkFactory = BuildChunkFactoryMock();

            ShardCursor cursor = new ShardCursor("chunk1.avro", blockOffset, eventIndex);

            ShardFactoryBase<TestEvent> factory = new ShardFactoryBase<TestEvent>(
                containerClient.Object,
                chunkFactory.Object);

            ShardBase<TestEvent> shard = await factory.BuildShard(IsAsync, ShardPath, cursor);

            // The current chunk is resumed at the cursor offset rather than being rejected.
            chunkFactory.Verify(f => f.BuildChunk(
                It.IsAny<bool>(),
                "chunk1.avro",
                blockOffset,
                eventIndex,
                It.IsAny<CancellationToken>()), Times.Once);

            ShardCursor outCursor = shard.GetCursor();
            Assert.AreEqual("chunk1.avro", outCursor.CurrentChunkPath);
            Assert.AreEqual(blockOffset, outCursor.BlockOffset);
            Assert.AreEqual(eventIndex, outCursor.EventIndex);
        }

        /// <summary>
        /// When the listing reports <c>ContentLength == BlockOffset</c> but the chunk blob has
        /// actually grown past the offset (authoritative length is larger), the factory must resume
        /// reading the same chunk at the offset rather than prematurely advancing to the next chunk
        /// and skipping the newly appended events.
        /// </summary>
        [Test]
        public async Task BuildShard_StaleListingEqualsOffset_ResumesSameChunkNotNext()
        {
            const long blockOffset = 100;

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupChunkListing(containerClient, new[]
            {
                ("chunk1.avro", 100L),   // stale: equals the offset
                ("chunk2.avro", 1000L),
            });
            // chunk1 has actually grown past the offset — more events are available in it.
            SetupChunkProperties(containerClient, "chunk1.avro", authoritativeLength: 5000L);

            Mock<ChunkFactoryBase<TestEvent>> chunkFactory = BuildChunkFactoryMock();

            ShardCursor cursor = new ShardCursor("chunk1.avro", blockOffset, eventIndex: 0);

            ShardFactoryBase<TestEvent> factory = new ShardFactoryBase<TestEvent>(
                containerClient.Object,
                chunkFactory.Object);

            ShardBase<TestEvent> shard = await factory.BuildShard(IsAsync, ShardPath, cursor);

            // chunk1 is resumed at the offset...
            chunkFactory.Verify(f => f.BuildChunk(
                It.IsAny<bool>(),
                "chunk1.avro",
                blockOffset,
                0L,
                It.IsAny<CancellationToken>()), Times.Once);

            // ...and chunk2 is NOT prematurely loaded.
            chunkFactory.Verify(f => f.BuildChunk(
                It.IsAny<bool>(),
                "chunk2.avro",
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        /// <summary>
        /// When the cursor names a chunk path that is not in the listing, the factory throws.
        /// This guards against silent zero-event reads when a cursor is reused against a feed
        /// whose chunk has been pruned or never existed.
        /// </summary>
        [Test]
        public void BuildShard_CursorChunkNotFound_Throws()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupChunkListing(containerClient, new[]
            {
                ("chunk1.avro", 1000L),
                ("chunk2.avro", 1000L),
            });

            Mock<ChunkFactoryBase<TestEvent>> chunkFactory = BuildChunkFactoryMock();

            ShardCursor cursor = new ShardCursor("chunk-missing.avro", blockOffset: 0, eventIndex: 0);

            ShardFactoryBase<TestEvent> factory = new ShardFactoryBase<TestEvent>(
                containerClient.Object,
                chunkFactory.Object);

            ArgumentException ex = Assert.ThrowsAsync<ArgumentException>(
                async () => await factory.BuildShard(IsAsync, ShardPath, cursor));
            StringAssert.Contains("chunk-missing.avro", ex.Message);
        }

        private class SingleAsyncPageable : AsyncPageable<BlobHierarchyItem>
        {
            private readonly Page<BlobHierarchyItem> _page;
            public SingleAsyncPageable(Page<BlobHierarchyItem> page) { _page = page; }
            public override async IAsyncEnumerable<Page<BlobHierarchyItem>> AsPages(
                string continuationToken = null, int? pageSizeHint = null)
            {
                yield return _page;
                await Task.CompletedTask;
            }
        }

        private class SingleSyncPageable : Pageable<BlobHierarchyItem>
        {
            private readonly Page<BlobHierarchyItem> _page;
            public SingleSyncPageable(Page<BlobHierarchyItem> page) { _page = page; }
            public override IEnumerable<Page<BlobHierarchyItem>> AsPages(
                string continuationToken = null, int? pageSizeHint = null)
            {
                yield return _page;
            }
        }
    }
}
