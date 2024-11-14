// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Processor;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Moq;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Processor
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class TestProcessorTests
    {
        private CIInfo _cIInfo = new();
        private CloudRunMetadata _cloudRunMetadata = new();

        [SetUp]
        public void Setup()
        {
            _cloudRunMetadata = new CloudRunMetadata
            {
                WorkspaceId = "workspaceId",
                RunId = "runId",
                AccessTokenDetails = new()
                {
                    oid = "oid",
                    userName = "  userName  "
                },
                EnableGithubSummary = false
            };
            _cIInfo = new CIInfo
            {
                Branch = "branch_name",
                Author = "author",
                CommitId = "commitId",
                RevisionUrl = "revisionUrl",
                Provider = CIConstants.s_gITHUB_ACTIONS
            };
        }

        [Test]
        public void TestRunStartHandler_CreatesTestRunAndShardInfo()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            var testRunShardDto = new TestRunShardDto();

            serviceClientMock.Setup(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>())).Returns(new TestRunDto());
            serviceClientMock.Setup(sc => sc.PostTestRunShardInfo(It.IsAny<TestRunShardDto>())).Returns(testRunShardDto);

            var sources = new List<string> { "source1", "source2" };
            var testRunCriteria = new TestRunCriteria(sources, 1);
            var e = new TestRunStartEventArgs(testRunCriteria);
            testProcessor.TestRunStartHandler(sender, e);

            dataProcessorMock.Verify(dp => dp.GetTestRun(), Times.Once);
            dataProcessorMock.Verify(dp => dp.GetTestRunShard(), Times.Once);
            serviceClientMock.Verify(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>()), Times.Once);
            serviceClientMock.Verify(sc => sc.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Once);
            Assert.AreEqual(testRunShardDto, testProcessor._testRunShard);
            Assert.IsFalse(testProcessor.FatalTestExecution);
        }

        [Test]
        public void TestRunStartHandler_PatchTestRunReturnsNull_MarksTestExecutionAsFatal()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            serviceClientMock.Setup(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>())).Returns((TestRunDto?)null);

            var sources = new List<string> { "source1", "source2" };
            var testRunCriteria = new TestRunCriteria(sources, 1);
            var e = new TestRunStartEventArgs(testRunCriteria);
            testProcessor.TestRunStartHandler(sender, e);

            dataProcessorMock.Verify(dp => dp.GetTestRun(), Times.Once);
            dataProcessorMock.Verify(dp => dp.GetTestRunShard(), Times.Once);
            serviceClientMock.Verify(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>()), Times.Once);
            serviceClientMock.Verify(sc => sc.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Never);
            Assert.IsNull(testProcessor._testRunShard);
            Assert.IsTrue(testProcessor.FatalTestExecution);
        }

        [Test]
        public void TestRunStartHandler_PatchTestRunThrowsError_MarksTestExecutionAsFatal()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            serviceClientMock.Setup(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>())).Throws(new System.Exception());

            var sources = new List<string> { "source1", "source2" };
            var testRunCriteria = new TestRunCriteria(sources, 1);
            var e = new TestRunStartEventArgs(testRunCriteria);
            testProcessor.TestRunStartHandler(sender, e);

            dataProcessorMock.Verify(dp => dp.GetTestRun(), Times.Once);
            dataProcessorMock.Verify(dp => dp.GetTestRunShard(), Times.Once);
            serviceClientMock.Verify(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>()), Times.Once);
            serviceClientMock.Verify(sc => sc.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Never);
            Assert.IsNull(testProcessor._testRunShard);
            Assert.IsTrue(testProcessor.FatalTestExecution);
        }

        [Test]
        public void TestRunStartHandler_PostTestRunShardReturnsNull_MarksTestExecutionAsFatal()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            serviceClientMock.Setup(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>())).Returns(new TestRunDto());
            serviceClientMock.Setup(sc => sc.PostTestRunShardInfo(It.IsAny<TestRunShardDto>())).Returns((TestRunShardDto?)null);

            var sources = new List<string> { "source1", "source2" };
            var testRunCriteria = new TestRunCriteria(sources, 1);
            var e = new TestRunStartEventArgs(testRunCriteria);
            testProcessor.TestRunStartHandler(sender, e);

            dataProcessorMock.Verify(dp => dp.GetTestRun(), Times.Once);
            dataProcessorMock.Verify(dp => dp.GetTestRunShard(), Times.Once);
            serviceClientMock.Verify(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>()), Times.Once);
            serviceClientMock.Verify(sc => sc.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Once);
            Assert.IsNull(testProcessor._testRunShard);
            Assert.IsTrue(testProcessor.FatalTestExecution);
        }

        [Test]
        public void TestRunStartHandler_PostTestRunShardThrowsError_MarksTestExecutionAsFatal()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            serviceClientMock.Setup(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>())).Returns(new TestRunDto());
            serviceClientMock.Setup(sc => sc.PostTestRunShardInfo(It.IsAny<TestRunShardDto>())).Throws(new System.Exception());

            var sources = new List<string> { "source1", "source2" };
            var testRunCriteria = new TestRunCriteria(sources, 1);
            var e = new TestRunStartEventArgs(testRunCriteria);
            testProcessor.TestRunStartHandler(sender, e);

            dataProcessorMock.Verify(dp => dp.GetTestRun(), Times.Once);
            dataProcessorMock.Verify(dp => dp.GetTestRunShard(), Times.Once);
            serviceClientMock.Verify(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>()), Times.Once);
            serviceClientMock.Verify(sc => sc.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Once);
            Assert.IsNull(testProcessor._testRunShard);
            Assert.IsTrue(testProcessor.FatalTestExecution);
        }

        [Test]
        public void TestRunStartHandler_EnableResultPublishIsFalse_ShouldBeNoOp()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            _cloudRunMetadata.EnableResultPublish = false;
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            var sources = new List<string> { "source1", "source2" };
            var testRunCriteria = new TestRunCriteria(sources, 1);
            var e = new TestRunStartEventArgs(testRunCriteria);
            testProcessor.TestRunStartHandler(sender, e);

            dataProcessorMock.Verify(dp => dp.GetTestRun(), Times.Never);
            dataProcessorMock.Verify(dp => dp.GetTestRunShard(), Times.Never);
            serviceClientMock.Verify(sc => sc.PatchTestRunInfo(It.IsAny<TestRunDto>()), Times.Never);
            serviceClientMock.Verify(sc => sc.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Never);
            Assert.IsNull(testProcessor._testRunShard);
            Assert.IsFalse(testProcessor.FatalTestExecution);
        }

        [Test]
        public void TestCaseResultHandler_TestPassed_AddsTestResultToTestResultsList()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            var testResults = new TestResults
            {
                Status = TestCaseResultStatus.s_pASSED
            };

            dataProcessorMock.Setup(dp => dp.GetTestCaseResultData(It.IsAny<TestResult?>())).Returns(testResults);

            var testResult = new TestResult(new TestCase("Test", new System.Uri("file://test.cs"), "test-source"));

            testProcessor.TestCaseResultHandler(sender, new TestResultEventArgs(testResult));

            Assert.AreEqual(1, testProcessor.TestResults.Count);
            Assert.AreEqual(testResults, testProcessor.TestResults[0]);
            Assert.IsTrue(testProcessor.RawTestResultsMap.Keys.Count == 1);
            Assert.IsTrue(testProcessor.PassedTestCount == 1);
            Assert.IsTrue(testProcessor.FailedTestCount == 0);
            Assert.IsTrue(testProcessor.SkippedTestCount == 0);
            cloudRunErrorParserMock.Verify(c => c.HandleScalableRunErrorMessage(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void TestCaseResultHandler_TestFailed_AddsTestResultToTestResultsList()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            var testResults = new TestResults
            {
                Status = TestCaseResultStatus.s_fAILED
            };

            dataProcessorMock.Setup(dp => dp.GetTestCaseResultData(It.IsAny<TestResult?>())).Returns(testResults);

            var testResult = new TestResult(new TestCase("Test", new System.Uri("file://test.cs"), "test-source"));

            testProcessor.TestCaseResultHandler(sender, new TestResultEventArgs(testResult));

            Assert.AreEqual(1, testProcessor.TestResults.Count);
            Assert.AreEqual(testResults, testProcessor.TestResults[0]);
            Assert.IsTrue(testProcessor.RawTestResultsMap.Keys.Count == 1);
            Assert.IsTrue(testProcessor.PassedTestCount == 0);
            Assert.IsTrue(testProcessor.FailedTestCount == 1);
            Assert.IsTrue(testProcessor.SkippedTestCount == 0);
            cloudRunErrorParserMock.Verify(c => c.HandleScalableRunErrorMessage(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void TestCaseResultHandler_TestSkipped_AddsTestResultToTestResultsList()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            var testResults = new TestResults
            {
                Status = TestCaseResultStatus.s_sKIPPED
            };

            dataProcessorMock.Setup(dp => dp.GetTestCaseResultData(It.IsAny<TestResult?>())).Returns(testResults);

            var testResult = new TestResult(new TestCase("Test", new System.Uri("file://test.cs"), "test-source"));

            testProcessor.TestCaseResultHandler(sender, new TestResultEventArgs(testResult));

            Assert.AreEqual(1, testProcessor.TestResults.Count);
            Assert.AreEqual(testResults, testProcessor.TestResults[0]);
            Assert.IsTrue(testProcessor.RawTestResultsMap.Keys.Count == 1);
            Assert.IsTrue(testProcessor.PassedTestCount == 0);
            Assert.IsTrue(testProcessor.FailedTestCount == 0);
            Assert.IsTrue(testProcessor.SkippedTestCount == 1);
            cloudRunErrorParserMock.Verify(c => c.HandleScalableRunErrorMessage(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void TestCaseResultHandler_ShouldPassErrorMessageAndStackTraceForScalableErrorParsing()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            var testResults = new TestResults
            {
                Status = TestCaseResultStatus.s_sKIPPED
            };
            dataProcessorMock.Setup(dp => dp.GetTestCaseResultData(It.IsAny<TestResult?>())).Returns(testResults);

            var testResult = new TestResult(new TestCase("Test", new System.Uri("file://test.cs"), "test-source"));

            testProcessor.TestCaseResultHandler(sender, new TestResultEventArgs(testResult)
            {
                Result =
                {
                    ErrorMessage = "Error message",
                    ErrorStackTrace = "Error stack trace"
                }
            });

            cloudRunErrorParserMock.Verify(c => c.HandleScalableRunErrorMessage(It.IsAny<string>()), Times.Exactly(2));
            cloudRunErrorParserMock.Verify(c => c.HandleScalableRunErrorMessage("Error message"), Times.Once);
            cloudRunErrorParserMock.Verify(c => c.HandleScalableRunErrorMessage("Error stack trace"), Times.Once);
        }

        [Test]
        public void TestCaseResultHandler_EnableResultPublishFalse_OnlyParseScalableErrorMessage()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            _cloudRunMetadata.EnableResultPublish = false;
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            var testResults = new TestResults
            {
                Status = TestCaseResultStatus.s_sKIPPED
            };

            dataProcessorMock.Setup(dp => dp.GetTestCaseResultData(It.IsAny<TestResult?>())).Returns(testResults);

            var testResult = new TestResult(new TestCase("Test", new System.Uri("file://test.cs"), "test-source"));

            testProcessor.TestCaseResultHandler(sender, new TestResultEventArgs(testResult));

            Assert.AreEqual(0, testProcessor.TestResults.Count);
            Assert.IsTrue(testProcessor.RawTestResultsMap.Keys.Count == 0);
            Assert.IsTrue(testProcessor.PassedTestCount == 0);
            Assert.IsTrue(testProcessor.FailedTestCount == 0);
            Assert.IsTrue(testProcessor.SkippedTestCount == 0);
            cloudRunErrorParserMock.Verify(c => c.HandleScalableRunErrorMessage(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void TestCaseResultHandler_ExceptionThrown_ShouldBeNoOp()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            var testResults = new TestResults
            {
                Status = TestCaseResultStatus.s_sKIPPED
            };

            dataProcessorMock.Setup(dp => dp.GetTestCaseResultData(It.IsAny<TestResult?>())).Throws(new System.Exception());

            var testResult = new TestResult(new TestCase("Test", new System.Uri("file://test.cs"), "test-source"));

            testProcessor.TestCaseResultHandler(sender, new TestResultEventArgs(testResult));

            Assert.AreEqual(0, testProcessor.TestResults.Count);
            Assert.IsTrue(testProcessor.RawTestResultsMap.Keys.Count == 0);
            Assert.IsTrue(testProcessor.PassedTestCount == 0);
            Assert.IsTrue(testProcessor.FailedTestCount == 0);
            Assert.IsTrue(testProcessor.SkippedTestCount == 0);
            cloudRunErrorParserMock.Verify(c => c.HandleScalableRunErrorMessage(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void TestRunCompleteHandler_UploadsTestResults()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();
            var testResults = new List<TestResults>
            {
                new() { Status = TestCaseResultStatus.s_pASSED },
                new() { Status = TestCaseResultStatus.s_fAILED },
                new() { Status = TestCaseResultStatus.s_sKIPPED }
            };
            testProcessor.TestResults = testResults;
            testProcessor.TestRunCompleteHandler(sender, new TestRunCompleteEventArgs(null, false, false, null, null, TimeSpan.Zero));

            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Once);
        }

        [Test]
        public void TestRunCompleteHandler_UploadsTestResultsThrows_IgnoresException()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            serviceClientMock.Setup(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>())).Throws(new System.Exception());

            var testResults = new List<TestResults>
            {
                new() { Status = TestCaseResultStatus.s_pASSED },
                new() { Status = TestCaseResultStatus.s_fAILED },
                new() { Status = TestCaseResultStatus.s_sKIPPED }
            };
            testProcessor.TestResults = testResults;
            testProcessor.TestRunCompleteHandler(sender, new TestRunCompleteEventArgs(null, false, false, null, null, TimeSpan.Zero));

            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Once);
        }

        [Test]
        public void TestRunCompleteHandler_PatchesTestRunShardInfo()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();
            testProcessor._testRunShard = new TestRunShardDto();
            testProcessor.TotalTestCount = 100;

            var testResults = new List<TestResults> { };
            testProcessor.TestResults = testResults;
            testProcessor.TestRunCompleteHandler(sender, new TestRunCompleteEventArgs(null, false, false, null, null, TimeSpan.Zero));

            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Once);
            serviceClientMock.Verify(c => c.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Once);
            Assert.AreEqual("CLIENT_COMPLETE", testProcessor._testRunShard.Summary!.Status);
            Assert.IsNotNull(testProcessor._testRunShard.Summary!.EndTime);
            Assert.IsNotNull(testProcessor._testRunShard.Summary!.TotalTime);
            Assert.AreEqual(100, testProcessor._testRunShard.Summary!.UploadMetadata!.NumTestResults);
            Assert.AreEqual(0, testProcessor._testRunShard.Summary!.UploadMetadata!.NumTotalAttachments);
            Assert.AreEqual(0, testProcessor._testRunShard.Summary!.UploadMetadata!.SizeTotalAttachments);
            Assert.IsTrue(testProcessor._testRunShard.UploadCompleted);
        }

        [Test]
        public void TestRunCompleteHandler_PatchesTestRunShardInfoThrows_DisplaysInformationMessagesAndPortalUrl()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            serviceClientMock.Setup(c => c.PostTestRunShardInfo(It.IsAny<TestRunShardDto>())).Throws(new System.Exception());

            testProcessor._testRunShard = new TestRunShardDto();

            var testResults = new List<TestResults> { };
            testProcessor.TestResults = testResults;
            testProcessor.TestRunCompleteHandler(sender, new TestRunCompleteEventArgs(null, false, false, null, null, TimeSpan.Zero));

            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Once);
            serviceClientMock.Verify(c => c.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Once);
            consoleWriterMock.Verify(c => c.WriteLine("\nTest Report: " + _cloudRunMetadata.PortalUrl), Times.Once);
            cloudRunErrorParserMock.Verify(c => c.DisplayMessages(), Times.Exactly(1));
        }

        [Test]
        public void TestRunCompleteHandler_DisplaysTestRunUrl()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();
            testProcessor._testRunShard = new TestRunShardDto();

            var testResults = new List<TestResults> { };
            testProcessor.TestResults = testResults;
            testProcessor.TestRunCompleteHandler(sender, new TestRunCompleteEventArgs(null, false, false, null, null, TimeSpan.Zero));

            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Once);
            serviceClientMock.Verify(c => c.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Once);
            consoleWriterMock.Verify(c => c.WriteLine("\nTest Report: " + _cloudRunMetadata.PortalUrl), Times.Once);
        }

        [Test]
        public void TestRunCompleteHandler_DisplaysMessagesOnEnd()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();
            testProcessor._testRunShard = new TestRunShardDto();

            var testResults = new List<TestResults> { };
            testProcessor.TestResults = testResults;
            testProcessor.TestRunCompleteHandler(sender, new TestRunCompleteEventArgs(null, false, false, null, null, TimeSpan.Zero));

            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Once);
            serviceClientMock.Verify(c => c.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Once);
            consoleWriterMock.Verify(c => c.WriteLine("\nTest Report: " + _cloudRunMetadata.PortalUrl), Times.Once);
            cloudRunErrorParserMock.Verify(c => c.DisplayMessages(), Times.Exactly(1));
        }

        [Test]
        public void TestRunCompleteHandler_FatalExecutionSetToTrue_DisplaysMessagesOnEnd()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            testProcessor.FatalTestExecution = true;

            var testResults = new List<TestResults> { };
            testProcessor.TestResults = testResults;
            testProcessor.TestRunCompleteHandler(sender, new TestRunCompleteEventArgs(null, false, false, null, null, TimeSpan.Zero));

            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Never);
            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Never);
            serviceClientMock.Verify(c => c.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Never);
            cloudRunErrorParserMock.Verify(c => c.DisplayMessages(), Times.Exactly(1));
        }

        [Test]
        public void TestRunCompleteHandler_EnableResultPublishSetToFalse_DisplaysMessagesOnEnd()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var sender = new object();

            _cloudRunMetadata.EnableResultPublish = false;

            var testResults = new List<TestResults> { };
            testProcessor.TestResults = testResults;
            testProcessor.TestRunCompleteHandler(sender, new TestRunCompleteEventArgs(null, false, false, null, null, TimeSpan.Zero));

            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Never);
            serviceClientMock.Verify(c => c.UploadBatchTestResults(It.IsAny<UploadTestResultsRequest>()), Times.Never);
            serviceClientMock.Verify(c => c.PostTestRunShardInfo(It.IsAny<TestRunShardDto>()), Times.Never);
            cloudRunErrorParserMock.Verify(c => c.DisplayMessages(), Times.Exactly(1));
        }
        [Test]
        public void CheckAndRenewSasUri_WhenUriExpired_FetchesNewSasUri()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var expiredTestResultsSasUri = new TestResultsUri { Uri = "http://example.com", ExpiresAt = DateTime.UtcNow.AddMinutes(-5).ToString(), AccessLevel = AccessLevel.Read };
            var newTestResultsSasUri = new TestResultsUri { Uri = "http://newexample.com", ExpiresAt = DateTime.UtcNow.AddHours(1).ToString(), AccessLevel = AccessLevel.Read };
            testProcessor._testResultsSasUri = expiredTestResultsSasUri;
            serviceClientMock.Setup(sc => sc.GetTestRunResultsUri()).Returns(newTestResultsSasUri);
            TestResultsUri? result = testProcessor.CheckAndRenewSasUri();
            Assert.AreEqual(newTestResultsSasUri, result);
            loggerMock.Verify(l => l.Info(It.IsAny<string>()), Times.AtLeastOnce);
        }
        [Test]
        public void CheckAndRenewSasUri_WhenUriNotExpired_DoesNotFetchNewSasUri()
        {
            var loggerMock = new Mock<ILogger>();
            var dataProcessorMock = new Mock<IDataProcessor>();
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var cloudRunErrorParserMock = new Mock<ICloudRunErrorParser>();
            var serviceClientMock = new Mock<IServiceClient>();
            var testProcessor = new TestProcessor(_cloudRunMetadata, _cIInfo, loggerMock.Object, dataProcessorMock.Object, cloudRunErrorParserMock.Object, serviceClientMock.Object, consoleWriterMock.Object);
            var validTestResultsSasUri = new TestResultsUri { Uri = "http://example.com?se=" + DateTime.UtcNow.AddMinutes(15).ToString("o"), ExpiresAt = DateTime.UtcNow.AddMinutes(15).ToString(), AccessLevel = AccessLevel.Read };
            testProcessor._testResultsSasUri = validTestResultsSasUri;
            TestResultsUri? result = testProcessor.CheckAndRenewSasUri();
            Assert.AreEqual(validTestResultsSasUri, result);
            serviceClientMock.Verify(sc => sc.GetTestRunResultsUri(), Times.Never);
            loggerMock.Verify(l => l.Info(It.IsAny<string>()), Times.Never);
        }
    }
}
