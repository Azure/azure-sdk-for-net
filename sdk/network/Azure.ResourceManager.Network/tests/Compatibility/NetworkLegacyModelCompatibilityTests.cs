// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Reflection;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;
using static Azure.ResourceManager.Network.Tests.CompatibilityTestHelpers;

namespace Azure.ResourceManager.Network.Tests
{
#pragma warning disable CS0618 // Directly exercise intentionally retained compatibility APIs and metadata.
    [NUnit.Framework.Category("Compatibility")]
    public class NetworkLegacyModelCompatibilityTests
    {
        [TestCase(typeof(ConnectionMonitorQueryResult))]
        [TestCase(typeof(ConnectionMonitorSourceStatus))]
        [TestCase(typeof(ConnectionStateSnapshot))]
        [TestCase(typeof(EvaluationState))]
        [TestCase(typeof(DdosCustomPolicyProtocol))]
        [TestCase(typeof(DdosCustomPolicyTriggerSensitivityOverride))]
        [TestCase(typeof(DdosSettingsProtectionCoverage))]
        [TestCase(typeof(ProtocolCustomSettings))]
        public void ObsoleteCompatibilityTypesAreHidden(Type type)
        {
            AssertDeprecated(type);
        }

        [TestCase(typeof(ApplicationGatewayCustomErrorStatusCode), nameof(ApplicationGatewayCustomErrorStatusCode.HttpStatus499))]
        [TestCase(typeof(ApplicationGatewayWafRuleSensitivityType), nameof(ApplicationGatewayWafRuleSensitivityType.None))]
        [TestCase(typeof(FirewallPolicyIntrusionDetectionProfileType), nameof(FirewallPolicyIntrusionDetectionProfileType.Basic))]
        [TestCase(typeof(FirewallPolicyIntrusionDetectionProfileType), nameof(FirewallPolicyIntrusionDetectionProfileType.Standard))]
        [TestCase(typeof(FirewallPolicyIntrusionDetectionProfileType), nameof(FirewallPolicyIntrusionDetectionProfileType.Advanced))]
        [TestCase(typeof(LoadBalancerBackendAddressAdminState), nameof(LoadBalancerBackendAddressAdminState.Drain))]
        [TestCase(typeof(ManagedRuleSensitivityType), nameof(ManagedRuleSensitivityType.None))]
        [TestCase(typeof(VpnAuthenticationType), nameof(VpnAuthenticationType.AAD))]
        [TestCase(typeof(DdosSettings), nameof(DdosSettings.ProtectionCoverage))]
        [TestCase(typeof(DdosCustomPolicyData), nameof(DdosCustomPolicyData.ProtocolCustomSettings))]
        public void ObsoleteCompatibilityPropertiesAreHidden(Type type, string name)
        {
            AssertDeprecated(type.GetProperty(name));
        }

        [TestCase(typeof(DdosSettingsProtectionCoverage), nameof(DdosSettingsProtectionCoverage.Basic))]
        [TestCase(typeof(DdosSettingsProtectionCoverage), nameof(DdosSettingsProtectionCoverage.Standard))]
        [TestCase(typeof(DdosCustomPolicyProtocol), nameof(DdosCustomPolicyProtocol.Syn))]
        [TestCase(typeof(ProtocolCustomSettings), nameof(ProtocolCustomSettings.Protocol))]
        [TestCase(typeof(ProtocolCustomSettings), nameof(ProtocolCustomSettings.TriggerSensitivityOverride))]
        [TestCase(typeof(ConnectionMonitorQueryResult), nameof(ConnectionMonitorQueryResult.SourceStatus))]
        [TestCase(typeof(ConnectionMonitorQueryResult), nameof(ConnectionMonitorQueryResult.States))]
        [TestCase(typeof(ConnectionStateSnapshot), nameof(ConnectionStateSnapshot.NetworkConnectionState))]
        [TestCase(typeof(ConnectionStateSnapshot), nameof(ConnectionStateSnapshot.EvaluationState))]
        public void ObsoleteContainersDoNotRedundantlyDeprecateTheirProperties(Type type, string name)
        {
            AssertDeprecated(type);
            PropertyInfo property = type.GetProperty(name);
            Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(property.GetCustomAttribute<EditorBrowsableAttribute>(), Is.Null);
        }

