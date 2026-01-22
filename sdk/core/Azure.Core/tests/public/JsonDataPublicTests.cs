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

            Assert.That((string)jsonData, Is.EqualTo("string"));
        }

        [Test]
        public void DynamicCanConvertToString() => Assert.That(JsonDataTestHelpers.JsonAsType<string>("\"string\""), Is.EqualTo("string"));

        [Test]
        public void DynamicCanConvertToInt() => Assert.That(JsonDataTestHelpers.JsonAsType<int>("5"), Is.EqualTo(5));

        [Test]
        public void DynamicCanConvertToLong() => Assert.That(JsonDataTestHelpers.JsonAsType<long>("5"), Is.EqualTo(5L));

        [Test]
        public void DynamicCanConvertToBool() => Assert.That(JsonDataTestHelpers.JsonAsType<bool>("true"), Is.EqualTo(true));

        [Test]
        public void DynamicCanConvertToNullAsString() => Assert.That(JsonDataTestHelpers.JsonAsType<string>("null"), Is.EqualTo(null));

        [Test]
        public void DynamicCanConvertToNullAsNullableInt() => Assert.That(JsonDataTestHelpers.JsonAsType<int?>("null"), Is.EqualTo(null));

        [Test]
        public void DynamicCanConvertToNullAsNullableLong() => Assert.That(JsonDataTestHelpers.JsonAsType<long?>("null"), Is.EqualTo(null));

        [Test]
        public void DynamicCanConvertToNullAsNullableBool() => Assert.That(JsonDataTestHelpers.JsonAsType<bool?>("null"), Is.EqualTo(null));

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
                        Assert.That((int)dynamicItem, Is.EqualTo(1));
                        break;
                    case 1:
                        Assert.That((string)dynamicItem, Is.EqualTo(null));
                        break;
                    case 2:
                        Assert.That((string)dynamicItem, Is.EqualTo("s"));
                        break;
                    default:
                        Assert.Fail();
                        break;
                }

                i++;
            }
            Assert.That(i, Is.EqualTo(3));
        }

        [Test]
        public void CanForeachOverIntArrayValues()
        {
            dynamic jsonData = new BinaryData("[0, 1, 2, 3]").ToDynamicFromJson();
            int i = 0;
            foreach (int dynamicItem in jsonData)
            {
                Assert.That(dynamicItem, Is.EqualTo(i));

                i++;
            }
            Assert.That(i, Is.EqualTo(4));
        }

        [Test]
        public void DynamicArrayHasLength()
        {
            dynamic jsonData = new BinaryData("[0, 1, 2, 3]").ToDynamicFromJson();
            Assert.That(((int[])jsonData).Length, Is.EqualTo(4));
        }

        [Test]
        public void DynamicArrayForEach()
        {
            dynamic jsonData = new BinaryData("[0, 1, 2, 3]").ToDynamicFromJson();
            int expected = 0;
            foreach (int i in jsonData)
            {
                Assert.That(i, Is.EqualTo(expected++));
            }
        }

        [Test]
        public void CanAccessProperties()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } }").ToDynamicFromJson();

            Assert.That((string)jsonData.primitive, Is.EqualTo("Hello"));
            Assert.That((bool)jsonData.nested.nestedPrimitive, Is.EqualTo(true));
        }

        [Test]
        public void CanTestPropertyForNull()
        {
            dynamic jsonData = new BinaryData("{ \"primitive\":\"Hello\", \"nested\": { \"nestedPrimitive\":true } }").ToDynamicFromJson();

            Assert.That((int?)jsonData.OptionalInt, Is.Null);
            Assert.That((string)jsonData.OptionalString, Is.Null);
            Assert.That((string)jsonData.primitive, Is.EqualTo("Hello"));
        }

        [Test]
        public void CanAddStringToList()
        {
            dynamic jsonData = new BinaryData(new { value = "foo" }).ToDynamicFromJson();

            List<string> list = new();
            list.Add(jsonData.value);

            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0], Is.EqualTo("foo"));
        }

        [Test]
        public void CanAddIntToList()
        {
            dynamic jsonData = new BinaryData(new { value = 5 }).ToDynamicFromJson();

            List<int> list = new();
            list.Add(jsonData.value);

            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0], Is.EqualTo(5));
        }

        [Test]
        public void CanReadIntsAsFloatingPoints()
        {
            var json = new BinaryData("5").ToDynamicFromJson();
            dynamic jsonData = json;

            Assert.That((float)jsonData, Is.EqualTo(5));
            Assert.That((double)jsonData, Is.EqualTo(5));
            Assert.That((int)jsonData, Is.EqualTo(5));
            Assert.That((long)jsonData, Is.EqualTo(5));
            Assert.That((float)json, Is.EqualTo(5));
            Assert.That((double)json, Is.EqualTo(5));
            Assert.That((int)json, Is.EqualTo(5));
            Assert.That((long)json, Is.EqualTo(5));
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

            Assert.That((int)jsonData.array[0], Is.EqualTo(1));
            Assert.That((int)jsonData.array[1], Is.EqualTo(2));
            Assert.That((int)jsonData.array[2], Is.EqualTo(3));
        }

        [Test]
        public void CanAccessJsonPropertiesWithDotnetIllegalCharacters()
        {
            dynamic jsonData = new BinaryData("{ \"$foo\":\"Hello\" }").ToDynamicFromJson();

            Assert.That((string)jsonData["$foo"], Is.EqualTo("Hello"));
        }

        [Test]
        [Ignore("Float behavior is different in JsonDocument depending on runtime version.")]
        public void FloatOverflowThrows()
        {
            var json = new BinaryData("34028234663852885981170418348451692544000").ToDynamicFromJson();

            dynamic jsonData = json;
            Assert.That((double)jsonData, Is.EqualTo(34028234663852885981170418348451692544000d));
            Assert.That((double)json, Is.EqualTo(34028234663852885981170418348451692544000d));
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
            Assert.That((long)jsonData, Is.EqualTo(3402823466385288598L));
            Assert.That((long)json, Is.EqualTo(3402823466385288598L));
            Assert.That((double)jsonData, Is.EqualTo(3402823466385288598D));
            Assert.That((double)json, Is.EqualTo(3402823466385288598D));
            Assert.That((float)jsonData, Is.EqualTo(3402823466385288598F));
            Assert.That((float)json, Is.EqualTo(3402823466385288598F));
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
            Assert.That((double)jsonData, Is.EqualTo(-34028234663852885981170418348451692544000d));
            Assert.That((double)json, Is.EqualTo(-34028234663852885981170418348451692544000d));
        }

        [Test]
        public void IntUnderflowThrows()
        {
            var json = new BinaryData("-3402823466385288598").ToDynamicFromJson();
            dynamic jsonData = json;
            Assert.Throws<InvalidCastException>(() => _ = (int)json);
            Assert.Throws<InvalidCastException>(() => _ = (int)jsonData);
            Assert.That((long)jsonData, Is.EqualTo(-3402823466385288598L));
            Assert.That((long)json, Is.EqualTo(-3402823466385288598L));
            Assert.That((double)jsonData, Is.EqualTo(-3402823466385288598D));
            Assert.That((double)json, Is.EqualTo(-3402823466385288598D));
            Assert.That((float)jsonData, Is.EqualTo(-3402823466385288598F));
            Assert.That((float)json, Is.EqualTo(-3402823466385288598F));
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

            Assert.That(roundtripped, Is.EqualTo(model));
        }

        [Test]
        public void CanCastToTypesYouDontOwn()
        {
            var now = DateTimeOffset.Now;

            // "O" is the only format supported by default JsonSerializer:
            // https://learn.microsoft.com/dotnet/standard/datetime/system-text-json-support
            dynamic nowJson = new BinaryData($"{{ \"value\": \"{now.ToString("O", CultureInfo.InvariantCulture)}\" }}").ToDynamicFromJson().value;

            var cast = (DateTimeOffset)nowJson;

            Assert.That(cast, Is.EqualTo(now));
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
                Assert.That(item, Is.EqualTo(++i));
            }
        }

        [Test]
        public void EqualsHandlesStringsSpecial()
        {
            dynamic json = new BinaryData("\"test\"").ToDynamicFromJson();

            Assert.That(json.Equals("test"), Is.True);
            Assert.That(json == "test", Is.True);
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

            Assert.That(aJson.Equals(bJson), Is.EqualTo(expected));
            Assert.That(aJson == bJson, Is.EqualTo(expected));
            Assert.That(bJson.Equals(aJson), Is.EqualTo(expected));
            Assert.That(bJson == aJson, Is.EqualTo(expected));
        }

        [Test]
        public void EqualsNull()
        {
            dynamic value = JsonDataTestHelpers.CreateFromJson("""{ "foo": null }""");
            Assert.That(value.foo, Is.EqualTo(null));
            Assert.That(value.foo == null, Is.True);

            string nullString = null;
            Assert.That(value.foo == nullString, Is.True);
            Assert.That(nullString == value.foo, Is.True);

            int? nullInt = null;
            Assert.That(value.foo == nullInt, Is.True);
            Assert.That(nullInt == value.foo, Is.True);

            bool? nullBool = null;
            Assert.That(value.foo == nullBool, Is.True);
            Assert.That(nullBool == value.foo, Is.True);
        }

        [Test]
        public void EqualsForObjectsAndArrays()
        {
            dynamic obj1 = new BinaryData(new { foo = "bar" }).ToDynamicFromJson();
            dynamic obj2 = new BinaryData(new { foo = "bar" }).ToDynamicFromJson();

            dynamic arr1 = new BinaryData(new[] { "bar" }).ToDynamicFromJson();
            dynamic arr2 = new BinaryData(new[] { "bar" }).ToDynamicFromJson();

            // For objects and arrays, Equals provides reference equality.
            Assert.That(obj1, Is.EqualTo(obj1));
            Assert.That(arr1, Is.EqualTo(arr1));

            Assert.That(obj1, Is.Not.EqualTo(obj2));
            Assert.That(arr1, Is.Not.EqualTo(arr2));
        }

        [Test]
        public void OperatorEqualsForBool()
        {
            dynamic trueJson = new BinaryData("{ \"value\": true }").ToDynamicFromJson().value;
            dynamic falseJson = new BinaryData("{ \"value\": false }").ToDynamicFromJson().value;

            Assert.That(trueJson == true, Is.True);
            Assert.That(true == trueJson, Is.True);
            Assert.That(trueJson != true, Is.False);
            Assert.That(true != trueJson, Is.False);

            Assert.That(falseJson == true, Is.False);
            Assert.That(true == falseJson, Is.False);
            Assert.That(falseJson != true, Is.True);
            Assert.That(true != falseJson, Is.True);
        }

        [Test]
        public void OperatorEqualsForInt32()
        {
            dynamic fiveJson = new BinaryData("{ \"value\": 5 }").ToDynamicFromJson().value;
            dynamic sixJson = new BinaryData("{ \"value\": 6 }").ToDynamicFromJson().value;

            Assert.That(fiveJson == 5, Is.True);
            Assert.That(5 == fiveJson, Is.True);
            Assert.That(fiveJson != 5, Is.False);
            Assert.That(5 != fiveJson, Is.False);

            Assert.That(sixJson == 5, Is.False);
            Assert.That(5 == sixJson, Is.False);
            Assert.That(sixJson != 5, Is.True);
            Assert.That(5 != sixJson, Is.True);
        }

        [Test]
        public void OperatorEqualsForLong()
        {
            long max = long.MaxValue;
            long min = long.MinValue;

            dynamic maxJson = new BinaryData($"{{ \"value\": {max} }}").ToDynamicFromJson().value;
            dynamic minJson = new BinaryData($"{{ \"value\": {min} }}").ToDynamicFromJson().value;

            Assert.That(maxJson == max, Is.True);
            Assert.That(max == maxJson, Is.True);
            Assert.That(maxJson != max, Is.False);
            Assert.That(max != maxJson, Is.False);

            Assert.That(minJson == max, Is.False);
            Assert.That(max == minJson, Is.False);
            Assert.That(minJson != max, Is.True);
            Assert.That(max != minJson, Is.True);
        }

        [Test]
        public void OperatorEqualsForFloat()
        {
            float half = 0.5f;

            dynamic halfJson = new BinaryData("{ \"value\": 0.5 }").ToDynamicFromJson().value;
            dynamic fourthJson = new BinaryData("{ \"value\": 0.25 }").ToDynamicFromJson().value;

            Assert.That(halfJson == half, Is.True);
            Assert.That(half == halfJson, Is.True);
            Assert.That(halfJson != half, Is.False);
            Assert.That(half != halfJson, Is.False);

            Assert.That(fourthJson == half, Is.False);
            Assert.That(half == fourthJson, Is.False);
            Assert.That(fourthJson != half, Is.True);
            Assert.That(half != fourthJson, Is.True);
        }
        [Test]
        public void OperatorEqualsForDouble()
        {
            double half = 0.5;

            dynamic halfJson = new BinaryData("{ \"value\": 0.5 }").ToDynamicFromJson().value;
            dynamic fourthJson = new BinaryData("{ \"value\": 0.25 }").ToDynamicFromJson().value;

            Assert.That(halfJson == half, Is.True);
            Assert.That(half == halfJson, Is.True);
            Assert.That(halfJson != half, Is.False);
            Assert.That(half != halfJson, Is.False);

            Assert.That(fourthJson == half, Is.False);
            Assert.That(half == fourthJson, Is.False);
            Assert.That(fourthJson != half, Is.True);
            Assert.That(half != fourthJson, Is.True);
        }

        [Test]
        public void OperatorEqualsForString()
        {
            dynamic fooJson = new BinaryData("\"foo\"").ToDynamicFromJson();
            dynamic barJson = new BinaryData("\"bar\"").ToDynamicFromJson();

            Assert.That(fooJson == "foo", Is.True);
            Assert.That("foo" == fooJson, Is.True);
            Assert.That(fooJson != "foo", Is.False);
            Assert.That("foo" != fooJson, Is.False);

            Assert.That(barJson == "foo", Is.False);
            Assert.That("foo" == barJson, Is.False);
            Assert.That(barJson != "foo", Is.True);
            Assert.That("foo" != barJson, Is.True);
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

            Assert.That(model.Message, Is.EqualTo("Hi!"));
            Assert.That(model.Number, Is.EqualTo(5));
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
