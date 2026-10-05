// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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

            var feature = response.Value;
            Assert.AreEqual("Feature", feature.Type);
            Assert.IsInstanceOf<GeoPoint>(feature.Geometry);
            Assert.AreEqual(GeoObjectType.Point, feature.Geometry.Type);
            Assert.AreEqual(-122.25, feature.Geometry.Coordinates.Longitude);
            Assert.AreEqual(37.87, feature.Geometry.Coordinates.Latitude);
            Assert.AreEqual(3, feature.Properties.Count);
            Assert.AreEqual("A single point of interest", feature.Properties["name"].ToObjectFromJson<string>());
            Assert.AreEqual("landmark", feature.Properties["category"].ToObjectFromJson<string>());
            Assert.AreEqual(100, feature.Properties["elevation"].ToObjectFromJson<int>());
            Assert.AreEqual("feature-1", feature.Id.ToObjectFromJson<string>());
        });

        [SpectorTest]
        public void FeatureWithNullGeometryIsDeserialized()
        {
            var feature = ModelReaderWriter.Read<Feature>(BinaryData.FromString(
                "{\"type\":\"Feature\",\"geometry\":null,\"properties\":{}}"));

            Assert.AreEqual("Feature", feature!.Type);
            Assert.IsNull(feature.Geometry);
        }
    }
}
