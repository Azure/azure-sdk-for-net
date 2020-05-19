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
        public void CanRoundripPoint()
        {
            var input = "{ \"type\": \"Point\", \"coordinates\": [100.1, 0.2] }";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.AreEqual(new GeoPosition(100.1, 0.2), point.Position);
        }

        [Test]
        public void CanRoundripPolygon()
        {
            var input = " { \"type\": \"Polygon\", \"coordinates\": [ [ [100.0, 0.0], [101.0, 0.0], [101.0, 1.0], [100.0, 1.0], [100.0, 0.0] ] ] }";

            var polygon = AssertRoundtrip<GeoPolygon>(input);
            Assert.AreEqual(1, polygon.Rings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(100.0, 0.0),
                P(101.0, 0.0),
                P(101.0, 1.0),
                P(100.0, 1.0),
                P(100.0, 0.0),
            }, polygon.Rings[0].Positions);
        }

        [Test]
        public void CanRoundripPolygonHoles()
        {
            var input = "{ \"type\": \"Polygon\", \"coordinates\": [ [ [100.0, 0.0], [101.0, 0.0], [101.0, 1.0], [100.0, 1.0], [100.0, 0.0] ], " +
                        "[ [100.8, 0.8], [100.8, 0.2], [100.2, 0.2], [100.2, 0.8], [100.8, 0.8] ] ] }";

            var polygon = AssertRoundtrip<GeoPolygon>(input);
            Assert.AreEqual(2, polygon.Rings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(100.0, 0.0),
                P(101.0, 0.0),
                P(101.0, 1.0),
                P(100.0, 1.0),
                P(100.0, 0.0),
            }, polygon.Rings[0].Positions);

            CollectionAssert.AreEqual(new[]
            {
                P(100.8, 0.8),
                P(100.8, 0.2),
                P(100.2, 0.2),
                P(100.2, 0.8),
                P(100.8, 0.8),
            }, polygon.Rings[1].Positions);
        }

        [Test]
        public void CanRoundripMultiPoint()
        {
            var input = "{ \"type\": \"MultiPoint\", \"coordinates\": [ [100.0, 0.0], [101.0, 1.0] ] }";

            var multipoint = AssertRoundtrip<GeoMultiPoint>(input);
            Assert.AreEqual(2, multipoint.Points.Count);

            Assert.AreEqual(P(100.0, 0.0), multipoint.Points[0].Position);
            Assert.AreEqual(P(101.0, 1.0), multipoint.Points[1].Position);
        }

        [Test]
        public void CanRoundripMultiLineString()
        {
            var input = "{ \"type\": \"MultiLineString\", \"coordinates\": [ [ [100.0, 0.0], [101.0, 1.0] ], [ [102.0, 2.0], [103.0, 3.0] ] ] }";

            var polygon = AssertRoundtrip<GeoMultiLineString>(input);
            Assert.AreEqual(2, polygon.LineStrings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(100.0, 0.0),
                P(101.0, 1.0)
            }, polygon.LineStrings[0].Positions);

            CollectionAssert.AreEqual(new[]
            {
                P(102.0, 2.0),
                P(103.0, 3.0)
            }, polygon.LineStrings[1].Positions);
        }

        [Test]
        public void CanRoundripMultiPolygon()
        {
            var input = " { \"type\": \"MultiPolygon\", \"coordinates\": [ [ [ [102.0, 2.0], [103.0, 2.0], [103.0, 3.0], [102.0, 3.0], [102.0, 2.0] ] ], [ [ [100.0, 0.0], [101.0, 0.0], [101.0, 1.0], [100.0, 1.0], [100.0, 0.0] ], [ [100.2, 0.2], [100.2, 0.8], [100.8, 0.8], [100.8, 0.2], [100.2, 0.2] ] ] ] }";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.AreEqual(new GeoPosition(100.1, 0.2), point.Position);
        }

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

        private GeoPosition P(double lon, double lat, double? alt = null) => new GeoPosition(lon, lat, alt);

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