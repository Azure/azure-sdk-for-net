// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class UnitTest
    {
        [Test]
        public void P2SConnectionFactoryPreservesRoutingInWireFormat()
        {
            const string routeTableId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub/hubRouteTables/table";
            var routingConfiguration = new RoutingConfigurationNfv
            {
                AssociatedRouteTableId = new ResourceIdentifier(routeTableId),
                PropagatedRouteTables = new PropagatedRouteTableNfv
                {
                    Labels = { "label1", "label2" },
                    Ids =
                    {
                        new RoutingConfigurationNfvSubResource { ResourceUri = new Uri(routeTableId + "1", UriKind.Relative) },
                        new RoutingConfigurationNfvSubResource { ResourceUri = new Uri(routeTableId + "2", UriKind.Relative) },
                        new RoutingConfigurationNfvSubResource { ResourceUri = new Uri(routeTableId + "3", UriKind.Relative) },
                    },
                },
                VnetRoutes = new VnetRoute(),
            };
            var gateway = new P2SVpnGatewayData
            {
                P2SConnectionConfigurations =
                {
                    ArmNetworkModelFactory.P2SConnectionConfiguration(
                        vpnClientAddressPool: new VirtualNetworkAddressSpace { AddressPrefixes = { "101.3.0.0/16" } },
                        routingConfiguration: routingConfiguration),
                },
            };

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            ((IJsonModel<P2SVpnGatewayData>)gateway).Write(writer, new ModelReaderWriterOptions("W"));
            writer.Flush();
            using var document = JsonDocument.Parse(stream.ToArray());
            var connection = document.RootElement.GetProperty("properties").GetProperty("p2SConnectionConfigurations")[0].GetProperty("properties");
            Assert.AreEqual("101.3.0.0/16", connection.GetProperty("vpnClientAddressPool").GetProperty("addressPrefixes")[0].GetString());
            var routing = connection.GetProperty("routingConfiguration");
            Assert.AreEqual(routeTableId, routing.GetProperty("associatedRouteTable").GetProperty("id").GetString());
            var propagated = routing.GetProperty("propagatedRouteTables");
            Assert.AreEqual(2, propagated.GetProperty("labels").GetArrayLength());
            Assert.AreEqual("label1", propagated.GetProperty("labels")[0].GetString());
            Assert.AreEqual("label2", propagated.GetProperty("labels")[1].GetString());
            Assert.AreEqual(3, propagated.GetProperty("ids").GetArrayLength());
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(routeTableId + (i + 1), propagated.GetProperty("ids")[i].GetProperty("id").GetString());
            }
            Assert.AreEqual(JsonValueKind.Object, routing.GetProperty("vnetRoutes").ValueKind);
        }

        // This is the test for fix of issue: https://github.com/Azure/azure-sdk-for-net/issues/46767
        [Test]
        public void DeserializeChangeNumber()
        {
            using var sr = new StreamReader(Path.Combine("TestData", "ServiceTags.json"));
            using var jsonContent = JsonDocument.Parse(sr.BaseStream);
            var data = AzureFirewallIPGroups.DeserializeAzureFirewallIPGroups(jsonContent.RootElement, ModelReaderWriterOptions.Json);
            Assert.NotNull(data.ChangeNumber);
        }

        // Regression test for ManagedRuleSetRuleGroup deserialization with mixed string/number rule IDs
        [Test]
        public void DeserializeManagedRuleSetRuleGroupWithMixedRuleTypes()
        {
            using var sr = new StreamReader(Path.Combine("TestData", "ManagedRuleSetRuleGroup.json"));
            using var jsonContent = JsonDocument.Parse(sr.BaseStream);
            var data = ManagedRuleSetRuleGroup.DeserializeManagedRuleSetRuleGroup(jsonContent.RootElement, ModelReaderWriterOptions.Json);

            Assert.NotNull(data.RuleIds);
            Assert.AreEqual(6, data.RuleIds.Count);

            // Verify that both string and numeric rule IDs are properly converted to strings
            Assert.AreEqual("920100", data.RuleIds[0]); // Originally string
            Assert.AreEqual("920110", data.RuleIds[1]); // Originally number
            Assert.AreEqual("920120", data.RuleIds[2]); // Originally string
            Assert.AreEqual("920130", data.RuleIds[3]); // Originally number
            Assert.AreEqual("920140", data.RuleIds[4]); // Originally string
            Assert.AreEqual("920150", data.RuleIds[5]); // Originally number
        }
    }
}
