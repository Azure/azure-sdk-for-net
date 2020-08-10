// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
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

        /// <summary>
        /// Test building a Segment with a SegmentCursor, and then calling Segment.GetCursor().
        /// </summary>
        [Test]
        public async Task GetCursor()
        {
            // Arrange
            string manifestPath = "idx/segments/2020/03/25/0200/meta.json";

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<ShardFactory> shardFactory = new Mock<ShardFactory>(MockBehavior.Strict);

            List<Mock<Shard>> shards = new List<Mock<Shard>>();
            int shardCount = 3;
            for (int i = 0; i < shardCount; i++)
            {
                shards.Add(new Mock<Shard>(MockBehavior.Strict));
            }

            DateTimeOffset dateTime = new DateTimeOffset(2020, 3, 25, 2, 0, 0, TimeSpan.Zero);
            string segmentPath = "idx/segments/2020/03/25/0200/meta.json";
            string currentShardPath = "log/00/2020/03/25/0200/";

            List<ShardCursor> shardCursors = new List<ShardCursor>
            {
                new ShardCursor("log/00/2020/03/25/0200/chunk1", 2, 3),
                new ShardCursor("log/01/2020/03/25/0200/chunk4", 5, 6),
                new ShardCursor("log/02/2020/03/25/0200/chunk7", 8, 9)
            };

            SegmentCursor expectedCursor = new SegmentCursor(
                segmentPath,
                shardCursors,
                currentShardPath);

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);

            using FileStream stream = File.OpenRead(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"SegmentManifest.json"}");
            BlobDownloadInfo blobDownloadInfo = BlobsModelFactory.BlobDownloadInfo(content: stream);
            Response<BlobDownloadInfo> downloadResponse = Response.FromValue(blobDownloadInfo, new MockResponse(200));

            if (IsAsync)
            {
                blobClient.Setup(r => r.DownloadAsync()).ReturnsAsync(downloadResponse);
            }
            else
            {
                blobClient.Setup(r => r.Download()).Returns(downloadResponse);
            }

            shardFactory.SetupSequence(r => r.BuildShard(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<ShardCursor>()))
                .ReturnsAsync(shards[0].Object)
                .ReturnsAsync(shards[1].Object)
                .ReturnsAsync(shards[2].Object);

            for (int i = 0; i < shardCount; i++)
            {
                shards[i].Setup(r => r.GetCursor()).Returns(shardCursors[i]);
                shards[i].Setup(r => r.ShardPath).Returns($"log/0{i}/2020/03/25/0200/");
                shards[i].Setup(r => r.HasNext()).Returns(true);
            }

            SegmentFactory segmentFactory = new SegmentFactory(
                containerClient.Object,
                shardFactory.Object);
            Segment segment = await segmentFactory.BuildSegment(
                IsAsync,
                manifestPath,
                expectedCursor);

            // Act
            SegmentCursor cursor = segment.GetCursor();

            // Assert
            Assert.AreEqual(expectedCursor.SegmentPath, cursor.SegmentPath);
            Assert.AreEqual(expectedCursor.ShardCursors.Count, cursor.ShardCursors.Count);
            for (int i = 0; i < shardCount; i++)
            {
                Assert.AreEqual(expectedCursor.ShardCursors[i].BlockOffset, cursor.ShardCursors[i].BlockOffset);
                Assert.AreEqual(expectedCursor.ShardCursors[i].CurrentChunkPath, cursor.ShardCursors[i].CurrentChunkPath);
                Assert.AreEqual(expectedCursor.ShardCursors[i].EventIndex, cursor.ShardCursors[i].EventIndex);
            }
            Assert.AreEqual(currentShardPath, cursor.CurrentShardPath);

            containerClient.Verify(r => r.GetBlobClient(manifestPath));

            if (IsAsync)
            {
                blobClient.Verify(r => r.DownloadAsync());
            }
            else
            {
                blobClient.Verify(r => r.Download());
            }

            for (int i = 0; i < shards.Count; i++)
            {
                shardFactory.Verify(r => r.BuildShard(
                    IsAsync,
                    $"log/0{i}/2020/03/25/0200/",
                    shardCursors[i]));
            }
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
            string manifestPath = "idx/segments/2020/03/25/0200/meta.json";
            int shardCount = 3;
            int eventCount = 5;

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<ShardFactory> shardFactory = new Mock<ShardFactory>(MockBehavior.Strict);

            List<Mock<Shard>> shards = new List<Mock<Shard>>();

            for (int i = 0; i < shardCount; i++)
            {
                shards.Add(new Mock<Shard>(MockBehavior.Strict));
            }

            List<Guid> eventIds = new List<Guid>();
            for (int i = 0; i < eventCount; i++)
            {
                eventIds.Add(Guid.NewGuid());
            }

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);

            using FileStream stream = File.OpenRead(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"SegmentManifest.json"}");
            BlobDownloadInfo blobDownloadInfo = BlobsModelFactory.BlobDownloadInfo(content: stream);
            Response<BlobDownloadInfo> downloadResponse = Response.FromValue(blobDownloadInfo, new MockResponse(200));

            if (IsAsync)
            {
                blobClient.Setup(r => r.DownloadAsync()).ReturnsAsync(downloadResponse);
            }
            else
            {
                blobClient.Setup(r => r.Download()).Returns(downloadResponse);
            }

            shardFactory.SetupSequence(r => r.BuildShard(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<ShardCursor>()))
                .ReturnsAsync(shards[0].Object)
                .ReturnsAsync(shards[1].Object)
                .ReturnsAsync(shards[2].Object);

            // Set up Shards
            shards[0].SetupSequence(r => r.Next(It.IsAny<bool>(), default))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[0]
                }))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[3]
                }));

            shards[0].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(true)
                .Returns(false);

            shards[1].SetupSequence(r => r.Next(It.IsAny<bool>(), default))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[1]
                }))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[4]
                }));

            shards[1].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(true)
                .Returns(false);

            shards[2].Setup(r => r.Next(It.IsAny<bool>(), default))
                .Returns(Task.FromResult(new BlobChangeFeedEvent
                {
                    Id = eventIds[2]
                }));

            shards[2].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            SegmentFactory segmentFactory = new SegmentFactory(
                containerClient.Object,
                shardFactory.Object);
            Segment segment = await segmentFactory.BuildSegment(
                IsAsync,
                manifestPath);

            // Act
            List<BlobChangeFeedEvent> events = await segment.GetPage(IsAsync, 25);

            // Assert
            Assert.AreEqual(eventCount, events.Count);
            for (int i = 0; i < eventCount; i++)
            {
                Assert.AreEqual(eventIds[i], events[i].Id);
            }

            containerClient.Verify(r => r.GetBlobClient(manifestPath));
            if (IsAsync)
            {
                blobClient.Verify(r => r.DownloadAsync());
            }
            else
            {
                blobClient.Verify(r => r.Download());
            }

            for (int i = 0; i < shards.Count; i++)
            {
                shardFactory.Verify(r => r.BuildShard(
                    IsAsync,
                    $"log/0{i}/2020/03/25/0200/",
                    default));
            }

            shards[0].Verify(r => r.Next(IsAsync, default));
            shards[0].Verify(r => r.HasNext());
            shards[1].Verify(r => r.Next(IsAsync, default));
            shards[1].Verify(r => r.HasNext());
            shards[2].Verify(r => r.Next(IsAsync, default));
            shards[2].Verify(r => r.HasNext());
            shards[0].Verify(r => r.Next(IsAsync, default));
            shards[0].Verify(r => r.HasNext());
            shards[1].Verify(r => r.Next(IsAsync, default));
            shards[1].Verify(r => r.HasNext());
        }
    }
}
