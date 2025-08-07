// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Moq;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Implementation
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class BlobServiceTests
    {
        private Mock<ILogger>? _loggerMock;
        private BlobService? _blobService;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger>();
            _blobService = new BlobService(_loggerMock.Object);
        }
        [Test]
        public async Task UploadBufferAsync_WithException_LogsError()
        {
            string uri = "invalid_uri";
            string buffer = "Test buffer";
            string fileRelativePath = "test/path";

            await _blobService!.UploadBufferAsync(uri, buffer, fileRelativePath);

            _loggerMock!.Verify(logger => logger.Error(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void UploadBuffer_WithException_LogsError()
        {
            string uri = "invalid_uri";
            string buffer = "Test buffer";
            string fileRelativePath = "test/path";

            _blobService!.UploadBuffer(uri, buffer, fileRelativePath);

            _loggerMock!.Verify(logger => logger.Error(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void GetCloudFilePath_WithValidParameters_ReturnsCorrectPath()
        {
            string uri = "https://example.com/container";
            string fileRelativePath = "test/path";
            string expectedPath = "https://example.com/container/test/path?";

            string? result = _blobService?.GetCloudFilePath(uri, fileRelativePath);

            Assert.AreEqual(expectedPath, result);
        }

        [Test]
        public void GetCloudFilePath_WithSasUri_ReturnsCorrectPath()
        {
            string uri = "https://example.com/container?sasToken";
            string fileRelativePath = "test/path";
            string expectedPath = "https://example.com/container/test/path?sasToken";

            string? result = _blobService?.GetCloudFilePath(uri, fileRelativePath);

            Assert.AreEqual(expectedPath, result);
        }
    }
}
