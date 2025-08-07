// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;

internal enum AccessLevel
{
    Read = 0,
    Write = 1,
    ReadWrite = 2,
    ReadAddCreateWrite = 3,
}

internal partial class CIConfig
{
    [JsonPropertyName("ciProviderName")] public string? CiProviderName { get; set; } = "";

    [JsonPropertyName("branch")] public string? Branch { get; set; }

    [JsonPropertyName("author")] public string? Author { get; set; }

    [JsonPropertyName("commitId")] public string? CommitId { get; set; }

    [JsonPropertyName("revisionUrl")] public string? RevisionUrl { get; set; }
}

internal partial class ClientConfig
{
    [JsonPropertyName("retries")]
    public int Retries { get; set; }

    [JsonPropertyName("repeatEach")]
    public int RepeatEach { get; set; }

    [JsonPropertyName("workers")]
    public int Workers { get; set; }

    [JsonPropertyName("pwVersion")] public string PwVersion { get; set; } = "";

    [JsonPropertyName("testFramework")]
    public TestFramework? TestFramework { get; set; }

    [JsonPropertyName("shards")]
    public Shard? Shards { get; set; }

    [JsonPropertyName("timeout")]
    public int Timeout { get; set; }

    [JsonPropertyName("testType")] public string TestType { get; set; } = "";

    [JsonPropertyName("testSdkLanguage")] public string TestSdkLanguage { get; set; } = "";

    [JsonPropertyName("reporterPackageVersion")] public string ReporterPackageVersion { get; set; } = "";
}

internal partial class PreviousRetrySummary
{
    [JsonPropertyName("testExecutionId")] public string TestExecutionId { get; set; } = "";

    [JsonPropertyName("retry")]
    public int Retry { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; } = "";

    [JsonPropertyName("duration")] public long Duration { get; set; }

    [JsonPropertyName("startTime")] public string StartTime { get; set; } = "";

    [JsonPropertyName("attachmentsMetadata")] public string AttachmentsMetadata { get; set; } = "";

    [JsonPropertyName("artifactsPath")]
    public ICollection<string> ArtifactsPath { get; set; } = new List<string>();
}

internal partial class Shard
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("current")]
    public int? Current { get; set; }
}

internal partial class TestFramework
{
    [JsonPropertyName("name")] public string Name { get; set; } = "";

    [JsonPropertyName("version")] public string Version { get; set; } = "";

    [JsonPropertyName("runnerName")] public string RunnerName { get; set; } = "";
}

internal partial class TestResults
{
    [JsonPropertyName("testExecutionId")] public string TestExecutionId { get; set; } = "";

    [JsonPropertyName("testId")] public string TestId { get; set; } = "";

    [JsonPropertyName("testCombinationId")] public string TestCombinationId { get; set; } = "";

    [JsonPropertyName("runId")] public string RunId { get; set; } = "";

    [JsonPropertyName("shardId")] public string ShardId { get; set; } = "";

    [JsonPropertyName("accountId")] public string AccountId { get; set; } = "";

    [JsonPropertyName("suiteId")] public string SuiteId { get; set; } = "";

    [JsonPropertyName("testTitle")] public string TestTitle { get; set; } = "";

    [JsonPropertyName("suiteTitle")] public string SuiteTitle { get; set; } = "";

    [JsonPropertyName("fileName")] public string FileName { get; set; } = "";

    [JsonPropertyName("lineNumber")]
    public int LineNumber { get; set; }

    [JsonPropertyName("retry")]
    public int Retry { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; } = "";

    [JsonPropertyName("webTestConfig")]
    public WebTestConfig? WebTestConfig { get; set; }

    [JsonPropertyName("ciConfig")]
    public CIConfig? CiConfig { get; set; }

    [JsonPropertyName("resultsSummary")]
    public TestResultsSummary? ResultsSummary { get; set; }

    [JsonPropertyName("previousRetries")]
    public ICollection<PreviousRetrySummary> PreviousRetries { get; set; } = new List<PreviousRetrySummary>();

    [JsonPropertyName("tags")]
    public ICollection<string> Tags { get; set; } = new List<string>();

    [JsonPropertyName("annotations")]
    public ICollection<string> Annotations { get; set; } = new List<string>();

    [JsonPropertyName("artifactsPath")]
    public ICollection<string> ArtifactsPath { get; set; } = new List<string>();
}

internal partial class TestResultsSummary
{
    [JsonPropertyName("status")] public string Status { get; set; } = "";

    [JsonPropertyName("duration")] public long Duration { get; set; }

    [JsonPropertyName("startTime")] public string StartTime { get; set; } = "";

