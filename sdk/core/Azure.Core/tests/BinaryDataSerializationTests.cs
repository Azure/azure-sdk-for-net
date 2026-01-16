// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class BinaryDataSerializationTests
    {
        [Test]
        public void DeserializeModelWithDictionaryOfBinaryData()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringDictOfBinaryData.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryDataInDictionary.DeserializeModelWithBinaryDataInDictionary(document.RootElement);

            Assert.That(data.A, Is.EqualTo("a.value"));
            Assert.That(data.Details["strValue"].ToObjectFromJson<string>(), Is.EqualTo("1"));
            Assert.That(data.Details["strValue"].ToObjectFromJson() is string, Is.True);
            Assert.That(data.Details["intValue"].ToObjectFromJson<int>(), Is.EqualTo(1));
            Assert.That(data.Details["intValue"].ToObjectFromJson() is int, Is.True);
            Assert.That(data.Details["doubleValue"].ToObjectFromJson<double>(), Is.EqualTo(1.1));
            Assert.That(data.Details["doubleValue"].ToObjectFromJson() is double, Is.True);

            var toObjectWithT = data.Details["innerProperties"].ToObjectFromJson<Dictionary<string, object>>();
            var jsonElementObject = data.Details["innerProperties"].ToObjectFromJson<object>();
            Assert.That(jsonElementObject is JsonElement, Is.True);
            var jsonDictionary = data.Details["innerProperties"].ToObjectFromJson();
            Assert.That(jsonDictionary is Dictionary<string, object>, Is.True);
            Assert.That(toObjectWithT["strValue"] is JsonElement, Is.True);

            var dict = data.Details["innerProperties"].ToObjectFromJson() as Dictionary<string, object>;
            Assert.That((string)dict["strValue"], Is.EqualTo("2"));
            Assert.That((int)dict["intValue"], Is.EqualTo(2));
            Assert.That((double)dict["doubleValue"], Is.EqualTo(2.2));
        }

        [Test]
        public void CanConvertInt()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringInt.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.That(data.A, Is.EqualTo("a.value"));
            Assert.That(data.Properties.ToObjectFromJson<int>(), Is.EqualTo(1));

            var roundTripString = GetSerializedString(data);
            Assert.That(roundTripString, Is.EqualTo(File.ReadAllText(GetFileName("JsonFormattedStringInt.json")).TrimEnd()));
        }

        [Test]
        public void CanConvertDouble()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringDouble.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.That(data.A, Is.EqualTo("a.value"));
            Assert.That(data.Properties.ToObjectFromJson<double>(), Is.EqualTo(1.5));

            var roundTripString = GetSerializedString(data);
            Assert.That(roundTripString, Is.EqualTo(File.ReadAllText(GetFileName("JsonFormattedStringDouble.json")).TrimEnd()));
        }

        [Test]
        public void CanConvertString()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringString.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.That(data.A, Is.EqualTo("a.value"));
            Assert.That(data.Properties.ToObjectFromJson<string>(), Is.EqualTo("1"));

            var roundTripString = GetSerializedString(data);
            Assert.That(roundTripString, Is.EqualTo(File.ReadAllText(GetFileName("JsonFormattedStringString.json")).TrimEnd()));
        }

        [Test]
        public void CanConvertNull()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringNull.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.That(data.A, Is.EqualTo("a.value"));
            Assert.That(data.Properties.ToObjectFromJson<string>(), Is.EqualTo(null));

            var roundTripString = GetSerializedString(data);
            Assert.That(roundTripString, Is.EqualTo(File.ReadAllText(GetFileName("JsonFormattedStringNull.json")).TrimEnd()));
        }

        [Test]
        public void CanConvertTrue()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringTrue.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.That(data.A, Is.EqualTo("a.value"));
            Assert.That(data.Properties.ToObjectFromJson<bool>(), Is.EqualTo(true));

            var roundTripString = GetSerializedString(data);
            Assert.That(roundTripString, Is.EqualTo(File.ReadAllText(GetFileName("JsonFormattedStringTrue.json")).TrimEnd()));
        }

        [Test]
        public void CanConvertFalse()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringFalse.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.That(data.A, Is.EqualTo("a.value"));
            Assert.That(data.Properties.ToObjectFromJson<bool>(), Is.EqualTo(false));

            var roundTripString = GetSerializedString(data);
            Assert.That(roundTripString, Is.EqualTo(File.ReadAllText(GetFileName("JsonFormattedStringFalse.json")).TrimEnd()));
        }

        [Test]
        public void CanConvertDifferentValueTypes()
        {
            var expected = File.ReadAllText(GetFileName("PropertiesWithDifferentValueTypes.json")).TrimEnd();
            var model = BinaryData.FromString(expected);

            var properties = model.ToObjectFromJson() as Dictionary<string, object>;
            Assert.That(properties["stringValue"].GetType(), Is.EqualTo(typeof(string)));
            Assert.That(properties["dateTimeValue"].GetType(), Is.EqualTo(typeof(string)));
            Assert.That(properties["intValue"].GetType(), Is.EqualTo(typeof(int)));
            Assert.That(properties["longValue"].GetType(), Is.EqualTo(typeof(long)));
            Assert.That(properties["doubleValue"].GetType(), Is.EqualTo(typeof(double)));
            Assert.That(properties["trueValue"].GetType(), Is.EqualTo(typeof(bool)));
            Assert.That(properties["falseValue"].GetType(), Is.EqualTo(typeof(bool)));
            Assert.That(properties["nullValue"], Is.Null);

            Assert.That(GetSerializedString(model), Is.EqualTo(expected));
        }

        [Test]
        public void CanConvertArrays()
        {
            var expected = File.ReadAllText(GetFileName("PropertiesWithArrays.json")).TrimEnd();
            var model = BinaryData.FromString(expected);

            var properties = model.ToObjectFromJson() as Dictionary<string, object>;
            Assert.That(AllValuesAreType(typeof(string), properties["stringArray"]), Is.True);
            Assert.That(AllValuesAreType(typeof(string), properties["dateTimeArray"]), Is.True);
            Assert.That(AllValuesAreType(typeof(int), properties["intArray"]), Is.True);
            Assert.That(AllValuesAreType(typeof(long), properties["longArray"]), Is.True);
            Assert.That(AllValuesAreType(typeof(double), properties["doubleArray"]), Is.True);
            Assert.That(AllValuesAreType(typeof(bool), properties["boolArray"]), Is.True);
            foreach (var item in properties["nullArray"] as object[])
            {
                Assert.That(item, Is.Null);
            }
            var mixList = properties["mixedNullArray"] as object[];
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    Assert.That(mixList[i], Is.Null);
                }
                else
                {
                    Assert.That(mixList[i], Is.Not.Null);
                }
            }
            Assert.That(GetSerializedString(model), Is.EqualTo(expected));
        }

        [Test]
        public void CanConvertArrayOfObjects()
        {
            var expected = File.ReadAllText(GetFileName("PropertiesWithArraysOfObjects.json")).TrimEnd();
            var model = BinaryData.FromString(expected);
            var properties = model.ToObjectFromJson() as Dictionary<string, object>;
            var objArray = properties["objectArray"] as object[];
            for (int i = 0; i < 3; i++)
            {
                var obj = objArray[i] as Dictionary<string, object>;
                Assert.That(obj, Is.Not.Null);
                Assert.That(obj["intValue"], Is.EqualTo(i));
                var innerObj = obj["objectValue"] as Dictionary<string, object>;
                Assert.That(innerObj, Is.Not.Null);
                Assert.That(innerObj["stringValue"], Is.EqualTo(i.ToString()));
            }
            Assert.That(GetSerializedString(model), Is.EqualTo(expected));
        }

        [Test]
        public void CanConvertArrayOfArrays()
        {
            var expected = File.ReadAllText(GetFileName("PropertiesWithArraysOfArrays.json")).TrimEnd();
            var model = BinaryData.FromString(expected);
            var properties = model.ToObjectFromJson() as Dictionary<string, object>;
            var arrayArray = properties["arrayArray"] as object[];
            Assert.That(arrayArray, Is.Not.Null);
            for (int i = 0; i < 2; i++)
            {
                var array = arrayArray[i] as object[];
                Assert.That(array, Is.Not.Null);
                foreach (var item in array)
                {
                    Assert.That(item, Is.EqualTo(i));
                }
            }
            Assert.That(GetSerializedString(model), Is.EqualTo(expected));
        }

        private bool AllValuesAreType(Type type, object list)
        {
            foreach (var item in list as object[])
            {
                if (!item.GetType().Equals(type))
                    return false;
            }
            return true;
        }

        [Test]
        public void DeserializeJsonFormattedStringWithObject()
        {
            using (var fs = new FileStream(GetFileName("JsonFormattedString.json"), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using var document = JsonDocument.Parse(fs);
                var data = ModelWithObject.DeserializeModelWithObject(document.RootElement);
                Assert.That(data.A, Is.EqualTo("a.value"));

                var properties = data.Properties as Dictionary<string, object>;
                Assert.That(properties["a"], Is.EqualTo("properties.a.value"));
                var innerProperties = properties["innerProperties"] as IDictionary<string, object>;
                Assert.That(innerProperties["a"], Is.EqualTo("properties.innerProperties.a.value"));
            }
        }

        [Test]
        public void DeserializeJsonFormattedStringWithBinaryData()
        {
            using (var fs = new FileStream(GetFileName("JsonFormattedString.json"), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using var document = JsonDocument.Parse(fs);
                var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);
                Assert.That(data.A, Is.EqualTo("a.value"));

                var properties = data.Properties.ToObjectFromJson() as Dictionary<string, object>;
                Assert.That(properties["a"], Is.EqualTo("properties.a.value"));
                var innerProperties = properties["innerProperties"] as IDictionary<string, object>;
                Assert.That(innerProperties["a"], Is.EqualTo("properties.innerProperties.a.value"));
            }
        }

        [Test]
        public void SerailizeUsingDictStringObject()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedString.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            var properties = new Dictionary<string, object>();
            var innerProperties = new Dictionary<string, object>();
            properties.Add("a", "properties.a.value");
            innerProperties.Add("a", "properties.innerProperties.a.value");
            properties.Add("innerProperties", innerProperties);
            payload.Properties = BinaryData.FromObjectAsJson(properties);

            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SerailizeUsingJsonFormattedString()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedString.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromString(File.ReadAllText(GetFileName("Properties.json")).TrimEnd());

            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SerailizeUsingJsonFormattedStringForDictOfBinaryData()
        {
#if NET462
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringDictOfBinaryDataNet461.json")).TrimEnd();
#else
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringDictOfBinaryData.json")).TrimEnd();
#endif

            var payload = new ModelWithBinaryDataInDictionary { A = "a.value" };

            var details = new Dictionary<string, BinaryData>();
            details["strValue"] = BinaryData.FromObjectAsJson("1");
            details["intValue"] = BinaryData.FromObjectAsJson(1);
            details["doubleValue"] = BinaryData.FromObjectAsJson(1.1);

            var innerProperties = new Dictionary<string, object>();
            innerProperties["strValue"] = "2";
            innerProperties["intValue"] = 2;
            innerProperties["doubleValue"] = 2.2;

            details["innerProperties"] = BinaryData.FromObjectAsJson(innerProperties);
            payload.Details = details;

            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SerailizeUsingStream()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedString.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            using var fs = File.Open(GetFileName("Properties.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            payload.Properties = BinaryData.FromStream(fs);

            string actual = GetSerializedString(payload);
            //for some reason in dotnet 6 only there is a random new line after the binarydata object
            //to make this work in all frameworks we will just do a comparison ignoring whitespace
            Assert.That(CompareIgnoreWhitespace(expected, actual), Is.True);
        }

        private bool? CompareIgnoreWhitespace(string expected, string actual)
        {
            int i = 0;
            int j = 0;
            while (i < expected.Length && j < actual.Length)
            {
                if (char.IsWhiteSpace(expected[i]))
                {
                    i++;
                    continue;
                }
                if (char.IsWhiteSpace(actual[j]))
                {
                    j++;
                    continue;
                }
                if (expected[i] != actual[j])
                    return false;
                i++;
                j++;
            }
            return i == expected.Length && j == actual.Length;
        }

        [Test]
        public void SerailizeUsingAnonObject()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedString.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            var properties = new
            {
                a = "properties.a.value",
                innerProperties = new
                {
                    a = "properties.innerProperties.a.value"
                }
            };
            payload.Properties = BinaryData.FromObjectAsJson(properties);

            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingString()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringString.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson("1");
            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));

            payload.Properties = BinaryData.FromString("\"1\"");
            actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingTrue()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringTrue.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson(true);

            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingFalse()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringFalse.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson(false);

            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingInt()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringInt.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson(1);

            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingDouble()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringDouble.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson(1.5);

            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingNull()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringNull.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson<object>(null);

            string actual = GetSerializedString(payload);
            Assert.That(actual, Is.EqualTo(expected));
        }

        private static string GetSerializedString(BinaryData payload)
        {
            using var ms = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(ms);
#if NET6_0_OR_GREATER
            writer.WriteRawValue(payload);
#else
            JsonSerializer.Serialize(writer, JsonDocument.Parse(payload.ToString()).RootElement);
#endif
            writer.Flush();

            ms.Position = 0;
            using var sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }

        private static string GetSerializedString(IUtf8JsonSerializable payload)
        {
            using var ms = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(ms);
            payload.Write(writer);
            writer.Flush();

            ms.Position = 0;
            using var sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }

        [Test]
        public async Task CanCreateBinaryDataFromCustomType()
        {
            var payload = new Model { A = "value", B = 5, C = 3 };
            var serializer = new JsonObjectSerializer();

            await AssertData(await serializer.SerializeAsync(payload));
            await AssertData(serializer.Serialize(payload));
            await AssertData(await serializer.SerializeAsync(payload, typeof(Model)));
            await AssertData(serializer.Serialize(payload, typeof(Model)));
            await AssertData(await serializer.SerializeAsync(payload, null));
            await AssertData(serializer.Serialize(payload, null));

            async Task AssertData(BinaryData data)
            {
                Assert.That(data.ToObject<Model>(serializer).A, Is.EqualTo(payload.A));
                Assert.That(data.ToObject<Model>(serializer).B, Is.EqualTo(payload.B));
                Assert.That(data.ToObject<Model>(serializer).C, Is.EqualTo(0));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).A, Is.EqualTo(payload.A));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).B, Is.EqualTo(payload.B));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).C, Is.EqualTo(0));
            }
        }

        [Test]
        public async Task CanCreateBinaryDataFromCustomTypePassingBaseType()
        {
            var payload = new ExtendedModel() { A = "value", B = 5, C = 3, F = 5 };
            var serializer = new JsonObjectSerializer();

            await AssertData(await serializer.SerializeAsync(payload, typeof(Model)));
            await AssertData(serializer.Serialize(payload, typeof(Model)));

            async Task AssertData(BinaryData data)
            {
                Assert.That(data.ToObject<Model>(serializer).A, Is.EqualTo(payload.A));
                Assert.That(data.ToObject<Model>(serializer).B, Is.EqualTo(payload.B));
                Assert.That(data.ToObject<Model>(serializer).C, Is.EqualTo(0));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).A, Is.EqualTo(payload.A));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).B, Is.EqualTo(payload.B));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).C, Is.EqualTo(0));
                Assert.That((await data.ToObjectAsync<ExtendedModel>(serializer)).F, Is.EqualTo(0));
            }
        }

        [Test]
        public async Task CanCreateBinaryDataFromNullObject()
        {
            Model model = null;
            var serializer = new JsonObjectSerializer();

            await AssertData(await serializer.SerializeAsync(model));
            await AssertData(serializer.Serialize(model));
            await AssertData(await serializer.SerializeAsync(model, typeof(Model)));
            await AssertData(serializer.Serialize(model, typeof(Model)));
            await AssertData(await serializer.SerializeAsync(model, null));
            await AssertData(serializer.Serialize(model, null));

            async Task AssertData(BinaryData data)
            {
                Assert.That(data.ToObject<Model>(serializer), Is.Null);
                Assert.That(await data.ToObjectAsync<Model>(serializer), Is.Null);
            }
        }

        [Test]
        public async Task CustomSerializerCanCreateBinaryDataFromCustomType()
        {
            var payload = new Model { A = "value", B = 5, C = 3 };
            // testing the base ObjectSerializer implementation
            var serializer = new CustomSerializer();

            await AssertData(await serializer.SerializeAsync(payload));
            await AssertData(serializer.Serialize(payload));
            await AssertData(await serializer.SerializeAsync(payload, typeof(Model)));
            await AssertData(serializer.Serialize(payload, typeof(Model)));
            await AssertData(await serializer.SerializeAsync(payload, null));
            await AssertData(serializer.Serialize(payload, null));

            async Task AssertData(BinaryData data)
            {
                Assert.That(data.ToObject<Model>(serializer).A, Is.EqualTo(payload.A));
                Assert.That(data.ToObject<Model>(serializer).B, Is.EqualTo(payload.B));
                Assert.That(data.ToObject<Model>(serializer).C, Is.EqualTo(0));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).A, Is.EqualTo(payload.A));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).B, Is.EqualTo(payload.B));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).C, Is.EqualTo(0));
            }
        }

        [Test]
        public async Task CustomSerializerCanCreateBinaryDataFromCustomTypePassingBaseType()
        {
            var payload = new ExtendedModel() { A = "value", B = 5, C = 3, F = 5 };
            // testing the base ObjectSerializer implementation
            var serializer = new CustomSerializer();

            await AssertData(await serializer.SerializeAsync(payload, typeof(Model)));
            await AssertData(serializer.Serialize(payload, typeof(Model)));

            async Task AssertData(BinaryData data)
            {
                Assert.That(data.ToObject<Model>(serializer).A, Is.EqualTo(payload.A));
                Assert.That(data.ToObject<Model>(serializer).B, Is.EqualTo(payload.B));
                Assert.That(data.ToObject<Model>(serializer).C, Is.EqualTo(0));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).A, Is.EqualTo(payload.A));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).B, Is.EqualTo(payload.B));
                Assert.That((await data.ToObjectAsync<Model>(serializer)).C, Is.EqualTo(0));
                Assert.That((await data.ToObjectAsync<ExtendedModel>(serializer)).F, Is.EqualTo(0));
            }
        }

        [Test]
        public async Task CustomSerializerCanCreateBinaryDataFromNullObject()
        {
            Model model = null;
            // testing the base ObjectSerializer implementation
            var serializer = new CustomSerializer();

            await AssertData(await serializer.SerializeAsync(model));
            await AssertData(serializer.Serialize(model));
            await AssertData(await serializer.SerializeAsync(model, typeof(Model)));
            await AssertData(serializer.Serialize(model, typeof(Model)));
            await AssertData(await serializer.SerializeAsync(model, null));
            await AssertData(serializer.Serialize(model, null));

            async Task AssertData(BinaryData data)
            {
                Assert.That(data.ToObject<Model>(serializer), Is.Null);
                Assert.That(await data.ToObjectAsync<Model>(serializer), Is.Null);
            }
        }

        public class Model
        {
            public string A { get; set; }

            public int B { get; set; }

            [JsonIgnore]
            public int C { get; set; }
        }

        public class ExtendedModel : Model
        {
            public ExtendedModel()
            {
            }

            internal ExtendedModel(int readOnlyD)
            {
                ReadOnlyD = readOnlyD;
            }

            [JsonPropertyName("d")]
            public int ReadOnlyD { get; }

            internal int IgnoredE { get; set; }

            public int F { get; set; }
        }

        public class CustomSerializer : ObjectSerializer
        {
            private static JsonObjectSerializer s_serializer = new JsonObjectSerializer();

            public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
                => s_serializer.Deserialize(stream, returnType, cancellationToken);

            public async override ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
                => await s_serializer.DeserializeAsync(stream, returnType, cancellationToken).ConfigureAwait(false);

            public override void Serialize(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
                => s_serializer.Serialize(stream, value, inputType, cancellationToken);

            public async override ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
                => await s_serializer.SerializeAsync(stream, value, inputType, cancellationToken).ConfigureAwait(false);
        }

        private string GetFileName(string file)
        {
            return Path.Combine(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", "BinaryData", file));
        }
    }
}
