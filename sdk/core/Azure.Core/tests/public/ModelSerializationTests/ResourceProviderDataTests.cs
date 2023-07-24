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
            RoundTripTest(SerializeWithModelSerializer);

        [Test]
        public void BufferTest() =>
            RoundTripTest(SerializeWithBuffer);

        [Test]
        public void JsonReaderTest() =>
            RoundTripTest(SerializeWithModelSerializer, DeserializeWithJsonReader);

        [Test]
        public void UsingSequence() =>
            RoundTripTest(SerializeWithModelSerializer, DeserializeWithSequence);

        private void RoundTripTest(Func<ResourceProviderData, string> serialize, Func<string, ResourceProviderData> deserialize = default)
        {
            string serviceResponse = File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "ModelSerializationTests", "TestData", "ResourceProviderData.json")).TrimEnd();

            var expectedSerializedString = serviceResponse;

            ResourceProviderData model = deserialize is null ? ModelSerializer.Deserialize<ResourceProviderData>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse))) : deserialize(serviceResponse);

            string roundTrip = serialize(model);

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            ResourceProviderData model2 = deserialize is null ? ModelSerializer.Deserialize<ResourceProviderData>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip))) : deserialize(roundTrip);
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
            return ResourceProviderData.DeserializeResourceProviderData(doc.RootElement);
        }

        private MultiBufferRequestContent WriteStringToBuffer(string json, ModelSerializerOptions options)
        {
            var model = ModelSerializer.Deserialize<ResourceProviderData>(new BinaryData(Encoding.UTF8.GetBytes(json)));
            MultiBufferRequestContent content = new MultiBufferRequestContent();
            using var writer = new Utf8JsonWriter(content);
            ((IJsonModelSerializable)model).Serialize(writer, options);
            writer.Flush();
            return content;
        }

        private string SerializeWithModelSerializer(ResourceProviderData model)
        {
            var data = ModelSerializer.Serialize(model);
            return data.ToString();
        }

        private string SerializeWithBuffer(ResourceProviderData model)
        {
            using var multiBufferRequestContent = new MultiBufferRequestContent(bufferSize: 4048);
            var writer = new Utf8JsonWriter(multiBufferRequestContent);
            model.Serialize(writer);
            writer.Flush();
            RequestContent content = multiBufferRequestContent;
            using var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        //[Test]
        //public void ConvertReaderToSpan()
        //{
        //    var bytes = Encoding.UTF8.GetBytes(File.ReadAllText(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "ModelSerializationTests", "TestData", "ResourceProviderData.json")).TrimEnd());
        //    Utf8JsonReader reader = new Utf8JsonReader(bytes);
        //    using MultiBufferRequestContent content = reader.GetRawBytes();
        //    content.TryComputeLength(out var length);

        //    using var stream = new MemoryStream((int)length);
        //    content.WriteTo(stream, default);

        //    var convertedBytes = stream.GetBuffer().AsMemory(0, (int)stream.Position);

        //    //Assert.AreEqual(bytes.Length, convertedBytes.Length);
        //    CollectionAssert.AreEqual(bytes, convertedBytes.ToArray());
        //}
    }
}
