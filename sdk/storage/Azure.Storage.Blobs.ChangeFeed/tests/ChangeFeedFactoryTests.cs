// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class ChangeFeedFactoryTests : ChangeFeedTestBase
    {
        public ChangeFeedFactoryTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task GetYearPathsTest()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

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

            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>();
            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object, segmentFactory.Object);

            // Act
            Queue<string> years = await changeFeedFactory.GetYearPaths(IsAsync).ConfigureAwait(false);

            // Assert
            Queue<string> expectedYears = new Queue<string>();
            expectedYears.Enqueue("idx/segments/2019/");
            expectedYears.Enqueue("idx/segments/2020/");
            expectedYears.Enqueue("idx/segments/2022/");
            expectedYears.Enqueue("idx/segments/2023/");
            Assert.AreEqual(expectedYears, years);
        }
    }
}
