// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorTestEnvironment : TestEnvironment
    {
        public const string DefaultEndpointSuffix = "azure.com";
        public string MetricsAdvisorApiKey => GetRecordedVariable("METRICSADVISOR_PRIMARY_API_KEY", options => options.IsSecret());
        public string MetricsAdvisorSubscriptionKey => GetRecordedVariable("METRICSADVISOR_SUBSCRIPTION_KEY", options => options.IsSecret());
        public string MetricsAdvisorAccountName => GetRecordedVariable("METRICSADVISOR_ACCOUNT_NAME");
        public string MetricsAdvisorEndpointSuffix => GetRecordedOptionalVariable("METRICSADVISOR_ENDPOINT_SUFFIX") ?? DefaultEndpointSuffix;
        public string MetricsAdvisorUri => $"https://{MetricsAdvisorAccountName}.cognitiveservices.{MetricsAdvisorEndpointSuffix}";

        // Data feed sources
        public string SqlServerConnectionString => GetRecordedVariable("METRICSADVISOR_SQL_SERVER_CONNECTION_STRING", options => options.IsSecret(SanitizedValue.Base64));
        public string SqlServerQuery => GetRecordedVariable("METRICSADVISOR_SQL_SERVER_QUERY");

        // Samples
        public string DataFeedId => Environment.GetEnvironmentVariable("METRICSADVISOR_DATA_FEED_ID");
        public string MetricId => Environment.GetEnvironmentVariable("METRICSADVISOR_METRIC_ID");
        public string HookId => Environment.GetEnvironmentVariable("METRICSADVISOR_HOOK_ID");
        public string DetectionConfigurationId => Environment.GetEnvironmentVariable("METRICSADVISOR_DETECTION_CONFIGURATION_ID");
        public string AlertConfigurationId => Environment.GetEnvironmentVariable("METRICSADVISOR_ALERT_CONFIGURATION_ID");
        public string AlertId => Environment.GetEnvironmentVariable("METRICSADVISOR_ALERT_ID");
        public string IncidentId => Environment.GetEnvironmentVariable("METRICSADVISOR_INCIDENT_ID");
        public string FeedbackId => Environment.GetEnvironmentVariable("METRICSADVISOR_FEEDBACK_ID");
    }
}
