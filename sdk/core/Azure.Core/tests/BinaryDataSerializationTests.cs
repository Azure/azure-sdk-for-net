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

            Assert.AreEqual("a.value", data.A);
            Assert.AreEqual("1", data.Details["strValue"].ToObjectFromJson<string>());
            Assert.IsTrue(data.Details["strValue"].ToObjectFromJson() is string);
            Assert.AreEqual(1, data.Details["intValue"].ToObjectFromJson<int>());
            Assert.IsTrue(data.Details["intValue"].ToObjectFromJson() is int);
            Assert.AreEqual(1.1, data.Details["doubleValue"].ToObjectFromJson<double>());
            Assert.IsTrue(data.Details["doubleValue"].ToObjectFromJson() is double);

            var toObjectWithT = data.Details["innerProperties"].ToObjectFromJson<Dictionary<string, object>>();
            var jsonElementObject = data.Details["innerProperties"].ToObjectFromJson<object>();
            Assert.IsTrue(jsonElementObject is JsonElement);
            var jsonDictionary = data.Details["innerProperties"].ToObjectFromJson();
            Assert.IsTrue(jsonDictionary is Dictionary<string, object>);
            Assert.IsTrue(toObjectWithT["strValue"] is JsonElement);

            var dict = data.Details["innerProperties"].ToObjectFromJson() as Dictionary<string, object>;
            Assert.AreEqual("2", (string)dict["strValue"]);
            Assert.AreEqual(2, (int)dict["intValue"]);
            Assert.AreEqual(2.2, (double)dict["doubleValue"]);
        }

        [Test]
        public void CanConvertInt()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringInt.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.AreEqual("a.value", data.A);
            Assert.AreEqual(1, data.Properties.ToObjectFromJson<int>());

            var roundTripString = GetSerializedString(data);
            Assert.AreEqual(File.ReadAllText(GetFileName("JsonFormattedStringInt.json")).TrimEnd(), roundTripString);
        }

        [Test]
        public void CanConvertDouble()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringDouble.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.AreEqual("a.value", data.A);
            Assert.AreEqual(1.5, data.Properties.ToObjectFromJson<double>());

            var roundTripString = GetSerializedString(data);
            Assert.AreEqual(File.ReadAllText(GetFileName("JsonFormattedStringDouble.json")).TrimEnd(), roundTripString);
        }

        [Test]
        public void CanConvertString()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringString.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.AreEqual("a.value", data.A);
            Assert.AreEqual("1", data.Properties.ToObjectFromJson<string>());

            var roundTripString = GetSerializedString(data);
            Assert.AreEqual(File.ReadAllText(GetFileName("JsonFormattedStringString.json")).TrimEnd(), roundTripString);
        }

        [Test]
        public void CanConvertNull()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringNull.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.AreEqual("a.value", data.A);
            Assert.AreEqual(null, data.Properties.ToObjectFromJson<string>());

            var roundTripString = GetSerializedString(data);
            Assert.AreEqual(File.ReadAllText(GetFileName("JsonFormattedStringNull.json")).TrimEnd(), roundTripString);
        }

        [Test]
        public void CanConvertTrue()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringTrue.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.AreEqual("a.value", data.A);
            Assert.AreEqual(true, data.Properties.ToObjectFromJson<bool>());

            var roundTripString = GetSerializedString(data);
            Assert.AreEqual(File.ReadAllText(GetFileName("JsonFormattedStringTrue.json")).TrimEnd(), roundTripString);
        }

        [Test]
        public void CanConvertFalse()
        {
            using var fs = File.Open(GetFileName("JsonFormattedStringFalse.json"), FileMode.Open, FileAccess.Read, FileShare.Read);
            using var document = JsonDocument.Parse(fs);
            var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);

            Assert.AreEqual("a.value", data.A);
            Assert.AreEqual(false, data.Properties.ToObjectFromJson<bool>());

            var roundTripString = GetSerializedString(data);
            Assert.AreEqual(File.ReadAllText(GetFileName("JsonFormattedStringFalse.json")).TrimEnd(), roundTripString);
        }

        [Test]
        public void CanConvertDifferentValueTypes()
        {
            var expected = File.ReadAllText(GetFileName("PropertiesWithDifferentValueTypes.json")).TrimEnd();
            var model = BinaryData.FromString(expected);

            var properties = model.ToObjectFromJson() as Dictionary<string, object>;
            Assert.AreEqual(typeof(string), properties["stringValue"].GetType());
            Assert.AreEqual(typeof(string), properties["dateTimeValue"].GetType());
            Assert.AreEqual(typeof(int), properties["intValue"].GetType());
            Assert.AreEqual(typeof(long), properties["longValue"].GetType());
            Assert.AreEqual(typeof(double), properties["doubleValue"].GetType());
            Assert.AreEqual(typeof(bool), properties["trueValue"].GetType());
            Assert.AreEqual(typeof(bool), properties["falseValue"].GetType());
            Assert.IsNull(properties["nullValue"]);

            Assert.AreEqual(expected, GetSerializedString(model));
        }

        [Test]
        public void CanConvertArrays()
        {
            var expected = File.ReadAllText(GetFileName("PropertiesWithArrays.json")).TrimEnd();
            var model = BinaryData.FromString(expected);

            var properties = model.ToObjectFromJson() as Dictionary<string, object>;
            Assert.IsTrue(AllValuesAreType(typeof(string), properties["stringArray"]));
            Assert.IsTrue(AllValuesAreType(typeof(string), properties["dateTimeArray"]));
            Assert.IsTrue(AllValuesAreType(typeof(int), properties["intArray"]));
            Assert.IsTrue(AllValuesAreType(typeof(long), properties["longArray"]));
            Assert.IsTrue(AllValuesAreType(typeof(double), properties["doubleArray"]));
            Assert.IsTrue(AllValuesAreType(typeof(bool), properties["boolArray"]));
            foreach (var item in properties["nullArray"] as object[])
            {
                Assert.IsNull(item);
            }
            var mixList = properties["mixedNullArray"] as object[];
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    Assert.IsNull(mixList[i]);
                }
                else
                {
                    Assert.IsNotNull(mixList[i]);
                }
            }
            Assert.AreEqual(expected, GetSerializedString(model));
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
                Assert.IsNotNull(obj);
                Assert.AreEqual(i, obj["intValue"]);
                var innerObj = obj["objectValue"] as Dictionary<string, object>;
                Assert.IsNotNull(innerObj);
                Assert.AreEqual(i.ToString(), innerObj["stringValue"]);
            }
            Assert.AreEqual(expected, GetSerializedString(model));
        }

        [Test]
        public void CanConvertArrayOfArrays()
        {
            var expected = File.ReadAllText(GetFileName("PropertiesWithArraysOfArrays.json")).TrimEnd();
            var model = BinaryData.FromString(expected);
            var properties = model.ToObjectFromJson() as Dictionary<string, object>;
            var arrayArray = properties["arrayArray"] as object[];
            Assert.IsNotNull(arrayArray);
            for (int i = 0; i < 2; i++)
            {
                var array = arrayArray[i] as object[];
                Assert.IsNotNull(array);
                foreach (var item in array)
                {
                    Assert.AreEqual(i, item);
                }
            }
            Assert.AreEqual(expected, GetSerializedString(model));
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
                Assert.AreEqual("a.value", data.A);

                var properties = data.Properties as Dictionary<string, object>;
                Assert.AreEqual("properties.a.value", properties["a"]);
                var innerProperties = properties["innerProperties"] as IDictionary<string, object>;
                Assert.AreEqual("properties.innerProperties.a.value", innerProperties["a"]);
            }
        }

        [Test]
        public void DeserializeJsonFormattedStringWithBinaryData()
        {
            using (var fs = new FileStream(GetFileName("JsonFormattedString.json"), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using var document = JsonDocument.Parse(fs);
                var data = ModelWithBinaryData.DeserializeModelWithBinaryData(document.RootElement);
                Assert.AreEqual("a.value", data.A);

                var properties = data.Properties.ToObjectFromJson() as Dictionary<string, object>;
                Assert.AreEqual("properties.a.value", properties["a"]);
                var innerProperties = properties["innerProperties"] as IDictionary<string, object>;
                Assert.AreEqual("properties.innerProperties.a.value", innerProperties["a"]);
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
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SerailizeUsingJsonFormattedString()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedString.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromString(File.ReadAllText(GetFileName("Properties.json")).TrimEnd());

            string actual = GetSerializedString(payload);
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.IsTrue(CompareIgnoreWhitespace(expected, actual));
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
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingString()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringString.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson("1");
            string actual = GetSerializedString(payload);
            Assert.AreEqual(expected, actual);

            payload.Properties = BinaryData.FromString("\"1\"");
            actual = GetSerializedString(payload);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingTrue()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringTrue.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson(true);

            string actual = GetSerializedString(payload);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingFalse()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringFalse.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson(false);

            string actual = GetSerializedString(payload);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingInt()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringInt.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson(1);

            string actual = GetSerializedString(payload);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingDouble()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringDouble.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson(1.5);

            string actual = GetSerializedString(payload);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SerailizeUsingAnonObjectSettingNull()
        {
            var expected = File.ReadAllText(GetFileName("JsonFormattedStringNull.json")).TrimEnd();

            var payload = new ModelWithBinaryData { A = "a.value" };
            payload.Properties = BinaryData.FromObjectAsJson<object>(null);

            string actual = GetSerializedString(payload);
            Assert.AreEqual(expected, actual);
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
                Assert.AreEqual(payload.A, data.ToObject<Model>(serializer).A);
                Assert.AreEqual(payload.B, data.ToObject<Model>(serializer).B);
                Assert.AreEqual(0, data.ToObject<Model>(serializer).C);
                Assert.AreEqual(payload.A, (await data.ToObjectAsync<Model>(serializer)).A);
                Assert.AreEqual(payload.B, (await data.ToObjectAsync<Model>(serializer)).B);
                Assert.AreEqual(0, (await data.ToObjectAsync<Model>(serializer)).C);
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
                Assert.AreEqual(payload.A, data.ToObject<Model>(serializer).A);
                Assert.AreEqual(payload.B, data.ToObject<Model>(serializer).B);
                Assert.AreEqual(0, data.ToObject<Model>(serializer).C);
                Assert.AreEqual(payload.A, (await data.ToObjectAsync<Model>(serializer)).A);
                Assert.AreEqual(payload.B, (await data.ToObjectAsync<Model>(serializer)).B);
                Assert.AreEqual(0, (await data.ToObjectAsync<Model>(serializer)).C);
                Assert.AreEqual(0, (await data.ToObjectAsync<ExtendedModel>(serializer)).F);
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
                Assert.IsNull(data.ToObject<Model>(serializer));
                Assert.IsNull(await data.ToObjectAsync<Model>(serializer));
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
                Assert.AreEqual(payload.A, data.ToObject<Model>(serializer).A);
                Assert.AreEqual(payload.B, data.ToObject<Model>(serializer).B);
                Assert.AreEqual(0, data.ToObject<Model>(serializer).C);
                Assert.AreEqual(payload.A, (await data.ToObjectAsync<Model>(serializer)).A);
                Assert.AreEqual(payload.B, (await data.ToObjectAsync<Model>(serializer)).B);
                Assert.AreEqual(0, (await data.ToObjectAsync<Model>(serializer)).C);
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
                Assert.AreEqual(payload.A, data.ToObject<Model>(serializer).A);
                Assert.AreEqual(payload.B, data.ToObject<Model>(serializer).B);
                Assert.AreEqual(0, data.ToObject<Model>(serializer).C);
                Assert.AreEqual(payload.A, (await data.ToObjectAsync<Model>(serializer)).A);
                Assert.AreEqual(payload.B, (await data.ToObjectAsync<Model>(serializer)).B);
                Assert.AreEqual(0, (await data.ToObjectAsync<Model>(serializer)).C);
                Assert.AreEqual(0, (await data.ToObjectAsync<ExtendedModel>(serializer)).F);
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
                Assert.IsNull(data.ToObject<Model>(serializer));
                Assert.IsNull(await data.ToObjectAsync<Model>(serializer));
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
