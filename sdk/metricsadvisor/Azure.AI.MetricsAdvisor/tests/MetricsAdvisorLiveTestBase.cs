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

        public MetricsAdvisorLiveTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode, useLegacyTransport: true)
        {
            Sanitizer = new MetricsAdvisorRecordedTestSanitizer();
        }

        public MetricsAdvisorLiveTestBase(bool isAsync) : base(isAsync, useLegacyTransport: true)
        {
            Sanitizer = new MetricsAdvisorRecordedTestSanitizer();
        }

        internal const string DetectionConfigurationId = "efaee305-f049-43ec-9f9b-76026d55c14a";
        internal const string IncidentId = "aaa0ff1cfe41d89ed481f9ac19dbcd8e-17c76f2dc00";
        internal const string AlertConfigurationId = "1c1575d8-b09e-40c3-a3c0-d459c64d8382";
        internal const string AlertId = "17bbd8dec00";
        internal const string MetricId = "390d1139-98fb-45af-b831-8d5ad61b150a";
        internal const string DataFeedId = "151e5444-449f-441e-8b64-988f21c5d054";

        protected int MaximumSamplesCount => 10;

        protected int MaxPageSizeSamples => 1;

        protected int SkipSamples => 1;

        protected DateTimeOffset SamplingStartTime => DateTimeOffset.Parse("2021-10-01T00:00:00Z");

        protected DateTimeOffset SamplingEndTime => DateTimeOffset.Parse("2021-10-31T00:00:00Z");

        public MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient(bool useTokenCredential = false)
        {
            // TODO: remove 'if' block when (https://github.com/Azure/azure-sdk-for-net/issues/23268) is solved
            if (useTokenCredential)
            {
                Assert.Ignore();
            }

            var endpoint = new Uri(TestEnvironment.MetricsAdvisorUri);
            var instrumentedOptions = GetInstrumentedOptions();

            MetricsAdvisorAdministrationClient client = useTokenCredential
                ? new(endpoint, TestEnvironment.Credential, instrumentedOptions)
                : new(endpoint, new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey), instrumentedOptions);

            return InstrumentClient(client);
        }

        public MetricsAdvisorClient GetMetricsAdvisorClient(bool useTokenCredential = false)
        {
            // TODO: remove 'if' block when (https://github.com/Azure/azure-sdk-for-net/issues/23268) is solved
            if (useTokenCredential)
            {
                Assert.Ignore();
            }

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
            Assert.That(seriesKey.TryGetValue("region", out string region));
            Assert.That(seriesKey.TryGetValue("category", out string category));

            Assert.That(region, Is.Not.Null.And.Not.Empty);
            Assert.That(category, Is.Not.Null.And.Not.Empty);
        }

        protected void ValidateGroupKey(DimensionKey groupKey)
        {
            Assert.That(groupKey, Is.Not.Null);

            int count = 0;

            foreach (KeyValuePair<string, string> dimension in groupKey)
            {
                Assert.That(dimension.Key, Is.EqualTo("region").Or.EqualTo("category"));
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
