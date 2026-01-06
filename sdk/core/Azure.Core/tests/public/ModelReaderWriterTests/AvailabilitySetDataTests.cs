// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using Azure.Core.Tests.Common;
using Azure.Core.Tests.Models.ResourceManager.Compute;
using NUnit.Framework;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests
{
    internal class AvailabilitySetDataTests : ModelJsonTests<AvailabilitySetData>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataWireFormat.json")).TrimEnd();

        protected override string JsonPayload => WirePayload;

        protected override string GetExpectedResult(string format)
        {
            var expectedSerializedString = "{";
            if (format == "J")
                expectedSerializedString += "\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",";
            expectedSerializedString += "\"sku\":{\"name\":\"Classic\"";
            //if (!ignoreAdditionalProperties)
            //    expectedSerializedString += ",\"extraSku\":\"extraSku\"";
            expectedSerializedString += "},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3}";
            //if (!ignoreAdditionalProperties)
            //    expectedSerializedString += ",\"extraRoot\":\"extraRoot\"";
            expectedSerializedString += "}";
            return expectedSerializedString; ;
        }

        protected override void VerifyModel(AvailabilitySetData model, string format)
        {
            Dictionary<string, string> expectedTags = new Dictionary<string, string>() { { "key", "value" } };

            Assert.That(model.Id.ToString(), Is.EqualTo("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375"));
            Assert.That(model.Tags, Is.EquivalentTo(expectedTags));
            Assert.Multiple(() =>
            {
                Assert.That(model.Location, Is.EqualTo(AzureLocation.EastUS));
                Assert.That(model.Name, Is.EqualTo("testAS-3375"));
                Assert.That(model.ResourceType.ToString(), Is.EqualTo("Microsoft.Compute/availabilitySets"));
                Assert.That(model.PlatformUpdateDomainCount, Is.EqualTo(5));
                Assert.That(model.PlatformFaultDomainCount, Is.EqualTo(3));
                Assert.That(model.Sku.Name, Is.EqualTo("Classic"));
            });
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
        {
            Assert.That(model2.Id, Is.EqualTo(format == "W" ? null : model.Id));
            Assert.AreEqual(model.Location, model2.Location);
            Assert.AreEqual(format == "W" ? null : model.Name, model2.Name);
            Assert.AreEqual(model.PlatformFaultDomainCount, model2.PlatformFaultDomainCount);
            Assert.AreEqual(model.PlatformUpdateDomainCount, model2.PlatformUpdateDomainCount);
            if (format == "J")
                Assert.That(model2.ResourceType, Is.EqualTo(model.ResourceType));
            Assert.That(model2.Tags, Is.EquivalentTo(model.Tags));
            Assert.That(model2.Sku.Name, Is.EqualTo(model.Sku.Name));
        }
    }
}
