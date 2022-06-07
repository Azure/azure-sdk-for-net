// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class TimeSeriesLiveTests : MetricsAdvisorLiveTestBase
    {
        public TimeSeriesLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetMetricDimensionValuesWithMinimumSetup(bool useTokenCredential)
        {
            const string dimensionName = "Dim1";

            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var valueCount = 0;

            await foreach (string value in client.GetMetricDimensionValuesAsync(MetricId, dimensionName))
            {
                Assert.That(value, Is.Not.Null.And.Not.Empty);

                if (++valueCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(valueCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetMetricDimensionValuesWithOptionalDimensionFilter()
        {
            const string dimensionName = "Dim1";
            const string filter = "JP";

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricDimensionValuesOptions()
            {
                DimensionValueFilter = filter
            };

            var valueCount = 0;

            await foreach (string value in client.GetMetricDimensionValuesAsync(MetricId, dimensionName, options))
            {
                Assert.That(value, Is.Not.Null.And.Not.Empty);
                Assert.That(value.Contains(filter));

                if (++valueCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(valueCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetMetricSeriesDefinitionsWithMinimumSetup(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var options = new GetMetricSeriesDefinitionsOptions(SamplingStartTime);

            var definitionCount = 0;

            await foreach (MetricSeriesDefinition definition in client.GetMetricSeriesDefinitionsAsync(MetricId, options))
            {
                Assert.That(definition, Is.Not.Null);
                Assert.That(definition.MetricId, Is.EqualTo(MetricId));

                ValidateSeriesKey(definition.SeriesKey);

                if (++definitionCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(definitionCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetMetricSeriesDefinitionsWithOptionalDimensionFilter()
        {
            var dim1Filter = new List<string>() { "JPN", "USD", "__SUM__" };
            var dim2Filter = new List<string>() { "JP", "US" };

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricSeriesDefinitionsOptions(SamplingStartTime);

            options.DimensionCombinationsFilter.Add("Dim1", dim1Filter);
            options.DimensionCombinationsFilter.Add("Dim2", dim2Filter);

            var definitionCount = 0;

            await foreach (MetricSeriesDefinition definition in client.GetMetricSeriesDefinitionsAsync(MetricId, options))
            {
                Assert.That(definition, Is.Not.Null);
                Assert.That(definition.MetricId, Is.EqualTo(MetricId));

                ValidateSeriesKey(definition.SeriesKey);

                DimensionKey seriesKey = definition.SeriesKey;

                Assert.That(seriesKey.TryGetValue("Dim1", out string region));
                Assert.That(seriesKey.TryGetValue("Dim2", out string category));

                Assert.That(dim1Filter.Contains(region));
                Assert.That(dim2Filter.Contains(category));

                if (++definitionCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(definitionCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetMetricSeriesData(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var dimensions = new Dictionary<string, string>() { { "Dim1", "JPN" }, { "Dim2", "__SUM__" } };
            var seriesKey1 = new DimensionKey(dimensions);

            dimensions = new Dictionary<string, string>() { { "Dim1", "USD" }, { "Dim2", "US" } };
            var seriesKey2 = new DimensionKey(dimensions);

            var returnedKey1 = false;
            var returnedKey2 = false;
            var seriesDataCount = 0;

            var options = new GetMetricSeriesDataOptions(SamplingStartTime, SamplingEndTime)
            {
                SeriesKeys = { seriesKey1, seriesKey2 }
            };

            await foreach (MetricSeriesData seriesData in client.GetMetricSeriesDataAsync(MetricId, options))
            {
                Assert.That(seriesData, Is.Not.Null);
                Assert.That(seriesData.SeriesKey, Is.Not.Null);
                Assert.That(seriesData.Timestamps, Is.Not.Null);
                Assert.That(seriesData.MetricValues, Is.Not.Null);

                Assert.That(seriesData.MetricId, Is.EqualTo(MetricId));

                Assert.That(seriesData.Timestamps.Count, Is.EqualTo(seriesData.MetricValues.Count));

                foreach (DateTimeOffset timestamp in seriesData.Timestamps)
                {
                    Assert.That(timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));
                }

                var seriesKey = seriesData.SeriesKey;

                Assert.That(seriesKey.TryGetValue("Dim1", out string dim1));
                Assert.That(seriesKey.TryGetValue("Dim2", out string dim2));

                if (dim1 == "JPN" && dim2 == "__SUM__")
                {
                    returnedKey1 = true;
                }
                else if (dim1 == "USD" && dim2 == "US")
                {
                    returnedKey2 = true;
                }

                seriesDataCount++;
            }

            Assert.That(seriesDataCount, Is.EqualTo(2));
            Assert.That(returnedKey1);
            Assert.That(returnedKey2);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetMetricEnrichmentStatuses(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var options = new GetMetricEnrichmentStatusesOptions(SamplingStartTime, SamplingEndTime);

            var statusCount = 0;

            await foreach (EnrichmentStatus enrichmentStatus in client.GetMetricEnrichmentStatusesAsync(MetricId, options))
            {
                Assert.That(enrichmentStatus, Is.Not.Null);
                Assert.That(enrichmentStatus.Status, Is.Not.Null.And.Not.Empty);
                Assert.That(enrichmentStatus.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(enrichmentStatus.Timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));

                if (++statusCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(statusCount, Is.GreaterThan(0));
        }
    }
}
