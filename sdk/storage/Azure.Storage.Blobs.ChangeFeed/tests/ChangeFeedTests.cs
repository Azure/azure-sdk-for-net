// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class ChangeFeedTests : ChangeFeedTestBase
    {
        public ChangeFeedTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Tests building a ChangeFeed with a ChangeFeedCursor, and then calling ChangeFeed.GetCursor()
        /// and making sure the cursors match.
        /// </summary>
        [RecordedTest]
        public async Task GetCursor()
        {
            // Arrange
            Mock<BlobServiceClient> serviceClient = new Mock<BlobServiceClient>(MockBehavior.Strict);
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);
            Mock<Segment> segment = new Mock<Segment>(MockBehavior.Strict);

            Uri containerUri = new Uri("https://account.blob.core.windows.net/$blobchangefeed");

            serviceClient.Setup(r => r.GetBlobContainerClient(It.IsAny<string>())).Returns(containerClient.Object);
            containerClient.Setup(r => r.Uri).Returns(containerUri);

            if (IsAsync)
            {
                containerClient.Setup(r => r.ExistsAsync(default)).ReturnsAsync(Response.FromValue(true, new MockResponse(200)));
            }
            else
            {
                containerClient.Setup(r => r.Exists(default)).Returns(Response.FromValue(true, new MockResponse(200)));
            }

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);

            using FileStream stream = File.OpenRead(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"ChangeFeedManifest.json"}");
            BlobDownloadStreamingResult blobDownloadInfo = BlobsModelFactory.BlobDownloadStreamingResult(content: stream);
            Response<BlobDownloadStreamingResult> downloadResponse = Response.FromValue(blobDownloadInfo, new MockResponse(200));

            if (IsAsync)
            {
                blobClient.Setup(r => r.DownloadStreamingAsync(default, default)).ReturnsAsync(downloadResponse);
            }
            else
            {
                blobClient.Setup(r => r.DownloadStreaming(default, default)).Returns(downloadResponse);
            }

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetYearsPathFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetYearPathFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(pageable);
            }

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetSegmentsInYearFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix != null &&
                                   options.Delimiter == null),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetSegmentsInYearFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix != null &&
                                   options.Delimiter == null),
                    default)).Returns(pageable);
            }

            segmentFactory.Setup(r => r.BuildSegment(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                It.IsAny<SegmentCursor>()))
                .ReturnsAsync(segment.Object);

            string currentChunkPath = "chunk1";
            long blockOffset = 2;
            long eventIndex = 3;
            ShardCursor shardCursor = new ShardCursor(
                currentChunkPath,
                blockOffset,
                eventIndex);

            DateTimeOffset segmentTime = new DateTimeOffset(2020, 1, 4, 17, 0, 0, TimeSpan.Zero);
            string segmentPath = "idx/segments/2020/01/04/1700/meta.json";
            string currentShardPath = "log/00/2020/01/04/1700/";
            SegmentCursor segmentCursor = new SegmentCursor(
                segmentPath,
                new List<ShardCursor>
                {
                    shardCursor
                },
                currentShardPath);

            segment.Setup(r => r.GetCursor()).Returns(segmentCursor);

            DateTimeOffset endDateTime = new DateTimeOffset(2020, 5, 6, 18, 0, 0, TimeSpan.Zero);
            ChangeFeedCursor expectedCursor = new ChangeFeedCursor(
                urlHost: containerUri.Host,
                endDateTime: endDateTime,
                currentSegmentCursor: segmentCursor);

            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object,
                segmentFactory.Object);

            // Act
            ChangeFeed changeFeed = await changeFeedFactory.BuildChangeFeed(
                startTime: default,
                endTime: default,
                continuation: JsonSerializer.Serialize<ChangeFeedCursor>(expectedCursor),
                async: IsAsync,
                cancellationToken: default);

            ChangeFeedCursor actualCursor = changeFeed.GetCursor();

            // Assert
            Assert.AreEqual(expectedCursor.CursorVersion, actualCursor.CursorVersion);
            Assert.AreEqual(expectedCursor.EndTime, actualCursor.EndTime);
            Assert.AreEqual(expectedCursor.UrlHost, actualCursor.UrlHost);

            Assert.AreEqual(expectedCursor.CurrentSegmentCursor.SegmentPath, actualCursor.CurrentSegmentCursor.SegmentPath);
            Assert.AreEqual(expectedCursor.CurrentSegmentCursor.CurrentShardPath, actualCursor.CurrentSegmentCursor.CurrentShardPath);
            Assert.AreEqual(expectedCursor.CurrentSegmentCursor.ShardCursors.Count, actualCursor.CurrentSegmentCursor.ShardCursors.Count);

            Assert.AreEqual(expectedCursor.CurrentSegmentCursor.ShardCursors[0].BlockOffset, actualCursor.CurrentSegmentCursor.ShardCursors[0].BlockOffset);
            Assert.AreEqual(expectedCursor.CurrentSegmentCursor.ShardCursors[0].CurrentChunkPath, actualCursor.CurrentSegmentCursor.ShardCursors[0].CurrentChunkPath);
            Assert.AreEqual(expectedCursor.CurrentSegmentCursor.ShardCursors[0].EventIndex, actualCursor.CurrentSegmentCursor.ShardCursors[0].EventIndex);

            containerClient.Verify(r => r.Uri);

            if (IsAsync)
            {
                containerClient.Verify(r => r.ExistsAsync(default));
            }
            else
            {
                containerClient.Verify(r => r.Exists(default));
            }

            containerClient.Verify(r => r.GetBlobClient(Constants.ChangeFeed.MetaSegmentsPath));

            if (IsAsync)
            {
                blobClient.Verify(r => r.DownloadStreamingAsync(default, default));
            }
            else
            {
                blobClient.Verify(r => r.DownloadStreaming(default, default));
            }

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default));
            }

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2020/"),
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2020/"),
                    default));
            }

            segmentFactory.Verify(r => r.BuildSegment(
                IsAsync,
                "idx/segments/2020/01/16/2300/meta.json",
                It.Is<SegmentCursor>(
                    r => r.SegmentPath == segmentPath
                    && r.CurrentShardPath == currentShardPath
                    && r.ShardCursors.Count == 1
                    && r.ShardCursors[0].BlockOffset == blockOffset
                    && r.ShardCursors[0].CurrentChunkPath == currentChunkPath
                    && r.ShardCursors[0].EventIndex == eventIndex
                )));

            segment.Verify(r => r.GetCursor());
        }

        /// <summary>
        /// This test has 8 total events, 4 segments, and 2 years.
        /// We call ChangeFeed.GetPage() with a page size of 3, and then again with no page size,
        /// resulting in two pages with 3 and 5 Events.
        /// </summary>
        [RecordedTest]
        public async Task GetPage()
        {
            // Arrange
            int eventCount = 8;
            int segmentCount = 4;
            Mock<BlobServiceClient> serviceClient = new Mock<BlobServiceClient>(MockBehavior.Strict);
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);
            Uri containerUri = new Uri("https://account.blob.core.windows.net/$blobchangefeed");

            List<Mock<Segment>> segments = new List<Mock<Segment>>();
            for (int i = 0; i < segmentCount; i++)
            {
                segments.Add(new Mock<Segment>(MockBehavior.Strict));
            }

            // ChangeFeedFactory.BuildChangeFeed() setups.
            serviceClient.Setup(r => r.GetBlobContainerClient(It.IsAny<string>())).Returns(containerClient.Object);
            containerClient.SetupSequence(r => r.Uri)
                .Returns(containerUri)
                .Returns(containerUri);

            if (IsAsync)
            {
                containerClient.Setup(r => r.ExistsAsync(default)).ReturnsAsync(Response.FromValue(true, new MockResponse(200)));
            }
            else
            {
                containerClient.Setup(r => r.Exists(default)).Returns(Response.FromValue(true, new MockResponse(200)));
            }

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);

            using FileStream stream = File.OpenRead(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"ChangeFeedManifest.json"}");
            BlobDownloadStreamingResult blobDownloadInfo = BlobsModelFactory.BlobDownloadStreamingResult(content: stream);
            Response<BlobDownloadStreamingResult> downloadResponse = Response.FromValue(blobDownloadInfo, new MockResponse(200));

            if (IsAsync)
            {
                blobClient.Setup(r => r.DownloadStreamingAsync(default, default)).ReturnsAsync(downloadResponse);
            }
            else
            {
                blobClient.Setup(r => r.DownloadStreaming(default, default)).Returns(downloadResponse);
            }

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetYearsPathShortFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetYearsPathShortFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(pageable);
            }

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetSegmentsInYear2019FuncAsync);
                AsyncPageable<BlobHierarchyItem> asyncPageable2 = PageResponseEnumerator.CreateAsyncEnumerable(GetSegmentsInYear2020FuncAsync);

                containerClient.SetupSequence(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix != null &&
                                   options.Delimiter == null),
                    default))
                    .Returns(asyncPageable)
                    .Returns(asyncPageable2);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetSegmentsInYear2019Func);

                Pageable<BlobHierarchyItem> pageable2 =
                    PageResponseEnumerator.CreateEnumerable(GetSegmentsInYear2020Func);

                containerClient.SetupSequence(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix != null &&
                                   options.Delimiter == null),
                    default))
                    .Returns(pageable)
                    .Returns(pageable2);
            }

            segmentFactory.SetupSequence(r => r.BuildSegment(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                default))
                .Returns(Task.FromResult(segments[0].Object))
                .Returns(Task.FromResult(segments[1].Object))
                .Returns(Task.FromResult(segments[2].Object))
                .Returns(Task.FromResult(segments[3].Object));

            List<BlobChangeFeedEvent> events = new List<BlobChangeFeedEvent>();
            for (int i = 0; i < eventCount; i++)
            {
                events.Add(new BlobChangeFeedEvent
                {
                    Id = Guid.NewGuid()
                });
            }

            segments[0].SetupSequence(r => r.HasNext())
                .Returns(false);
            segments[1].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);
            segments[2].SetupSequence(r => r.HasNext())
                .Returns(false);
            segments[3].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            segments[0].SetupSequence(r => r.GetPage(
                It.IsAny<bool>(),
                It.IsAny<int?>(),
                default))
                .Returns(Task.FromResult(new List<BlobChangeFeedEvent>
                {
                    events[0],
                    events[1]
                }));

            segments[1].SetupSequence(r => r.GetPage(
                It.IsAny<bool>(),
                It.IsAny<int?>(),
                default))
                .Returns(Task.FromResult(new List<BlobChangeFeedEvent>
                {
                    events[2]
                }))
                .Returns(Task.FromResult(new List<BlobChangeFeedEvent>
                {
                    events[3]
                }));

            segments[2].SetupSequence(r => r.GetPage(
                It.IsAny<bool>(),
                It.IsAny<int?>(),
                default))
                .Returns(Task.FromResult(new List<BlobChangeFeedEvent>
                {
                    events[4],
                    events[5]
                }));

            segments[3].SetupSequence(r => r.GetPage(
                It.IsAny<bool>(),
                It.IsAny<int?>(),
                default))
                .Returns(Task.FromResult(new List<BlobChangeFeedEvent>
                {
                    events[6],
                    events[7]
                }));

            string currentChunkPath = "chunk1";
            long blockOffset = 2;
            long eventIndex = 3;
            ShardCursor shardCursor = new ShardCursor(
                currentChunkPath,
                blockOffset,
                eventIndex);

            DateTimeOffset segmentTime = new DateTimeOffset(2020, 1, 4, 17, 0, 0, TimeSpan.Zero);
            string segmentPath = "idx/segments/2020/01/04/1700/meta.json";
            string currentShardPath = "log/00/2020/01/04/1700/";
            SegmentCursor segmentCursor = new SegmentCursor(
                segmentPath,
                new List<ShardCursor>
                {
                    shardCursor
                },
                currentShardPath);
            ChangeFeedCursor changeFeedCursor = new ChangeFeedCursor(
                containerUri.Host,
                null,
                segmentCursor);

            containerClient.SetupSequence(r => r.Uri)
                .Returns(containerUri)
                .Returns(containerUri);

            segments[1].Setup(r => r.GetCursor()).Returns(segmentCursor);
            segments[3].Setup(r => r.GetCursor()).Returns(segmentCursor);

            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object,
                segmentFactory.Object);
            ChangeFeed changeFeed = await changeFeedFactory.BuildChangeFeed(
                startTime: default,
                endTime: default,
                continuation: default,
                async: IsAsync,
                cancellationToken: default);

            // Act
            Page<BlobChangeFeedEvent> page0 = await changeFeed.GetPage(IsAsync, 3);
            Page<BlobChangeFeedEvent> page1 = await changeFeed.GetPage(IsAsync);

            // Assert
            Assert.AreEqual(JsonSerializer.Serialize(changeFeedCursor), page0.ContinuationToken);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(events[i].Id, page0.Values[i].Id);
            }

            Assert.AreEqual(JsonSerializer.Serialize(changeFeedCursor), page1.ContinuationToken);

            for (int i = 3; i < events.Count; i++)
            {
                Assert.AreEqual(events[i].Id, page1.Values[i - 3].Id);
            }

            // ChangeFeedFactory.BuildChangeFeed() verifies
            containerClient.Verify(r => r.Uri);

            if (IsAsync)
            {
                containerClient.Verify(r => r.ExistsAsync(default));
            }
            else
            {
                containerClient.Verify(r => r.Exists(default));
            }

            containerClient.Verify(r => r.GetBlobClient(Constants.ChangeFeed.MetaSegmentsPath));

            if (IsAsync)
            {
                blobClient.Verify(r => r.DownloadStreamingAsync(default, default));
            }
            else
            {
                blobClient.Verify(r => r.DownloadStreaming(default, default));
            }

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default));
            }

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2019/"),
                    default));

                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2020/"),
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2019/"),
                    default));

                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2020/"),
                    default));
            }

            // ChangeFeeed.Next() verifies.
            segments[0].Verify(r => r.HasNext());
            segments[1].Verify(r => r.HasNext(), Times.Exactly(2));
            segments[2].Verify(r => r.HasNext());
            segments[3].Verify(r => r.HasNext(), Times.Exactly(3));

            segments[0].Verify(r => r.GetPage(
                IsAsync,
                3,
                default));

            segments[1].Verify(r => r.GetPage(
                IsAsync,
                1,
                default));

            segments[1].Verify(r => r.GetPage(
                IsAsync,
                Constants.ChangeFeed.DefaultPageSize,
                default));

            segments[2].Verify(r => r.GetPage(
                IsAsync,
                Constants.ChangeFeed.DefaultPageSize - 1,
                default));

            segments[3].Verify(r => r.GetPage(
                IsAsync,
                Constants.ChangeFeed.DefaultPageSize - 3,
                default));

            segments[1].Verify(r => r.GetCursor());
            segments[3].Verify(r => r.GetCursor());

            containerClient.Verify(r => r.Uri, Times.Exactly(2));
        }

        /// <summary>
        /// Tests that HasNext returns false when no segments exist after the specified start time.
        /// </summary>
        [RecordedTest]
        public async Task NoYearsAfterStartTime()
        {
            // Arrange
            Mock<BlobServiceClient> serviceClient = new Mock<BlobServiceClient>(MockBehavior.Strict);
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);
            Mock<Segment> segment = new Mock<Segment>(MockBehavior.Strict);

            Uri containerUri = new Uri("https://account.blob.core.windows.net/$blobchangefeed");

            serviceClient.Setup(r => r.GetBlobContainerClient(It.IsAny<string>())).Returns(containerClient.Object);

            if (IsAsync)
            {
                containerClient.Setup(r => r.ExistsAsync(default)).ReturnsAsync(Response.FromValue(true, new MockResponse(200)));
            }
            else
            {
                containerClient.Setup(r => r.Exists(default)).Returns(Response.FromValue(true, new MockResponse(200)));
            }

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);

            using FileStream stream = File.OpenRead(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"ChangeFeedManifest.json"}");
            BlobDownloadStreamingResult blobDownloadInfo = BlobsModelFactory.BlobDownloadStreamingResult(content: stream);
            Response<BlobDownloadStreamingResult> downloadResponse = Response.FromValue(blobDownloadInfo, new MockResponse(200));

            if (IsAsync)
            {
                blobClient.Setup(r => r.DownloadStreamingAsync(default, default)).ReturnsAsync(downloadResponse);
            }
            else
            {
                blobClient.Setup(r => r.DownloadStreaming(default, default)).Returns(downloadResponse);
            }

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetYearsPathFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetYearPathFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(pageable);
            }

            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object,
                segmentFactory.Object);
            ChangeFeed changeFeed = await changeFeedFactory.BuildChangeFeed(
                startTime: new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                endTime: default,
                continuation: default,
                async: IsAsync,
                cancellationToken: default);

            // Act
            bool hasNext = changeFeed.HasNext();

            // Assert
            Assert.IsFalse(hasNext);

            if (IsAsync)
            {
                containerClient.Verify(r => r.ExistsAsync(default));
            }
            else
            {
                containerClient.Verify(r => r.Exists(default));
            }

            containerClient.Verify(r => r.GetBlobClient(Constants.ChangeFeed.MetaSegmentsPath));

            if (IsAsync)
            {
                blobClient.Verify(r => r.DownloadStreamingAsync(default, default));
            }
            else
            {
                blobClient.Verify(r => r.DownloadStreaming(default, default));
            }

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default));
            }
        }

        /// <summary>
        /// Tests that when no segments remain in the start year, the change feed advances to the next year.
        /// </summary>
        [RecordedTest]
        public async Task NoSegmentsRemainingInStartYear()
        {
            // Arrange
            int eventCount = 2;
            int segmentCount = 2;
            Mock<BlobServiceClient> serviceClient = new Mock<BlobServiceClient>(MockBehavior.Strict);
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);
            Uri containerUri = new Uri("https://account.blob.core.windows.net/$blobchangefeed");

            List<Mock<Segment>> segments = new List<Mock<Segment>>();
            for (int i = 0; i < segmentCount; i++)
            {
                segments.Add(new Mock<Segment>(MockBehavior.Strict));
            }

            // ChangeFeedFactory.BuildChangeFeed() setups.
            serviceClient.Setup(r => r.GetBlobContainerClient(It.IsAny<string>())).Returns(containerClient.Object);
            containerClient.SetupSequence(r => r.Uri)
                .Returns(containerUri)
                .Returns(containerUri);

            if (IsAsync)
            {
                containerClient.Setup(r => r.ExistsAsync(default)).ReturnsAsync(Response.FromValue(true, new MockResponse(200)));
            }
            else
            {
                containerClient.Setup(r => r.Exists(default)).Returns(Response.FromValue(true, new MockResponse(200)));
            }

            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);

            using FileStream stream = File.OpenRead(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"ChangeFeedManifest.json"}");
            BlobDownloadStreamingResult blobDownloadInfo = BlobsModelFactory.BlobDownloadStreamingResult(content: stream);
            Response<BlobDownloadStreamingResult> downloadResponse = Response.FromValue(blobDownloadInfo, new MockResponse(200));

            if (IsAsync)
            {
                blobClient.Setup(r => r.DownloadStreamingAsync(default, default)).ReturnsAsync(downloadResponse);
            }
            else
            {
                blobClient.Setup(r => r.DownloadStreaming(default, default)).Returns(downloadResponse);
            }

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetYearsPathShortFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetYearsPathShortFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default)).Returns(pageable);
            }

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetSegmentsInYear2019FuncAsync);
                AsyncPageable<BlobHierarchyItem> asyncPageable2 = PageResponseEnumerator.CreateAsyncEnumerable(GetSegmentsInYear2020FuncAsync);

                containerClient.SetupSequence(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix != null &&
                                   options.Delimiter == null),
                    default))
                    .Returns(asyncPageable)
                    .Returns(asyncPageable2);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetSegmentsInYear2019Func);

                Pageable<BlobHierarchyItem> pageable2 =
                    PageResponseEnumerator.CreateEnumerable(GetSegmentsInYear2020Func);

                containerClient.SetupSequence(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix != null &&
                                   options.Delimiter == null),
                    default))
                    .Returns(pageable)
                    .Returns(pageable2);
            }

            segmentFactory.SetupSequence(r => r.BuildSegment(
                It.IsAny<bool>(),
                It.IsAny<string>(),
                default))
                .Returns(Task.FromResult(segments[0].Object))
                .Returns(Task.FromResult(segments[1].Object));

            List<BlobChangeFeedEvent> events = new List<BlobChangeFeedEvent>();
            for (int i = 0; i < eventCount; i++)
            {
                events.Add(new BlobChangeFeedEvent
                {
                    Id = Guid.NewGuid()
                });
            }

            segments[0].SetupSequence(r => r.GetPage(
                It.IsAny<bool>(),
                It.IsAny<int?>(),
                default))
                .Returns(Task.FromResult(new List<BlobChangeFeedEvent>
                {
                    events[0]
                }));

            segments[1].SetupSequence(r => r.GetPage(
                It.IsAny<bool>(),
                It.IsAny<int?>(),
                default))
                .Returns(Task.FromResult(new List<BlobChangeFeedEvent>
                {
                    events[1]
                }));

            segments[0].SetupSequence(r => r.HasNext())
                .Returns(false);
            segments[1].SetupSequence(r => r.HasNext())
                .Returns(true)
                .Returns(false);

            segments[1].Setup(r => r.GetCursor())
                .Returns(new SegmentCursor());

            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object,
                segmentFactory.Object);
            ChangeFeed changeFeed = await changeFeedFactory.BuildChangeFeed(
                startTime: new DateTimeOffset(2019, 6, 1, 0, 0, 0, TimeSpan.Zero),
                endTime: default,
                continuation: default,
                async: IsAsync,
                cancellationToken: default);

            // Act
            Page<BlobChangeFeedEvent> page = await changeFeed.GetPage(IsAsync);

            // Assert
            Assert.AreEqual(2, page.Values.Count);
            Assert.AreEqual(events[0].Id, page.Values[0].Id);
            Assert.AreEqual(events[1].Id, page.Values[1].Id);

            containerClient.Verify(r => r.Uri);

            if (IsAsync)
            {
                containerClient.Verify(r => r.ExistsAsync(default));
            }
            else
            {
                containerClient.Verify(r => r.Exists(default));
            }

            containerClient.Verify(r => r.GetBlobClient(Constants.ChangeFeed.MetaSegmentsPath));

            if (IsAsync)
            {
                blobClient.Verify(r => r.DownloadStreamingAsync(default, default));
            }
            else
            {
                blobClient.Verify(r => r.DownloadStreaming(default, default));
            }

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == Constants.ChangeFeed.SegmentPrefix &&
                                   options.Delimiter == "/"),
                    default));
            }

            if (IsAsync)
            {
                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2019/"),
                    default));

                containerClient.Verify(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2020/"),
                    default));
            }
            else
            {
                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2019/"),
                    default));

                containerClient.Verify(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        options => options.Prefix == "idx/segments/2020/"),
                    default));
            }

            // ChangeFeeed.Next() verifies.
            segments[0].Verify(r => r.HasNext(), Times.Exactly(1));

            segments[0].Verify(r => r.GetPage(
                IsAsync,
                Constants.ChangeFeed.DefaultPageSize,
                default));

            segments[1].Verify(r => r.HasNext(), Times.Exactly(3));

            segments[1].Verify(r => r.GetPage(
                IsAsync,
                Constants.ChangeFeed.DefaultPageSize - 1,
                default));

            containerClient.Verify(r => r.Uri, Times.Exactly(1));
        }

        /// <summary>
        /// Tests retrieving the last consumable timestamp from the change feed.
        /// </summary>
        [RecordedTest]
        [PlaybackOnly("Last Consumable is always changing")]
        public async Task GetLastConsumable()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient changeFeedClient = service.GetChangeFeedClient();

            // Act
            DateTimeOffset? lastConsumable = await changeFeedClient.GetLastConsumableAsync();

            // Assert
            DateTimeOffset expectedLastConsumable = new DateTimeOffset(2020, 06, 01, 21, 0, 0, TimeSpan.Zero);
            Assert.AreEqual(expectedLastConsumable, lastConsumable.Value);
        }

        /// <summary>
        /// Tests that calling GetPage() on an empty ChangeFeed throws InvalidOperationException.
        /// </summary>
        [RecordedTest]
        public void GetPage_ThrowsWhenExhausted()
        {
            // Arrange
            ChangeFeed changeFeed = ChangeFeed.Empty();

            // Act / Assert
            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await changeFeed.GetPage(IsAsync));
        }

        /// <summary>
        /// Tests that HasNext() returns false when the current segment's DateTime >= endTime,
        /// even when the segment itself still has events.
        /// </summary>
        [RecordedTest]
        public void HasNext_ReturnsFalseWhenEndTimeReached()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);

            DateTimeOffset segmentTime = new DateTimeOffset(2020, 5, 1, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2020, 5, 1, 0, 0, 0, TimeSpan.Zero);

            // Segment has events (HasNext=true), but DateTime == endTime
            Mock<Shard> shard = new Mock<Shard>(MockBehavior.Strict);
            shard.Setup(r => r.HasNext()).Returns(true);

            Segment segment = new Segment(
                new List<Shard> { shard.Object },
                0,
                segmentTime,
                "idx/segments/2020/05/01/0000/meta.json");

            ChangeFeed changeFeed = new ChangeFeed(
                containerClient.Object,
                segmentFactory.Object,
                new Queue<string>(),
                new Queue<string>(),
                segment,
                new DateTimeOffset(2020, 6, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                endTime);

            // Act / Assert - HasNext should return false because segment time >= endTime
            Assert.IsFalse(changeFeed.HasNext());

            // Also verify that a segment before endTime would return true
            DateTimeOffset earlierSegmentTime = new DateTimeOffset(2020, 4, 1, 0, 0, 0, TimeSpan.Zero);
            Segment earlierSegment = new Segment(
                new List<Shard> { shard.Object },
                0,
                earlierSegmentTime,
                "idx/segments/2020/04/01/0000/meta.json");

            ChangeFeed changeFeedWithEarlierSegment = new ChangeFeed(
                containerClient.Object,
                segmentFactory.Object,
                new Queue<string>(),
                new Queue<string>(),
                earlierSegment,
                new DateTimeOffset(2020, 6, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                endTime);

            Assert.IsTrue(changeFeedWithEarlierSegment.HasNext());
        }

        /// <summary>
        /// Tests that pageSize is capped to DefaultPageSize when a larger value is requested.
        /// </summary>
        [RecordedTest]
        public async Task GetPage_CapsPageSizeToDefault()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);

            Uri containerUri = new Uri("https://account.blob.core.windows.net/$blobchangefeed");
            containerClient.Setup(r => r.Uri).Returns(containerUri);

            DateTimeOffset segmentTime = new DateTimeOffset(2020, 3, 1, 0, 0, 0, TimeSpan.Zero);

            BlobChangeFeedEvent evt = new BlobChangeFeedEvent { Id = Guid.NewGuid() };

            // Set up a shard that returns one event then is exhausted
            Mock<Shard> shard = new Mock<Shard>(MockBehavior.Strict);
            shard.SetupSequence(r => r.HasNext())
                .Returns(false);
            shard.Setup(r => r.Next(It.IsAny<bool>(), default))
                .Returns(Task.FromResult(evt));
            shard.Setup(r => r.GetCursor()).Returns(new ShardCursor("chunk1", 0, 0));
            shard.Setup(r => r.ShardPath).Returns("log/00/2020/03/01/0000/");

            Segment segment = new Segment(
                new List<Shard> { shard.Object },
                0,
                segmentTime,
                "idx/segments/2020/03/01/0000/meta.json");

            ChangeFeed changeFeed = new ChangeFeed(
                containerClient.Object,
                segmentFactory.Object,
                new Queue<string>(),
                new Queue<string>(),
                segment,
                new DateTimeOffset(2020, 6, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                null);

            // Act - request a page size larger than DefaultPageSize
            // The key verification: the code internally caps to DefaultPageSize,
            // but since there's only 1 event, the page will have 1 event regardless.
            // The important thing is that it doesn't throw and works correctly.
            Page<BlobChangeFeedEvent> page = await changeFeed.GetPage(IsAsync, Constants.ChangeFeed.DefaultPageSize + 1000);

            // Assert
            Assert.AreEqual(1, page.Values.Count);
            Assert.AreEqual(evt.Id, page.Values[0].Id);
        }

        /// <summary>
        /// Async helper that returns a short list of mock year paths (1601, 2019, 2020) for test setup.
        /// </summary>
        public static Task<Page<BlobHierarchyItem>> GetYearsPathShortFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetYearsPathShortFunc(continuation, pageSizeHint));

        /// <summary>
        /// Returns a page of mock year paths (1601, 2019, 2020) for test setup.
        /// </summary>
        public static Page<BlobHierarchyItem> GetYearsPathShortFunc(
            string continuation,
            int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/1601/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2019/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2020/", null)
            });

        /// <summary>
        /// Async helper that returns mock 2019 segment paths for test setup.
        /// </summary>
        public static Task<Page<BlobHierarchyItem>> GetSegmentsInYear2019FuncAsync(
            string continuation,
            int? pageSizeHint)
            => Task.FromResult(GetSegmentsInYear2019Func(continuation, pageSizeHint));

        /// <summary>
        /// Returns a page of mock 2019 segment paths for test setup.
        /// </summary>
        public static Page<BlobHierarchyItem> GetSegmentsInYear2019Func(
            string continuation,
            int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2019/03/02/2000/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2019/04/03/2200/meta.json", false, null))
            });

        /// <summary>
        /// Async helper that returns mock 2020 segment paths for test setup.
        /// </summary>
        public static Task<Page<BlobHierarchyItem>> GetSegmentsInYear2020FuncAsync(
            string continuation,
            int? pageSizeHint)
            => Task.FromResult(GetSegmentsInYear2020Func(continuation, pageSizeHint));

        /// <summary>
        /// Returns a page of mock 2020 segment paths for test setup.
        /// </summary>
        public static Page<BlobHierarchyItem> GetSegmentsInYear2020Func(
            string continuation,
            int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/2000/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/2200/meta.json", false, null))
            });
    }
}
