// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using Azure.Core.Spatial;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class SpatialTests
    {
        [Test]
        public void CanRoundripGeometryCollection()
        {
            var input = "{ \"type\": \"GeometryCollection\", \"geometries\": [{ \"type\": \"Point\", \"coordinates\": [100.1, 0.2] }, { \"type\": \"LineString\", \"coordinates\": [ [101.3, 0.4], [102.5, 1.6] ] }] }";

            var collection = AssertRoundtrip<GeometryCollection>(input);
            var point = (GeoPoint) collection.Geometries[0];
            Assert.AreEqual(new GeoPosition(100.1, 0.2), point.Position);

            var lineString = (GeoLineString) collection.Geometries[1];
            Assert.AreEqual(new GeoPosition(101.3, 0.4), lineString.Positions[0]);
            Assert.AreEqual(new GeoPosition(102.5, 1.6), lineString.Positions[1]);

            Assert.AreEqual(2, collection.Geometries.Count);
        }

        private T AssertRoundtrip<T>(string json) where T: Geometry
        {
            var element = JsonDocument.Parse(json).RootElement;
            var geometry = GeoJsonConverter.Read(element);

            var memoryStreamOutput = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(memoryStreamOutput))
            {
                GeoJsonConverter.Write(writer, geometry);
            }

            var element2 = JsonDocument.Parse(memoryStreamOutput.ToArray()).RootElement;
            var geometry2 = GeoJsonConverter.Read(element2);

            return (T)geometry2;
        }
    }
}