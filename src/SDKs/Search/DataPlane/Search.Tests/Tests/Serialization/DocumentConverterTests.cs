// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Serialization;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Spatial;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class DocumentConverterTests
    {
        private const string TestDateString = "2016-10-10T17:41:05.123-07:00";

        private static readonly DateTimeOffset TestDate = new DateTimeOffset(2016, 10, 10, 17, 41, 5, 123, TimeSpan.FromHours(-7));

        // Use the same deserialization settings as JsonUtility so we're getting the right behavior for deserializing field values.
        private static readonly JsonSerializerSettings Settings =
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

        private static Document Deserialize(string json) => JsonConvert.DeserializeObject<Document>(json, Settings);

        private static void AssertDocumentsEqual(Document expectedDoc, Document actualDoc) =>
            Assert.Equal(expectedDoc, actualDoc, new ModelComparer<Document>());

        // Functional tests that ensure expected behavior of DocumentConverter.
        public sealed class Functional
        {
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

                var expectedDoc =
                    new Document()
                    {
                        ["field1"] = "value1",
                        ["field2"] = 123L,
                        ["field3"] = 2.78
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void CanReadNullValues()
            {
                const string Json =
@"{
    ""field1"": null,
    ""field2"": [ ""hello"", null ],
    ""field3"": [ null, 123, null ],
}";

                var expectedDoc =
                    new Document()
                    {
                        ["field1"] = null,
                        ["field2"] = new string[] { "hello", null },
                        ["field3"] = new object[] { null, 123L, null }
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Theory]
            [InlineData("123", 123L)]
            [InlineData("9999999999999", 9_999_999_999_999L)]
            [InlineData("3.14", 3.14)]
            [InlineData(@"""hello""", "hello")]
            [InlineData("true", true)]
            [InlineData("false", false)]
            public void CanReadPrimitiveTypes(string jsonValue, object expectedObject)
            {
                string json = $@"{{ ""field"": {jsonValue} }}";
                var expectedDoc = new Document() { ["field"] = expectedObject };

                Document actualDoc = Deserialize(json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Theory]
            [InlineData(@"[""hello"", ""goodbye""]", new string[] { "hello", "goodbye" })]
            [InlineData(@"[123, 456]", new long[] { 123L, 456L })]
            [InlineData(@"[9999999999999, -12]", new long[] { 9_999_999_999_999L, -12L })]
            [InlineData(@"[3.14, 2.78]", new double[] { 3.14, 2.78 })]
            [InlineData(@"[true, false]", new bool[] { true, false })]
            public void CanReadArraysOfPrimitiveTypes(string jsonArray, Array expectedArray)
            {
                string json = $@"{{ ""field"": {jsonArray} }}";

                var expectedDoc =
                    new Document()
                    {
                        ["field"] = expectedArray
                    };

                Document actualDoc = Deserialize(json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void CanReadGeoPoint()
            {
                const string Json = @"{ ""field"": { ""type"": ""Point"", ""coordinates"": [-122.131577, 47.678581] } }";

                var expectedDoc =
                    new Document()
                    {
                        ["field"] = GeographyPoint.Create(latitude: 47.678581, longitude: -122.131577)
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void CanReadGeoPointCollections()
            {
                const string Json =
@"{
    ""field"": [
        { ""type"": ""Point"", ""coordinates"": [-122.131577, 47.678581] },
        { ""type"": ""Point"", ""coordinates"": [-121, 49] }
    ]
}";

                var expectedDoc =
                    new Document()
                    {
                        ["field"] = new[]
                        {
                            GeographyPoint.Create(latitude: 47.678581, longitude: -122.131577),
                            GeographyPoint.Create(latitude: 49, longitude: -121)
                        }
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            // This is not quite a pinning test in the sense that it actually is correct behavior if the field is defined
            // as Edm.DateTimeOffset. What's notable is that this is how such values deserialize, even when the field is not that type.
            [Fact]
            public void DateTimeStringsAreReadAsDateTime()
            {
                string json =
$@"{{
    ""field1"": ""{TestDateString}"",
    ""field2"": [""{TestDateString}"", ""{TestDateString}""]
}}";

                var expectedDoc =
                    new Document()
                    {
                        ["field1"] = TestDate,
                        ["field2"] = new DateTimeOffset[] { TestDate, TestDate }
                    };

                Document actualDoc = Deserialize(json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }
        }

        // These are all pinning tests. These tests don't exemplify ideal behavior, but it's the best we can do without type information.
        public sealed class Pinning
        {
            [Fact]
            public void SpecialDoublesAreReadAsStrings()
            {
                const string Json =
@"{
    ""field1"": ""NaN"",
    ""field2"": ""INF"",
    ""field3"": ""-INF"",
    ""field4"": [""NaN"", ""INF"", ""-INF""]
}";

                var expectedDoc =
                    new Document()
                    {
                        ["field1"] = "NaN",
                        ["field2"] = "INF",
                        ["field3"] = "-INF",
                        ["field4"] = new string[] { "NaN", "INF", "-INF" }
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void CanReadArraysOfMixedTypes()
            {
                // Azure Search won't return payloads like this; This test is only for pinning purposes.
                const string Json = @"{ ""field"": [""hello"", 123, 3.14, { ""type"": ""Point"", ""coordinates"": [-122.131577, 47.678581] }] }";

                var expectedDoc =
                    new Document()
                    {
                        ["field"] = new object[] { "hello", 123L, 3.14, GeographyPoint.Create(47.678581, -122.131577) }
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void DateTimeStringsInArraysAreReadAsDateTime()
            {
                string json = $@"{{ ""field"": [ ""hello"", ""{TestDateString}"", ""123"" ] }}";

                var expectedDoc =
                    new Document()
                    {
                        ["field"] = new object[] { "hello", TestDate, "123" }
                    };

                Document actualDoc = Deserialize(json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void EmptyArraysReadAsObjectArrays()
            {
                const string Json = @"{ ""field"": [] }";

                // With no elements, we can't tell what type of collection it is, so we default to object.
                var expectedDoc = new Document() { ["field"] = new object[0] };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void ArraysWithOnlyNullsReadAsStringArrays()
            {
                const string Json = @"{ ""field"": [null, null] }";

                // With only null elements, we can't tell what type of collection it is. For backward compatibility, we assume type string.
                // This shouldn't happen in practice anyway since Azure Search generally doesn't allow nulls in collections.
                var expectedDoc = new Document() { ["field"] = new string[] { null, null } };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }
        }
    }
}
