// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Recommender.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Recommender.Tests
{
    [LiveOnly(Reason = "Exercises actual Spot service responses; service recordings have not been captured.")]
    public class ComputeRecommenderDiagnosticTests : ComputeRecommenderManagementTestBase
    {
        public ComputeRecommenderDiagnosticTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase("2025-06-05")]
        [TestCase("2026-10-05-preview")]
        public async Task DiagnosticOperationsPreserveGaContract(string apiVersion)
        {
            var options = new ArmClientOptions();
            options.SetApiVersion(ComputeRecommenderDiagnosticResource.ResourceType, apiVersion);
            ArmClient client = GetArmClient(options);
            var location = new AzureLocation(TestEnvironment.Location);
            ResourceIdentifier id = ComputeRecommenderDiagnosticResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, location);
            ComputeRecommenderDiagnosticResource resource = client.GetComputeRecommenderDiagnosticResource(id);

            var metadata = await resource.GetAsync();
            Assert.AreEqual(200, metadata.GetRawResponse().Status);
            Assert.AreEqual(id, metadata.Value.Id);
            CollectionAssert.Contains(metadata.Value.Data.ComputeRecommenderDiagnosticSupportedResourceTypes, "Microsoft.Compute/virtualMachines");

            const string sku = "Standard_D2s_v5";
            var content = new ComputeRecommenderGenerateContent
            {
                DesiredLocations = { location },
                DesiredSizes = { new ComputeRecommenderResourceSize { Sku = sku } },
                DesiredCount = 1,
                AvailabilityZones = false
            };
            var result = await resource.GenerateAsync(content);
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.IsNotEmpty(result.Value.PlacementScores);

            // Compare optional fields with the service payload instead of assuming current capacity or quota.
            using JsonDocument response = JsonDocument.Parse(result.GetRawResponse().Content);
            JsonElement scores = response.RootElement.GetProperty("placementScores");
            Assert.AreEqual(scores.GetArrayLength(), result.Value.PlacementScores.Count);
            for (int i = 0; i < result.Value.PlacementScores.Count; i++)
            {
                ComputeRecommenderPlacementScore score = result.Value.PlacementScores[i];
                Assert.AreEqual(sku, score.Sku);
                Assert.AreEqual(location, score.Region);
                Assert.IsNotEmpty(score.Score);
                Assert.AreEqual(scores[i].GetProperty("score").GetString(), score.Score);

                bool? quota = scores[i].TryGetProperty("isQuotaAvailable", out JsonElement quotaValue) && quotaValue.ValueKind != JsonValueKind.Null
                    ? quotaValue.GetBoolean() : (bool?)null;
                int? preference = scores[i].TryGetProperty("placementPreference", out JsonElement preferenceValue) && preferenceValue.ValueKind != JsonValueKind.Null
                    ? preferenceValue.GetInt32() : (int?)null;
                Assert.AreEqual(quota, score.IsQuotaAvailable);
                Assert.AreEqual(preference, score.PlacementPreference);
            }
        }
    }
}
