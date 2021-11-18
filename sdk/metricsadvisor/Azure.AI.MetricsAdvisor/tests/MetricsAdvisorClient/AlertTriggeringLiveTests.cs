// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class AlertTriggeringLiveTests : MetricsAdvisorLiveTestBase
    {
        public AlertTriggeringLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase("anomalyDetectedOn")]
        [TestCase("createdOn")]
        [TestCase("lastModified")]
        public async Task GetAlerts(string timeModeName)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            AlertQueryTimeMode timeMode = timeModeName switch
            {
                "anomalyDetectedOn" => AlertQueryTimeMode.AnomalyDetectedOn,
                "createdOn" => AlertQueryTimeMode.CreatedOn,
                "lastModified" => AlertQueryTimeMode.LastModified,
                _ => throw new ArgumentOutOfRangeException("Invalid test case.")
            };

            var options = new GetAlertsOptions(SamplingStartTime, SamplingEndTime, timeMode);

            var alertCount = 0;

            await foreach (AnomalyAlert alert in client.GetAlertsAsync(AlertConfigurationId, options))
            {
                Assert.That(alert, Is.Not.Null);
                Assert.That(alert.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(alert.Timestamp, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(alert.CreatedOn, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(alert.LastModified, Is.Not.EqualTo(default(DateTimeOffset)));

                DateTimeOffset filteredTime = timeModeName switch
                {
                    "anomalyDetectedOn" => alert.Timestamp,
                    "createdOn" => alert.CreatedOn,
                    "lastModified" => alert.LastModified,
                    _ => throw new ArgumentOutOfRangeException("Invalid test case.")
                };

                Assert.That(filteredTime, Is.InRange(SamplingStartTime, SamplingEndTime));

                if (++alertCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(alertCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetAlertsWithTokenCredential()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential: true);

            var options = new GetAlertsOptions(SamplingStartTime, SamplingEndTime, AlertQueryTimeMode.AnomalyDetectedOn);

            var alertCount = 0;

            await foreach (AnomalyAlert alert in client.GetAlertsAsync(AlertConfigurationId, options))
            {
                Assert.That(alert, Is.Not.Null);
                Assert.That(alert.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(alert.Timestamp, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(alert.CreatedOn, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(alert.LastModified, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(alert.Timestamp, Is.InRange(SamplingStartTime, SamplingEndTime));

                if (++alertCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(alertCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAnomaliesForAlert(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var anomalyCount = 0;

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesForAlertAsync(AlertConfigurationId, AlertId))
            {
                Assert.That(anomaly, Is.Not.Null);
                Assert.That(anomaly.DataFeedId, Is.Not.Null.And.Not.Empty);
                Assert.That(anomaly.MetricId, Is.Not.Null.And.Not.Empty);
                Assert.That(anomaly.DetectionConfigurationId, Is.Not.Null.And.Not.Empty);
                Assert.That(anomaly.Timestamp, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(anomaly.CreatedOn, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(anomaly.LastModified, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(anomaly.Status, Is.Not.EqualTo(default(AnomalyStatus)));
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetIncidentsForAlert(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsForAlertAsync(AlertConfigurationId, AlertId))
            {
                Assert.That(incident, Is.Not.Null);

                Assert.That(incident.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(incident.DataFeedId, Is.Not.Null.And.Not.Empty);
                Assert.That(incident.MetricId, Is.Not.Null.And.Not.Empty);
                Assert.That(incident.DetectionConfigurationId, Is.Not.Null.And.Not.Empty);
                Assert.That(incident.StartedOn, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(incident.LastDetectedOn, Is.Not.EqualTo(default(DateTimeOffset)));
                Assert.That(incident.Status, Is.Not.EqualTo(default(AnomalyIncidentStatus)));
                // Service bug: https://github.com/Azure/azure-sdk-for-net/issues/16581
                //Assert.That(incident.Severity, Is.Not.EqualTo(default(AnomalySeverity)));

                ValidateSeriesKey(incident.RootSeriesKey);

                if (++incidentCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(incidentCount, Is.GreaterThan(0));
        }
    }
}
