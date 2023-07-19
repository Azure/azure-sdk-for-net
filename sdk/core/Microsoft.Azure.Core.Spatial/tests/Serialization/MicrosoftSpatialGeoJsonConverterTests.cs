// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core.Serialization;
using Microsoft.Spatial;
using NUnit.Framework;

namespace Microsoft.Azure.Core.Spatial.Tests.Serialization
{
    public class MicrosoftSpatialGeoJsonConverterTests
    {
        private static readonly List<GeographyGeoJson> GeographyGeoJsons = new List<GeographyGeoJson>()
        {
            new GeographyGeoJson
            {
                Geography = GeographyFactory.Point(25.086071, -121.726906).Build(),
                GeoJson = "{\"type\":\"Point\",\"coordinates\":[-121.726906,25.086071]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.LineString(10, 30).LineTo(30, 10).LineTo(40, 40).Build(),
                GeoJson = "{\"type\":\"LineString\",\"coordinates\":[[30,10],[10,30],[40,40]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.Polygon().Ring(10, 35).LineTo(45, 45).LineTo(40,15).LineTo(20, 10).Ring(30,20).LineTo(35,35).LineTo(20, 30).Build(),
                GeoJson = "{\"type\":\"Polygon\",\"coordinates\":[[[35,10],[45,45],[15,40],[10,20],[35,10]],[[20,30],[35,35],[30,20],[20,30]]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.MultiPoint().Point(40, 10).Point(30, 40).Point(20, 20).Point(10, 30).Build(),
                GeoJson = "{\"type\":\"MultiPoint\",\"coordinates\":[[10,40],[40,30],[20,20],[30,10]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.MultiLineString().LineString().LineTo(10,10).LineTo(20, 20).LineTo(40, 10).LineString(40, 40).LineTo(30, 30).LineTo(20, 40).LineTo(10, 30).Build(),
                GeoJson= "{\"type\":\"MultiLineString\",\"coordinates\":[[[10,10],[20,20],[10,40]],[[40,40],[30,30],[40,20],[30,10]]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.MultiPolygon().Polygon().Ring(35,20).LineTo(30,10).LineTo(10,10).LineTo(5,30).LineTo(20,45).Ring(20,30).LineTo(15,20).LineTo(25,20).Polygon().Ring(40,40).LineTo(45,20).LineTo(30,45).Build(),
                GeoJson = "{\"type\":\"MultiPolygon\",\"coordinates\":[[[[20,35],[10,30],[10,10],[30,5],[45,20],[20,35]],[[30,20],[20,15],[20,25],[30,20]]],[[[40,40],[20,45],[45,30],[40,40]]]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.Collection().Point(10, 40).LineString().LineTo(10, 10).LineTo(20, 20).LineTo(40, 10).Polygon().Ring(40, 40).LineTo(45, 20).LineTo(30, 45).Build(),
                GeoJson = "{\"type\":\"GeometryCollection\",\"geometries\":[{\"type\":\"Point\",\"coordinates\":[40,10]},{\"type\":\"LineString\",\"coordinates\":[[10,10],[20,20],[10,40]]},{\"type\":\"Polygon\",\"coordinates\":[[[40,40],[20,45],[45,30],[40,40]]]}]}",
            },
        };

        [Test]
        public void CanConvert()
        {
            MicrosoftSpatialGeoJsonConverter converter = new MicrosoftSpatialGeoJsonConverter();

            Assert.IsFalse(converter.CanConvert(typeof(Geography)));

            // This list is the implementation types. CanConvert will see these when serializing.
            List<Type> types = (from p in GeographyGeoJsons
                                group p by p.Geography.GetType()
                                into grouped
                                select grouped.Key).Distinct().ToList();

            foreach (Type type in types)
            {
                Assert.IsTrue(converter.CanConvert(type));
            }

            // During a deserialization request, you pass the base classes, so these also must pass.
            types = (from p in GeographyGeoJsons
                     group p by p.Geography.GetType().BaseType
                     into grouped
                     select grouped.Key).Distinct().ToList();

            foreach (Type type in types)
            {
                Assert.IsTrue(converter.CanConvert(type));
            }
        }

        [Test]
        public void Read()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters =
                {
                    new MicrosoftSpatialGeoJsonConverter(),
                },
            };

