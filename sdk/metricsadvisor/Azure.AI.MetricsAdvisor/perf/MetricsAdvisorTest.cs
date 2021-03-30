// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public abstract class MetricsAdvisorTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        public MetricsAdvisorTest(TOptions options) : base(options)
        {
            var uri = new Uri(MetricsAdvisorUri);
            var credential = new MetricsAdvisorKeyCredential(MetricsAdvisorSubscriptionKey, MetricsAdvisorApiKey);

            Client = new MetricsAdvisorClient(uri, credential);
        }

        protected MetricsAdvisorClient Client { get; }

        protected string DetectionConfigurationId => GetEnvironmentVariable("METRICSADVISOR_DETECTION_CONFIGURATION_ID");

        protected string AlertConfigurationId => GetEnvironmentVariable("METRICSADVISOR_ALERT_CONFIGURATION_ID");

        protected string AlertId => GetEnvironmentVariable("METRICSADVISOR_ALERT_ID");

        protected string IncidentId => GetEnvironmentVariable("METRICSADVISOR_INCIDENT_ID");

        private string MetricsAdvisorAccountName => GetEnvironmentVariable("METRICSADVISOR_ACCOUNT_NAME");

        private string MetricsAdvisorUri => $"https://{MetricsAdvisorAccountName}.cognitiveservices.azure.com";

        private string MetricsAdvisorSubscriptionKey => GetEnvironmentVariable("METRICSADVISOR_SUBSCRIPTION_KEY");

        private string MetricsAdvisorApiKey => GetEnvironmentVariable("METRICSADVISOR_PRIMARY_API_KEY");
    }
}
