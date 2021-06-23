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
        public async Task GetAnomaliesForDetectionConfigurationAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string detectionConfigurationId = DetectionConfigurationId;

            var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endTime = DateTimeOffset.UtcNow;
            var options = new GetAnomaliesForDetectionConfigurationOptions(startTime, endTime)
            {
                MaxPageSize = 3
            };

            int anomalyCount = 0;

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesForDetectionConfigurationAsync(detectionConfigurationId, options))
            {
                Console.WriteLine($"Anomaly value: {anomaly.Value}");

                if (anomaly.ExpectedValue.HasValue)
                {
                    Console.WriteLine($"Anomaly expected value: {anomaly.ExpectedValue}");
                }

                Console.WriteLine($"Anomaly at timestamp: {anomaly.Timestamp}");
                Console.WriteLine($"Severity: {anomaly.Severity}");
                Console.WriteLine("Series key:");

                foreach (KeyValuePair<string, string> keyValuePair in anomaly.SeriesKey.AsDictionary())
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine();

                // Print at most 3 anomalies.
                if (++anomalyCount >= 3)
                {
                    break;
                }
            }
        }

        [Test]
        public async Task GetAnomaliesForAlertAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            #region Snippet:GetAnomaliesForAlertAsync
#if SNIPPET
            string alertConfigurationId = "<alertConfigurationId>";
            string alertId = "<alertId>";
#else
            string alertConfigurationId = AlertConfigurationId;
            string alertId = AlertId;
#endif

            var options = new GetAnomaliesForAlertOptions() { MaxPageSize = 3 };

            int anomalyCount = 0;

            await foreach (DataPointAnomaly anomaly in client.GetAnomaliesForAlertAsync(alertConfigurationId, alertId, options))
            {
                Console.WriteLine($"Anomaly detection configuration ID: {anomaly.DetectionConfigurationId}");
                Console.WriteLine($"Data feed ID: {anomaly.DataFeedId}");
                Console.WriteLine($"Metric ID: {anomaly.MetricId}");
                Console.WriteLine($"Anomaly value: {anomaly.Value}");

                if (anomaly.ExpectedValue.HasValue)
                {
                    Console.WriteLine($"Anomaly expected value: {anomaly.ExpectedValue}");
                }

                Console.WriteLine($"Anomaly at timestamp: {anomaly.Timestamp}");
                Console.WriteLine($"Anomaly detected at: {anomaly.CreatedTime}");
                Console.WriteLine($"Status: {anomaly.Status}");
                Console.WriteLine($"Severity: {anomaly.Severity}");
                Console.WriteLine("Series key:");

                foreach (KeyValuePair<string, string> keyValuePair in anomaly.SeriesKey.AsDictionary())
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine();

                // Print at most 3 anomalies.
                if (++anomalyCount >= 3)
                {
                    break;
                }
            }
            #endregion
        }
    }
}
