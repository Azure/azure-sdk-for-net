// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Serialization.Internal;
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
                Converters = CustomJsonConverters.CreateAllConverters().ToList(),
                DateParseHandling = DateParseHandling.DateTimeOffset,
                NullValueHandling = NullValueHandling.Include
            };

        private static Document Deserialize(string json) => JsonConvert.DeserializeObject<Document>(json, Settings);

        private static void AssertDocumentsEqual(Document expectedDoc, Document actualDoc) =>
            Assert.Equal(expectedDoc, actualDoc, new DataPlaneModelComparer<Document>());

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
    ""field4"": [ null, { ""name"": ""Bob"" } ]
}";

                var expectedDoc =
                    new Document()
                    {
                        ["field1"] = null,
                        ["field2"] = new string[] { "hello", null },
                        ["field3"] = new object[] { null, 123L, null },
                        ["field4"] = new object[] { null, new Document() { ["name"] = "Bob" } }
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
            public void CanReadGeoPointCollection()
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

            [Fact]
            public void CanReadComplexObject()
            {
                const string Json =
@"{
    ""name"": ""Boots"",
    ""details"": {
        ""sku"": 123,
        ""seasons"": [ ""fall"", ""winter"" ]
    }
}";

                var expectedDoc =
                    new Document()
                    {
                        ["name"] = "Boots",
                        ["details"] = new Document()
                        {
                            ["sku"] = 123L,
                            ["seasons"] = new string[] { "fall", "winter" }
                        }
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void CanReadComplexCollection()
            {
                const string Json =
@"{
    ""stores"": [
        {
            ""name"": ""North"",
            ""address"": {
                ""city"": ""Vancouver"",
                ""country"": ""Canada""
            },
            ""location"": { ""type"": ""Point"", ""coordinates"": [-121, 49] }
        },
        {
            ""name"": ""South"",
            ""address"": {
                ""city"": ""Seattle"",
                ""country"": ""USA""
            },
            ""location"": { ""type"": ""Point"", ""coordinates"": [-122.5, 47.6] }
        }
    ]
}";

                var expectedDoc =
                    new Document()
                    {
                        ["stores"] = new[]
                        {
                            new Document()
                            {
                                ["name"] = "North",
                                ["address"] = new Document()
                                {
                                    ["city"] = "Vancouver",
                                    ["country"] = "Canada"
                                },
                                ["location"] = GeographyPoint.Create(latitude: 49, longitude: -121)
                            },
                            new Document()
                            {
                                ["name"] = "South",
                                ["address"] = new Document()
                                {
                                    ["city"] = "Seattle",
                                    ["country"] = "USA"
                                },
                                ["location"] = GeographyPoint.Create(latitude: 47.6, longitude: -122.5)
                            }
                        }
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            // This is not quite a pinning test in the sense that it actually is correct behavior if the field is defined
            // as Edm.DateTimeOffset. What's notable is that this is how such values deserialize even when the field is not that type.
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
    ""field4"": [""NaN"", ""INF"", ""-INF""],
    ""field5"": { ""value"": ""-INF"" }
}";

                var expectedDoc =
                    new Document()
                    {
                        ["field1"] = "NaN",
                        ["field2"] = "INF",
                        ["field3"] = "-INF",
                        ["field4"] = new string[] { "NaN", "INF", "-INF" },
                        ["field5"] = new Document() { ["value"] = "-INF" }
                    };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }

            [Fact]
            public void CanReadArraysOfMixedTypes()
            {
                // Azure Cognitive Search won't return payloads like this; This test is only for pinning purposes.
                const string Json =
@"{
    ""field"": [
        ""hello"",
        123,
        3.14,
        { ""type"": ""Point"", ""coordinates"": [-122.131577, 47.678581] },
        { ""name"": ""Arthur"", ""quest"": null }
    ]
}";

                var expectedDoc =
                    new Document()
                    {
                        ["field"] = new object[]
                        {
                            "hello",
                            123L,
                            3.14,
                            GeographyPoint.Create(47.678581, -122.131577),
                            new Document()
                            {
                                ["name"] = "Arthur",
                                ["quest"] = null
                            }
                        }
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
                // This shouldn't happen in practice anyway since Azure Cognitive Search generally doesn't allow nulls in collections.
                var expectedDoc = new Document() { ["field"] = new string[] { null, null } };

                Document actualDoc = Deserialize(Json);

                AssertDocumentsEqual(expectedDoc, actualDoc);
            }
        }
    }
}
