// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkModelCompatibilityTests
    {
        private const string GatewayId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/localNetworkGateways/gateway";
        private const string NetworkId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/network";

        // This is the test for fix of issue: https://github.com/Azure/azure-sdk-for-net/issues/46767
        [Test]
        public void DeserializeChangeNumber()
        {
            using var sr = new StreamReader(Path.Combine("TestData", "ServiceTags.json"));
            using var jsonContent = JsonDocument.Parse(sr.BaseStream);
            var data = AzureFirewallIPGroups.DeserializeAzureFirewallIPGroups(jsonContent.RootElement, ModelReaderWriterOptions.Json);
            Assert.NotNull(data.ChangeNumber);
        }

        [TestCase(typeof(ReachabilityAnalysisIntentProperties))]
        [TestCase(typeof(ReachabilityAnalysisRunProperties))]
        [TestCase(typeof(StaticCidrProperties))]
        public void ReleasedProvisioningSettersRemainConnected(Type type)
        {
            object value = ModelReaderWriter.Read(BinaryData.FromString("""{"provisioningState":"Succeeded"}"""), type, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            PropertyInfo property = type.GetProperty("ProvisioningState");
            Assert.That(property.GetValue(value), Is.EqualTo(NetworkProvisioningState.Succeeded));
            property.SetValue(value, NetworkProvisioningState.Failed);
            using JsonDocument persisted = JsonDocument.Parse(ModelReaderWriter.Write(value));
            Assert.That(persisted.RootElement.GetProperty("provisioningState").GetString(), Is.EqualTo("Failed"));
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.TryGetProperty("provisioningState", out _), Is.False);
        }

        [TestCase("true")]
        [TestCase("false")]
        [TestCase("True")]
        [TestCase("False")]
        [TestCase("future-value")]
        public void ReservationEnumUsesNativeWireValues(string token)
        {
            UndoReservationType value = token;
            var content = new ReserveCloudServicePublicIPAddressContent(value);
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(content, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.GetProperty("isRollback").GetString(), Is.EqualTo(token));
            var restored = ModelReaderWriter.Read<ReserveCloudServicePublicIPAddressContent>(ModelReaderWriter.Write(content));
            Assert.That(restored.IsRollback, Is.EqualTo(value));
        }

        [Test]
        public void ReservationEnumRetainsNativeConstructionAndEquality()
        {
            Assert.That(UndoReservationType.True.ToString(), Is.EqualTo("true"));
            Assert.That(UndoReservationType.False.ToString(), Is.EqualTo("false"));
            Assert.That(new UndoReservationType("TRUE"), Is.EqualTo(UndoReservationType.True));
            Assert.That(new UndoReservationType("TRUE").GetHashCode(), Is.EqualTo(UndoReservationType.True.GetHashCode()));
            Assert.Throws<ArgumentNullException>(() => new UndoReservationType(null));
        }

        [Test]
        public void RoutingDestinationNativeReaderUsesParsedType()
        {
            var value = ModelReaderWriter.Read<RoutingRuleRouteDestination>(BinaryData.FromString("""{"type":"ServiceTag","destinationAddress":"AzureCloud","futureProperty":17}"""));
            Assert.That(value.DestinationType.ToString(), Is.EqualTo("ServiceTag"));
            Assert.That(value.DestinationAddress, Is.EqualTo("AzureCloud"));
            AssertUnknownProperty(value);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void EncryptionNativeReaderUsesParsedEnabled(bool enabled)
        {
            var value = ModelReaderWriter.Read<VirtualNetworkEncryption>(BinaryData.FromString($$$"""{"enabled":{{{enabled.ToString().ToLowerInvariant()}}},"enforcement":"AllowUnencrypted","futureProperty":17}"""));
            Assert.That(value.IsEnabled, Is.EqualTo(enabled));
            Assert.That(value.Enforcement.ToString(), Is.EqualTo("AllowUnencrypted"));
            AssertUnknownProperty(value);
        }

        private static void AssertUnknownProperty<T>(T value)
        {
            using JsonDocument persisted = JsonDocument.Parse(ModelReaderWriter.Write(value));
            Assert.That(persisted.RootElement.GetProperty("futureProperty").GetInt32(), Is.EqualTo(17));
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.TryGetProperty("futureProperty", out _), Is.False);
        }

        [Test]
        public void UnknownAdminRuleUsesNativePolymorphicReaders()
        {
            BinaryData payload = BinaryData.FromString("""{"kind":"FutureRule","futureProperty":17}""");
            var value = ModelReaderWriter.Read<BaseAdminRuleData>(payload);
            Assert.That(value.GetType().IsPublic, Is.False);
            using JsonDocument persisted = JsonDocument.Parse(ModelReaderWriter.Write(value));
            Assert.That(persisted.RootElement.GetProperty("kind").GetString(), Is.EqualTo("FutureRule"));
            Assert.That(persisted.RootElement.GetProperty("futureProperty").GetInt32(), Is.EqualTo(17));
            var reader = new Utf8JsonReader(payload.ToMemory().Span);
            var restored = ((IJsonModel<BaseAdminRuleData>)value).Create(ref reader, ModelReaderWriterOptions.Json);
            Assert.That(restored.GetType(), Is.EqualTo(value.GetType()));
            Assert.That(reader.TokenType, Is.EqualTo(JsonTokenType.EndObject));
        }

        [Test]
        public void HubIpConfigurationsReadAndPersistServiceReferences()
        {
            var value = ModelReaderWriter.Read<VirtualHubData>(BinaryData.FromString($$$"""{"properties":{"ipConfigurations":[{"id":"{{{NetworkId}}}"}]}}"""));
            Assert.That(value.IPConfigurations.Count, Is.EqualTo(1));
            Assert.That(value.IPConfigurations[0].Id.ToString(), Is.EqualTo(NetworkId));
            using JsonDocument persisted = JsonDocument.Parse(ModelReaderWriter.Write(value));
            Assert.That(persisted.RootElement.GetProperty("properties").GetProperty("ipConfigurations")[0].GetProperty("id").GetString(), Is.EqualTo(NetworkId));
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.GetProperty("properties").TryGetProperty("ipConfigurations", out _), Is.False);
        }

        [Test]
        public void GatewayReferenceAndIdentifierShareMutableSerializedState()
        {
            var value = new VirtualNetworkGatewayData();
            value.GatewayDefaultSite = new WritableSubResource { Id = new ResourceIdentifier(GatewayId) };
            Assert.That(value.GatewayDefaultSiteId.ToString(), Is.EqualTo(GatewayId));
            value.GatewayDefaultSite.Id = new ResourceIdentifier(NetworkId);
            Assert.That(value.GatewayDefaultSiteId.ToString(), Is.EqualTo(NetworkId));
            value.GatewayDefaultSiteId = new ResourceIdentifier(GatewayId);
            AssertReferenceWire(value, "gatewayDefaultSite", GatewayId);
            var restored = ModelReaderWriter.Read<VirtualNetworkGatewayData>(ModelReaderWriter.Write(value));
            Assert.That(restored.GatewayDefaultSite.Id, Is.EqualTo(value.GatewayDefaultSiteId));
            value.GatewayDefaultSite = null;
            Assert.That(value.GatewayDefaultSiteId, Is.Null);
        }

        [Test]
        public void PeeringReferenceAndIdentifierShareMutableSerializedState()
        {
            var value = new VirtualNetworkPeeringData();
            value.RemoteVirtualNetwork = new WritableSubResource { Id = new ResourceIdentifier(NetworkId) };
            Assert.That(value.RemoteVirtualNetworkId.ToString(), Is.EqualTo(NetworkId));
            value.RemoteVirtualNetwork.Id = new ResourceIdentifier(GatewayId);
            Assert.That(value.RemoteVirtualNetworkId.ToString(), Is.EqualTo(GatewayId));
            value.RemoteVirtualNetworkId = new ResourceIdentifier(NetworkId);
            AssertReferenceWire(value, "remoteVirtualNetwork", NetworkId);
            var restored = ModelReaderWriter.Read<VirtualNetworkPeeringData>(ModelReaderWriter.Write(value));
            Assert.That(restored.RemoteVirtualNetwork.Id, Is.EqualTo(value.RemoteVirtualNetworkId));
            value.RemoteVirtualNetwork = null;
            Assert.That(value.RemoteVirtualNetworkId, Is.Null);
        }

        private static void AssertReferenceWire<T>(T value, string property, string id)
        {
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(value, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.GetProperty("properties").GetProperty(property).GetProperty("id").GetString(), Is.EqualTo(id));
        }

        [Test]
        public void ReleasedGatewayConnectionConstructorUsesPublicProperties()
        {
            var value = new VirtualNetworkGatewayConnectionListEntity(new WritableSubResource { Id = new ResourceIdentifier(GatewayId) }, VirtualNetworkGatewayConnectionType.IPsec);
            Assert.That(value.ConnectionType, Is.EqualTo(VirtualNetworkGatewayConnectionType.IPsec));
            Assert.That(value.VirtualNetworkGateway1Id.ToString(), Is.EqualTo(GatewayId));
            AssertReferenceWire(value, "virtualNetworkGateway1", GatewayId);
            Assert.Throws<ArgumentNullException>(() => new VirtualNetworkGatewayConnectionListEntity(null, VirtualNetworkGatewayConnectionType.IPsec));
        }

        [Test]
        public void TroubleshootingUriConstructorForwardsToPublicStringConstructor()
        {
            var path = new Uri("https://storage.example/container");
            var value = new TroubleshootingContent(new ResourceIdentifier(NetworkId), new ResourceIdentifier(GatewayId), path);
            Assert.That(value.StoragePath, Is.EqualTo(path.AbsoluteUri));
        }

        [Test]
        public void ServiceTagsRetainTheReleasedResourceIdentifier()
        {
            var value = ModelReaderWriter.Read<ServiceTagsListResult>(BinaryData.FromString($$$"""{"id":"{{{NetworkId}}}","type":"Microsoft.Network/virtualNetworks","values":[]}"""));
            Assert.That(value.Id, Is.EqualTo(new ResourceIdentifier(NetworkId)));
            Assert.That(((global::Azure.ResourceManager.Models.ResourceData)value).Id, Is.SameAs(value.Id));
        }

        [TestCase(typeof(ResourceNavigationLink))]
        [TestCase(typeof(ServiceAssociationLink))]
        [TestCase(typeof(VirtualNetworkApplianceIPConfiguration))]
        [TestCase(typeof(VirtualNetworkGatewayConnectionListEntity))]
        public void ReleasedParameterlessConstructorsDoNotInventBooleanOverloads(Type type)
        {
            ConstructorInfo constructor = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            Assert.That(constructor, Is.Not.Null);
            Assert.That(type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(bool) }, null), Is.Null);
        }

        [TestCase("VpnClientParameters")]
        [TestCase("VpnPacketCaptureStartParameters")]
        [TestCase("VpnPacketCaptureStopParameters")]
        public void RetiredVpnTypesAreHiddenWithoutDuplicateMemberDeprecation(string name)
        {
            Type type = typeof(VpnClientContent).Assembly.GetType("Azure.ResourceManager.Network.Models." + name);
            Assert.That(type.GetCustomAttribute<ObsoleteAttribute>().Message, Is.EqualTo("This class is obsolete and will be removed in a future release"));
            Assert.That(type.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(type.GetConstructor(Type.EmptyTypes).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
        }

        [Test]
        public void AadIsTheNativeVpnToken()
        {
            Assert.That(VpnAuthenticationType.Aad.ToString(), Is.EqualTo("AAD"));
            Assert.That(new VpnAuthenticationType("AAD"), Is.EqualTo(VpnAuthenticationType.Aad));
            PropertyInfo legacy = typeof(VpnAuthenticationType).GetProperty("AAD");
            Assert.That(legacy.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            Assert.That(legacy.GetCustomAttribute<ObsoleteAttribute>().IsError, Is.False);
            Assert.That(legacy.GetCustomAttribute<ObsoleteAttribute>().Message,
                Is.EqualTo("This value is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead"));
        }
    }
}
