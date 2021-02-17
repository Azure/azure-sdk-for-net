﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public async Task GetDimensionValuesWithMinimumSetup(bool useTokenCredential)
        {
            const string dimensionName = "city";

            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var valueCount = 0;

            await foreach (string value in client.GetDimensionValuesAsync(MetricId, dimensionName))
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
        public async Task GetDimensionValuesWithOptionalDimensionFilter()
        {
            const string dimensionName = "city";
            const string filter = "ba";

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetDimensionValuesOptions()
            {
                DimensionValueToFilter = filter
            };

            var valueCount = 0;

            await foreach (string value in client.GetDimensionValuesAsync(MetricId, dimensionName, options))
            {
                Assert.That(value, Is.Not.Null.And.Not.Empty);
                Assert.That(value.ToLowerInvariant().Contains(filter));

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
            var cityFilter = new List<string>() { "Belo Horizonte", "Chennai", "Hong Kong" };
            var categoryFilter = new List<string>() { "__SUM__", "Outdoors" };

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricSeriesDefinitionsOptions(SamplingStartTime);

            options.DimensionCombinationsToFilter.Add("city", cityFilter);
            options.DimensionCombinationsToFilter.Add("category", categoryFilter);

            var definitionCount = 0;

            await foreach (MetricSeriesDefinition definition in client.GetMetricSeriesDefinitionsAsync(MetricId, options))
            {
                Assert.That(definition, Is.Not.Null);
                Assert.That(definition.MetricId, Is.EqualTo(MetricId));

                ValidateSeriesKey(definition.SeriesKey);

                Dictionary<string, string> dimensionColumns = definition.SeriesKey.AsDictionary();

                string city = dimensionColumns["city"];
                string category = dimensionColumns["category"];

                Assert.That(cityFilter.Contains(city));
                Assert.That(categoryFilter.Contains(category));

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

            var seriesKey1 = new DimensionKey();
            seriesKey1.AddDimensionColumn("city", "Delhi");
            seriesKey1.AddDimensionColumn("category", "Handmade");

            var seriesKey2 = new DimensionKey();
            seriesKey2.AddDimensionColumn("city", "Koltaka");
            seriesKey2.AddDimensionColumn("category", "__SUM__");

            var returnedKeys = new List<DimensionKey>();

            var options = new GetMetricSeriesDataOptions(SamplingStartTime, SamplingEndTime)
            {
                SeriesToFilter = { seriesKey1, seriesKey2 }
            };

            await foreach (MetricSeriesData seriesData in client.GetMetricSeriesDataAsync(MetricId, options))
            {
                Assert.That(seriesData, Is.Not.Null);
                Assert.That(seriesData.Definition, Is.Not.Null);
                Assert.That(seriesData.Definition.SeriesKey, Is.Not.Null);
                Assert.That(seriesData.Timestamps, Is.Not.Null);
                Assert.That(seriesData.Values, Is.Not.Null);

                Assert.That(seriesData.Definition.MetricId, Is.EqualTo(MetricId));

                Assert.That(seriesData.Timestamps.Count, Is.EqualTo(seriesData.Values.Count));

                foreach (DateTimeOffset timestamp in seriesData.Timestamps)
                {
                    Assert.That(timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));
                }

                returnedKeys.Add(seriesData.Definition.SeriesKey);
            }

            Assert.That(returnedKeys.Count, Is.EqualTo(2));
            Assert.That(returnedKeys.Contains(seriesKey1));
            Assert.That(returnedKeys.Contains(seriesKey2));
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
