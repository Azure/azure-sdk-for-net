// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class OutboundRuleCollectionCompatibilityTests
    {
        private const string FrontendId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/loadBalancers/lb/frontendIPConfigurations/frontend";
        private const string BackendId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/loadBalancers/lb/backendAddressPools/pool";
        private const string RequiredProperties = "\"protocol\":\"All\",\"backendAddressPool\":{\"id\":\"" + BackendId + "\"}";

        [Test]
        public void FreshOutboundRuleHasUsableFrontendCollection()
        {
            AssertUsableCollection(new OutboundRuleData(), 0);
        }

        // Network 1.15.0 normalizes missing/null collections even in incomplete responses.
        [TestCase("{}", 0)]
        [TestCase("{\"properties\":null}", 0)]
        [TestCase("{\"properties\":{}}", 0)]
        [TestCase("{\"properties\":{" + RequiredProperties + "}}", 0)]
        [TestCase("{\"properties\":{" + RequiredProperties + ",\"frontendIPConfigurations\":null}}", 0)]
        [TestCase("{\"properties\":{" + RequiredProperties + ",\"frontendIPConfigurations\":[]}}", 0)]
        [TestCase("{\"properties\":{" + RequiredProperties + ",\"frontendIPConfigurations\":[{\"id\":\"" + FrontendId + "\"}]}}", 1)]
        public void DeserializeOutboundRuleHasUsableFrontendCollection(string json, int expectedCount)
        {
            var data = ModelReaderWriter.Read<OutboundRuleData>(BinaryData.FromString(json));

            AssertUsableCollection(data, expectedCount);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void SerializeOutboundRuleWithMissingFrontendCollection(string format)
        {
            var data = ModelReaderWriter.Read<OutboundRuleData>(
                BinaryData.FromString("{\"properties\":{" + RequiredProperties + "}}"));

            // Write before accessing the getter so lazy initialization cannot hide a serialization failure.
            var json = ModelReaderWriter.Write(data, new ModelReaderWriterOptions(format));
            using var document = JsonDocument.Parse(json.ToString());
            Assert.AreEqual(0, document.RootElement.GetProperty("properties").GetProperty("frontendIPConfigurations").GetArrayLength());
        }

        private static void AssertUsableCollection(OutboundRuleData data, int expectedCount)
        {
            Assert.NotNull(data.FrontendIPConfigurations);
            Assert.AreEqual(expectedCount, data.FrontendIPConfigurations.Count);
            if (expectedCount > 0)
            {
                Assert.AreEqual(FrontendId, data.FrontendIPConfigurations[0].Id.ToString());
            }

            string addedId = FrontendId + "2";
            data.FrontendIPConfigurations.Add(new WritableSubResource { Id = new ResourceIdentifier(addedId) });
            Assert.AreEqual(expectedCount + 1, data.FrontendIPConfigurations.Count);

            // Supply unrelated required fields for round-tripping fresh/incomplete models.
            data.Protocol = LoadBalancerOutboundRuleProtocol.All;
            data.BackendAddressPoolId = new ResourceIdentifier(BackendId);
            var json = ModelReaderWriter.Write(data, new ModelReaderWriterOptions("W"));
            using var document = JsonDocument.Parse(json.ToString());
            var references = document.RootElement.GetProperty("properties").GetProperty("frontendIPConfigurations");
            Assert.AreEqual(expectedCount + 1, references.GetArrayLength());
            Assert.AreEqual(addedId, references[expectedCount].GetProperty("id").GetString());

            var roundTrip = ModelReaderWriter.Read<OutboundRuleData>(json);
            Assert.NotNull(roundTrip.FrontendIPConfigurations);
            Assert.AreEqual(expectedCount + 1, roundTrip.FrontendIPConfigurations.Count);
            Assert.AreEqual(addedId, roundTrip.FrontendIPConfigurations[expectedCount].Id.ToString());
        }
    }
}
