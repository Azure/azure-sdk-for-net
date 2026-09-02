// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Tests for <see cref="SegmentFactoryBase{TEvent}"/> covering manifest parsing,
    /// container-prefix stripping, empty-shard filtering, and cursor-driven shard restoration.
    /// </summary>
    public class SegmentFactoryBaseTests : ChangeFeedCommonTestBase
    {
        private const string ManifestPath = "idx/segments/2024/01/15/0800/meta.json";
        private static readonly DateTimeOffset ManifestDateTime =
            new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero);

        public SegmentFactoryBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Wires <paramref name="containerClient"/> so that downloading the manifest at
        /// <see cref="ManifestPath"/> returns the supplied JSON body. Mirrors the helper used by
        /// <c>ChangeFeedFactoryBaseTests</c> for the metadata blob.
        /// </summary>
        private void SetupManifestDownload(Mock<BlobContainerClient> containerClient, string manifestJson)
        {
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            containerClient.Setup(c => c.GetBlobClient(ManifestPath)).Returns(blobClient.Object);

            BlobDownloadStreamingResult streamingResult = BlobsModelFactory.BlobDownloadStreamingResult(
                content: new MemoryStream(Encoding.UTF8.GetBytes(manifestJson)));

            if (IsAsync)
            {
                blobClient.Setup(b => b.DownloadStreamingAsync(
                    It.IsAny<BlobDownloadOptions>(),
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(Response.FromValue(streamingResult, null));
            }
            else
            {
                blobClient.Setup(b => b.DownloadStreaming(
                    It.IsAny<BlobDownloadOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(Response.FromValue(streamingResult, null));
            }
        }

        /// <summary>
        /// Builds a non-empty mock shard with the given <paramref name="shardPath"/>.
        /// </summary>
        private static Mock<ShardBase<TestEvent>> BuildNonEmptyShardMock(string shardPath)
        {
            Mock<ShardBase<TestEvent>> shard = new Mock<ShardBase<TestEvent>>();
            shard.Setup(s => s.HasNext()).Returns(true);
            shard.Setup(s => s.ShardPath).Returns(shardPath);
            return shard;
        }

        /// <summary>
        /// Verifies the happy path: a manifest listing two chunk paths produces a
        /// <see cref="SegmentBase{TEvent}"/> with two shards, the parsed segment timestamp,
        /// and the manifest path preserved.
        /// </summary>
        [Test]
        public async Task BuildSegment_HappyPath_ParsesManifestAndCreatesShards()
        {
            string manifestJson = @"{""chunkFilePaths"":[""log/00/2024/01/15/0800/"",""log/01/2024/01/15/0800/""]}";

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupManifestDownload(containerClient, manifestJson);

            Mock<ShardFactoryBase<TestEvent>> shardFactory = new Mock<ShardFactoryBase<TestEvent>>();
            shardFactory.Setup(f => f.BuildShard(IsAsync, "log/00/2024/01/15/0800/", null))
                .ReturnsAsync(BuildNonEmptyShardMock("log/00/2024/01/15/0800/").Object);
            shardFactory.Setup(f => f.BuildShard(IsAsync, "log/01/2024/01/15/0800/", null))
                .ReturnsAsync(BuildNonEmptyShardMock("log/01/2024/01/15/0800/").Object);

            SegmentFactoryBase<TestEvent> factory = new SegmentFactoryBase<TestEvent>(
                containerClient.Object,
                shardFactory.Object,
                CreateTestConfig());

            SegmentBase<TestEvent> segment = await factory.BuildSegment(IsAsync, ManifestPath);

            Assert.IsNotNull(segment);
            Assert.AreEqual(ManifestDateTime, segment.DateTime);
            Assert.AreEqual(ManifestPath, segment.ManifestPath);
            Assert.IsTrue(segment.HasNext());

            SegmentCursor cursor = segment.GetCursor();
            Assert.AreEqual("log/00/2024/01/15/0800/", cursor.CurrentShardPath);

            shardFactory.VerifyAll();
        }

        /// <summary>
        /// Verifies that paths prefixed by <c>ContainerPrefix</c> are stripped before being passed
        /// to <see cref="ShardFactoryBase{TEvent}.BuildShard"/>. Without the strip, the shard
        /// listing would target the wrong blob path.
        /// </summary>
        [Test]
        public async Task BuildSegment_StripsContainerPrefix()
        {
            // CreateTestConfig sets ContainerPrefix = "$fileschangefeed-testguid/".
            string manifestJson =
                @"{""chunkFilePaths"":[""$fileschangefeed-testguid/log/00/2024/01/15/0800/""]}";

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupManifestDownload(containerClient, manifestJson);

            Mock<ShardFactoryBase<TestEvent>> shardFactory = new Mock<ShardFactoryBase<TestEvent>>();
            // Strict expectation: the call must come in WITHOUT the container prefix.
            shardFactory.Setup(f => f.BuildShard(IsAsync, "log/00/2024/01/15/0800/", null))
                .ReturnsAsync(BuildNonEmptyShardMock("log/00/2024/01/15/0800/").Object);

            SegmentFactoryBase<TestEvent> factory = new SegmentFactoryBase<TestEvent>(
                containerClient.Object,
                shardFactory.Object,
                CreateTestConfig());

            SegmentBase<TestEvent> segment = await factory.BuildSegment(IsAsync, ManifestPath);

            Assert.IsNotNull(segment);
            shardFactory.Verify(f => f.BuildShard(IsAsync, "log/00/2024/01/15/0800/", null), Times.Once);
            // Negative: the prefixed path must never have been forwarded.
            shardFactory.Verify(
                f => f.BuildShard(
                    It.IsAny<bool>(),
                    It.Is<string>(p => p.StartsWith("$fileschangefeed", StringComparison.Ordinal)),
                    It.IsAny<ShardCursor>()),
                Times.Never);
        }

        /// <summary>
        /// Verifies that shards which report <c>HasNext() == false</c> are filtered out of the
        /// resulting <see cref="SegmentBase{TEvent}"/>. This protects against a segment being
        /// built with empty shards that would otherwise need to be skipped at iteration time.
        /// </summary>
        [Test]
        public async Task BuildSegment_DropsEmptyShards()
        {
            string manifestJson = @"{""chunkFilePaths"":[""log/00/2024/01/15/0800/"",""log/01/2024/01/15/0800/""]}";

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupManifestDownload(containerClient, manifestJson);

            Mock<ShardBase<TestEvent>> emptyShard = new Mock<ShardBase<TestEvent>>();
            emptyShard.Setup(s => s.HasNext()).Returns(false);
            emptyShard.Setup(s => s.ShardPath).Returns("log/00/2024/01/15/0800/");

            Mock<ShardFactoryBase<TestEvent>> shardFactory = new Mock<ShardFactoryBase<TestEvent>>();
            shardFactory.Setup(f => f.BuildShard(IsAsync, "log/00/2024/01/15/0800/", null))
                .ReturnsAsync(emptyShard.Object);
            shardFactory.Setup(f => f.BuildShard(IsAsync, "log/01/2024/01/15/0800/", null))
                .ReturnsAsync(BuildNonEmptyShardMock("log/01/2024/01/15/0800/").Object);

            SegmentFactoryBase<TestEvent> factory = new SegmentFactoryBase<TestEvent>(
                containerClient.Object,
                shardFactory.Object,
                CreateTestConfig());

            SegmentBase<TestEvent> segment = await factory.BuildSegment(IsAsync, ManifestPath);

            // The empty shard should have been dropped, leaving only the second shard. The cursor's
            // CurrentShardPath reflects the shard at index 0 of the surviving list.
            SegmentCursor cursor = segment.GetCursor();
            Assert.AreEqual("log/01/2024/01/15/0800/", cursor.CurrentShardPath);
        }

        /// <summary>
        /// Verifies that when a <see cref="SegmentCursor"/> with a non-null
        /// <c>CurrentShardPath</c> is supplied, the returned segment positions itself on the
        /// matching shard (rather than defaulting to index 0).
        /// </summary>
        [Test]
        public async Task BuildSegment_RestoresCurrentShardPathFromCursor()
        {
            string manifestJson = @"{""chunkFilePaths"":[""log/00/2024/01/15/0800/"",""log/01/2024/01/15/0800/""]}";

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            SetupManifestDownload(containerClient, manifestJson);

            Mock<ShardFactoryBase<TestEvent>> shardFactory = new Mock<ShardFactoryBase<TestEvent>>();
            shardFactory.Setup(f => f.BuildShard(IsAsync, "log/00/2024/01/15/0800/", It.IsAny<ShardCursor>()))
                .ReturnsAsync(BuildNonEmptyShardMock("log/00/2024/01/15/0800/").Object);
            shardFactory.Setup(f => f.BuildShard(IsAsync, "log/01/2024/01/15/0800/", It.IsAny<ShardCursor>()))
                .ReturnsAsync(BuildNonEmptyShardMock("log/01/2024/01/15/0800/").Object);

            SegmentCursor inputCursor = new SegmentCursor(
                segmentPath: ManifestPath,
                shardCursors: new List<ShardCursor>(),
                currentShardPath: "log/01/2024/01/15/0800/");

            SegmentFactoryBase<TestEvent> factory = new SegmentFactoryBase<TestEvent>(
                containerClient.Object,
                shardFactory.Object,
                CreateTestConfig());

            SegmentBase<TestEvent> segment = await factory.BuildSegment(IsAsync, ManifestPath, inputCursor);

            // GetCursor returns CurrentShardPath = _shards[_shardIndex].ShardPath, so this asserts
            // _shardIndex was correctly set to the shard matching cursor.CurrentShardPath.
            SegmentCursor outputCursor = segment.GetCursor();
            Assert.AreEqual("log/01/2024/01/15/0800/", outputCursor.CurrentShardPath);
        }
    }
}
