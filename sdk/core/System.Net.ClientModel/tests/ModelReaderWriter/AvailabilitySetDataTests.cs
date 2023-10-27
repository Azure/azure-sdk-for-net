﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Tests.Client;
using System.Net.ClientModel.Tests.Client.ResourceManager.Compute;

namespace System.Net.ClientModel.Tests.ModelReaderWriterTests
{
    internal class AvailabilitySetDataTests : ModelJsonTests<AvailabilitySetData>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataWireFormat.json")).TrimEnd();

        protected override string JsonPayload => WirePayload;

        protected override Func<AvailabilitySetData?, MessageBody> ToPipelineContent => model => model;

        protected override Func<Result?, AvailabilitySetData> FromResult => response => (AvailabilitySetData)response;

        protected override string GetExpectedResult(ModelReaderWriterFormat format)
        {
            var expectedSerializedString = "{";
            if (format == ModelReaderWriterFormat.Json)
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

        protected override void VerifyModel(AvailabilitySetData model, ModelReaderWriterFormat format)
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
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, ModelReaderWriterFormat format)
        {
            Assert.AreEqual(format == ModelReaderWriterFormat.Wire ? null : model.Id, model2.Id);
            Assert.AreEqual(model.Location, model2.Location);
            Assert.AreEqual(format == ModelReaderWriterFormat.Wire ? null : model.Name, model2.Name);
            Assert.AreEqual(model.PlatformFaultDomainCount, model2.PlatformFaultDomainCount);
            Assert.AreEqual(model.PlatformUpdateDomainCount, model2.PlatformUpdateDomainCount);
            if (format == ModelReaderWriterFormat.Json)
                Assert.AreEqual(model.ResourceType, model2.ResourceType);
            CollectionAssert.AreEquivalent(model.Tags, model2.Tags);
            Assert.AreEqual(model.Sku.Name, model2.Sku.Name);
        }
    }
}
