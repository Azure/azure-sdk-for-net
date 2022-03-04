// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.MetricsAdvisor.Perf
{
    /// <summary>
    /// Represents the ambient environment in which the test suite is being run, offering access to information such
    /// as environment variables.
    /// </summary>
    public sealed class PerfTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PerfTestEnvironment"/> class.
        /// </summary>
        private PerfTestEnvironment()
        {
        }

        /// <summary>
        /// The shared instance of the <see cref="PerfTestEnvironment"/> to be used during test runs.
        /// </summary>
        public static PerfTestEnvironment Instance { get; } = new PerfTestEnvironment();

        /// <summary>
        /// The name of the Metrics Advisor account to test against.
        /// </summary>
        /// <value>The account name, read from the "METRICSADVISOR_ACCOUNT_NAME" environment variable.</value>
        public string MetricsAdvisorAccountName => GetVariable("METRICSADVISOR_ACCOUNT_NAME");

        /// <summary>
        /// The endpoint of the Metrics Advisor account to test against.
        /// </summary>
        public string MetricsAdvisorUri => $"https://{MetricsAdvisorAccountName}.cognitiveservices.azure.com";

        /// <summary>
        /// The subscription key of the Metrics Advisor account to test against.
        /// </summary>
        /// <value>The subscription key, read from the "METRICSADVISOR_SUBSCRIPTION_KEY" environment variable.</value>
        public string MetricsAdvisorSubscriptionKey => GetVariable("METRICSADVISOR_SUBSCRIPTION_KEY");

        /// <summary>
        /// The API key of the Metrics Advisor account to test against.
        /// </summary>
        /// <value>The API key, read from the "METRICSADVISOR_PRIMARY_API_KEY" environment variable.</value>
        public string MetricsAdvisorApiKey => GetVariable("METRICSADVISOR_PRIMARY_API_KEY");

        /// <summary>
        /// The ID of the anomaly detection configuration to test against.
        /// </summary>
        /// <value>The detection configuration ID, read from the "METRICSADVISOR_DETECTION_CONFIGURATION_ID" environment variable.</value>
        public string DetectionConfigurationId => GetVariable("METRICSADVISOR_DETECTION_CONFIGURATION_ID");

        /// <summary>
        /// The ID of the anomaly alert configuration to test against.
        /// </summary>
        /// <value>The alert configuration ID, read from the "METRICSADVISOR_ALERT_CONFIGURATION_ID" environment variable.</value>
        public string AlertConfigurationId => GetVariable("METRICSADVISOR_ALERT_CONFIGURATION_ID");

        /// <summary>
        /// The ID of the alert to test against.
        /// </summary>
        /// <value>The alert ID, read from the "METRICSADVISOR_ALERT_ID" environment variable.</value>
        public string AlertId => GetVariable("METRICSADVISOR_ALERT_ID");

        /// <summary>
        /// The ID of the incident to test against.
        /// </summary>
        /// <value>The incident ID, read from the "METRICSADVISOR_INCIDENT_ID" environment variable.</value>
        public string IncidentId => GetVariable("METRICSADVISOR_INCIDENT_ID");
    }
}
