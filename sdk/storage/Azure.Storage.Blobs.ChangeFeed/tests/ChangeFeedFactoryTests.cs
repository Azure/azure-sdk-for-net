// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class ChangeFeedFactoryTests : ChangeFeedTestBase
    {
        public ChangeFeedFactoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task GetYearPathsTest()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

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

            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>();
            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object, segmentFactory.Object);

            // Act
            Queue<string> years = await changeFeedFactory.GetYearPathsInternal(
                IsAsync,
                default).ConfigureAwait(false);

            // Assert
            Queue<string> expectedYears = new Queue<string>();
            expectedYears.Enqueue("idx/segments/2019/");
            expectedYears.Enqueue("idx/segments/2020/");
            expectedYears.Enqueue("idx/segments/2022/");
            expectedYears.Enqueue("idx/segments/2023/");
            Assert.AreEqual(expectedYears, years);
        }

        [RecordedTest]
        public async Task ChangeFeedEnabledNoMetaSegmentsBlob()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);
            Mock<SegmentFactory> segmentFactory = new Mock<SegmentFactory>(MockBehavior.Strict);
            ChangeFeedFactory changeFeedFactory = new ChangeFeedFactory(
                containerClient.Object,
                segmentFactory.Object);

            if (IsAsync)
            {
                containerClient.Setup(r => r.ExistsAsync(default)).ReturnsAsync(Response.FromValue(true, new MockResponse(200)));
            }
            else
            {
                containerClient.Setup(r => r.Exists(default)).Returns(Response.FromValue(true, new MockResponse(200)));
            }

            Mock<BlobClient> blobClient = new Mock<BlobClient>(MockBehavior.Strict);
            containerClient.Setup(r => r.GetBlobClient(It.IsAny<string>())).Returns(blobClient.Object);

            RequestFailedException ex = new RequestFailedException(
                status: 404,
                message: "The specified blob does not exist.",
                errorCode: BlobErrorCode.BlobNotFound.ToString(),
                innerException: null);

            if (IsAsync)
            {
                blobClient.Setup(r => r.DownloadStreamingAsync(
                    default,
                    CancellationToken.None)).ThrowsAsync(ex);
            }
            else
            {
                blobClient.Setup(r => r.DownloadStreaming(
                    default,
                    CancellationToken.None)).Throws(ex);
            }

            // Act
            ChangeFeed changeFeed = await changeFeedFactory.BuildChangeFeed(
                startTime: null,
                endTime: null,
                continuation: null,
                async: IsAsync,
                cancellationToken: CancellationToken.None);

            // Assert
            Assert.IsFalse(changeFeed.HasNext());

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
                blobClient.Verify(r => r.DownloadStreamingAsync(
                    default,
                    CancellationToken.None));
            }
            else
            {
                blobClient.Verify(r => r.DownloadStreaming(
                    default,
                    CancellationToken.None));
            }
        }
    }
}
