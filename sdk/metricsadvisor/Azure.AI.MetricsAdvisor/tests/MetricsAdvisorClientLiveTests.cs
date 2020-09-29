// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorClientLiveTests : MetricsAdvisorLiveTestBase
    {
        private const string DetectionConfigurationId = "59f26a57-55f7-41eb-8899-a7268d125557";
        private const string IncidentId = "013c34456c5aed901c66ca1dff0714aa-174995c5800";
        private const string AlertConfigurationId = "08318302-6006-4019-9afc-975bc63ee566";
        private const string AlertId = "174995c5800";
        private const string MetricId = "3d48ed3e-6e6e-4391-b78f-b00dfee1e6f5";

        public MetricsAdvisorClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        [RecordedTest]
        public async Task GetMetricSeriesDefinitions()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            var client = GetMetricsAdvisorClient();

            List<DataFeed> feeds = await adminClient.GetDataFeedsAsync().ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(feeds, Is.Not.Empty);

            int totalcount = 0;
            foreach (DataFeed feed in feeds)
            {
                foreach (var metricId in feed.MetricIds)
                {
                    await foreach (MetricSeriesDefinition metricDef in client.GetMetricSeriesDefinitionsAsync(
                        metricId,
                        new GetMetricSeriesDefinitionsOptions(Recording.UtcNow.AddYears(-5)) { TopCount = 2 }))
                    {
                        Assert.That(metricDef.Dimension.Count, Is.Not.Zero);

                        // stop when we find at least one definition
                        if (++totalcount >= 1)
                            break;
                    }
                }
            }

            Assert.That(totalcount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetMetricDimensionValues()
        {
            var adminClient = GetMetricsAdvisorAdministrationClient();
            var client = GetMetricsAdvisorClient();

            DataFeed feed = await GetFirstDataFeed(adminClient);

            foreach (var metricId in feed.MetricIds)
            {
                foreach (MetricDimension dimension in feed.Schema.DimensionColumns)
                {
                    await foreach (string value in client.GetMetricDimensionValuesAsync(metricId, dimension.DimensionName))
                    {
                        Assert.That(!string.IsNullOrEmpty(value));
                    }
                }
            }
        }

        [RecordedTest]
        public async Task GetMetricSeriesData()
        {
            var client = GetMetricsAdvisorClient();

            var seriesList = await client.GetMetricSeriesDataAsync(
                MetricId,
                new GetMetricSeriesDataOptions(
                        new List<DimensionKey>()
                        {
                            new DimensionKey(new List<KeyValuePair<string, string>> {
                                new KeyValuePair<string, string>("Dim1", "*"),
                                new KeyValuePair<string, string>("Dim2", "*"),
                            }) },
                        Recording.UtcNow.AddYears(-5),
                        Recording.UtcNow)
                ).ConfigureAwait(false);

            Assert.That(seriesList.Value, Is.Not.Empty);

            foreach (MetricSeriesData seriesData in seriesList.Value)
            {
                Assert.That(seriesData, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task GetAnomaliesForDetectionConfiguration()
        {
            var client = GetMetricsAdvisorClient();

            List<DataAnomaly> anomalies = await client.GetAnomaliesForDetectionConfigurationAsync(
                DetectionConfigurationId,
                new GetAnomaliesForDetectionConfigurationOptions(Recording.UtcNow.AddYears(-5), Recording.UtcNow)
            ).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(anomalies, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetIncidentsForDetectionConfiguration()
        {
            var client = GetMetricsAdvisorClient();

            int pages = 0;

            await foreach (var incident in client.GetIncidentsForDetectionConfigurationAsync(
                 DetectionConfigurationId,
                 new GetIncidentsForDetectionConfigurationOptions(Recording.UtcNow.AddYears(-5), Recording.UtcNow) { TopCount = 1 }))
            {
                Assert.That(incident, Is.Not.Null);
                Assert.That(incident.Id, Is.Not.Null);

                // Just fetch 2 pages
                if (++pages > 2)
                {
                    break;
                }
            }

            Assert.That(pages, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetIncidentRootCauses()
        {
            var client = GetMetricsAdvisorClient();

            var rootCauses = await client.GetIncidentRootCausesAsync(
                DetectionConfigurationId,
                IncidentId
            ).ConfigureAwait(false);

            Assert.That(rootCauses.Value, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task GetValuesOfDimensionWithAnomalies()
        {
            var client = GetMetricsAdvisorClient();

            int pages = 0;

            await foreach (var value in client.GetValuesOfDimensionWithAnomaliesAsync(
                DetectionConfigurationId,
                "city",
                new GetValuesOfDimensionWithAnomaliesOptions(Recording.UtcNow.AddYears(-5), Recording.UtcNow) { TopCount = 1 }))
            {
                Assert.That(value, Is.Not.Null);

                // Just fetch 2 pages
                if (++pages > 2)
                {
                    break;
                }
            }

            Assert.That(pages, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetAlerts()
        {
            var client = GetMetricsAdvisorClient();

            int pages = 0;

            await foreach (var alert in client.GetAlertsAsync(
                AlertConfigurationId,
                new GetAlertsOptions(Recording.UtcNow.AddYears(-5), Recording.UtcNow, TimeMode.CreatedTime) { TopCount = 1 }))
            {
                Assert.That(alert.AlertId, Is.Not.Null);

                // Just fetch 2 pages
                if (++pages > 2)
                {
                    break;
                }
            }

            Assert.That(pages, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetAnomaliesForAlert()
        {
            var client = GetMetricsAdvisorClient();

            int pages = 0;

            await foreach (var anomaly in client.GetAnomaliesForAlertAsync(
                AlertConfigurationId,
                AlertId,
                new GetAnomaliesForAlertOptions() { TopCount = 1 }))
            {
                Assert.That(anomaly, Is.Not.Null);

                // Just fetch 2 pages
                if (++pages > 2)
                {
                    break;
                }
            }

            Assert.That(pages, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetIncidentsForAlert()
        {
            var client = GetMetricsAdvisorClient();

            int pages = 0;

            await foreach (var incident in client.GetIncidentsForAlertAsync(
                AlertConfigurationId,
                AlertId,
                new GetIncidentsForAlertOptions() { TopCount = 1 }))
            {
                Assert.That(incident, Is.Not.Null);

                // Just fetch 2 pages
                if (++pages > 2)
                {
                    break;
                }
            }

            Assert.That(pages, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetMetricEnrichedSeriesData()
        {
            var client = GetMetricsAdvisorClient();

            int pages = 0;

            var series = await client.GetMetricEnrichedSeriesDataAsync(
                new List<DimensionKey>()
                {
                    new DimensionKey(new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("Dim1", "Common Lime"),
                        new KeyValuePair<string, string>("Dim2", "Amphibian"),
                    }),
                    new DimensionKey(new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("Dim1", "Common Beech"),
                        new KeyValuePair<string, string>("Dim2", "Ant"),
                    })
                },
                DetectionConfigurationId,
                Recording.UtcNow.AddMonths(-5),
                Recording.UtcNow
            ).ConfigureAwait(false);

            foreach (var seriesData in series.Value)
            {
                Assert.That(seriesData, Is.Not.Null);

                // Just fetch 2 pages
                if (++pages > 2)
                {
                    break;
                }
            }

            Assert.That(pages, Is.GreaterThan(0));
        }
    }
}
