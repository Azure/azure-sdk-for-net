// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Text.Json;
using PlaywrightConstants = Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility.Constants;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;

[FriendlyName("ms-playwright-service")]
[ExtensionUri("logger://Microsoft/Playwright/ServiceLogger/v1")]
internal class PlaywrightReporter : ITestLoggerWithParameters
{
    private Dictionary<string, string?>? _parametersDictionary;

    private bool IsInitialized { get; set; }

    private HttpClient? _httpClient;

    private ReportingTestResultsClient? _reportingTestResultsClient;
    private ReportingTestRunsClient? _reportingTestRunsClient;

    private static readonly JsonWebTokenHandler s_tokenHandler = new();

    private readonly LogLevel _logLevel = LogLevel.Debug;

    internal static string EnableConsoleLog { get => Environment.GetEnvironmentVariable(PlaywrightConstants.PLAYWRIGHT_SERVICE_DEBUG) ?? "false"; set { } }

    internal string? PortalUrl { get; set; }

    internal static string? BaseUrl { get => Environment.GetEnvironmentVariable(PlaywrightConstants.PLAYWRIGHT_SERVICE_REPORTING_URL); private set { } }

    internal static string AccessToken { get => Environment.GetEnvironmentVariable(PlaywrightConstants.PLAYWRIGHT_SERVICE_ACCESS_TOKEN) ?? ""; set { } }

    internal string? WorkspaceId { get; set; }

    internal TokenDetails? TokenDetails { get; set; }

    internal CIInfo? CIInfo { get; set; }

    internal string? RunId { get; set; }

    internal DateTime TestRunStartTime { get; private set; }

    internal int TotalTestCount { get; private set; }

    internal int PassedTestCount { get; private set; }

    internal int FailedTestCount { get; private set; }

    internal int SkippedTestCount { get; private set; }

    internal TestRunDtoV2? TestRun { get; set; }

    internal TestRunShardDto? TestRunShard { get; set; }

    internal bool EnableGithubSummary { get; set; } = true;
    internal bool EnableResultPublish { get; set; } = true;

    internal List<TestResults> TestResults = new();

    internal ConcurrentDictionary<string, RawTestResult?> RawTestResultsMap = new();

    internal PlaywrightService? playwrightService;
    private List<string> informationalMessages = new();
    private List<string> processedErrorMessageKeys = new();

    public void Initialize(TestLoggerEvents events, Dictionary<string, string?> parameters)
    {
        ValidateArg.NotNull(events, nameof(events));
        _parametersDictionary = parameters;
        Initialize(events, _parametersDictionary[DefaultLoggerParameterNames.TestRunDirectory]!);
    }

    public void Initialize(TestLoggerEvents events, string testResultsDirPath)
    {
        ValidateArg.NotNull(events, nameof(events));
        ValidateArg.NotNullOrEmpty(testResultsDirPath, nameof(testResultsDirPath));

        // Register for the events.
        events.TestRunMessage += TestMessageHandler;
        events.TestResult += TestResultHandler;
        events.TestRunComplete += TestRunCompleteHandler;
        events.TestRunStart += TestRunStartHandler;
    }

    #region Event Handlers

