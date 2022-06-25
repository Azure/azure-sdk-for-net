// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
namespace Azure.Analytics.LoadTestService
{
    /// <summary></summary>
    public class TestModel
    {
        /// <summary></summary>
        public string testId { get; set; }
        /// <summary></summary>
        public string description { get; set; }
        /// <summary></summary>
        public string displayName { get; set; }
        /// <summary></summary>
        public string resourceId { get; set; }
        /// <summary></summary>
        public LoadTestConfig loadTestConfig { get; set; }
        /// <summary></summary>
        public PassFailCriteria passFailCriteria { get; set; }
        /// <summary></summary>
        public DateTime createdDateTime { get; set; }
        /// <summary></summary>
        public string createdBy { get; set; }
        /// <summary></summary>
        public DateTime lastModifiedDateTime { get; set; }
        /// <summary></summary>
        public string lastModifiedBy { get; set; }
        /// <summary></summary>
        public InputArtifacts inputArtifacts { get; set; }
        /// <summary></summary>
        public SecretData secrets { get; set; }
        /// <summary></summary>
        public EnvironmentVariables environmentVariables { get; set; }
        /// <summary></summary>
        public string subnetId { get; set; }
        /// <summary></summary>
        public string keyvaultReferenceIdentityType { get; set; }
        /// <summary></summary>
        public string keyvaultReferenceIdentityId { get; set; }
    }
    /// <summary></summary>
    public class LoadTestConfig
    {
        /// <summary></summary>
        public int engineInstances { get; set; }
        /// <summary></summary>
        public bool splitAllCSVs { get; set; }
    }
    /// <summary></summary>
    public class PassFailCriteria
    {
        /// <summary></summary>
        public Dictionary<string, PassFailMetric> passFailMetrics { get;}
    }
    /// <summary></summary>
    public class PassFailMetric
    {
        /// <summary></summary>
        public string clientmetric { get; set; }
        /// <summary></summary>
        public string aggregate { get; set; }
        /// <summary></summary>
        public string condition { get; set; }
        /// <summary></summary>
        public int value { get; set; }
        /// <summary></summary>
        public string action { get; set; }
        /// <summary></summary>
        public int actualValue { get; set; }
        /// <summary></summary>
        public object result { get; set; }
    }
    /// <summary></summary>
    public class InputArtifacts
    {
        /// <summary></summary>
        public ConfigUrl configUrl { get; set; }
        /// <summary></summary>
        public TestScriptUrl testScriptUrl { get; set; }
        /// <summary></summary>
        public UserPropUrl userPropUrl { get; set; }
        /// <summary></summary>
        public InputArtifactsZipfileUrl inputArtifactsZipFileurl { get; set; }
        /// <summary></summary>
        public object[] additionalUrls { get; set; }
    }
    /// <summary></summary>
    public class ConfigUrl
    {
        /// <summary></summary>
        public Uri url { get; set; }
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
    public class TestScriptUrl
    {
        /// <summary></summary>
        public Uri url { get; set; }
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
    public class UserPropUrl
    {
        /// <summary></summary>
        public Uri url { get; set; }
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
    public class InputArtifactsZipfileUrl
    {
        /// <summary></summary>
        public Uri url { get; set; }
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
    public class SecretData
    {
        /// <summary></summary>
        public Dictionary<string, SecretMetadata> secretmetadata { get; }
    }
    /// <summary></summary>
    public class SecretMetadata
    {
        /// <summary></summary>
        public string value { get; }
        /// <summary></summary>
        public string type { get; set; }
    }
    /// <summary></summary>
    public class EnvironmentVariables
    {
        /// <summary></summary>
        public string envvar { get; set; }
    }
}
