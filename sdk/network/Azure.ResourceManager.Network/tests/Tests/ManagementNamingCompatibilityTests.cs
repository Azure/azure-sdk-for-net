// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class ManagementNamingCompatibilityTests
    {
        [TestCase(typeof(VirtualNetworkGatewayData), "CustomRoutesAddressPrefixes", "CustomRoutes", "customRoutes")]
        [TestCase(typeof(VirtualNetworkPeeringData), "LocalAddressPrefixes", "LocalAddressSpace", "localAddressSpace")]
        [TestCase(typeof(VirtualNetworkPeeringData), "LocalVirtualNetworkAddressPrefixes", "LocalVirtualNetworkAddressSpace", "localVirtualNetworkAddressSpace")]
        [TestCase(typeof(VirtualNetworkPeeringData), "RemoteAddressPrefixes", "RemoteAddressSpace", "remoteAddressSpace")]
        [TestCase(typeof(VirtualNetworkPeeringData), "RemoteVirtualNetworkAddressPrefixes", "RemoteVirtualNetworkAddressSpace", "remoteVirtualNetworkAddressSpace")]
        public void FlattenedAddressPrefixesForwardWithoutObsolete(Type modelType, string flattenedName, string containerName, string wireName)
        {
            var flattened = modelType.GetProperty(flattenedName);
            var container = modelType.GetProperty(containerName);
            Assert.That(flattened, Is.Not.Null);
            Assert.That(flattened.PropertyType, Is.EqualTo(typeof(IList<string>)));
            Assert.That(flattened.CanWrite, Is.False);
            Assert.That(flattened.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(flattened.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);

            var empty = Activator.CreateInstance(modelType);
            Assert.That(container.GetValue(empty), Is.Null);
            var emptyPrefixes = (IList<string>)flattened.GetValue(empty);
            Assert.That(emptyPrefixes, Is.Empty);
            Assert.That(emptyPrefixes, Is.SameAs(((VirtualNetworkAddressSpace)container.GetValue(empty)).AddressPrefixes));

            var model = ModelReaderWriter.Read(
                BinaryData.FromString("""{"location":"westus","properties":{"WIRE_NAME":{"addressPrefixes":["10.0.0.0/24"],"ipamPoolPrefixAllocations":[{}]}}}"""
                    .Replace("WIRE_NAME", wireName)), modelType);
            var addressSpace = (VirtualNetworkAddressSpace)container.GetValue(model);
            var prefixes = (IList<string>)flattened.GetValue(model);
            Assert.That(prefixes, Is.SameAs(addressSpace.AddressPrefixes));
            Assert.That(prefixes, Is.EqualTo(new[] { "10.0.0.0/24" }));
            var allocation = addressSpace.IpamPoolPrefixAllocations[0];
            prefixes.Add("10.0.1.0/24");
            Assert.That(addressSpace.IpamPoolPrefixAllocations[0], Is.SameAs(allocation));

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            var wireAddressSpace = json.RootElement.GetProperty("properties").GetProperty(wireName);
            Assert.That(wireAddressSpace.GetProperty("addressPrefixes").GetArrayLength(), Is.EqualTo(2));
            Assert.That(wireAddressSpace.GetProperty("addressPrefixes")[1].GetString(), Is.EqualTo("10.0.1.0/24"));
            Assert.That(wireAddressSpace.GetProperty("ipamPoolPrefixAllocations").GetArrayLength(), Is.EqualTo(1));

            var replacement = new VirtualNetworkAddressSpace();
            replacement.AddressPrefixes.Add("10.1.0.0/24");
            container.SetValue(model, replacement);
            Assert.That(flattened.GetValue(model), Is.SameAs(replacement.AddressPrefixes));
            container.SetValue(model, null);
            Assert.That((IList<string>)flattened.GetValue(model), Is.Empty);
            Assert.That(container.GetValue(model), Is.Not.Null);
        }

        [Test]
        public void VirtualHubIPConfigurationsUseWritableSubResources()
        {
            const string id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub/ipConfigurations/config";
            var model = ModelReaderWriter.Read<VirtualHubData>(
                BinaryData.FromString("""{"location":"westus","properties":{"ipConfigurations":[{"id":"RESOURCE_ID"}]}}"""
                    .Replace("RESOURCE_ID", id)));

            IReadOnlyList<WritableSubResource> configurations = model.IPConfigurations;
            Assert.That(configurations.Count, Is.EqualTo(1));
            Assert.That(configurations[0].Id, Is.EqualTo(new ResourceIdentifier(id)));
            Assert.That(model.IPConfigurations, Is.SameAs(configurations));
            Assert.That(new VirtualHubData().IPConfigurations, Is.Empty);

            using var persisted = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(persisted.RootElement.GetProperty("properties").GetProperty("ipConfigurations")[0].GetProperty("id").GetString(),
                Is.EqualTo(id));
            using var wire = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.GetProperty("properties").TryGetProperty("ipConfigurations", out _), Is.False);
        }

        [Test]
        public void GatewayDefaultSiteUsesWritableSubResource()
        {
            const string id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/localNetworkGateways/site";
            var model = ModelReaderWriter.Read<VirtualNetworkGatewayData>(
                BinaryData.FromString("""{"location":"westus","properties":{"gatewayDefaultSite":{"id":"RESOURCE_ID"}}}"""
                    .Replace("RESOURCE_ID", id)));

            WritableSubResource site = model.GatewayDefaultSite;
            Assert.That(site.Id, Is.EqualTo(new ResourceIdentifier(id)));
            Assert.That(model.GatewayDefaultSiteId, Is.EqualTo(site.Id));
            var replacement = new WritableSubResource { Id = new ResourceIdentifier(id + "2") };
            model.GatewayDefaultSite = replacement;
            Assert.That(model.GatewayDefaultSite, Is.SameAs(replacement));
            Assert.That(model.GatewayDefaultSiteId, Is.EqualTo(replacement.Id));
            model.GatewayDefaultSiteId = new ResourceIdentifier(id + "3");
            Assert.That(replacement.Id, Is.EqualTo(model.GatewayDefaultSiteId));

            using var wire = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.GetProperty("properties").GetProperty("gatewayDefaultSite").GetProperty("id").GetString(),
                Is.EqualTo(id + "3"));
            model.GatewayDefaultSite = null;
            Assert.That(model.GatewayDefaultSiteId, Is.Null);
            model.GatewayDefaultSiteId = new ResourceIdentifier(id);
            Assert.That(model.GatewayDefaultSite.Id, Is.EqualTo(new ResourceIdentifier(id)));
        }

        [Test]
        public void PeeringRemoteVirtualNetworkUsesWritableSubResource()
        {
            const string id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/remote";
            var model = ModelReaderWriter.Read<VirtualNetworkPeeringData>(
                BinaryData.FromString("""{"properties":{"remoteVirtualNetwork":{"id":"RESOURCE_ID"}}}"""
                    .Replace("RESOURCE_ID", id)));

            WritableSubResource remote = model.RemoteVirtualNetwork;
            Assert.That(remote.Id, Is.EqualTo(new ResourceIdentifier(id)));
            Assert.That(model.RemoteVirtualNetworkId, Is.EqualTo(remote.Id));
            var replacement = new WritableSubResource { Id = new ResourceIdentifier(id + "2") };
            model.RemoteVirtualNetwork = replacement;
            Assert.That(model.RemoteVirtualNetwork, Is.SameAs(replacement));
            Assert.That(model.RemoteVirtualNetworkId, Is.EqualTo(replacement.Id));
            model.RemoteVirtualNetworkId = new ResourceIdentifier(id + "3");
            Assert.That(replacement.Id, Is.EqualTo(model.RemoteVirtualNetworkId));

            using var wire = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.GetProperty("properties").GetProperty("remoteVirtualNetwork").GetProperty("id").GetString(),
                Is.EqualTo(id + "3"));
            model.RemoteVirtualNetwork = null;
            Assert.That(model.RemoteVirtualNetworkId, Is.Null);
            model.RemoteVirtualNetworkId = new ResourceIdentifier(id);
            Assert.That(model.RemoteVirtualNetwork.Id, Is.EqualTo(new ResourceIdentifier(id)));
        }

        [TestCase(typeof(ApplicationGatewayBackendSettings), "EnableL4ClientIPPreservation", "IsL4ClientIPPreservationEnabled")]
        [TestCase(typeof(ApplicationGatewayBackendSettings), "EnableL4ClientIpPreservation", "IsL4ClientIPPreservationEnabled")]
        [TestCase(typeof(ApplicationGatewayBackendSettings), "Timeout", "TimeoutInSeconds")]
        [TestCase(typeof(ApplicationGatewayProbe), "Interval", "IntervalInSeconds")]
        [TestCase(typeof(ApplicationGatewayProbe), "Timeout", "TimeoutInSeconds")]
        [TestCase(typeof(ApplicationGatewayProbe), "EnableProbeProxyProtocolHeader", "IsProbeProxyProtocolHeaderEnabled")]
        [TestCase(typeof(VirtualNetworkData), "PrivateEndpointVNetPolicies", "PrivateEndpointVnetPolicy")]
        [TestCase(typeof(VirtualNetworkEncryption), "Enabled", "IsEnabled")]
        [TestCase(typeof(RoutingRuleRouteDestination), "Type", "DestinationType")]
        public void LegacyNamesAreHiddenAliases(Type modelType, string legacyName, string preferredName)
        {
            var legacy = modelType.GetProperty(legacyName);
            var preferred = modelType.GetProperty(preferredName);
            Assert.That(legacy, Is.Not.Null);
            Assert.That(preferred, Is.Not.Null);
            Assert.That(legacy.GetCustomAttribute<ObsoleteAttribute>(), Is.Not.Null);
            Assert.That(legacy.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(preferred.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(legacy.PropertyType, Is.EqualTo(preferred.PropertyType));
            Assert.That(legacy.CanWrite, Is.EqualTo(preferred.CanWrite));
        }

        [Test]
        public void BackendSettingsNamesPreserveWireValues()
        {
            var model = ModelReaderWriter.Read<ApplicationGatewayBackendSettings>(
                BinaryData.FromString("""{"properties":{"enableL4ClientIpPreservation":true,"timeout":30}}"""));
            Assert.That(model.IsL4ClientIPPreservationEnabled, Is.True);
            Assert.That(model.TimeoutInSeconds, Is.EqualTo(30));

#pragma warning disable CS0618
            model.EnableL4ClientIPPreservation = false;
            model.Timeout = 45;
            Assert.That(model.EnableL4ClientIpPreservation, Is.False);
#pragma warning restore CS0618

            Assert.That(model.IsL4ClientIPPreservationEnabled, Is.False);
            Assert.That(model.TimeoutInSeconds, Is.EqualTo(45));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            var properties = json.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("enableL4ClientIpPreservation").GetBoolean(), Is.False);
            Assert.That(properties.GetProperty("timeout").GetInt32(), Is.EqualTo(45));
            Assert.That(properties.TryGetProperty("isL4ClientIPPreservationEnabled", out _), Is.False);
        }

        [TestCase(typeof(CustomIPPrefixData), "CustomIPPrefixParent", "ParentCustomIPPrefixId", "customIpPrefixParent")]
        [TestCase(typeof(ExpressRouteCircuitPeeringData), "ExpressRouteConnection", "ExpressRouteConnectionId", "expressRouteConnection")]
        [TestCase(typeof(ExpressRouteConnectionData), "ExpressRouteCircuitPeering", "ExpressRouteCircuitPeeringId", "expressRouteCircuitPeering")]
        [TestCase(typeof(ExpressRouteCrossConnectionData), "ExpressRouteCircuit", "ExpressRouteCircuitId", "expressRouteCircuit")]
        [TestCase(typeof(ExpressRouteGatewayData), "VirtualHub", "VirtualHubId", "virtualHub")]
        [TestCase(typeof(ApplicationGatewayRequestRoutingRule), "EntraJWTValidationConfig", "EntraJwtValidationConfigId", "entraJWTValidationConfig")]
        [TestCase(typeof(LoadBalancerBackendAddress), "LoadBalancerFrontendIPConfiguration", "LoadBalancerFrontendIPConfigurationId", "loadBalancerFrontendIPConfiguration")]
        public void ResourceReferenceAliasesPreserveWireShape(Type modelType, string legacyName, string preferredName, string wireName)
        {
            const string parentId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/customIPPrefixes/parent";
            var model = ModelReaderWriter.Read(
                BinaryData.FromString("""{"location":"westus","properties":{"WIRE_NAME":{"id":"RESOURCE_ID"}}}"""
                    .Replace("WIRE_NAME", wireName).Replace("RESOURCE_ID", parentId)), modelType);
            var preferred = modelType.GetProperty(preferredName);
            var legacy = modelType.GetProperty(legacyName);
            Assert.That(preferred.GetValue(model), Is.EqualTo(new ResourceIdentifier(parentId)));
            var legacyValue = legacy.GetValue(model);
            Assert.That(legacyValue is CustomIPPrefixData prefix ? prefix.Id : legacyValue, Is.EqualTo(preferred.GetValue(model)));
            var expectedId = parentId;
            if (legacy.CanWrite)
            {
                expectedId += "2";
                object value = legacy.PropertyType == typeof(CustomIPPrefixData)
                    ? new CustomIPPrefixData { Id = new ResourceIdentifier(expectedId) }
                    : new ResourceIdentifier(expectedId);
                legacy.SetValue(model, value);
                Assert.That(preferred.GetValue(model), Is.EqualTo(new ResourceIdentifier(expectedId)));
            }

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty(wireName).GetProperty("id").GetString(),
                Is.EqualTo(expectedId));
        }

        [Test]
        public void FlattenedDnsServersPreserveWireValues()
        {
            var model = ModelReaderWriter.Read<VirtualNetworkData>(
                BinaryData.FromString("""{"location":"westus","properties":{"dhcpOptions":{"dnsServers":["10.0.0.1"]}}}"""));
            Assert.That(model.DhcpOptionsDnsServers, Is.EqualTo(new[] { "10.0.0.1" }));
            model.DhcpOptionsDnsServers.Add("10.0.0.2");

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            var servers = json.RootElement.GetProperty("properties").GetProperty("dhcpOptions").GetProperty("dnsServers");
            Assert.That(servers.GetArrayLength(), Is.EqualTo(2));
            Assert.That(servers[1].GetString(), Is.EqualTo("10.0.0.2"));
        }

        [Test]
        public void RequiredRenamedPropertiesDeserializeAndPreserveUnknownValues()
        {
            var encryption = ModelReaderWriter.Read<VirtualNetworkEncryption>(
                BinaryData.FromString("""{"enabled":true,"enforcement":"AllowUnencrypted","future":"value"}"""));
            Assert.That(encryption.IsEnabled, Is.True);
#pragma warning disable CS0618
            encryption.Enabled = false;
#pragma warning restore CS0618
            using var encryptionJson = JsonDocument.Parse(ModelReaderWriter.Write(encryption));
            Assert.That(encryptionJson.RootElement.GetProperty("enabled").GetBoolean(), Is.False);
            Assert.That(encryptionJson.RootElement.GetProperty("enforcement").GetString(), Is.EqualTo("AllowUnencrypted"));
            Assert.That(encryptionJson.RootElement.GetProperty("future").GetString(), Is.EqualTo("value"));

            var destination = ModelReaderWriter.Read<RoutingRuleRouteDestination>(
                BinaryData.FromString("""{"type":"IPAddress","destinationAddress":"10.0.0.1","future":"value"}"""));
            Assert.That(destination.DestinationType.ToString(), Is.EqualTo("IPAddress"));
            Assert.That(destination.DestinationAddress, Is.EqualTo("10.0.0.1"));
#pragma warning disable CS0618
            destination.Type = new RoutingRuleDestinationType("ServiceTag");
#pragma warning restore CS0618
            using var destinationJson = JsonDocument.Parse(ModelReaderWriter.Write(destination));
            Assert.That(destinationJson.RootElement.GetProperty("type").GetString(), Is.EqualTo("ServiceTag"));
            Assert.That(destinationJson.RootElement.GetProperty("future").GetString(), Is.EqualTo("value"));
        }
    }
}
