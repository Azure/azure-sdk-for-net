// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Dynamic;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class JsonDataTests
    {
        //[Test]
        //public void CanCreateFromJson()
        //{
        //    var jsonData = DynamicJsonTests.GetDynamicJson("\"string\"");

        //    Assert.AreEqual("\"string\"", jsonData.ToJsonString());
        //}

        //[Test]
        //public void CanCreateFromNull()
        //{
        //    var jsonData = new JsonData(null);
        //    Assert.AreEqual(JsonValueKind.Null, jsonData.Kind);
        //}

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
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[1, null, \"s\"]");
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
            dynamic jsonData = DynamicJsonTests.GetDynamicJson("[0, 1, 2, 3]");
            int i = 0;
            foreach (int dynamicItem in jsonData)
            {
                Assert.AreEqual(i, dynamicItem);

                i++;
            }
            Assert.AreEqual(4, i);
        }

        [Test]
        public void CanAccessProperties()
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson(@"
                {
                  ""primitive"" : ""Hello"",
                  ""nested"" : {
                      ""nestedPrimitive"": true
                 }
              }");

            Assert.AreEqual("Hello", (string)jsonData.primitive);
            Assert.AreEqual(true, (bool)jsonData.nested.nestedPrimitive);
        }

        //[Test]
        //public void CanReadIntsAsFloatingPoints()
        //{
        //    var json = JsonData.Parse("5");
        //    dynamic jsonData = json;

        //    Assert.AreEqual(5, (float)jsonData);
        //    Assert.AreEqual(5, (double)jsonData);
        //    Assert.AreEqual(5, (int)jsonData);
        //    Assert.AreEqual(5, (long)jsonData);
        //    Assert.AreEqual(5, (float)json);
        //    Assert.AreEqual(5, (double)json);
        //    Assert.AreEqual(5, (int)json);
        //    Assert.AreEqual(5, (long)json);
        //}

        //[Test]
        //public void ReadingFloatingPointAsIntThrows()
        //{
        //    var json = JsonData.Parse("5.5");
        //    dynamic jsonData = json;
        //    Assert.Throws<FormatException>(() => _ = (int)json);
        //    Assert.Throws<FormatException>(() => _ = (int)jsonData);
        //    Assert.Throws<FormatException>(() => _ = (long)json);
        //    Assert.Throws<FormatException>(() => _ = (long)jsonData);
        //}

        //[Test]
        //public void FloatOverflowThrows()
        //{
        //    var json = JsonData.Parse("34028234663852885981170418348451692544000");
        //    dynamic jsonData = json;
        //    Assert.Throws<OverflowException>(() => _ = (float)json);
        //    Assert.Throws<OverflowException>(() => _ = (float)jsonData);
        //    Assert.AreEqual(34028234663852885981170418348451692544000d, (double)jsonData);
        //    Assert.AreEqual(34028234663852885981170418348451692544000d, (double)json);
        //}

        //[Test]
        //public void FloatUnderflowThrows()
        //{
        //    var json = JsonData.Parse("-34028234663852885981170418348451692544000");
        //    dynamic jsonData = json;
        //    Assert.Throws<OverflowException>(() => _ = (float)json);
        //    Assert.Throws<OverflowException>(() => _ = (float)jsonData);
        //    Assert.AreEqual(-34028234663852885981170418348451692544000d, (double)jsonData);
        //    Assert.AreEqual(-34028234663852885981170418348451692544000d, (double)json);
        //}

        //[Test]
        //public void IntOverflowThrows()
        //{
        //    var json = JsonData.Parse("3402823466385288598");
        //    dynamic jsonData = json;
        //    Assert.Throws<OverflowException>(() => _ = (int)json);
        //    Assert.Throws<OverflowException>(() => _ = (int)jsonData);
        //    Assert.AreEqual(3402823466385288598L, (long)jsonData);
        //    Assert.AreEqual(3402823466385288598L, (long)json);
        //    Assert.AreEqual(3402823466385288598D, (double)jsonData);
        //    Assert.AreEqual(3402823466385288598D, (double)json);
        //    Assert.AreEqual(3402823466385288598F, (float)jsonData);
        //    Assert.AreEqual(3402823466385288598F, (float)json);
        //}

        //[Test]
        //public void IntUnderflowThrows()
        //{
        //    var json = JsonData.Parse("-3402823466385288598");
        //    dynamic jsonData = json;
        //    Assert.Throws<OverflowException>(() => _ = (int)json);
        //    Assert.Throws<OverflowException>(() => _ = (int)jsonData);
        //    Assert.AreEqual(-3402823466385288598L, (long)jsonData);
        //    Assert.AreEqual(-3402823466385288598L, (long)json);
        //    Assert.AreEqual(-3402823466385288598D, (double)jsonData);
        //    Assert.AreEqual(-3402823466385288598D, (double)json);
        //    Assert.AreEqual(-3402823466385288598F, (float)jsonData);
        //    Assert.AreEqual(-3402823466385288598F, (float)json);
        //}

        //[Test]
        //public void ReadingArrayAsValueThrows()
        //{
        //    var json = JsonData.Parse("[1,3]");
        //    dynamic jsonData = json;
        //    Assert.Throws<InvalidOperationException>(() => _ = (int)json);
        //    Assert.Throws<InvalidOperationException>(() => _ = (int)jsonData);
        //}

        //[Test]
        //public void RoundtripObjects()
        //{
        //    var model = new SampleModel("Hello World", 5);
        //    var roundtripped = new JsonData(model).To<SampleModel>();

        //    Assert.AreEqual(model, roundtripped);
        //}

        //[Test]
        //public void EqualsProvidesValueEqualityPrimitives()
        //{
        //    Assert.AreEqual(new JsonData(1), new JsonData(1));
        //    Assert.AreEqual(new JsonData(true), new JsonData(true));
        //    Assert.AreEqual(new JsonData(false), new JsonData(false));
        //    Assert.AreEqual(new JsonData("hello"), new JsonData("hello"));
        //    Assert.AreEqual(new JsonData(null), new JsonData(null));
        //}

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

        //[Test]
        //public void EqualsAndNull()
        //{
        //    Assert.AreNotEqual(new JsonData(null), null);
        //    Assert.AreNotEqual(null, new JsonData(null));
        //}

        //[Test]
        //public void OperatorEqualsForString()
        //{
        //    Assert.IsTrue(new JsonData("foo") == "foo");
        //    Assert.IsTrue("foo" == new JsonData("foo"));
        //    Assert.IsFalse(new JsonData("foo") != "foo");
        //    Assert.IsFalse("foo" != new JsonData("foo"));

        //    Assert.IsFalse(new JsonData("bar") == "foo");
        //    Assert.IsFalse("foo" == new JsonData("bar"));
        //    Assert.IsTrue(new JsonData("bar") != "foo");
        //    Assert.IsTrue("foo" != new JsonData("bar"));
        //}

        ////[Test]
        ////public void JsonDataInPOCOsWorks()
        ////{
        ////    JsonData orig = new JsonData(new
        ////    {
        ////        property = new JsonData("hello")
        ////    });

        ////    void validate(JsonData d)
        ////    {
        ////        Assert.AreEqual(JsonValueKind.Object, d.Kind);
        ////        Assert.AreEqual(d.Properties.Count(), 1);
        ////        Assert.AreEqual(d.Get("property"), "hello");
        ////    }

        ////    validate(orig);

        ////    JsonData roundTrip = JsonSerializer.Deserialize<JsonData>(JsonSerializer.Serialize(orig, orig.GetType()));

        ////    validate(roundTrip);
        ////}

        private T JsonAsType<T>(string json)
        {
            dynamic jsonData = DynamicJsonTests.GetDynamicJson(json);
            return (T) jsonData;
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
