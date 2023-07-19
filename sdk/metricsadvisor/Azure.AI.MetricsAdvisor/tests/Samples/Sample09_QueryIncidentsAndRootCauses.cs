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

            var dimensions = new Dictionary<string, string>()
            {
                { "region", "Bengaluru" }
            };
            var groupKey1 = new DimensionKey(dimensions);

            dimensions = new Dictionary<string, string>()
            {
                { "region", "Hong Kong" },
                { "category", "Industrial & Scientific" }
            };
            var groupKey2 = new DimensionKey(dimensions);

            var startsOn = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endsOn = DateTimeOffset.UtcNow;
            var options = new GetIncidentsForDetectionConfigurationOptions(startsOn, endsOn) { MaxPageSize = 3 };

            options.DimensionKeys.Add(groupKey1);
            options.DimensionKeys.Add(groupKey2);

            int incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsForDetectionConfigurationAsync(detectionConfigurationId, options))
            {
                Console.WriteLine($"Incident ID: {incident.Id}");
                Console.WriteLine($"First associated anomaly occurred at: {incident.StartedOn}");
                Console.WriteLine($"Last associated anomaly occurred at: {incident.LastDetectedOn}");
                Console.WriteLine($"Status: {incident.Status}");
                Console.WriteLine($"Severity: {incident.Severity}");
                Console.WriteLine($"Value of root node anomaly: {incident.ValueOfRootNode}");

                if (incident.ExpectedValueOfRootNode.HasValue)
                {
                    Console.WriteLine($"Expected value of root node anomaly: {incident.ExpectedValueOfRootNode}");
                }

                Console.WriteLine("Series key of root node:");

                foreach (KeyValuePair<string, string> keyValuePair in incident.RootSeriesKey)
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

            var options = new GetIncidentsForAlertOptions() { MaxPageSize = 3 };

            int incidentCount = 0;

            await foreach (AnomalyIncident incident in client.GetIncidentsForAlertAsync(alertConfigurationId, alertId, options))
            {
                Console.WriteLine($"Incident ID: {incident.Id}");
                Console.WriteLine($"Data feed ID: {incident.DataFeedId}");
                Console.WriteLine($"Metric ID: {incident.MetricId}");
                Console.WriteLine($"Detection configuration ID: {incident.DetectionConfigurationId}");
                Console.WriteLine($"First associated anomaly occurred at: {incident.StartedOn}");
                Console.WriteLine($"Last associated anomaly occurred at: {incident.LastDetectedOn}");
                Console.WriteLine($"Status: {incident.Status}");
                Console.WriteLine($"Severity: {incident.Severity}");
                Console.WriteLine($"Value of root node anomaly: {incident.ValueOfRootNode}");

                if (incident.ExpectedValueOfRootNode.HasValue)
                {
                    Console.WriteLine($"Expected value of root node anomaly: {incident.ExpectedValueOfRootNode}");
                }

                Console.WriteLine("Series key of root node:");

                foreach (KeyValuePair<string, string> keyValuePair in incident.RootSeriesKey)
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
                Console.WriteLine($"Score: {rootCause.ContributionScore}");
                Console.WriteLine("Paths:");

                foreach (string path in rootCause.Paths)
                {
                    Console.WriteLine($"  {path}");
                }

                Console.WriteLine("Series key:");

                foreach (KeyValuePair<string, string> keyValuePair in rootCause.SeriesKey)
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
