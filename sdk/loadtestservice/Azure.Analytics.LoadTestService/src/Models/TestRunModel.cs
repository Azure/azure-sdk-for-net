// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
namespace Azure.Analytics.LoadTestService
{
    /// <summary></summary>
    public class TestRunModel
    {
        /// <summary></summary>
        public string testRunId { get; set; }
        /// <summary></summary>
        public string displayName { get; set; }
        /// <summary></summary>
        public string testId { get; set; }
        /// <summary></summary>
        public string resourceId { get; set; }
        /// <summary></summary>
        public string description { get; set; }
        /// <summary></summary>
        public string status { get; set; }
        /// <summary></summary>
        public DateTime startDateTime { get; set; }
        /// <summary></summary>
        public DateTime endDateTime { get; set; }
        /// <summary></summary>
        public LoadTestConfig loadTestConfig { get; set; }
        /// <summary></summary>
        public string testResult { get; set; }
        /// <summary></summary>
        public PassFailCriteria passFailCriteria { get; set; }
        /// <summary></summary>
        public TestArtifacts testArtifacts { get; set; }
        /// <summary></summary>
        public DateTime executedDateTime { get; set; }
        /// <summary></summary>
        public int vusers { get; set; }
        /// <summary></summary>
        public TestRunStatistics testRunStatistics { get; set; }
        /// <summary></summary>
        public DateTime createdDateTime { get; set; }
        /// <summary></summary>
        public string createdBy { get; set; }
        /// <summary></summary>
        public DateTime lastModifiedDateTime { get; set; }
        /// <summary></summary>
        public string lastModifiedBy { get; set; }
        /// <summary></summary>
        public string portalUrl { get; set; }
        /// <summary></summary>
        public SecretData secrets { get; set; }
        /// <summary></summary>
        public EnvironmentVariables environmentVariables { get; set; }
        /// <summary></summary>
        public int duration { get; set; }
        /// <summary></summary>
        public string subnetId { get; set; }
    }
    /// <summary></summary>
    public class TestArtifacts
    {
        /// <summary></summary>
        public InputArtifacts inputArtifacts { get; set; }
        /// <summary></summary>
        public OutputArtifacts outputArtifacts { get; set; }
    }
    /// <summary></summary>
    public class OutputArtifacts
    {
        /// <summary></summary>
        public ResultUrl resultUrl { get; set; }
        /// <summary></summary>
        public LogsUrl logsUrl { get; set; }
    }
    /// <summary></summary>
    public class ResultUrl
    {
        /// <summary></summary>
        public string url { get; set; }
        /// <summary></summary>
        public string fileId { get; set; }
        /// <summary></summary>
        public string filename { get; set; }
        /// <summary></summary>
        public int fileType { get; set; }
        /// <summary></summary>
        public DateTime expireTime { get; set; }
        /// <summary></summary>
        public string validationStatus { get; set; }
    }
    /// <summary></summary>
    public class LogsUrl
    {
        /// <summary></summary>
        public string url { get; set; }
        /// <summary></summary>
        public string fileId { get; set; }
        /// <summary></summary>
        public string filename { get; set; }
        /// <summary></summary>
        public int fileType { get; set; }
        /// <summary></summary>
        public DateTime expireTime { get; set; }
        /// <summary></summary>
        public string validationStatus { get; set; }
    }
    /// <summary></summary>
    public class TestRunStatistics
    {
        /// <summary></summary>
        public TotalValue Total { get; set; }
    }
    /// <summary></summary>
    public class TotalValue
    {
        /// <summary></summary>
        public string transaction { get; set; }
        /// <summary></summary>
        public int sampleCount { get; set; }
        /// <summary></summary>
        public int errorCount { get; set; }
        /// <summary></summary>
        public int errorPct { get; set; }
        /// <summary></summary>
        public int meanResTime { get; set; }
        /// <summary></summary>
        public int medianResTime { get; set; }
        /// <summary></summary>
        public int maxResTime { get; set; }
        /// <summary></summary>
        public int minResTime { get; set; }
        /// <summary></summary>
        public int pct1ResTime { get; set; }
        /// <summary></summary>
        public int pct2ResTime { get; set; }
        /// <summary></summary>
        public int pct3ResTime { get; set; }
        /// <summary></summary>
        public int throughput { get; set; }
        /// <summary></summary>
        public int receivedKBytesPerSec { get; set; }
        /// <summary></summary>
        public int sentKBytesPerSec { get; set; }
    }
}
