// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
#if SOURCE_GENERATOR
using System.ClientModel.SourceGeneration.Tests;
#endif

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal partial class AvailabilitySetDataTests : ModelJsonTests<AvailabilitySetData>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataWireFormat.json")).TrimEnd();

        protected override string JsonPayload => WirePayload;

#if SOURCE_GENERATOR
        protected override ModelReaderWriterContext Context => BasicContext.Default;
#else
        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();
#endif

        protected override string GetExpectedResult(string format)
        {
            var expectedSerializedString = "{";
            if (format == "J")
                expectedSerializedString += "\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",";
            expectedSerializedString += "\"sku\":{\"name\":\"Classic\"";
            expectedSerializedString += "},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}";
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
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => CompareAvailabilitySetData(model, model2, format);

        internal static void CompareAvailabilitySetData(AvailabilitySetData model, AvailabilitySetData model2, string format, params string[] propertySkips)
        {
            if (model is null)
            {
                Assert.That(model2, Is.Null);
                return;
            }

            HashSet<string> skips = new HashSet<string>(propertySkips);
            if (!skips.Contains("id"))
            {
                Assert.That(model2.Id, Is.EqualTo(format == "W" ? null : model.Id));
            }
            if (!skips.Contains("name"))
            {
                Assert.That(model2.Name, Is.EqualTo(format == "W" ? null : model.Name));
            }
            if (format == "J" && !skips.Contains("resourceType"))
            {
                Assert.That(model2.ResourceType, Is.EqualTo(model.ResourceType));
            }
            if (!skips.Contains("location"))
            {
                Assert.That(model2.Location, Is.EqualTo(model.Location));
            }
            if (!skips.Contains("platformFaultDomainCount"))
            {
                Assert.That(model2.PlatformFaultDomainCount, Is.EqualTo(model.PlatformFaultDomainCount));
            }
            if (!skips.Contains("platformUpdateDomainCount"))
            {
                Assert.That(model2.PlatformUpdateDomainCount, Is.EqualTo(model.PlatformUpdateDomainCount));
            }
            if (!skips.Contains("sku"))
            {
                Assert.That(model2.Sku.Name, Is.EqualTo(model.Sku.Name));
            }
            if (!skips.Contains("tags"))
            {
                Assert.That(model2.Tags, Is.EquivalentTo(model.Tags));
            }
        }
    }
}
