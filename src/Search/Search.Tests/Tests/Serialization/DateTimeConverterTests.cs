// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Azure.Search.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public sealed class DateTimeConverterTests
    {
        private readonly JsonSerializerSettings _serializerSettings =
            new JsonSerializerSettings() { Converters = new List<JsonConverter>() { new DateTimeConverter() } };

        private readonly JsonSerializerSettings _deserializerSettings =
            new JsonSerializerSettings() 
            { 
                DateParseHandling = DateParseHandling.DateTimeOffset,
                Converters = new List<JsonConverter>() { new DateTimeConverter() }
            };

        [Fact]
        public void CanWriteLocalDateTime()
        {
            var localDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Local);
            var expectedDateTime = new DateTimeOffset(localDateTime);
            string expectedJson =
                String.Format(
                    @"""{0}{1}{2}""",
                    expectedDateTime.DateTime.ToString("s"),
                    expectedDateTime.Offset < TimeSpan.Zero ? "-" : "+",
                    expectedDateTime.Offset.ToString("hh\\:mm"));

            string json = JsonConvert.SerializeObject(localDateTime, _serializerSettings);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void CanWriteUtcDateTime()
        {
            var utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            string json = JsonConvert.SerializeObject(utcDateTime, _serializerSettings);

            Assert.Equal(@"""2000-01-01T00:00:00+00:00""", json);
        }

        [Fact]
        public void CanWriteUnspecifiedDateTime()
        {
            var utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

            string json = JsonConvert.SerializeObject(utcDateTime, _serializerSettings);

            Assert.Equal(@"""2000-01-01T00:00:00+00:00""", json);
        }

        [Fact]
        public void CanWriteNullableDateTime()
        {
            DateTime? utcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            
            // Due to some JSON.NET weirdness, we need to wrap it in an object to trigger the DateTime? detection path.
            object obj = new { UtcDateTime = utcDateTime };

            string json = JsonConvert.SerializeObject(obj, _serializerSettings);

            Assert.Equal(@"{""UtcDateTime"":""2000-01-01T00:00:00+00:00""}", json);
        }

        [Fact]
        public void CanWriteNullDateTime()
        {
            DateTime? utcDateTime = null;

            // Due to some JSON.NET weirdness, we need to wrap it in an object to trigger the DateTime? detection path.
            object obj = new { UtcDateTime = utcDateTime };

            string json = JsonConvert.SerializeObject(obj, _serializerSettings);

            Assert.Equal(@"{""UtcDateTime"":null}", json);
        }

        [Fact]
        public void CanReadUtcDateTime()
        {
            var expectedUtcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            DateTime actualDateTime = 
                JsonConvert.DeserializeObject<DateTime>(@"""2000-01-01T00:00:00Z""", _deserializerSettings);

            Assert.Equal(expectedUtcDateTime, actualDateTime);
        }

        [Fact]
        public void CanReadUtcDateTimeOffset()
        {
            var expectedUtcDateTimeOffset = new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            DateTimeOffset actualDateTimeOffset =
                JsonConvert.DeserializeObject<DateTimeOffset>(@"""2000-01-01T00:00:00Z""", _deserializerSettings);

            Assert.Equal(expectedUtcDateTimeOffset, actualDateTimeOffset);
        }

        [Fact]
        public void ReadingDateTimeWithOffsetConvertsToUtc()
        {
            DateTime expectedUtcTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            DateTime actualDateTime =
                JsonConvert.DeserializeObject<DateTime>(@"""1999-12-31T16:00:00-08:00""", _deserializerSettings);

            Assert.Equal(expectedUtcTime, actualDateTime);
        }

        [Fact]
        public void CanReadDateTimeWithOffsetToDateTimeOffset()
        {
            var expectedUtcDateTimeOffset = 
                new DateTimeOffset(new DateTime(1999, 12, 31, 16, 0, 0), TimeSpan.FromHours(-8));

            DateTimeOffset actualDateTimeOffset =
                JsonConvert.DeserializeObject<DateTimeOffset>(@"""1999-12-31T16:00:00-08:00""", _deserializerSettings);

            Assert.Equal(expectedUtcDateTimeOffset, actualDateTimeOffset);
        }

        [Fact]
        public void CanReadNullableDateTime()
        {
            DateTime? expectedUtcDateTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            DateTime? actualDateTime =
                JsonConvert.DeserializeObject<DateTime?>(@"""2000-01-01T00:00:00Z""", _deserializerSettings);

            Assert.Equal(expectedUtcDateTime, actualDateTime);
        }

        [Fact]
        public void CanReadNullableDateTimeOffset()
        {
            DateTimeOffset? expectedUtcDateTimeOffset = 
                new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            DateTimeOffset? actualDateTimeOffset =
                JsonConvert.DeserializeObject<DateTimeOffset?>(@"""2000-01-01T00:00:00Z""", _deserializerSettings);

            Assert.Equal(expectedUtcDateTimeOffset, actualDateTimeOffset);
        }

        [Fact]
        public void CanReadNullDateTime()
        {
            DateTime? nullUtcDateTime = null;
            DateTime? actualDateTime = JsonConvert.DeserializeObject<DateTime?>("null", _deserializerSettings);
            Assert.Equal(nullUtcDateTime, actualDateTime);
        }

        [Fact]
        public void CanReadNullDateTimeOffset()
        {
            DateTimeOffset? nullUtcDateTimeOffset = null;
            DateTimeOffset? actualDateTimeOffset = 
                JsonConvert.DeserializeObject<DateTimeOffset?>("null", _deserializerSettings);
            Assert.Equal(nullUtcDateTimeOffset, actualDateTimeOffset);
        }

        [Fact]
        public void CanReadPreParsedDateTime()
        {
            const string Json = @"{""CreatedAt"":""2000-01-01T00:00:00Z""}";
            using (JsonReader reader = new JsonTextReader(new StringReader(Json)))
            {
                JsonSerializer serializer = JsonSerializer.Create(_deserializerSettings);
                JObject propertyBag = serializer.Deserialize<JObject>(reader);
                Model model = serializer.Deserialize<Model>(new JTokenReader(propertyBag));
                Assert.Equal(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), model.CreatedAt);
            }
        }

        private class Model
        {
            public DateTime CreatedAt { get; set; }
        }
    }
}
