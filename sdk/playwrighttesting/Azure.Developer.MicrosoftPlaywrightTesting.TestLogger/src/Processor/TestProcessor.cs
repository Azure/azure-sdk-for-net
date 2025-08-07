// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
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
        internal readonly CIInfo _cIInfo;
        internal readonly CloudRunMetadata _cloudRunMetadata;
        private readonly IBlobService _blobService;

        // Test Metadata
        internal int TotalTestCount { get; set; } = 0;
        internal int PassedTestCount { get; set; } = 0;
        internal int FailedTestCount { get; set; } = 0;
        internal int SkippedTestCount { get; set; } = 0;
        internal int TotalArtifactCount { get; set; } = 0;
        internal int TotalArtifactSizeInBytes { get; set; } = 0;
        internal List<TestResults> TestResults { get; set; } = new List<TestResults>();
        internal ConcurrentDictionary<string, RawTestResult?> RawTestResultsMap { get; set; } = new();
        internal bool FatalTestExecution { get; set; } = false;
        internal TestRunShardDto? _testRunShard;
        internal TestResultsUri? _testResultsSasUri;

        public TestProcessor(CloudRunMetadata cloudRunMetadata, CIInfo cIInfo, ILogger? logger = null, IDataProcessor? dataProcessor = null, ICloudRunErrorParser? cloudRunErrorParser = null, IServiceClient? serviceClient = null, IConsoleWriter? consoleWriter = null, IBlobService? blobService = null)
        {
            _cloudRunMetadata = cloudRunMetadata;
            _cIInfo = cIInfo;
            _logger = logger ?? new Logger();
            _dataProcessor = dataProcessor ?? new DataProcessor(_cloudRunMetadata, _cIInfo, _logger);
            _cloudRunErrorParser = cloudRunErrorParser ?? new CloudRunErrorParser(_logger);
            _serviceClient = serviceClient ?? new ServiceClient(_cloudRunMetadata, _cloudRunErrorParser);
            _consoleWriter = consoleWriter ?? new ConsoleWriter();
            _blobService = blobService ?? new BlobService(_logger);
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
                TestRunDto run = _dataProcessor.GetTestRun();
                TestRunShardDto shard = _dataProcessor.GetTestRunShard();
                TestRunDto? testRun = _serviceClient.PatchTestRunInfo(run);
                if (testRun == null)
                {
                    _logger.Error("Failed to patch test run info");
                    FatalTestExecution = true;
                    return;
                }
                _logger.Info("Successfully patched test run - init");
                TestRunShardDto? testShard = _serviceClient.PostTestRunShardInfo(shard);
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

                // TODO - Send error to blob
                _cloudRunErrorParser.HandleScalableRunErrorMessage(testResultSource.ErrorMessage);
                _cloudRunErrorParser.HandleScalableRunErrorMessage(testResultSource.ErrorStackTrace);
                if (!_cloudRunMetadata.EnableResultPublish || FatalTestExecution)
                {
                    return;
                }

                // TODO move rawResult upload here same as JS
                RawTestResultsMap.TryAdd(testResult.TestExecutionId, rawResult);

                // Upload Attachments
                UploadAttachment(e, testResult.TestExecutionId);

                // Update Test Count
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
                    TestResultsUri? sasUri = CheckAndRenewSasUri();
                    if (!string.IsNullOrEmpty(sasUri?.Uri))
                    {
                        foreach (TestResults testResult in TestResults)
                        {
                            if (RawTestResultsMap.TryGetValue(testResult.TestExecutionId!, out RawTestResult? rawResult) && rawResult != null)
                            {
                                // Renew the SAS URI if needed
                                sasUri = CheckAndRenewSasUri();
                                if (sasUri == null)
                                {
                                    _logger.Warning("SAS URI is empty");
                                    continue; // allow recovery from temporary reporter API failures. In the future, we might consider shortciruiting the upload process.
                                }

                                // Upload rawResult to blob storage using sasUri
                                var rawTestResultJson = JsonSerializer.Serialize(rawResult);
                                var filePath = $"{testResult.TestExecutionId}/rawTestResult.json";
                                _blobService.UploadBuffer(sasUri!.Uri!, rawTestResultJson, filePath);
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

        private void UploadAttachment(TestResultEventArgs e, string testExecutionId)
        {
            _testResultsSasUri = CheckAndRenewSasUri();
            if (e.Result.Attachments != null)
            {
                foreach (var attachmentSet in e.Result.Attachments)
                {
                    foreach (var attachmentData in attachmentSet.Attachments)
                    {
                        var filePath = attachmentData.Uri.LocalPath;
                        _logger.Info($"Uploading attachment: {filePath}");
                        if (!File.Exists( filePath ))
                        {
                            _logger.Error($"Attachment file not found: {filePath}");
                            continue;
                        }
                        try
                        {
                            // get file size
                            var fileSize = new FileInfo(filePath).Length;
                            var cloudFileName = _blobService.GetCloudFileName(filePath, testExecutionId);
                            if (cloudFileName != null) {
                                _blobService.UploadBlobFile(_testResultsSasUri!.Uri!, cloudFileName, filePath);
                                TotalArtifactCount++;
                                TotalArtifactSizeInBytes = TotalArtifactSizeInBytes + (int)fileSize;
                            }
                            else
                            {
                                _logger.Error($"Attachment file Upload Failed: {filePath}");
                            }
                        }
                        catch (Exception ex)
                        {
                            var error = $"Cannot Upload '{filePath}' file: {ex.Message}";

                            _logger.Error(error);
                        }
                    }
                }
            }
        }

        internal TestResultsUri? CheckAndRenewSasUri()
        {
            var reporterUtils = new ReporterUtils();
            if (_testResultsSasUri == null || !reporterUtils.IsTimeGreaterThanCurrentPlus10Minutes(_testResultsSasUri.Uri))
            {
                _testResultsSasUri = _serviceClient.GetTestRunResultsUri();
                _logger.Info($"Fetched SAS URI with validity: {_testResultsSasUri?.ExpiresAt} and access: {_testResultsSasUri?.AccessLevel}.");
            }
            return _testResultsSasUri;
        }

        private void EndTestRun(TestRunCompleteEventArgs e)
        {
            if (_cloudRunMetadata.EnableResultPublish && !FatalTestExecution)
            {
                try
                {
                    _testRunShard = GetTestRunEndShard(e);
                    _serviceClient.PostTestRunShardInfo(_testRunShard);
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

        private TestRunShardDto GetTestRunEndShard(TestRunCompleteEventArgs e)
        {
            DateTime testRunEndedOn = DateTime.UtcNow;
            long durationInMs = 0;

            var result = FailedTestCount > 0 ? TestCaseResultStatus.s_fAILED : TestCaseResultStatus.s_pASSED;

#pragma warning disable CS8073 // The result of the expression is always 'true' since a value of type 'TimeSpan' is never equal to 'null' of type 'TimeSpan?' (net8.0)
            if (e.ElapsedTimeInRunningTests != null)
            {
                testRunEndedOn = _cloudRunMetadata.TestRunStartTime.Add(e.ElapsedTimeInRunningTests);
                durationInMs = (long)e.ElapsedTimeInRunningTests.TotalMilliseconds;
            }
#pragma warning restore CS8073 // The result of the expression is always 'true' since a value of type 'TimeSpan' is never equal to 'null' of type 'TimeSpan?' (net8.0)

            TestRunShardDto? testRunShard = _testRunShard;
            // Update Shard End
            if (testRunShard!.Summary == null)
                testRunShard.Summary = new TestRunShardSummary();
            testRunShard.Summary.Status = "CLIENT_COMPLETE";
            testRunShard.Summary.StartTime = _cloudRunMetadata.TestRunStartTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            testRunShard.Summary.EndTime = testRunEndedOn.ToString("yyyy-MM-ddTHH:mm:ssZ");
            testRunShard.Summary.TotalTime = durationInMs;
            testRunShard.Summary.UploadMetadata = new UploadMetadata() { NumTestResults = TotalTestCount, NumTotalAttachments = TotalArtifactCount, SizeTotalAttachments = TotalArtifactSizeInBytes };
            testRunShard.UploadCompleted = true;
            return testRunShard;
        }
        private void GenerateMarkdownSummary()
        {
            if (_cIInfo.Provider == CIConstants.s_gITHUB_ACTIONS)
            {
                string markdownContent = @$"
#### Results:

![pass](https://img.shields.io/badge/status-passed-brightgreen) **Passed:** {PassedTestCount}

![fail](https://img.shields.io/badge/status-failed-red) **Failed:** {FailedTestCount}

![flaky](https://img.shields.io/badge/status-flaky-yellow) **Flaky:** {"0"}

![skipped](https://img.shields.io/badge/status-skipped-lightgrey) **Skipped:** {SkippedTestCount}

#### For more details, visit the [service dashboard]({_cloudRunMetadata.PortalUrl}).
";

                string? filePath = Environment.GetEnvironmentVariable("GITHUB_STEP_SUMMARY");
                try
                {
                    File.WriteAllText(filePath ?? string.Empty, markdownContent);
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
