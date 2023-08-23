// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class MonitorQueryTestEnvironment : TestEnvironment
    {
        public string WorkspaceId => GetRecordedVariable("WORKSPACE_ID");
        public string SecondaryWorkspaceId => GetRecordedVariable("SECONDARY_WORKSPACE_ID");
        public string WorkspaceKey => GetRecordedVariable("WORKSPACE_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string SecondaryWorkspaceKey => GetRecordedVariable("SECONDARY_WORKSPACE_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string MetricsResource => GetRecordedVariable("METRICS_RESOURCE_ID");
        public string MetricsNamespace => GetRecordedVariable("METRICS_RESOURCE_NAMESPACE");
        public string MonitorIngestionEndpoint => GetOptionalVariable("METRICS_INGEST_SUFFIX") ?? "ods.opinsights.azure.com";
        public string MetricsIngestionEndpoint => GetOptionalVariable("METRICS_INGEST_SUFFIX") ?? "monitoring.azure.com";
        public Uri MetricsEndpoint => new(ResourceManagerUrl);
        public string ResourceId => GetRecordedVariable("RESOURCE_ID");
        public string WorkspacePrimaryResourceId => GetRecordedVariable("WORKSPACE_PRIMARY_RESOURCE_ID");
        public string WorkspaceSecondaryResourceId => GetRecordedVariable("WORKSPACE_SECONDARY_RESOURCE_ID");
        public Uri LogsEndpoint => new(GetEndpoint());

        private Dictionary<string, string> regions = new Dictionary<string, string>()
        {
            { "AzureCloud", "https://api.loganalytics.io/v1" },
            { "AzureChinaCloud", "https://api.loganalytics.azure.cn/v1" },
            { "AzureUSGovernment", "https://api.loganalytics.us/v1" }
        };

        private string ENV_MONITOR_ENVIRONMENT = "MONITOR_ENVIRONMENT";
        private string GetEndpoint()
        {
            // if mode is Playback use DefaultEndpoint
            if (Mode == RecordedTestMode.Playback)
            {
                return GetRecordedVariable("LOGS_ENDPOINT");
            }
            // else find endpoing of specific region from pipeline
            string endpoint = "";
            TestContext.Progress.WriteLine("Current Region: " + Environment.GetEnvironmentVariable(ENV_MONITOR_ENVIRONMENT));
            if (regions.TryGetValue(Environment.GetEnvironmentVariable(ENV_MONITOR_ENVIRONMENT), out string region))
            {
                endpoint = region;
            }
            return endpoint;
        }
    }
}
