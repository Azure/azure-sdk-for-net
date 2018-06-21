// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Serialization;
    using Models;
    using Newtonsoft.Json;
    using Xunit;
    using System;
    using Spatial;

    public sealed class DocumentConverterTests
    {
        private const string TestDateString = "2016-10-10T17:41:05.123-07:00";

        private static readonly DateTimeOffset TestDate = new DateTimeOffset(2016, 10, 10, 17, 41, 5, 123, TimeSpan.FromHours(-7));

        // Use the same deserialization settings as JsonUtility so we're getting the right behavior for deserializing field values.
        private readonly JsonSerializerSettings _settings =
            new JsonSerializerSettings()
            {
                Converters =
                    new JsonConverter[]
                    {
                        new DocumentConverter(),
                        new GeographyPointConverter(),
                        new DateTimeConverter(),
                        // DoubleConverter shouldn't make a difference since it only kicks in when deserializing NaN/INF/-INF, and that case
                        // is currently not covered by DocumentConverter. However, including it for completeness anyway.
                        new DoubleConverter()
                    },
                DateParseHandling = DateParseHandling.DateTimeOffset,
                NullValueHandling = NullValueHandling.Include
            };

        [Fact]
        public void AnnotationsAreExcludedFromDocument()
        {
            const string Json =
@"{
    ""@search.score"": 3.14,
    ""field1"": ""value1"",
    ""field2"": 123,
    ""@search.someOtherAnnotation"": { ""a"": ""b"" },
    ""field3"": 2.78
}";

            Document doc = JsonConvert.DeserializeObject<Document>(Json, _settings);

            Assert.Equal(3, doc.Count);
            Assert.Equal("value1", doc["field1"]);
            Assert.Equal(123L, doc["field2"]);
            Assert.Equal(2.78, doc["field3"]);
        }

        [Fact]
        public void CanReadNullValues()
        {
            const string Json =
@"{
    ""field1"": null,
    ""field2"": [ ""hello"", null ]
}";

            Document doc = JsonConvert.DeserializeObject<Document>(Json, _settings);

            Assert.Equal(2, doc.Count);
            Assert.Null(doc["field1"]);

            string[] field2Values = Assert.IsType<string[]>(doc["field2"]);

            Assert.Equal(2, field2Values.Length);
            Assert.Equal("hello", field2Values[0]);
            Assert.Null(field2Values[1]);
        }

        [Fact]
        public void CanReadEmptyArrays()
        {
            Document doc = JsonConvert.DeserializeObject<Document>(@"{ ""field"": [] }", _settings);

            Assert.Equal(1, doc.Count);
            string[] fieldValues = Assert.IsType<string[]>(doc["field"]);
            Assert.Equal(0, fieldValues.Length);
        }

        [Fact]
        public void CanReadArraysOfStrings()
        {
            Document doc = JsonConvert.DeserializeObject<Document>(@"{ ""field"": [""hello"", ""goodbye""] }", _settings);

            Assert.Equal(1, doc.Count);
            string[] fieldValues = Assert.IsType<string[]>(doc["field"]);
            Assert.Equal(2, fieldValues.Length);
            Assert.Equal("hello", fieldValues[0]);
            Assert.Equal("goodbye", fieldValues[1]);
        }

        [Fact]
        public void CanReadGeoPoint()
        {
            const string Json = @"{ ""field"": { ""type"": ""Point"", ""coordinates"": [-122.131577, 47.678581] } }";
            Document doc = JsonConvert.DeserializeObject<Document>(Json, _settings);

            Assert.Equal(1, doc.Count);
            GeographyPoint fieldValue = Assert.IsAssignableFrom<GeographyPoint>(doc["field"]);
            Assert.Equal(-122.131577, fieldValue.Longitude);
            Assert.Equal(47.678581, fieldValue.Latitude);
        }

        // This is a pinning test. It is not ideal behavior, but it's the best we can do without type information.
        [Fact]
        public void SpecialDoublesAreReadAsStrings()
        {
            const string Json =
@"{
    ""field1"": ""NaN"",
    ""field2"": ""INF"",
    ""field3"": ""-INF""
}";

            Document doc = JsonConvert.DeserializeObject<Document>(Json, _settings);

            Assert.Equal(3, doc.Count);
            Assert.Equal("NaN", doc["field1"]);
            Assert.Equal("INF", doc["field2"]);
            Assert.Equal("-INF", doc["field3"]);
        }

        // This is a pinning test. It is not ideal behavior, but it's the best we can do without type information.
        [Fact]
        public void DateTimeStringsAreReadAsDateTime()
        {
            string json = $@"{{ ""field"": ""{TestDateString}"" }}";

            Document doc = JsonConvert.DeserializeObject<Document>(json, _settings);

            Assert.Equal(1, doc.Count);
            Assert.Equal(TestDate, doc["field"]);
        }

        // This is a pinning test. It is not ideal behavior, but it's the best we can do without type information.
        [Fact]
        public void CanReadArraysOfMixedTypes()
        {
            // Azure Search won't return payloads like this; This test is only for pinning purposes.
            Document doc = JsonConvert.DeserializeObject<Document>(@"{ ""field"": [""hello"", 123, 3.14] }", _settings);

            Assert.Equal(1, doc.Count);
            object[] fieldValues = Assert.IsType<object[]>(doc["field"]);
            Assert.Equal(3, fieldValues.Length);
            Assert.Equal("hello", fieldValues[0]);
            Assert.Equal(123L, fieldValues[1]);
            Assert.Equal(3.14, fieldValues[2]);
        }

        // This is a pinning test. It is not ideal behavior, but it's the best we can do without type information.
        [Fact]
        public void DateTimeStringsInArraysAreReadAsDateTime()
        {
            string json = $@"{{ ""field"": [ ""hello"", ""{TestDateString}"", ""123"" ] }}";

            Document doc = JsonConvert.DeserializeObject<Document>(json, _settings);

            Assert.Equal(1, doc.Count);
            object[] fieldValues = Assert.IsType<object[]>(doc["field"]);
            Assert.Equal(3, fieldValues.Length);
            Assert.Equal("hello", fieldValues[0]);
            Assert.Equal(TestDate, fieldValues[1]);
            Assert.Equal("123", fieldValues[2]);
        }
    }
}
