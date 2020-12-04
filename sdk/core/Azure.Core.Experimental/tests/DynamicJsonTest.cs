// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public void DynamicCanConvertToLong() => Assert.AreEqual(5L, JsonAsType<long>("5"));

        [Test]
        public void DynamicCanConvertToBool() => Assert.AreEqual(true, JsonAsType<bool>("true"));

        [Test]
        public void DynamicCanConvertToNullAsString() => Assert.AreEqual(null, JsonAsType<string>("null"));

        [Test]
        public void DynamicCanConvertToNullAsNullableInt() => Assert.AreEqual(null, JsonAsType<int?>("null"));

        [Test]
        public void DynamicCanConvertToNullAsNullableLong() => Assert.AreEqual(null, JsonAsType<long?>("null"));

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
            Assert.AreEqual(4, dynamicJson.GetArrayLength());
        }

        [Test]
        public void DynamicArrayFor()
        {
            dynamic dynamicJson = DynamicJson.Parse("[0, 1, 2, 3]");
            for (int i = 0; i < dynamicJson.GetArrayLength(); i++)
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

        [Test]
        public void CanReadIntsAsFloatingPoints()
        {
            var json = DynamicJson.Parse("5");
            dynamic dynamicJson = json;

            Assert.AreEqual(5, (float)dynamicJson);
            Assert.AreEqual(5, (double)dynamicJson);
            Assert.AreEqual(5, (int)dynamicJson);
            Assert.AreEqual(5, (long)dynamicJson);
            Assert.AreEqual(5, (float)json);
            Assert.AreEqual(5, (double)json);
            Assert.AreEqual(5, (int)json);
            Assert.AreEqual(5, (long)json);
        }

        [Test]
        public void ReadingFloatingPointAsIntThrows()
        {
            var json = DynamicJson.Parse("5.5");
            dynamic dynamicJson = json;
            Assert.Throws<FormatException>(() => _ = (int)json);
            Assert.Throws<FormatException>(() => _ = (int)dynamicJson);
            Assert.Throws<FormatException>(() => _ = (long)json);
            Assert.Throws<FormatException>(() => _ = (long)dynamicJson);
        }

        [Test]
        public void FloatOverflowThrows()
        {
            var json = DynamicJson.Parse("34028234663852885981170418348451692544000");
            dynamic dynamicJson = json;
            Assert.Throws<OverflowException>(() => _ = (float)json);
            Assert.Throws<OverflowException>(() => _ = (float)dynamicJson);
            Assert.AreEqual(34028234663852885981170418348451692544000d, (double)dynamicJson);
            Assert.AreEqual(34028234663852885981170418348451692544000d, (double)json);
        }

        [Test]
        public void FloatUnderflowThrows()
        {
            var json = DynamicJson.Parse("-34028234663852885981170418348451692544000");
            dynamic dynamicJson = json;
            Assert.Throws<OverflowException>(() => _ = (float)json);
            Assert.Throws<OverflowException>(() => _ = (float)dynamicJson);
            Assert.AreEqual(-34028234663852885981170418348451692544000d, (double)dynamicJson);
            Assert.AreEqual(-34028234663852885981170418348451692544000d, (double)json);
        }

        [Test]
        public void IntOverflowThrows()
        {
            var json = DynamicJson.Parse("3402823466385288598");
            dynamic dynamicJson = json;
            Assert.Throws<OverflowException>(() => _ = (int)json);
            Assert.Throws<OverflowException>(() => _ = (int)dynamicJson);
            Assert.AreEqual(3402823466385288598L, (long)dynamicJson);
            Assert.AreEqual(3402823466385288598L, (long)json);
            Assert.AreEqual(3402823466385288598D, (double)dynamicJson);
            Assert.AreEqual(3402823466385288598D, (double)json);
            Assert.AreEqual(3402823466385288598F, (float)dynamicJson);
            Assert.AreEqual(3402823466385288598F, (float)json);
        }

        [Test]
        public void IntUnderflowThrows()
        {
            var json = DynamicJson.Parse("-3402823466385288598");
            dynamic dynamicJson = json;
            Assert.Throws<OverflowException>(() => _ = (int)json);
            Assert.Throws<OverflowException>(() => _ = (int)dynamicJson);
            Assert.AreEqual(-3402823466385288598L, (long)dynamicJson);
            Assert.AreEqual(-3402823466385288598L, (long)json);
            Assert.AreEqual(-3402823466385288598D, (double)dynamicJson);
            Assert.AreEqual(-3402823466385288598D, (double)json);
            Assert.AreEqual(-3402823466385288598F, (float)dynamicJson);
            Assert.AreEqual(-3402823466385288598F, (float)json);
        }

        [Test]
        public void ReadingArrayAsValueThrows()
        {
            var json = DynamicJson.Parse("[1,3]");
            dynamic dynamicJson = json;
            Assert.Throws<InvalidOperationException>(() => _ = (int)json);
            Assert.Throws<InvalidOperationException>(() => _ = (int)dynamicJson);
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
