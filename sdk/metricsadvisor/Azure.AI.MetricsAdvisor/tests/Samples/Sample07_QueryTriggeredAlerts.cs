// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [Test]
        public async Task GetAlertsAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            #region Snippet:GetAlertsAsync
#if SNIPPET
            string anomalyAlertConfigurationId = "<anomalyAlertConfigurationId>";
#else
            string anomalyAlertConfigurationId = AlertConfigurationId;
#endif

            var startsOn = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endsOn = DateTimeOffset.UtcNow;
            var options = new GetAlertsOptions(startsOn, endsOn, AlertQueryTimeMode.AnomalyDetectedOn)
            {
                MaxPageSize = 5
            };

            int alertCount = 0;

            await foreach (AnomalyAlert alert in client.GetAlertsAsync(anomalyAlertConfigurationId, options))
            {
                Console.WriteLine($"Alert created at: {alert.CreatedOn}");
                Console.WriteLine($"Alert at timestamp: {alert.Timestamp}");
                Console.WriteLine($"Id: {alert.Id}");
                Console.WriteLine();

                // Print at most 5 alerts.
                if (++alertCount >= 5)
                {
                    break;
                }
            }
            #endregion
        }
    }
}
