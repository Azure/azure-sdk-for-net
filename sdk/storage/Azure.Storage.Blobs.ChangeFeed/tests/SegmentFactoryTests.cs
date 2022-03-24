// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class SegmentFactoryTests : ChangeFeedTestBase
    {
        public SegmentFactoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task BuildSegment_SegmentCursorNullCurrentShardPath()
        {
            // Arrange
            string manifestPath = "idx/segments/2020/03/25/0200/meta.json";
            string segmentPath = "idx/segments/2020/03/25/0200/meta.json";
            List<ShardCursor> shardCursors = new List<ShardCursor>
            {
                new ShardCursor("log/00/2020/03/25/0200/chunk1", 2, 3),
                new ShardCursor("log/01/2020/03/25/0200/chunk4", 5, 6),
                new ShardCursor("log/02/2020/03/25/0200/chunk7", 8, 9)
            };
            SegmentCursor expectedSegmentCursor = new SegmentCursor()
            {
                SegmentPath = segmentPath,
                ShardCursors = shardCursors,
                CurrentShardPath = null
            };

            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<ShardFactory> shardFactory = new Mock<ShardFactory>(MockBehavior.Strict);

            List<Mock<Shard>> shards = new List<Mock<Shard>>();
            int shardCount = 3;
            for (int i = 0; i < shardCount; i++)
            {
                shards.Add(new Mock<Shard>(MockBehavior.Strict));
            }

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);

            using FileStream stream = File.OpenRead(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"SegmentManifest.json"}");
            BlobDownloadStreamingResult blobDownloadStreamingResult = BlobsModelFactory.BlobDownloadStreamingResult(content: stream);
            Response<BlobDownloadStreamingResult> downloadResponse = Response.FromValue(blobDownloadStreamingResult, new MockResponse(200));

            if (IsAsync)
            {
                blobClient.Setup(r => r.DownloadStreamingAsync(default, default)).ReturnsAsync(downloadResponse);
            }
            else
            {
                blobClient.Setup(r => r.DownloadStreaming(default, default)).Returns(downloadResponse);
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

            // Act
            Segment segment = await segmentFactory.BuildSegment(
                async: IsAsync,
                manifestPath: manifestPath,
                cursor: expectedSegmentCursor);

            SegmentCursor actualSegmentCursor = segment.GetCursor();

            // Assert
            Assert.AreEqual(expectedSegmentCursor.SegmentPath, actualSegmentCursor.SegmentPath);
            Assert.AreEqual(expectedSegmentCursor.ShardCursors.Count, actualSegmentCursor.ShardCursors.Count);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expectedSegmentCursor.ShardCursors[i].BlockOffset, actualSegmentCursor.ShardCursors[i].BlockOffset);
                Assert.AreEqual(expectedSegmentCursor.ShardCursors[i].CurrentChunkPath, actualSegmentCursor.ShardCursors[i].CurrentChunkPath);
                Assert.AreEqual(expectedSegmentCursor.ShardCursors[i].EventIndex, actualSegmentCursor.ShardCursors[i].EventIndex);
            }
            Assert.AreEqual("log/00/2020/03/25/0200/", actualSegmentCursor.CurrentShardPath);

            containerClient.Verify(r => r.GetBlobClient(manifestPath));

            if (IsAsync)
            {
                blobClient.Verify(r => r.DownloadStreamingAsync(default, default));
            }
            else
            {
                blobClient.Verify(r => r.DownloadStreaming(default, default));
            }
        }
    }
}
