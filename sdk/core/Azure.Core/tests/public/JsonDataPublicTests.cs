// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class JsonDataPublicTests
    {
        [Test]
        public void CanCreateFromJson()
        {
            dynamic jsonData = new BinaryData("\"string\"").ToDynamicFromJson();

            Assert.AreEqual("string", (string)jsonData);
        }

        [Test]
        public void DynamicCanConvertToString() => Assert.AreEqual("string", JsonDataTestHelpers.JsonAsType<string>("\"string\""));

        [Test]
        public void DynamicCanConvertToInt() => Assert.AreEqual(5, JsonDataTestHelpers.JsonAsType<int>("5"));

        [Test]
        public void DynamicCanConvertToLong() => Assert.AreEqual(5L, JsonDataTestHelpers.JsonAsType<long>("5"));

        [Test]
        public void DynamicCanConvertToBool() => Assert.AreEqual(true, JsonDataTestHelpers.JsonAsType<bool>("true"));

        [Test]
        public void DynamicCanConvertToNullAsString() => Assert.AreEqual(null, JsonDataTestHelpers.JsonAsType<string>("null"));

        [Test]
        public void DynamicCanConvertToNullAsNullableInt() => Assert.AreEqual(null, JsonDataTestHelpers.JsonAsType<int?>("null"));

        [Test]
        public void DynamicCanConvertToNullAsNullableLong() => Assert.AreEqual(null, JsonDataTestHelpers.JsonAsType<long?>("null"));

        [Test]
        public void DynamicCanConvertToNullAsNullableBool() => Assert.AreEqual(null, JsonDataTestHelpers.JsonAsType<bool?>("null"));

        [Test]
        public void CanForeachOverHeterogenousArrayValues()
        {
            dynamic jsonData = new BinaryData("[1, null, \"s\"]").ToDynamicFromJson();
            int i = 0;
            foreach (dynamic dynamicItem in jsonData)
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
        public void CanForeachOverIntArrayValues()
        {
            dynamic jsonData = new BinaryData("[0, 1, 2, 3]").ToDynamicFromJson();
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
            dynamic jsonData = new BinaryData("[0, 1, 2, 3]").ToDynamicFromJson();
            Assert.AreEqual(4, ((int[])jsonData).Length);
        }

        [Test]
        public void DynamicArrayForEach()
        {
            dynamic jsonData = new BinaryData("[0, 1, 2, 3]").ToDynamicFromJson();
            int expected = 0;
            foreach (int i in jsonData)
            {
                Assert.AreEqual(expected++, i);
            }
        }

        [Test]
        public void CanAccessProperties()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } }").ToDynamicFromJson();

            Assert.AreEqual("Hello", (string)jsonData.primitive);
            Assert.AreEqual(true, (bool)jsonData.nested.nestedPrimitive);
        }

        [Test]
        public void CanTestPropertyForNull()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } }").ToDynamicFromJson();

            Assert.IsNull((int?)jsonData.OptionalInt);
            Assert.IsNull((string)jsonData.OptionalString);
            Assert.AreEqual("Hello", (string)jsonData.primitive);
        }

        [Test]
        public void CanAddStringToList()
        {
            dynamic jsonData = new BinaryData(new { value = "foo" }).ToDynamicFromJson();

            List<string> list = new();
            list.Add(jsonData.value);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("foo", list[0]);
        }

        [Test]
        public void CanAddIntToList()
        {
            dynamic jsonData = new BinaryData(new { value = 5 }).ToDynamicFromJson();

            List<int> list = new();
            list.Add(jsonData.value);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(5, list[0]);
        }

        [Test]
        public void CanReadIntsAsFloatingPoints()
        {
            var json = new BinaryData("5").ToDynamicFromJson();
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
            var json = new BinaryData("5.5").ToDynamicFromJson();
            dynamic jsonData = json;
            Assert.Throws<InvalidCastException>(() => _ = (int)json);
            Assert.Throws<InvalidCastException>(() => _ = (int)jsonData);
            Assert.Throws<InvalidCastException>(() => _ = (long)json);
            Assert.Throws<InvalidCastException>(() => _ = (long)jsonData);
        }

        [Test]
        public void CanAccessArrayValues()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } , \"array\": [1, 2, 3] }").ToDynamicFromJson();

            Assert.AreEqual(1, (int)jsonData.array[0]);
            Assert.AreEqual(2, (int)jsonData.array[1]);
            Assert.AreEqual(3, (int)jsonData.array[2]);
        }

        [Test]
        public void CanAccessJsonPropertiesWithDotnetIllegalCharacters()
        {
            dynamic jsonData = new BinaryData("{ \"$foo\":\"Hello\" }").ToDynamicFromJson();

            Assert.AreEqual("Hello", (string)jsonData["$foo"]);
        }

        [Test]
        [Ignore("Float behavior is different in JsonDocument depending on runtime version.")]
        public void FloatOverflowThrows()
        {
            var json = new BinaryData("34028234663852885981170418348451692544000").ToDynamicFromJson();

            dynamic jsonData = json;
            Assert.AreEqual(34028234663852885981170418348451692544000d, (double)jsonData);
            Assert.AreEqual(34028234663852885981170418348451692544000d, (double)json);
            Assert.Throws<InvalidCastException>(() => _ = (float)json);
            Assert.Throws<InvalidCastException>(() => _ = (float)jsonData);
        }

        [Test]
        public void IntOverflowThrows()
        {
            var json = new BinaryData("3402823466385288598").ToDynamicFromJson();
            dynamic jsonData = json;
            Assert.Throws<InvalidCastException>(() => _ = (int)json);
            Assert.Throws<InvalidCastException>(() => _ = (int)jsonData);
            Assert.AreEqual(3402823466385288598L, (long)jsonData);
            Assert.AreEqual(3402823466385288598L, (long)json);
            Assert.AreEqual(3402823466385288598D, (double)jsonData);
            Assert.AreEqual(3402823466385288598D, (double)json);
            Assert.AreEqual(3402823466385288598F, (float)jsonData);
            Assert.AreEqual(3402823466385288598F, (float)json);
        }

        [Test]
        [Ignore("Float behavior is different in JsonDocument depending on runtime version.")]
        public void FloatUnderflowThrows()
        {
            var json = new BinaryData("-34028234663852885981170418348451692544000").ToDynamicFromJson();
            dynamic jsonData = json;

            var doc = JsonDocument.Parse("-34028234663852885981170418348451692544000");
            doc.RootElement.GetSingle();

            Assert.Throws<InvalidCastException>(() => _ = (float)json);
            Assert.Throws<InvalidCastException>(() => _ = (float)jsonData);
            Assert.AreEqual(-34028234663852885981170418348451692544000d, (double)jsonData);
            Assert.AreEqual(-34028234663852885981170418348451692544000d, (double)json);
        }

        [Test]
        public void IntUnderflowThrows()
        {
            var json = new BinaryData("-3402823466385288598").ToDynamicFromJson();
            dynamic jsonData = json;
            Assert.Throws<InvalidCastException>(() => _ = (int)json);
            Assert.Throws<InvalidCastException>(() => _ = (int)jsonData);
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
            var json = new BinaryData("[1,3]").ToDynamicFromJson();
            dynamic jsonData = json;
            Assert.Throws<InvalidCastException>(() => _ = (int)json);
            Assert.Throws<InvalidCastException>(() => _ = (int)jsonData);
        }

        [Test]
        [Ignore("Disallowing POCO support in current version.")]
        public void RoundtripObjects()
        {
            var model = new SampleModel("Hello World", 5);
            var roundtripped = (SampleModel)new BinaryData(model).ToDynamicFromJson();

            Assert.AreEqual(model, roundtripped);
        }

        [Test]
        public void CanCastToTypesYouDontOwn()
        {
            var now = DateTimeOffset.Now;

            // "O" is the only format supported by default JsonSerializer:
            // https://learn.microsoft.com/dotnet/standard/datetime/system-text-json-support
            dynamic nowJson = new BinaryData($"{{ \"value\": \"{now.ToString("O", CultureInfo.InvariantCulture)}\" }}").ToDynamicFromJson().value;

            var cast = (DateTimeOffset)nowJson;

            Assert.AreEqual(now, cast);
        }

        [Test]
        [Ignore("Disallowing general IEnumerable support in current version.")]
        public void CanCastToIEnumerableOfT()
        {
            dynamic data = new BinaryData("{ \"array\": [ 1, 2, 3] }").ToDynamicFromJson();

            var enumerable = (IEnumerable<int>)data.array;

            int i = 0;
            foreach (var item in enumerable)
            {
                Assert.AreEqual(++i, item);
            }
        }

        [Test]
        public void EqualsHandlesStringsSpecial()
        {
            dynamic json = new BinaryData("\"test\"").ToDynamicFromJson();

            Assert.IsTrue(json.Equals("test"));
            Assert.IsTrue(json == "test");
        }

        [Test]
        [TestCase("\"test\"", "\"test\"", true)]
        [TestCase("1", "1.0", true)]
        [TestCase("5.5", "5.5", true)]
        [TestCase("true", "true", true)]
        [TestCase("false", "false", true)]
        [TestCase("null", "null", true)]
        [TestCase("\"test\"", "\"wrong\"", false)]
        [TestCase("\"test\"", "1", false)]
        [TestCase("true", "false", false)]
        [TestCase("1.1", "1.2", false)]
        [TestCase("1", "1.2", false)]
        [TestCase("1", "2", false)]
        [TestCase("1", "null", false)]
        [TestCase("1", "{ \"foo\": 1 }", false)]
        public void EqualsPrimitiveValues(string a, string b, bool expected)
        {
            dynamic aJson = new BinaryData(a).ToDynamicFromJson();
            dynamic bJson = new BinaryData(b).ToDynamicFromJson();

            Assert.AreEqual(expected, aJson.Equals(bJson));
            Assert.AreEqual(expected, aJson == bJson);
            Assert.AreEqual(expected, bJson.Equals(aJson));
            Assert.AreEqual(expected, bJson == aJson);
        }

        [Test]
        public void EqualsNull()
        {
            dynamic value = JsonDataTestHelpers.CreateFromJson("""{ "foo": null }""");
            Assert.AreEqual(null, value.foo);
            Assert.IsTrue(value.foo == null);

            string nullString = null;
            Assert.IsTrue(value.foo == nullString);
            Assert.IsTrue(nullString == value.foo);

            int? nullInt = null;
            Assert.IsTrue(value.foo == nullInt);
            Assert.IsTrue(nullInt == value.foo);

            bool? nullBool = null;
            Assert.IsTrue(value.foo == nullBool);
            Assert.IsTrue(nullBool == value.foo);
        }

        [Test]
        public void EqualsForObjectsAndArrays()
        {
            dynamic obj1 = new BinaryData(new { foo = "bar" }).ToDynamicFromJson();
            dynamic obj2 = new BinaryData(new { foo = "bar" }).ToDynamicFromJson();

            dynamic arr1 = new BinaryData(new[] { "bar" }).ToDynamicFromJson();
            dynamic arr2 = new BinaryData(new[] { "bar" }).ToDynamicFromJson();

            // For objects and arrays, Equals provides reference equality.
            Assert.AreEqual(obj1, obj1);
            Assert.AreEqual(arr1, arr1);

            Assert.AreNotEqual(obj1, obj2);
            Assert.AreNotEqual(arr1, arr2);
        }

        [Test]
        public void OperatorEqualsForBool()
        {
            dynamic trueJson = new BinaryData("{ \"value\": true }").ToDynamicFromJson().value;
            dynamic falseJson = new BinaryData("{ \"value\": false }").ToDynamicFromJson().value;

            Assert.IsTrue(trueJson == true);
            Assert.IsTrue(true == trueJson);
            Assert.IsFalse(trueJson != true);
            Assert.IsFalse(true != trueJson);

            Assert.IsFalse(falseJson == true);
            Assert.IsFalse(true == falseJson);
            Assert.IsTrue(falseJson != true);
            Assert.IsTrue(true != falseJson);
        }

        [Test]
        public void OperatorEqualsForInt32()
        {
            dynamic fiveJson = new BinaryData("{ \"value\": 5 }").ToDynamicFromJson().value;
            dynamic sixJson = new BinaryData("{ \"value\": 6 }").ToDynamicFromJson().value;

            Assert.IsTrue(fiveJson == 5);
            Assert.IsTrue(5 == fiveJson);
            Assert.IsFalse(fiveJson != 5);
            Assert.IsFalse(5 != fiveJson);

            Assert.IsFalse(sixJson == 5);
            Assert.IsFalse(5 == sixJson);
            Assert.IsTrue(sixJson != 5);
            Assert.IsTrue(5 != sixJson);
        }

        [Test]
        public void OperatorEqualsForLong()
        {
            long max = long.MaxValue;
            long min = long.MinValue;

            dynamic maxJson = new BinaryData($"{{ \"value\": {max} }}").ToDynamicFromJson().value;
            dynamic minJson = new BinaryData($"{{ \"value\": {min} }}").ToDynamicFromJson().value;

            Assert.IsTrue(maxJson == max);
            Assert.IsTrue(max == maxJson);
            Assert.IsFalse(maxJson != max);
            Assert.IsFalse(max != maxJson);

            Assert.IsFalse(minJson == max);
            Assert.IsFalse(max == minJson);
            Assert.IsTrue(minJson != max);
            Assert.IsTrue(max != minJson);
        }

        [Test]
        public void OperatorEqualsForFloat()
        {
            float half = 0.5f;

            dynamic halfJson = new BinaryData("{ \"value\": 0.5 }").ToDynamicFromJson().value;
            dynamic fourthJson = new BinaryData("{ \"value\": 0.25 }").ToDynamicFromJson().value;

            Assert.IsTrue(halfJson == half);
            Assert.IsTrue(half == halfJson);
            Assert.IsFalse(halfJson != half);
            Assert.IsFalse(half != halfJson);

            Assert.IsFalse(fourthJson == half);
            Assert.IsFalse(half == fourthJson);
            Assert.IsTrue(fourthJson != half);
            Assert.IsTrue(half != fourthJson);
        }
        [Test]
        public void OperatorEqualsForDouble()
        {
            double half = 0.5;

            dynamic halfJson = new BinaryData("{ \"value\": 0.5 }").ToDynamicFromJson().value;
            dynamic fourthJson = new BinaryData("{ \"value\": 0.25 }").ToDynamicFromJson().value;

            Assert.IsTrue(halfJson == half);
            Assert.IsTrue(half == halfJson);
            Assert.IsFalse(halfJson != half);
            Assert.IsFalse(half != halfJson);

            Assert.IsFalse(fourthJson == half);
            Assert.IsFalse(half == fourthJson);
            Assert.IsTrue(fourthJson != half);
            Assert.IsTrue(half != fourthJson);
        }

        [Test]
        public void OperatorEqualsForString()
        {
            dynamic fooJson = new BinaryData("\"foo\"").ToDynamicFromJson();
            dynamic barJson = new BinaryData("\"bar\"").ToDynamicFromJson();

            Assert.IsTrue(fooJson == "foo");
            Assert.IsTrue("foo" == fooJson);
            Assert.IsFalse(fooJson != "foo");
            Assert.IsFalse("foo" != fooJson);

            Assert.IsFalse(barJson == "foo");
            Assert.IsFalse("foo" == barJson);
            Assert.IsTrue(barJson != "foo");
            Assert.IsTrue("foo" != barJson);
        }

        [Test]
        public async Task CanWriteToStream_JsonSerializer()
        {
            // Arrange
            dynamic json = new BinaryData("{ \"Message\": \"Hi!\", \"Number\": 5 }").ToDynamicFromJson();

            // Act
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, json);

            // Assert

            // Deserialize to model type to validate value was correctly written to stream.
            stream.Position = 0;

            var model = (SampleModel)await JsonSerializer.DeserializeAsync(stream, typeof(SampleModel));

            Assert.AreEqual("Hi!", model.Message);
            Assert.AreEqual(5, model.Number);
        }

        [Test]
        public void CallToInternalMethodFails()
        {
            // Arrange
            dynamic json = new BinaryData("{ \"Message\": \"Hi!\", \"Number\": 5 }").ToDynamicFromJson();

            // Act
            using Stream stream = new MemoryStream();
            Assert.Throws<RuntimeBinderException>(() => json.WriteTo(stream));
        }
    }
}
