// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [Test]
        public async Task GetIncidentsForDetectionConfigurationAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string detectionConfigurationId = DetectionConfigurationId;

            // Only incidents from time series that are part of one of the groups specified
            // will be returned.

            var groupKey1 = new DimensionKey();
            groupKey1.AddDimensionColumn("city", "Bengaluru");

            var groupKey2 = new DimensionKey();
            groupKey2.AddDimensionColumn("city", "Hong Kong");
            groupKey2.AddDimensionColumn("category", "Industrial & Scientific");

            var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endTime = DateTimeOffset.UtcNow;
            var options = new GetIncidentsForDetectionConfigurationOptions(startTime, endTime)
            {
                DimensionsToFilter = new List<DimensionKey>() { groupKey1, groupKey2 },
                TopCount = 3
            };

            int incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsAsync(detectionConfigurationId, options))
            {
                Console.WriteLine($"Incident ID: {incident.Id}");
                Console.WriteLine($"First associated anomaly occurred at: {incident.StartTime}");
                Console.WriteLine($"Last associated anomaly occurred at: {incident.LastTime}");
                Console.WriteLine($"Status: {incident.Status}");
                Console.WriteLine($"Severity: {incident.Severity}");
                Console.WriteLine("Series key:");

                foreach (KeyValuePair<string, string> keyValuePair in incident.DimensionKey.AsDictionary())
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine();

                // Print at most 3 incidents.
                if (++incidentCount >= 3)
                {
                    break;
                }
            }
        }

        [Test]
        public async Task GetIncidentsForAlertAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string alertConfigurationId = AlertConfigurationId;
            string alertId = AlertId;

            var options = new GetIncidentsForAlertOptions() { TopCount = 3 };

            int incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsAsync(alertConfigurationId, alertId, options))
            {
                Console.WriteLine($"Incident ID: {incident.Id}");
                Console.WriteLine($"Metric ID: {incident.MetricId}");
                Console.WriteLine($"Detection configuration ID: {incident.DetectionConfigurationId}");
                Console.WriteLine($"First associated anomaly occurred at: {incident.StartTime}");
                Console.WriteLine($"Last associated anomaly occurred at: {incident.LastTime}");
                Console.WriteLine($"Status: {incident.Status}");
                Console.WriteLine($"Severity: {incident.Severity}");
                Console.WriteLine("Series key:");

                foreach (KeyValuePair<string, string> keyValuePair in incident.DimensionKey.AsDictionary())
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine();

                // Print at most 3 incidents.
                if (++incidentCount >= 3)
                {
                    break;
                }
            }
        }

        [Test]
        public async Task GetIncidentRootCausesAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string detectionConfigurationId = DetectionConfigurationId;
            string incidentId = IncidentId;

            int rootCauseCount = 0;

            await foreach (IncidentRootCause rootCause in client.GetIncidentRootCausesAsync(detectionConfigurationId, incidentId))
            {
                Console.WriteLine($"Root cause description: {rootCause.Description}");
                Console.WriteLine($"Score: {rootCause.Score}");
                Console.WriteLine("Paths:");

                foreach (string path in rootCause.Paths)
                {
                    Console.WriteLine($"  {path}");
                }

                Console.WriteLine("Series key:");

                foreach (KeyValuePair<string, string> keyValuePair in rootCause.DimensionKey.AsDictionary())
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine();

                // Print at most 3 root causes.
                if (++rootCauseCount >= 3)
                {
                    break;
                }
            }
        }
    }
}
