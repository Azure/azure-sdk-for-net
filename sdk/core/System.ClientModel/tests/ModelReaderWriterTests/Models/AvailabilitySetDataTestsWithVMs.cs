// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class AvailabilitySetDataTestsWithVMs : ModelJsonTests<AvailabilitySetData>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataWithVMsWireFormat.json")).TrimEnd();

        protected override string JsonPayload => WirePayload;

        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();

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
            return expectedSerializedString;
            ;
        }

        protected override void VerifyModel(AvailabilitySetData model, string format)
        {
            Dictionary<string, string> expectedTags = new Dictionary<string, string>() { { "key", "value" } };

            Assert.That(model.Id!.ToString(), Is.EqualTo("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375"));
            Assert.That(model.Tags, Is.EquivalentTo(expectedTags));
            Assert.That(model.Location, Is.EqualTo("eastus"));
            Assert.That(model.Name, Is.EqualTo("testAS-3375"));
            Assert.That(model.ResourceType!.ToString(), Is.EqualTo("Microsoft.Compute/availabilitySets"));
            Assert.That(model.PlatformUpdateDomainCount, Is.EqualTo(5));
            Assert.That(model.PlatformFaultDomainCount, Is.EqualTo(3));
            Assert.That(model.Sku.Name, Is.EqualTo("Classic"));
            Assert.That(model.VirtualMachines.Count, Is.EqualTo(2));
            Assert.That(model.VirtualMachines[0].Id!, Is.EqualTo("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS1"));
            Assert.That(model.VirtualMachines[1].Id!, Is.EqualTo("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS2"));
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
        {
            Assert.That(model2.Id, Is.EqualTo(format == "W" ? null : model.Id));
            Assert.That(model.Location, Is.EqualTo(model2.Location));
            Assert.That(format == "W" ? null : model.Name, Is.EqualTo(model2.Name));
            Assert.That(model.PlatformFaultDomainCount, Is.EqualTo(model2.PlatformFaultDomainCount));
            Assert.That(model.PlatformUpdateDomainCount, Is.EqualTo(model2.PlatformUpdateDomainCount));
            if (format == "J")
                Assert.That(model2.ResourceType, Is.EqualTo(model.ResourceType));
            Assert.That(model2.Tags, Is.EquivalentTo(model.Tags));
            Assert.That(model2.Sku.Name, Is.EqualTo(model.Sku.Name));
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(model.VirtualMachines.Count));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo(model.VirtualMachines[0].Id));
            Assert.That(model2.VirtualMachines[1].Id, Is.EqualTo(model.VirtualMachines[1].Id));
        }
    }
}
