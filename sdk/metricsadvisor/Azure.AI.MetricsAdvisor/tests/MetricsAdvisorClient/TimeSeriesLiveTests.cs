// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class TimeSeriesLiveTests : MetricsAdvisorLiveTestBase
    {
        public TimeSeriesLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetDimensionValues(bool populateOptionalMembers)
        {
            const string dimensionName = "city";
            const string filter = "ba";

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetDimensionValuesOptions();

            if (populateOptionalMembers)
            {
                options.DimensionValueToFilter = filter;
            }

            var valueCount = 0;

            await foreach (string value in client.GetDimensionValuesAsync(MetricId, dimensionName, options))
            {
                Assert.That(value, Is.Not.Null.And.Not.Empty);

                if (populateOptionalMembers)
                {
                    Assert.That(value.ToLowerInvariant().Contains(filter));
                }

                if (++valueCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(valueCount, Is.GreaterThan(0));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetMetricSeriesDefinitions(bool populateOptionalMembers)
        {
            var cityFilter = new List<string>() { "Belo Horizonte", "Los Angeles", "Osaka" };
            var categoryFilter = new List<string>() { "__SUM__", "Shoes Handbags & Sunglasses" };

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricSeriesDefinitionsOptions(SamplingStartTime);

            if (populateOptionalMembers)
            {
                options.DimensionCombinationsToFilter.Add("city", cityFilter);
                options.DimensionCombinationsToFilter.Add("category", categoryFilter);
            }

            var definitionCount = 0;

            await foreach (MetricSeriesDefinition definition in client.GetMetricSeriesDefinitionsAsync(MetricId, options))
            {
                Assert.That(definition, Is.Not.Null);
                Assert.That(definition.MetricId, Is.EqualTo(MetricId));

                ValidateDimensionKey(definition.SeriesKey);

                if (populateOptionalMembers)
                {
                    Dictionary<string, string> dimensionColumns = definition.SeriesKey.AsDictionary();

                    string city = dimensionColumns["city"];
                    string category = dimensionColumns["category"];

                    Assert.That(cityFilter.Contains(city));
                    Assert.That(categoryFilter.Contains(category));
                }

                if (++definitionCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(definitionCount, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetMetricSeriesData()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var seriesKey1 = new DimensionKey();
            seriesKey1.AddDimensionColumn("city", "Delhi");
            seriesKey1.AddDimensionColumn("category", "Handmade");

            var seriesKey2 = new DimensionKey();
            seriesKey2.AddDimensionColumn("city", "Koltaka");
            seriesKey2.AddDimensionColumn("category", "__SUM__");

            var seriesKeys = new List<DimensionKey>() { seriesKey1, seriesKey2 };
            var returnedKeys = new List<DimensionKey>();

            var options = new GetMetricSeriesDataOptions(seriesKeys, SamplingStartTime, SamplingEndTime);

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

            IEnumerable<List<KeyValuePair<string, string>>> expectedKvps = seriesKeys.Select(key => key.AsDictionary().ToList());
            IEnumerable<List<KeyValuePair<string, string>>> returnedKvps = returnedKeys.Select(key => key.AsDictionary().ToList());

            Assert.That(returnedKvps, Is.EquivalentTo(expectedKvps));
        }

        [Test]
        public async Task GetMetricEnrichmentStatuses()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

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
