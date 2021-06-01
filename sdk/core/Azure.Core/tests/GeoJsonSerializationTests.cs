﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(2)]
    [TestFixture(3)]
    public class GeoJsonSerializationTests
    {
        private readonly int _points;

        public GeoJsonSerializationTests(int points)
        {
            _points = points;
        }

        [Test]
        public void CanRoundripPoint()
        {
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}] }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.AreEqual(P(0), point.Coordinates);
        }

        [Test]
        public void CanRoundripBBox()
        {
            // cspell:ignore bbox
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}], \"bbox\": [ {PS(1)}, {PS(2)} ] }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.AreEqual(P(0), point.Coordinates);
            Assert.AreEqual(P(1).Longitude, point.BoundingBox.West);
            Assert.AreEqual(P(1).Latitude, point.BoundingBox.South);

            Assert.AreEqual(P(2).Longitude, point.BoundingBox.East);
            Assert.AreEqual(P(2).Latitude, point.BoundingBox.North);

            Assert.AreEqual(P(1).Altitude, point.BoundingBox.MinAltitude);
            Assert.AreEqual(P(2).Altitude, point.BoundingBox.MaxAltitude);

            if (_points == 2)
            {
                Assert.AreEqual(P(1).Longitude, point.BoundingBox[0]);
                Assert.AreEqual(P(1).Latitude, point.BoundingBox[1]);

                Assert.AreEqual(P(2).Longitude, point.BoundingBox[2]);
                Assert.AreEqual(P(2).Latitude, point.BoundingBox[3]);
            }
            else
            {
                Assert.AreEqual(P(1).Longitude, point.BoundingBox[0]);
                Assert.AreEqual(P(1).Latitude, point.BoundingBox[1]);
                Assert.AreEqual(P(1).Altitude, point.BoundingBox[2]);

                Assert.AreEqual(P(2).Longitude, point.BoundingBox[3]);
                Assert.AreEqual(P(2).Latitude, point.BoundingBox[4]);
                Assert.AreEqual(P(2).Altitude, point.BoundingBox[5]);
            }
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
                        $" \"additionalArray\": [1, 2.2, 9999999999999999999, \"hello\", true, null]," +
                        $" \"additionalObject\": {{ " +
                        $"    \"additionalNumber\": 1," +
                        $"    \"additionalNumber2\": 2.2" +
                        $" }}" +
                        $" }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.AreEqual(P(0), point.Coordinates);
            Assert.AreEqual(1, point.CustomProperties["additionalNumber"]);
            Assert.AreEqual(2.2, point.CustomProperties["additionalNumber2"]);
            Assert.AreEqual(9999999999999999999L, point.CustomProperties["additionalNumber3"]);
            Assert.AreEqual("hello", point.CustomProperties["additionalString"]);
            Assert.AreEqual(null, point.CustomProperties["additionalNull"]);
            Assert.AreEqual(true, point.CustomProperties["additionalBool"]);
            Assert.AreEqual(new object[] {1, 2.2, 9999999999999999999L, "hello", true, null}, point.CustomProperties["additionalArray"]);

            Assert.AreEqual(true, point.TryGetCustomProperty("additionalObject", out var obj));
            Assert.True(obj is IReadOnlyDictionary<string, object>);
            var dictionary = (IReadOnlyDictionary<string, object>) obj;
            Assert.AreEqual(1, dictionary["additionalNumber"]);
            Assert.AreEqual(2.2, dictionary["additionalNumber2"]);
        }

        [Test]
        public void CanRoundripPolygon()
        {
            var input = $" {{ \"type\": \"Polygon\", \"coordinates\": [ [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}], [{PS(0)}] ] ] }}";

            var polygon = AssertRoundtrip<GeoPolygon>(input);
            Assert.AreEqual(1, polygon.Rings.Count);

            CollectionAssert.AreEqual(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
                P(0),
            }, polygon.Rings[0].Coordinates);
        }

        [Test]
        public void CanRoundripPolygonHoles()
        {
            var input = $"{{ \"type\": \"Polygon\", \"coordinates\": [" +
                        $" [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}], [{PS(0)}] ]," +
                        $" [ [{PS(5)}], [{PS(6)}], [{PS(7)}], [{PS(8)}], [{PS(9)}], [{PS(5)}] ]" +
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
                P(0),
            }, polygon.Rings[0].Coordinates);

            CollectionAssert.AreEqual(new[]
            {
                P(5),
                P(6),
                P(7),
                P(8),
                P(9),
                P(5),
            }, polygon.Rings[1].Coordinates);
        }

        [Test]
        public void CanRoundripMultiPoint()
        {
            var input = $"{{ \"type\": \"MultiPoint\", \"coordinates\": [ [{PS(0)}], [{PS(1)}] ] }}";

            var multipoint = AssertRoundtrip<GeoPointCollection>(input);
            Assert.AreEqual(2, multipoint.Points.Count);

            Assert.AreEqual(P(0), multipoint.Points[0].Coordinates);
            Assert.AreEqual(P(1), multipoint.Points[1].Coordinates);
        }

        [Test]
        public void CanRoundripMultiLineString()
        {
            var input = $"{{ \"type\": \"MultiLineString\", \"coordinates\": [ [ [{PS(0)}], [{PS(1)}] ], [ [{PS(2)}], [{PS(3)}] ] ] }}";

            var polygon = AssertRoundtrip<GeoLineStringCollection>(input);
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
                        $" [ [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}], [{PS(0)}] ] ]," +
                        $" [" +
                        $" [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}], [{PS(0)}] ]," +
                        $" [ [{PS(5)}], [{PS(6)}], [{PS(7)}], [{PS(8)}], [{PS(9)}], [{PS(5)}] ]" +
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
                P(0),
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
                P(0),
            }, polygon.Rings[0].Coordinates);

            CollectionAssert.AreEqual(new[]
            {
                P(5),
                P(6),
                P(7),
                P(8),
                P(9),
                P(5),
            }, polygon.Rings[1].Coordinates);
        }

        [Test]
        public void CanRoundripGeometryCollection()
        {
            var input = $"{{ \"type\": \"GeometryCollection\", \"geometries\": [{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}] }}, {{ \"type\": \"LineString\", \"coordinates\": [ [{PS(1)}], [{PS(2)}] ] }}] }}";

            var collection = AssertRoundtrip<GeoCollection>(input);
            var point = (GeoPoint) collection.Geometries[0];
            Assert.AreEqual(P(0), point.Coordinates);

            var lineString = (GeoLineString) collection.Geometries[1];
            Assert.AreEqual(P(1), lineString.Coordinates[0]);
            Assert.AreEqual(P(2), lineString.Coordinates[1]);

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

            // Serialize and deserialize as a base class
            var bytes = JsonSerializer.SerializeToUtf8Bytes(geometry2, typeof(GeoObject));
            var geometry3 = JsonSerializer.Deserialize<GeoObject>(bytes);

            // Serialize and deserialize as a concrete class
            var bytes2 = JsonSerializer.SerializeToUtf8Bytes(geometry3);
            var geometry4 = JsonSerializer.Deserialize<T>(bytes2);

            return geometry4;
        }
    }
}