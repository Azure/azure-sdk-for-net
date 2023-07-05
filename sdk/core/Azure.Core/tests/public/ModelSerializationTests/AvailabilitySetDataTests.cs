 // Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using NUnit.Framework;
using Azure.Core.Tests.Public.ModelSerializationTests.Models;
using Azure.Core.Serialization;
using System.Collections.Generic;
using System;
using Azure.ResourceManager.Compute;

namespace Azure.Core.Tests.Public.ModelSerializationTests
{
    internal class AvailabilitySetDataTests
    {
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void RoundTripTest(bool ignoreReadOnlyProperties, bool ignoreAdditionalProperties)
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
            var data = ModelSerializer.Serialize(model, options);
            string roundTrip = data.ToString();

            Assert.That(roundTrip, Is.EqualTo(expectedSerializedString));

            AvailabilitySetData model2 = ModelSerializer.Deserialize<AvailabilitySetData>(new BinaryData(Encoding.UTF8.GetBytes(roundTrip)), options);
            CompareModels(model, model2, ignoreReadOnlyProperties);
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
