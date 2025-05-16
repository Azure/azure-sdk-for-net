// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.OnlineExperimentation.Samples
{
    public partial class OnlineExperimentationSamples
    {
        [Test]
        [AsyncOnly]
        public async Task RetrieveSingleMetricAsync()
        {
            #region Snippet:OnlineExperimentation_RetrieveMetricAsync
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Get a specific metric by ID
            var metric = await client.GetMetricAsync("avg_revenue_per_purchase");

            // Access metric properties to view or use the metric definition
            Console.WriteLine($"Metric ID: {metric.Value.Id}");
            Console.WriteLine($"Display name: {metric.Value.DisplayName}");
            Console.WriteLine($"Description: {metric.Value.Description}");
            Console.WriteLine($"Lifecycle stage: {metric.Value.Lifecycle}");
            Console.WriteLine($"Desired direction: {metric.Value.DesiredDirection}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ListAllMetricsAsync()
        {
            #region Snippet:OnlineExperimentation_ListMetricsAsync
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // List all metrics in the workspace
            Console.WriteLine("Listing all metrics:");
            await foreach (var item in client.GetMetricsAsync())
            {
                Console.WriteLine($"- {item.Id}: {item.DisplayName}");
            }
            #endregion
        }
    }
}
