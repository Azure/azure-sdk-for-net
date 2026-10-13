// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.AlternateType;
using Specs.Azure.ClientGenerator.Core.AlternateType._ExternalType;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.AlternateType
{
    public class AlternateTypeTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_AlternateType_ExternalType_getModel() => Test(async (host) =>
        {
            var response = await new AlternateTypeClient(host, null).GetExternalTypeClient().GetModelAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            AssertFeature(response.Value);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_AlternateType_ExternalType_putModel() => Test(async (host) =>
        {
            var response = await new AlternateTypeClient(host, null).GetExternalTypeClient().PutModelAsync(CreateFeature());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_AlternateType_ExternalType_getProperty() => Test(async (host) =>
        {
            var response = await new AlternateTypeClient(host, null).GetExternalTypeClient().GetPropertyAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("extra", response.Value.AdditionalProperty);
            AssertFeature(response.Value.Feature);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_AlternateType_ExternalType_putProperty() => Test(async (host) =>
        {
            var body = new ModelWithFeatureProperty(CreateFeature(), "extra");
            var response = await new AlternateTypeClient(host, null).GetExternalTypeClient().PutPropertyAsync(body);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public void FeatureRoundTrip()
        {
            var data = ModelReaderWriter.Write(CreateFeature(), ModelReaderWriterOptions.Json, SpecsAzureClientGeneratorCoreAlternateTypeContext.Default);
            var feature = ModelReaderWriter.Read<Feature>(data, ModelReaderWriterOptions.Json, SpecsAzureClientGeneratorCoreAlternateTypeContext.Default);
            AssertFeature(feature!);
        }

        [SpectorTest]
        public void FeatureWithNullGeometryAndMissingIdRoundTrip()
        {
            var feature = new Feature(null, new Dictionary<string, BinaryData>());
            var options = new ModelReaderWriterOptions("W");
            var data = ModelReaderWriter.Write(feature, options, SpecsAzureClientGeneratorCoreAlternateTypeContext.Default);
            using var document = JsonDocument.Parse(data);
            var root = document.RootElement;
            Assert.AreEqual("Feature", root.GetProperty("type").GetString());
            Assert.AreEqual(JsonValueKind.Null, root.GetProperty("geometry").ValueKind);
            Assert.AreEqual(JsonValueKind.Object, root.GetProperty("properties").ValueKind);
            Assert.IsFalse(root.TryGetProperty("id", out _));

            var roundTrip = ModelReaderWriter.Read<Feature>(data, options, SpecsAzureClientGeneratorCoreAlternateTypeContext.Default);
            Assert.AreEqual("Feature", roundTrip!.Type);
            Assert.IsNull(roundTrip.Geometry);
            Assert.IsEmpty(roundTrip.Properties);
            Assert.IsNull(roundTrip.Id);
        }

        [SpectorTest]
        public void PropertyWithAltitudeAndNumericIdRoundTrip()
        {
            var feature = CreateFeature();
            feature.Geometry = new GeoPoint(-122.25, 37.87, 100);
            feature.Id = BinaryData.FromObjectAsJson(42);
            var model = new ModelWithFeatureProperty(feature, "extra");
            var options = new ModelReaderWriterOptions("W");
            var data = ModelReaderWriter.Write(model, options, SpecsAzureClientGeneratorCoreAlternateTypeContext.Default);
            using var document = JsonDocument.Parse(data);
            var serializedFeature = document.RootElement.GetProperty("feature");
            var coordinates = serializedFeature.GetProperty("geometry").GetProperty("coordinates");
            Assert.AreEqual(3, coordinates.GetArrayLength());
            Assert.AreEqual(-122.25, coordinates[0].GetDouble());
            Assert.AreEqual(37.87, coordinates[1].GetDouble());
            Assert.AreEqual(100, coordinates[2].GetDouble());
            Assert.AreEqual(JsonValueKind.Number, serializedFeature.GetProperty("id").ValueKind);
            Assert.AreEqual(42, serializedFeature.GetProperty("id").GetInt32());

            var roundTrip = ModelReaderWriter.Read<ModelWithFeatureProperty>(data, options, SpecsAzureClientGeneratorCoreAlternateTypeContext.Default);
            Assert.AreEqual("extra", roundTrip!.AdditionalProperty);
            Assert.AreEqual(GeoObjectType.Point, roundTrip.Feature.Geometry.Type);
            Assert.AreEqual(-122.25, roundTrip.Feature.Geometry.Coordinates.Longitude);
            Assert.AreEqual(37.87, roundTrip.Feature.Geometry.Coordinates.Latitude);
            Assert.AreEqual(100, roundTrip.Feature.Geometry.Coordinates.Altitude);
            Assert.AreEqual(42, roundTrip.Feature.Id.ToObjectFromJson<int>());
            AssertProperties(roundTrip.Feature);
        }

        private static Feature CreateFeature() => new Feature(
            new GeoPoint(-122.25, 37.87),
            new Dictionary<string, BinaryData>
            {
                ["name"] = BinaryData.FromObjectAsJson("A single point of interest"),
                ["category"] = BinaryData.FromObjectAsJson("landmark"),
                ["elevation"] = BinaryData.FromObjectAsJson(100)
            })
        {
            Id = BinaryData.FromObjectAsJson("feature-1")
        };

        private static void AssertFeature(Feature feature)
        {
            Assert.AreEqual("Feature", feature.Type);
            Assert.IsInstanceOf<GeoPoint>(feature.Geometry);
            Assert.AreEqual(GeoObjectType.Point, feature.Geometry.Type);
            Assert.AreEqual(-122.25, feature.Geometry.Coordinates.Longitude);
            Assert.AreEqual(37.87, feature.Geometry.Coordinates.Latitude);
            Assert.IsNull(feature.Geometry.Coordinates.Altitude);
            Assert.AreEqual("feature-1", feature.Id.ToObjectFromJson<string>());
            AssertProperties(feature);
        }

        private static void AssertProperties(Feature feature)
        {
            Assert.AreEqual(3, feature.Properties.Count);
            Assert.AreEqual("A single point of interest", feature.Properties["name"].ToObjectFromJson<string>());
            Assert.AreEqual("landmark", feature.Properties["category"].ToObjectFromJson<string>());
            Assert.AreEqual(100, feature.Properties["elevation"].ToObjectFromJson<int>());
        }
    }
}
