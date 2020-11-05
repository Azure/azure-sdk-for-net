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

        internal const string DetectionConfigurationId = "fb5a6ed6-2b9e-4b72-8b0c-0046ead1c15c";
        internal const string IncidentId = "736eed64368bb6a372e855322a15a736-174e1756000";
        internal const string AlertConfigurationId = "08318302-6006-4019-9afc-975bc63ee566";
        internal const string AlertId = "174995c5800";
        internal const string MetricId = "3d48ed3e-6e6e-4391-b78f-b00dfee1e6f5";
        internal const string DataFeedId = "0072a752-1476-4cfa-8cf0-f226995201a0";

        public void InitDataFeedSources()
        {
            _blobFeedName = Recording.GenerateAlphaNumericId("test");
            _blobSource = new AzureBlobDataFeedSource(TestEnvironment.PrimaryStorageAccountKey, "foo", "template");
            _dailyGranularity = new DataFeedGranularity(DataFeedGranularityType.Daily);
            _dataFeedSchema = new DataFeedSchema(new List<DataFeedMetric> { new DataFeedMetric("someMetricId", "someMetricName", "someMetricDisplayName", "someDescription") });
            _dataFeedIngestionSettings = new DataFeedIngestionSettings(new DateTimeOffset(Recording.UtcNow.Year, Recording.UtcNow.Month, Recording.UtcNow.Day, 0, 0, 0, TimeSpan.Zero));
            _dataFeedDescription = "my feed description";
        }

        public MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            return InstrumentClient(new MetricsAdvisorAdministrationClient(
                new Uri(TestEnvironment.MetricsAdvisorUri),
                new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey),
                InstrumentClientOptions(new MetricsAdvisorClientsOptions())));
        }

        public MetricsAdvisorClient GetMetricsAdvisorClient()
        {
            return InstrumentClient(new MetricsAdvisorClient(
                new Uri(TestEnvironment.MetricsAdvisorUri),
                new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey),
                InstrumentClientOptions(new MetricsAdvisorClientsOptions())));
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

        internal async Task<string> CreateDetectionConfiguration(MetricsAdvisorAdministrationClient adminClient)
        {
            DataFeed feed = await GetFirstDataFeed(adminClient).ConfigureAwait(false);
            AnomalyDetectionConfiguration config = PopulateMetricAnomalyDetectionConfiguration(feed.MetricIds.First());

            return await adminClient.CreateDetectionConfigurationAsync(config).ConfigureAwait(false);
        }

        public AnomalyDetectionConfiguration PopulateMetricAnomalyDetectionConfiguration(string metricId)
        {
            return new AnomalyDetectionConfiguration(
                metricId,
                Recording.GenerateAlphaNumericId("Name"),
                new MetricWholeSeriesDetectionCondition(
                    DetectionConditionsOperator.And,
                    new SmartDetectionCondition(42, AnomalyDetectorDirection.Both, new SuppressCondition(1, 67)),
                    new HardThresholdCondition(23, 45, AnomalyDetectorDirection.Both, new SuppressCondition(1, 50)),
                    new ChangeThresholdCondition(12, 5, true, AnomalyDetectorDirection.Both, new SuppressCondition(1, 1))));
        }

        internal string _blobFeedName;
        internal AzureBlobDataFeedSource _blobSource;
        internal DataFeedGranularity _dailyGranularity;
        internal DataFeedSchema _dataFeedSchema;
        internal DataFeedIngestionSettings _dataFeedIngestionSettings;
        internal string _dataFeedDescription;
    }
}
