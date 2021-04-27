// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Serialization;
using Microsoft.Spatial;
using NUnit.Framework;

namespace Microsoft.Azure.Core.Spatial.Tests.Serialization
{
    public class MicrosoftSpatialGeoJsonConverterTests
    {
        [Test]
        public void CanConvert()
        {
            MicrosoftSpatialGeoJsonConverter converter = new MicrosoftSpatialGeoJsonConverter();
            Assert.IsTrue(converter.CanConvert(typeof(GeographyPoint)));
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

            GeographyPoint point = JsonSerializer.Deserialize<GeographyPoint>(@"{""type"":""Point"",""coordinates"":[-121.726906,46.879967]}", options);

            Assert.AreEqual(46.879967, point.Latitude);
            Assert.AreEqual(-121.726906, point.Longitude);
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

            GeographyPoint point = JsonSerializer.Deserialize<GeographyPoint>(@"{""type"":""Point"",""coordinates"":[-121.726906,46.879967,2541.118],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}}", options);

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
            new TestCaseData(@"{}", $"Deserialization of {nameof(GeographyPoint)} failed. Expected geographic type: 'Point'."),
            new TestCaseData(@"{""type"":""point""}", $"Deserialization of {nameof(GeographyPoint)} failed. Expected geographic type: 'Point'."),
            new TestCaseData(@"{""type"":""Polygon""}", $"Deserialization of {nameof(GeographyPoint)} failed. Expected geographic type: 'Point'."),
            new TestCaseData(@"{""Type"":""Point""}", $"Deserialization of {nameof(GeographyPoint)} failed. Expected geographic type: 'Point'."),
            new TestCaseData(@"{""type"":""Point"",""Coordinates"":[-121.726906,46.879967,2541.118]}", $"Deserialization of {nameof(GeographyPoint)} failed. Expected both longitude and latitude."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":-121.726906}", $"Deserialization failed. Expected token: '{nameof(JsonTokenType.StartArray)}'."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[]}", $"Deserialization failed. Expected token: '{nameof(JsonTokenType.Number)}'."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[""foo""]}", $"Deserialization failed. Expected token: '{nameof(JsonTokenType.Number)}'."),
            new TestCaseData(@"{""type"":""Point"",""coordinates"":[-121.726906]}", $"Deserialization failed. Expected token: '{nameof(JsonTokenType.Number)}'."),
        };

        [Test]
        public void Write()
        {
            GeographyPoint point = GeographyPoint.Create(46.879967, -121.726906);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters =
                {
                    new MicrosoftSpatialGeoJsonConverter(),
                },
            };

            string json = JsonSerializer.Serialize(point, options);

            // Use regex comparison since double precision can be slight off.
            StringAssert.IsMatch(@"\{""type\"":""Point"",""coordinates"":\[-121\.72690\d+,46\.87996\d+\]\}", json);
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
