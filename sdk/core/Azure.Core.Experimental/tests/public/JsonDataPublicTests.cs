// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core.Dynamic;
using System.Text.Json;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

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
        public void CanTestPropertyForNull()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } }").ToDynamic();

            Assert.IsNull(jsonData.OptionalInt);
            Assert.IsNull(jsonData.OptionalString);
            Assert.AreEqual("Hello", (string)jsonData.primitive);
        }

        [Test]
        public void CanAddStringToList()
        {
            dynamic jsonData = new BinaryData(new { value = "foo" }).ToDynamic();

            List<string> list = new();
            list.Add(jsonData.value);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("foo", list[0]);
        }

        [Test]
        public void CanAddIntToList()
        {
            dynamic jsonData = new BinaryData(new { value = 5 }).ToDynamic();

            List<int> list = new();
            list.Add(jsonData.value);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(5, list[0]);
        }

        [Test]
        [Ignore(reason: "TODO: Feature to be added in later version.")]
        public void GetMemberIsCaseInsensitive()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } }").ToDynamic();

            Assert.AreEqual("Hello", (string)jsonData.Primitive);
            Assert.AreEqual(true, (bool)jsonData.Nested.NestedPrimitive);
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
        public void CanAccessArrayValues()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } , \"array\": [1, 2, 3] }").ToDynamic();

            Assert.AreEqual(1, (int)jsonData.array[0]);
            Assert.AreEqual(2, (int)jsonData.array[1]);
            Assert.AreEqual(3, (int)jsonData.array[2]);
        }

        [Test]
        public void CanAccessJsonPropertiesWithDotnetIllegalCharacters()
        {
            dynamic jsonData = new BinaryData("{ \"$foo\":\"Hello\" }").ToDynamic();

            Assert.AreEqual("Hello", (string)jsonData["$foo"]);
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
        public void OperatorEqualsForBool()
        {
            dynamic trueJson = new BinaryData("{ \"value\": true }").ToDynamic().value;
            dynamic falseJson = new BinaryData("{ \"value\": false }").ToDynamic().value;

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
            dynamic fiveJson = new BinaryData("{ \"value\": 5 }").ToDynamic().value;
            dynamic sixJson = new BinaryData("{ \"value\": 6 }").ToDynamic().value;

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

            dynamic maxJson = new BinaryData($"{{ \"value\": { max } }}").ToDynamic().value;
            dynamic minJson = new BinaryData($"{{ \"value\": { min } }}").ToDynamic().value;

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

            dynamic halfJson = new BinaryData("{ \"value\": 0.5 }").ToDynamic().value;
            dynamic fourthJson = new BinaryData("{ \"value\": 0.25 }").ToDynamic().value;

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

            dynamic halfJson = new BinaryData("{ \"value\": 0.5 }").ToDynamic().value;
            dynamic fourthJson = new BinaryData("{ \"value\": 0.25 }").ToDynamic().value;

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

        [Test]
        [Ignore(reason: "TODO: Decide whether to require cast for this case or not.")]
        public void EqualsForStringNUnit()
        {
            dynamic foo = new BinaryData("{ \"value\": \"foo\" }").ToDynamic();
            var value = foo.Value;

            Assert.AreEqual(value, "foo");
            Assert.AreEqual("foo", value);

            Assert.That(value, Is.EqualTo("foo"));
            Assert.That("foo", Is.EqualTo(value));
        }

        [Test]
        public async Task CanWriteToStream()
        {
            // Arrange
            dynamic json = new BinaryData("{ \"Message\": \"Hi!\", \"Number\": 5 }").ToDynamic();

            // Act
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                DynamicData.WriteTo(writer, json);
            }

            // Assert

            // Deserialize to model type to validate value was correctly written to stream.
            stream.Position = 0;

            var model = (SampleModel)await JsonSerializer.DeserializeAsync(stream, typeof(SampleModel));

            Assert.AreEqual("Hi!", model.Message);
            Assert.AreEqual(5, model.Number);
        }

        [Test]
        public async Task CanWriteToStream_JsonSerializer()
        {
            // Arrange
            dynamic json = new BinaryData("{ \"Message\": \"Hi!\", \"Number\": 5 }").ToDynamic();

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
    }
}
