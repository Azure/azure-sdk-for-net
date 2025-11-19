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
            return expectedSerializedString; ;
        }

        protected override void VerifyModel(AvailabilitySetData model, string format)
        {
            Dictionary<string, string> expectedTags = new Dictionary<string, string>() { { "key", "value" } };

            Assert.AreEqual("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375", model.Id!.ToString());
            CollectionAssert.AreEquivalent(expectedTags, model.Tags);
            Assert.AreEqual("eastus", model.Location);
            Assert.AreEqual("testAS-3375", model.Name);
            Assert.AreEqual("Microsoft.Compute/availabilitySets", model.ResourceType!.ToString());
            Assert.AreEqual(5, model.PlatformUpdateDomainCount);
            Assert.AreEqual(3, model.PlatformFaultDomainCount);
            Assert.AreEqual("Classic", model.Sku.Name);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => CompareAvailabilitySetData(model, model2, format);

        internal static void CompareAvailabilitySetData(AvailabilitySetData model, AvailabilitySetData model2, string format, params string[] propertySkips)
        {
            if (model is null)
            {
                Assert.IsNull(model2);
                return;
            }

            HashSet<string> skips = new HashSet<string>(propertySkips);
            if (!skips.Contains("id"))
            {
                Assert.AreEqual(format == "W" ? null : model.Id, model2.Id);
            }
            if (!skips.Contains("name"))
            {
                Assert.AreEqual(format == "W" ? null : model.Name, model2.Name);
            }
            if (format == "J" && !skips.Contains("resourceType"))
            {
                Assert.AreEqual(model.ResourceType, model2.ResourceType);
            }
            if (!skips.Contains("location"))
            {
                Assert.AreEqual(model.Location, model2.Location);
            }
            if (!skips.Contains("platformFaultDomainCount"))
            {
                Assert.AreEqual(model.PlatformFaultDomainCount, model2.PlatformFaultDomainCount);
            }
            if (!skips.Contains("platformUpdateDomainCount"))
            {
                Assert.AreEqual(model.PlatformUpdateDomainCount, model2.PlatformUpdateDomainCount);
            }
            if (!skips.Contains("sku"))
            {
                Assert.AreEqual(model.Sku.Name, model2.Sku.Name);
            }
            if (!skips.Contains("tags"))
            {
                CollectionAssert.AreEquivalent(model.Tags, model2.Tags);
            }
        }
    }
}
