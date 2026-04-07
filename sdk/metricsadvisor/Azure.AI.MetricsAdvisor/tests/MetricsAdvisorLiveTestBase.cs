// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorLiveTestBase : RecordedTestBase<MetricsAdvisorTestEnvironment>
    {
        protected const string TempDataFeedMetricName = "metric";
        protected const string TempDataFeedDimensionNameA = "dimensionA";
        protected const string TempDataFeedDimensionNameB = "dimensionB";
        protected static string EmptyGuid = Guid.Empty.ToString();

        public MetricsAdvisorLiveTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            SanitizedHeaders.Add(Constants.SubscriptionAuthorizationHeader);
            SanitizedHeaders.Add(Constants.ApiAuthorizationHeader);
            JsonPathSanitizers.Add("$..password");
            JsonPathSanitizers.Add("$..certificatePassword");
            JsonPathSanitizers.Add("$..clientSecret");
            JsonPathSanitizers.Add("$..keyVaultClientSecret");
            JsonPathSanitizers.Add("$..apiKey");
            JsonPathSanitizers.Add("$..accountKey");
            JsonPathSanitizers.Add("$..authHeader");
            JsonPathSanitizers.Add("$..httpHeader");
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"\w+@microsoft.com") { Value = "foo@contoso.com" });
        }

        internal const string DetectionConfigurationId = "78f3a4e7-fe53-4a05-9f4d-d724ab6c23a7";
        internal const string IncidentId = "88ecf25a0e6bd330ef9e7b49b7c5b92b-18001521c00";
        internal const string AlertConfigurationId = "126d1470-b500-4ef0-b5c0-47f9ca914a75";
        internal const string AlertId = "17f9f794800";
        internal const string MetricId = "b6c0649c-0c51-4aa6-82b6-3c3b0aa55066";
        internal const string DataFeedId = "6e48e476-33e6-4113-a299-a5740bc0db47";

        protected int MaximumSamplesCount => 10;

        protected int MaxPageSizeSamples => 1;

        protected int SkipSamples => 1;

        protected DateTimeOffset SamplingStartTime => DateTimeOffset.Parse("2022-01-01T00:00:00.0000000Z");

        protected DateTimeOffset SamplingEndTime => DateTimeOffset.Parse("2022-04-15T00:00:00.0000000Z");

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
            Assert.That(seriesKey.TryGetValue("Dim1", out string dim1));
            Assert.That(seriesKey.TryGetValue("Dim2", out string dim2));

            Assert.That(dim1, Is.Not.Null.And.Not.Empty);
            Assert.That(dim2, Is.Not.Null.And.Not.Empty);
        }

        protected void ValidateGroupKey(DimensionKey groupKey)
        {
            Assert.That(groupKey, Is.Not.Null);

            int count = 0;

            foreach (KeyValuePair<string, string> dimension in groupKey)
            {
                Assert.That(dimension.Key, Is.EqualTo("Dim1").Or.EqualTo("Dim2"));
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
