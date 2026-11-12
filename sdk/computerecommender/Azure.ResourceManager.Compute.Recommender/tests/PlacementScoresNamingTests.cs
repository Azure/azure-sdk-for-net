// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Compute.Recommender.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Recommender.Tests
{
    public class PlacementScoresNamingTests
    {
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public void RegularPlacementRequestPreservesAvailabilityZonesWireName(bool? isZonal)
        {
            var sizes = new[] { new ComputeRecommenderResourceSize { Sku = "Standard_D2s_v5" } };
            var regular = new ComputePlacementScoresGenerateContent(sizes) { IsZonal = isZonal };
            var spot = new ComputeRecommenderGenerateContent(sizes) { AvailabilityZones = isZonal };
            var options = new ModelReaderWriterOptions("W");

            using JsonDocument regularJson = JsonDocument.Parse(ModelReaderWriter.Write(regular, options));
            using JsonDocument spotJson = JsonDocument.Parse(ModelReaderWriter.Write(spot, options));

            Assert.AreEqual(isZonal.HasValue, regularJson.RootElement.TryGetProperty("availabilityZones", out JsonElement regularValue));
            Assert.AreEqual(isZonal.HasValue, spotJson.RootElement.TryGetProperty("availabilityZones", out JsonElement spotValue));
            Assert.IsFalse(regularJson.RootElement.TryGetProperty("isZonal", out _));
            if (isZonal.HasValue)
            {
                Assert.AreEqual(isZonal.Value, regularValue.GetBoolean());
                Assert.AreEqual(isZonal.Value, spotValue.GetBoolean());
            }
        }

        [TestCase("true", true)]
        [TestCase("false", false)]
        [TestCase("null", null)]
        public void PlacementResponsesDeserializeWithDistinctClrNames(string value, bool? expected)
        {
            var data = BinaryData.FromString("{\"availabilityZones\":" + value + "}");

            var regular = ModelReaderWriter.Read<ComputePlacementScoresGenerateResult>(data);
            var spot = ModelReaderWriter.Read<ComputeRecommenderGenerateResult>(data);

            Assert.AreEqual(expected, regular.IsZonal);
            Assert.AreEqual(expected, spot.AvailabilityZones);
        }
    }
}
