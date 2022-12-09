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
    public class AnomalyDetectionLiveTests : MetricsAdvisorLiveTestBase
    {
        public AnomalyDetectionLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAnomaliesForDetectionConfigurationWithMinimumSetup(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var options = new GetAnomaliesForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime);

            var anomalyCount = 0;

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesForDetectionConfigurationAsync(DetectionConfigurationId, options))
            {
                Assert.That(anomaly, Is.Not.Null);
                Assert.That(anomaly.DataFeedId, Is.Null);
                Assert.That(anomaly.MetricId, Is.Null);
                Assert.That(anomaly.DetectionConfigurationId, Is.Null);
                Assert.That(anomaly.CreatedOn, Is.Null);
                Assert.That(anomaly.LastModified, Is.Null);
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
        public async Task GetAnomaliesForDetectionConfigurationWithOptionalFilter()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomaliesForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime)
            {
                Filter = new AnomalyFilter(AnomalySeverity.High, AnomalySeverity.High)
            };

            var dimensions = new Dictionary<string, string>() { { "Dim1", "JPN" }, { "Dim2", "JP" } };
            var groupKey1 = new DimensionKey(dimensions);

            dimensions = new Dictionary<string, string>() { { "Dim1", "USD" } };
            var groupKey2 = new DimensionKey(dimensions);

            options.Filter.DimensionKeys.Add(groupKey1);
            options.Filter.DimensionKeys.Add(groupKey2);

            var anomalyCount = 0;

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesForDetectionConfigurationAsync(DetectionConfigurationId, options))
            {
                Assert.That(anomaly, Is.Not.Null);
                Assert.That(anomaly.DataFeedId, Is.Null);
                Assert.That(anomaly.MetricId, Is.Null);
                Assert.That(anomaly.DetectionConfigurationId, Is.Null);
                Assert.That(anomaly.CreatedOn, Is.Null);
                Assert.That(anomaly.LastModified, Is.Null);
                Assert.That(anomaly.Status, Is.Null);

                Assert.That(anomaly.Timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));
                Assert.That(anomaly.Severity, Is.EqualTo(AnomalySeverity.High));

                ValidateSeriesKey(anomaly.SeriesKey);

                anomaly.SeriesKey.TryGetValue("Dim1", out string dim1);
                anomaly.SeriesKey.TryGetValue("Dim2", out string dim2);

                Assert.That((dim1 == "JPN" && dim2 == "JP") || dim1 == "USD");

                if (++anomalyCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(anomalyCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetIncidentsForDetectionConfigurationWithMinimumSetup(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var options = new GetIncidentsForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime);

            var incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsForDetectionConfigurationAsync(DetectionConfigurationId, options))
            {
                Assert.That(incident, Is.Not.Null);
                Assert.That(incident.DataFeedId, Is.Null);
                Assert.That(incident.MetricId, Is.Null);

                Assert.That(incident.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(incident.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));
                Assert.That(incident.StartedOn, Is.GreaterThanOrEqualTo(SamplingStartTime));
                Assert.That(incident.LastDetectedOn, Is.LessThanOrEqualTo(SamplingEndTime));
                Assert.That(incident.Status, Is.Not.EqualTo(default(AnomalyIncidentStatus)));
                Assert.That(incident.Severity, Is.Not.EqualTo(default(AnomalySeverity)));

                ValidateSeriesKey(incident.RootSeriesKey);

                if (++incidentCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(incidentCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetIncidentsForDetectionConfigurationWithOptionalDimensionFilter()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetIncidentsForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime);

            var dimensions = new Dictionary<string, string>() { { "Dim1", "__SUM__" }, { "Dim2", "__SUM__" } };
            var groupKey = new DimensionKey(dimensions);

            options.DimensionKeys.Add(groupKey);

            var incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsForDetectionConfigurationAsync(DetectionConfigurationId, options))
            {
                Assert.That(incident, Is.Not.Null);
                Assert.That(incident.DataFeedId, Is.Null);
                Assert.That(incident.MetricId, Is.Null);

                Assert.That(incident.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(incident.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));
                Assert.That(incident.StartedOn, Is.GreaterThanOrEqualTo(SamplingStartTime));
                Assert.That(incident.LastDetectedOn, Is.LessThanOrEqualTo(SamplingEndTime));
                Assert.That(incident.Status, Is.Not.EqualTo(default(AnomalyIncidentStatus)));
                Assert.That(incident.Severity, Is.Not.EqualTo(default(AnomalySeverity)));

                ValidateSeriesKey(incident.RootSeriesKey);

                incident.RootSeriesKey.TryGetValue("Dim1", out string dim1);
                incident.RootSeriesKey.TryGetValue("Dim2", out string dim2);

                Assert.That(dim1 == "__SUM__" && dim2 == "__SUM__");

                if (++incidentCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(incidentCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetIncidentRootCauses(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

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
            const string incidentId = "88ecf25a0e6bd330ef9e7b49b7c5b92b-17fc385cc00";

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            AnomalyIncident incident = null;
            var options = new GetIncidentsForDetectionConfigurationOptions(SamplingStartTime, SamplingEndTime);

            await foreach (AnomalyIncident currentIncident in client.GetIncidentsForDetectionConfigurationAsync(DetectionConfigurationId, options))
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

        [RecordedTest]
        public async Task GetIncidentRootCausesForIncidentFromAlert()
        {
            const string incidentId = "88ecf25a0e6bd330ef9e7b49b7c5b92b-17f9f794800";

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            AnomalyIncident incident = null;

            await foreach (AnomalyIncident currentIncident in client.GetIncidentsForAlertAsync(AlertConfigurationId, AlertId))
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

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAnomalyDimensionValuesWithMinimumSetup(bool useTokenCredential)
        {
            const string dimensionName = "Dim1";

            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var options = new GetAnomalyDimensionValuesOptions(SamplingStartTime, SamplingEndTime);

            var valueCount = 0;

            await foreach (string value in client.GetAnomalyDimensionValuesAsync(DetectionConfigurationId, dimensionName, options))
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
        public async Task GetAnomalyDimensionValuesWithOptionalDimensionFilter()
        {
            const string dimensionName = "Dim1";

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensions = new Dictionary<string, string>() { { "Dim2", "JP" } };
            var options = new GetAnomalyDimensionValuesOptions(SamplingStartTime, SamplingEndTime)
            {
                SeriesGroupKey = new DimensionKey(dimensions)
            };

            var valueCount = 0;

            await foreach (string value in client.GetAnomalyDimensionValuesAsync(DetectionConfigurationId, dimensionName, options))
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetMetricEnrichedSeriesData(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var dimensions = new Dictionary<string, string>() { { "Dim1", "JPN" }, { "Dim2", "JP" } };
            var seriesKey1 = new DimensionKey(dimensions);

            dimensions = new Dictionary<string, string>() { { "Dim1", "USD" }, { "Dim2", "__SUM__" } };
            var seriesKey2 = new DimensionKey(dimensions);

            var seriesKeys = new List<DimensionKey>() { seriesKey1, seriesKey2 };
            var returnedKeys = new List<DimensionKey>();

            await foreach (MetricEnrichedSeriesData seriesData in client.GetMetricEnrichedSeriesDataAsync(DetectionConfigurationId, seriesKeys, SamplingStartTime, SamplingEndTime))
            {
                Assert.That(seriesData, Is.Not.Null);
                Assert.That(seriesData.SeriesKey, Is.Not.Null);
                Assert.That(seriesData.Timestamps, Is.Not.Null);
                Assert.That(seriesData.MetricValues, Is.Not.Null);
                Assert.That(seriesData.ExpectedMetricValues, Is.Not.Null);
                Assert.That(seriesData.IsAnomaly, Is.Not.Null);
                Assert.That(seriesData.Periods, Is.Not.Null);
                Assert.That(seriesData.LowerBoundaryValues, Is.Not.Null);
                Assert.That(seriesData.UpperBoundaryValues, Is.Not.Null);

                int pointsCount = seriesData.Timestamps.Count;

                Assert.That(seriesData.MetricValues.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.ExpectedMetricValues.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.IsAnomaly.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.Periods.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.LowerBoundaryValues.Count, Is.EqualTo(pointsCount));
                Assert.That(seriesData.UpperBoundaryValues.Count, Is.EqualTo(pointsCount));

                foreach (DateTimeOffset timestamp in seriesData.Timestamps)
                {
                    Assert.That(timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));
                }

                returnedKeys.Add(seriesData.SeriesKey);
            }

            // Making sure count is exactly 2 because the logic below relies on that.
            Assert.That(seriesKeys.Count, Is.EqualTo(2));
            Assert.That(returnedKeys.Count, Is.EqualTo(2));

            if (AreSame(seriesKeys[0], returnedKeys[0]))
            {
                Assert.That(seriesKeys[1], Is.EquivalentTo(returnedKeys[1]));
            }
            else
            {
                Assert.That(seriesKeys[0], Is.EquivalentTo(returnedKeys[1]));
                Assert.That(seriesKeys[1], Is.EquivalentTo(returnedKeys[0]));
            }
        }

        private void ValidateIncidentRootCause(IncidentRootCause rootCause)
        {
            Assert.That(rootCause, Is.Not.Null);
            Assert.That(rootCause.Description, Is.Not.Null.And.Not.Empty);
            Assert.That(rootCause.ContributionScore, Is.GreaterThan(0.0).And.LessThanOrEqualTo(1.0));

            foreach (string path in rootCause.Paths)
            {
                Assert.That(path, Is.Not.Null.And.Not.Empty);
            }

            ValidateSeriesKey(rootCause.SeriesKey);
        }

        private bool AreSame(DimensionKey left, DimensionKey right)
        {
            if (left.Dimension.Count != right.Dimension.Count)
            {
                return false;
            }

            foreach (KeyValuePair<string, string> kvp in left)
            {
                if (!right.TryGetValue(kvp.Key, out string value) || value != kvp.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
