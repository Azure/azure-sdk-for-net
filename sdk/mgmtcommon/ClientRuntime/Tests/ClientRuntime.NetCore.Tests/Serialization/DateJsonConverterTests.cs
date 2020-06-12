// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

using System;

using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests.Serialization
{
    public class DateJsonConverterTests
    {
        [Fact]
        public void CanSerializeLocal()
        {
            var date = new DateTime(2020, 2, 29, 0, 0, 0, DateTimeKind.Local);
            var dateOffset = new DateTimeOffset(date);
            var dates = new DateData
            {
                DateTime = date,
                DateTimeNullable = date,
                DateTimeOffset = dateOffset,
                DateTimeOffsetNullable = dateOffset,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
            var expectedJson = @"{
  ""dt"": ""2020-02-29"",
  ""dtn"": ""2020-02-29"",
  ""dto"": ""2020-02-29"",
  ""dton"": ""2020-02-29""
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanSerializeUnspecified()
        {
            var date = new DateTime(2020, 2, 29);
            var dateOffset = new DateTimeOffset(date);
            var dates = new DateData
            {
                DateTime = date,
                DateTimeNullable = date,
                DateTimeOffset = dateOffset,
                DateTimeOffsetNullable = dateOffset,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
            var expectedJson = @"{
  ""dt"": ""2020-02-29"",
  ""dtn"": ""2020-02-29"",
  ""dto"": ""2020-02-29"",
  ""dton"": ""2020-02-29""
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanSerializeUtc()
        {
            var date = new DateTime(2020, 2, 29, 0, 0, 0, DateTimeKind.Utc);
            var dateOffset = new DateTimeOffset(date);
            var dates = new DateData
            {
                DateTime = date,
                DateTimeNullable = date,
                DateTimeOffset = dateOffset,
                DateTimeOffsetNullable = dateOffset,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
            var expectedJson = @"{
  ""dt"": ""2020-02-29"",
  ""dtn"": ""2020-02-29"",
  ""dto"": ""2020-02-29"",
  ""dton"": ""2020-02-29""
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        // Note: Currently handled internally by JSON.NET:
        // https://github.com/JamesNK/Newtonsoft.Json/issues/1639
        [Fact]
        public void CanSerializeNull()
        {
            var dates = new DateData();
            var serializeSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented, serializeSettings);
            var expectedJson = @"{
  ""dt"": ""0001-01-01"",
  ""dtn"": null,
  ""dto"": ""0001-01-01"",
  ""dton"": null
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void SerializeRemovesTime()
        {
            var date = new DateTime(2020, 2, 29, 12, 30, 30, 500);
            var dateOffset = new DateTimeOffset(date);
            var dates = new DateData
            {
                DateTime = date,
                DateTimeNullable = date,
                DateTimeOffset = dateOffset,
                DateTimeOffsetNullable = dateOffset,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
            var expectedJson = @"{
  ""dt"": ""2020-02-29"",
  ""dtn"": ""2020-02-29"",
  ""dto"": ""2020-02-29"",
  ""dton"": ""2020-02-29""
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanDeserialize()
        {
            var json = @"{
  ""dt"": ""2020-02-29"",
  ""dtn"": ""2020-02-29"",
  ""dto"": ""2020-02-29"",
  ""dton"": ""2020-02-29""
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            var date = new DateTime(2020, 2, 29);
            var dateOffset = new DateTimeOffset(date);
            Assert.Equal(date, dates.DateTime);
            Assert.Equal(date, dates.DateTimeNullable);
            Assert.Equal(dateOffset, dates.DateTimeOffset);
            Assert.Equal(dateOffset, dates.DateTimeOffsetNullable);
        }

        [Fact]
        public void CanDeserializeNull()
        {
            var json = @"{
  ""dtn"": null,
  ""dton"": null
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            var date = new DateTime();
            var dateOffset = new DateTimeOffset();
            Assert.Equal(date, dates.DateTime);
            Assert.Null(dates.DateTimeNullable);
            Assert.Equal(dateOffset, dates.DateTimeOffset);
            Assert.Null(dates.DateTimeOffsetNullable);
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void DeserializePreservesTime()
        {
            var json = @"{
  ""dt"": ""2020-02-29T12:30:30.5"",
  ""dtn"": ""2020-02-29T12:30:30.5"",
  ""dto"": ""2020-02-29T12:30:30.5"",
  ""dton"": ""2020-02-29T12:30:30.5""
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            var date = new DateTime(2020, 2, 29, 12, 30, 30, 500);
            var dateOffset = new DateTimeOffset(date);
            Assert.Equal(date, dates.DateTime);
            Assert.Equal(date, dates.DateTimeNullable);
            Assert.Equal(dateOffset, dates.DateTimeOffset);
            Assert.Equal(dateOffset, dates.DateTimeOffsetNullable);
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void DeserializePreservesTimeUtc()
        {
            var json = @"{
  ""dt"": ""2020-02-29T12:30:30.5Z"",
  ""dtn"": ""2020-02-29T12:30:30.5Z"",
  ""dto"": ""2020-02-29T12:30:30.5Z"",
  ""dton"": ""2020-02-29T12:30:30.5Z""
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            var date = new DateTime(2020, 2, 29, 12, 30, 30, 500, DateTimeKind.Utc);
            var dateOffset = new DateTimeOffset(date);
            Assert.Equal(date, dates.DateTime);
            Assert.Equal(date, dates.DateTimeNullable);
            Assert.Equal(dateOffset, dates.DateTimeOffset);
            Assert.Equal(dateOffset, dates.DateTimeOffsetNullable);
        }

        [Fact]
        public void DeserializeThrowsForEmptyNonNullable()
        {
            var json = "{\"dt\":\"\"}";
            Assert.Throws<JsonException>(() => JsonConvert.DeserializeObject<DateData>(json));
        }

        [Fact]
        public void CanDeserializeEmptyAsNull()
        {
            var json = @"{
  ""dtn"": """",
  ""dton"": """"
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            var date = new DateTime();
            var dateOffset = new DateTimeOffset();
            Assert.Equal(date, dates.DateTime);
            Assert.Null(dates.DateTimeNullable);
            Assert.Equal(dateOffset, dates.DateTimeOffset);
            Assert.Null(dates.DateTimeOffsetNullable);
        }

        [Fact]
        public void DeserializeThrowsForInvalidDate()
        {
            var json = "{\"dt\":\"invalid\"}";
            Assert.Throws<JsonException>(() => JsonConvert.DeserializeObject<DateData>(json));
        }

        private class DateData
        {
            [JsonConverter(typeof(DateJsonConverter))]
            [JsonProperty("dt")]
            public DateTime DateTime { get; set; }

            [JsonConverter(typeof(DateJsonConverter))]
            [JsonProperty("dtn")]
            public DateTime? DateTimeNullable { get; set; }

            [JsonProperty("dto")]
            [JsonConverter(typeof(DateJsonConverter))]
            public DateTimeOffset DateTimeOffset { get; set; }

            [JsonProperty("dton")]
            [JsonConverter(typeof(DateJsonConverter))]
            public DateTimeOffset? DateTimeOffsetNullable { get; set; }
        }
    }
}
