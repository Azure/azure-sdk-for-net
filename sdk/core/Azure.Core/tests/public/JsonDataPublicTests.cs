// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class JsonDataPublicTests
    {
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
            dynamic jsonData = new BinaryData("[1, null, \"s\"]").ToDynamic();
            int i = 0;
            foreach (var dynamicItem in jsonData)
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
            dynamic jsonData = new BinaryData("[0, 1, 2, 3]").ToDynamic();
            int i = 0;
            foreach (int dynamicItem in jsonData)
            {
                Assert.AreEqual(i, dynamicItem);

                i++;
            }
            Assert.AreEqual(4, i);
        }

        [Test]
        public void DynamicArrayHasLength()
        {
            dynamic jsonData = new BinaryData("[0, 1, 2, 3]").ToDynamic();
            Assert.AreEqual(4, jsonData.Length);
        }

        [Test]
        public void DynamicArrayFor()
        {
            dynamic jsonData = new BinaryData("[0, 1, 2, 3]").ToDynamic();
            for (int i = 0; i < jsonData.Length; i++)
            {
                Assert.AreEqual(i, (int)jsonData[i]);
            }
        }

        [Test]
        public void CanAccessProperties()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } }").ToDynamic();

            Assert.AreEqual("Hello", (string)jsonData.primitive);
            Assert.AreEqual(true, (bool)jsonData.nested.nestedPrimitive);
        }

        [Test]
        public void CanReadIntsAsFloatingPoints()
        {
            dynamic json = new BinaryData("{ \"value\": 5 }").ToDynamic().value;

            Assert.AreEqual(5, (float)json);
            Assert.AreEqual(5, (double)json);
            Assert.AreEqual(5, (int)json);
            Assert.AreEqual(5, (long)json);
        }

        [Test]
        public void ReadingFloatingPointAsIntThrows()
        {
            dynamic json = new BinaryData("{ \"value\": 5.5 }").ToDynamic().value;
            Assert.Throws<FormatException>(() => _ = (int)json);
            Assert.Throws<FormatException>(() => _ = (long)json);
        }

        [Test]
        public void FloatOverflowThrows()
        {
            var json = new BinaryData("{ \"value\": 34028234663852885981170418348451692544000 }").ToDynamic().value;
            Assert.Throws<OverflowException>(() => _ = (float)json);
            Assert.AreEqual(34028234663852885981170418348451692544000d, (double)json);
        }

        [Test]
        public void CanAccessArrayValues()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } , \"array\": [1, 2, 3] }").ToDynamic();

            Assert.AreEqual(1, (int)jsonData.array[0]);
            Assert.AreEqual(2, (int)jsonData.array[1]);
            Assert.AreEqual(3, (int)jsonData.array[2]);
        }

        [Test]
        public void FloatUnderflowThrows()
        {
            var json = new BinaryData("{ \"value\": -34028234663852885981170418348451692544000 }").ToDynamic().value;
            Assert.Throws<OverflowException>(() => _ = (float)json);
            Assert.AreEqual(-34028234663852885981170418348451692544000d, (double)json);
        }

        [Test]
        public void IntOverflowThrows()
        {
            var json = new BinaryData("{ \"value\": 3402823466385288598 }").ToDynamic().value;
            Assert.Throws<OverflowException>(() => _ = (int)json);
            Assert.AreEqual(3402823466385288598L, (long)json);
            Assert.AreEqual(3402823466385288598D, (double)json);
            Assert.AreEqual(3402823466385288598F, (float)json);
        }

        [Test]
        public void IntUnderflowThrows()
        {
            var json = new BinaryData("{ \"value\": -3402823466385288598 }").ToDynamic().value;
            Assert.Throws<OverflowException>(() => _ = (int)json);
            Assert.AreEqual(-3402823466385288598L, (long)json);
            Assert.AreEqual(-3402823466385288598D, (double)json);
            Assert.AreEqual(-3402823466385288598F, (float)json);
        }

        [Test]
        public void ReadingArrayAsValueThrows()
        {
            var json = new BinaryData("{ \"value\": [1,3] }").ToDynamic().value;
            Assert.Throws<InvalidOperationException>(() => _ = (int)json);
        }

        [Test]
        public void CanCastObjects()
        {
            var model = new SampleModel("Hello World", 5);
            dynamic json = new BinaryData(model).ToDynamic();
            var cast = (SampleModel)json;

            Assert.AreEqual(model, cast);
        }

        [Test]
        public void CanCastToTypesYouDontOwn()
        {
            var now = DateTimeOffset.Now;

            // "O" is the only format supported by default JsonSerializer:
            // https://learn.microsoft.com/dotnet/standard/datetime/system-text-json-support
            dynamic nowJson = new BinaryData($"{{ \"value\": \"{now.ToString("O", CultureInfo.InvariantCulture)}\" }}").ToDynamic().value;

            var cast = (DateTimeOffset)nowJson;

            Assert.AreEqual(now, cast);
        }

        [Test]
        public void CanCastToIEnumerableOfT()
        {
            dynamic data = new BinaryData("{ \"array\": [ 1, 2, 3] }").ToDynamic();

            var enumerable = (IEnumerable<int>)data.array;

            int i = 0;
            foreach (var item in enumerable)
            {
                Assert.AreEqual(++i, item);
            }
        }

        [Test]
        public void CanGetDynamicFromBinaryData()
        {
            var data = new BinaryData(new
            {
                array = new[] { 1, 2, 3 }
            });

            dynamic json = data.ToDynamic();
            dynamic array = json.array;

            int i = 0;
            foreach (int item in array)
            {
                Assert.AreEqual(++i, item);
            }
        }

        //[Test]
        //public void EqualsHandlesStringsSpecial()
        //{
        //    Assert.IsTrue((new JsonData("test").Equals("test")));
        //    Assert.IsTrue((new JsonData("test").Equals(new JsonData("test"))));
        //}

        //[Test]
        //public void EqualsForObjectsAndArrays()
        //{
        //    JsonData obj1 = new JsonData(new { foo = "bar" });
        //    JsonData obj2 = new JsonData(new { foo = "bar" });

        //    JsonData arr1 = new JsonData(new[] { "bar" });
        //    JsonData arr2 = new JsonData(new[] { "bar" });

        //    // For objects and arrays, Equals provides reference equality.
        //    Assert.AreEqual(obj1, obj1);
        //    Assert.AreEqual(arr1, arr1);

        //    Assert.AreNotEqual(obj1, obj2);
        //    Assert.AreNotEqual(arr1, arr2);
        //}

        [Test]
        public void OperatorEqualsForString()
        {
            dynamic foo = new BinaryData("{ \"value\": \"foo\" }").ToDynamic().value;
            dynamic bar = new BinaryData("{ \"value\": \"bar\" }").ToDynamic().value;

            Assert.IsTrue(foo == "foo");
            Assert.IsTrue("foo" == foo);
            Assert.IsFalse(foo != "foo");
            Assert.IsFalse("foo" != foo);

            Assert.IsFalse(bar == "foo");
            Assert.IsFalse("foo" == bar);
            Assert.IsTrue(bar != "foo");
            Assert.IsTrue("foo" != bar);
        }

        private T JsonAsType<T>(string json)
        {
            dynamic jsonData = new BinaryData(json).ToDynamic();
            return (T)jsonData;
        }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        internal class SampleModel : IEquatable<SampleModel>
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            public SampleModel() { }
            public string Message { get; set; }
            public int Number { get; set; }
            public SampleModel(string message, int number)
            {
                Message = message;
                Number = number;
            }
            public override bool Equals(object obj)
            {
                SampleModel other = obj as SampleModel;
                if (other == null)
                {
                    return false;
                }
                return Equals(other);
            }
            public bool Equals(SampleModel obj)
            {
                return Message == obj.Message && Number == obj.Number;
            }
        }
    }
}
