// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class ChangeFeedTests : ChangeFeedTestBase
    {
        public ChangeFeedTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task GetYearPathsTest()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>();
            ChangeFeed changeFeed = new ChangeFeed(containerClient.Object);

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetYearsPathFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    "/",
                    Constants.ChangeFeed.SegmentPrefix,
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetYearPathFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    "/",
                    Constants.ChangeFeed.SegmentPrefix,
                    default)).Returns(pageable);
            }

            // Act
            Queue<string> years = await changeFeed.GetYearPaths(IsAsync).ConfigureAwait(false);

            // Assert
            Queue<string> expectedYears = new Queue<string>();
            expectedYears.Enqueue("idx/segments/2019/");
            expectedYears.Enqueue("idx/segments/2020/");
            expectedYears.Enqueue("idx/segments/2022/");
            expectedYears.Enqueue("idx/segments/2023/");
            Assert.AreEqual(expectedYears, years);

        }

        private static Task<Page<BlobHierarchyItem>> GetYearsPathFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetYearPathFunc(continuation, pageSizeHint));

        private static Page<BlobHierarchyItem> GetYearPathFunc(
            string continuation,
            int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/1601/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2019/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2020/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2022/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2023/", null),
            });

        [Test]
        public async Task GetSegmentsInYearTest()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>();
            ChangeFeed changeFeed = new ChangeFeed(containerClient.Object);

            if (IsAsync)
            {
                AsyncPageable<BlobHierarchyItem> asyncPageable = PageResponseEnumerator.CreateAsyncEnumerable(GetSegmentsInYearFuncAsync);

                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    default,
                    default,
                    default,
                    "idx/segments/2020/",
                    default)).Returns(asyncPageable);
            }
            else
            {
                Pageable<BlobHierarchyItem> pageable =
                    PageResponseEnumerator.CreateEnumerable(GetSegmentsInYearFunc);

                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    default,
                    default,
                    default,
                    "idx/segments/2020/",
                    default)).Returns(pageable);
            }

            // Act
            Queue<string> segmentPaths = await changeFeed.GetSegmentsInYear(
                IsAsync,
                "idx/segments/2020/",
                startTime: new DateTimeOffset(2020, 3, 3, 0, 0, 0, TimeSpan.Zero),
                endTime: new DateTimeOffset(2020, 3, 3, 22, 0 , 0, TimeSpan.Zero));

            // Assert
            Queue<string> expectedSegmentPaths = new Queue<string>();
            expectedSegmentPaths.Enqueue("idx/segments/2020/03/03/0000/meta.json");
            expectedSegmentPaths.Enqueue("idx/segments/2020/03/03/1800/meta.json");
            expectedSegmentPaths.Enqueue("idx/segments/2020/03/03/2000/meta.json");
            expectedSegmentPaths.Enqueue("idx/segments/2020/03/03/2200/meta.json");

            Assert.AreEqual(expectedSegmentPaths, segmentPaths);
        }

        private static Task<Page<BlobHierarchyItem>> GetSegmentsInYearFuncAsync(
            string continuation,
            int? pageSizeHint)
            => Task.FromResult(GetSegmentsInYearFunc(continuation, pageSizeHint));

        private static Page<BlobHierarchyItem> GetSegmentsInYearFunc(
            string continuation,
            int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/01/16/2300/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/02/2300/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/0000/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/1800/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/2000/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/2200/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/05/1700/meta.json", false, null)),
            });
    }
}
