// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class ResourceProviderDataTests
    {
        [Test]
        public void RoundTripTest() =>
            RoundTripTest(SerializeWithModelSerializer, DeserializeWithModelSerializer);

        [Test]
        public void BufferTest() =>
            RoundTripTest(SerializeWithBuffer, DeserializeWithModelSerializer);

        [Test]
        public void JsonReaderTest() =>
            RoundTripTest(SerializeWithModelSerializer, DeserializeWithJsonReader);

        [Test]
        public void UsingSequence() =>
            RoundTripTest(SerializeWithModelSerializer, DeserializeWithSequence);

        [Test]
        public void UsingNonGeneric() =>
            RoundTripTest(SerializeWithModelSerializerNonGeneric, DeserializeWithModelSerializerNonGeneric);

        [Test]
        public void UsingInternal() =>
            RoundTripTest(SerializeWithInternal, DeserializeWithInternal);

        private void RoundTripTest(Func<ResourceProviderData, string> serialize, Func<string, ResourceProviderData> deserialize)
        {
            string serviceResponse = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "ModelSerializationTests", "TestData", "ResourceProviderData.json")).TrimEnd();

            var expectedSerializedString = serviceResponse;

            ResourceProviderData model = deserialize(serviceResponse);

            string roundTrip = serialize(model);

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            ResourceProviderData model2 = deserialize(roundTrip);
        }

        private ResourceProviderData DeserializeWithJsonReader(string json)
        {
            Utf8JsonReader reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
            var model = Activator.CreateInstance(typeof(ResourceProviderData), true) as IJsonModelSerializable;
            return (ResourceProviderData)model.Deserialize(ref reader, new ModelSerializerOptions());
        }

        private ResourceProviderData DeserializeWithSequence(string json)
        {
            using var content = WriteStringToBuffer(json, new ModelSerializerOptions());
            using var doc = JsonDocument.Parse(content.GetReadOnlySequence());
            return ResourceProviderData.DeserializeResourceProviderData(doc.RootElement, new ModelSerializerOptions(ModelSerializerFormat.Wire));
        }

        private ResourceProviderData DeserializeWithModelSerializer(string json)
        {
            return ModelSerializer.Deserialize<ResourceProviderData>(new BinaryData(Encoding.UTF8.GetBytes(json)));
        }

        private ResourceProviderData DeserializeWithInternal(string json)
        {
            using var doc = JsonDocument.Parse(json);
            return ResourceProviderData.DeserializeResourceProviderData(doc.RootElement, new ModelSerializerOptions(ModelSerializerFormat.Wire));
        }

        private ResourceProviderData DeserializeWithModelSerializerNonGeneric(string json)
        {
            return (ResourceProviderData)ModelSerializer.Deserialize(new BinaryData(Encoding.UTF8.GetBytes(json)), typeof(ResourceProviderData));
        }

        private SequenceWriter WriteStringToBuffer(string json, ModelSerializerOptions options)
        {
            var model = ModelSerializer.Deserialize<ResourceProviderData>(new BinaryData(Encoding.UTF8.GetBytes(json)));
            SequenceWriter sequenceWriter = new SequenceWriter();
            using var writer = new Utf8JsonWriter(sequenceWriter);
            ((IJsonModelSerializable)model).Serialize(writer, options);
            writer.Flush();
            return sequenceWriter;
        }

        private string SerializeWithModelSerializer(ResourceProviderData model)
        {
            var data = ModelSerializer.Serialize(model);
            return data.ToString();
        }

        private string SerializeWithModelSerializerNonGeneric(object model)
        {
            var data = ModelSerializer.Serialize(model);
            return data.ToString();
        }

        private string SerializeWithInternal(ResourceProviderData model)
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            model.Serialize(writer);
            writer.Flush();
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private string SerializeWithBuffer(ResourceProviderData model)
        {
            using var sequenceWriter = new SequenceWriter(bufferSize: 4048);
            var writer = new Utf8JsonWriter(sequenceWriter);
            model.Serialize(writer);
            writer.Flush();
            RequestContent content = RequestContent.Create(sequenceWriter);
            using var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
