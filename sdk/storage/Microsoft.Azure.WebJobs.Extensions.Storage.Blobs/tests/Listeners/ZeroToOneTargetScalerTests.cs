// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners.ZeroToOneTargetScalerProvider;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests.Listeners
{
    public class ZeroToOneTargetScalerTests
    {
        public ZeroToOneTargetScalerTests()
        {
        }

        [Test]
        [TestCase("Sample log content", 10, "sc-test-blobs/basic", 0, 0)]
        [TestCase("1.0;Timestamp='';PutBlob;Success;201;6;6;authenticated;teststorage;teststorage;blob;\"https://teststorage.blob.core.windows.net:443/test-blobs/basic%5Ctest.txt\";\"/teststorage/test-blobs/basic/test.txt\";612fc70e-e01e-008e-507f-3defe5000000;0;172.185.1.166:36700;2025-01-05;545;9;337;0;9;;\"HlAhCgICSX+3m8OLat5sNA==\";\"&quot;0x8DE0B970756F5CF&quot;\";Wednesday, 15-Oct-25 03:00:42 GMT;\"If-None-Match=*\";\"azsdk-net-Storage.Blobs/12.23.0 (.NET 8.0.21; Microsoft Windows 10.0.17763)\";;\"0ec36b75-69d3-453f-afd3-a329e0970962\"\r\n1.0;",
            10, "test-blobs/basic", 1, 1)]
        [TestCase("1.0;Timestamp='';PutBlob;Success;201;6;6;authenticated;teststorage;teststorage;blob;\"https://teststorage.blob.core.windows.net:443/test-blobs/basic%5Ctest.txt\";\"/teststorage/test-blobs/basic/test.txt\";612fc70e-e01e-008e-507f-3defe5000000;0;172.185.1.166:36700;2025-01-05;545;9;337;0;9;;\"HlAhCgICSX+3m8OLat5sNA==\";\"&quot;0x8DE0B970756F5CF&quot;\";Wednesday, 15-Oct-25 03:00:42 GMT;\"If-None-Match=*\";\"azsdk-net-Storage.Blobs/12.23.0 (.NET 8.0.21; Microsoft Windows 10.0.17763)\";;\"0ec36b75-69d3-453f-afd3-a329e0970962\"\r\n1.0;",
            180, "test-blobs/basic", 1, 0)]
        [TestCase("1.0;Timestamp='';PutBlob;Success;201;6;6;authenticated;teststorage;teststorage;blob;\"https://teststorage.blob.core.windows.net:443/test-blobs/basic%5Ctest.txt\";\"/teststorage/test-blobs/basic/test.txt\";612fc70e-e01e-008e-507f-3defe5000000;0;172.185.1.166:36700;2025-01-05;545;9;337;0;9;;\"HlAhCgICSX+3m8OLat5sNA==\";\"&quot;0x8DE0B970756F5CF&quot;\";Wednesday, 15-Oct-25 03:00:42 GMT;\"If-None-Match=*\";\"azsdk-net-Storage.Blobs/12.23.0 (.NET 8.0.21; Microsoft Windows 10.0.17763)\";;\"0ec36b75-69d3-453f-afd3-a329e0970962\"\r\n1.0;",
            10, "test-blobs1/basic", 0, 0)]
        public async Task GetScaleResultAsync_WorkAsExpected(string logBlobContent, int offsetInMinutes, string blobPath, int expectedTargetWorkerCount, int excpectedChachReads)
        {
            string timeStamp = $"{DateTime.UtcNow.AddMinutes(-offsetInMinutes):o}";
            logBlobContent = logBlobContent.Replace("Timestamp=''", timeStamp);

            var mockBlobContainerClient = new Mock<BlobContainerClient>();
            var page = Page<BlobItem>.FromValues(
                values: new BlobItem[] { CreateBlobItem() },
                continuationToken: null,
                response: Mock.Of<Response>());

            mockBlobContainerClient
                .Setup(b => b.GetBlobsAsync(
                    It.IsAny<BlobTraits>(),
                    It.IsAny<BlobStates>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(AsyncPageable<BlobItem>.FromPages(new[] { page }));

            mockBlobContainerClient.Setup(b => b.GetBlobClient(It.IsAny<string>()))
                .Returns(CreateBlobClient(logBlobContent));

            var mockBlobServiceClient = new Mock<BlobServiceClient>();
            mockBlobServiceClient.Setup(b => b.GetPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(Response.FromValue(new BlobServiceProperties()
                {
                    Logging = new BlobAnalyticsLogging() { Write = true }
                }, Mock.Of<Response>()));
            mockBlobServiceClient.Setup(b => b.GetBlobContainerClient(It.IsAny<string>()))
                .Returns(mockBlobContainerClient.Object);

            var loggerProvider = new TestLoggerProvider();
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(loggerProvider);

            var scaler = new ZeroToOneTargetScaler("TestFunction", mockBlobServiceClient.Object, blobPath, loggerFactory);

            var result = await scaler.GetScaleResultAsync(new TargetScalerContext());

            Assert.NotNull(result);
            Assert.AreEqual(expectedTargetWorkerCount, result.TargetWorkerCount);

            result = await scaler.GetScaleResultAsync(new TargetScalerContext());

            var cacheReads = loggerProvider.GetAllLogMessages().Where(x => x.FormattedMessage.Contains("Recent writes were detected from cache for ")).Count();
            Assert.AreEqual(excpectedChachReads, cacheReads);

            Assert.NotNull(result);
            Assert.AreEqual(expectedTargetWorkerCount, result.TargetWorkerCount);
        }

        private BlobItem CreateBlobItem()
        {
            BlobItem blobItem = BlobsModelFactory.BlobItem(
                name: Guid.NewGuid().ToString(),
                metadata: new System.Collections.Generic.Dictionary<string, string>()
                {
                    { "LogType", "write" }
                },
                properties: BlobsModelFactory.BlobItemProperties(
                    accessTierInferred: true,
                    contentLength: 1024,
                    blobType: BlobType.Block,
                    eTag: new ETag("etag")));

            return blobItem;
        }

        private BlobClient CreateBlobClient(string logBlobContent)
        {
            var mockBlobClient = new Mock<BlobClient>();
            mockBlobClient
                .Setup(b => b.OpenReadAsync(
                    It.IsAny<BlobOpenReadOptions>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    return new System.IO.MemoryStream(Encoding.UTF8.GetBytes(logBlobContent));
                });
            return mockBlobClient.Object;
        }
    }
}