    internal void TestRunStartHandler(object? sender, TestRunStartEventArgs e)
    {
        InitializePlaywrightReporter(e.TestRunCriteria.TestRunSettings!);
        LogMessage("Test Run start Handler");
        if (!EnableResultPublish)
        {
            return;
        }
        if (!IsInitialized || _reportingTestResultsClient == null || _reportingTestRunsClient == null)
        {
            LogErrorMessage("Test Run setup issue exiting handler");
            return;
        }

        var startTime = TestRunStartTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
        LogMessage("Test Run start time: " + startTime);
        var corelationId = Guid.NewGuid().ToString();
        var gitBasedRunName = ReporterUtils.GetRunName(CiInfoProvider.GetCIInfo());
        var runName = string.IsNullOrEmpty(gitBasedRunName) ? Guid.NewGuid().ToString() : gitBasedRunName;
        var run = new TestRunDtoV2
        {
            TestRunId = RunId!,
            DisplayName = runName,
            StartTime = startTime,
            CreatorId = TokenDetails!.oid ?? "",
            CreatorName = TokenDetails.userName ?? "",
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
                Branch = CIInfo!.Branch ?? "",
                Author = CIInfo.Author ?? "",
                CommitId = CIInfo.CommitId ?? "",
                RevisionUrl = CIInfo.RevisionUrl ?? ""
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
        var token = "Bearer " + AccessToken;
        TestRunDtoV2? response = null;
        try
        {
            Response apiResponse = _reportingTestRunsClient.PatchTestRunInfo(WorkspaceId, RunId, RequestContent.Create(run), "application/json", token, corelationId);
            if (apiResponse.Content != null)
            {
                response = apiResponse.Content!.ToObject<TestRunDtoV2>(new JsonObjectSerializer());
            }
        }
        catch (Exception ex)
        {
            Logger.Log(true, LogLevel.Error, ex.ToString());
            throw;
        }
        if (response != null)
        {
            TestRun = response;

            // Start shard
            corelationId = Guid.NewGuid().ToString();
            TestRunShardDto? response1 = null;
            try
            {
                Response apiResponse = _reportingTestRunsClient.PatchTestRunShardInfo(WorkspaceId, RunId, "1", RequestContent.Create(shard), "application/json", token, corelationId);
                if (apiResponse.Content != null)
                {
                    response1 = apiResponse.Content!.ToObject<TestRunShardDto>(new JsonObjectSerializer());
                }
            }
            catch (Exception ex)
            {
                Logger.Log(true, LogLevel.Error, ex.ToString());
                throw;
            }
            if (response1 != null)
            {
                TestRunShard = shard; // due to wrong response type TODO
            }
            else
            {
                Logger.Log(true, LogLevel.Error, "Run shard creation Failed");
            }
        }
        else
        {
            Logger.Log(true, LogLevel.Error, "Run creation Failed");
        }
        LogMessage("Test Run start Handler completed");
    }

    internal void TestMessageHandler(object? sender, TestRunMessageEventArgs e)
    {
        LogMessage("Test Message Handler");
        ValidateArg.NotNull(sender, nameof(sender));
        ValidateArg.NotNull(e, nameof(e));
        LogMessage(e.Message);
    }

    internal void TestResultHandler(object? sender, TestResultEventArgs e)
    {
        LogMessage("Test Result Handler");
        TestResults? testResult = GetTestCaseResultData(e.Result);
        if (!EnableResultPublish)
        {
            return;
        }
        if (!IsInitialized || _reportingTestResultsClient == null || _reportingTestRunsClient == null)
        {
            LogErrorMessage("Test Run setup issue exiting handler");
            return;
        }
        // Set various counts (passed tests, failed tests, total tests)
        if (testResult != null)
        {
            TotalTestCount++;
            if (testResult.Status == "failed")
            {
                FailedTestCount++;
            }
            else if (testResult.Status == "passed")
            {
                PassedTestCount++;
            }
            else if (testResult.Status == "skipped")
            {
                SkippedTestCount++;
            }
        }
        if (testResult != null)
        {
            TestResults.Add(testResult);
        }
    }

    internal void TestRunCompleteHandler(object? sender, TestRunCompleteEventArgs e)
    {
        LogMessage("Test Run End Handler");
        if (!EnableResultPublish)
        {
            UpdateTestRun(e); // will not publish results, but will print informational messages
            return;
        }
        if (!IsInitialized || _reportingTestResultsClient == null || _reportingTestRunsClient == null || TestRun == null)
        {
            LogErrorMessage("Test Run setup issue exiting handler");
            EnableResultPublish = false;
            UpdateTestRun(e); // will not publish results, but will print informational messages
            return;
        }
        // Upload TestResults
        var corelationId = Guid.NewGuid().ToString();
        var token = "Bearer " + AccessToken;

        var body = new UploadTestResultsRequest() { Value = TestResults };
        try
        {
            _reportingTestResultsClient.UploadBatchTestResults(WorkspaceId, RequestContent.Create(JsonSerializer.Serialize(body)), token, corelationId, null);
            LogMessage("Test Result Uploaded");
        }
        catch (Exception ex)
        {
            LogErrorMessage(ex.Message);
        }

        corelationId = Guid.NewGuid().ToString();
        TestResultsUri? sasUri = null;
        Response response = _reportingTestRunsClient.GetTestRunResultsUri(WorkspaceId, RunId, token, corelationId, null);
        var serializer = new JsonObjectSerializer();
        if (response.Content != null)
        {
            sasUri = response.Content.ToObject<TestResultsUri>(serializer);
        }
        if (sasUri != null && !string.IsNullOrEmpty(sasUri.Uri))
        {
            LogMessage("Test Run Uri: " + sasUri.ToString());
            foreach (TestResults testResult in TestResults)
            {
                if (RawTestResultsMap.TryGetValue(testResult.TestExecutionId!, out RawTestResult? rawResult) && rawResult != null)
                {
                    // Upload rawResult to blob storage using sasUri
                    var rawTestResultJson = JsonSerializer.Serialize(rawResult);
                    var filePath = $"{testResult.TestExecutionId}/rawTestResult.json";
                    UploadBuffer(sasUri.Uri!, rawTestResultJson, filePath);
                }
                else
                {
                    LogMessage("Couldnt find rawResult for Id: " + testResult.TestExecutionId);
                }
            }
        }
        else
        {
            LogMessage("MPT API error: failed to upload artifacts");
        }
        LogMessage("Test Results uploaded");
        // Update TestRun with CLIENT_COMPLETE
        if (UpdateTestRun(e) == false)
        {
            LogErrorMessage("Test Run setup issue, Failed to update TestRun");
        }
    }
    #endregion

    private bool UpdateTestRun(TestRunCompleteEventArgs e)
    {
        if (EnableResultPublish)
        {
            if (!IsInitialized || _reportingTestResultsClient == null || _reportingTestRunsClient == null || TestRun == null || TestRunShard == null)
            {
                // no-op
            }
            else
            {
                DateTime testRunStartedOn = DateTime.MinValue;
                DateTime testRunEndedOn = DateTime.UtcNow;
                long durationInMs = 0;

                var result = FailedTestCount > 0 ? "failed" : "passed";

                if (e.ElapsedTimeInRunningTests != null)
                {
                    testRunEndedOn = TestRunStartTime.Add(e.ElapsedTimeInRunningTests);
                    durationInMs = (long)e.ElapsedTimeInRunningTests.TotalMilliseconds;
                }

                // Update Shard End
                if (TestRunShard.Summary == null)
                    TestRunShard.Summary = new TestRunShardSummary();
                TestRunShard.Summary.Status = "CLIENT_COMPLETE";
                TestRunShard.Summary.StartTime = TestRunStartTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
                TestRunShard.Summary.EndTime = testRunEndedOn.ToString("yyyy-MM-ddTHH:mm:ssZ");
                TestRunShard.Summary.TotalTime = durationInMs;
                TestRunShard.Summary.UploadMetadata = new UploadMetadata() { NumTestResults = TotalTestCount, NumTotalAttachments = 0, SizeTotalAttachments = 0 };
                LogMessage("duration:" + durationInMs);
                LogMessage("StartTime:" + TestRunShard.Summary.StartTime);
                LogMessage("EndTime:" + TestRunShard.Summary.EndTime);
                TestRunShard.ResultsSummary = new TestRunResultsSummary
                {
                    NumTotalTests = TotalTestCount,
                    NumPassedTests = PassedTestCount,
                    NumFailedTests = FailedTestCount,
                    NumSkippedTests = SkippedTestCount,
                    NumFlakyTests = 0, // TODO: Implement flaky tests
                    Status = result
                };
                TestRunShard.UploadCompleted = "true";
                var token = "Bearer " + AccessToken;
                var corelationId = Guid.NewGuid().ToString();
                try
                {
                    _reportingTestRunsClient.PatchTestRunShardInfo(WorkspaceId, RunId, "1", RequestContent.Create(TestRunShard), "application/json", token, corelationId);
                }
                catch (Exception ex)
                {
                    LogErrorMessage("Test Run shard failed: " + ex.ToString());
                    throw;
                }

                LogMessage("TestRun Shard updated");
                playwrightService?.Cleanup();
                Console.WriteLine("Visit MPT Portal for Debugging: " + Uri.EscapeUriString(PortalUrl!));
                if (EnableGithubSummary)
                    GenerateMarkdownSummary();
            }
        }
        if (informationalMessages.Count > 0)
            Console.WriteLine();
        int index = 1;
        foreach (string message in informationalMessages)
        {
            Console.WriteLine($"{index}) {message}");
        }
        return true;
    }

    private TestResults GetTestCaseResultData(TestResult testResultSource)
    {
        if (testResultSource == null)
            return new TestResults();

        LogMessage(testResultSource.TestCase.DisplayName);
        TestResults testCaseResultData = new()
        {
            ArtifactsPath = new List<string>(),

            AccountId = WorkspaceId!,
            RunId = RunId!,
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
            JobName = CIInfo!.JobId ?? "",
            //ProjectName = "playwright-dotnet", // TODO no project concept NA??
            //BrowserName = "chromium", // TODO check if possible to get from test
            Os = GetCurrentOS(),
        };
        //testCaseResultData.Annotations = ["windows"]; // TODO MSTest/Nunit annotation ??
        //testCaseResultData.Tags = ["windows"]; // TODO NA ??

        TimeSpan duration = testResultSource.Duration;
        testCaseResultData.ResultsSummary = new TestResultsSummary
        {
            Duration = (long)duration.TotalMilliseconds, // TODO fallback get from End-Start
            StartTime = testResultSource.StartTime.UtcDateTime.ToString(),
            Status = "inconclusive"
        };
        TestOutcome outcome = testResultSource.Outcome;
        switch (outcome)
        {
            case TestOutcome.Passed:
                testCaseResultData.ResultsSummary.Status = "passed";
                testCaseResultData.Status = "passed";
                break;
            case TestOutcome.Failed:
                testCaseResultData.ResultsSummary.Status = "failed";
                testCaseResultData.Status = "failed";
                break;
            case TestOutcome.Skipped:
                testCaseResultData.ResultsSummary.Status = "skipped";
                testCaseResultData.Status = "skipped";
                break;
            default:
                testCaseResultData.ResultsSummary.Status = "inconclusive";
                testCaseResultData.Status = "inconclusive";
                break;
        }
        // errorMessage, Stacktrace
        RawTestResult rawResult = GetRawResultObject(testResultSource);
        RawTestResultsMap.TryAdd(testCaseResultData.TestExecutionId, rawResult);

        if (!string.IsNullOrEmpty(testResultSource.ErrorMessage))
        {
            ProcessTestResultMessage(testResultSource.ErrorMessage);
            // TODO send it in blob
        }
        if (!string.IsNullOrEmpty(testResultSource.ErrorStackTrace))
        {
            ProcessTestResultMessage(testResultSource.ErrorStackTrace);
            // TODO send it in blob
        }

        // TODO ArtifactsPaths
        return testCaseResultData;
    }

    private void ProcessTestResultMessage(string? message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return;
        }
        foreach (TestResultError testResultErrorObj in TestResultErrorConstants.ErrorConstants)
        {
            if (processedErrorMessageKeys.Contains(testResultErrorObj.Key!))
                continue;
            if (testResultErrorObj.Pattern.IsMatch(message))
            {
                AddInformationalMessage(testResultErrorObj.Message!);
                processedErrorMessageKeys.Add(testResultErrorObj.Key!);
            }
        }
    }

