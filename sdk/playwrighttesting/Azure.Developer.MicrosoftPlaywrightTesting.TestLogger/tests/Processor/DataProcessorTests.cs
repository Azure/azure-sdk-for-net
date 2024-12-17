// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Processor;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Processor
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class DataProcessorTests
    {
        [Test]
        public void GetTestRun_ReturnsTestRunDto()
        {
            var cloudRunMetadata = new CloudRunMetadata
            {
                WorkspaceId = "workspaceId",
                RunId = "runId",
                AccessTokenDetails = new()
                {
                    oid = "oid",
                    userName = "  userName  "
                },
                NumberOfTestWorkers = 5
            };
            var cIInfo = new CIInfo
            {
                Branch = "branch_name",
                Author = "author",
                CommitId = "commitId",
                RevisionUrl = "revisionUrl",
                Provider = CIConstants.s_gITHUB_ACTIONS
            };
            var dataProcessor = new DataProcessor(cloudRunMetadata, cIInfo);

            TestRunDto result = dataProcessor.GetTestRun();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<TestRunDto>(result);

            Assert.AreEqual(cloudRunMetadata.RunId, result.TestRunId);
            Assert.IsNotNull(result.DisplayName);
            Assert.IsNotNull(result.StartTime);
            Assert.AreEqual(cloudRunMetadata.AccessTokenDetails.oid, result.CreatorId);
            Assert.AreEqual("userName", result.CreatorName);
            Assert.IsTrue(result.CloudReportingEnabled);
            Assert.IsFalse(result.CloudRunEnabled);
            Assert.IsNotNull(result.CiConfig);
            Assert.AreEqual(cIInfo.Branch, result.CiConfig!.Branch);
            Assert.AreEqual(cIInfo.Author, result.CiConfig!.Author);
            Assert.AreEqual(cIInfo.CommitId, result.CiConfig!.CommitId);
            Assert.AreEqual(cIInfo.RevisionUrl, result.CiConfig!.RevisionUrl);
            Assert.AreEqual(cIInfo.Provider, result.CiConfig!.CiProviderName);
            Assert.IsNotNull(result.TestRunConfig);
            Assert.AreEqual(5, result.TestRunConfig!.Workers);
            Assert.AreEqual("1.40", result.TestRunConfig!.PwVersion);
            Assert.AreEqual(60000, result.TestRunConfig!.Timeout);
            Assert.AreEqual("WebTest", result.TestRunConfig!.TestType);
            Assert.AreEqual("CSHARP", result.TestRunConfig!.TestSdkLanguage);
            Assert.IsNotNull(result.TestRunConfig!.TestFramework);
            Assert.AreEqual("PLAYWRIGHT", result.TestRunConfig!.TestFramework!.Name);
            Assert.AreEqual("NUNIT", result.TestRunConfig!.TestFramework!.RunnerName);
            Assert.AreEqual("3.1", result.TestRunConfig!.TestFramework!.Version);
            Assert.AreEqual("1.0.0-beta.4", result.TestRunConfig!.ReporterPackageVersion);
            Assert.IsNotNull(result.TestRunConfig!.Shards);
            Assert.AreEqual(1, result.TestRunConfig!.Shards!.Total);
        }
        [Test]
        public void GetTestRun_ShouldUseRunName_WhenRunNameIsNotEmpty()
        {
            var cloudRunMetadata = new CloudRunMetadata
            {
                RunName = "runName",
                WorkspaceId = "workspaceId",
                RunId = "runId",
                AccessTokenDetails = new()
                {
                    oid = "oid",
                    userName = "  userName  "
                }
            };
            var cIInfo = new CIInfo
            {
                Branch = "branch_name",
                Author = "author",
                CommitId = "commitId",
                RevisionUrl = "revisionUrl",
                Provider = CIConstants.s_gITHUB_ACTIONS
            };
            var dataProcessor = new DataProcessor(cloudRunMetadata, cIInfo);
            TestRunDto result = dataProcessor.GetTestRun();
            Assert.AreEqual("runName", result.DisplayName);
        }

        [Test]
        public void GetTestRunShard_ReturnsTestRunShardDto()
        {
            var cloudRunMetadata = new CloudRunMetadata();
            cloudRunMetadata.NumberOfTestWorkers = 6;
            var cIInfo = new CIInfo();
            var dataProcessor = new DataProcessor(cloudRunMetadata, cIInfo);

            TestRunShardDto result = dataProcessor.GetTestRunShard();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<TestRunShardDto>(result);
            Assert.IsFalse(result.UploadCompleted);
            Assert.AreEqual("1", result.ShardId);
            Assert.IsNotNull(result.Summary);
            Assert.AreEqual("RUNNING", result.Summary!.Status);
            Assert.IsNotNull(result.Summary!.StartTime);
            Assert.AreEqual(6, result.Workers);
        }

        [Test]
        public void GetTestCaseResultData_WithNullTestResult_ReturnsEmptyTestResults()
        {
            var cloudRunMetadata = new CloudRunMetadata();
            var cIInfo = new CIInfo();
            var dataProcessor = new DataProcessor(cloudRunMetadata, cIInfo);
            TestResult? testResult = null;

            TestResults result = dataProcessor.GetTestCaseResultData(testResult);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetTestCaseResultData_WithNonNullTestResult_ReturnsTestResults()
        {
            var cloudRunMetadata = new CloudRunMetadata
            {
                WorkspaceId = "workspaceId",
                RunId = "runId",
                AccessTokenDetails = new()
                {
                    oid = "oid",
                    userName = "  userName  "
                }
            };
            var cIInfo = new CIInfo
            {
                Branch = "branch_name",
                Author = "author",
                CommitId = "commitId",
                RevisionUrl = "revisionUrl",
                Provider = CIConstants.s_gITHUB_ACTIONS,
                JobId = "jobId"
            };
            var dataProcessor = new DataProcessor(cloudRunMetadata, cIInfo);
            var testResult = new TestResult(new TestCase("Test.Reporting", new System.Uri("file:///test.cs"), "TestNamespace.TestClass"));

            TestResults result = dataProcessor.GetTestCaseResultData(testResult);

            Assert.IsNotNull(result);
            Assert.IsEmpty(result.ArtifactsPath);
            Assert.AreEqual(cloudRunMetadata.WorkspaceId, result.AccountId);
            Assert.AreEqual(cloudRunMetadata.RunId, result.RunId);
            Assert.IsNotNull(result.TestExecutionId);
            Assert.IsNotNull(result.TestCombinationId);
            Assert.IsNotNull(result.TestId);
            Assert.AreEqual(testResult.TestCase.DisplayName, result.TestTitle);
            Assert.AreEqual("Test", result.SuiteTitle);
            Assert.AreEqual(ReporterUtils.CalculateSha1Hash("Test"), result.SuiteId);
            Assert.AreEqual("TestNamespace.TestClass", result.FileName);
            Assert.AreEqual(testResult.TestCase.LineNumber, result.LineNumber);
            Assert.AreEqual(0, result.Retry);
            Assert.IsNotNull(result.WebTestConfig);
            Assert.AreEqual(cIInfo.JobId, result.WebTestConfig!.JobName);
            Assert.AreEqual(ReporterUtils.GetCurrentOS(), result.WebTestConfig.Os);
            Assert.IsNotNull(result.ResultsSummary);
            Assert.AreEqual((long)testResult.Duration.TotalMilliseconds, result.ResultsSummary!.Duration);
            Assert.AreEqual(testResult.StartTime.ToString("yyyy-MM-ddTHH:mm:ssZ"), result.ResultsSummary.StartTime);
            Assert.AreEqual(TestCaseResultStatus.s_iNCONCLUSIVE, result.ResultsSummary.Status);
            Assert.AreEqual(TestCaseResultStatus.s_iNCONCLUSIVE, result.Status);
        }
        [Test]
        [Ignore("Need to mock GetRunName response")]
        public void GetTestRun_ShouldUseGitBasedRunName_WhenRunNameIsEmptyAndGitBasedRunNameIsNotEmpty()
        {
            var cloudRunMetadata = new CloudRunMetadata
            {
                RunName = "",
                WorkspaceId = "workspaceId",
                RunId = "runId",
                AccessTokenDetails = new()
                {
                    oid = "oid",
                    userName = "  userName  "
                }
            };
            var cIInfo = new CIInfo
            {
                Branch = "branch_name",
                Author = "author",
                CommitId = "commitId",
                RevisionUrl = "revisionUrl",
                Provider = CIConstants.s_gITHUB_ACTIONS
            };
            var gitBasedRunName = ReporterUtils.GetRunName(cIInfo);
            var dataProcessor = new DataProcessor(cloudRunMetadata, cIInfo);
            TestRunDto result = dataProcessor.GetTestRun();
            Assert.AreEqual(gitBasedRunName, result.DisplayName);
        }
        [Test]
        [Ignore("Need to mock GetRunName response")]
        public void GetTestRun_ShouldUseRunId_WhenRunNameAndGitBasedRunNameAreEmpty()
        {
            var cloudRunMetadata = new CloudRunMetadata
            {
                RunName = "",
                WorkspaceId = "workspaceId",
                RunId = "runId",
                AccessTokenDetails = new()
                {
                    oid = "oid",
                    userName = "  userName  "
                }
            };
            var cIInfo = new CIInfo
            {
            };
            var reporterUtilsMock = new Mock<ReporterUtils>();
            reporterUtilsMock.Setup(r => ReporterUtils.GetRunName(cIInfo)).Returns(string.Empty);
            var dataProcessor = new DataProcessor(cloudRunMetadata, cIInfo);
            TestRunDto result = dataProcessor.GetTestRun();
            Assert.AreEqual("runId", result.DisplayName);
        }
        [Test]
        public void GetRawResultObject_WithNullTestResult_ReturnsRawTestResultWithEmptyErrorsAndStdErr()
        {
            RawTestResult result = DataProcessor.GetRawResultObject(null);

            Assert.IsNotNull(result);
            Assert.AreEqual("[]", result.errors);
            Assert.AreEqual("[]", result.stdErr);
        }

        [Test]
        public void GetRawResultObject_WithNullErrorStackTrace_ReturnsRawTestResultWithEmptyErrorsAndStdErr()
        {
            var testResult = new TestResult(new TestCase("Test", new System.Uri("file:///test.cs"), "TestNamespace.TestClass"))
            {
                ErrorMessage = null,
                ErrorStackTrace = null
            };

            RawTestResult result = DataProcessor.GetRawResultObject(testResult);

            Assert.IsNotNull(result);
            Assert.AreEqual("[]", result.errors);
            Assert.AreEqual("[]", result.stdErr);
        }

        [Test]
        public void GetRawResultObject_WithNonNullTestResult_ReturnsRawTestResultWithErrorsAndStdErr()
        {
            var testResult = new TestResult(new TestCase("Test", new System.Uri("file:///test.cs"), "TestNamespace.TestClass"))
            {
                ErrorMessage = "An error occurred",
                ErrorStackTrace = "Error stack trace"
            };

            RawTestResult result = DataProcessor.GetRawResultObject(testResult);

            Assert.IsNotNull(result);
            Assert.AreEqual("[{\"message\":\"An error occurred\"},{\"message\":\"Error stack trace\"}]", result.errors);
        }
    }
}