    [JsonPropertyName("attachmentsMetadata")] public string AttachmentsMetadata { get; set; } = "";
}

internal partial class TestResultsUri
{
    [JsonPropertyName("uri")] public string Uri { get; set; } = "";

    [JsonPropertyName("createdAt")] public string CreatedAt { get; set; } = "";

    [JsonPropertyName("expiresAt")] public string ExpiresAt { get; set; } = "";

    [JsonPropertyName("accessLevel")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AccessLevel? AccessLevel { get; set; }
}

internal partial class TestRunDto
{
    [JsonPropertyName("testRunId")]
    public string TestRunId { get; set; } = "";

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; } = "";

    [JsonPropertyName("startTime")]
    public string StartTime { get; set; } = "";

    [JsonPropertyName("creatorId")]
    public string CreatorId { get; set; } = "";

    [JsonPropertyName("creatorName")]
    public string CreatorName { get; set; } = "";

    [JsonPropertyName("summary")]
    public TestRunSummary? Summary { get; set; }

    [JsonPropertyName("resultsSummary")]
    public TestRunResultsSummary? ResultsSummary { get; set; }

    [JsonPropertyName("ciConfig")]
    public CIConfig? CiConfig { get; set; }

    [JsonPropertyName("testRunConfig")]
    public ClientConfig? TestRunConfig { get; set; }

    [JsonPropertyName("testResultsUri")]
    public TestResultsUri? TestResultsUri { get; set; }

    [JsonPropertyName("cloudRunEnabled")] public bool? CloudRunEnabled { get; set; }

    [JsonPropertyName("cloudReportingEnabled")] public bool? CloudReportingEnabled { get; set; }
}

internal partial class TestRunResultsSummary
{
    [JsonPropertyName("numTotalTests")]
    public long NumTotalTests { get; set; }

    [JsonPropertyName("numPassedTests")]
    public long NumPassedTests { get; set; }

    [JsonPropertyName("numFailedTests")]
    public long NumFailedTests { get; set; }

    [JsonPropertyName("numSkippedTests")]
    public long NumSkippedTests { get; set; }

    [JsonPropertyName("numFlakyTests")]
    public long NumFlakyTests { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = "";
}

internal partial class TestRunShardDto
{
    [JsonPropertyName("shardId")] public string ShardId { get; set; } = "";
    [JsonPropertyName("uploadCompleted")] public bool UploadCompleted { get; set; } = false;

    [JsonPropertyName("summary")]
    public TestRunShardSummary? Summary { get; set; }

    [JsonPropertyName("workers")] public int? Workers { get; set; }
}

internal partial class TestRunShardSummary
{
    [JsonPropertyName("status")] public string Status { get; set; } = "";
    [JsonPropertyName("startTime")] public string StartTime { get; set; } = "";

    [JsonPropertyName("endTime")] public string EndTime { get; set; } = "";

    [JsonPropertyName("errorMessages")]
    public ICollection<string> ErrorMessages { get; set; } = new List<string>();

    [JsonPropertyName("uploadMetadata")]
    public UploadMetadata? UploadMetadata { get; set; }

    [JsonPropertyName("totalTime")] public long TotalTime { get; set; }
}

internal partial class TestRunSummary
{
    [JsonPropertyName("status")] public string Status { get; set; } = "";

    [JsonPropertyName("billableTime")] public long BillableTime { get; set; }

    [JsonPropertyName("numBrowserSessions")] public long NumBrowserSessions { get; set; }

    [JsonPropertyName("jobs")]
    public ICollection<string> Jobs { get; set; } = new List<string>();

    [JsonPropertyName("projects")]
    public ICollection<string> Projects { get; set; } = new List<string>();

    [JsonPropertyName("tags")]
    public ICollection<string> Tags { get; set; } = new List<string>();
}

internal partial class UploadMetadata
{
    [JsonPropertyName("numTestResults")] public long NumTestResults { get; set; }

    [JsonPropertyName("numTotalAttachments")] public long NumTotalAttachments { get; set; }

    [JsonPropertyName("sizeTotalAttachments")] public long SizeTotalAttachments { get; set; }
}

internal partial class UploadTestResultsRequest
{
    [JsonPropertyName("value")]
    public ICollection<TestResults> Value { get; set; } = new List<TestResults>();
}

internal partial class WebTestConfig
{
    [JsonPropertyName("jobName")] public string JobName { get; set; } = "";

    [JsonPropertyName("projectName")] public string ProjectName { get; set; } = "";

    [JsonPropertyName("browserType")] public string BrowserName { get; set; } = "";

    [JsonPropertyName("os")] public string Os { get; set; } = "";
}
