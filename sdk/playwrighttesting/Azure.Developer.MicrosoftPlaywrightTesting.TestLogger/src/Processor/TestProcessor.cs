// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
using Azure.Storage.Blobs;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Processor
{
    internal class TestProcessor : ITestProcessor
    {
        // Dependency Injection
        private readonly IDataProcessor _dataProcessor;
        private readonly ILogger _logger;
        private readonly ICloudRunErrorParser _cloudRunErrorParser;
        private readonly IServiceClient _serviceClient;
        private readonly IConsoleWriter _consoleWriter;
        private readonly CIInfo _cIInfo;
        private readonly CloudRunMetadata _cloudRunMetadata;

        // Test Metadata
        private int TotalTestCount { get; set; } = 0;
        private int PassedTestCount { get; set; } = 0;
        private int FailedTestCount { get; set; } = 0;
        private int SkippedTestCount { get; set; } = 0;
        private List<TestResults> TestResults { get; set; } = new List<TestResults>();
        private ConcurrentDictionary<string, RawTestResult?> RawTestResultsMap { get; set; } = new();
        private bool FatalTestExecution { get; set; } = false;
        private TestRunShardDto? _testRunShard;

        public TestProcessor(CloudRunMetadata cloudRunMetadata, CIInfo cIInfo, ILogger? logger = null, IDataProcessor? dataProcessor = null, ICloudRunErrorParser? cloudRunErrorParser = null, IServiceClient? serviceClient = null, IConsoleWriter? consoleWriter = null)
        {
            _cloudRunMetadata = cloudRunMetadata;
            _cIInfo = cIInfo;
            _logger = logger ?? new Logger();
            _dataProcessor = dataProcessor ?? new DataProcessor(_cloudRunMetadata, _cIInfo, _logger);
            _cloudRunErrorParser = cloudRunErrorParser ?? new CloudRunErrorParser(_logger);
            _serviceClient = serviceClient ?? new ServiceClient(_cloudRunMetadata, _cloudRunErrorParser);
            _consoleWriter = consoleWriter ?? new ConsoleWriter();
        }

        public void TestRunStartHandler(object? sender, TestRunStartEventArgs e)
        {
            try
            {
                _logger.Info("Initialising test run");
                if (!_cloudRunMetadata.EnableResultPublish || FatalTestExecution)
                {
                    return;
                }
                TestRunDtoV2 run = _dataProcessor.GetTestRun();
                TestRunShardDto shard = _dataProcessor.GetTestRunShard();
                TestRunDtoV2? testRun = _serviceClient.PatchTestRunInfo(run);
                if (testRun == null)
                {
                    _logger.Error("Failed to patch test run info");
                    FatalTestExecution = true;
                    return;
                }
                _logger.Info("Successfully patched test run - init");
                TestRunShardDto? testShard = _serviceClient.PatchTestRunShardInfo(1, shard);
                if (testShard == null)
                {
                    _logger.Error("Failed to patch test run shard info");
                    FatalTestExecution = true;
                    return;
                }
                _testRunShard = testShard;
                _logger.Info("Successfully patched test run shard - init");
                _consoleWriter.WriteLine($"\nInitializing reporting for this test run. You can view the results at: {_cloudRunMetadata.PortalUrl!}");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to initialise test run: {ex}");
                FatalTestExecution = true;
            }
        }
        public void TestCaseResultHandler(object? sender, TestResultEventArgs e)
        {
            try
            {
                TestResult testResultSource = e.Result;
                TestResults? testResult = _dataProcessor.GetTestCaseResultData(testResultSource);
                RawTestResult rawResult = DataProcessor.GetRawResultObject(testResultSource);
                RawTestResultsMap.TryAdd(testResult.TestExecutionId, rawResult);

                // TODO - Send error to blob
                _cloudRunErrorParser.HandleScalableRunErrorMessage(testResultSource.ErrorMessage);
                _cloudRunErrorParser.HandleScalableRunErrorMessage(testResultSource.ErrorStackTrace);
                if (!_cloudRunMetadata.EnableResultPublish)
                {
                    return;
                }
                if (testResult != null)
                {
                    TotalTestCount++;
                    if (testResult.Status == TestCaseResultStatus.s_fAILED)
                    {
                        FailedTestCount++;
                    }
                    else if (testResult.Status == TestCaseResultStatus.s_pASSED)
                    {
                        PassedTestCount++;
                    }
                    else if (testResult.Status == TestCaseResultStatus.s_sKIPPED)
                    {
                        SkippedTestCount++;
                    }
                }
                if (testResult != null)
                {
                    TestResults.Add(testResult);
                }
            }
            catch (Exception ex)
            {
                // test case processing failures should not stop the test run
                _logger.Error($"Failed to process test case result: {ex}");
            }
        }
        public void TestRunCompleteHandler(object? sender, TestRunCompleteEventArgs e)
        {
            _logger.Info("Test run complete handler - start");
            if (_cloudRunMetadata.EnableResultPublish && !FatalTestExecution)
            {
                try
                {
                    var body = new UploadTestResultsRequest() { Value = TestResults };
                    _serviceClient.UploadBatchTestResults(body);
                    _logger.Info("Successfully uploaded test results");
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to upload test results: {ex}");
                }
                try
                {
                    TestResultsUri? sasUri = _serviceClient.GetTestRunResultsUri();
                    if (!string.IsNullOrEmpty(sasUri?.Uri))
                    {
                        foreach (TestResults testResult in TestResults)
                        {
                            if (RawTestResultsMap.TryGetValue(testResult.TestExecutionId!, out RawTestResult? rawResult) && rawResult != null)
                            {
                                // Renew the SAS URI if needed
                                var reporterUtils = new ReporterUtils();
                                if (sasUri == null || !reporterUtils.IsTimeGreaterThanCurrentPlus10Minutes(sasUri.Uri))
                                {
                                    sasUri = _serviceClient.GetTestRunResultsUri(); // Create new SAS URI
                                    _logger.Info($"Fetched SAS URI with validity: {sasUri?.ExpiresAt} and access: {sasUri?.AccessLevel}.");
                                }
                                if (sasUri == null)
                                {
                                    _logger.Warning("SAS URI is empty");
                                    continue; // allow recovery from temporary reporter API failures. In the future, we might consider shortciruiting the upload process.
                                }

                                // Upload rawResult to blob storage using sasUri
                                var rawTestResultJson = JsonSerializer.Serialize(rawResult);
                                var filePath = $"{testResult.TestExecutionId}/rawTestResult.json";
                                UploadBuffer(sasUri!.Uri!, rawTestResultJson, filePath);
                            }
                            else
                            {
                                _logger.Info("Couldn't find rawResult for Id: " + testResult.TestExecutionId);
                            }
                        }
                        _logger.Info("Successfully uploaded raw test results");
                    }
                    else
                    {
                        _logger.Error("SAS URI is empty");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to upload artifacts: {ex}");
                }
            }
            EndTestRun(e);
        }

        #region Test Processor Helper Methods
        private void EndTestRun(TestRunCompleteEventArgs e)
        {
            if (_cloudRunMetadata.EnableResultPublish && !FatalTestExecution)
            {
                try
                {
                    _testRunShard = GetTestRunEndShard(e);
                    _serviceClient.PatchTestRunShardInfo(1, _testRunShard);
                    _logger.Info("Successfully ended test run shard");
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to end test run shard: {ex}");
                }
                _consoleWriter.WriteLine($"\nTest Report: {_cloudRunMetadata.PortalUrl!}");
                if (_cloudRunMetadata.EnableGithubSummary)
                {
                    GenerateMarkdownSummary();
                }
            }
            _cloudRunErrorParser.DisplayMessages();
        }
        private static string GetCloudFilePath(string uri, string fileRelativePath)
        {
            string[] parts = uri.Split(new string[] { ReporterConstants.s_sASUriSeparator }, StringSplitOptions.None);
            string containerUri = parts[0];
            string sasToken = parts.Length > 1 ? parts[1] : string.Empty;

            return $"{containerUri}/{fileRelativePath}?{sasToken}";
        }
        private void UploadBuffer(string uri, string buffer, string fileRelativePath)
        {
            string cloudFilePath = GetCloudFilePath(uri, fileRelativePath);
            BlobClient blobClient = new(new Uri(cloudFilePath));
            byte[] bufferBytes = Encoding.UTF8.GetBytes(buffer);
            blobClient.Upload(new BinaryData(bufferBytes), overwrite: true);
            _logger.Info($"Uploaded buffer to {fileRelativePath}");
        }
        private TestRunShardDto GetTestRunEndShard(TestRunCompleteEventArgs e)
        {
            DateTime testRunEndedOn = DateTime.UtcNow;
            long durationInMs = 0;

            var result = FailedTestCount > 0 ? TestCaseResultStatus.s_fAILED : TestCaseResultStatus.s_pASSED;

            if (e.ElapsedTimeInRunningTests != null)
            {
                testRunEndedOn = _cloudRunMetadata.TestRunStartTime.Add(e.ElapsedTimeInRunningTests);
                durationInMs = (long)e.ElapsedTimeInRunningTests.TotalMilliseconds;
            }
            TestRunShardDto? testRunShard = _testRunShard;
            // Update Shard End
            if (testRunShard!.Summary == null)
                testRunShard.Summary = new TestRunShardSummary();
            testRunShard.Summary.Status = "CLIENT_COMPLETE";
            testRunShard.Summary.StartTime = _cloudRunMetadata.TestRunStartTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            testRunShard.Summary.EndTime = testRunEndedOn.ToString("yyyy-MM-ddTHH:mm:ssZ");
            testRunShard.Summary.TotalTime = durationInMs;
            testRunShard.Summary.UploadMetadata = new UploadMetadata() { NumTestResults = TotalTestCount, NumTotalAttachments = 0, SizeTotalAttachments = 0 };
            testRunShard.ResultsSummary = new TestRunResultsSummary
            {
                NumTotalTests = TotalTestCount,
                NumPassedTests = PassedTestCount,
                NumFailedTests = FailedTestCount,
                NumSkippedTests = SkippedTestCount,
                NumFlakyTests = 0, // TODO: Implement flaky tests
                Status = result
            };
            testRunShard.UploadCompleted = "true";
            return testRunShard;
        }
        private void GenerateMarkdownSummary()
        {
            if (_cIInfo.Provider == CIConstants.s_gITHUB_ACTIONS)
            {
                string markdownContent = @$"
#### Results:

![pass](https://img.shields.io/badge/status-passed-brightgreen) **Passed:** {_testRunShard!.ResultsSummary!.NumPassedTests}

![fail](https://img.shields.io/badge/status-failed-red) **Failed:** {_testRunShard.ResultsSummary.NumFailedTests}

![flaky](https://img.shields.io/badge/status-flaky-yellow) **Flaky:** {"0"}

![skipped](https://img.shields.io/badge/status-skipped-lightgrey) **Skipped:** {_testRunShard.ResultsSummary.NumSkippedTests}

#### For more details, visit the [service dashboard]({Uri.EscapeUriString(_cloudRunMetadata.PortalUrl!)}).
";

                string filePath = Environment.GetEnvironmentVariable("GITHUB_STEP_SUMMARY");
                try
                {
                    File.WriteAllText(filePath, markdownContent);
                }
                catch (Exception ex)
                {
                    _logger.Error($"Error writing Markdown summary: {ex}");
                }
            }
        }
        #endregion
    }
}
