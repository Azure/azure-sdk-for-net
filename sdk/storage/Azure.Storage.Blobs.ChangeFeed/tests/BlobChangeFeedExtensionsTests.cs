// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class BlobChangeFeedExtensionsTests : ChangeFeedTestBase
    {
        public BlobChangeFeedExtensionsTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public void ToDateTimeOffsetTests()
        {
            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 17, 0, 0, TimeSpan.Zero),
                BlobChangeFeedExtensions.ToDateTimeOffset("idx/segments/2019/11/02/1700/meta.json"));

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 17, 0, 0, TimeSpan.Zero),
                BlobChangeFeedExtensions.ToDateTimeOffset("idx/segments/2019/11/02/1700/"));

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 17, 0, 0, TimeSpan.Zero),
                BlobChangeFeedExtensions.ToDateTimeOffset("idx/segments/2019/11/02/1700"));

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 0, 0, 0, TimeSpan.Zero),
                BlobChangeFeedExtensions.ToDateTimeOffset("idx/segments/2019/11/02/"));

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 0, 0, 0, TimeSpan.Zero),
                BlobChangeFeedExtensions.ToDateTimeOffset("idx/segments/2019/11/02"));

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 1, 0, 0, 0, TimeSpan.Zero),
                BlobChangeFeedExtensions.ToDateTimeOffset("idx/segments/2019/11/"));

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 1, 0, 0, 0, TimeSpan.Zero),
                BlobChangeFeedExtensions.ToDateTimeOffset("idx/segments/2019/11"));

            Assert.AreEqual(
                new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero),
                BlobChangeFeedExtensions.ToDateTimeOffset("idx/segments/2019/"));

            Assert.AreEqual(
                new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero),
                BlobChangeFeedExtensions.ToDateTimeOffset("idx/segments/2019"));

            Assert.AreEqual(
                null,
                BlobChangeFeedExtensions.ToDateTimeOffset(((string)null)));
        }

        [RecordedTest]
        public void RoundDownToNearestHourTests()
        {
            Assert.AreEqual(
                new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 20, 0, 0, TimeSpan.Zero)),
                (new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 20, 25, 30, TimeSpan.Zero))).RoundDownToNearestHour());

            Assert.AreEqual(
                null,
                ((DateTimeOffset?)null).RoundDownToNearestHour());
        }

        [RecordedTest]
        public void RoundUpToNearestHourTests()
        {
            Assert.AreEqual(
                new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 21, 0, 0, TimeSpan.Zero)),
                (new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 20, 25, 30, TimeSpan.Zero))).RoundUpToNearestHour());

            Assert.AreEqual(
                new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 21, 0, 0, TimeSpan.Zero)),
                (new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 21, 0, 0, TimeSpan.Zero))).RoundUpToNearestHour());

            Assert.AreEqual(
                null,
                ((DateTimeOffset?)null).RoundUpToNearestHour());
        }

        [RecordedTest]
        public void RoundDownToNearestYearTests()
        {
            Assert.AreEqual(
                new DateTimeOffset?(
                    new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                (new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 20, 25, 30, TimeSpan.Zero))).RoundDownToNearestYear());

            Assert.AreEqual(
                null,
                ((DateTimeOffset?)null).RoundDownToNearestYear());
        }

        [RecordedTest]
        public async Task GetSegmentsInYearTest()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>();

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetSegmentsInYearFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.Is<GetBlobsByHierarchyOptions>(
                        r => r.Prefix == "idx/segments/2020/"),
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetSegmentsInYearFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.Is<GetBlobsByHierarchyOptions>(
                        r => r.Prefix == "idx/segments/2020/"),
                    default)).Returns(pageable);
            }

            // Act
            Queue<string> segmentPaths = await BlobChangeFeedExtensions.GetSegmentsInYearInternal(
                containerClient.Object,
                "idx/segments/2020/",
                startTime: new DateTimeOffset(2020, 3, 3, 0, 0, 0, TimeSpan.Zero),
                endTime: new DateTimeOffset(2020, 3, 3, 22, 0, 0, TimeSpan.Zero),
                IsAsync,
                default);

            // Assert
            Queue<string> expectedSegmentPaths = new Queue<string>();
            expectedSegmentPaths.Enqueue("idx/segments/2020/03/03/0000/meta.json");
            expectedSegmentPaths.Enqueue("idx/segments/2020/03/03/1800/meta.json");
            expectedSegmentPaths.Enqueue("idx/segments/2020/03/03/2000/meta.json");
            expectedSegmentPaths.Enqueue("idx/segments/2020/03/03/2200/meta.json");

            Assert.AreEqual(expectedSegmentPaths, segmentPaths);
        }
    }
}
