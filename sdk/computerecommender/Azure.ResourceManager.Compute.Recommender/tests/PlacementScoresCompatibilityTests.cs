// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Recommender.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Recommender.Tests
{
    public class PlacementScoresCompatibilityTests
    {
        [Test]
        public void ParameterlessSpotRequestSupportsCollectionInitializers()
        {
            var content = new ComputeRecommenderGenerateContent
            {
                DesiredLocations = { AzureLocation.EastUS },
                DesiredSizes = { new ComputeRecommenderResourceSize { Sku = "Standard_D2s_v5" } },
                AvailabilityZones = true
            };

            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(content, new ModelReaderWriterOptions("W")));
            Assert.AreEqual("Standard_D2s_v5", json.RootElement.GetProperty("desiredSizes")[0].GetProperty("sku").GetString());
            Assert.AreEqual("eastus", json.RootElement.GetProperty("desiredLocations")[0].GetString());
            Assert.IsTrue(json.RootElement.GetProperty("availabilityZones").GetBoolean());
            Assert.Throws<ArgumentNullException>(() => new ComputeRecommenderGenerateContent(null));
        }

        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public void LegacyScoreFactoryPreservesOptionalArgumentsAndQuota(bool? quota)
        {
            Assert.IsNull(ArmComputeRecommenderModelFactory.ComputeRecommenderPlacementScore().IsQuotaAvailable);
            Assert.IsNull(ArmComputeRecommenderModelFactory.ComputeRecommenderPlacementScore(null).IsQuotaAvailable);
            Assert.IsNull(ArmComputeRecommenderModelFactory.ComputeRecommenderPlacementScore(null, null, null, null, null).IsQuotaAvailable);
            Assert.AreEqual(quota, ArmComputeRecommenderModelFactory.ComputeRecommenderPlacementScore(isQuotaAvailable: quota).IsQuotaAvailable);

            var score = ArmComputeRecommenderModelFactory.ComputeRecommenderPlacementScore("Standard_D2s_v5", AzureLocation.EastUS, "1", "High", quota);
            Assert.AreEqual("Standard_D2s_v5", score.Sku);
            Assert.AreEqual(AzureLocation.EastUS, score.Region);
            Assert.AreEqual("1", score.AvailabilityZone);
            Assert.AreEqual("High", score.Score);
            Assert.AreEqual(quota, score.IsQuotaAvailable);
            Assert.IsNull(score.PlacementPreference);

            var latest = ArmComputeRecommenderModelFactory.ComputeRecommenderPlacementScore("Standard_D2s_v5", AzureLocation.EastUS, "1", "High", 8, quota);
            Assert.AreEqual(quota, latest.IsQuotaAvailable);
            Assert.AreEqual(8, latest.PlacementPreference);

            foreach (string format in new[] { "J", "W" })
            {
                var options = new ModelReaderWriterOptions(format);
                var persisted = ModelReaderWriter.Read<ComputeRecommenderPlacementScore>(ModelReaderWriter.Write(latest, options), options);
                Assert.AreEqual(quota, persisted.IsQuotaAvailable);
                Assert.AreEqual(8, persisted.PlacementPreference);
            }
        }

        [TestCase("J", "true", true)]
        [TestCase("J", "false", false)]
        [TestCase("J", "null", null)]
        [TestCase("W", "true", true)]
        [TestCase("W", "false", false)]
        [TestCase("W", "null", null)]
        public void LegacyQuotaAndPlacementPreferenceDeserializeIndependently(string format, string value, bool? expected)
        {
            var options = new ModelReaderWriterOptions(format);
            var data = BinaryData.FromString("{\"placementScores\":[{\"sku\":\"Standard_D2s_v5\",\"score\":\"High\",\"isQuotaAvailable\":" + value + ",\"placementPreference\":8}]}");
            var response = ModelReaderWriter.Read<ComputeRecommenderGenerateResult>(data, options);
            var score = response.PlacementScores[0];

            Assert.AreEqual(expected, score.IsQuotaAvailable);
            Assert.AreEqual(8, score.PlacementPreference);

            var legacy = ModelReaderWriter.Read<ComputeRecommenderPlacementScore>(BinaryData.FromString("{\"isQuotaAvailable\":" + value + "}"), options);
            Assert.AreEqual(expected, legacy.IsQuotaAvailable);
            Assert.IsNull(legacy.PlacementPreference);

            var latest = ModelReaderWriter.Read<ComputeRecommenderPlacementScore>(BinaryData.FromString("{\"placementPreference\":0}"), options);
            Assert.IsNull(latest.IsQuotaAvailable);
            Assert.AreEqual(0, latest.PlacementPreference);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RegularMetadataCollectionIsEmptyWhenPropertiesAreAbsent(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var fromWire = ModelReaderWriter.Read<ComputePlacementScoresData>(BinaryData.FromString("{}"), options);
            var fromFactory = ArmComputeRecommenderModelFactory.ComputePlacementScoresData();

            Assert.IsNotNull(fromWire.ComputeRecommenderDiagnosticSupportedResourceTypes);
            Assert.IsEmpty(fromWire.ComputeRecommenderDiagnosticSupportedResourceTypes);
            Assert.IsNotNull(fromFactory.ComputeRecommenderDiagnosticSupportedResourceTypes);
            Assert.IsEmpty(fromFactory.ComputeRecommenderDiagnosticSupportedResourceTypes);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(fromWire, options));
            Assert.IsFalse(json.RootElement.TryGetProperty("properties", out _));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RegularMetadataCollectionRetainsMutationsWhenPropertiesAreAbsent(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var data = ModelReaderWriter.Read<ComputePlacementScoresData>(BinaryData.FromString("{\"properties\":null}"), options);
            var resourceTypes = data.ComputeRecommenderDiagnosticSupportedResourceTypes;
            Assert.AreSame(resourceTypes, data.ComputeRecommenderDiagnosticSupportedResourceTypes);
            resourceTypes.Add("Microsoft.Compute/virtualMachines");

            var persisted = ModelReaderWriter.Read<ComputePlacementScoresData>(ModelReaderWriter.Write(data, options), options);
            CollectionAssert.AreEqual(resourceTypes, persisted.ComputeRecommenderDiagnosticSupportedResourceTypes);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RegularMetadataPreservesExistingProperties(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var data = ModelReaderWriter.Read<ComputePlacementScoresData>(
                BinaryData.FromString("{\"properties\":{\"supportedResourceTypes\":[\"Microsoft.Compute/virtualMachines\"]}}"), options);

            CollectionAssert.AreEqual(new[] { "Microsoft.Compute/virtualMachines" }, data.ComputeRecommenderDiagnosticSupportedResourceTypes);
            var persisted = ModelReaderWriter.Read<ComputePlacementScoresData>(ModelReaderWriter.Write(data, options), options);
            CollectionAssert.AreEqual(data.ComputeRecommenderDiagnosticSupportedResourceTypes, persisted.ComputeRecommenderDiagnosticSupportedResourceTypes);
        }

        [Test]
        public void RegularMetadataPreservesUnknownPropertiesInJson()
        {
            var options = new ModelReaderWriterOptions("J");
            var data = ModelReaderWriter.Read<ComputePlacementScoresData>(
                BinaryData.FromString("{\"properties\":{\"supportedResourceTypes\":[\"Microsoft.Compute/virtualMachines\"],\"futureProperty\":true},\"futureRootProperty\":42}"), options);

            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(data, options));
            Assert.IsTrue(json.RootElement.GetProperty("properties").GetProperty("futureProperty").GetBoolean());
            Assert.AreEqual(42, json.RootElement.GetProperty("futureRootProperty").GetInt32());
        }

        [Test]
        public void DiagnosticFactoryPreservesOptionalArgumentsAndSupportedResourceTypes()
        {
            Assert.IsNotNull(ArmComputeRecommenderModelFactory.ComputeRecommenderDiagnosticData());
            var data = ArmComputeRecommenderModelFactory.ComputeRecommenderDiagnosticData(
                computeRecommenderDiagnosticSupportedResourceTypes: new[] { "Microsoft.Compute/virtualMachines" });

            CollectionAssert.AreEqual(new[] { "Microsoft.Compute/virtualMachines" }, data.ComputeRecommenderDiagnosticSupportedResourceTypes);
            var persisted = ModelReaderWriter.Read<ComputeRecommenderDiagnosticData>(ModelReaderWriter.Write(data));
            CollectionAssert.AreEqual(data.ComputeRecommenderDiagnosticSupportedResourceTypes, persisted.ComputeRecommenderDiagnosticSupportedResourceTypes);
        }
    }
}
