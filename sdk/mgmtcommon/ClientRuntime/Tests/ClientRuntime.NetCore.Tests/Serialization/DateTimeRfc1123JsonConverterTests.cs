// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

using System;

using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests.Serialization
{
    public class DateTimeRfc1123JsonConverterTests
    {
        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void CanSerializeLocal()
        {
            var date = new DateTime(2020, 2, 29, 8, 5, 4, 500, DateTimeKind.Local);
            var dateOffset = new DateTimeOffset(date);
            var dates = new DateData
            {
                DateTime = date,
                DateTimeNullable = date,
                DateTimeOffset = dateOffset,
                DateTimeOffsetNullable = dateOffset,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
            // Note: Time of DateTimeOffset is converted to UTC, DateTime is not.
            var dateStrGmt = date.ToUniversalTime().ToString("R");
            var expectedJson = @"{
  ""dt"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dtn"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dto"": """ + dateStrGmt + @""",
  ""dton"": """ + dateStrGmt + @"""
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanSerializeUnspecified()
        {
            var date = new DateTime(2020, 2, 29, 8, 5, 4, 500);
            var dateOffset = new DateTimeOffset(date);
            var dates = new DateData
            {
                DateTime = date,
                DateTimeNullable = date,
                DateTimeOffset = dateOffset,
                DateTimeOffsetNullable = dateOffset,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
            // Note: Time of DateTimeOffset is converted to UTC, DateTime is not.
            var dateStrGmt = date.ToUniversalTime().ToString("R");
            var expectedJson = @"{
  ""dt"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dtn"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dto"": """ + dateStrGmt + @""",
  ""dton"": """ + dateStrGmt + @"""
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanSerializeUtc()
        {
            var date = new DateTime(2020, 2, 29, 8, 5, 4, 500, DateTimeKind.Utc);
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
  ""dt"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dtn"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dto"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dton"": ""Sat, 29 Feb 2020 08:05:04 GMT""
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
  ""dt"": ""Mon, 01 Jan 0001 00:00:00 GMT"",
  ""dtn"": null,
  ""dto"": ""Mon, 01 Jan 0001 00:00:00 GMT"",
  ""dton"": null
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanDeserialize()
        {
            var json = @"{
  ""dt"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dtn"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dto"": ""Sat, 29 Feb 2020 08:05:04 GMT"",
  ""dton"": ""Sat, 29 Feb 2020 08:05:04 GMT""
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            var date = new DateTime(2020, 2, 29, 8, 5, 4, DateTimeKind.Utc);
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
        public void DeserializeThrowsIfNoDow()
        {
            var json = @"{
  ""dt"": ""29 Feb 2020 08:05:04 GMT"",
  ""dtn"": ""29 Feb 2020 08:05:04 GMT"",
  ""dto"": ""29 Feb 2020 08:05:04 GMT"",
  ""dton"": ""29 Feb 2020 08:05:04 GMT""
}";
            Assert.Throws<JsonException>(() => JsonConvert.DeserializeObject<DateData>(json));
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void DeserializeThrowsIfNoSeconds()
        {
            var json = @"{
  ""dt"": ""Sat, 29 Feb 2020 08:05 GMT"",
  ""dtn"": ""Sat, 29 Feb 2020 08:05 GMT"",
  ""dto"": ""Sat, 29 Feb 2020 08:05 GMT"",
  ""dton"": ""Sat, 29 Feb 2020 08:05 GMT""
}";
            Assert.Throws<JsonException>(() => JsonConvert.DeserializeObject<DateData>(json));
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void DeserializeThrowsIfUt()
        {
            var json = @"{
  ""dt"": ""Sat, 29 Feb 2020 08:05:04 UT"",
  ""dtn"": ""Sat, 29 Feb 2020 08:05:04 UT"",
  ""dto"": ""Sat, 29 Feb 2020 08:05:04 UT"",
  ""dton"": ""Sat, 29 Feb 2020 08:05:04 UT""
}";
            Assert.Throws<JsonException>(() => JsonConvert.DeserializeObject<DateData>(json));
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void DeserializeThrowsIfPst()
        {
            var json = @"{
  ""dt"": ""Sat, 29 Feb 2020 08:05:04 PST"",
  ""dtn"": ""Sat, 29 Feb 2020 08:05:04 PST"",
  ""dto"": ""Sat, 29 Feb 2020 08:05:04 PST"",
  ""dton"": ""Sat, 29 Feb 2020 08:05:04 PST""
}";
            Assert.Throws<JsonException>(() => JsonConvert.DeserializeObject<DateData>(json));
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void DeserializeThrowsIfTzOffset()
        {
            var json = @"{
  ""dt"": ""Sat, 29 Feb 2020 08:05:04 +0700"",
  ""dtn"": ""Sat, 29 Feb 2020 08:05:04 +0700"",
  ""dto"": ""Sat, 29 Feb 2020 08:05:04 +0700"",
  ""dton"": ""Sat, 29 Feb 2020 08:05:04 +0700""
}";
            Assert.Throws<JsonException>(() => JsonConvert.DeserializeObject<DateData>(json));
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
            [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
            [JsonProperty("dt")]
            public DateTime DateTime { get; set; }

            [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
            [JsonProperty("dtn")]
            public DateTime? DateTimeNullable { get; set; }

            [JsonProperty("dto")]
            [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
            public DateTimeOffset DateTimeOffset { get; set; }

            [JsonProperty("dton")]
            [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
            public DateTimeOffset? DateTimeOffsetNullable { get; set; }
        }
    }
}
