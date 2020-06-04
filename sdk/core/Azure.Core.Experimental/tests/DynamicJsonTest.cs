// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DynamicJsonTest
    {
        [Test]
        public void CanCreateFromJson()
        {
            var dynamicJson = DynamicJson.Parse("\"string\"");

            Assert.AreEqual("\"string\"", dynamicJson.ToString());
        }

        [Test]
        public void DynamicCanConvertToString() => Assert.AreEqual("string", JsonAsType<string>("\"string\""));

        [Test]
        public void DynamicCanConvertToInt() => Assert.AreEqual(5, JsonAsType<int>("5"));

        [Test]
        [Ignore("nope")]
        public void DynamicCanConvertToLong() => Assert.AreEqual(5L, JsonAsType<long>("5"));

        [Test]
        public void DynamicCanConvertToBool() => Assert.AreEqual(true, JsonAsType<bool>("true"));

        [Test]
        public void DynamicCanConvertToNullAsString() => Assert.AreEqual(null, JsonAsType<string>("null"));

        [Ignore("nope")]
        [Test]
        public void DynamicCanConvertToNullAsNullableInt() => Assert.AreEqual(null, JsonAsType<int?>("null"));

        [Ignore("nope")]
        [Test]
        public void DynamicCanConvertToNullAsNullableLong() => Assert.AreEqual(null, JsonAsType<long?>("null"));

        [Ignore("nope")]
        [Test]
        public void DynamicCanConvertToNullAsNullableBool() => Assert.AreEqual(null, JsonAsType<bool?>("null"));

        [Test]
        public void DynamicCanConvertToIEnumerableDynamic()
        {
            dynamic dynamicJson = DynamicJson.Parse("[1, null, \"s\"]");
            int i = 0;
            foreach (var dynamicItem in dynamicJson)
            {
                switch (i)
                {
                    case 0:
                        Assert.AreEqual(1, (int)dynamicItem);
                        break;
                    case 1:
                        Assert.AreEqual(null, (string)dynamicItem);
                        break;
                    case 2:
                        Assert.AreEqual("s", (string)dynamicItem);
                        break;
                    default:
                        Assert.Fail();
                        break;
                }

                i++;
            }
            Assert.AreEqual(3, i);
        }

        [Test]
        public void DynamicCanConvertToIEnumerableInt()
        {
            dynamic dynamicJson = DynamicJson.Parse("[0, 1, 2, 3]");
            int i = 0;
            foreach (int dynamicItem in dynamicJson)
            {
                Assert.AreEqual(i, dynamicItem);

                i++;
            }
            Assert.AreEqual(4, i);
        }

        [Test]
        public void DynamicArrayHasLength()
        {
            dynamic dynamicJson = DynamicJson.Parse("[0, 1, 2, 3]");
            Assert.AreEqual(4, dynamicJson.Length);
        }

        [Test]
        public void DynamicArrayFor()
        {
            dynamic dynamicJson = DynamicJson.Parse("[0, 1, 2, 3]");
            for (int i = 0; i < dynamicJson.Length; i++)
            {
                Assert.AreEqual(i, (int)dynamicJson[i]);
            }
        }

        [Test]
        public void CanAccessProperties()
        {
            dynamic dynamicJson = DynamicJson.Parse("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } }");

            Assert.AreEqual("Hello", (string)dynamicJson.primitive);
            Assert.AreEqual(true, (bool)dynamicJson.nested.nestedPrimitive);
        }

        private T JsonAsType<T>(string json)
        {
            dynamic dynamicJson = DynamicJson.Parse(json);
            return (T) dynamicJson;
        }

        internal class DynamicJsonSubclass : DynamicJson
        {
            protected DynamicJsonSubclass(JsonElement element) : base(element)
            {
            }
        }
    }
}