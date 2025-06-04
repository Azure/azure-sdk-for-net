// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Moq;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Implementation
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class ServiceClientTests
    {
        private ServiceClient? _serviceClient;
        private Mock<TestReportingClient>? _mockTestReportingClient;
        private Mock<ICloudRunErrorParser>? _mockCloudRunErrorParser;
        private Mock<ILogger>? _mockLogger;
        private CloudRunMetadata? _cloudRunMetadata;

        [SetUp]
        public void Setup()
        {
            _mockTestReportingClient = new Mock<TestReportingClient>();
            _mockCloudRunErrorParser = new Mock<ICloudRunErrorParser>();
            _mockLogger = new Mock<ILogger>();
            _cloudRunMetadata = new CloudRunMetadata
            {
                BaseUri = new Uri("https://example.com"),
                WorkspaceId = "workspaceId",
                RunId = "runId"
            };

            _serviceClient = new ServiceClient(_cloudRunMetadata, _mockCloudRunErrorParser.Object, _mockTestReportingClient.Object, _mockLogger.Object);
        }

        [Test]
        public void PatchTestRunInfo_ReturnsTestRunDto()
        {
            var run = new TestRunDto();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(run));

            responseMock.SetupGet(r => r.Status).Returns(200);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.PatchTestRunInfo(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<RequestContent>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Returns(responseMock.Object);

            TestRunDto? result = _serviceClient!.PatchTestRunInfo(run);

            Assert.IsNotNull(result);
        }

        [Test]
        public void PatchTestRunInfo_On409Conflict_Throws()
        {
            var run = new TestRunDto();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(run));

            responseMock.SetupGet(r => r.Status).Returns(409);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.PatchTestRunInfo(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<RequestContent>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Throws(new RequestFailedException(responseMock.Object));

            Assert.Throws<Exception>(() => _serviceClient!.PatchTestRunInfo(run));

            _mockCloudRunErrorParser!.Verify(x => x.PrintErrorToConsole(It.IsAny<string>()), Times.Once);
            _mockCloudRunErrorParser.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), ReporterConstants.s_cONFLICT_409_ERROR_MESSAGE_KEY), Times.Once);
        }

        [Test]
        public void PatchTestRunInfo_On403Forbidden_Throws()
        {
            var run = new TestRunDto();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(run));

            responseMock.SetupGet(r => r.Status).Returns(403);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.PatchTestRunInfo(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<RequestContent>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Throws(new RequestFailedException(responseMock.Object));

            Assert.Throws<Exception>(() => _serviceClient!.PatchTestRunInfo(run));

            _mockCloudRunErrorParser!.Verify(x => x.PrintErrorToConsole(It.IsAny<string>()), Times.Once);
            _mockCloudRunErrorParser.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), ReporterConstants.s_fORBIDDEN_403_ERROR_MESSAGE_KEY), Times.Once);
        }

        [Test]
        public void PatchTestRunInfo_OnAPIError_ReturnsNull()
        {
            var run = new TestRunDto();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(run));

            responseMock.SetupGet(r => r.Status).Returns(401);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.PatchTestRunInfo(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<RequestContent>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Throws(new RequestFailedException(responseMock.Object));

            TestRunDto? result = _serviceClient!.PatchTestRunInfo(run);

            Assert.IsNull(result);
            _mockCloudRunErrorParser!.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), "401"), Times.Once);
        }

        [Test]
        public void PatchTestRunInfo_OnSuccessButNot200_ReturnsNull()
        {
            var run = new TestRunDto();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(run));

            responseMock.SetupGet(r => r.Status).Returns(201);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.PatchTestRunInfo(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<RequestContent>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Returns(responseMock.Object);

            TestRunDto? result = _serviceClient!.PatchTestRunInfo(run);

            Assert.IsNull(result);
            _mockCloudRunErrorParser!.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), "201"), Times.Once);
        }

        [Test]
        public void PostTestRunShardInfo_ReturnsTestRunShardDto()
        {
            var shard = new TestRunShardDto();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(shard));

            responseMock.SetupGet(r => r.Status).Returns(200);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.PostTestRunShardInfo(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<RequestContent>(),
                It.IsAny<ContentType>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Returns(responseMock.Object);

            TestRunShardDto? result = _serviceClient!.PostTestRunShardInfo(shard);

            Assert.IsNotNull(result);
        }

        [Test]
        public void PostTestRunShardInfo_OnAPIError_ReturnsNull()
        {
            var shard = new TestRunShardDto();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(shard));

            responseMock.SetupGet(r => r.Status).Returns(401);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.PostTestRunShardInfo(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<RequestContent>(),
                It.IsAny<ContentType>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Throws(new RequestFailedException(responseMock.Object));

            TestRunShardDto? result = _serviceClient!.PostTestRunShardInfo(shard);

            Assert.IsNull(result);
            _mockCloudRunErrorParser!.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), "401"), Times.Once);
        }

        [Test]
        public void PostTestRunShardInfo_OnSuccessButNot200_ReturnsNull()
        {
            var shard = new TestRunShardDto();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(shard));

            responseMock.SetupGet(r => r.Status).Returns(201);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.PostTestRunShardInfo(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<RequestContent>(),
                It.IsAny<ContentType>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Returns(responseMock.Object);

            TestRunShardDto? result = _serviceClient!.PostTestRunShardInfo(shard);

            Assert.IsNull(result);
            _mockCloudRunErrorParser!.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), "201"), Times.Once);
        }

        [Test]
        public void GetTestRunResultsUri_ReturnsTestResultsUri()
        {
            var testResultsUri = new TestResultsUri();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(testResultsUri));

            responseMock.SetupGet(r => r.Status).Returns(200);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.GetTestRunResultsUri(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Returns(responseMock.Object);

            TestResultsUri? result = _serviceClient!.GetTestRunResultsUri();

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetTestRunResultsUri_OnAPIError_ReturnsNull()
        {
            var testResultsUri = new TestResultsUri();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(testResultsUri));

            responseMock.SetupGet(r => r.Status).Returns(401);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.GetTestRunResultsUri(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Throws(new RequestFailedException(responseMock.Object));

            TestResultsUri? result = _serviceClient!.GetTestRunResultsUri();

            Assert.IsNull(result);
            _mockCloudRunErrorParser!.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), "401"), Times.Once);
        }

        [Test]
        public void GetTestRunResultsUri_OnSuccessButNot200_ReturnsNull()
        {
            var testResultsUri = new TestResultsUri();
            var responseMock = new Mock<Response>();
            var responseContent = new BinaryData(JsonSerializer.Serialize(testResultsUri));

            responseMock.SetupGet(r => r.Status).Returns(201);
            responseMock.SetupGet(r => r.Content).Returns(responseContent!);

            _mockTestReportingClient!.Setup(x => x.GetTestRunResultsUri(
                _cloudRunMetadata!.WorkspaceId!,
                _cloudRunMetadata.RunId!,
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Returns(responseMock.Object);

            TestResultsUri? result = _serviceClient!.GetTestRunResultsUri();

            Assert.IsNull(result);
            _mockCloudRunErrorParser!.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), "201"), Times.Once);
        }

        [Test]
        public void UploadBatchTestResults_Returns()
        {
            var responseMock = new Mock<Response>();

            responseMock.SetupGet(r => r.Status).Returns(200);

            _mockTestReportingClient!.Setup(x => x.UploadBatchTestResults(
                _cloudRunMetadata!.WorkspaceId!,
                It.IsAny<RequestContent>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Returns(responseMock.Object);

            _serviceClient!.UploadBatchTestResults(new UploadTestResultsRequest());
        }

        [Test]
        public void UploadBatchTestResults_OnAPIError_Returns()
        {
            var responseMock = new Mock<Response>();

            responseMock.SetupGet(r => r.Status).Returns(401);

            _mockTestReportingClient!.Setup(x => x.UploadBatchTestResults(
                _cloudRunMetadata!.WorkspaceId!,
                It.IsAny<RequestContent>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Throws(new RequestFailedException(responseMock.Object));

            _serviceClient!.UploadBatchTestResults(new UploadTestResultsRequest());

            _mockCloudRunErrorParser!.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), "401"), Times.Once);
        }

        [Test]
        public void UploadBatchTestResults_OnSuccessButNot200_Returns()
        {
            var responseMock = new Mock<Response>();

            responseMock.SetupGet(r => r.Status).Returns(201);

            _mockTestReportingClient!.Setup(x => x.UploadBatchTestResults(
                _cloudRunMetadata!.WorkspaceId!,
                It.IsAny<RequestContent>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<RequestContext>()))
                .Returns(responseMock.Object);

            _serviceClient!.UploadBatchTestResults(new UploadTestResultsRequest());

            _mockCloudRunErrorParser!.Verify(x => x.TryPushMessageAndKey(It.IsAny<string>(), "201"), Times.Once);
        }
    }
}
