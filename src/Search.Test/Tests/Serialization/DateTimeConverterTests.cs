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

using System;
using System.Collections.Generic;
using Microsoft.Azure.Search.Serialization;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class DateTimeConverterTests
    {
        private readonly JsonSerializerSettings _jsonSettings =
            new JsonSerializerSettings() { Converters = new List<JsonConverter>() { new DateTimeConverter() } };

        [Fact]
        public void CanWriteLocalDateTime()
        {
            var localDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Local);
            var expectedDateTime = new DateTimeOffset(localDateTime);
            string expectedJson =
                String.Format(
                    @"""{0}-{1}""",
                    expectedDateTime.DateTime.ToString("s"),
                    expectedDateTime.Offset.ToString("hh\\:mm"));

            string json = JsonConvert.SerializeObject(localDateTime, _jsonSettings);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void CanWriteUtcDateTime()
        {
            var utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            string json = JsonConvert.SerializeObject(utcDateTime, _jsonSettings);

            Assert.Equal(@"""2000-01-01T00:00:00+00:00""", json);
        }

        [Fact]
        public void CanWriteUnspecifiedDateTime()
        {
            var utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

            string json = JsonConvert.SerializeObject(utcDateTime, _jsonSettings);

            Assert.Equal(@"""2000-01-01T00:00:00+00:00""", json);
        }

        [Fact]
        public void CanWriteNullableDateTime()
        {
            DateTime? utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            
            // Due to some JSON.NET weirdness, we need to wrap it in an object to trigger the DateTime? detection path.
            object obj = new { UtcDateTime = utcDateTime };

            string json = JsonConvert.SerializeObject(obj, _jsonSettings);

            Assert.Equal(@"{""UtcDateTime"":""2000-01-01T00:00:00+00:00""}", json);
        }

        [Fact]
        public void CanWriteNullDateTime()
        {
            DateTime? utcDateTime = null;

            // Due to some JSON.NET weirdness, we need to wrap it in an object to trigger the DateTime? detection path.
            object obj = new { UtcDateTime = utcDateTime };

            string json = JsonConvert.SerializeObject(obj, _jsonSettings);

            Assert.Equal(@"{""UtcDateTime"":null}", json);
        }
    }
}
