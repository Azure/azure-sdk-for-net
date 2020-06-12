// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

using System;

using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests.Serialization
{
    public class Iso8601TimeSpanConverterTests
    {
        [Fact]
        public void CanSerialize()
        {
            var time = new TimeSpan(1, 1, 1, 1, 1);
            var times = new TimeData
            {
                TimeSpan = time,
                TimeSpanNullable = time,
            };
            var serializedJson = JsonConvert.SerializeObject(times, Formatting.Indented);
            var expectedJson = @"{
  ""ts"": ""P1DT1H1M1.001S"",
  ""tsn"": ""P1DT1H1M1.001S""
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanSerializeManyDays()
        {
            var time = TimeSpan.FromDays(396);
            var times = new TimeData
            {
                TimeSpan = time,
                TimeSpanNullable = time,
            };
            var serializedJson = JsonConvert.SerializeObject(times, Formatting.Indented);
            // Note: Does not use Year, Month, or Week periods
            var expectedJson = @"{
  ""ts"": ""P396D"",
  ""tsn"": ""P396D""
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        // Note: Currently handled internally by JSON.NET:
        // https://github.com/JamesNK/Newtonsoft.Json/issues/1639
        [Fact]
        public void CanSerializeNull()
        {
            var times = new TimeData();
            var serializeSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
            };
            var serializedJson = JsonConvert.SerializeObject(times, Formatting.Indented, serializeSettings);
            var expectedJson = @"{
  ""ts"": ""PT0S"",
  ""tsn"": null
}";
            Assert.Equal(expectedJson, serializedJson);
        }

        [Fact]
        public void CanDeserialize()
        {
            var json = @"{
  ""ts"": ""P1DT1H1M1.001S"",
  ""tsn"": ""P1DT1H1M1.001S""
}";
            var times = JsonConvert.DeserializeObject<TimeData>(json);
            var time = new TimeSpan(1, 1, 1, 1, 1);
            Assert.Equal(time, times.TimeSpan);
            Assert.Equal(time, times.TimeSpanNullable);
        }

        [Fact]
        public void CanDeserializeManyHours()
        {
            var json = @"{
  ""ts"": ""PT36H"",
  ""tsn"": ""PT36H""
}";
            var times = JsonConvert.DeserializeObject<TimeData>(json);
            var time = TimeSpan.FromHours(36);
            Assert.Equal(time, times.TimeSpan);
            Assert.Equal(time, times.TimeSpanNullable);
        }

        // Note: The test author makes no statement about whether this behavior
        // is correct/desirable.  This test demonstrates current behavior.
        [Fact]
        public void DeserializeThrowsForWeek()
        {
            var json = @"{
  ""ts"": ""P1W""
}";
            Assert.Throws<FormatException>(() => JsonConvert.DeserializeObject<TimeData>(json));
        }

        [Fact]
        public void CanDeserializeYearMonth()
        {
            var json = @"{
  ""ts"": ""P1Y1M"",
  ""tsn"": ""P1Y1M""
}";
            var times = JsonConvert.DeserializeObject<TimeData>(json);
            var now = DateTime.Now;
            var time = now.AddYears(1).AddMonths(1) - now;
            Assert.Equal(time, times.TimeSpan);
            Assert.Equal(time, times.TimeSpanNullable);
        }

        [Fact]
        public void CanDeserializeNull()
        {
            var json = @"{
  ""tsn"": null
}";
            var times = JsonConvert.DeserializeObject<TimeData>(json);
            var time = new TimeSpan();
            Assert.Equal(time, times.TimeSpan);
            Assert.Null(times.TimeSpanNullable);
        }

        [Fact]
        public void DeserializeThrowsForEmptyNonNullable()
        {
            var json = @"{
  ""ts"": """"
}";
            Assert.Throws<FormatException>(() => JsonConvert.DeserializeObject<TimeData>(json));
        }

        [Fact]
        public void DeserializeThrowsForEmptyNullable()
        {
            var json = @"{
  ""tsn"": """"
}";
            Assert.Throws<FormatException>(() => JsonConvert.DeserializeObject<TimeData>(json));
        }

        [Fact]
        public void DeserializeThrowsForInvalid()
        {
            var json = "{\"ts\":\"invalid\"}";
            Assert.Throws<FormatException>(() => JsonConvert.DeserializeObject<TimeData>(json));
        }

        private class TimeData
        {
            [JsonConverter(typeof(Iso8601TimeSpanConverter))]
            [JsonProperty("ts")]
            public TimeSpan TimeSpan { get; set; }

            [JsonConverter(typeof(Iso8601TimeSpanConverter))]
            [JsonProperty("tsn")]
            public TimeSpan? TimeSpanNullable { get; set; }
        }
    }
}
