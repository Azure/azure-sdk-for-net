// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System.Collections.Generic;
using Microsoft.Azure.Search.Serialization;
using Microsoft.Spatial;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class GeographyPointConverterTests
    {
        private readonly JsonSerializerSettings _jsonSettings = 
            new JsonSerializerSettings() { Converters = new List<JsonConverter>() { new GeographyPointConverter() } };

        [Fact]
        public void CanWriteGeoPoint()
        {
            var point = GeographyPoint.Create(47.1, 121.9);
            string json = JsonConvert.SerializeObject(point, _jsonSettings);

            Assert.Equal(@"{""type"":""Point"",""coordinates"":[121.9,47.1]}", json);
        }

        [Fact]
        public void CanReadWellFormedGeoPoint()
        {
            var expectedPoint = GeographyPoint.Create(47.1, 121.9);
            const string Json = @"{""type"":""Point"",""coordinates"":[121.9,47.1]}";

            GeographyPoint actualPoint = JsonConvert.DeserializeObject<GeographyPoint>(Json, _jsonSettings);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void CanReadWellFormedGeoPointWithCRS()
        {
            var expectedPoint = GeographyPoint.Create(47.1, 121.9);
            const string Json = 
@"{""type"":""Point"",""coordinates"":[121.9,47.1],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}}";

            GeographyPoint actualPoint = JsonConvert.DeserializeObject<GeographyPoint>(Json, _jsonSettings);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Fact]
        public void ReadInvalidGeoPointContentThrowsException()
        {
            const string InvalidJson = @"{""type"":""NotAPoint"",""coordinates"":[121.9,47.1]}";

            Assert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<GeographyPoint>(InvalidJson, _jsonSettings));
        }

        [Fact]
        public void ReadInvalidGeoPointStructureThrowsException()
        {
            const string InvalidJson = @"{""type"":[""Point""]}";

            Assert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<GeographyPoint>(InvalidJson, _jsonSettings));
        }

        [Fact]
        public void ReadValidGeoPointWithExtraStuffThrowsException()
        {
            const string InvalidJson = @"{""type"":""Point"",""coordinates"":[121.9,47.1],""nope"":0}";

            Assert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<GeographyPoint>(InvalidJson, _jsonSettings));
        }

        [Fact]
        public void ReadNullReturnsNull()
        {
            GeographyPoint point = JsonConvert.DeserializeObject<GeographyPoint>("null", _jsonSettings);
            Assert.Null(point);
        }
    }
}