            foreach (GeographyGeoJson geographyGeoJson in GeographyGeoJsons)
            {
                object geography = JsonSerializer.Deserialize(geographyGeoJson.GeoJson, geographyGeoJson.Geography.GetType().BaseType, options);

                Assert.AreEqual(geography, geographyGeoJson.Geography);
            }
        }

        [Test]
        public void ReadMore()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters =
                {
                    new MicrosoftSpatialGeoJsonConverter(),
                },
            };

            string json = @"{""type"":""Point"",""coordinates"":[-121.726906,46.879967,2541.118],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}}";

            GeographyPoint point = JsonSerializer.Deserialize<GeographyPoint>(json, options);

            Assert.AreEqual(46.879967, point.Latitude);
            Assert.AreEqual(-121.726906, point.Longitude);

            // Not currently supported.
            Assert.IsNull(point.Z);
        }

        [Test]
        public void ReadIntegers()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters =
                {
                    new MicrosoftSpatialGeoJsonConverter(),
                },
            };

            GeographyPoint point = JsonSerializer.Deserialize<GeographyPoint>(@"{""type"":""Point"",""coordinates"":[-121,46]}", options);

            Assert.AreEqual(46.0, point.Latitude);
            Assert.AreEqual(-121.0, point.Longitude);
        }

        [TestCaseSource(nameof(ReadBadJsonData))]
        public void ReadBadJson(string json, string expectedExceptionMessage)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters =
                {
                    new MicrosoftSpatialGeoJsonConverter(),
                },
            };

            JsonException expectedException = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<GeographyPoint>(json, options));
            Assert.AreEqual(expectedExceptionMessage, expectedException.Message);
        }

        private static IEnumerable<TestCaseData> ReadBadJsonData => new[]
        {
            new TestCaseData(@"[]", $"Deserialization failed. Expected token: '{nameof(JsonTokenType.StartObject)}'."),
            new TestCaseData(@"{}", "Deserialization failed. Required GeoJson property 'type' not found."),
            new TestCaseData(@"{""type"":""point""}", "Deserialization failed. GeoJson property 'type' values are case sensitive. Use 'Point' instead."),
            new TestCaseData(@"{""type"":""Polygon""}", "Deserialization failed. Required GeoJson property 'coordinates' not found."),
            new TestCaseData(@"{""Type"":""Point""}", "Deserialization failed. Required GeoJson property 'type' not found."),
            new TestCaseData(@"{""type"":""Point"",""Coordinates"":[-121.726906,46.879967,2541.118]}", $"Deserialization failed. Required GeoJson property 'coordinates' not found."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":-121.726906}", $"Deserialization failed. Expected token: '{nameof(JsonTokenType.StartArray)}'."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[]}", $"Deserialization failed. Expected token: '{nameof(JsonTokenType.Number)}'."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[""foo""]}", $"Deserialization failed. Expected token: '{nameof(JsonTokenType.Number)}'."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[-121.726906]}", $"Deserialization failed. Expected token: '{nameof(JsonTokenType.Number)}'."),
            new TestCaseData("{\"type\":\"LineString\",\"coordinates\":[[30,10]]}", "Deserialization of GeographyLineString failed. LineString must contain at least two points."),
            new TestCaseData("{\"type\":\"Polygon\",\"coordinates\":[[[30,10],[40,40],[30,10]]]}", "Deserialization of GeographyPolygon failed. Polygon must have at least four points."),
            new TestCaseData("{\"type\":\"Polygon\",\"coordinates\":[[[30,10],[40,40],[20,40],[10,20],[30,11]]]}", "Deserialization of GeographyPolygon failed. Polygon first and last point must be the same."),
            new TestCaseData("{\"type\":\"GeometryCollection\"}", "Deserialization failed. Required GeoJson property 'geometries' not found."),
        };

        [Test]
        public void Write()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters =
                {
                    new MicrosoftSpatialGeoJsonConverter(),
                },
            };

            foreach (GeographyGeoJson geographyGeoJson in GeographyGeoJsons)
            {
                // Very strange issue when serializing on net462. If you don't pass the inputType, CanConvert receives Geography
                // as the typeToConvert, which actually needs to return false.
                string geoJson = JsonSerializer.Serialize(geographyGeoJson.Geography, geographyGeoJson.Geography.GetType(), options);

                Assert.AreEqual(geographyGeoJson.GeoJson, geoJson);
            }
        }

        [Test]
        public void ThrowsActionableExceptionMessage()
        {
            string json = @"{
  ""type"": ""Point"",
  ""coordinates"": [
    -121.726906
  ]
}";
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters =
                {
                    new MicrosoftSpatialGeoJsonConverter(),
                },
            };

            JsonException expectedException = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<GeographyPoint>(json, options));
            Assert.AreEqual("$", expectedException.Path);
            Assert.AreEqual(3, expectedException.BytePositionInLine);
            Assert.AreEqual(4, expectedException.LineNumber);
        }
    }
}
