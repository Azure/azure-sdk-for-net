// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ResourceManager.Compute;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class AvailabilitySetDataTests
    {
        private const string _serviceResponse = "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"location\":\"eastus\",\"tags\":{\"key\":\"value\"},\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"sku\":{\"name\":\"Classic\",\"extraSku\":\"extraSku\"},\"extraRoot\":\"extraRoot\"}";

        [TestCase("W")]
        [TestCase("D")]
        public void RoundTripTest(string format) =>
            RoundTripTest(format, SerializeWithModelSerializer);

        [TestCase("W")]
        [TestCase("D")]
        public void BufferTest(string format) =>
            RoundTripTest(format, SerializeWithBuffer);

        [Test]
        public void ImplicitCastTest() =>
            RoundTripTest(ModelSerializerFormat.Wire, SerializeWithImplicitCast);

        [TestCase("W")]
        [TestCase("D")]
        public void JsonReaderTest(string format) =>
            RoundTripTest(format, SerializeWithModelSerializer, DeserializeWithJsonReader);

        [TestCase("W")]
        [TestCase("D")]
        public void UsingSequence(string format) =>
            RoundTripTest(format, SerializeWithModelSerializer, DeserializeWithSequence);

        private void RoundTripTest(string format, Func<AvailabilitySetData, ModelSerializerOptions, string> serialize, Func<string, ModelSerializerOptions, AvailabilitySetData> deserialize = default)
        {
            ModelSerializerOptions options = new ModelSerializerOptions(format);

            var expectedSerializedString = "{";
            if (format == ModelSerializerFormat.Data)
                expectedSerializedString += "\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",";
            expectedSerializedString += "\"sku\":{\"name\":\"Classic\"";
            //if (!ignoreAdditionalProperties)
            //    expectedSerializedString += ",\"extraSku\":\"extraSku\"";
            expectedSerializedString += "},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3}";
            //if (!ignoreAdditionalProperties)
            //    expectedSerializedString += ",\"extraRoot\":\"extraRoot\"";
            expectedSerializedString += "}";

            AvailabilitySetData model = deserialize is null ? ModelSerializer.Deserialize<AvailabilitySetData>(new BinaryData(Encoding.UTF8.GetBytes(_serviceResponse)), options) : deserialize(_serviceResponse, options);

            ValidateModel(model);
            string roundTrip = serialize(model, options);

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            AvailabilitySetData model2 = deserialize is null ? ModelSerializer.Deserialize<AvailabilitySetData>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)), options) : deserialize(roundTrip, options);
            CompareModels(model, model2, format);
        }

        private AvailabilitySetData DeserializeWithJsonReader(string json, ModelSerializerOptions options)
        {
            Utf8JsonReader reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
            var model = Activator.CreateInstance(typeof(AvailabilitySetData), true) as IJsonModelSerializable;
            return (AvailabilitySetData)model.Deserialize(ref reader, options);
        }

        private AvailabilitySetData DeserializeWithSequence(string json, ModelSerializerOptions options)
        {
            using MultiBufferRequestContent content = WriteStringToBuffer(json);
            var sequence = content.GetReadOnlySequence();
            using var doc = JsonDocument.Parse(content.GetReadOnlySequence());
            return AvailabilitySetData.DeserializeAvailabilitySetData(doc.RootElement);
        }

        private MultiBufferRequestContent WriteStringToBuffer(string json)
        {
            MultiBufferRequestContent content = new MultiBufferRequestContent();
            var bytes = Encoding.UTF8.GetBytes(json);
            int fullBuffers = bytes.Length / 4096;
            for (int i = 0; i < fullBuffers; i++)
            {
                int index = i * 4096;
                bytes.AsSpan(index, 4096).CopyTo(content.GetSpan(4096));
                content.Advance(4096);
            }
            var remainder = bytes.Length % 4096;
            bytes.AsSpan(fullBuffers * 4096, remainder).CopyTo(content.GetSpan(remainder));
            content.Advance(remainder);
            return content;
        }

        private string SerializeWithImplicitCast(AvailabilitySetData model, ModelSerializerOptions options)
        {
            RequestContent content = model;
            return GetStringFromContent(content);
        }

        private string SerializeWithModelSerializer(AvailabilitySetData model, ModelSerializerOptions options)
        {
            var data = ModelSerializer.Serialize(model, options);
            return data.ToString();
        }

        private string SerializeWithBuffer(AvailabilitySetData model, ModelSerializerOptions options)
        {
            using var content = new MultiBufferRequestContent();
            using var writer = new Utf8JsonWriter(content);
            ((IJsonModelSerializable)model).Serialize(writer, options);
            writer.Flush();
            return GetStringFromContent(content);
        }

        private static string GetStringFromContent(RequestContent content)
        {
            MemoryStream stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
        {
            Assert.AreEqual(format == ModelSerializerFormat.Wire ? null : model.Id, model2.Id);
            Assert.AreEqual(model.Location, model2.Location);
            Assert.AreEqual(format == ModelSerializerFormat.Wire ? null : model.Name, model2.Name);
            Assert.AreEqual(model.PlatformFaultDomainCount, model2.PlatformFaultDomainCount);
            Assert.AreEqual(model.PlatformUpdateDomainCount, model2.PlatformUpdateDomainCount);
            if (format == ModelSerializerFormat.Data)
                Assert.AreEqual(model.ResourceType, model2.ResourceType);
            CollectionAssert.AreEquivalent(model.Tags, model2.Tags);
            Assert.AreEqual(model.Sku.Name, model2.Sku.Name);
        }

        private void ValidateModel(AvailabilitySetData model)
        {
            Dictionary<string, string> expectedTags = new Dictionary<string, string>() { { "key", "value" } };

            Assert.AreEqual("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375", model.Id.ToString());
            CollectionAssert.AreEquivalent(expectedTags, model.Tags);
            Assert.AreEqual(AzureLocation.EastUS, model.Location);
            Assert.AreEqual("testAS-3375", model.Name);
            Assert.AreEqual("Microsoft.Compute/availabilitySets", model.ResourceType.ToString());
            Assert.AreEqual(5, model.PlatformUpdateDomainCount);
            Assert.AreEqual(3, model.PlatformFaultDomainCount);
            Assert.AreEqual("Classic", model.Sku.Name);
        }

        //[Test]
        //public void ConvertReaderToSpan()
        //{
        //    var bytes = Encoding.UTF8.GetBytes(_serviceResponse);
        //    Utf8JsonReader reader = new Utf8JsonReader(bytes);
        //    using MultiBufferRequestContent content = reader.GetRawBytes();
        //    content.TryComputeLength(out var length);

        //    using var stream = new MemoryStream((int)length);
        //    content.WriteTo(stream, default);

        //    var convertedBytes = stream.GetBuffer().AsMemory(0, (int)stream.Position);

        //    Assert.AreEqual(bytes.Length, convertedBytes.Length);
        //    CollectionAssert.AreEqual(bytes, convertedBytes.ToArray());
        //}
    }
}
