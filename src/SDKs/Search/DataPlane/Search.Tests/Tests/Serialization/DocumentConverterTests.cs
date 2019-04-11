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
    ""field2"": [ ""hello"", null ]
}";

                var expectedDoc =
                    new Document()
                    {
                        ["field1"] = null,
                        ["field2"] = new[] { "hello", null }
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void CanReadArraysOfStrings()
            {
                const string Json = @"{ ""field"": [""hello"", ""goodbye""] }";

                var expectedDoc =
                    new Document()
                    {
                        ["field"] = new[] { "hello", "goodbye" }
                    };

                Document actualDoc = Deserialize(Json);

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
        }

        // These are all pinning tests. These tests don't exemplify ideal behavior, but it's the best we can do without type information.
        public sealed class Pinning
        {
            private const string TestDateString = "2016-10-10T17:41:05.123-07:00";

            private static readonly DateTimeOffset TestDate = new DateTimeOffset(2016, 10, 10, 17, 41, 5, 123, TimeSpan.FromHours(-7));

            [Fact]
            public void SpecialDoublesAreReadAsStrings()
            {
                const string Json =
    @"{
    ""field1"": ""NaN"",
    ""field2"": ""INF"",
    ""field3"": ""-INF""
}";

                var expectedDoc =
                    new Document()
                    {
                        ["field1"] = "NaN",
                        ["field2"] = "INF",
                        ["field3"] = "-INF"
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void DateTimeStringsAreReadAsDateTime()
            {
                string json = $@"{{ ""field"": ""{TestDateString}"" }}";

                var expectedDoc = new Document() { ["field"] = TestDate };

                Document actualDoc = Deserialize(json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void CanReadArraysOfMixedTypes()
            {
                // Azure Search won't return payloads like this; This test is only for pinning purposes.
                const string Json = @"{ ""field"": [""hello"", 123, 3.14] }";

                var expectedDoc =
                    new Document()
                    {
                        ["field"] = new object[] { "hello", 123L, 3.14 }
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
            public void EmptyArraysReadAsStringArrays()
            {
                const string Json = @"{ ""field"": [] }";

                // With no elements, we can't tell what type of collection it is. For backward compatibility, we assume type string.
                var expectedDoc = new Document() { ["field"] = new string[0] };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void ArraysWithOnlyNullsReadAsStringArrays()
            {
                const string Json = @"{ ""field"": [null, null] }";

                // With only null elements, we can't tell what type of collection it is. For backward compatibility, we assume type string.
                var expectedDoc = new Document() { ["field"] = new string[] { null, null } };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }
        }
    }
}
