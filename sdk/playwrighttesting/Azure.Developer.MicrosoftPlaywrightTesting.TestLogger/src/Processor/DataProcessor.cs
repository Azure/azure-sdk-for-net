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

        public TestRunDto GetTestRun()
        {
            var startTime = _cloudRunMetadata.TestRunStartTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var gitBasedRunName = ReporterUtils.GetRunName(CiInfoProvider.GetCIInfo())?.Trim();
            string runName;
            if (!string.IsNullOrEmpty(_cloudRunMetadata.RunName))
            {
                runName = _cloudRunMetadata.RunName!;
            }
            else if (!string.IsNullOrEmpty(gitBasedRunName))
            {
                runName = gitBasedRunName!;
            }
            else
            {
                runName = _cloudRunMetadata.RunId!;
            }
            var run = new TestRunDto
            {
                TestRunId = _cloudRunMetadata.RunId!,
                DisplayName = runName,
                StartTime = startTime,
                CreatorId = _cloudRunMetadata.AccessTokenDetails!.oid ?? "",
                CreatorName = _cloudRunMetadata.AccessTokenDetails!.userName?.Trim() ?? "",
                CloudReportingEnabled = true,
                CloudRunEnabled = false,
                CiConfig = new CIConfig
                {
                    Branch = ReporterUtils.TruncateData(_cIInfo.Branch, 500),
                    Author = ReporterUtils.TruncateData(_cIInfo.Author,500),
                    CommitId = ReporterUtils.TruncateData(_cIInfo.CommitId,500),
                    RevisionUrl = ReporterUtils.TruncateData(_cIInfo.RevisionUrl,1000),
                    CiProviderName = _cIInfo.Provider ?? CIConstants.s_dEFAULT
                },
                TestRunConfig = new ClientConfig // TODO fetch some of these dynamically
                {
                    Workers = _cloudRunMetadata.NumberOfTestWorkers,
                    PwVersion = "1.40",
                    Timeout = 60000,
                    TestType = "WebTest",
                    TestSdkLanguage = "CSHARP",
                    TestFramework = new TestFramework() { Name = "PLAYWRIGHT", RunnerName = "NUNIT", Version = "3.1" }, // TODO fetch runner name MSTest/Nunit
                    ReporterPackageVersion = "1.0.0-beta.4",
                    Shards = new Shard() { Total = 1 }
                }
            };
            return run;
        }

        public TestRunShardDto GetTestRunShard()
        {
            var startTime = _cloudRunMetadata.TestRunStartTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var shard = new TestRunShardDto
            {
                UploadCompleted = false,
                ShardId = "1",
                Summary = new TestRunShardSummary
                {
                    Status = "RUNNING",
                    StartTime = startTime,
                },
                Workers = _cloudRunMetadata.NumberOfTestWorkers
            };
            return shard;
        }
        public TestResults GetTestCaseResultData(TestResult? testResultSource)
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
            testCaseResultData.TestTitle = ReporterUtils.TruncateData(testResultSource.TestCase.DisplayName, 500)!;
            testCaseResultData.TestTitle = ReporterUtils.TruncateData(testResultSource.TestCase.DisplayName, 500)!;
            var className = FetchTestClassName(testResultSource.TestCase.FullyQualifiedName);
            testCaseResultData.SuiteTitle = ReporterUtils.TruncateData(className,500)!;
            testCaseResultData.SuiteId = ReporterUtils.CalculateSha1Hash(className);
            testCaseResultData.FileName = ReporterUtils.TruncateData(FetchFileName(testResultSource.TestCase.Source),300)!;
            testCaseResultData.LineNumber = testResultSource.TestCase.LineNumber;
            testCaseResultData.Retry = 0; // TODO Retry and PreviousRetries
            testCaseResultData.WebTestConfig = new WebTestConfig
            {
                JobName = _cIInfo.JobId != null ? ReporterUtils.TruncateData(_cIInfo.JobId, 500) ?? "" : "",
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
                StartTime = testResultSource.StartTime.ToString("yyyy-MM-ddTHH:mm:ssZ"),
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

        public static RawTestResult GetRawResultObject(TestResult? testResultSource)
        {
            if (testResultSource == null)
                return new RawTestResult();
            List <MPTError> errors = new();
            if (testResultSource.ErrorMessage != null)
                errors.Add(new MPTError() { message = testResultSource.ErrorMessage });
            if (testResultSource.ErrorStackTrace != null)
                errors.Add(new MPTError() { message = testResultSource.ErrorStackTrace });
            var rawTestResult = new RawTestResult
            {
                errors = JsonSerializer.Serialize(errors)
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
