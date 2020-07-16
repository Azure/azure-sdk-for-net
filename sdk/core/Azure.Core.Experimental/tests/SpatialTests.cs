// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using Azure.Core.Spatial;
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
            Assert.AreEqual(P(0), point.Coordinate);
        }

        [Test]
        public void CanRoundripBBox()
        {
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}], \"bbox\": [ {PS(1)}, {PS(2)} ] }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.AreEqual(P(0), point.Coordinate);
            Assert.AreEqual(P(1).AsGeographyCoordinate().Longitude, point.BoundingBox.Value.AsGeographyBoundingBox().West);
            Assert.AreEqual(P(1).AsGeographyCoordinate().Latitude, point.BoundingBox.Value.AsGeographyBoundingBox().South);

            Assert.AreEqual(P(2).AsGeographyCoordinate().Longitude, point.BoundingBox.Value.AsGeographyBoundingBox().East);
            Assert.AreEqual(P(2).AsGeographyCoordinate().Latitude, point.BoundingBox.Value.AsGeographyBoundingBox().North);

            Assert.AreEqual(P(1).AsGeographyCoordinate().Altitude, point.BoundingBox.Value.AsGeographyBoundingBox().MinAltitude);
            Assert.AreEqual(P(2).AsGeographyCoordinate().Altitude, point.BoundingBox.Value.AsGeographyBoundingBox().MaxAltitude);


            Assert.AreEqual(P(1).AsGeometryCoordinate().X, point.BoundingBox.Value.AsGeometryBoundingBox().MinX);
            Assert.AreEqual(P(1).AsGeometryCoordinate().Y, point.BoundingBox.Value.AsGeometryBoundingBox().MinY);

            Assert.AreEqual(P(2).AsGeometryCoordinate().X, point.BoundingBox.Value.AsGeometryBoundingBox().MaxX);
            Assert.AreEqual(P(2).AsGeometryCoordinate().Y, point.BoundingBox.Value.AsGeometryBoundingBox().MaxY);

            Assert.AreEqual(P(1).AsGeometryCoordinate().Z, point.BoundingBox.Value.AsGeometryBoundingBox().MinZ);
            Assert.AreEqual(P(2).AsGeometryCoordinate().Z, point.BoundingBox.Value.AsGeometryBoundingBox().MaxZ);
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
            Assert.AreEqual(P(0), point.Coordinate);
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
            }, polygon.Rings[0].Coordinates);
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
            }, polygon.Rings[0].Coordinates);

            CollectionAssert.AreEqual(new[]
            {
                P(5),
                P(6),
                P(7),
                P(8),
                P(9),
            }, polygon.Rings[1].Coordinates);
        }

        [Test]
        public void CanRoundripMultiPoint()
        {
            var input = $"{{ \"type\": \"MultiPoint\", \"coordinates\": [ [{PS(0)}], [{PS(1)}] ] }}";

            var multipoint = AssertRoundtrip<GeoPointCollection>(input);
            Assert.AreEqual(2, multipoint.Points.Count);

            Assert.AreEqual(P(0), multipoint.Points[0].Coordinate);
            Assert.AreEqual(P(1), multipoint.Points[1].Coordinate);
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
            }, polygon.Lines[0].Coordinates);

            CollectionAssert.AreEqual(new[]
            {
                P(2),
                P(3)
            }, polygon.Lines[1].Coordinates);
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

            var multiPolygon = AssertRoundtrip<GeoMultiPolygon>(input);

            var polygon = multiPolygon.Polygons[0];

            Assert.AreEqual(1, polygon.Rings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
            }, polygon.Rings[0].Coordinates);

            polygon = multiPolygon.Polygons[1];
            Assert.AreEqual(2, polygon.Rings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
            }, polygon.Rings[0].Coordinates);

            CollectionAssert.AreEqual(new[]
            {
                P(5),
                P(6),
                P(7),
                P(8),
                P(9),
            }, polygon.Rings[1].Coordinates);
        }

        [Test]
        public void CanRoundripGeometryCollection()
        {
            var input = $"{{ \"type\": \"GeometryCollection\", \"geometries\": [{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}] }}, {{ \"type\": \"LineString\", \"coordinates\": [ [{PS(1)}], [{PS(2)}] ] }}] }}";

            var collection = AssertRoundtrip<GeoCollection>(input);
            var point = (GeoPoint) collection.Geometries[0];
            Assert.AreEqual(P(0), point.Coordinate);

            var lineString = (GeoLine) collection.Geometries[1];
            Assert.AreEqual(P(1), lineString.Coordinates[0]);
            Assert.AreEqual(P(2), lineString.Coordinates[1]);

            Assert.AreEqual(2, collection.Geometries.Count);
        }

        [Test]
        public void GeoCoordinateFormatsToString()
        {
            Assert.AreEqual("[1, 2]", new GeoCoordinate(1, 2, null).ToString());
            Assert.AreEqual("[1, 2, 3]", new GeoCoordinate(1, 2, 3).ToString());
        }

        [Test]
        public void GeometryCoordinateFormatsToString()
        {
            Assert.AreEqual("X: 1, Y: 2", new GeometryCoordinate(1, 2).ToString());
            Assert.AreEqual("X: 1, Y: 2, Z: 3", new GeometryCoordinate(1, 2, 3).ToString());
        }

        [Test]
        public void GeographyCoordinateFormatsToString()
        {
            Assert.AreEqual("Longitude: 1, Latitude: 2", new GeographyCoordinate(1, 2).ToString());
            Assert.AreEqual("Longitude: 1, Latitude: 2, Altitude: 3", new GeographyCoordinate(1, 2, 3).ToString());
        }

        private string PS(int number)
        {
            if (_points == 2)
            {
                return $"{1.1 * number:G17}, {2.2 * number:G17}";
            }

            return $"{1.1 * number:G17}, {2.2 * number:G17}, {3.3 * number:G17}";
        }

        private GeoCoordinate P(int number)
        {
            if (_points == 2)
            {
                return new GeoCoordinate(new GeographyCoordinate(1.1 * number, 2.2 * number));
            }

            return new GeoCoordinate(new GeographyCoordinate(1.1 * number, 2.2 * number, 3.3 * number));
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