// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineRequestContentTests
    {
        [Test]
        public void StreamCopyToCancellation()
        {
            int size = 100;
            var source = new MemoryStream(size);
            var destination = new MemoryStream(size);
            var content = RequestContent.Create(source);
            var cancellation = new CancellationTokenSource();
            cancellation.Cancel();
            Assert.Throws<TaskCanceledException>(() => { content.WriteTo(destination, cancellation.Token); });
        }

        [Test]
        public void StreamCopyTo()
        {
            int size = 100;
            var sourceArray = new byte[size];
            var destinationArray = new byte[size * 2];
            new Random(100).NextBytes(sourceArray);

            var source = new MemoryStream(sourceArray);
            var destination = new MemoryStream(destinationArray);
            var content = RequestContent.Create(source);

            content.WriteTo(destination, default);

            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(sourceArray[i], destinationArray[i]);
            }
            for (int i = size; i < destinationArray.Length; i++)
            {
                Assert.AreEqual(0, destinationArray[i]);
            }
        }

        [Test]
        public void BinaryDataContent()
        {
            int size = 100;
            var sourceArray = new byte[size];
            var destinationArray = new byte[size];
            new Random(100).NextBytes(sourceArray);

            var source = new BinaryData(sourceArray);
            var destination = new MemoryStream(destinationArray);
            var content = RequestContent.Create(source);

            content.WriteTo(destination, default);

            CollectionAssert.AreEqual(sourceArray, destination.ToArray());
        }

        [Test]
        public void StringContent()
        {
            const string testString = "sample content";

            var expected = (new UTF8Encoding(false)).GetBytes(testString);
            var destination = new MemoryStream();
            var content = RequestContent.Create(testString);

            content.WriteTo(destination, default);

            CollectionAssert.AreEqual(expected, destination.ToArray());
        }

        [Test]
        public void ObjectContent()
        {
            var objectToSerialize = new
            {
                StringProperty = "foo",
                NumberProperty = 5,
            };

            var expected = (new UTF8Encoding(false)).GetBytes(JsonSerializer.Serialize(objectToSerialize));
            var destination = new MemoryStream();
            var content = RequestContent.Create(objectToSerialize);

            content.WriteTo(destination, default);

            CollectionAssert.AreEqual(expected, destination.ToArray());
        }

        [Test]
        public void IntArrayContent()
        {
            var intArray = new int[] { 1, 2, 3 };
            var expected = "[1,2,3]";
            var destination = new MemoryStream();
            var content = RequestContent.Create(intArray);

            content.WriteTo(destination, default);
            destination.Position = 0;
            using var reader = new StreamReader(destination);

            Assert.AreEqual(expected, reader.ReadToEnd());
        }

        [Test]
        public void DictionaryContent()
        {
            var dictionary = new Dictionary<string, object> { { "keyInt", 1 }, { "keyString", "2" }, { "keyFloat", 3.1f } };

#if NETCOREAPP
            var expected = "{\"keyInt\":1,\"keyString\":\"2\",\"keyFloat\":3.1}";
#else
            var expected = "{\"keyInt\":1,\"keyString\":\"2\",\"keyFloat\":3.0999999}";
#endif
            var destination = new MemoryStream();
            var content = RequestContent.Create(dictionary);

            content.WriteTo(destination, default);
            destination.Position = 0;
            using var reader = new StreamReader(destination);

            Assert.AreEqual(expected, reader.ReadToEnd());
        }

        [Test]
        public void JsonModelContent()
        {
            MockJsonModel model = new(404, "abcde");
            using RequestContent content = RequestContent.Create(model, ModelReaderWriterOptions.Json);

            MemoryStream destination = new();
            content.WriteTo(destination, default);

            destination.Position = 0;

            Assert.AreEqual(model.Utf8BytesValue, destination.ToArray());
        }

        [Test]
        public void DynamicDataContent()
        {
            ReadOnlySpan<byte> utf8Json = """
                {
                    "foo" : {
                       "bar" : 1
                    }
                }
                """u8;
            ReadOnlyMemory<byte> json = new ReadOnlyMemory<byte>(utf8Json.ToArray());

            using JsonDocument doc = JsonDocument.Parse(json);
            using MemoryStream expected = new();
            using Utf8JsonWriter writer = new(expected);
            doc.WriteTo(writer);
            writer.Flush();
            expected.Position = 0;

            using dynamic source = new BinaryData(json).ToDynamicFromJson();
            using RequestContent content = RequestContent.Create(source);
            using MemoryStream destination = new();

            content.WriteTo(destination, default);

            CollectionAssert.AreEqual(expected.ToArray(), destination.ToArray());
        }

        [Test]
        public void CamelCaseContent()
        {
            ReadOnlySpan<byte> utf8Json = """
                {
                    "foo" : {
                       "bar" : 1
                    }
                }
                """u8;
            ReadOnlyMemory<byte> json = new ReadOnlyMemory<byte>(utf8Json.ToArray());

            using JsonDocument doc = JsonDocument.Parse(json);
            using MemoryStream expected = new();
            using Utf8JsonWriter writer = new(expected);
            doc.WriteTo(writer);
            writer.Flush();
            expected.Position = 0;

            var anon = new
            {
                Foo = new
                {
                    Bar = 1
                }
            };

            using RequestContent content = RequestContent.Create(anon, JsonPropertyNames.CamelCase);
            using MemoryStream destination = new();
            content.WriteTo(destination, default);

            CollectionAssert.AreEqual(expected.ToArray(), destination.ToArray());
        }

        #region Helpers

        private class MockJsonModel : IJsonModel<MockJsonModel>
        {
            public int IntValue { get; set; }

            public string StringValue { get; set; }

            public byte[] Utf8BytesValue { get; }

            public MockJsonModel(int intValue, string stringValue)
            {
                IntValue = intValue;
                StringValue = stringValue;

                dynamic json = BinaryData.FromString("{}").ToDynamicFromJson(JsonPropertyNames.CamelCase);
                json.IntValue = IntValue;
                json.StringValue = StringValue;

                MemoryStream stream = new();
                using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

                writer.WriteStartObject();
                writer.WriteNumber("IntValue", IntValue);
                writer.WriteString("StringValue", StringValue);
                writer.WriteEndObject();

                writer.Flush();
                Utf8BytesValue = stream.ToArray();
            }

            MockJsonModel IPersistableModel<MockJsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                dynamic json = data.ToDynamicFromJson(JsonPropertyNames.CamelCase);
                return new MockJsonModel(json.IntValue, json.StringValue);
            }

            MockJsonModel IJsonModel<MockJsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using JsonDocument doc = JsonDocument.ParseValue(ref reader);
                int intValue = doc.RootElement.GetProperty("IntValue").GetInt32();
                string stringValue = doc.RootElement.GetProperty("StringValue").GetString()!;
                return new MockJsonModel(intValue, stringValue);
            }

            string IPersistableModel<MockJsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
                => "J";

            BinaryData IPersistableModel<MockJsonModel>.Write(ModelReaderWriterOptions options)
            {
                return BinaryData.FromBytes(Utf8BytesValue);
            }

            void IJsonModel<MockJsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteNumber("IntValue", IntValue);
                writer.WriteString("StringValue", StringValue);
                writer.WriteEndObject();
            }
        }

        #endregion
    }
}
