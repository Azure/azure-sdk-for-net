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
        public async Task DeleteMetricAsync()
        {
            #region Snippet:OnlineExperimentation_DeleteMetricAsync
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Delete a metric by ID - removes it from the workspace
            var response = await client.DeleteMetricAsync("test_metric_id");

            Console.WriteLine($"Delete operation status: {response.Status}");
            #endregion
        }
    }
}
