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
    public class MetricsAdvisorClientLiveTests : MetricsAdvisorLiveTestBase
    {
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
                        Assert.That(metricDef.SeriesKey.Dimension.Count, Is.Not.Zero);

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
                foreach (DataFeedDimension dimension in feed.Schema.DimensionColumns)
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

            var options = new GetMetricSeriesDataOptions(
                new List<DimensionKey>()
                {
                    new DimensionKey(new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("Dim1", "*"),
                        new KeyValuePair<string, string>("Dim2", "*"),
                    }) },
                Recording.UtcNow.AddYears(-5),
                Recording.UtcNow);

            bool isResponseEmpty = true;

            await foreach (MetricSeriesData seriesData in client.GetMetricSeriesDataAsync(MetricId, options))
            {
                isResponseEmpty = false;
                Assert.That(seriesData, Is.Not.Null);
            }

            Assert.That(isResponseEmpty, Is.False);
        }

        [RecordedTest]
        public async Task GetAnomaliesForDetectionConfiguration()
        {
            var client = GetMetricsAdvisorClient();

            List<DataPointAnomaly> anomalies = await client.GetAnomaliesForDetectionConfigurationAsync(
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

            bool isResponseEmpty = true;

            await foreach (IncidentRootCause rootCause in client.GetIncidentRootCausesAsync(DetectionConfigurationId, IncidentId))
            {
                isResponseEmpty = false;
                break;
            }

            Assert.That(isResponseEmpty, Is.False);
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
                new GetAlertsOptions(Recording.UtcNow.AddYears(-5), Recording.UtcNow, AlertQueryTimeMode.CreatedTime) { TopCount = 1 }))
            {
                Assert.That(alert.Id, Is.Not.Null);

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

            IEnumerable<DimensionKey> seriesKeys = new List<DimensionKey>()
            {
                new DimensionKey(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("Dim1", "Common Lime"),
                    new KeyValuePair<string, string>("Dim2", "Amphibian"),
                }),
                new DimensionKey(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("Dim1", "Common Beech"),
                    new KeyValuePair<string, string>("Dim2", "Ant"),
                })
            };

            int pages = 0;

            await foreach (MetricEnrichedSeriesData seriesData in client.GetMetricEnrichedSeriesDataAsync(seriesKeys, DetectionConfigurationId, Recording.UtcNow.AddMonths(-5), Recording.UtcNow))
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

        [RecordedTest]
        public async Task GetEnrichmentStatus()
        {
            var client = GetMetricsAdvisorClient();

            int pages = 0;

            await foreach (var status in client.GetMetricEnrichmentStatusesAsync(MetricId, new GetMetricEnrichmentStatusesOptions(Recording.UtcNow.AddYears(-5), Recording.UtcNow) { TopCount = 2 }))
            {
                Assert.That(status, Is.Not.Null);

                // Just fetch 2 pages
                if (++pages > 2)
                {
                    break;
                }
            }

            Assert.That(pages, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetMetricFeedbacks()
        {
            var client = GetMetricsAdvisorClient();

            int pages = 0;

            await foreach (MetricFeedback feedback in client.GetMetricFeedbacksAsync(MetricId, new GetMetricFeedbacksOptions() { TopCount = 2 }))
            {
                Assert.That(feedback, Is.Not.Null);
                Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
                switch (feedback.Type.ToString())
                {
                    case "Anomaly":
                        Assert.That(feedback is MetricAnomalyFeedback);
                        break;
                    case "ChangePoint":
                        Assert.That(feedback is MetricChangePointFeedback);
                        break;
                    case "Period":
                        Assert.That(feedback is MetricPeriodFeedback);
                        break;
                    case "Comment":
                        Assert.That(feedback is MetricCommentFeedback);
                        break;
                    default:
                        Assert.Fail("Unexpected MetricFeedback type");
                        break;
                }

                // Just fetch 2 pages
                if (++pages > 2)
                {
                    break;
                }
            }

            Assert.That(pages, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task CreateMetricFeedback()
        {
            var client = GetMetricsAdvisorClient();
            FeedbackDimensionFilter dimensionFilter = new FeedbackDimensionFilter(
                new DimensionKey(
                    new Dictionary<string, string>
                    {
                        {"Dim1", "Common Lime"},
                        {"Dim2", "Ant"}
                    }));
            DateTimeOffset start = Recording.UtcNow.AddMonths(-4);
            DateTimeOffset end = Recording.UtcNow;

            MetricAnomalyFeedback anomalyFeedback = new MetricAnomalyFeedback(MetricId, dimensionFilter, start, end, AnomalyValue.NotAnomaly);
            MetricChangePointFeedback changePointFeedback = new MetricChangePointFeedback(MetricId, dimensionFilter, start, end, ChangePointValue.NotChangePoint);
            MetricPeriodFeedback periodFeedback = new MetricPeriodFeedback(MetricId, dimensionFilter, PeriodType.AssignValue, 5);
            MetricCommentFeedback commentFeedback = new MetricCommentFeedback(MetricId, dimensionFilter, "my comment");

            var feedbacks = new List<MetricFeedback>
            {
                anomalyFeedback,
                changePointFeedback,
                periodFeedback,
                commentFeedback
            };

            foreach (var feedback in feedbacks)
            {
                MetricFeedback createdFeedback = await client.CreateMetricFeedbackAsync(feedback).ConfigureAwait(false);

                Assert.That(createdFeedback.MetricId, Is.EqualTo(MetricId));
                Assert.That(createdFeedback.Id, Is.Not.Null);

                MetricFeedback getFeedback = await client.GetMetricFeedbackAsync(feedbackId: createdFeedback.Id).ConfigureAwait(false);

                Assert.That(getFeedback.Id, Is.EqualTo(createdFeedback.Id));
            }
        }
    }
}
