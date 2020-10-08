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

            DataFeed dataFeed = await CreateSampleDataFeed(adminClient);
            string dataFeedId = dataFeed.Id;

            #region Snippet:CheckIngestionStatusOfDataFeed
            //@@ string dataFeedId = "<dataFeedId>";

            var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endTime = DateTimeOffset.Parse("2020-09-09T00:00:00Z");
            var options = new GetDataFeedIngestionStatusesOptions(startTime, endTime);

            Console.WriteLine("Ingestion statuses:");
            Console.WriteLine();

            await foreach (DataFeedIngestionStatus ingestionStatus in adminClient.GetDataFeedIngestionStatusesAsync(dataFeedId, options))
            {
                Console.WriteLine($"Timestamp: {ingestionStatus.Timestamp}");
                Console.WriteLine($"Status: {ingestionStatus.Status.Value}");
                Console.WriteLine($"Service message: {ingestionStatus.Message}");
                Console.WriteLine();
            }
            #endregion

            // Delete the created data feed to clean up the Metrics Advisor resource. Do not perform this
            // step if you intend to keep using the data feed.

            await adminClient.DeleteDataFeedAsync(dataFeed.Id);
        }
    }
}
