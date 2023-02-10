// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Dynamic;
using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class JsonDataPublicMutableTests
    {
        [Test]
        public void ArrayItemsCanBeAssigned()
        {
            dynamic json = new BinaryData("[0, 1, 2, 3]").ToDynamic();
            json[1] = 2;
            json[2] = null;
            json[3] = "string";

            Assert.AreEqual(json.ToString(), "[0,2,null,\"string\"]");
        }

        [Test]
        public void ExistingObjectPropertiesCanBeAssigned()
        {
            dynamic json = new BinaryData("{\"a\":1}").ToDynamic();
            json["a"] = "2";

            Assert.AreEqual(json.ToString(), "{\"a\":\"2\"}");
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void NewObjectPropertiesCanBeAssignedWithPrimitive<T>(T value, string expected)
        {
            dynamic json = JsonDataTestHelpers.CreateEmpty();
            json.a = value;

            Assert.AreEqual(json.ToString(), "{\"a\":" + expected + "}");
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void PrimitiveValuesCanBeParsedDirectly<T>(T value, string expected)
        {
            dynamic json = new BinaryData(expected).ToDynamic();

            Assert.AreEqual(value, (T)json);
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithArrays()
        {
            dynamic json = JsonDataTestHelpers.CreateEmpty();
            json.a = new object[] { 1, 2, null, "string" };

            Assert.AreEqual(json.ToString(), "{\"a\":[1,2,null,\"string\"]}");
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithObject()
        {
            var json = JsonDataTestHelpers.CreateEmpty();
            json.a = new { b = 2 };

            Assert.AreEqual(json.ToString(), "{\"a\":{\"b\":2}}");
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithObjectIndirectly()
        {
            dynamic json = JsonDataTestHelpers.CreateEmpty();
            dynamic anotherJson = JsonDataTestHelpers.CreateEmpty();
            json.a = anotherJson;
            anotherJson.b = 2;

            Assert.AreEqual(json.ToString(), "{\"a\":{\"b\":2}}");
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithSerializedObject()
        {
            var json = JsonDataTestHelpers.CreateEmpty();
            json.a = new GeoPoint(1, 2);

            Assert.AreEqual("{\"a\":{\"type\":\"Point\",\"coordinates\":[1,2]}}", json.ToString());
        }

        [TestCaseSource(nameof(PrimitiveValues))]
        public void CanModifyNestedProperties<T>(T value, string expected)
        {
            var json = new BinaryData("{\"a\":{\"b\":2}}").ToDynamic();
            json.a.b = value;

            Assert.AreEqual(json.ToString(), "{\"a\":{\"b\":" + expected + "}}");
            Assert.AreEqual(value, (T)json.a.b);

            dynamic reparsedJson = new BinaryData(json.ToString()).ToDynamic();

            Assert.AreEqual(value, (T)reparsedJson.a.b);
        }

        public static IEnumerable<object[]> PrimitiveValues()
        {
            yield return new object[] { "string", "\"string\"" };
            yield return new object[] { 1L, "1" };
            yield return new object[] { 1, "1" };
            yield return new object[] { 1.0, "1" };
#if NETCOREAPP
                    yield return new object[] {1.1D, "1.1"};
                    yield return new object[] {1.1F, "1.1"};
#else
            yield return new object[] { 1.1D, "1.1000000000000001" };
            yield return new object[] { 1.1F, "1.10000002" };
#endif
            yield return new object[] { true, "true" };
            yield return new object[] { false, "false" };
        }
    }
}
