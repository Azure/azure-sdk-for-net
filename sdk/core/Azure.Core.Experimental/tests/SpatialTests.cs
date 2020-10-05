// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(2)]
    [TestFixture(3)]
    public class SpatialTests
    {
        private readonly int _points;

        public SpatialTests(int points)
        {
            _points = points;
        }

        [Test]
        public void CanRoundripPoint()
        {
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}] }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.AreEqual(P(0), point.Position);
        }

        [Test]
        public void CanRoundripBBox()
        {
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}], \"bbox\": [ {PS(1)}, {PS(2)} ] }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.AreEqual(P(0), point.Position);
            Assert.AreEqual(P(1).Longitude, point.BoundingBox.West);
            Assert.AreEqual(P(1).Latitude, point.BoundingBox.South);

            Assert.AreEqual(P(2).Longitude, point.BoundingBox.East);
            Assert.AreEqual(P(2).Latitude, point.BoundingBox.North);

            Assert.AreEqual(P(1).Altitude, point.BoundingBox.MinAltitude);
            Assert.AreEqual(P(2).Altitude, point.BoundingBox.MaxAltitude);
        }

        [Test]
        public void CanRoundripAdditionalProperties()
        {
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}]," +
                        $" \"additionalNumber\": 1," +
                        $" \"additionalNumber2\": 2.2," +
                        $" \"additionalNumber3\": 9999999999999999999," +
                        $" \"additionalString\": \"hello\", " +
                        $" \"additionalBool\": true, " +
                        $" \"additionalNull\": null, " +
                        $" \"additionalArray\": [1, 2.2, 9999999999999999999, \"hello\", true, null]" +
                        $" }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.AreEqual(P(0), point.Position);
            Assert.AreEqual(1, point.AdditionalProperties["additionalNumber"]);
            Assert.AreEqual(2.2, point.AdditionalProperties["additionalNumber2"]);
            Assert.AreEqual(9999999999999999999L, point.AdditionalProperties["additionalNumber3"]);
            Assert.AreEqual("hello", point.AdditionalProperties["additionalString"]);
            Assert.AreEqual(null, point.AdditionalProperties["additionalNull"]);
            Assert.AreEqual(true, point.AdditionalProperties["additionalBool"]);
            Assert.AreEqual(new object[] {1, 2.2, 9999999999999999999L, "hello", true, null}, point.AdditionalProperties["additionalArray"]);
        }

        [Test]
        public void CanRoundripPolygon()
        {
            var input = $" {{ \"type\": \"Polygon\", \"coordinates\": [ [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}] ] ] }}";

            var polygon = AssertRoundtrip<GeoPolygon>(input);
            Assert.AreEqual(1, polygon.Rings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
            }, polygon.Rings[0].Positions);
        }

        [Test]
        public void CanRoundripPolygonHoles()
        {
            var input = $"{{ \"type\": \"Polygon\", \"coordinates\": [" +
                        $" [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}] ]," +
                        $" [ [{PS(5)}], [{PS(6)}], [{PS(7)}], [{PS(8)}], [{PS(9)}] ]" +
                        $" ] }}";

            var polygon = AssertRoundtrip<GeoPolygon>(input);
            Assert.AreEqual(2, polygon.Rings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
            }, polygon.Rings[0].Positions);

            CollectionAssert.AreEqual(new[]
            {
                P(5),
                P(6),
                P(7),
                P(8),
                P(9),
            }, polygon.Rings[1].Positions);
        }

        [Test]
        public void CanRoundripMultiPoint()
        {
            var input = $"{{ \"type\": \"MultiPoint\", \"coordinates\": [ [{PS(0)}], [{PS(1)}] ] }}";

            var multipoint = AssertRoundtrip<GeoPointCollection>(input);
            Assert.AreEqual(2, multipoint.Points.Count);

            Assert.AreEqual(P(0), multipoint.Points[0].Position);
            Assert.AreEqual(P(1), multipoint.Points[1].Position);
        }

        [Test]
        public void CanRoundripMultiLineString()
        {
            var input = $"{{ \"type\": \"MultiLineString\", \"coordinates\": [ [ [{PS(0)}], [{PS(1)}] ], [ [{PS(2)}], [{PS(3)}] ] ] }}";

            var polygon = AssertRoundtrip<GeoLineCollection>(input);
            Assert.AreEqual(2, polygon.Lines.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(0),
                P(1)
            }, polygon.Lines[0].Positions);

            CollectionAssert.AreEqual(new[]
            {
                P(2),
                P(3)
            }, polygon.Lines[1].Positions);
        }

        [Test]
        public void CanRoundripMultiPolygon()
        {
            var input = $" {{ \"type\": \"MultiPolygon\", \"coordinates\": [" +
                        $" [ [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}] ] ]," +
                        $" [" +
                        $" [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}] ]," +
                        $" [ [{PS(5)}], [{PS(6)}], [{PS(7)}], [{PS(8)}], [{PS(9)}] ]" +
                        $" ] ]}}";

            var multiPolygon = AssertRoundtrip<GeoPolygonCollection>(input);

            var polygon = multiPolygon.Polygons[0];

            Assert.AreEqual(1, polygon.Rings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
            }, polygon.Rings[0].Positions);

            polygon = multiPolygon.Polygons[1];
            Assert.AreEqual(2, polygon.Rings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
            }, polygon.Rings[0].Positions);

            CollectionAssert.AreEqual(new[]
            {
                P(5),
                P(6),
                P(7),
                P(8),
                P(9),
            }, polygon.Rings[1].Positions);
        }

        [Test]
        public void CanRoundripGeometryCollection()
        {
            var input = $"{{ \"type\": \"GeometryCollection\", \"geometries\": [{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}] }}, {{ \"type\": \"LineString\", \"coordinates\": [ [{PS(1)}], [{PS(2)}] ] }}] }}";

            var collection = AssertRoundtrip<GeoCollection>(input);
            var point = (GeoPoint) collection.Geometries[0];
            Assert.AreEqual(P(0), point.Position);

            var lineString = (GeoLine) collection.Geometries[1];
            Assert.AreEqual(P(1), lineString.Positions[0]);
            Assert.AreEqual(P(2), lineString.Positions[1]);

            Assert.AreEqual(2, collection.Geometries.Count);
        }

        private string PS(int number)
        {
            if (_points == 2)
            {
                return $"{1.1 * number:G17}, {2.2 * number:G17}";
            }

            return $"{1.1 * number:G17}, {2.2 * number:G17}, {3.3 * number:G17}";
        }

        private GeoPosition P(int number)
        {
            if (_points == 2)
            {
                return new GeoPosition(1.1 * number, 2.2 * number);
            }

            return new GeoPosition(1.1 * number, 2.2 * number, 3.3 * number);
        }

        private T AssertRoundtrip<T>(string json) where T: GeoObject
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

            var options = new JsonSerializerOptions()
            {
                Converters = { new GeoJsonConverter() }
            };

            // Serialize and deserialize as a base class
            var bytes = JsonSerializer.SerializeToUtf8Bytes(geometry2, typeof(GeoObject), options);
            var geometry3 = JsonSerializer.Deserialize<GeoObject>(bytes, options);

            // Serialize and deserialize as a concrete class
            var bytes2 = JsonSerializer.SerializeToUtf8Bytes(geometry3, options);
            var geometry4 = JsonSerializer.Deserialize<T>(bytes2, options);

            return geometry4;
        }
    }
}