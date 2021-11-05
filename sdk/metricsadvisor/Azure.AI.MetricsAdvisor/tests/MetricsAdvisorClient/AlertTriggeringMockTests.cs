// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class AlertTriggeringMockTests : MockClientTestBase
    {
        public AlertTriggeringMockTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetAnomaliesForAlertSetsValue()
        {
            double originalValue = 3.14;

            using Stream responseBody = CreateAnomalyJsonStream(value: originalValue);
            MockResponse mockResponse = new MockResponse(200) { ContentStream = responseBody };

            MetricsAdvisorClient client = CreateInstrumentedClient(mockResponse);

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesForAlertAsync(FakeGuid, "alertId"))
            {
                Assert.That(anomaly.Value, Is.EqualTo(originalValue));
            }
        }

        [Test]
        public async Task GetAnomaliesForAlertSetsNullExpectedValue()
        {
            using Stream responseBody = CreateAnomalyJsonStream(expectedValue: null);
            MockResponse mockResponse = new MockResponse(200) { ContentStream = responseBody };

            MetricsAdvisorClient client = CreateInstrumentedClient(mockResponse);

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesForAlertAsync(FakeGuid, "alertId"))
            {
                Assert.That(anomaly.ExpectedValue, Is.Null);
            }
        }

        [Test]
        public async Task GetAnomaliesForAlertSetsExpectedValue()
        {
            double originalExpectedValue = 1.62;

            using Stream responseBody = CreateAnomalyJsonStream(expectedValue: originalExpectedValue);
            MockResponse mockResponse = new MockResponse(200) { ContentStream = responseBody };

            MetricsAdvisorClient client = CreateInstrumentedClient(mockResponse);

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesForAlertAsync(FakeGuid, "alertId"))
            {
                Assert.That(anomaly.ExpectedValue, Is.EqualTo(originalExpectedValue));
            }
        }

        [Test]
        public async Task GetIncidentsForAlertSetsValueOfRootNode()
        {
            double originalValue = 3.14;

            using Stream responseBody = CreateIncidentJsonStream(valueOfRootNode: originalValue);
            MockResponse mockResponse = new MockResponse(200) { ContentStream = responseBody };

            MetricsAdvisorClient client = CreateInstrumentedClient(mockResponse);

            await foreach (AnomalyIncident incident in client.GetIncidentsForAlertAsync(FakeGuid, "alertId"))
            {
                Assert.That(incident.ValueOfRootNode, Is.EqualTo(originalValue));
            }
        }

        [Test]
        public async Task GetIncidentsForAlertSetsNullExpectedValueOfRootNode()
        {
            using Stream responseBody = CreateIncidentJsonStream(expectedValueOfRootNode: null);
            MockResponse mockResponse = new MockResponse(200) { ContentStream = responseBody };

            MetricsAdvisorClient client = CreateInstrumentedClient(mockResponse);

            await foreach (AnomalyIncident incident in client.GetIncidentsForAlertAsync(FakeGuid, "alertId"))
            {
                Assert.That(incident.ExpectedValueOfRootNode, Is.Null);
            }
        }

        [Test]
        public async Task GetIncidentsForAlertSetsExpectedValueOfRootNode()
        {
            double originalValue = 1.62;

            using Stream responseBody = CreateIncidentJsonStream(expectedValueOfRootNode: originalValue);
            MockResponse mockResponse = new MockResponse(200) { ContentStream = responseBody };

            MetricsAdvisorClient client = CreateInstrumentedClient(mockResponse);

            await foreach (AnomalyIncident incident in client.GetIncidentsForAlertAsync(FakeGuid, "alertId"))
            {
                Assert.That(incident.ExpectedValueOfRootNode, Is.EqualTo(originalValue));
            }
        }
    }
}
