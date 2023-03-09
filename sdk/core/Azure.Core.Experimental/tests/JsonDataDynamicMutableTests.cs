// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.GeoJson;
using Azure.Core.Json;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class JsonDataDynamicMutableTests
    {
        [Test]
        public void ArrayItemsCanBeAssigned()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");

            json[1] = 2;
            json[2] = null;
            json[3] = "string";

            Assert.AreEqual("[0,2,null,\"string\"]", json.ToString());
        }

        [Test]
        public void ExistingObjectPropertiesCanBeAssigned()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{\"a\":1}");

            json.a = "2";

            Assert.AreEqual("{\"a\":\"2\"}", json.ToString());
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void NewObjectPropertiesCanBeAssignedWithPrimitive<T>(T value, string expected)
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");

            json.a = value;

            Assert.AreEqual("{\"a\":" + expected + "}", json.ToString());
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void PrimitiveValuesCanBeParsedDirectly<T>(T value, string expected)
        {
            dynamic json = DynamicJsonTests.GetDynamicJson(expected);

            Assert.AreEqual(value, (T)json);
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithArrays()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");

            json.a = new MutableJsonDocument(new object[] { 1, 2, null, "string" });

            Assert.AreEqual("{\"a\":[1,2,null,\"string\"]}", json.ToString());
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithObject()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");

            json.a = DynamicJsonTests.GetDynamicJson("{}");
            json.a.b = 2;

            Assert.AreEqual("{\"a\":{\"b\":2}}", json.ToString());
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithObjectIndirectly()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");
            dynamic anotherJson = DynamicJsonTests.GetDynamicJson("{}");

            json.a = anotherJson;
            anotherJson.b = 2;

            Assert.AreEqual("{\"a\":{\"b\":2}}", json.ToString());
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithSerializedObject()
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{}");

            json.a = new MutableJsonDocument(new GeoPoint(1, 2));

            Assert.AreEqual("{\"a\":{\"type\":\"Point\",\"coordinates\":[1,2]}}", json.ToString());
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void CanModifyNestedProperties<T>(T value, string expected)
        {
            dynamic json = DynamicJsonTests.GetDynamicJson("{\"a\":{\"b\":2}}");

            json.a.b = value;

            Assert.AreEqual("{\"a\":{\"b\":" + expected + "}}", json.ToString());
            Assert.AreEqual(value, (T)json.a.b);

            dynamic reparsedJson = DynamicJsonTests.GetDynamicJson(json.ToString());

            Assert.AreEqual(value, (T)reparsedJson.a.b);
        }

        public static IEnumerable<object[]> PrimitiveValues()
        {
            yield return new object[] { "string", "\"string\""};
            yield return new object[] {1L, "1"};
            yield return new object[] {1, "1"};
            yield return new object[] {1.0, "1"};
#if NETCOREAPP
            yield return new object[] {1.1D, "1.1"};
            yield return new object[] {1.1F, "1.1"};
#else
            yield return new object[] {1.1D, "1.1000000000000001"};
            yield return new object[] {1.1F, "1.10000002" };
#endif
            yield return new object[] {true, "true"};
            yield return new object[] {false, "false"};
        }
    }
}
