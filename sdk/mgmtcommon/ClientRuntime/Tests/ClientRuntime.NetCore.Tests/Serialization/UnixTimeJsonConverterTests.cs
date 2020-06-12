// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

using System;

using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests.Serialization
{
    public class UnixTimeJsonConverterTests
    {
        private static long ToUnixTime(DateTime dateTime)
        {
            // Copied from DateTimeOffset.ToUnixTimeSeconds for .NET < 4.6
            // https://github.com/dotnet/runtime/blob/v5.0.0-preview.5.20278.1/src/libraries/System.Private.CoreLib/src/System/DateTimeOffset.cs#L583-L603
            const long UnixEpochSeconds = 62135596800;
            long seconds = dateTime.Ticks / TimeSpan.TicksPerSecond;
            return seconds - UnixEpochSeconds;
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void CanSerializeLocal()
        {
            var date = new DateTime(2020, 2, 29, 8, 5, 4, 600, DateTimeKind.Local);
            var dates = new DateData
            {
                DateTime = date,
                DateTimeNullable = date,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
            // DateTime is seconds since midnight 1970-01-01 local time, rounded down
            var expectedJson = @"{
  ""dt"": 1582963504,
  ""dtn"": 1582963504
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void CanSerializeUnspecified()
        {
            var date = new DateTime(2020, 2, 29, 8, 5, 4, 600);
            var dates = new DateData
            {
                DateTime = date,
                DateTimeNullable = date,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
            // DateTime is seconds since midnight 1970-01-01 ignoring tz, rounded down
            var expectedJson = @"{
  ""dt"": 1582963504,
  ""dtn"": 1582963504
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanSerializeUtc()
        {
            var date = new DateTime(2020, 2, 29, 8, 5, 4, 600, DateTimeKind.Utc);
            var dates = new DateData
            {
                DateTime = date,
                DateTimeNullable = date,
            };
            var serializedJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
            // Seconds since midnight 1970-01-01 UTC, rounded down
            var expectedJson = @"{
  ""dt"": 1582963504,
  ""dtn"": 1582963504
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
  ""dt"": -62135596800,
  ""dtn"": null
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanDeserialize()
        {
            var json = @"{
  ""dt"": 0,
  ""dtn"": 0
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            Assert.Equal(UnixTimeJsonConverter.EpochDate, dates.DateTime);
            Assert.Equal(UnixTimeJsonConverter.EpochDate, dates.DateTimeNullable);
        }

        [Fact]
        public void CanDeserializeNull()
        {
            var json = @"{
  ""dtn"": null
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            var date = new DateTime();
            var dateOffset = new DateTimeOffset();
            Assert.Equal(date, dates.DateTime);
            Assert.Null(dates.DateTimeNullable);
        }

        [Fact]
        public void CanDeserializeString()
        {
            var json = @"{
  ""dt"": ""0"",
  ""dtn"": ""0""
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            Assert.Equal(UnixTimeJsonConverter.EpochDate, dates.DateTime);
            Assert.Equal(UnixTimeJsonConverter.EpochDate, dates.DateTimeNullable);
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void CanDeserializeEmptyString()
        {
            var json = @"{
  ""dt"": """",
  ""dtn"": """"
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            Assert.Equal(new DateTime(), dates.DateTime);
            Assert.Null(dates.DateTimeNullable);
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void DeserializeRoundsToSecond()
        {
            var json = @"{
  ""dt"": 86400.9,
  ""dtn"": 86400.9
}";
            var dates = JsonConvert.DeserializeObject<DateData>(json);
            var date = UnixTimeJsonConverter.EpochDate.AddDays(1).AddSeconds(1);
            var dateOffset = new DateTimeOffset(date);
            Assert.Equal(date, dates.DateTime);
            Assert.Equal(date, dates.DateTimeNullable);
        }

        [Fact]
        public void DeserializeThrowsForNonNumber()
        {
            var json = "{\"dt\":\"invalid\"}";
            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<DateData>(json));
        }

        private class DateData
        {
            [JsonConverter(typeof(UnixTimeJsonConverter))]
            [JsonProperty("dt")]
            public DateTime DateTime { get; set; }

            [JsonConverter(typeof(UnixTimeJsonConverter))]
            [JsonProperty("dtn")]
            public DateTime? DateTimeNullable { get; set; }
        }
    }
}
