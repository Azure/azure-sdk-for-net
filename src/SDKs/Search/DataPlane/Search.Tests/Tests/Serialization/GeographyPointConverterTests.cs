// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Collections.Generic;
    using Microsoft.Azure.Search.Serialization;
    using Microsoft.Spatial;
    using Newtonsoft.Json;
    using Xunit;

    public sealed class GeographyPointConverterTests
    {
        private readonly JsonSerializerSettings _jsonSettings = 
            new JsonSerializerSettings() { Converters = new List<JsonConverter>() { new GeographyPointConverter() } };

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

            GeographyPoint actualPoint = JsonConvert.DeserializeObject<GeographyPoint>(Json, _jsonSettings);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void CanReadWellFormedGeoPointWithIntegerCoordinates()
        {
            var expectedPoint = GeographyPoint.Create(47, 121);
            const string Json = @"{ ""type"": ""Point"", ""coordinates"": [ 121, 47 ] }";

            GeographyPoint actualPoint = JsonConvert.DeserializeObject<GeographyPoint>(Json, _jsonSettings);

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

            GeographyPoint actualPoint = JsonConvert.DeserializeObject<GeographyPoint>(Json, _jsonSettings);

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

            GeographyPoint actualPoint = JsonConvert.DeserializeObject<GeographyPoint>(Json, _jsonSettings);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void ReadInvalidGeoPointContentThrowsException()
        {
            const string InvalidJson = @"{ ""type"": ""NotAPoint"", ""coordinates"": [ 121.9, 47.1 ] }";

            Assert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<GeographyPoint>(InvalidJson, _jsonSettings));
        }

        [Fact]
        public void ReadInvalidGeoPointStructureThrowsException()
        {
            const string InvalidJson = @"{ ""type"": [ ""Point"" ] }";

            Assert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<GeographyPoint>(InvalidJson, _jsonSettings));
        }

        [Theory]
        [InlineData(@"{ ""type"": ""Point"", ""coordinates"": [ 121.9, 47.1 ], ""nope"": 0 }")]
        [InlineData(@"{ ""type"": ""Point"", ""coordinates"": [ 121.9, 47.1 ], ""crs"": { ""type"": ""name"", ""properties"": { ""name"": ""EPSG:4326"" }, ""nope"": false } }")]
        public void ReadValidGeoPointWithExtraStuffThrowsException(string invalidJson)
        {
            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<GeographyPoint>(invalidJson, _jsonSettings));
        }

        [Fact]
        public void WhenPropertiesAreDuplicatedTheLastInstanceIsUsed()
        {
            const string Json = @"{ ""type"": ""Point"", ""coordinates"": [ 121.9, 47.1 ], ""coordinates"": [ 122.1, 49.1 ] }";

            var expectedPoint = GeographyPoint.Create(49.1, 122.1);
            var actualPoint = JsonConvert.DeserializeObject<GeographyPoint>(Json, _jsonSettings);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void ReadEmptyObjectThrowsException()
        {
            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<GeographyPoint>("{}", _jsonSettings));
        }

        [Fact]
        public void ReadNullReturnsNull()
        {
            GeographyPoint point = JsonConvert.DeserializeObject<GeographyPoint>("null", _jsonSettings);
            Assert.Null(point);
        }
    }
}
