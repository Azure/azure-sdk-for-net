// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorLiveTestBase : RecordedTestBase<MetricsAdvisorTestEnvironment>
    {
        public MetricsAdvisorLiveTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            Sanitizer = new MetricsAdvisorRecordedTestSanitizer();
        }

        public MetricsAdvisorLiveTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new MetricsAdvisorRecordedTestSanitizer();
        }

        public void InitDataFeedSources()
        {
            _blobFeedName = Recording.GenerateAlphaNumericId("test");
            _blobSource = new AzureBlobDataFeedSource(TestEnvironment.PrimaryStorageAccountKey, "foo", "template");
            _dailyGranularity = new DataFeedGranularity(DataFeedGranularityType.Daily);
            _dataFeedSchema = new DataFeedSchema(new List<DataFeedMetric> { new DataFeedMetric("someMetricId", "someMetricName", "someMetricDisplayName", "someDescription") });
            _dataFeedIngestionSettings = new DataFeedIngestionSettings(new DateTimeOffset(Recording.UtcNow.Year, Recording.UtcNow.Month, Recording.UtcNow.Day, 0, 0, 0, TimeSpan.Zero));
            _dataFeedOptions = new DataFeedOptions() { FeedDescription = "my feed description" };
        }

        public MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClientAad()
        {
            return InstrumentClient(new MetricsAdvisorAdministrationClient(
                new Uri(TestEnvironment.MetricsAdvisorUri),
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new MetricsAdvisorClientOptions())));
        }

        public MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            return InstrumentClient(new MetricsAdvisorAdministrationClient(
                new Uri(TestEnvironment.MetricsAdvisorUri),
                new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey),
                Recording.InstrumentClientOptions(new MetricsAdvisorClientOptions())));
        }

        public MetricsAdvisorClient GetMetricsAdvisorClient()
        {
            return InstrumentClient(new MetricsAdvisorClient(
                new Uri(TestEnvironment.MetricsAdvisorUri),
                new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey),
                Recording.InstrumentClientOptions(new MetricsAdvisorClientOptions())));
        }

        internal static async Task<DataFeed> GetFirstDataFeed(MetricsAdvisorAdministrationClient adminClient)
        {
            DataFeed feed = null;
            IAsyncEnumerable<Page<DataFeed>> pages = adminClient.GetDataFeedsAsync(new GetDataFeedsOptions { TopCount = 1 }).AsPages();

            await foreach (var page in pages)
            {
                //Only perform a single iteration.
                feed = page.Values?.FirstOrDefault();
                break;
            }
            return feed;
        }

        internal async Task<MetricAnomalyDetectionConfiguration> CreateMetricAnomalyDetectionConfiguration(MetricsAdvisorAdministrationClient adminClient)
        {
            DataFeed feed = await GetFirstDataFeed(adminClient).ConfigureAwait(false);

            var config = new MetricAnomalyDetectionConfiguration(
                feed.MetricIds.First(),
                Recording.GenerateAlphaNumericId("Name"),
                new MetricAnomalyDetectionConditions(
                    DetectionConditionsOperator.And,
                    new SmartDetectionCondition(42, AnomalyDetectorDirection.Both, new SuppressCondition(1, 67)),
                    new HardThresholdCondition(23, 45, AnomalyDetectorDirection.Both, new SuppressCondition(1, 50)),
                    new ChangeThresholdCondition(12, 5, true, AnomalyDetectorDirection.Both, new SuppressCondition(1, 1))));

            return await adminClient.CreateMetricAnomalyDetectionConfigurationAsync(config).ConfigureAwait(false);
        }

        internal string _blobFeedName;
        internal AzureBlobDataFeedSource _blobSource;
        internal DataFeedGranularity _dailyGranularity;
        internal DataFeedSchema _dataFeedSchema;
        internal DataFeedIngestionSettings _dataFeedIngestionSettings;
        internal DataFeedOptions _dataFeedOptions;
    }
}
