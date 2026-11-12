// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Recommender.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Recommender.Tests
{
    public class PlacementScoresOperationsTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";

        [TestCase("2025-06-05", false)]
        [TestCase("2025-06-05", true)]
        [TestCase("2026-10-05-preview", false)]
        [TestCase("2026-10-05-preview", true)]
        public async Task DiagnosticOperationsPreserveGaWireContract(string apiVersion, bool async)
        {
            ResourceIdentifier id = ComputeRecommenderDiagnosticResource.CreateResourceIdentifier(SubscriptionId, AzureLocation.EastUS);
            var metadataResponse = new MockResponse(200);
            metadataResponse.SetContent("{\"id\":\"" + id + "\",\"name\":\"spot\",\"type\":\"Microsoft.Compute/locations/placementScores\",\"properties\":{\"supportedResourceTypes\":[\"Microsoft.Compute/virtualMachines\"]}}");
            var generateResponse = new MockResponse(200);
            bool legacy = apiVersion == "2025-06-05";
            generateResponse.SetContent("{\"placementScores\":[{\"sku\":\"Standard_D2s_v5\",\"score\":\"High\"," + (legacy ? "\"isQuotaAvailable\":false" : "\"placementPreference\":8") + "}]}");
            var transport = new MockTransport(metadataResponse, generateResponse);
            var options = new ArmClientOptions { Transport = transport };
            options.SetApiVersion(ComputeRecommenderDiagnosticResource.ResourceType, apiVersion);
            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            ComputeRecommenderDiagnosticResource resource = client.GetComputeRecommenderDiagnosticResource(id);

            var metadata = async ? await resource.GetAsync() : resource.Get();
            Assert.AreEqual(id, metadata.Value.Id);
            CollectionAssert.AreEqual(new[] { "Microsoft.Compute/virtualMachines" }, metadata.Value.Data.ComputeRecommenderDiagnosticSupportedResourceTypes);

            var content = new ComputeRecommenderGenerateContent
            {
                DesiredSizes = { new ComputeRecommenderResourceSize { Sku = "Standard_D2s_v5" } },
                AvailabilityZones = true
            };
            var result = async ? await resource.GenerateAsync(content) : resource.Generate(content);
            var score = result.Value.PlacementScores[0];
            Assert.AreEqual("High", score.Score);
            Assert.AreEqual(legacy ? false : (bool?)null, score.IsQuotaAvailable);
            Assert.AreEqual(legacy ? (int?)null : 8, score.PlacementPreference);
            AssertRequests(transport, id, apiVersion);
        }

        [TestCase("eastus", false)]
        [TestCase("eastus", true)]
        [TestCase("westeurope", false)]
        [TestCase("westeurope", true)]
        public async Task RegularOperationsUseRegularPlacementPath(string location, bool async)
        {
            ResourceIdentifier id = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/providers/Microsoft.Compute/locations/{location}/placementScores/regular");
            var metadataResponse = new MockResponse(200);
            metadataResponse.SetContent("{\"id\":\"" + id + "\",\"name\":\"regular\",\"type\":\"Microsoft.Compute/locations/placementScores\",\"properties\":{\"supportedResourceTypes\":[\"Microsoft.Compute/virtualMachines\"]}}");
            var generateResponse = new MockResponse(200);
            generateResponse.SetContent("{\"availabilityZones\":true,\"placementScores\":[{\"sku\":\"Standard_D2s_v5\",\"score\":\"High\",\"placementPreference\":8}]}");
            var transport = new MockTransport(metadataResponse, generateResponse);
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            SubscriptionResource subscription = client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));
            ComputePlacementScoresResource resource = subscription.GetComputePlacementScores(new AzureLocation(location));
            Assert.AreEqual(id, resource.Id);

            var metadata = async ? await resource.GetAsync() : resource.Get();
            Assert.AreEqual(id, metadata.Value.Id);
            CollectionAssert.AreEqual(new[] { "Microsoft.Compute/virtualMachines" }, metadata.Value.Data.ComputeRecommenderDiagnosticSupportedResourceTypes);

            var content = new ComputePlacementScoresGenerateContent(new[] { new ComputeRecommenderResourceSize { Sku = "Standard_D2s_v5" } }) { IsZonal = true };
            var result = async ? await resource.GenerateAsync(content) : resource.Generate(content);
            Assert.IsTrue(result.Value.IsZonal);
            Assert.AreEqual("High", result.Value.PlacementScores[0].Score);
            Assert.AreEqual(8, result.Value.PlacementScores[0].PlacementPreference);
            AssertRequests(transport, id, "2026-10-05-preview");
        }

        [Test]
        public void RegularResourceRejectsSpotIdentifier()
        {
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = new MockTransport() });
            ResourceIdentifier spotId = ComputeRecommenderDiagnosticResource.CreateResourceIdentifier(SubscriptionId, AzureLocation.EastUS);

            Assert.Throws<ArgumentException>(() => client.GetComputePlacementScoresResource(spotId));
        }

        [Test]
        public void RegularResourceAcceptsCaseInsensitiveSingletonNameAndRejectsOtherTypes()
        {
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = new MockTransport() });
            var regularId = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/providers/Microsoft.Compute/locations/eastus/placementScores/REGULAR");
            var wrongTypeId = new ResourceIdentifier($"/subscriptions/{SubscriptionId}/resourceGroups/example");

            Assert.AreEqual(regularId, client.GetComputePlacementScoresResource(regularId).Id);
            Assert.Throws<ArgumentException>(() => client.GetComputePlacementScoresResource(wrongTypeId));
        }

        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/example/providers/Microsoft.Compute/locations/eastus/placementScores/regular")]
        [TestCase("/providers/Microsoft.Compute/locations/eastus/placementScores/regular")]
        public void RegularResourceRejectsOtherScopes(string id)
        {
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = new MockTransport() });

            Assert.Throws<ArgumentException>(() => client.GetComputePlacementScoresResource(new ResourceIdentifier(id)));
        }

        private static void AssertRequests(MockTransport transport, ResourceIdentifier id, string apiVersion)
        {
            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual(RequestMethod.Get, transport.Requests[0].Method);
            Assert.AreEqual(id.ToString(), transport.Requests[0].Uri.ToUri().AbsolutePath);
            Assert.AreEqual("?api-version=" + apiVersion, transport.Requests[0].Uri.ToUri().Query);
            Assert.AreEqual(RequestMethod.Post, transport.Requests[1].Method);
            Assert.AreEqual(id + "/generate", transport.Requests[1].Uri.ToUri().AbsolutePath);
            Assert.AreEqual("?api-version=" + apiVersion, transport.Requests[1].Uri.ToUri().Query);
            using var stream = new MemoryStream();
            transport.Requests[1].Content.WriteTo(stream, default);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            Assert.IsTrue(body.RootElement.GetProperty("availabilityZones").GetBoolean());
            Assert.IsFalse(body.RootElement.TryGetProperty("isZonal", out _));
            Assert.AreEqual("Standard_D2s_v5", body.RootElement.GetProperty("desiredSizes")[0].GetProperty("sku").GetString());
        }
    }
}
