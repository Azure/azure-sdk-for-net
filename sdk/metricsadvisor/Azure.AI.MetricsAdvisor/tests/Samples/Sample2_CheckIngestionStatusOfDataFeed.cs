// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task CheckIngestionStatusOfDataFeed()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string dataFeedId = DataFeedId;

            #region Snippet:CheckIngestionStatusOfDataFeed
            //@@ string dataFeedId = "<dataFeedId>";

            var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endTime = DateTimeOffset.Parse("2020-09-09T00:00:00Z");
            var options = new GetDataFeedIngestionStatusesOptions(startTime, endTime);

            Console.WriteLine("Ingestion statuses:");
            Console.WriteLine();

            int statusCount = 0;

            await foreach (DataFeedIngestionStatus ingestionStatus in adminClient.GetDataFeedIngestionStatusesAsync(dataFeedId, options))
            {
                Console.WriteLine($"Timestamp: {ingestionStatus.Timestamp}");
                Console.WriteLine($"Status: {ingestionStatus.Status.Value}");
                Console.WriteLine($"Service message: {ingestionStatus.Message}");
                Console.WriteLine();

                // Print at most 10 statuses.
                if (++statusCount >= 10)
                {
                    break;
                }
            }
            #endregion
        }
    }
}