    private TokenDetails ParseWorkspaceIdFromAccessToken(string accessToken)
    {
        TokenDetails tokenDetails = new();
        if (accessToken == null)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException("AccessToken is null or empty");
            }
        }
        try
        {
            JsonWebToken inputToken = (JsonWebToken)s_tokenHandler.ReadToken(accessToken);
            var aid = inputToken.Claims.FirstOrDefault(c => c.Type == "aid")?.Value ?? string.Empty;

            if (!string.IsNullOrEmpty(aid)) // Custom Token
            {
                LogMessage("Custom Token parsing");
                tokenDetails.aid = aid;
                tokenDetails.oid = inputToken.Claims.FirstOrDefault(c => c.Type == "oid")?.Value ?? string.Empty;
                tokenDetails.id = inputToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? string.Empty;
                tokenDetails.userName = inputToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? string.Empty;
            }
            else // Entra Token
            {
                LogMessage("Entra Token parsing");
                tokenDetails.aid = Environment.GetEnvironmentVariable(PlaywrightConstants.PLAYWRIGHT_SERVICE_WORKSPACE_ID) ?? string.Empty;
                tokenDetails.oid = inputToken.Claims.FirstOrDefault(c => c.Type == "oid")?.Value ?? string.Empty;
                tokenDetails.id = string.Empty;
                tokenDetails.userName = inputToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? string.Empty;
                // TODO add back suport for old claims https://devdiv.visualstudio.com/OnlineServices/_git/PlaywrightService?path=/src/Common/Authorization/JwtSecurityTokenValidator.cs&version=GBmain&line=200&lineEnd=200&lineStartColumn=30&lineEndColumn=52&lineStyle=plain&_a=contents
            }

            return tokenDetails;
        }
        catch (Exception ex)
        {
            LogErrorMessage(ex.Message);
            throw;
        }
    }

    private static Guid GetExecutionId(TestResult testResult)
    {
        TestProperty? executionIdProperty = testResult.Properties.FirstOrDefault(
            property => property.Id.Equals(PlaywrightConstants.ExecutionIdPropertyIdentifier));

        Guid executionId = Guid.Empty;
        if (executionIdProperty != null)
            executionId = testResult.GetPropertyValue(executionIdProperty, Guid.Empty);

        return executionId.Equals(Guid.Empty) ? Guid.NewGuid() : executionId;
    }

    private static RawTestResult GetRawResultObject(TestResult testResultSource)
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

    private static string GetCloudFilePath(string uri, string fileRelativePath)
    {
        // Assuming Constants.SAS_URI_SEPARATOR is a static property or field in a class named Constants
        // that holds the character used to split the URI and the SAS token.
        string[] parts = uri.Split(new string[] { PlaywrightConstants.SASUriSeparator }, StringSplitOptions.None);
        string containerUri = parts[0];
        string sasToken = parts.Length > 1 ? parts[1] : string.Empty;

        return $"{containerUri}/{fileRelativePath}?{sasToken}";
    }

    private void UploadBuffer(string uri, string buffer, string fileRelativePath)
    {
        string cloudFilePath = GetCloudFilePath(uri, fileRelativePath);
        LogMessage(cloudFilePath);
        LogMessage(buffer);
        BlobClient blobClient = new(new Uri(cloudFilePath));
        byte[] bufferBytes = Encoding.UTF8.GetBytes(buffer);
        blobClient.Upload(new BinaryData(bufferBytes), overwrite: true);
        LogMessage($"Uploaded buffer to {fileRelativePath}");
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

    private static string GetCurrentOS()
    {
        PlatformID platform = Environment.OSVersion.Platform;
        if (platform == PlatformID.Unix)
            return "Linux";
        else if (platform == PlatformID.MacOSX)
            return "MacOS";
        else
            return "Windows";
    }

    private void LogMessage(string message)
    {
        bool enable = bool.TryParse(EnableConsoleLog, out enable) == true && enable;
        Logger.Log(enable, _logLevel, message);
    }

    private static void LogErrorMessage(string message)
    {
        Logger.Log(true, LogLevel.Error, message);
    }

    private void InitializePlaywrightReporter(string xmlSettings)
    {
        if (IsInitialized)
        {
            return;
        }

        Dictionary<string, object> runParameters = XmlRunSettingsUtilities.GetTestRunParameters(xmlSettings);
        runParameters.TryGetValue(RunSettingKey.RunId, out var runId);
        // If run id is not provided and not set via env, try fetching it from CI info.
        CIInfo = CiInfoProvider.GetCIInfo();
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(PlaywrightConstants.PLAYWRIGHT_SERVICE_RUN_ID)))
        {
            if (string.IsNullOrEmpty(runId?.ToString()))
                Environment.SetEnvironmentVariable(PlaywrightConstants.PLAYWRIGHT_SERVICE_RUN_ID, ReporterUtils.GetRunId(CIInfo));
            else
                Environment.SetEnvironmentVariable(PlaywrightConstants.PLAYWRIGHT_SERVICE_RUN_ID, runId!.ToString());
        }
        else
        {
            PlaywrightService.GetDefaultRunId(); // will not set run id if already present in the environment variable
        }

        runParameters.TryGetValue(RunSettingKey.DefaultAuth, out var defaultAuth);
        runParameters.TryGetValue(RunSettingKey.AzureTokenCredentialType, out var azureTokenCredential);
        runParameters.TryGetValue(RunSettingKey.ManagedIdentityClientId, out var managedIdentityClientId);
        runParameters.TryGetValue(RunSettingKey.EnableGitHubSummary, out var enableGithubSummary);
        runParameters.TryGetValue(RunSettingKey.EnableResultPublish, out var enableResultPublish);
        string? enableGithubSummaryString = enableGithubSummary?.ToString();
        string? enableResultPublishString = enableResultPublish?.ToString();

        EnableGithubSummary = string.IsNullOrEmpty(enableGithubSummaryString) || bool.Parse(enableGithubSummaryString!);
        EnableResultPublish = string.IsNullOrEmpty(enableResultPublishString) || bool.Parse(enableResultPublishString!);

        PlaywrightServiceSettings? playwrightServiceSettings = null;
        try
        {
            playwrightServiceSettings = new(runId: runId?.ToString(), defaultAuth: defaultAuth?.ToString(), azureTokenCredentialType: azureTokenCredential?.ToString(), managedIdentityClientId: managedIdentityClientId?.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Failed to initialize PlaywrightServiceSettings: " + ex.Message);
            Environment.Exit(1);
        }

        // setup entra rotation handlers
        playwrightService = new PlaywrightService(null, playwrightServiceSettings!.RunId, null, playwrightServiceSettings.DefaultAuth, null, playwrightServiceSettings.AzureTokenCredential);
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        playwrightService.InitializeAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.

        RunId = Environment.GetEnvironmentVariable(PlaywrightConstants.PLAYWRIGHT_SERVICE_RUN_ID);

        try
        {
            ValidateArg.NotNullOrEmpty(BaseUrl, "Playwright Service URL");
            ValidateArg.NotNullOrEmpty(AccessToken, "Playwright Service Access Token");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Missing values : " + ex.Message);
            Environment.Exit(1);
        }

        TotalTestCount = 0;
        PassedTestCount = 0;
        FailedTestCount = 0;
        SkippedTestCount = 0;

        TestRunStartTime = DateTime.UtcNow;
        TokenDetails = ParseWorkspaceIdFromAccessToken(AccessToken);
        WorkspaceId = TokenDetails.aid;
        LogMessage("RunId: " + RunId);
        LogMessage("BaseUrl: " + BaseUrl);
        LogMessage("Workspace Id: " + WorkspaceId);

        PortalUrl = PlaywrightConstants.PortalBaseUrl + WorkspaceId + PlaywrightConstants.ReportingRoute + RunId;

        _httpClient = new HttpClient();
        var baseUri = new Uri(BaseUrl!);
        _reportingTestRunsClient = new ReportingTestRunsClient(baseUri);
        _reportingTestResultsClient = new ReportingTestResultsClient(baseUri);

        IsInitialized = true;

        LogMessage("Playwright Service Reporter Intialized");
    }

    internal void GenerateMarkdownSummary()
    {
        if (CiInfoProvider.GetCIProvider() == PlaywrightConstants.GITHUB_ACTIONS)
        {
            string markdownContent = @$"
#### Results:

![pass](https://img.shields.io/badge/status-passed-brightgreen) **Passed:** {TestRunShard!.ResultsSummary!.NumPassedTests}

![fail](https://img.shields.io/badge/status-failed-red) **Failed:** {TestRunShard.ResultsSummary.NumFailedTests}

![flaky](https://img.shields.io/badge/status-flaky-yellow) **Flaky:** {"0"}

![skipped](https://img.shields.io/badge/status-skipped-lightgrey) **Skipped:** {TestRunShard.ResultsSummary.NumSkippedTests}

#### For more details, visit the [service dashboard]({Uri.EscapeUriString(PortalUrl!)}).
";

            string filePath = Environment.GetEnvironmentVariable("GITHUB_STEP_SUMMARY");
            try
            {
                File.WriteAllText(filePath, markdownContent);
            }
            catch (Exception ex)
            {
                LogErrorMessage($"Error writing Markdown summary: {ex}");
            }
        }
    }

    private void AddInformationalMessage(string message)
    {
        informationalMessages.Add(message);
    }
}
