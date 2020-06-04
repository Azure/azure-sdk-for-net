// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Spatial;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DynamicJsonMutableTests
    {
        [Test]
        public void ArrayItemsCanBeAssigned()
        {
            var json = DynamicJson.Parse("[0, 1, 2, 3]");
            dynamic dynamicJson = json;
            dynamicJson[1] = 2;
            dynamicJson[2] = null;
            dynamicJson[3] = "string";

            Assert.AreEqual(dynamicJson.ToString(), "[2, null, \"string\"]");
        }

        [Test]
        public void ExistingObjectPropertiesCanBeAssigned()
        {
            var json = DynamicJson.Parse("{\"a\":1}");
            dynamic dynamicJson = json;
            dynamicJson.a = "2";

            Assert.AreEqual(json.ToString(), "{\"a\":\"2\"}");
        }

        [Test]
        public void NewObjectPropertiesCanBeAssignedWithPrimitive()
        {
            var json = DynamicJson.Parse("{}");
            dynamic dynamicJson = json;
            dynamicJson.a = "2";

            Assert.AreEqual(json.ToString(), "{\"a\":\"2\"}");
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
        public void NewObjectPropertiesCanBeAssignedWithSerializedObject()
        {
            var json = DynamicJson.Parse("{}");
            dynamic dynamicJson = json;
            dynamicJson.a = DynamicJson.Serialize(new PointGeometry(new GeometryPosition(1, 2)), new JsonSerializerOptions()
            {
                Converters = { new GeometryJsonConverter() }
            });

            Assert.AreEqual("", json.ToString());
        }
    }
}