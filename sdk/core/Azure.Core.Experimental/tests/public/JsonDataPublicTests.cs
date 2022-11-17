// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class JsonDataPublicTests
    {
        [Test]
        public void CanCreateFromJson()
        {
            dynamic jsonData = new BinaryData("\"string\"").ToDynamic();

            Assert.AreEqual("string", (string)jsonData);
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
            var json = new BinaryData("5").ToDynamic();
            dynamic jsonData = json;

            Assert.AreEqual(5, (float)jsonData);
            Assert.AreEqual(5, (double)jsonData);
            Assert.AreEqual(5, (int)jsonData);
            Assert.AreEqual(5, (long)jsonData);
            Assert.AreEqual(5, (float)json);
            Assert.AreEqual(5, (double)json);
            Assert.AreEqual(5, (int)json);
            Assert.AreEqual(5, (long)json);
        }

        [Test]
        public void ReadingFloatingPointAsIntThrows()
        {
            var json = new BinaryData("5.5").ToDynamic();
            dynamic jsonData = json;
            Assert.Throws<FormatException>(() => _ = (int)json);
            Assert.Throws<FormatException>(() => _ = (int)jsonData);
            Assert.Throws<FormatException>(() => _ = (long)json);
            Assert.Throws<FormatException>(() => _ = (long)jsonData);
        }

        [Test]
        public void FloatOverflowThrows()
        {
            var json = new BinaryData("34028234663852885981170418348451692544000").ToDynamic();
            dynamic jsonData = json;
            Assert.Throws<OverflowException>(() => _ = (float)json);
            Assert.Throws<OverflowException>(() => _ = (float)jsonData);
            Assert.AreEqual(34028234663852885981170418348451692544000d, (double)jsonData);
            Assert.AreEqual(34028234663852885981170418348451692544000d, (double)json);
        }

        [Test]
        public void FloatUnderflowThrows()
        {
            var json = new BinaryData("-34028234663852885981170418348451692544000").ToDynamic();
            dynamic jsonData = json;
            Assert.Throws<OverflowException>(() => _ = (float)json);
            Assert.Throws<OverflowException>(() => _ = (float)jsonData);
            Assert.AreEqual(-34028234663852885981170418348451692544000d, (double)jsonData);
            Assert.AreEqual(-34028234663852885981170418348451692544000d, (double)json);
        }

        [Test]
        public void IntOverflowThrows()
        {
            var json = new BinaryData("3402823466385288598").ToDynamic();
            dynamic jsonData = json;
            Assert.Throws<OverflowException>(() => _ = (int)json);
            Assert.Throws<OverflowException>(() => _ = (int)jsonData);
            Assert.AreEqual(3402823466385288598L, (long)jsonData);
            Assert.AreEqual(3402823466385288598L, (long)json);
            Assert.AreEqual(3402823466385288598D, (double)jsonData);
            Assert.AreEqual(3402823466385288598D, (double)json);
            Assert.AreEqual(3402823466385288598F, (float)jsonData);
            Assert.AreEqual(3402823466385288598F, (float)json);
        }

        [Test]
        public void IntUnderflowThrows()
        {
            var json = new BinaryData("-3402823466385288598").ToDynamic();
            dynamic jsonData = json;
            Assert.Throws<OverflowException>(() => _ = (int)json);
            Assert.Throws<OverflowException>(() => _ = (int)jsonData);
            Assert.AreEqual(-3402823466385288598L, (long)jsonData);
            Assert.AreEqual(-3402823466385288598L, (long)json);
            Assert.AreEqual(-3402823466385288598D, (double)jsonData);
            Assert.AreEqual(-3402823466385288598D, (double)json);
            Assert.AreEqual(-3402823466385288598F, (float)jsonData);
            Assert.AreEqual(-3402823466385288598F, (float)json);
        }

        [Test]
        public void ReadingArrayAsValueThrows()
        {
            var json = new BinaryData("[1,3]").ToDynamic();
            dynamic jsonData = json;
            Assert.Throws<InvalidOperationException>(() => _ = (int)json);
            Assert.Throws<InvalidOperationException>(() => _ = (int)jsonData);
        }

        [Test]
        public void RoundtripObjects()
        {
            var model = new SampleModel("Hello World", 5);
            var roundtripped = (SampleModel)new BinaryData(model).ToDynamic();

            Assert.AreEqual(model, roundtripped);
        }

        [Test]
        public void EqualsHandlesStringsSpecial()
        {
            dynamic json = new BinaryData("\"test\"").ToDynamic();

            Assert.IsTrue(json.Equals("test"));
            Assert.IsTrue(json.Equals(new BinaryData("\"test\"").ToDynamic()));
        }

        [Test]
        public void EqualsForObjectsAndArrays()
        {
            dynamic obj1 = new BinaryData(new { foo = "bar" }).ToDynamic();
            dynamic obj2 = new BinaryData(new { foo = "bar" }).ToDynamic();

            dynamic arr1 = new BinaryData(new[] { "bar" }).ToDynamic();
            dynamic arr2 = new BinaryData(new[] { "bar" }).ToDynamic();

            // For objects and arrays, Equals provides reference equality.
            Assert.AreEqual(obj1, obj1);
            Assert.AreEqual(arr1, arr1);

            Assert.AreNotEqual(obj1, obj2);
            Assert.AreNotEqual(arr1, arr2);
        }

        [Test]
        public void OperatorEqualsForString()
        {
            dynamic fooJson = new BinaryData("\"foo\"").ToDynamic();
            dynamic barJson = new BinaryData("\"bar\"").ToDynamic();

            Assert.IsTrue(fooJson == "foo");
            Assert.IsTrue("foo" == fooJson);
            Assert.IsFalse(fooJson != "foo");
            Assert.IsFalse("foo" != fooJson);

            Assert.IsFalse(barJson == "foo");
            Assert.IsFalse("foo" == barJson);
            Assert.IsTrue(barJson != "foo");
            Assert.IsTrue("foo" != barJson);
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