        [TestCase(typeof(DdosSettingsProtectionCoverage), "VirtualNetworkInherited")]
        [TestCase(typeof(DdosSettingsProtectionCoverage), "Enabled")]
        [TestCase(typeof(DdosSettingsProtectionCoverage), "Disabled")]
        [TestCase(typeof(DdosCustomPolicyProtocol), "TcpSyn")]
        [TestCase(typeof(ConnectionMonitorEndpointType), "MultiEndpoint")]
        [TestCase(typeof(ConnectionMonitorEndpointType), "SingleSourceDestination")]
        [TestCase(typeof(PacketCaptureData), "ContinuousCapture")]
        [TestCase(typeof(SubnetData), "PrivateEndpointNetworkPolicies")]
        [TestCase(typeof(SubnetData), "PrivateLinkServiceNetworkPolicies")]
        [TestCase(typeof(VirtualNetworkPeeringData), "PeerCompleteVnets")]
        public void MigrationDoesNotInventLegacyAliases(Type type, string name)
        {
            Assert.That(type.GetProperty(name), Is.Null);
        }

        [TestCase(typeof(DdosSettingsProtectionCoverage))]
        [TestCase(typeof(DdosCustomPolicyProtocol))]
        public void LegacyEnumsDoNotIntroduceNullableStringConversions(Type type)
        {
            Type nullableType = typeof(Nullable<>).MakeGenericType(type);
            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                if (method.Name == "op_Implicit")
                    Assert.That(method.ReturnType, Is.Not.EqualTo(nullableType));
            }
        }

        [Test]
        public void LegacyQueryEntryPointsAreDeprecated()
        {
            AssertDeprecated(typeof(ConnectionMonitorResource).GetMethod(nameof(ConnectionMonitorResource.Query)));
            AssertDeprecated(typeof(ConnectionMonitorResource).GetMethod(nameof(ConnectionMonitorResource.QueryAsync)));
            AssertDeprecated(typeof(ArmNetworkModelFactory).GetMethod(nameof(ArmNetworkModelFactory.ConnectionMonitorQueryResult)));
            AssertDeprecated(typeof(ArmNetworkModelFactory).GetMethod(nameof(ArmNetworkModelFactory.ConnectionStateSnapshot)));
        }

