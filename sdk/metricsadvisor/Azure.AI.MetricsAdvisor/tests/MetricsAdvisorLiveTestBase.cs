// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorLiveTestBase : RecordedTestBase<MetricsAdvisorTestEnvironment>
    {
        protected const string TempDataFeedMetricName = "metric";
        protected const string TempDataFeedDimensionNameA = "dimensionA";
        protected const string TempDataFeedDimensionNameB = "dimensionB";

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
        internal const string AlertConfigurationId = "204a211a-c5f4-45f3-a30e-512fb25d1d2c";
        internal const string AlertId = "17571a77000";
        internal const string MetricId = "27e3015f-04fd-44ba-a20b-bc529a0aebae";
        internal const string DataFeedId = "9860df01-e740-40ec-94a2-6351813552ba";

        protected int MaximumSamplesCount => 10;

        protected DateTimeOffset SamplingStartTime => DateTimeOffset.Parse("2020-10-01T00:00:00Z");

        protected DateTimeOffset SamplingEndTime => DateTimeOffset.Parse("2020-10-31T00:00:00Z");

        public MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient(bool useTokenCredential = false)
        {
            var endpoint = new Uri(TestEnvironment.MetricsAdvisorUri);
            var instrumentedOptions = GetInstrumentedOptions();

            MetricsAdvisorAdministrationClient client = useTokenCredential
                ? new(endpoint, TestEnvironment.Credential, instrumentedOptions)
                : new(endpoint, new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey), instrumentedOptions);

            return InstrumentClient(client);
        }

        public MetricsAdvisorClient GetMetricsAdvisorClient(bool useTokenCredential = false)
        {
            var endpoint = new Uri(TestEnvironment.MetricsAdvisorUri);
            var instrumentedOptions = GetInstrumentedOptions();

            MetricsAdvisorClient client = useTokenCredential
                ? new(endpoint, TestEnvironment.Credential, instrumentedOptions)
                : new(endpoint, new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey), instrumentedOptions);

            return InstrumentClient(client);
        }

        protected async Task<DisposableDataFeed> CreateTempDataFeedAsync(MetricsAdvisorAdministrationClient adminClient)
        {
            var dataFeed = new DataFeed()
            {
                Name = Recording.GenerateAlphaNumericId("dataFeed"),
                DataSource = new SqlServerDataFeedSource("connString", "query"),
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily),
                Schema = new DataFeedSchema()
                {
                    MetricColumns = { new DataFeedMetric(TempDataFeedMetricName) },
                    DimensionColumns = { new DataFeedDimension(TempDataFeedDimensionNameA), new DataFeedDimension(TempDataFeedDimensionNameB) }
                },
                IngestionSettings = new DataFeedIngestionSettings(SamplingStartTime)
            };

            return await DisposableDataFeed.CreateDataFeedAsync(adminClient, dataFeed);
        }

        protected int Count(DimensionKey dimensionKey)
        {
            int count = 0;

            foreach (var _ in dimensionKey)
            {
                count++;
            }

            return count;
        }

        protected void ValidateSeriesKey(DimensionKey seriesKey)
        {
            Assert.That(seriesKey, Is.Not.Null);

            Assert.That(Count(seriesKey), Is.EqualTo(2));
            Assert.That(seriesKey.TryGetValue("city", out string city));
            Assert.That(seriesKey.TryGetValue("category", out string category));

            Assert.That(city, Is.Not.Null.And.Not.Empty);
            Assert.That(category, Is.Not.Null.And.Not.Empty);
        }

        protected void ValidateGroupKey(DimensionKey groupKey)
        {
            Assert.That(groupKey, Is.Not.Null);

            int count = 0;

            foreach (KeyValuePair<string, string> dimension in groupKey)
            {
                Assert.That(dimension.Key, Is.EqualTo("city").Or.EqualTo("category"));
                Assert.That(dimension.Value, Is.Not.Null.And.Not.Empty);

                count++;
            }

            Assert.That(count, Is.GreaterThan(0));
            Assert.That(count, Is.LessThanOrEqualTo(2));
        }

        protected void ValidateTempDataFeedDimensionKey(DimensionKey dimensionKey, string expectedDimensionA)
        {
            Assert.That(dimensionKey, Is.Not.Null);

            Assert.That(Count(dimensionKey), Is.EqualTo(1));
            Assert.That(dimensionKey.TryGetValue(TempDataFeedDimensionNameA, out string dimensionA));
            Assert.That(dimensionA, Is.EqualTo(expectedDimensionA));
        }

        protected void ValidateTempDataFeedDimensionKey(DimensionKey dimensionKey, string expectedDimensionA, string expectedDimensionB)
        {
            Assert.That(dimensionKey, Is.Not.Null);

            Assert.That(Count(dimensionKey), Is.EqualTo(2));
            Assert.That(dimensionKey.TryGetValue(TempDataFeedDimensionNameA, out string dimensionA));
            Assert.That(dimensionKey.TryGetValue(TempDataFeedDimensionNameB, out string dimensionB));
            Assert.That(dimensionA, Is.EqualTo(expectedDimensionA));
            Assert.That(dimensionB, Is.EqualTo(expectedDimensionB));
        }

        private MetricsAdvisorClientsOptions GetInstrumentedOptions()
        {
            var options = new MetricsAdvisorClientsOptions();

            options.Retry.MaxRetries = 6;

            return InstrumentClientOptions(options);
        }
    }
}
