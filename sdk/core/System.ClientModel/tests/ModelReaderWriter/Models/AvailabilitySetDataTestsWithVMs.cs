// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class AvailabilitySetDataTestsWithVMs : ModelJsonTests<AvailabilitySetData>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataWithVMsWireFormat.json")).TrimEnd();

        protected override string JsonPayload => WirePayload;

        protected override string GetExpectedResult(string format)
        {
            var expectedSerializedString = "{";
            if (format == "J")
                expectedSerializedString += "\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",";
            expectedSerializedString += "\"sku\":{\"name\":\"Classic\"";
            //if (!ignoreAdditionalProperties)
            //    expectedSerializedString += ",\"extraSku\":\"extraSku\"";
            expectedSerializedString += "},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3";
            //if (!ignoreAdditionalProperties)
            //    expectedSerializedString += ",\"extraRoot\":\"extraRoot\"";
            expectedSerializedString += ",\"virtualMachines\":[{\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS1\"},{\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS2\"}]";
            expectedSerializedString += "}}";
            return expectedSerializedString; ;
        }

        protected override void VerifyModel(AvailabilitySetData model, string format)
        {
            Dictionary<string, string> expectedTags = new Dictionary<string, string>() { { "key", "value" } };

            Assert.AreEqual("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375", model.Id.ToString());
            CollectionAssert.AreEquivalent(expectedTags, model.Tags);
            Assert.AreEqual("eastus", model.Location);
            Assert.AreEqual("testAS-3375", model.Name);
            Assert.AreEqual("Microsoft.Compute/availabilitySets", model.ResourceType.ToString());
            Assert.AreEqual(5, model.PlatformUpdateDomainCount);
            Assert.AreEqual(3, model.PlatformFaultDomainCount);
            Assert.AreEqual("Classic", model.Sku.Name);
            Assert.AreEqual(2, model.VirtualMachines.Count);
            Assert.AreEqual("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS1", model.VirtualMachines[0].Id.ToString());
            Assert.AreEqual("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS2", model.VirtualMachines[1].Id.ToString());
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
        {
            Assert.AreEqual(format == "W" ? null : model.Id, model2.Id);
            Assert.AreEqual(model.Location, model2.Location);
            Assert.AreEqual(format == "W" ? null : model.Name, model2.Name);
            Assert.AreEqual(model.PlatformFaultDomainCount, model2.PlatformFaultDomainCount);
            Assert.AreEqual(model.PlatformUpdateDomainCount, model2.PlatformUpdateDomainCount);
            if (format == "J")
                Assert.AreEqual(model.ResourceType, model2.ResourceType);
            CollectionAssert.AreEquivalent(model.Tags, model2.Tags);
            Assert.AreEqual(model.Sku.Name, model2.Sku.Name);
            Assert.AreEqual(model.VirtualMachines.Count, model2.VirtualMachines.Count);
            Assert.AreEqual(model.VirtualMachines[0].Id, model2.VirtualMachines[0].Id);
            Assert.AreEqual(model.VirtualMachines[1].Id, model2.VirtualMachines[1].Id);
        }
    }
}
