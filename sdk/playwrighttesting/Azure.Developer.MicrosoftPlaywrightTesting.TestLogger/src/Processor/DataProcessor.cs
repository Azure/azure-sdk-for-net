// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Linq;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using System.Text.Json;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Processor
{
    internal class DataProcessor : IDataProcessor
    {
        private readonly ILogger _logger;
        private readonly CIInfo _cIInfo;
        private readonly CloudRunMetadata _cloudRunMetadata;
        public DataProcessor(CloudRunMetadata cloudRunMetadata, CIInfo cIInfo, ILogger? logger = null)
        {
            _cloudRunMetadata = cloudRunMetadata;
            _cIInfo = cIInfo;
            _logger = logger ?? new Logger();
        }

        public TestRunDtoV2 GetTestRun()
        {
            var startTime = _cloudRunMetadata.TestRunStartTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var gitBasedRunName = ReporterUtils.GetRunName(CiInfoProvider.GetCIInfo())?.Trim();
            string runName = string.IsNullOrEmpty(gitBasedRunName) ? _cloudRunMetadata.RunId! : gitBasedRunName!;
            var run = new TestRunDtoV2
            {
                TestRunId = _cloudRunMetadata.RunId!,
                DisplayName = runName,
                StartTime = startTime,
                CreatorId = _cloudRunMetadata.AccessTokenDetails!.oid ?? "",
                CreatorName = _cloudRunMetadata.AccessTokenDetails!.userName?.Trim() ?? "",
                //CloudRunEnabled = "false",
                CloudReportingEnabled = "true",
                Summary = new TestRunSummary
                {
                    Status = "RUNNING",
                    StartTime = startTime,
                    //Projects = ["playwright-dotnet"],
                    //Tags = ["Nunit", "dotnet"],
                    //Jobs = ["playwright-dotnet"],
                },
                CiConfig = new CIConfig // TODO fetch dynamically
                {
                    Branch = _cIInfo.Branch ?? "",
                    Author = _cIInfo.Author ?? "",
                    CommitId = _cIInfo.CommitId ?? "",
                    RevisionUrl = _cIInfo.RevisionUrl ?? ""
                },
                TestRunConfig = new ClientConfig // TODO fetch some of these dynamically
                {
                    Workers = 1,
                    PwVersion = "1.40",
                    Timeout = 60000,
                    TestType = "WebTest",
                    TestSdkLanguage = "Dotnet",
                    TestFramework = new TestFramework() { Name = "VSTest", RunnerName = "Nunit/MSTest", Version = "3.1" }, // TODO fetch runner name MSTest/Nunit
                    ReporterPackageVersion = "0.0.1-dotnet",
                    Shards = new Shard() { Current = 0, Total = 1 }
                }
            };
            return run;
        }

        public TestRunShardDto GetTestRunShard()
        {
            var startTime = _cloudRunMetadata.TestRunStartTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var shard = new TestRunShardDto
            {
                UploadCompleted = "false",
                Summary = new TestRunShardSummary
                {
                    Status = "RUNNING",
                    StartTime = startTime,
                },
                TestRunConfig = new ClientConfig // TODO fetch some of these dynamically
                {
                    Workers = 1,
                    PwVersion = "1.40",
                    Timeout = 60000,
                    TestType = "Functional",
                    TestSdkLanguage = "dotnet",
                    TestFramework = new TestFramework() { Name = "VSTest", RunnerName = "Nunit", Version = "3.1" },
                    ReporterPackageVersion = "0.0.1-dotnet",
                    Shards = new Shard() { Current = 0, Total = 1 },
                }
            };
            return shard;
        }
        public TestResults GetTestCaseResultData(TestResult testResultSource)
        {
            if (testResultSource == null)
                return new TestResults();

            TestResults testCaseResultData = new()
            {
                ArtifactsPath = new List<string>(),
                AccountId = _cloudRunMetadata.WorkspaceId!,
                RunId = _cloudRunMetadata.RunId!,
                TestExecutionId = GetExecutionId(testResultSource).ToString()
            };
            testCaseResultData.TestCombinationId = testCaseResultData.TestExecutionId; // TODO check
            testCaseResultData.TestId = testResultSource.TestCase.Id.ToString();
            testCaseResultData.TestTitle = testResultSource.TestCase.DisplayName;
            var className = FetchTestClassName(testResultSource.TestCase.FullyQualifiedName);
            testCaseResultData.SuiteTitle = className;
            testCaseResultData.SuiteId = className;
            testCaseResultData.FileName = FetchFileName(testResultSource.TestCase.Source);
            testCaseResultData.LineNumber = testResultSource.TestCase.LineNumber;
            testCaseResultData.Retry = 0; // TODO Retry and PreviousRetries
            testCaseResultData.WebTestConfig = new WebTestConfig
            {
                JobName = _cIInfo.JobId ?? "",
                //ProjectName = "playwright-dotnet", // TODO no project concept NA??
                //BrowserName = "chromium", // TODO check if possible to get from test
                Os = ReporterUtils.GetCurrentOS(),
            };
            //testCaseResultData.Annotations = ["windows"]; // TODO MSTest/Nunit annotation ??
            //testCaseResultData.Tags = ["windows"]; // TODO NA ??

            TimeSpan duration = testResultSource.Duration;
            testCaseResultData.ResultsSummary = new TestResultsSummary
            {
                Duration = (long)duration.TotalMilliseconds, // TODO fallback get from End-Start
                StartTime = testResultSource.StartTime.UtcDateTime.ToString(),
                Status = TestCaseResultStatus.s_iNCONCLUSIVE
            };
            TestOutcome outcome = testResultSource.Outcome;
            switch (outcome)
            {
                case TestOutcome.Passed:
                    testCaseResultData.ResultsSummary.Status = TestCaseResultStatus.s_pASSED;
                    testCaseResultData.Status = TestCaseResultStatus.s_pASSED;
                    break;
                case TestOutcome.Failed:
                    testCaseResultData.ResultsSummary.Status = TestCaseResultStatus.s_fAILED;
                    testCaseResultData.Status = TestCaseResultStatus.s_fAILED;
                    break;
                case TestOutcome.Skipped:
                    testCaseResultData.ResultsSummary.Status = TestCaseResultStatus.s_sKIPPED;
                    testCaseResultData.Status = TestCaseResultStatus.s_sKIPPED;
                    break;
                default:
                    testCaseResultData.ResultsSummary.Status = TestCaseResultStatus.s_iNCONCLUSIVE;
                    testCaseResultData.Status = TestCaseResultStatus.s_iNCONCLUSIVE;
                    break;
            }
            return testCaseResultData;
        }

        public static RawTestResult GetRawResultObject(TestResult testResultSource)
        {
            List<MPTError> errors = new();//[testResultSource.ErrorMessage];
            if (testResultSource.ErrorMessage != null)
                errors.Add(new MPTError() { message = testResultSource.ErrorMessage });
            var rawTestResult = new RawTestResult
            {
                errors = JsonSerializer.Serialize(errors),
                stdErr = testResultSource?.ErrorStackTrace ?? string.Empty
            };
            return rawTestResult;
        }

        #region Data Processor Utility Methods

        private static Guid GetExecutionId(TestResult testResult)
        {
            TestProperty? executionIdProperty = testResult.Properties.FirstOrDefault(
                property => property.Id.Equals(ReporterConstants.s_executionIdPropertyIdentifier));

            Guid executionId = Guid.Empty;
            if (executionIdProperty != null)
                executionId = testResult.GetPropertyValue(executionIdProperty, Guid.Empty);

            return executionId.Equals(Guid.Empty) ? Guid.NewGuid() : executionId;
        }

        private static string FetchTestClassName(string fullyQualifiedName)
        {
            string[] parts = fullyQualifiedName.Split('.');
            return string.Join(".", parts.Take(parts.Length - 1));
        }

        private static string FetchFileName(string fullFilePath)
        {
            char[] delimiters = { '\\', '/' };
            string[] parts = fullFilePath.Split(delimiters);
            return parts.Last();
        }
        #endregion
    }
}
