// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Test.Perf;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public abstract class MetricsAdvisorTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        public MetricsAdvisorTest(TOptions options) : base(options)
        {
            TestEnvironment = PerfTestEnvironment.Instance;

            var uri = new Uri(TestEnvironment.MetricsAdvisorUri);
            var credential = new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey);

            Client = new MetricsAdvisorClient(uri, credential);
            AdminClient = new MetricsAdvisorAdministrationClient(uri, credential);
        }

        protected PerfTestEnvironment TestEnvironment { get; }

        protected MetricsAdvisorClient Client { get; }

        protected MetricsAdvisorAdministrationClient AdminClient { get; }

        protected DataFeed GetDataFeedInstance()
        {
            var dataSource = new AzureBlobDataFeedSource("secret", "container", "template");
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            return new DataFeed()
            {
                Name = "net-perf-" + Guid.NewGuid(),
                DataSource = dataSource,
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily),
                Schema = new DataFeedSchema() { MetricColumns = { new("cost") } },
                IngestionSettings = new DataFeedIngestionSettings(ingestionStartTime)
            };
        }
    }
}
