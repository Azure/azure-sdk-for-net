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
        public async Task ValidateMetricAsync()
        {
            #region Snippet:OnlineExperimentation_ValidateMetricAsync
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
            var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());

            // Define a metric to validate
            var metricToValidate = new ExperimentMetric(
                LifecycleStage.Active,
                "Test metric for validation",
                "This metric definition will be validated before creation",
                ["Test"],
                DesiredDirection.Increase,
                new EventCountMetricDefinition("TestEvent")
            );

            // Validate the metric - checks for errors in the definition
            var validationResult = await client.ValidateMetricAsync(metricToValidate);

            // Check if the metric definition is valid
            if (validationResult.Value.IsValid)
            {
                Console.WriteLine("Metric definition is valid");

                // Now create the validated metric
                var createdMetric = await client.CreateOrUpdateMetricAsync("test_metric_id", metricToValidate);
                Console.WriteLine($"Created metric: {createdMetric.Value.Id}");
            }
            else
            {
                // Handle validation errors
                Console.WriteLine("Metric definition has errors:");
                foreach (var error in validationResult.Value.Diagnostics)
                {
                    Console.WriteLine($"- [{error.Code}] {error.Message}");
                }
            }
            #endregion
        }
    }
}
