// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ETagConverterTests: JsonConverterTestBase
    {
        public ETagConverterTests(JsonSerializerType serializer) : base(serializer)
        {
        }

        [Theory]
        [TestCase(null)]
        [TestCase("\"tag\"")]
        [TestCase("W/\"weakETag\"")]
        public void CanSerializeAndDeserializeETag(string value)
        {
            var escapedValue = value != null ? Newtonsoft.Json.JsonConvert.ToString(value) : "null";
            var expected = $"{{\"ETag\":{escapedValue}}}";
            var deserialized = Deserialize<ClassWithEtagProperty>(expected);
            var serialized = Serialize(deserialized);

            if (value == null)
            {
                Assert.AreEqual(default(ETag), deserialized.ETag);
            }
            else
            {
                Assert.AreEqual(value, deserialized.ETag.ToString("H"));
            }
            Assert.AreEqual(expected, serialized);
        }

        [Theory]
        [TestCase(null)]
        [TestCase("\"tag\"")]
        [TestCase("W/\"weakETag\"")]
        public void CanSerializeAndDeserializeNullableETag(string value)
        {
            var escapedValue = ToJsonString(value);
            var expected = $"{{\"ETag\":{escapedValue}}}";
            var deserialized = Deserialize<ClassWithNullableEtagProperty>(expected);
            var serialized = Serialize(deserialized);

            if (value == null)
            {
                Assert.Null(deserialized.ETag);
            }
            else
            {
                Assert.AreEqual(value, deserialized.ETag.Value.ToString("H"));
            }
            Assert.AreEqual(expected, serialized);
        }

        private class ClassWithEtagProperty
        {
            public ETag ETag { get; set; }
        }

        private class ClassWithNullableEtagProperty
        {
            public ETag? ETag { get; set; }
        }
    }
}