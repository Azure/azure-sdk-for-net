// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DynamicJsonDynamicMutableTests
    {
        [Test]
        public void ArrayItemsCanBeAssigned()
        {
            var json = DynamicJson.Parse("[0, 1, 2, 3]");
            dynamic dynamicJson = json;
            dynamicJson[1] = 2;
            dynamicJson[2] = null;
            dynamicJson[3] = "string";

            Assert.AreEqual(dynamicJson.ToString(), "[0,2,null,\"string\"]");
        }

        [Test]
        public void ExistingObjectPropertiesCanBeAssigned()
        {
            var json = DynamicJson.Parse("{\"a\":1}");
            dynamic dynamicJson = json;
            dynamicJson.a = "2";

            Assert.AreEqual(json.ToString(), "{\"a\":\"2\"}");
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void NewObjectPropertiesCanBeAssignedWithPrimitive<T>(T value, string expected)
        {
            var json = DynamicJson.Parse("{}");
            dynamic dynamicJson = json;
            dynamicJson.a = value;

            Assert.AreEqual(json.ToString(), "{\"a\":" + expected + "}");
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void PrimitiveValuesCanBeParsedDirectly<T>(T value, string expected)
        {
            dynamic json = DynamicJson.Parse(expected);

            Assert.AreEqual(value, (T)json);
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithArrays()
        {
            var json = DynamicJson.Parse("{}");
            dynamic dynamicJson = json;
            dynamicJson.a = DynamicJson.Array(1, 2, null, "string");

            Assert.AreEqual(json.ToString(), "{\"a\":[1,2,null,\"string\"]}");
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithObject()
        {
            var json = DynamicJson.Parse("{}");
            dynamic dynamicJson = json;
            dynamicJson.a = DynamicJson.Object();
            dynamicJson.a.b = 2;

            Assert.AreEqual(json.ToString(), "{\"a\":{\"b\":2}}");
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithObjectIndirectly()
        {
            var json = DynamicJson.Parse("{}");
            dynamic dynamicJson = json;
            dynamic anotherJson = DynamicJson.Object();
            dynamicJson.a = anotherJson;
            anotherJson.b = 2;

            Assert.AreEqual(json.ToString(), "{\"a\":{\"b\":2}}");
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithSerializedObject()
        {
            var json = DynamicJson.Parse("{}");
            dynamic dynamicJson = json;
            dynamicJson.a = DynamicJson.Serialize(new GeoPoint(1, 2), new JsonSerializerOptions()
            {
                Converters = { new GeoJsonConverter() }
            });

            Assert.AreEqual("{\"a\":{\"type\":\"Point\",\"coordinates\":[1,2]}}", json.ToString());
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void CanModifyNestedProperties<T>(T value, string expected)
        {
            var json = DynamicJson.Parse("{\"a\":{\"b\":2}}");
            dynamic dynamicJson = json;
            dynamicJson.a.b = value;

            Assert.AreEqual(json.ToString(), "{\"a\":{\"b\":" + expected + "}}");
            Assert.AreEqual(value, (T)dynamicJson.a.b);

            dynamic reparsedJson = DynamicJson.Parse(json.ToString());

            Assert.AreEqual(value, (T)reparsedJson.a.b);
        }

        public static IEnumerable<object[]> PrimitiveValues()
        {
            yield return new object[] { "string", "\"string\""};
            yield return new object[] {1L, "1"};
            yield return new object[] {1, "1"};
            yield return new object[] {1.0, "1"};
#if NET5_0
            yield return new object[] {1.1D, "1.1"};
            yield return new object[] {1.1F, "1.100000023841858"};
#else
            yield return new object[] {1.1D, "1.1000000000000001"};
            yield return new object[] {1.1F, "1.1000000238418579"};
#endif
            yield return new object[] {true, "true"};
            yield return new object[] {false, "false"};
        }
    }
}