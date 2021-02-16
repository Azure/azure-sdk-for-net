// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor
{
    public abstract class MetricsAdvisorTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        public MetricsAdvisorTest(TOptions options) : base(options)
        {
        }

        protected string MetricsAdvisorUri => $"https://{MetricsAdvisorAccountName}.cognitiveservices.azure.com";

        protected string MetricsAdvisorSubscriptionKey => GetEnvironmentVariable("METRICSADVISOR_SUBSCRIPTION_KEY");

        protected string MetricsAdvisorApiKey => GetEnvironmentVariable("METRICSADVISOR_PRIMARY_API_KEY");

        protected string DataFeedId => GetEnvironmentVariable("METRICSADVISOR_DATA_FEED_ID");

        protected DateTimeOffset SamplingStartTime => DateTimeOffset.Parse("2020-10-01T00:00:00Z");

        protected DateTimeOffset SamplingEndTime => DateTimeOffset.Parse("2020-10-31T00:00:00Z");

        private string MetricsAdvisorAccountName => GetEnvironmentVariable("METRICSADVISOR_ACCOUNT_NAME");
    }
}
