// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search.Serialization;
using Microsoft.Azure.Search.Serialization.Internal;
using Microsoft.Spatial;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class GeoJsonPointConverterTests
    {
        private readonly JsonSerializerSettings _jsonSettings = 
            new JsonSerializerSettings() { Converters = new[] { CustomJsonConverters.CreateGeoJsonPointConverter() } };

        [Fact]
        public void CanWriteGeoPoint()
        {
            // NOTE: Spacing here must match exactly.
            const string ExpectedJson = @"{""type"":""Point"",""coordinates"":[121.9,47.1]}";

            var point = GeographyPoint.Create(47.1, 121.9);
            string actualJson = JsonConvert.SerializeObject(point, _jsonSettings);

            Assert.Equal(ExpectedJson, actualJson);
        }

        [Fact]
        public void CanReadWellFormedGeoPoint()
        {
            var expectedPoint = GeographyPoint.Create(47.1, 121.9);
            const string Json = @"{ ""type"": ""Point"", ""coordinates"": [ 121.9, 47.1 ] }";

            GeographyPoint actualPoint = DeserializeAndExpectSuccess(Json);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void CanReadWellFormedGeoPointWithIntegerCoordinates()
        {
            var expectedPoint = GeographyPoint.Create(47, 121);
            const string Json = @"{ ""type"": ""Point"", ""coordinates"": [ 121, 47 ] }";

            GeographyPoint actualPoint = DeserializeAndExpectSuccess(Json);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void CanReadWellFormedGeoPointWithCRS()
        {
            var expectedPoint = GeographyPoint.Create(47.1, 121.9);
            const string Json = 
@"{
    ""type"": ""Point"",
    ""coordinates"": [ 121.9, 47.1 ],
    ""crs"": {
        ""type"": ""name"",
        ""properties"": {
            ""name"": ""EPSG:4326""
        }
    }
}";

            GeographyPoint actualPoint = DeserializeAndExpectSuccess(Json);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void CanReadWellFormedGeoPointWithPropertiesOutOfOrder()
        {
            var expectedPoint = GeographyPoint.Create(47.1, 121.9);
            const string Json =
@"{
    ""coordinates"": [ 121.9, 47.1 ],
    ""crs"": {
        ""properties"": {
            ""name"": ""EPSG:4326""
        },
        ""type"": ""name""
    },
    ""type"": ""Point""
}";

            GeographyPoint actualPoint = DeserializeAndExpectSuccess(Json);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void ReadInvalidGeoPointContentThrowsException()
        {
            const string InvalidJson = @"{ ""type"": ""NotAPoint"", ""coordinates"": [ 121.9, 47.1 ] }";
            DeserializeAndExpectFailure(InvalidJson);
        }

        [Fact]
        public void ReadInvalidGeoPointStructureThrowsException()
        {
            const string InvalidJson = @"{ ""type"": [ ""Point"" ] }";
            DeserializeAndExpectFailure(InvalidJson);
        }

        [Theory]
        [InlineData(@"{ ""type"": ""Point"", ""coordinates"": [ 121.9, 47.1 ], ""nope"": 0 }")]
        [InlineData(@"{ ""type"": ""Point"", ""coordinates"": [ 121.9, 47.1 ], ""crs"": { ""type"": ""name"", ""properties"": { ""name"": ""EPSG:4326"" }, ""nope"": false } }")]
        [InlineData(@"{ ""type"": ""Point"", ""coordinates"": [ 121.9, 47.1 ], ""crs"": { ""type"": ""name"", ""properties"": { ""name"": ""EPSG:4326"", ""nope"": ""EPSG:4326"" } } }")]
        public void ReadValidGeoPointWithExtraStuffThrowsException(string invalidJson)
        {
            DeserializeAndExpectFailure(invalidJson);
        }

        [Fact]
        public void WhenPropertiesAreDuplicatedTheLastInstanceIsUsed()
        {
            const string Json = @"{ ""type"": ""Point"", ""coordinates"": [ 121.9, 47.1 ], ""coordinates"": [ 122.1, 49.1 ] }";

            var expectedPoint = GeographyPoint.Create(49.1, 122.1);
            GeographyPoint actualPoint = DeserializeAndExpectSuccess(Json);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void ReadEmptyObjectThrowsException()
        {
            DeserializeAndExpectFailure("{}");
        }

        [Fact]
        public void ReadNullReturnsNull()
        {
            const string Json = "null";

            // This is the one case where you can deserialize something to a GeographyPoint that isn't recognized as Geo-JSON.
            JObject dynamicPoint = JsonConvert.DeserializeObject<JObject>(Json);
            Assert.Null(dynamicPoint);
            Assert.False(dynamicPoint.IsGeoJsonPoint(), "Null should not be recognized as Geo-JSON");

            var point = JsonConvert.DeserializeObject<GeographyPoint>(Json, _jsonSettings);

            Assert.Null(point);
        }

        private GeographyPoint DeserializeAndExpectSuccess(string json)
        {
            JObject dynamicPoint = JsonConvert.DeserializeObject<JObject>(json);
            Assert.True(
                dynamicPoint.IsGeoJsonPoint(), 
                $"Expected given JSON to be recognized as Geo-JSON: <{json}>");

            return JsonConvert.DeserializeObject<GeographyPoint>(json, _jsonSettings);
        }

        private void DeserializeAndExpectFailure(string json)
        {
            JObject dynamicPoint = JsonConvert.DeserializeObject<JObject>(json);
            Assert.False(
                dynamicPoint.IsGeoJsonPoint(),
                $"Expected given JSON to NOT be recognized as Geo-JSON: <{json}>");

            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<GeographyPoint>(json, _jsonSettings));
        }
    }
}
