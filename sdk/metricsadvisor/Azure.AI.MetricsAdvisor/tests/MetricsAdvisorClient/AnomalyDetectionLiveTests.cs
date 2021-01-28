// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class AnomalyDetectionLiveTests : MetricsAdvisorLiveTestBase
    {
        public AnomalyDetectionLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetAnomaliesWithMinimumSetup()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomaliesForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime);

            var anomalyCount = 0;

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesAsync(DetectionConfigurationId, options))
            {
                Assert.That(anomaly, Is.Not.Null);
                Assert.That(anomaly.MetricId, Is.Null);
                Assert.That(anomaly.AnomalyDetectionConfigurationId, Is.Null);
                Assert.That(anomaly.CreatedTime, Is.Null);
                Assert.That(anomaly.ModifiedTime, Is.Null);
                Assert.That(anomaly.Status, Is.Null);

                Assert.That(anomaly.Timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));
                Assert.That(anomaly.Severity, Is.Not.EqualTo(default(AnomalySeverity)));

                ValidateSeriesKey(anomaly.SeriesKey);

                if (++anomalyCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(anomalyCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetAnomaliesWithOptionalFilter()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomaliesForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime)
            {
                Filter = new GetAnomaliesForDetectionConfigurationFilter(AnomalySeverity.Medium, AnomalySeverity.Medium)
            };

            var groupKey1 = new DimensionKey();
            groupKey1.AddDimensionColumn("city", "Delhi");
            groupKey1.AddDimensionColumn("category", "Handmade");

            var groupKey2 = new DimensionKey();
            groupKey2.AddDimensionColumn("city", "Kolkata");

            options.Filter.SeriesGroupKeys.Add(groupKey1);
            options.Filter.SeriesGroupKeys.Add(groupKey2);

            var anomalyCount = 0;

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesAsync(DetectionConfigurationId, options))
            {
                Assert.That(anomaly, Is.Not.Null);
                Assert.That(anomaly.MetricId, Is.Null);
                Assert.That(anomaly.AnomalyDetectionConfigurationId, Is.Null);
                Assert.That(anomaly.CreatedTime, Is.Null);
                Assert.That(anomaly.ModifiedTime, Is.Null);
                Assert.That(anomaly.Status, Is.Null);

                Assert.That(anomaly.Timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));
                Assert.That(anomaly.Severity, Is.EqualTo(AnomalySeverity.Medium));

                ValidateSeriesKey(anomaly.SeriesKey);

                Dictionary<string, string> dimensionColumns = anomaly.SeriesKey.AsDictionary();

                string city = dimensionColumns["city"];
                string category = dimensionColumns["category"];

                Assert.That((city == "Delhi" && category == "Handmade") || city == "Kolkata");

                if (++anomalyCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(anomalyCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetIncidentsWithMinimumSetup()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetIncidentsForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime);

            var incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsAsync(DetectionConfigurationId, options))
            {
                Assert.That(incident, Is.Not.Null);
                Assert.That(incident.MetricId, Is.Null);

                Assert.That(incident.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(incident.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));
                Assert.That(incident.StartTime, Is.GreaterThanOrEqualTo(SamplingStartTime));
                Assert.That(incident.LastTime, Is.LessThanOrEqualTo(SamplingEndTime));
                Assert.That(incident.Status, Is.Not.EqualTo(default(AnomalyIncidentStatus)));
                Assert.That(incident.Severity, Is.Not.EqualTo(default(AnomalySeverity)));

                ValidateSeriesKey(incident.DimensionKey);

                if (++incidentCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(incidentCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetIncidentsWithOptionalDimensionFilter()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetIncidentsForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime);

            var groupKey1 = new DimensionKey();
            groupKey1.AddDimensionColumn("city", "Delhi");
            groupKey1.AddDimensionColumn("category", "Handmade");

            var groupKey2 = new DimensionKey();
            groupKey2.AddDimensionColumn("city", "Kolkata");

            options.DimensionsToFilter.Add(groupKey1);
            options.DimensionsToFilter.Add(groupKey2);

            var incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsAsync(DetectionConfigurationId, options))
            {
                Assert.That(incident, Is.Not.Null);
                Assert.That(incident.MetricId, Is.Null);

                Assert.That(incident.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(incident.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));
                Assert.That(incident.StartTime, Is.GreaterThanOrEqualTo(SamplingStartTime));
                Assert.That(incident.LastTime, Is.LessThanOrEqualTo(SamplingEndTime));
                Assert.That(incident.Status, Is.Not.EqualTo(default(AnomalyIncidentStatus)));
                Assert.That(incident.Severity, Is.Not.EqualTo(default(AnomalySeverity)));

                ValidateSeriesKey(incident.DimensionKey);

                Dictionary<string, string> dimensionColumns = incident.DimensionKey.AsDictionary();

                string city = dimensionColumns["city"];
                string category = dimensionColumns["category"];

                Assert.That((city == "Delhi" && category == "Handmade") || city == "Kolkata");

                if (++incidentCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(incidentCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetIncidentRootCauses()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var rootCauseCount = 0;

            await foreach (IncidentRootCause rootCause in client.GetIncidentRootCausesAsync(DetectionConfigurationId, IncidentId))
            {
                ValidateIncidentRootCause(rootCause);

                if (++rootCauseCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(rootCauseCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetIncidentRootCausesForIncidentFromDetectionConfiguration()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            AnomalyIncident incident = null;
            var options = new GetIncidentsForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime);

            // We already know the the incident we want to get, so apply filters to make the
            // service call cheaper.

            var groupKey = new DimensionKey();
            groupKey.AddDimensionColumn("city", "__SUM__");
            groupKey.AddDimensionColumn("category", "Grocery & Gourmet Food");

            options.DimensionsToFilter.Add(groupKey);

            await foreach (AnomalyIncident currentIncident in client.GetIncidentsAsync(DetectionConfigurationId, options))
            {
                if (currentIncident.Id == IncidentId)
                {
                    incident = currentIncident;
                    break;
                }
            }

            Assert.That(incident, Is.Not.Null);

            var rootCauseCount = 0;

            await foreach (IncidentRootCause rootCause in client.GetIncidentRootCausesAsync(incident))
            {
                ValidateIncidentRootCause(rootCause);

                if (++rootCauseCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(rootCauseCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetIncidentRootCausesForIncidentFromAlert()
        {
            const string incidentId = "5a0692283edccf37ce825b3a8d475f4e-17571a77000";

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            AnomalyIncident incident = null;

            await foreach (AnomalyIncident currentIncident in client.GetIncidentsAsync(AlertConfigurationId, AlertId))
            {
                if (currentIncident.Id == incidentId)
                {
                    incident = currentIncident;
                    break;
                }
            }

            Assert.That(incident, Is.Not.Null);

            var rootCauseCount = 0;

            await foreach (IncidentRootCause rootCause in client.GetIncidentRootCausesAsync(incident))
            {
                ValidateIncidentRootCause(rootCause);

                if (++rootCauseCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(rootCauseCount, Is.GreaterThan(0));
        }

        /// <param name="populateOptionalMembers">
        /// When <c>true</c>, all optional properties are populated to make sure values are being passed and returned
        /// correctly. When <c>false</c>, the test makes sure it's still possible to make a request with the minimum
        /// configuration and that the responses with <c>null</c> and <c>default</c> values can be parsed by the client.
        /// </param>
        [RecordedTest]
        public async Task GetValuesOfDimensionWithAnomaliesWithMinimumSetup()
        {
            const string dimensionName = "city";

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetValuesOfDimensionWithAnomaliesOptions(SamplingStartTime, SamplingEndTime);

            var valueCount = 0;

            await foreach (string value in client.GetValuesOfDimensionWithAnomaliesAsync(DetectionConfigurationId, dimensionName, options))
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
        public async Task GetValuesOfDimensionWithAnomaliesWithOptionalDimensionFilter()
        {
            const string dimensionName = "city";

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetValuesOfDimensionWithAnomaliesOptions(SamplingStartTime, SamplingEndTime)
            {
                DimensionToFilter = new DimensionKey()
            };

            options.DimensionToFilter.AddDimensionColumn("category", "Handmade");

            var valueCount = 0;

            await foreach (string value in client.GetValuesOfDimensionWithAnomaliesAsync(DetectionConfigurationId, dimensionName, options))
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
        public async Task GetMetricEnrichedSeriesData()
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

            await foreach (MetricEnrichedSeriesData seriesData in client.GetMetricEnrichedSeriesDataAsync(seriesKeys, DetectionConfigurationId, SamplingStartTime, SamplingEndTime))
            {
                Assert.That(seriesData, Is.Not.Null);
                Assert.That(seriesData.SeriesKey, Is.Not.Null);
                Assert.That(seriesData.Timestamps, Is.Not.Null);
                Assert.That(seriesData.Values, Is.Not.Null);
                Assert.That(seriesData.ExpectedValues, Is.Not.Null);
                Assert.That(seriesData.IsAnomaly, Is.Not.Null);
                Assert.That(seriesData.Periods, Is.Not.Null);
                Assert.That(seriesData.LowerBoundaries, Is.Not.Null);
                Assert.That(seriesData.UpperBoundaries, Is.Not.Null);

                int pointsCount = seriesData.Timestamps.Count;

                Assert.That(seriesData.Values.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.ExpectedValues.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.IsAnomaly.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.Periods.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.LowerBoundaries.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.UpperBoundaries.Count, Is.EqualTo(pointsCount));

                foreach (DateTimeOffset timestamp in seriesData.Timestamps)
                {
                    Assert.That(timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));
                }

                returnedKeys.Add(seriesData.SeriesKey);
            }

            IEnumerable<List<KeyValuePair<string, string>>> expectedKvps = seriesKeys.Select(key => key.AsDictionary().ToList());
            IEnumerable<List<KeyValuePair<string, string>>> returnedKvps = returnedKeys.Select(key => key.AsDictionary().ToList());

            Assert.That(returnedKvps, Is.EquivalentTo(expectedKvps));
        }

        private void ValidateIncidentRootCause(IncidentRootCause rootCause)
        {
            Assert.That(rootCause, Is.Not.Null);
            Assert.That(rootCause.Description, Is.Not.Null.And.Not.Empty);
            Assert.That(rootCause.Score, Is.GreaterThan(0.0).And.LessThanOrEqualTo(1.0));

            foreach (string path in rootCause.Paths)
            {
                Assert.That(path, Is.Not.Null.And.Not.Empty);
            }

            ValidateSeriesKey(rootCause.DimensionKey);
        }
    }
}
