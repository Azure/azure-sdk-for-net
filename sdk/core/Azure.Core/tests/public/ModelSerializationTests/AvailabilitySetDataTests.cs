// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.Public.ResourceManager.Compute;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class AvailabilitySetDataTests
    {
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void RoundTripTest(bool ignoreReadOnlyProperties, bool ignoreAdditionalProperties) =>
            RoundTripTest(ignoreReadOnlyProperties, ignoreAdditionalProperties, SerializeWithModelSerializer);

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void BufferTest(bool ignoreReadOnlyProperties, bool ignoreAdditionalProperties) =>
            RoundTripTest(ignoreReadOnlyProperties, ignoreAdditionalProperties, SerializeWithBuffer);

        private void RoundTripTest(bool ignoreReadOnlyProperties, bool ignoreAdditionalProperties, Func<AvailabilitySetData, ModelSerializerOptions, string> serialize)
        {
            ModelSerializerOptions options = new ModelSerializerOptions();
            options.IgnoreAdditionalProperties = ignoreAdditionalProperties;
            options.IgnoreReadOnlyProperties = ignoreReadOnlyProperties;

            string serviceResponse = "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"location\":\"eastus\",\"tags\":{\"key\":\"value\"},\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"sku\":{\"name\":\"Classic\",\"extraSku\":\"extraSku\"},\"extraRoot\":\"extraRoot\"}";

            var expectedSerializedString = "{";
            if (!ignoreReadOnlyProperties)
                expectedSerializedString += "\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",";
            expectedSerializedString += "\"sku\":{\"name\":\"Classic\"";
            //if (!ignoreAdditionalProperties)
            //    expectedSerializedString += ",\"extraSku\":\"extraSku\"";
            expectedSerializedString += "},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3}";
            //if (!ignoreAdditionalProperties)
            //    expectedSerializedString += ",\"extraRoot\":\"extraRoot\"";
            expectedSerializedString += "}";

            AvailabilitySetData model = ModelSerializer.Deserialize<AvailabilitySetData>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options);

            ValidateModel(model);
            string roundTrip = serialize(model, options);

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            AvailabilitySetData model2 = ModelSerializer.Deserialize<AvailabilitySetData>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)), options);
            CompareModels(model, model2, ignoreReadOnlyProperties);
        }

        private string SerializeWithModelSerializer(AvailabilitySetData model, ModelSerializerOptions options)
        {
            var data = ModelSerializer.Serialize(model, options);
            return data.ToString();
        }

        private string SerializeWithBuffer(AvailabilitySetData model, ModelSerializerOptions options)
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

        private void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, bool ignoreReadOnlyProperties)
        {
            Assert.AreEqual(ignoreReadOnlyProperties ? null : model.Id, model2.Id);
            Assert.AreEqual(model.Location, model2.Location);
            Assert.AreEqual(ignoreReadOnlyProperties ? null : model.Name, model2.Name);
            Assert.AreEqual(model.PlatformFaultDomainCount, model2.PlatformFaultDomainCount);
            Assert.AreEqual(model.PlatformUpdateDomainCount, model2.PlatformUpdateDomainCount);
            if (!ignoreReadOnlyProperties)
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
    }
}
