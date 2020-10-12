// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.Serialization;
using Microsoft.Spatial;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.Core.Spatial.NewtonsoftJson.Tests
{
    public class NewtonsoftJsonMicrosoftSpatialGeoJsonConverterTests
    {
        [Test]
        public void CanConvert()
        {
            NewtonsoftJsonMicrosoftSpatialGeoJsonConverter converter = new NewtonsoftJsonMicrosoftSpatialGeoJsonConverter();
            Assert.IsTrue(converter.CanConvert(typeof(GeographyPoint)));
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

            GeographyPoint point = JsonConvert.DeserializeObject<GeographyPoint>(@"{""type"":""Point"",""coordinates"":[-121.726906,46.879967]}", settings);

            Assert.AreEqual(point.Latitude, 46.879967);
            Assert.AreEqual(point.Longitude, -121.726906);
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
            new TestCaseData(@"[]", $"Deserialization failed. Expected token: '{nameof(JsonToken.StartObject)}'"),
            new TestCaseData(@"{}", $"Deserialization failed. Could not find required 'type' property."),
            new TestCaseData(@"{""type"":""point""}", $"Deserialization failed. Expected value(s): 'Point'. Actual: 'point'"),
            new TestCaseData(@"{""type"":""Polygon""}", $"Deserialization failed. Expected value(s): 'Point'. Actual: 'Polygon'"),
            new TestCaseData(@"{""Type"":""Point""}", $"Deserialization failed. Expected value(s): 'type, coordinates, crs'. Actual: 'Type'"),
            new TestCaseData(@"{""type"":""Point"",""Coordinates"":[-121.726906,46.879967]}", $"Deserialization failed. Expected value(s): 'type, coordinates, crs'. Actual: 'Coordinates'"),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":-121.726906}", $"Deserialization failed. Expected token: '{nameof(JsonToken.StartArray)}'"),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[]}", $"Deserialization failed. Expected token: '{nameof(JsonToken.Float)}'"),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[""foo""]}", $"Deserialization failed. Expected token: '{nameof(JsonToken.Float)}'"),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[-121.726906]}", $"Deserialization failed. Expected token: '{nameof(JsonToken.Float)}'"),
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

            GeographyPoint point = GeographyPoint.Create(46.879967, -121.726906);
            string json = JsonConvert.SerializeObject(point, settings);

            // Use regex comparison since double precision can be slight off.
            StringAssert.IsMatch(@"\{""type\"":""Point"",""coordinates"":\[-121\.72690\d+,46\.87996\d+\]\}", json);
        }
    }
}
