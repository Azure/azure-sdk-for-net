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
            Assert.That(expectedTags, Is.EquivalentTo(model.Tags));
            Assert.That(model.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(model.Name, Is.EqualTo("testAS-3375"));
            Assert.That(model.ResourceType.ToString(), Is.EqualTo("Microsoft.Compute/availabilitySets"));
            Assert.That(model.PlatformUpdateDomainCount, Is.EqualTo(5));
            Assert.That(model.PlatformFaultDomainCount, Is.EqualTo(3));
            Assert.That(model.Sku.Name, Is.EqualTo("Classic"));
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
        {
            Assert.That(format == "W" ? null : model.Id, Is.EqualTo(model2.Id));
            Assert.That(model.Location, Is.EqualTo(model2.Location));
            Assert.That(format == "W" ? null : model.Name, Is.EqualTo(model2.Name));
            Assert.That(model.PlatformFaultDomainCount, Is.EqualTo(model2.PlatformFaultDomainCount));
            Assert.That(model.PlatformUpdateDomainCount, Is.EqualTo(model2.PlatformUpdateDomainCount));
            if (format == "J")
                Assert.That(model.ResourceType, Is.EqualTo(model2.ResourceType));
            Assert.That(model.Tags, Is.EquivalentTo(model2.Tags));
            Assert.That(model.Sku.Name, Is.EqualTo(model2.Sku.Name));
        }
    }
}