        [Test]
        public void LegacyValuesAndAliasesRetainTheirMeaning()
        {
            Assert.That(VpnAuthenticationType.AAD, Is.EqualTo(VpnAuthenticationType.Aad));
            Assert.That(VpnAuthenticationType.Aad.ToString(), Is.EqualTo("AAD"));
            Assert.That(new ConnectionMonitorEndpointType("MultiEndpoint").ToString(), Is.EqualTo("MultiEndpoint"));
            Assert.That(new ConnectionMonitorEndpointType("SingleSourceDestination").ToString(), Is.EqualTo("SingleSourceDestination"));
            Assert.That(DdosCustomPolicyProtocol.Syn.ToString(), Is.EqualTo("Syn"));
            Assert.That(DdosSettingsProtectionCoverage.Basic.ToString(), Is.EqualTo("Basic"));
            Assert.That(ConnectionMonitorSourceStatus.Active.ToString(), Is.EqualTo("Active"));
            Assert.That(EvaluationState.Completed.ToString(), Is.EqualTo("Completed"));
            var information = ModelReaderWriter.Read<ConnectivityInformation>(
                BinaryData.FromString("{\"connectionStatus\":\"Connected\"}"), ModelReaderWriterOptions.Json);
            Assert.That(information.NetworkConnectionStatus, Is.EqualTo(NetworkConnectionStatus.Connected));
            Assert.That(typeof(ConnectivityInformation).GetProperty("ConnectionStatus"), Is.Null);
            PropertyInfo status = typeof(ConnectivityInformation).GetProperty(nameof(ConnectivityInformation.NetworkConnectionStatus));
            Assert.That(status.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(status.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.Not.EqualTo(EditorBrowsableState.Never));
        }

        [Test]
        public void CurrentEnumTypesAreNotDeprecated()
        {
            Assert.That(typeof(CidrAdvertisingGeoCode).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(DdosSettingsProtectionMode).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(DdosTrafficType).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(typeof(VpnAuthenticationType).GetProperty(nameof(VpnAuthenticationType.Aad)).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            Assert.That(default(CidrAdvertisingGeoCode).ToString(), Is.Null);
            Assert.Throws<ArgumentNullException>(() => new CidrAdvertisingGeoCode(null));
            var settings = new DdosSettings { ProtectionMode = DdosSettingsProtectionMode.Enabled };
            Assert.That(settings.ProtectionMode, Is.EqualTo(DdosSettingsProtectionMode.Enabled));
            var rule = new TrafficDetectionRule { TrafficType = DdosTrafficType.TcpSyn };
            Assert.That(rule.TrafficType, Is.EqualTo(DdosTrafficType.TcpSyn));
        }

        [TestCase(nameof(CidrAdvertisingGeoCode.Global), "GLOBAL")]
        [TestCase(nameof(CidrAdvertisingGeoCode.Afri), "AFRI")]
        [TestCase(nameof(CidrAdvertisingGeoCode.Apac), "APAC")]
        [TestCase(nameof(CidrAdvertisingGeoCode.Euro), "EURO")]
        [TestCase(nameof(CidrAdvertisingGeoCode.Latam), "LATAM")]
        [TestCase(nameof(CidrAdvertisingGeoCode.Nam), "NAM")]
        [TestCase(nameof(CidrAdvertisingGeoCode.ME), "ME")]
        [TestCase(nameof(CidrAdvertisingGeoCode.Oceania), "OCEANIA")]
        [TestCase(nameof(CidrAdvertisingGeoCode.AQ), "AQ")]
        public void GeneratedCidrCodesRetainTheirWireValues(string member, string wireValue)
        {
            var code = (CidrAdvertisingGeoCode)typeof(CidrAdvertisingGeoCode).GetProperty(member).GetValue(null);
            Assert.That(code.ToString(), Is.EqualTo(wireValue));
            Assert.That(code, Is.EqualTo(new CidrAdvertisingGeoCode(wireValue.ToLowerInvariant())));
            var prefix = new CustomIPPrefixData { Geo = code };
            var restored = ModelReaderWriter.Read<CustomIPPrefixData>(
                ModelReaderWriter.Write(prefix, ModelReaderWriterOptions.Json), ModelReaderWriterOptions.Json);
            Assert.That(restored.Geo, Is.EqualTo(code));
        }

        [TestCase("VirtualNetworkInherited")]
        [TestCase("Enabled")]
        [TestCase("Disabled")]
        public void DdosProtectionModeUsesTheGeneratedModeEnum(string wireValue)
        {
            var settings = ModelReaderWriter.Read<DdosSettings>(
                BinaryData.FromString($"{{\"protectionMode\":\"{wireValue}\"}}"), ModelReaderWriterOptions.Json);
            Assert.That(settings.ProtectionMode, Is.EqualTo(new DdosSettingsProtectionMode(wireValue)));
            Assert.That(ModelReaderWriter.Write(settings, ModelReaderWriterOptions.Json).ToString(),
                Does.Contain($"\"protectionMode\":\"{wireValue}\""));
        }

        [TestCase("Tcp")]
        [TestCase("Udp")]
        [TestCase("TcpSyn")]
        public void DdosTrafficUsesTheGeneratedTrafficEnum(string wireValue)
        {
            var rule = ModelReaderWriter.Read<TrafficDetectionRule>(
                BinaryData.FromString($"{{\"trafficType\":\"{wireValue}\"}}"), ModelReaderWriterOptions.Json);
            Assert.That(rule.TrafficType, Is.EqualTo(new DdosTrafficType(wireValue)));
            Assert.That(ModelReaderWriter.Write(rule, ModelReaderWriterOptions.Json).ToString(),
                Does.Contain($"\"trafficType\":\"{wireValue}\""));
            Assert.That(DdosCustomPolicyProtocol.Syn.ToString(), Is.Not.EqualTo(DdosTrafficType.TcpSyn.ToString()));
        }

        [Test]
        public void NativeEnumsValidateNullAndRemainExtensible()
        {
            Assert.Throws<ArgumentNullException>(() => new DdosSettingsProtectionMode(null));
            Assert.Throws<ArgumentNullException>(() => new DdosTrafficType(null));
            Assert.That(default(DdosSettingsProtectionMode).ToString(), Is.Null);
            Assert.That(default(DdosTrafficType).ToString(), Is.Null);
            Assert.That(new CidrAdvertisingGeoCode("future-geo").ToString(), Is.EqualTo("future-geo"));
            Assert.That(new DdosSettingsProtectionMode("future-mode").ToString(), Is.EqualTo("future-mode"));
            Assert.That(new DdosTrafficType("future-traffic").ToString(), Is.EqualTo("future-traffic"));
        }

        [TestCase(typeof(ApplicationGatewaySslPredefinedPolicy))]
        [TestCase(typeof(AzureFirewallFqdnTag))]
        [TestCase(typeof(BgpCommunity))]
        [TestCase(typeof(BgpServiceCommunity))]
        [TestCase(typeof(ContainerNetworkInterface))]
        [TestCase(typeof(EffectiveBaseSecurityAdminRule))]
        [TestCase(typeof(ExpressRoutePortsLocationBandwidths))]
        [TestCase(typeof(ExpressRouteServiceProvider))]
        [TestCase(typeof(ExpressRouteServiceProviderBandwidthsOffered))]
        public void ReleasedParameterlessConstructorsDoNotInventBooleanOverloads(Type type)
        {
            ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
            Assert.That(constructor, Is.Not.Null);
            Assert.That(type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { typeof(bool) }, null), Is.Null);
        }
    }
#pragma warning restore CS0618
}
