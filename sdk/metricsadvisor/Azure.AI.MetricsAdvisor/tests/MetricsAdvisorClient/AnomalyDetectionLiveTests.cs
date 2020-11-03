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
        public async Task GetAnomalies(bool populateOptionalMembers)
        {
            const int maximumAnomalySamples = 10;

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var startTime = DateTimeOffset.Parse("2020-10-01T00:00:00Z");
            var endTime = DateTimeOffset.Parse("2020-10-31T00:00:00Z");

            var options = new GetAnomaliesForDetectionConfigurationOptions(startTime, endTime);

            if (populateOptionalMembers)
            {
                options.Filter = new GetAnomaliesForDetectionConfigurationFilter(AnomalySeverity.Medium, AnomalySeverity.Medium);

                var groupKey1 = new DimensionKey();
                groupKey1.AddDimensionColumn("city", "Delhi");
                groupKey1.AddDimensionColumn("category", "Handmade");

                var groupKey2 = new DimensionKey();
                groupKey2.AddDimensionColumn("city", "Kolkata");

                options.Filter.SeriesGroupKeys.Add(groupKey1);
                options.Filter.SeriesGroupKeys.Add(groupKey2);
            }

            var anomalyCount = 0;

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesAsync(DetectionConfigurationId, options))
            {
                Assert.That(anomaly.AnomalyDetectionConfigurationId, Is.Null);
                Assert.That(anomaly.MetricId, Is.Null);
                Assert.That(anomaly.CreatedTime, Is.Null);
                Assert.That(anomaly.ModifiedTime, Is.Null);
                Assert.That(anomaly.Status, Is.Null);

                Assert.That(anomaly.Timestamp, Is.InRange(startTime, endTime));
                Assert.That(anomaly.Severity, Is.Not.EqualTo(default(AnomalySeverity)));
                Assert.That(anomaly.SeriesKey, Is.Not.Null);

                Dictionary<string, string> dimensionColumns = anomaly.SeriesKey.AsDictionary();

                Assert.That(dimensionColumns.Count, Is.EqualTo(2));
                Assert.That(dimensionColumns.ContainsKey("city"));
                Assert.That(dimensionColumns.ContainsKey("category"));

                string city = dimensionColumns["city"];
                string category = dimensionColumns["category"];

                Assert.That(city, Is.Not.Null.And.Not.Empty);
                Assert.That(category, Is.Not.Null.And.Not.Empty);

                if (populateOptionalMembers)
                {
                    Assert.That(anomaly.Severity, Is.EqualTo(AnomalySeverity.Medium));
                    Assert.That((city == "Delhi" && category == "Handmade") || city == "Kolkata");
                }

                if (++anomalyCount >= maximumAnomalySamples)
                {
                    break;
                }
            }

            Assert.That(anomalyCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetIncidents(bool populateOptionalMembers)
        {
            const int maximumIncidentSamples = 10;

            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var startTime = DateTimeOffset.Parse("2020-10-01T00:00:00Z");
            var endTime = DateTimeOffset.Parse("2020-10-31T00:00:00Z");

            var options = new GetIncidentsForDetectionConfigurationOptions(startTime, endTime);

            if (populateOptionalMembers)
            {
                var groupKey1 = new DimensionKey();
                groupKey1.AddDimensionColumn("city", "Delhi");
                groupKey1.AddDimensionColumn("category", "Handmade");

                var groupKey2 = new DimensionKey();
                groupKey2.AddDimensionColumn("city", "Kolkata");

                options.DimensionsToFilter.Add(groupKey1);
                options.DimensionsToFilter.Add(groupKey2);
            }

            var incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsAsync(DetectionConfigurationId, options))
            {
                Assert.That(incident.DetectionConfigurationId, Is.Null);
                Assert.That(incident.MetricId, Is.Null);

                Assert.That(incident.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(incident.StartTime, Is.GreaterThanOrEqualTo(startTime));
                Assert.That(incident.LastTime, Is.LessThanOrEqualTo(endTime));
                Assert.That(incident.Status, Is.Not.EqualTo(default(AnomalyIncidentStatus)));
                Assert.That(incident.Severity, Is.Not.EqualTo(default(AnomalySeverity)));

                Assert.That(incident.DimensionKey, Is.Not.Null);

                Dictionary<string, string> dimensionColumns = incident.DimensionKey.AsDictionary();

                Assert.That(dimensionColumns.Count, Is.EqualTo(2));
                Assert.That(dimensionColumns.ContainsKey("city"));
                Assert.That(dimensionColumns.ContainsKey("category"));

                string city = dimensionColumns["city"];
                string category = dimensionColumns["category"];

                Assert.That(city, Is.Not.Null.And.Not.Empty);
                Assert.That(category, Is.Not.Null.And.Not.Empty);

                if (populateOptionalMembers)
                {
                    Assert.That((city == "Delhi" && category == "Handmade") || city == "Kolkata");
                }

                if (++incidentCount >= maximumIncidentSamples)
                {
                    break;
                }
            }

            Assert.That(incidentCount, Is.GreaterThan(0));
        }
    }
}
