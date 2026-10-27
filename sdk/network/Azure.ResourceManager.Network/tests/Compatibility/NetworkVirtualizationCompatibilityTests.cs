// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

#pragma warning disable CS0618 // Verify the released obsolete APIs.

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkVirtualizationCompatibilityTests
    {
        private const string ReferenceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet";

        [TestCase("GetNetworkInterfaceLoadBalancers", typeof(Pageable<LoadBalancerResource>))]
        [TestCase("GetNetworkInterfaceLoadBalancersAsync", typeof(AsyncPageable<LoadBalancerResource>))]
        public void NetworkInterfaceLoadBalancerMethodsKeepReleasedNamesAndSignatures(string methodName, Type returnType)
        {
            MethodInfo method = typeof(NetworkInterfaceResource).GetMethod(
                methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly,
                null, new[] { typeof(CancellationToken) }, null);
            Assert.That(method, Is.Not.Null);
            Assert.That(method.ReturnType, Is.EqualTo(returnType));
            Assert.That(method.IsVirtual, Is.True);
            Assert.That(method.IsFinal, Is.False);
            Assert.That(method.GetParameters()[0].IsOptional, Is.True);
        }

        [Test]
        public void FirewallRuleCollectionProxyKeepsReleasedTypeName()
        {
            Type modelType = typeof(FirewallPolicyRuleCollectionInfo);
            CustomAttributeData proxy = modelType.GetCustomAttributesData().Single(
                attribute => attribute.AttributeType == typeof(PersistableModelProxyAttribute));
            Type proxyType = (Type)proxy.ConstructorArguments[0].Value;
            Assert.That(proxyType.Name, Is.EqualTo("UnknownFirewallPolicyRuleCollection"));
            Assert.That(proxyType.IsNotPublic, Is.True);
            Assert.That(proxyType.BaseType, Is.EqualTo(modelType));
            Assert.That(modelType.Assembly.GetType("Azure.ResourceManager.Network.Models.UnknownFirewallPolicyRuleCollectionInfo"), Is.Null);
        }

        [Test]
        public void WritableResourceBaseKeepsReleasedStandaloneShape()
        {
            Type modelType = typeof(NetworkWritableResourceData);
            Assert.That(modelType.BaseType, Is.EqualTo(typeof(object)));
            Assert.That(modelType.Assembly.GetType("Azure.ResourceManager.Network.Models.NetworkWritableResource"), Is.Null);
            foreach (string propertyName in new[] { "Id", "Name", "ResourceType" })
            {
                PropertyInfo property = modelType.GetProperty(propertyName);
                Assert.That(property.DeclaringType, Is.EqualTo(modelType));
                Assert.That(property.GetMethod.IsPublic, Is.True);
                Assert.That(property.SetMethod.IsPublic, Is.True);
            }
            MethodInfo writer = modelType.GetMethod("JsonModelWriteCore", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            Assert.That(writer, Is.Not.Null);
            Assert.That(writer.IsVirtual, Is.True);
            Assert.That(writer.IsFinal, Is.False);
            Assert.That(writer.GetBaseDefinition().DeclaringType, Is.EqualTo(modelType));
        }

        [TestCase(typeof(NetworkInterfaceIPConfigurationData))]
        [TestCase(typeof(RouteData))]
        [TestCase(typeof(SecurityRuleData))]
        [TestCase(typeof(SubnetData))]
        [TestCase(typeof(VirtualNetworkPeeringData))]
        [TestCase(typeof(ServiceDelegation))]
        [TestCase(typeof(PolicySignaturesOverridesForIdpsData))]
        public void WritableResourcesUseTheSharedNativeBase(Type modelType)
        {
            Assert.That(modelType.BaseType, Is.EqualTo(typeof(NetworkWritableResourceData)));
        }

        [TestCase(typeof(NetworkWritableResourceData))]
        [TestCase(typeof(NetworkInterfaceIPConfigurationData))]
        [TestCase(typeof(RouteData))]
        [TestCase(typeof(SecurityRuleData))]
        [TestCase(typeof(SubnetData))]
        [TestCase(typeof(VirtualNetworkPeeringData))]
        [TestCase(typeof(ServiceDelegation))]
        [TestCase(typeof(PolicySignaturesOverridesForIdpsData))]
        public void WritableResourceHierarchyKeepsNativeMetadataWireStorage(Type modelType)
        {
            foreach (string format in new[] { "J", "W" })
            {
                var options = new ModelReaderWriterOptions(format);
                object model = ModelReaderWriter.Read(BinaryData.FromString(
                    $$$"""{"id":"{{{ReferenceId}}}","name":"before","type":"Microsoft.Network/virtualNetworks","futureMetadata":19}"""), modelType, options);
                modelType.GetProperty("Id").SetValue(model, new ResourceIdentifier(ReferenceId + "/child"));
                modelType.GetProperty("Name").SetValue(model, "after");
                modelType.GetProperty("ResourceType").SetValue(model, new ResourceType("Microsoft.Network/virtualNetworks/subnets"));
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
                Assert.That(json.RootElement.GetProperty("id").GetString(), Is.EqualTo(ReferenceId + "/child"));
                Assert.That(json.RootElement.GetProperty("name").GetString(), Is.EqualTo("after"));
                Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo("Microsoft.Network/virtualNetworks/subnets"));
                bool hasUnknownField = json.RootElement.TryGetProperty("futureMetadata", out JsonElement unknownField);
                Assert.That(hasUnknownField, Is.EqualTo(format == "J"));
                if (hasUnknownField)
                    Assert.That(unknownField.GetInt32(), Is.EqualTo(19));
            }
        }

        [TestCase(typeof(BastionHostResource), "Update", typeof(BastionHostData))]
        [TestCase(typeof(BastionHostResource), "UpdateAsync", typeof(BastionHostData))]
        [TestCase(typeof(VirtualHubResource), "GetEffectiveVirtualHubRoutes", typeof(EffectiveRoutesContent))]
        [TestCase(typeof(VirtualHubResource), "GetEffectiveVirtualHubRoutesAsync", typeof(EffectiveRoutesContent))]
        [TestCase(typeof(VirtualHubResource), "GetInboundRoutes", typeof(VirtualHubInboundRoutesContent))]
        [TestCase(typeof(VirtualHubResource), "GetInboundRoutesAsync", typeof(VirtualHubInboundRoutesContent))]
        [TestCase(typeof(VirtualHubResource), "GetOutboundRoutes", typeof(VirtualHubOutboundRoutesContent))]
        [TestCase(typeof(VirtualHubResource), "GetOutboundRoutesAsync", typeof(VirtualHubOutboundRoutesContent))]
        [TestCase(typeof(VirtualNetworkGatewayConnectionResource), "StartPacketCapture", typeof(VpnPacketCaptureStartParameters))]
        [TestCase(typeof(VirtualNetworkGatewayConnectionResource), "StartPacketCaptureAsync", typeof(VpnPacketCaptureStartParameters))]
        [TestCase(typeof(VirtualNetworkGatewayConnectionResource), "StopPacketCapture", typeof(VpnPacketCaptureStopParameters))]
        [TestCase(typeof(VirtualNetworkGatewayConnectionResource), "StopPacketCaptureAsync", typeof(VpnPacketCaptureStopParameters))]
        [TestCase(typeof(VirtualNetworkGatewayResource), "Generatevpnclientpackage", typeof(VpnClientParameters))]
        [TestCase(typeof(VirtualNetworkGatewayResource), "GeneratevpnclientpackageAsync", typeof(VpnClientParameters))]
        [TestCase(typeof(VirtualNetworkGatewayResource), "GenerateVpnProfile", typeof(VpnClientParameters))]
        [TestCase(typeof(VirtualNetworkGatewayResource), "GenerateVpnProfileAsync", typeof(VpnClientParameters))]
        [TestCase(typeof(VirtualNetworkGatewayResource), "StartPacketCapture", typeof(VpnPacketCaptureStartParameters))]
        [TestCase(typeof(VirtualNetworkGatewayResource), "StartPacketCaptureAsync", typeof(VpnPacketCaptureStartParameters))]
        [TestCase(typeof(VirtualNetworkGatewayResource), "StopPacketCapture", typeof(VpnPacketCaptureStopParameters))]
        [TestCase(typeof(VirtualNetworkGatewayResource), "StopPacketCaptureAsync", typeof(VpnPacketCaptureStopParameters))]
        public void LegacyOperationObsoleteMessagesMatchReleasedMetadata(Type resourceType, string methodName, Type contentType)
        {
            MethodInfo method = resourceType.GetMethod(methodName, new[] { typeof(WaitUntil), contentType, typeof(CancellationToken) });
            Assert.That(method, Is.Not.Null);
            ObsoleteAttribute obsolete = method.GetCustomAttribute<ObsoleteAttribute>();
            Assert.That(obsolete, Is.Not.Null);
            Assert.That(obsolete.Message, Is.EqualTo("This method is obsolete and will be removed in a future release"));
            Assert.That(obsolete.IsError, Is.False);
        }

        [TestCase(typeof(DdosCustomPolicyData), "ProtocolCustomSettings", "This property is obsolete and will be removed in a future release")]
        [TestCase(typeof(EffectiveNetworkSecurityGroup), "TagMap", "This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead")]
        [TestCase(typeof(DdosSettings), "ProtectedIP", "This property is obsolete and might be removed in a future version, please use `ProtectionMode` instead")]
        [TestCase(typeof(DdosSettings), "ProtectionCoverage", "This property is obsolete and might be removed in a future version")]
        public void LegacyPropertyObsoleteMessagesPreserveReleasedPatternWithoutIncorrectGuidance(Type modelType, string propertyName, string expectedMessage)
        {
            PropertyInfo property = modelType.GetProperty(propertyName);
            Assert.That(property, Is.Not.Null);
            ObsoleteAttribute obsolete = property.GetCustomAttribute<ObsoleteAttribute>();
            Assert.That(obsolete, Is.Not.Null);
            Assert.That(obsolete.Message, Is.EqualTo(expectedMessage));
            Assert.That(obsolete.IsError, Is.False);
        }

        [TestCase(typeof(DdosSettingsProtectionCoverage), "This struct is obsolete and will be removed in a future release")]
        [TestCase(typeof(ProtocolCustomSettings), "This class is obsolete and will be removed in a future release")]
        public void LegacyTypeObsoleteMessagesMatchReleasedMetadata(Type modelType, string expectedMessage)
        {
            ObsoleteAttribute obsolete = modelType.GetCustomAttribute<ObsoleteAttribute>();
            Assert.That(obsolete, Is.Not.Null);
            Assert.That(obsolete.Message, Is.EqualTo(expectedMessage));
            Assert.That(obsolete.IsError, Is.False);
        }

        [TestCase(typeof(DdosCustomPolicyData), "PublicIPAddresses")]
        [TestCase(typeof(DdosSettings), "DdosCustomPolicyId")]
        public void GeneratedDdosPropertiesHaveNoCustomVisibilityOrDeprecation(Type modelType, string propertyName)
        {
            PropertyInfo property = modelType.GetProperty(propertyName);
            Assert.That(property, Is.Not.Null);
            Assert.That(property.GetCustomAttribute<EditorBrowsableAttribute>(), Is.Null);
            Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
        }

        [TestCase(typeof(FirewallPolicyData), "SnatPrivateRanges")]
        [TestCase(typeof(ApplicationGatewaySslProfile), "VerifyClientCertIssuerDN")]
        public void SupportedCompatibilityPropertiesAreHiddenWithoutDeprecation(Type modelType, string propertyName)
        {
            PropertyInfo property = modelType.GetProperty(propertyName);
            Assert.That(property, Is.Not.Null);
            EditorBrowsableAttribute visibility = property.GetCustomAttribute<EditorBrowsableAttribute>();
            Assert.That(visibility, Is.Not.Null);
            Assert.That(visibility.State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
        }

        [Test]
        public void GeneratedDdosPolicyReferencesKeepNativeWireStorage()
        {
            var policy = ModelReaderWriter.Read<DdosCustomPolicyData>(BinaryData.FromString(
                $$$"""{"properties":{"publicIPAddresses":[{"id":"{{{ReferenceId}}}"}] } }"""));
            Assert.That(policy.PublicIPAddresses.Count, Is.EqualTo(1));
            Assert.That(policy.PublicIPAddresses[0].Id.ToString(), Is.EqualTo(ReferenceId));
            policy.PublicIPAddresses[0].Id = new ResourceIdentifier(ReferenceId + "2");
            foreach (string format in new[] { "J", "W" })
            {
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(policy, new ModelReaderWriterOptions(format)));
                JsonElement properties = json.RootElement.GetProperty("properties");
                bool included = properties.TryGetProperty("publicIPAddresses", out JsonElement references);
                if (format == "J")
                {
                    Assert.That(included, Is.True);
                    Assert.That(references[0].GetProperty("id").GetString(), Is.EqualTo(ReferenceId + "2"));
                }
                else
                {
                    Assert.That(included, Is.False);
                }
            }
        }

        [Test]
        public void GeneratedDdosPolicyIdentifierPreservesItsParentAndNullHandling()
        {
            var settings = ModelReaderWriter.Read<DdosSettings>(BinaryData.FromString(
                $$$"""{"ddosCustomPolicy":{"id":"{{{ReferenceId}}}","futureSetting":17} }"""));
            Assert.That(settings.DdosCustomPolicyId.ToString(), Is.EqualTo(ReferenceId));
            settings.DdosCustomPolicyId = new ResourceIdentifier(ReferenceId + "2");
            foreach (string format in new[] { "J", "W" })
            {
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(settings, new ModelReaderWriterOptions(format)));
                JsonElement reference = json.RootElement.GetProperty("ddosCustomPolicy");
                Assert.That(reference.GetProperty("id").GetString(), Is.EqualTo(ReferenceId + "2"));
                if (format == "J")
                    Assert.That(reference.GetProperty("futureSetting").GetInt32(), Is.EqualTo(17));
            }
            settings.DdosCustomPolicyId = null;
            Assert.That(settings.DdosCustomPolicyId, Is.Null);
            var empty = new DdosSettings();
            Assert.That(empty.DdosCustomPolicyId, Is.Null);
            empty.DdosCustomPolicyId = null;
            Assert.That(empty.DdosCustomPolicyId, Is.Null);
        }

        [Test]
        public void ReleasedNamedArgumentsCompileAndPreserveForwarding()
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000001";
            ResourceIdentifier swap = CloudServiceSwapResource.CreateResourceIdentifier(
                subscriptionId: subscriptionId, groupName: "rg", resourceName: "cloud");
            Assert.That(swap, Is.EqualTo(CloudServiceSwapResource.CreateResourceIdentifier(subscriptionId, "rg", "cloud", "default")));
            var id = new ResourceIdentifier(ReferenceId);
            var uri = new Uri("https://storage.example/container/");
            var troubleshooting = new TroubleshootingContent(targetResourceId: id, storageId: id, storageUri: uri);
            Assert.That(troubleshooting.StoragePath, Is.EqualTo(uri.AbsoluteUri));
            var connection = new VirtualNetworkGatewayConnectionListEntity(
                virtualNetworkGateway1: new WritableSubResource { Id = id },
                connectionType: VirtualNetworkGatewayConnectionType.IPsec);
            Assert.That(connection.VirtualNetworkGateway1Id, Is.EqualTo(id));
            Assert.That(connection.VirtualNetworkGateway2Id, Is.Null);
            Assert.That(connection.LocalNetworkGateway2Id, Is.Null);
            Assert.That(connection.ConnectionType, Is.EqualTo(VirtualNetworkGatewayConnectionType.IPsec));
            foreach (string format in new[] { "J", "W" })
            {
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(connection, new ModelReaderWriterOptions(format)));
                JsonElement properties = json.RootElement.GetProperty("properties");
                Assert.That(properties.GetProperty("virtualNetworkGateway1").GetProperty("id").GetString(), Is.EqualTo(ReferenceId));
                Assert.That(properties.TryGetProperty("virtualNetworkGateway2", out _), Is.False);
                Assert.That(properties.TryGetProperty("localNetworkGateway2", out _), Is.False);
            }
        }

        [Test]
        public void ConnectionListConstructorPreservesReleasedValidationAndCollections()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new VirtualNetworkGatewayConnectionListEntity(
                virtualNetworkGateway1: null, connectionType: VirtualNetworkGatewayConnectionType.IPsec));
            Assert.That(exception.ParamName, Is.EqualTo("virtualNetworkGateway1"));
            var connection = new VirtualNetworkGatewayConnectionListEntity(
                virtualNetworkGateway1: new WritableSubResource(), connectionType: VirtualNetworkGatewayConnectionType.IPsec);
            Assert.That(connection.VirtualNetworkGateway1Id, Is.Null);
            Assert.That(connection.LocalNetworkGateway2Id, Is.Null);
            Assert.That(connection.ConnectionType, Is.EqualTo(VirtualNetworkGatewayConnectionType.IPsec));
            Assert.That(connection.TunnelConnectionStatus, Is.Empty);
            Assert.That(connection.GatewayCustomBgpIPAddresses, Is.Empty);
            Assert.That(connection.IPsecPolicies, Is.Empty);
            Assert.That(connection.TrafficSelectorPolicies, Is.Empty);
        }

        [Test]
        public void ReleasedInboundRuleConversionParameterAndBehaviorArePreserved()
        {
            Type legacyType = typeof(InboundSecurityRuleData).Assembly.GetType("Azure.ResourceManager.Network.Models.InboundSecurityRule");
            MethodInfo conversion = legacyType.GetMethod("op_Implicit", BindingFlags.Public | BindingFlags.Static);
            Assert.That(conversion.GetParameters()[0].Name, Is.EqualTo("r"));
            Assert.That(conversion.Invoke(null, new object[] { null }), Is.Null);
            object legacy = Activator.CreateInstance(legacyType);
            var converted = (InboundSecurityRuleData)conversion.Invoke(null, new[] { legacy });
            Assert.That(converted, Is.Not.Null);
            Assert.That(typeof(InboundSecurityRuleData).GetProperty("Rules").GetValue(converted),
                Is.SameAs(legacyType.GetProperty("Rules").GetValue(legacy)));
        }

        [TestCase(typeof(VirtualHubData), "BgpConnections", "bgpConnections")]
        [TestCase(typeof(VirtualHubData), "RouteMaps", "routeMaps")]
        [TestCase(typeof(VirtualNetworkGatewayPolicyGroup), "VngClientConnectionConfigurations", "vngClientConnectionConfigurations")]
        [TestCase(typeof(VirtualRouterData), "Peerings", "peerings")]
        [TestCase(typeof(VirtualWanData), "VirtualHubs", "virtualHubs")]
        [TestCase(typeof(VirtualWanData), "VpnSites", "vpnSites")]
        [TestCase(typeof(VpnGatewayNatRuleData), "EgressVpnSiteLinkConnections", "egressVpnSiteLinkConnections")]
        [TestCase(typeof(VpnGatewayNatRuleData), "IngressVpnSiteLinkConnections", "ingressVpnSiteLinkConnections")]
        [TestCase(typeof(VpnServerConfigurationPolicyGroupData), "P2SConnectionConfigurations", "p2SConnectionConfigurations")]
        [TestCase(typeof(WebApplicationFirewallPolicyData), "HttpListeners", "httpListeners")]
        [TestCase(typeof(WebApplicationFirewallPolicyData), "PathBasedRules", "pathBasedRules")]
        public void NativeReadOnlyReferencesUseTheReleasedElementsAndRealStorage(Type modelType, string propertyName, string wireName)
        {
            object model = ModelReaderWriter.Read(BinaryData.FromString(
                $$$"""{"properties":{"{{{wireName}}}":[{"id":"{{{ReferenceId}}}"}] } }"""), modelType);
            var references = (IReadOnlyList<WritableSubResource>)modelType.GetProperty(propertyName).GetValue(model);
            Assert.That(references.Count, Is.EqualTo(1));
            Assert.That(references[0].Id.ToString(), Is.EqualTo(ReferenceId));
            references[0].Id = new ResourceIdentifier(ReferenceId + "2");
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty(wireName)[0].GetProperty("id").GetString(), Is.EqualTo(ReferenceId + "2"));
        }

        [TestCase(typeof(VirtualNetworkData), "IPAllocations", "ipAllocations")]
        [TestCase(typeof(VirtualNetworkGatewayConnectionData), "EgressNatRules", "egressNatRules")]
        [TestCase(typeof(VirtualNetworkGatewayConnectionData), "IngressNatRules", "ingressNatRules")]
        public void NativeWritableReferenceCollectionsSerializeMutations(Type modelType, string propertyName, string wireName)
        {
            object model = ModelReaderWriter.Read(BinaryData.FromString(
                $$$"""{"properties":{"{{{wireName}}}":[{"id":"{{{ReferenceId}}}"}] } }"""), modelType);
            var references = (IList<WritableSubResource>)modelType.GetProperty(propertyName).GetValue(model);
            references.Add(new WritableSubResource { Id = new ResourceIdentifier(ReferenceId + "2") });
            foreach (string format in new[] { "J", "W" })
            {
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions(format)));
                JsonElement list = json.RootElement.GetProperty("properties").GetProperty(wireName);
                Assert.That(list.GetArrayLength(), Is.EqualTo(2));
                Assert.That(list[1].GetProperty("id").GetString(), Is.EqualTo(ReferenceId + "2"));
            }
        }

        [Test]
        public void WafContainerReferencesAreNotDisconnected()
        {
            var policy = ModelReaderWriter.Read<WebApplicationFirewallPolicyData>(BinaryData.FromString(
                $$$"""{"properties":{"applicationGatewayForContainers":[{"id":"{{{ReferenceId}}}"}] } }"""));
            IReadOnlyList<SubResource> references = policy.ApplicationGatewayForContainers;
            Assert.That(references[0].Id.ToString(), Is.EqualTo(ReferenceId));
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(policy));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("applicationGatewayForContainers")[0].GetProperty("id").GetString(), Is.EqualTo(ReferenceId));
        }

        [TestCase(typeof(VirtualNetworkData), "AddressPrefixes", "AddressSpace", "addressSpace")]
        [TestCase(typeof(VpnSiteData), "AddressPrefixes", "AddressSpace", "addressSpace")]
        [TestCase(typeof(VirtualNetworkGatewayData), "CustomRoutesAddressPrefixes", "CustomRoutes", "customRoutes")]
        public void RetainedAddressPrefixFacadesShareNativeStorage(Type modelType, string facadeName, string nativeName, string wireName)
        {
            object model = ModelReaderWriter.Read(BinaryData.FromString(
                $$$"""{"properties":{"{{{wireName}}}":{"addressPrefixes":["10.0.0.0/24"],"futureSetting":17} } }"""), modelType);
            var prefixes = (IList<string>)modelType.GetProperty(facadeName).GetValue(model);
            var addressSpace = (VirtualNetworkAddressSpace)modelType.GetProperty(nativeName).GetValue(model);
            Assert.That(prefixes, Is.SameAs(addressSpace.AddressPrefixes));
            prefixes.Add("10.0.1.0/24");
            foreach (string format in new[] { "J", "W" })
            {
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions(format)));
                JsonElement wrapper = json.RootElement.GetProperty("properties").GetProperty(wireName);
                Assert.That(wrapper.GetProperty("addressPrefixes").GetArrayLength(), Is.EqualTo(2));
                if (format == "J")
                    Assert.That(wrapper.GetProperty("futureSetting").GetInt32(), Is.EqualTo(17));
            }
        }

        [Test]
        public void NativeRouteTableETagAndHiddenGatewayIdentifierUseRealStorage()
        {
            var routeTable = ModelReaderWriter.Read<VirtualHubRouteTableV2Data>(BinaryData.FromString(
                """{"etag":"tag","properties":{}}"""));
            Assert.That(routeTable.ETag, Is.EqualTo(new ETag("tag")));
            using JsonDocument routeTableJson = JsonDocument.Parse(ModelReaderWriter.Write(routeTable));
            Assert.That(routeTableJson.RootElement.GetProperty("etag").GetString(), Is.EqualTo("tag"));
            var gateway = new VirtualNetworkGatewayData { GatewayDefaultSiteId = new ResourceIdentifier(ReferenceId) };
            foreach (string format in new[] { "J", "W" })
            {
                using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(gateway, new ModelReaderWriterOptions(format)));
                Assert.That(json.RootElement.GetProperty("properties").GetProperty("gatewayDefaultSite").GetProperty("id").GetString(), Is.EqualTo(ReferenceId));
            }
        }

        [Test]
        public void NativeNamesAndRoutingConfigurationUseRealWireStorage()
        {
            var appliance = new VirtualNetworkApplianceData { BandwidthInGbps = "100.0" };
            var hub = new VirtualHubData();
            hub.Routes.Add(new VirtualHubRoute());
            var gateway = new VirtualNetworkGatewayData { IsActive = true };
            var connection = new VpnConnectionData
            {
                RoutingConfiguration = ModelReaderWriter.Read<RoutingConfiguration>(BinaryData.FromString(
                    $$$"""{"associatedRouteTable":{"id":"{{{ReferenceId}}}"} }"""))
            };
            foreach (string format in new[] { "J", "W" })
            {
                var options = new ModelReaderWriterOptions(format);
                using JsonDocument applianceJson = JsonDocument.Parse(ModelReaderWriter.Write(appliance, options));
                Assert.That(applianceJson.RootElement.GetProperty("properties").GetProperty("bandwidthInGbps").GetString(), Is.EqualTo("100.0"));
                using JsonDocument hubJson = JsonDocument.Parse(ModelReaderWriter.Write(hub, options));
                Assert.That(hubJson.RootElement.GetProperty("properties").GetProperty("routeTable").GetProperty("routes").GetArrayLength(), Is.EqualTo(1));
                using JsonDocument gatewayJson = JsonDocument.Parse(ModelReaderWriter.Write(gateway, options));
                Assert.That(gatewayJson.RootElement.GetProperty("properties").GetProperty("activeActive").GetBoolean(), Is.True);
                using JsonDocument connectionJson = JsonDocument.Parse(ModelReaderWriter.Write(connection, options));
                Assert.That(connectionJson.RootElement.GetProperty("properties").GetProperty("routingConfiguration").GetProperty("associatedRouteTable").GetProperty("id").GetString(), Is.EqualTo(ReferenceId));
            }
        }

        [Test]
        public void GatewayActiveAliasSharesNativeStorageAndKeepsTheWireName()
        {
            PropertyInfo legacy = typeof(VirtualNetworkGatewayData).GetProperty("Active");
            Assert.That(legacy.PropertyType, Is.EqualTo(typeof(bool?)));
            Assert.That(legacy.GetCustomAttribute<ObsoleteAttribute>()?.Message, Does.Contain("IsActive"));
            Assert.That(legacy.GetCustomAttribute<System.ComponentModel.EditorBrowsableAttribute>()?.State,
                Is.EqualTo(System.ComponentModel.EditorBrowsableState.Never));
            Assert.That(typeof(VirtualNetworkGatewayData).GetProperty("IsActive").GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            var gateway = new VirtualNetworkGatewayData();
            foreach (bool? value in new bool?[] { true, false, null })
            {
                legacy.SetValue(gateway, value);
                Assert.That(gateway.IsActive, Is.EqualTo(value));
                foreach (string format in new[] { "J", "W" })
                {
                    var options = new ModelReaderWriterOptions(format);
                    using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(gateway, options));
                    JsonElement properties = json.RootElement.GetProperty("properties");
                    Assert.That(properties.TryGetProperty("activeActive", out JsonElement active), Is.EqualTo(value.HasValue));
                    if (value.HasValue)
                        Assert.That(active.GetBoolean(), Is.EqualTo(value.Value));
                    Assert.That(properties.TryGetProperty("isActive", out _), Is.False);
                    Assert.That(properties.TryGetProperty("active", out _), Is.False);
                    var roundTrip = ModelReaderWriter.Read<VirtualNetworkGatewayData>(ModelReaderWriter.Write(gateway, options), options);
                    Assert.That(roundTrip.IsActive, Is.EqualTo(value));
                    Assert.That(legacy.GetValue(roundTrip), Is.EqualTo(value));
                }
                gateway.IsActive = value == true ? false : true;
                Assert.That(legacy.GetValue(gateway), Is.EqualTo(gateway.IsActive));
            }
        }

        [Test]
        public void GatewayFactoryActiveArgumentsReachNativeStorage()
        {
            int factories = 0;
            foreach (MethodInfo method in typeof(ArmNetworkModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                if (method.Name != nameof(ArmNetworkModelFactory.VirtualNetworkGatewayData))
                    continue;
                ParameterInfo[] parameters = method.GetParameters();
                int activeIndex = Array.FindIndex(parameters, parameter => parameter.Name is "active" or "isActive");
                Assert.That(activeIndex, Is.GreaterThanOrEqualTo(0));
                foreach (bool? value in new bool?[] { true, false, null })
                {
                    var arguments = new object[parameters.Length];
                    for (int index = 0; index < parameters.Length; index++)
                        arguments[index] = parameters[index].ParameterType.IsValueType
                            ? Activator.CreateInstance(parameters[index].ParameterType) : null;
                    arguments[activeIndex] = value;
                    var gateway = (VirtualNetworkGatewayData)method.Invoke(null, arguments);
                    Assert.That(gateway.IsActive, Is.EqualTo(value), method.ToString());
                }
                factories++;
            }
            Assert.That(factories, Is.EqualTo(5));
        }

        [Test]
        public void ReleasedApplianceFactoryForwardsStringBandwidthAndMetadata()
        {
            var appliance = ArmNetworkModelFactory.VirtualNetworkApplianceData(
                id: new ResourceIdentifier(ReferenceId),
                resourceType: new ResourceType("Microsoft.Network/virtualNetworkAppliances"),
                etag: new ETag("tag"),
                bandwidthInGbps: "100.0");
            Assert.That(appliance.BandwidthInGbps, Is.EqualTo("100.0"));
            Assert.That(appliance.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/virtualNetworkAppliances"));
            Assert.That(appliance.ETag, Is.EqualTo(new ETag("tag")));
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(appliance));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("bandwidthInGbps").GetString(), Is.EqualTo("100.0"));
        }

        [Test]
        public void UntypedRouteOperationPreservesNativePollingAndFailures()
        {
            var native = new RecordingRouteOperation();
            Type adapterType = typeof(VirtualHubResource).GetNestedType("UntypedRouteOperation", BindingFlags.NonPublic);
            var adapter = (ArmOperation)Activator.CreateInstance(adapterType, native);
            using var cancellation = new CancellationTokenSource();
            CancellationToken token = cancellation.Token;
            Assert.That(adapter.Id, Is.EqualTo(native.Id));
            Assert.That(adapter.HasCompleted, Is.False);
            adapter.GetRawResponse();
            Assert.That(native.LastCall, Is.EqualTo("raw"));
            adapter.GetRehydrationToken();
            Assert.That(native.LastCall, Is.EqualTo("token"));
            adapter.UpdateStatus(token);
            Assert.That(native.LastCall, Is.EqualTo("update"));
            adapter.UpdateStatusAsync(token).GetAwaiter().GetResult();
            Assert.That(native.LastCall, Is.EqualTo("updateAsync"));
            adapter.WaitForCompletionResponse(token);
            Assert.That(native.LastCall, Is.EqualTo("wait"));
            adapter.WaitForCompletionResponseAsync(token).GetAwaiter().GetResult();
            Assert.That(native.LastCall, Is.EqualTo("waitAsync"));
            adapter.WaitForCompletionResponse(TimeSpan.FromSeconds(7), token);
            Assert.That(native.LastInterval, Is.EqualTo(TimeSpan.FromSeconds(7)));
            adapter.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(11), token).GetAwaiter().GetResult();
            Assert.That(native.LastInterval, Is.EqualTo(TimeSpan.FromSeconds(11)));
            DelayStrategy strategy = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.FromSeconds(3));
            adapter.WaitForCompletionResponse(strategy, token);
            Assert.That(native.LastCall, Is.EqualTo("waitStrategy"));
            Assert.That(native.LastStrategy, Is.SameAs(strategy));
            adapter.WaitForCompletionResponseAsync(strategy, token).GetAwaiter().GetResult();
            Assert.That(native.LastCall, Is.EqualTo("waitStrategyAsync"));
            Assert.That(native.LastStrategy, Is.SameAs(strategy));
            Assert.That(native.LastToken, Is.EqualTo(token));
            Assert.That(adapter.HasCompleted, Is.True);
            var failure = new RequestFailedException(503, "Polling failed.");
            native.Failure = failure;
            Assert.That(Assert.Throws<RequestFailedException>(() => adapter.UpdateStatus(token)), Is.SameAs(failure));
            Assert.That(Assert.ThrowsAsync<RequestFailedException>(async () => await adapter.UpdateStatusAsync(token)), Is.SameAs(failure));
            native.Failure = null;
            cancellation.Cancel();
            Assert.Throws<OperationCanceledException>(() => adapter.UpdateStatus(token));
        }

        [TestCase(typeof(VirtualHubResource), 6)]
        [TestCase(typeof(VirtualNetworkGatewayConnectionResource), 4)]
        [TestCase(typeof(VirtualNetworkGatewayResource), 8)]
        [TestCase(typeof(VirtualWanResource), 2)]
        [TestCase(typeof(VpnGatewayResource), 2)]
        public void RetainedRedirectingOperationsDeclareForwardedClientCalls(Type resourceType, int expectedRedirects)
        {
            int redirects = 0;
            foreach (MethodInfo method in resourceType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                // The retained aliases are hidden; native operations remain visible.
                if (method.GetCustomAttribute<System.ComponentModel.EditorBrowsableAttribute>()?.State != System.ComponentModel.EditorBrowsableState.Never)
                    continue;
                Assert.That(Array.Exists(method.GetCustomAttributes(false), attribute => attribute.GetType().Name == "ForwardsClientCallsAttribute"), Is.True, method.Name);
                redirects++;
            }
            Assert.That(redirects, Is.EqualTo(expectedRedirects));
        }

        private sealed class RecordingRouteOperation : ArmOperation<VirtualHubEffectiveRouteList>
        {
            public string LastCall { get; private set; }
            public CancellationToken LastToken { get; private set; }
            public TimeSpan LastInterval { get; private set; }
            public DelayStrategy LastStrategy { get; private set; }
            public RequestFailedException Failure { get; set; }
            public override string Id => "route-operation";
            public override bool HasCompleted => LastToken != default;
            public override bool HasValue => HasCompleted;
            public override VirtualHubEffectiveRouteList Value => default;
            public override Response GetRawResponse() { LastCall = "raw"; return null; }
            public override RehydrationToken? GetRehydrationToken() { LastCall = "token"; return null; }
            public override Response UpdateStatus(CancellationToken cancellationToken = default)
                => Record("update", cancellationToken);
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
                => new ValueTask<Response>(Record("updateAsync", cancellationToken));
            public override Response WaitForCompletionResponse(CancellationToken cancellationToken = default)
                => Record("wait", cancellationToken);
            public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
                => new ValueTask<Response>(Record("waitAsync", cancellationToken));
            public override Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
            {
                LastInterval = pollingInterval;
                return Record("waitInterval", cancellationToken);
            }
            public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
            {
                LastInterval = pollingInterval;
                return new ValueTask<Response>(Record("waitIntervalAsync", cancellationToken));
            }
            public override Response WaitForCompletionResponse(DelayStrategy delayStrategy, CancellationToken cancellationToken = default)
            {
                LastStrategy = delayStrategy;
                return Record("waitStrategy", cancellationToken);
            }
            public override ValueTask<Response> WaitForCompletionResponseAsync(DelayStrategy delayStrategy, CancellationToken cancellationToken = default)
            {
                LastStrategy = delayStrategy;
                return new ValueTask<Response>(Record("waitStrategyAsync", cancellationToken));
            }

            private Response Record(string call, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (Failure is not null)
                    throw Failure;
                LastCall = call;
                LastToken = cancellationToken;
                return null;
            }
        }
    }
}

#pragma warning restore CS0618
