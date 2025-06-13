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
        public async Task UpdateMetricAsync()
        {
            #region Snippet:OnlineExperimentation_UpdateMetricAsync
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Update a Description and Definition of an existing metric,
            // other fields (DisplayName, Categories, DesiredDirection, Lifecycle) remain unchanged.
            var response = await client.UpdateMetricAsync(
                experimentMetricId: "avg_revenue_per_purchase",
                new ExperimentMetricUpdate
                {
                    Description = "The average revenue per purchase transaction in USD.",
                    Definition = new AverageMetricDefinition(eventName: "Purchase", eventProperty: "Revenue")
                    {
                        Value = { Filter = "Revenue > 0" }
                    }
                });

            Console.WriteLine($"Updated metric: {response.Value.Id}");
            Console.WriteLine($"New display name: {response.Value.DisplayName}");
            Console.WriteLine($"New description: {response.Value.Description}");
            #endregion
        }
    }
}
