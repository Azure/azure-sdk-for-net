// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [RecordedTest]
        public async Task QueryDetectedAnomaliesAndTriggeredAlerts()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string anomalyAlertConfigurationId = AlertConfigurationId;

            #region Snippet:QueryDetectedAnomaliesAndTriggeredAlerts
            //@@ string anomalyAlertConfigurationId = "<anomalyAlertConfigurationId>";

            var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endTime = DateTimeOffset.UtcNow;
            var options = new GetAlertsOptions(startTime, endTime, TimeMode.AnomalyTime);

            int alertCount = 0;

            await foreach (AnomalyAlert alert in client.GetAlertsAsync(anomalyAlertConfigurationId, options))
            {
                Console.WriteLine($"Alert at timestamp: {alert.Timestamp}");
                Console.WriteLine($"Id: {alert.Id}");
                Console.WriteLine($"Anomalies that triggered this alert:");

                await foreach (DataAnomaly anomaly in client.GetAnomaliesForAlertAsync(anomalyAlertConfigurationId, alert.Id))
                {
                    Console.WriteLine("  Anomaly:");
                    Console.WriteLine($"    Status: {anomaly.Status.Value}");
                    Console.WriteLine($"    Severity: {anomaly.Severity}");
                    Console.WriteLine($"    Series key:");

                    foreach (KeyValuePair<string, string> keyValuePair in anomaly.SeriesKey.AsDictionary())
                    {
                        Console.WriteLine($"      Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                    }

                    Console.WriteLine();
                }

                // Print at most 3 alerts.
                if (++alertCount >= 3)
                {
                    break;
                }
            }
            #endregion
        }
    }
}
