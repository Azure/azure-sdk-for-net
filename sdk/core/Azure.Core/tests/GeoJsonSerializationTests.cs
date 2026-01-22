// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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
        private readonly ModelReaderWriterOptions _jsonOptions = new("J");
        private readonly ModelReaderWriterOptions _xmlOptions = new("X");
        private readonly int _points;

        public GeoJsonSerializationTests(int points)
        {
            _points = points;
        }

        [Test]
        public void CanRoundTripPoint()
        {
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}] }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.That(point.Coordinates, Is.EqualTo(P(0)));
        }

        [Test]
        public void CanRoundTripNullBBox()
        {
            // cspell:ignore bbox
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}], \"bbox\": null }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.That(point.Coordinates, Is.EqualTo(P(0)));
        }

        [Test]
        public void CanRoundTripBBox()
        {
            // cspell:ignore bbox
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}], \"bbox\": [ {PS(1)}, {PS(2)} ] }}";

            var point = AssertRoundtrip<GeoPoint>(input);
            Assert.That(point.Coordinates, Is.EqualTo(P(0)));
            Assert.That(point.BoundingBox.West, Is.EqualTo(P(1).Longitude));
            Assert.That(point.BoundingBox.South, Is.EqualTo(P(1).Latitude));

            Assert.That(point.BoundingBox.East, Is.EqualTo(P(2).Longitude));
            Assert.That(point.BoundingBox.North, Is.EqualTo(P(2).Latitude));

            Assert.That(point.BoundingBox.MinAltitude, Is.EqualTo(P(1).Altitude));
            Assert.That(point.BoundingBox.MaxAltitude, Is.EqualTo(P(2).Altitude));

            if (_points == 2)
            {
                Assert.That(point.BoundingBox[0], Is.EqualTo(P(1).Longitude));
                Assert.That(point.BoundingBox[1], Is.EqualTo(P(1).Latitude));

                Assert.That(point.BoundingBox[2], Is.EqualTo(P(2).Longitude));
                Assert.That(point.BoundingBox[3], Is.EqualTo(P(2).Latitude));
            }
            else
            {
                Assert.That(point.BoundingBox[0], Is.EqualTo(P(1).Longitude));
                Assert.That(point.BoundingBox[1], Is.EqualTo(P(1).Latitude));
                Assert.That(point.BoundingBox[2], Is.EqualTo(P(1).Altitude));

                Assert.That(point.BoundingBox[3], Is.EqualTo(P(2).Longitude));
                Assert.That(point.BoundingBox[4], Is.EqualTo(P(2).Latitude));
                Assert.That(point.BoundingBox[5], Is.EqualTo(P(2).Altitude));
            }
        }

        [Test]
        public void CanRoundTripAdditionalProperties()
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
            Assert.That(point.Coordinates, Is.EqualTo(P(0)));
            Assert.That(point.CustomProperties["additionalNumber"], Is.EqualTo(1));
            Assert.That(point.CustomProperties["additionalNumber2"], Is.EqualTo(2.2));
            Assert.That(point.CustomProperties["additionalNumber3"], Is.EqualTo(9999999999999999999L));
            Assert.That(point.CustomProperties["additionalString"], Is.EqualTo("hello"));
            Assert.That(point.CustomProperties["additionalNull"], Is.EqualTo(null));
            Assert.That(point.CustomProperties["additionalBool"], Is.EqualTo(true));
            Assert.That(point.CustomProperties["additionalArray"], Is.EqualTo(new object[] { 1, 2.2, 9999999999999999999L, "hello", true, null }));

            Assert.That(point.TryGetCustomProperty("additionalObject", out var obj), Is.EqualTo(true));
            Assert.That(obj is IReadOnlyDictionary<string, object>, Is.True);
            var dictionary = (IReadOnlyDictionary<string, object>)obj;
            Assert.That(dictionary["additionalNumber"], Is.EqualTo(1));
            Assert.That(dictionary["additionalNumber2"], Is.EqualTo(2.2));
        }

        [Test]
        public void CanRoundTripPolygon()
        {
            var input = $" {{ \"type\": \"Polygon\", \"coordinates\": [ [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}], [{PS(0)}] ] ] }}";

            var polygon = AssertRoundtrip<GeoPolygon>(input);
            Assert.That(polygon.Rings.Count, Is.EqualTo(1));

            Assert.That(polygon.Rings[0].Coordinates, Is.EqualTo(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
                P(0),
            }).AsCollection);
        }

        [Test]
        public void CanRoundTripPolygonHoles()
        {
            var input = $"{{ \"type\": \"Polygon\", \"coordinates\": [" +
                        $" [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}], [{PS(0)}] ]," +
                        $" [ [{PS(5)}], [{PS(6)}], [{PS(7)}], [{PS(8)}], [{PS(9)}], [{PS(5)}] ]" +
                        $" ] }}";

            var polygon = AssertRoundtrip<GeoPolygon>(input);
            Assert.That(polygon.Rings.Count, Is.EqualTo(2));

            Assert.That(polygon.Rings[0].Coordinates, Is.EqualTo(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
                P(0),
            }).AsCollection);

            Assert.That(polygon.Rings[1].Coordinates, Is.EqualTo(new[]
            {
                P(5),
                P(6),
                P(7),
                P(8),
                P(9),
                P(5),
            }).AsCollection);
        }

        [Test]
        public void CanRoundTripMultiPoint()
        {
            var input = $"{{ \"type\": \"MultiPoint\", \"coordinates\": [ [{PS(0)}], [{PS(1)}] ] }}";

            var multipoint = AssertRoundtrip<GeoPointCollection>(input);
            Assert.That(multipoint.Points.Count, Is.EqualTo(2));

            Assert.That(multipoint.Points[0].Coordinates, Is.EqualTo(P(0)));
            Assert.That(multipoint.Points[1].Coordinates, Is.EqualTo(P(1)));
        }

        [Test]
        public void CanRoundTripMultiLineString()
        {
            var input = $"{{ \"type\": \"MultiLineString\", \"coordinates\": [ [ [{PS(0)}], [{PS(1)}] ], [ [{PS(2)}], [{PS(3)}] ] ] }}";

            var polygon = AssertRoundtrip<GeoLineStringCollection>(input);
            Assert.That(polygon.Lines.Count, Is.EqualTo(2));

            Assert.That(polygon.Lines[0].Coordinates, Is.EqualTo(new[]
            {
                P(0),
                P(1)
            }).AsCollection);

            Assert.That(polygon.Lines[1].Coordinates, Is.EqualTo(new[]
            {
                P(2),
                P(3)
            }).AsCollection);
        }

        [Test]
        public void CanRoundTripMultiPolygon()
        {
            var input = $" {{ \"type\": \"MultiPolygon\", \"coordinates\": [" +
                        $" [ [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}], [{PS(0)}] ] ]," +
                        $" [" +
                        $" [ [{PS(0)}], [{PS(1)}], [{PS(2)}], [{PS(3)}], [{PS(4)}], [{PS(0)}] ]," +
                        $" [ [{PS(5)}], [{PS(6)}], [{PS(7)}], [{PS(8)}], [{PS(9)}], [{PS(5)}] ]" +
                        $" ] ]}}";

            var multiPolygon = AssertRoundtrip<GeoPolygonCollection>(input);

            var polygon = multiPolygon.Polygons[0];

            Assert.That(polygon.Rings.Count, Is.EqualTo(1));

            Assert.That(polygon.Rings[0].Coordinates, Is.EqualTo(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
                P(0),
            }).AsCollection);

            polygon = multiPolygon.Polygons[1];
            Assert.That(polygon.Rings.Count, Is.EqualTo(2));

            Assert.That(polygon.Rings[0].Coordinates, Is.EqualTo(new[]
            {
                P(0),
                P(1),
                P(2),
                P(3),
                P(4),
                P(0),
            }).AsCollection);

            Assert.That(polygon.Rings[1].Coordinates, Is.EqualTo(new[]
            {
                P(5),
                P(6),
                P(7),
                P(8),
                P(9),
                P(5),
            }).AsCollection);
        }

        [Test]
        public void CanRoundTripGeometryCollection()
        {
            var input = $"{{ \"type\": \"GeometryCollection\", \"geometries\": [{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}] }}, {{ \"type\": \"LineString\", \"coordinates\": [ [{PS(1)}], [{PS(2)}] ] }}] }}";

            var collection = AssertRoundtrip<GeoCollection>(input);
            var point = (GeoPoint)collection.Geometries[0];
            Assert.That(point.Coordinates, Is.EqualTo(P(0)));

            var lineString = (GeoLineString)collection.Geometries[1];
            Assert.That(lineString.Coordinates[0], Is.EqualTo(P(1)));
            Assert.That(lineString.Coordinates[1], Is.EqualTo(P(2)));

            Assert.That(collection.Geometries.Count, Is.EqualTo(2));
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

        private T AssertRoundtrip<T>(string json) where T : GeoObject
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

        private GeoPoint AssertRoundtripMRW(string json)
        {
            BinaryData data = new BinaryData(json);
            var point = ModelReaderWriter.Read<GeoPoint>(data, _jsonOptions);

            // Write using IJsonModel
            var memoryStreamOutput = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(memoryStreamOutput))
            {
                ((IJsonModel<GeoPoint>)point).Write(writer, _jsonOptions);
            }

            // Read back using IJsonModel
            var jsonReader2 = new Utf8JsonReader(memoryStreamOutput.ToArray());
            var point2 = ((IJsonModel<GeoPoint>)point).Create(ref jsonReader2, _jsonOptions);

            // Write using IPersistableModel
            var binaryData = ((IPersistableModel<GeoPoint>)point2).Write(_jsonOptions);

            // Read back using IPersistableModel
            var point3 = ((IPersistableModel<GeoPoint>)point2).Create(binaryData, _jsonOptions);

            return point3;
        }

        [Test]
        public void CanRoundTripPointMRW()
        {
            var input = $"{{ \"type\": \"Point\", \"coordinates\": [{PS(0)}] }}";

            var point = AssertRoundtripMRW(input);

            Assert.That(point.Coordinates, Is.EqualTo(P(0)));
        }

        [Test]
        public void CanRoundTripComplexPointMRW()
        {
            var input = """{"type":"Point","coordinates":[-122.091954,47.607148],"bbox":[-180,-90,180,90],"name":"Test Point","value":42}""";

            var point = AssertRoundtripMRW(input);

            Assert.That(point.Coordinates.Longitude, Is.EqualTo(-122.091954).Within(1e-10));
            Assert.That(point.Coordinates.Latitude, Is.EqualTo(47.607148).Within(1e-10));
            Assert.That(point.BoundingBox, Is.Not.Null);
            Assert.That(point.BoundingBox.West, Is.EqualTo(-180));
            Assert.That(point.BoundingBox.South, Is.EqualTo(-90));
            Assert.That(point.BoundingBox.East, Is.EqualTo(180));
            Assert.That(point.BoundingBox.North, Is.EqualTo(90));
            Assert.That(point.CustomProperties["name"], Is.EqualTo("Test Point"));
            Assert.That(point.CustomProperties["value"], Is.EqualTo(42));
        }

        [Test]
        public void NonJsonFormatThrowsMRW()
        {
            var point = new GeoPoint(-122.091954, 47.607148);
            var jsonModel = (IJsonModel<GeoPoint>)point;
            var persistableModel = (IPersistableModel<GeoPoint>)point;

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            var binaryData = BinaryData.FromString("""{"type":"Point","coordinates":[-122.091954,47.607148]}""");

            Assert.Throws<FormatException>(() => jsonModel.Write(writer, _xmlOptions));
            Assert.Throws<FormatException>(() => persistableModel.Write(_xmlOptions));
            Assert.Throws<FormatException>(() => persistableModel.Create(binaryData, _xmlOptions));
        }
    }
}
