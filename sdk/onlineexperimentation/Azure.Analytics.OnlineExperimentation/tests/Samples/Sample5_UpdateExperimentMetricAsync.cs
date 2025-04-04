// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.OnlineExperimentation.Samples
{
    public partial class Sample5_UpdateExperimentMetric
    {
        [Test]
        [AsyncOnly]
        public async Task UpdateMetricAsync()
        {
            #region Snippet:OnlineExperimentation_UpdateMetricAsync
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINE_EXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // First, get the existing metric
            var existingMetric = (await client.GetMetricAsync("avg_revenue_per_purchase")).Value;

            existingMetric.DisplayName = "Average revenue per purchase [USD]";
            existingMetric.Description = "The average revenue per purchase transaction in USD. Refund transactions are excluded.";

            // Update the metric - the CreateOrUpdate method is used for both creating and updating
            var response = await client.CreateOrUpdateMetricAsync(existingMetric.Id, existingMetric);

            Console.WriteLine($"Updated metric: {response.Value.Id}");
            Console.WriteLine($"New display name: {response.Value.DisplayName}");
            Console.WriteLine($"New description: {response.Value.Description}");
            #endregion
        }
    }
}
