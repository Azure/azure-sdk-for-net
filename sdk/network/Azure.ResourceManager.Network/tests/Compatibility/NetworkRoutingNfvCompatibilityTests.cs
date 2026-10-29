// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
#pragma warning disable CS0618 // Exercise the explicitly deprecated NFV compatibility contract.
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkRoutingNfvCompatibilityTests
    {
        private const string RouteId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub/hubRouteTables/route";
        private const string NativeJson = """
            {"associatedRouteTable":{"id":"/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub/hubRouteTables/route"},
             "propagatedRouteTables":{"labels":["default"],"ids":[{"id":"/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub/hubRouteTables/route"}]},
             "vnetRoutes":{"staticRoutes":[{"name":"one","addressPrefixes":["10.0.0.0/24"],"nextHopIpAddress":"10.0.0.4"}]},
             "futureNative":{"preserve":true}}
            """;
        private const string NfvJson = """
            {"associatedRouteTable":{"resourceUri":"https://example.test/routes/associated"},
             "propagatedRouteTables":{"labels":["nfv"],"ids":[{"resourceUri":"https://example.test/routes/child"}]},
             "inboundRouteMap":{"resourceUri":"https://example.test/maps/in"},
             "outboundRouteMap":{"resourceUri":"https://example.test/maps/out"}}
            """;

        [Test]
        public void P2SConnectionFactoryPreservesRoutingInWireFormat()
        {
            const string routeTableId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub/hubRouteTables/table";
            var routingConfiguration = new RoutingConfiguration
            {
                AssociatedRouteTableId = new ResourceIdentifier(routeTableId),
                PropagatedRouteTables = new PropagatedRouteTable
                {
                    Labels = { "label1", "label2" },
                    Ids =
                    {
                        new WritableSubResource { Id = new ResourceIdentifier(routeTableId + "1") },
                        new WritableSubResource { Id = new ResourceIdentifier(routeTableId + "2") },
                        new WritableSubResource { Id = new ResourceIdentifier(routeTableId + "3") },
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

        [Test]
        public void NativeAndNfvModelsHaveIndependentReleasedContracts()
        {
            foreach (Type type in new[] { typeof(RoutingConfigurationNfv), typeof(PropagatedRouteTableNfv), typeof(RoutingConfigurationNfvSubResource) })
            {
                Assert.That(type.BaseType, Is.EqualTo(typeof(object)));
                Assert.That(type.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
                Assert.That(type.GetCustomAttributesData().Any(a => a.AttributeType.Name == "CodeGenTypeAttribute"), Is.False);
            }
            Assert.That(typeof(RoutingConfiguration).BaseType, Is.EqualTo(typeof(object)));
            Assert.That(typeof(PropagatedRouteTable).BaseType, Is.EqualTo(typeof(object)));
            Assert.That(typeof(PropagatedRouteTable).GetProperty("Ids").PropertyType, Is.EqualTo(typeof(IList<WritableSubResource>)));
            Assert.That(typeof(PropagatedRouteTableNfv).GetProperty("Ids").PropertyType, Is.EqualTo(typeof(IList<RoutingConfigurationNfvSubResource>)));
            Assert.That(typeof(RoutingConfiguration).GetProperty("PropagatedRouteTables").PropertyType, Is.EqualTo(typeof(PropagatedRouteTable)));
            Assert.That(typeof(RoutingConfigurationNfv).GetProperty("PropagatedRouteTables").PropertyType, Is.EqualTo(typeof(PropagatedRouteTableNfv)));
            Assert.That(typeof(NetworkVirtualApplianceConnectionData).GetProperty("ConnectionRoutingConfiguration").PropertyType, Is.EqualTo(typeof(RoutingConfiguration)));
            Assert.That(typeof(NetworkVirtualApplianceConnectionData).GetProperty("RoutingConfiguration").PropertyType, Is.EqualTo(typeof(RoutingConfigurationNfv)));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void HistoricalNfvModelsRoundTripResourceUris(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            RoutingConfigurationNfv model = ModelReaderWriter.Read<RoutingConfigurationNfv>(
                BinaryData.FromString(NfvJson), options);
            Assert.That(model.AssociatedRouteTableResourceUri.AbsoluteUri, Is.EqualTo("https://example.test/routes/associated"));
            Assert.That(model.PropagatedRouteTables.Ids.Single().ResourceUri.AbsoluteUri, Is.EqualTo("https://example.test/routes/child"));
            model.InboundRouteMapResourceUri = new Uri("https://example.test/maps/updated");
            model.PropagatedRouteTables.Ids.Add(new RoutingConfigurationNfvSubResource { ResourceUri = new Uri("https://example.test/routes/second") });
            BinaryData serialized = ((IPersistableModel<RoutingConfigurationNfv>)model).Write(options);
            using JsonDocument json = JsonDocument.Parse(serialized);
            JsonElement root = json.RootElement;
            Assert.That(root.GetProperty("inboundRouteMap").GetProperty("resourceUri").GetString(), Is.EqualTo("https://example.test/maps/updated"));
            Assert.That(root.GetProperty("outboundRouteMap").GetProperty("resourceUri").GetString(), Is.EqualTo("https://example.test/maps/out"));
            JsonElement ids = root.GetProperty("propagatedRouteTables").GetProperty("ids");
            Assert.That(ids.GetArrayLength(), Is.EqualTo(2));
            Assert.That(ids[0].TryGetProperty("id", out _), Is.False);
            Assert.That(ModelReaderWriter.Read<RoutingConfigurationNfv>(serialized, options)
                .PropagatedRouteTables.Ids.Count, Is.EqualTo(2));
        }

        [Test]
        public void OnlyLegacyNfvSurfaceIsDeprecated()
        {
            var replacements = new Dictionary<Type, string>
            {
                [typeof(PropagatedRouteTableNfv)] = " Please use PropagatedRouteTable instead.",
                [typeof(RoutingConfigurationNfv)] = " Please use RoutingConfiguration instead.",
                [typeof(RoutingConfigurationNfvSubResource)] = ""
            };
            foreach (var entry in replacements)
            {
                Assert.That(entry.Key.GetCustomAttribute<ObsoleteAttribute>().Message,
                    Is.EqualTo("This type is obsoleted and will be removed in a future version." + entry.Value));
                Assert.That(entry.Key.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    .Any(p => p.GetCustomAttribute<ObsoleteAttribute>() != null), Is.False);
            }
            PropertyInfo legacy = typeof(NetworkVirtualApplianceConnectionData).GetProperty("RoutingConfiguration");
            Assert.That(legacy.GetCustomAttribute<ObsoleteAttribute>().Message,
                Is.EqualTo("This property is obsoleted and will be removed in a future version. Please use ConnectionRoutingConfiguration instead."));
            Assert.That(legacy.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            var factories = typeof(ArmNetworkModelFactory).GetMethods().Where(m => m.Name == "NetworkVirtualApplianceConnectionData").ToArray();
            MethodInfo legacyFactory = factories.Single(m => m.GetParameters().Last().ParameterType == typeof(RoutingConfigurationNfv));
            Assert.That(legacyFactory.GetCustomAttribute<ObsoleteAttribute>().Message,
                Is.EqualTo("This method is obsolete. Please use the overload accepting RoutingConfiguration instead."));
            Assert.That(legacyFactory.GetCustomAttribute<ObsoleteAttribute>().IsError, Is.False);
            Assert.That(legacyFactory.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(factories.Single(m => m.GetParameters().Last().ParameterType == typeof(RoutingConfiguration))
                .GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(RoutingConfiguration).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(PropagatedRouteTable).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(AzureResourceManagerNetworkContext).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(NetworkVirtualApplianceConnectionData).GetProperty("ConnectionRoutingConfiguration")
                .GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
        }

        [Test]
        public void NfvDefaultsAndNullReferencesRemainReadable()
        {
            Assert.That(new PropagatedRouteTableNfv().Labels, Is.Empty);
            Assert.That(new PropagatedRouteTableNfv().Ids, Is.Empty);
            var model = ModelReaderWriter.Read<RoutingConfigurationNfv>(
                BinaryData.FromString("""{"associatedRouteTable":null,"propagatedRouteTables":{"labels":[],"ids":[null]}}"""));
            Assert.That(model.AssociatedRouteTableResourceUri, Is.Null);
            Assert.That(model.PropagatedRouteTables.Ids.Single(), Is.Null);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(json.RootElement.GetProperty("propagatedRouteTables").GetProperty("ids")[0].ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(ModelReaderWriter.Read<RoutingConfigurationNfvSubResource>(BinaryData.FromString("""{"id":"ignored"}""")).ResourceUri, Is.Null);
        }

        [Test]
        public void NfvModelsRejectUnsupportedPersistenceFormats()
        {
            var options = new ModelReaderWriterOptions("X");
            Assert.Throws<FormatException>(() => ((IPersistableModel<RoutingConfigurationNfv>)new RoutingConfigurationNfv()).Write(options));
            Assert.Throws<FormatException>(() => ((IPersistableModel<PropagatedRouteTableNfv>)new PropagatedRouteTableNfv()).Write(options));
            Assert.Throws<FormatException>(() => ((IPersistableModel<RoutingConfigurationNfvSubResource>)new RoutingConfigurationNfvSubResource()).Write(options));
        }

        [Test]
        public void NativeConnectionRoutingReadsMutatesAndPreservesUnknownJson()
        {
            var model = ModelReaderWriter.Read<NetworkVirtualApplianceConnectionData>(
                BinaryData.FromString("{\"properties\":{\"routingConfiguration\":" + NativeJson + "}}"));
            RoutingConfiguration routing = model.ConnectionRoutingConfiguration;
            Assert.That(routing.AssociatedRouteTableId.ToString(), Is.EqualTo(RouteId));
            Assert.That(routing.PropagatedRouteTables.Ids.Single().Id.ToString(), Is.EqualTo(RouteId));
            routing.AssociatedRouteTableId = new ResourceIdentifier(RouteId + "2");
            routing.PropagatedRouteTables.Labels.Add("second");
            routing.PropagatedRouteTables.Ids.Add(new WritableSubResource { Id = new ResourceIdentifier(RouteId + "2") });
            routing.StaticRoutes.Single().AddressPrefixes.Add("10.1.0.0/24");
            Assert.That(routing.StaticRoutes, Is.SameAs(routing.VnetRoutes.StaticRoutes));
            Assert.That(model.RoutingConfiguration, Is.Null);
            model.RoutingConfiguration = ModelReaderWriter.Read<RoutingConfigurationNfv>(BinaryData.FromString(NfvJson));
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            JsonElement properties = json.RootElement.GetProperty("properties");
            Assert.That(properties.EnumerateObject().Count(p => p.Name == "routingConfiguration"), Is.EqualTo(1));
            JsonElement wire = properties.GetProperty("routingConfiguration");
            Assert.That(wire.GetProperty("associatedRouteTable").GetProperty("id").GetString(), Is.EqualTo(RouteId + "2"));
            Assert.That(wire.GetProperty("associatedRouteTable").TryGetProperty("resourceUri", out _), Is.False);
            Assert.That(wire.GetProperty("propagatedRouteTables").GetProperty("ids").GetArrayLength(), Is.EqualTo(2));
            Assert.That(wire.GetProperty("propagatedRouteTables").GetProperty("ids")[1].GetProperty("id").GetString(), Is.EqualTo(RouteId + "2"));
            Assert.That(wire.GetProperty("propagatedRouteTables").GetProperty("labels").GetArrayLength(), Is.EqualTo(2));
            Assert.That(wire.GetProperty("futureNative").GetProperty("preserve").GetBoolean(), Is.True);
            Assert.That(wire.GetProperty("vnetRoutes").GetProperty("staticRoutes")[0].GetProperty("addressPrefixes").GetArrayLength(), Is.EqualTo(2));
        }

        [Test]
        public void ReleasedApplianceFactoriesKeepNativeAndLegacyRoles()
        {
            RoutingConfiguration routing = ModelReaderWriter.Read<RoutingConfiguration>(BinaryData.FromString(NativeJson));
            var native = ArmNetworkModelFactory.NetworkVirtualApplianceConnectionData(connectionRoutingConfiguration: routing);
            Assert.That(native.ConnectionRoutingConfiguration, Is.SameAs(routing));
            var legacy = ArmNetworkModelFactory.NetworkVirtualApplianceConnectionData(
                id: null, name: null, resourceType: null, namePropertiesName: null, provisioningState: null,
                asn: null, tunnelIdentifier: null, bgpPeerAddress: null, enableInternetSecurity: null,
                routingConfiguration: new RoutingConfigurationNfv { AssociatedRouteTableResourceUri = new Uri("https://example.test/legacy") });
            // The 1.15 compatibility factory intentionally forwards null native routing, not the legacy argument.
            Assert.That(legacy.ConnectionRoutingConfiguration, Is.Null);
            Assert.That(legacy.RoutingConfiguration, Is.Null);
        }

        [Test]
        public void NativeP2SRoutingAndReleasedFactoryUseOrdinaryRoutingModel()
        {
            RoutingConfiguration routing = ModelReaderWriter.Read<RoutingConfiguration>(BinaryData.FromString(NativeJson));
            var model = ArmNetworkModelFactory.P2SConnectionConfiguration(
                id: null, name: null, resourceType: null, etag: null, vpnClientAddressPrefixes: new[] { "10.2.0.0/24" },
                routingConfiguration: routing, enableInternetSecurity: true, configurationPolicyGroupAssociations: null,
                previousConfigurationPolicyGroupAssociations: null, provisioningState: null);
            Assert.That(model.RoutingConfiguration, Is.SameAs(routing));
            Assert.That(model.VpnClientAddressPool.IpamPoolPrefixAllocations, Is.Not.Null.And.Empty);
            foreach (string format in new[] { "J", "W" })
            {
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions(format)));
                Assert.That(json.RootElement.GetProperty("properties").GetProperty("vpnClientAddressPool")
                    .GetProperty("addressPrefixes")[0].GetString(), Is.EqualTo("10.2.0.0/24"));
                Assert.That(json.RootElement.GetProperty("properties").GetProperty("routingConfiguration")
                    .GetProperty("associatedRouteTable").GetProperty("id").GetString(), Is.EqualTo(RouteId));
            }
        }
#pragma warning restore CS0618
    }
}
