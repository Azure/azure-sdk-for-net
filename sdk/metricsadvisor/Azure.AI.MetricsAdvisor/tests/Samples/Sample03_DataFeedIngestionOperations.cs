// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [Test]
        public async Task GetDataFeedIngestionStatusesAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            #region Snippet:GetDataFeedIngestionStatusesAsync
#if SNIPPET
            string dataFeedId = "<dataFeedId>";
#else
            string dataFeedId = DataFeedId;
#endif

            var startsOn = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endsOn = DateTimeOffset.Parse("2020-09-09T00:00:00Z");
            var options = new GetDataFeedIngestionStatusesOptions(startsOn, endsOn)
            {
                MaxPageSize = 5
            };

            Console.WriteLine("Ingestion statuses:");
            Console.WriteLine();

            int statusCount = 0;

            await foreach (DataFeedIngestionStatus ingestionStatus in adminClient.GetDataFeedIngestionStatusesAsync(dataFeedId, options))
            {
                Console.WriteLine($"Timestamp: {ingestionStatus.Timestamp}");
                Console.WriteLine($"Status: {ingestionStatus.Status}");
                Console.WriteLine($"Service message: {ingestionStatus.Message}");
                Console.WriteLine();

                // Print at most 5 statuses.
                if (++statusCount >= 5)
                {
                    break;
                }
            }
            #endregion
        }

        [Test]
        public async Task GetDataFeedIngestionProgressAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string dataFeedId = DataFeedId;

            Response<DataFeedIngestionProgress> response = await adminClient.GetDataFeedIngestionProgressAsync(dataFeedId);

            DataFeedIngestionProgress ingestionProgress = response.Value;

            Console.WriteLine($"Latest active timestamp: {ingestionProgress.LatestActiveTimestamp}");
            Console.WriteLine($"Latest success timestamp: {ingestionProgress.LatestSuccessTimestamp}");
        }

        [Test]
        public async Task RefreshDataFeedIngestionAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string dataFeedId = DataFeedId;

            var startsOn = DateTimeOffset.Parse("2022-03-01T00:00:00Z");
            var endsOn = DateTimeOffset.Parse("2022-03-03T00:00:00Z");

            await adminClient.RefreshDataFeedIngestionAsync(dataFeedId, startsOn, endsOn);
        }
    }
}
