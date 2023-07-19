// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.Serialization;
using Microsoft.Spatial;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.Core.Spatial.NewtonsoftJson.Tests
{
    public class NewtonsoftJsonMicrosoftSpatialGeoJsonConverterTests
    {
        /// <summary>
        /// Note, Newtonsoft serialization will not abbreviate a double to an int when possible (as opposed to System.Text.Json.)
        /// </summary>
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
                GeoJson = "{\"type\":\"LineString\",\"coordinates\":[[30.0,10.0],[10.0,30.0],[40.0,40.0]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.Polygon().Ring(10, 35).LineTo(45, 45).LineTo(40,15).LineTo(20, 10).Ring(30,20).LineTo(35,35).LineTo(20, 30).Build(),
                GeoJson = "{\"type\":\"Polygon\",\"coordinates\":[[[35.0,10.0],[45.0,45.0],[15.0,40.0],[10.0,20.0],[35.0,10.0]],[[20.0,30.0],[35.0,35.0],[30.0,20.0],[20.0,30.0]]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.MultiPoint().Point(40, 10).Point(30, 40).Point(20, 20).Point(10, 30).Build(),
                GeoJson = "{\"type\":\"MultiPoint\",\"coordinates\":[[10.0,40.0],[40.0,30.0],[20.0,20.0],[30.0,10.0]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.MultiLineString().LineString().LineTo(10,10).LineTo(20, 20).LineTo(40, 10).LineString(40, 40).LineTo(30, 30).LineTo(20, 40).LineTo(10, 30).Build(),
                GeoJson= "{\"type\":\"MultiLineString\",\"coordinates\":[[[10.0,10.0],[20.0,20.0],[10.0,40.0]],[[40.0,40.0],[30.0,30.0],[40.0,20.0],[30.0,10.0]]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.MultiPolygon().Polygon().Ring(35,20).LineTo(30,10).LineTo(10,10).LineTo(5,30).LineTo(20,45).Ring(20,30).LineTo(15,20).LineTo(25,20).Polygon().Ring(40,40).LineTo(45,20).LineTo(30,45).Build(),
                GeoJson = "{\"type\":\"MultiPolygon\",\"coordinates\":[[[[20.0,35.0],[10.0,30.0],[10.0,10.0],[30.0,5.0],[45.0,20.0],[20.0,35.0]],[[30.0,20.0],[20.0,15.0],[20.0,25.0],[30.0,20.0]]],[[[40.0,40.0],[20.0,45.0],[45.0,30.0],[40.0,40.0]]]]}",
            },
            new GeographyGeoJson
            {
                Geography = GeographyFactory.Collection().Point(10, 40).LineString().LineTo(10, 10).LineTo(20, 20).LineTo(40, 10).Polygon().Ring(40, 40).LineTo(45, 20).LineTo(30, 45).Build(),
                GeoJson = "{\"type\":\"GeometryCollection\",\"geometries\":[{\"type\":\"Point\",\"coordinates\":[40.0,10.0]},{\"type\":\"LineString\",\"coordinates\":[[10.0,10.0],[20.0,20.0],[10.0,40.0]]},{\"type\":\"Polygon\",\"coordinates\":[[[40.0,40.0],[20.0,45.0],[45.0,30.0],[40.0,40.0]]]}]}",
            },
        };

        [Test]
        public void CanConvert()
        {
            NewtonsoftJsonMicrosoftSpatialGeoJsonConverter converter = new NewtonsoftJsonMicrosoftSpatialGeoJsonConverter();

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
        public void ReadJson()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters =
                {
                    new NewtonsoftJsonMicrosoftSpatialGeoJsonConverter(),
                },
            };

            foreach (GeographyGeoJson geographyGeoJson in GeographyGeoJsons)
            {
                object geography = JsonConvert.DeserializeObject(geographyGeoJson.GeoJson, geographyGeoJson.Geography.GetType().BaseType, settings);

                Assert.AreEqual(geography, geographyGeoJson.Geography);
            }
        }

        [Test]
        public void ReadJsonMore()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters =
                {
                    new NewtonsoftJsonMicrosoftSpatialGeoJsonConverter(),
                },
            };

            GeographyPoint point = JsonConvert.DeserializeObject<GeographyPoint>(@"{""type"":""Point"",""coordinates"":[-121.726906,46.879967,2541.118],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}}", settings);

            Assert.AreEqual(point.Latitude, 46.879967);
            Assert.AreEqual(point.Longitude, -121.726906);

            // Not currently supported.
            Assert.IsNull(point.Z);
        }

        [Test]
        public void ReadIntegers()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters =
                {
                    new NewtonsoftJsonMicrosoftSpatialGeoJsonConverter(),
                },
            };

            GeographyPoint point = JsonConvert.DeserializeObject<GeographyPoint>(@"{""type"":""Point"",""coordinates"":[-121,46]}", settings);

            Assert.AreEqual(46.0, point.Latitude);
            Assert.AreEqual(-121.0, point.Longitude);

            // Not currently supported.
            Assert.IsNull(point.Z);
        }

        [TestCaseSource(nameof(ReadBadJsonData))]
        public void ReadBadJson(string json, string expectedExceptionMessage)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters =
                {
                    new NewtonsoftJsonMicrosoftSpatialGeoJsonConverter(),
                },
            };

            JsonSerializationException expectedException = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<GeographyPoint>(json, settings));
            Assert.AreEqual(expectedExceptionMessage, expectedException.Message);
        }

        private static IEnumerable<TestCaseData> ReadBadJsonData => new[]
        {
            new TestCaseData(@"[]", $"Deserialization failed: Expected token '{nameof(JsonToken.StartObject)}'."),
            new TestCaseData(@"{}", "Deserialization failed: Required GeoJson property 'type' not found."),
            new TestCaseData(@"{""type"":""point""}", "Deserialization failed: GeoJson property 'type' values are case sensitive. Use 'Point' instead."),
            new TestCaseData(@"{""type"":""Polygon""}", "Deserialization failed: Required GeoJson property 'coordinates' not found."),
            new TestCaseData(@"{""Type"":""Point""}", "Deserialization failed: Required GeoJson property 'type' not found."),
            new TestCaseData(@"{""type"":""Point"",""Coordinates"":[-121.726906,46.879967,2541.118]}", $"Deserialization failed: Required GeoJson property 'coordinates' not found."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":-121.726906}", $"Deserialization failed: Expected token '{nameof(JsonToken.StartArray)}'."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[]}", $"Deserialization failed: Expected token '{nameof(JsonToken.Integer)}' or '{nameof(JsonToken.Float)}'."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[""foo""]}", $"Deserialization failed: Expected token '{nameof(JsonToken.Integer)}' or '{nameof(JsonToken.Float)}'."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[-121.726906]}", $"Deserialization failed: Expected token '{nameof(JsonToken.Integer)}' or '{nameof(JsonToken.Float)}'."),
            new TestCaseData("{\"type\":\"LineString\",\"coordinates\":[[30,10]]}", "Deserialization failed: GeoJson type 'LineString' must contain at least two points."),
            new TestCaseData("{\"type\":\"Polygon\",\"coordinates\":[[[30,10],[40,40],[30,10]]]}", "Deserialization failed: GeoJson type 'Polygon' must contain at least four points."),
            new TestCaseData("{\"type\":\"Polygon\",\"coordinates\":[[[30,10],[40,40],[20,40],[10,20],[30,11]]]}", "Deserialization failed: GeoJson type 'Polygon' has an invalid ring, its first and last points do not match."),
            new TestCaseData("{\"type\":\"GeometryCollection\"}", "Deserialization failed: Required GeoJson property 'geometries' not found."),
        };

        [Test]
        public void WriteJson()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters =
                {
                    new NewtonsoftJsonMicrosoftSpatialGeoJsonConverter(),
                },
            };

            foreach (GeographyGeoJson geographyGeoJson in GeographyGeoJsons)
            {
                string geoJson = JsonConvert.SerializeObject(geographyGeoJson.Geography, settings);

                Assert.AreEqual(geographyGeoJson.GeoJson, geoJson);
            }
        }
    }
}
