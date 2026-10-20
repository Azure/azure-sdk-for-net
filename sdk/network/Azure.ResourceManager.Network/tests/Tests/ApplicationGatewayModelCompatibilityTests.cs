// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class ApplicationGatewayModelCompatibilityTests
    {
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public void ProbeProxyProtocolNamesShareWireStorage(bool? enabled)
        {
            var poolId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/applicationGateways/gateway/backendAddressPools/pool");
            var settingsId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/applicationGateways/gateway/backendHttpSettingsCollection/settings");
            var match = new ApplicationGatewayProbeHealthResponseMatch();
            var factoryProbe = ArmNetworkModelFactory.ApplicationGatewayOnDemandProbe(
                protocol: ApplicationGatewayProtocol.Http,
                host: "probe.test",
                path: "/health",
                timeout: 30,
                pickHostNameFromBackendHttpSettings: true,
                enableProbeProxyProtocolHeader: enabled,
                match: match,
                backendAddressPoolId: poolId,
                backendHttpSettingsId: settingsId);
            Assert.That(factoryProbe.IsProbeProxyProtocolHeaderEnabled, Is.EqualTo(enabled));
            Assert.That(factoryProbe.Protocol, Is.EqualTo(ApplicationGatewayProtocol.Http));
            Assert.That(factoryProbe.Host, Is.EqualTo("probe.test"));
            Assert.That(factoryProbe.Path, Is.EqualTo("/health"));
            Assert.That(factoryProbe.Timeout, Is.EqualTo(30));
            Assert.That(factoryProbe.PickHostNameFromBackendHttpSettings, Is.True);
            Assert.That(factoryProbe.Match, Is.SameAs(match));
            Assert.That(factoryProbe.BackendAddressPoolId, Is.EqualTo(poolId));
            Assert.That(factoryProbe.BackendHttpSettingsId, Is.EqualTo(settingsId));
            var probe = new ApplicationGatewayOnDemandProbe { IsProbeProxyProtocolHeaderEnabled = enabled };
#pragma warning disable CS0618 // Exercise the released compatibility alias.
            Assert.That(probe.EnableProbeProxyProtocolHeader, Is.EqualTo(enabled));
            probe.EnableProbeProxyProtocolHeader = enabled.HasValue ? !enabled.Value : null;
            Assert.That(probe.IsProbeProxyProtocolHeaderEnabled, Is.EqualTo(probe.EnableProbeProxyProtocolHeader));
#pragma warning restore CS0618

            BinaryData data = ModelReaderWriter.Write(probe, ModelReaderWriterOptions.Json);
            using JsonDocument json = JsonDocument.Parse(data.ToString());
            Assert.That(json.RootElement.EnumerateObject().Count(p => p.Name == "enableProbeProxyProtocolHeader"), Is.EqualTo(enabled.HasValue ? 1 : 0));
            Assert.That(json.RootElement.TryGetProperty("isProbeProxyProtocolHeaderEnabled", out _), Is.False);
            var roundTrip = ModelReaderWriter.Read<ApplicationGatewayOnDemandProbe>(data, ModelReaderWriterOptions.Json);
            Assert.That(roundTrip.IsProbeProxyProtocolHeaderEnabled, Is.EqualTo(probe.IsProbeProxyProtocolHeaderEnabled));
        }

        [Test]
        public void OnlyTheOldProbeNameIsDeprecated()
        {
            Type type = typeof(ApplicationGatewayOnDemandProbe);
            Assert.That(type.GetProperty(nameof(ApplicationGatewayOnDemandProbe.IsProbeProxyProtocolHeaderEnabled)).GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
            PropertyInfo alias = type.GetProperty("EnableProbeProxyProtocolHeader");
            Assert.That(alias.GetCustomAttribute<ObsoleteAttribute>(), Is.Not.Null);
            Assert.That(alias.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
        }

        [Test]
        public void ReleasedProtectedConstructorsRemainCallable()
        {
            Assert.That(new DerivedActiveRule(), Is.InstanceOf<ActiveBaseSecurityAdminRule>());
            Assert.That(new DerivedActiveRule(true), Is.InstanceOf<ActiveBaseSecurityAdminRule>());
            Assert.That(new DerivedFirewallRule(), Is.InstanceOf<ApplicationGatewayFirewallRule>());
            Assert.That(new DerivedFirewallRuleGroup(), Is.InstanceOf<ApplicationGatewayFirewallRuleGroup>());
            Assert.That(new DerivedFirewallRuleSet(), Is.InstanceOf<ApplicationGatewayFirewallRuleSet>());
            Assert.That(new DerivedPrivateLinkResource(), Is.InstanceOf<ApplicationGatewayPrivateLinkResource>());
        }

        [Test]
        public void LegacySslOptionsRetainsFactoryAndResourceTypePersistence()
        {
#pragma warning disable CS0618 // This type is intentionally retained for binary compatibility.
            var resourceType = new ResourceType("Microsoft.Network/applicationGatewayAvailableSslOptions");
            var options = ArmNetworkModelFactory.ApplicationGatewayAvailableSslOptionsInfo(
                resourceType: resourceType,
                predefinedPolicies: new[] { new WritableSubResource() },
                defaultPolicy: ApplicationGatewaySslPolicyName.AppGwSslPolicy20150501,
                availableCipherSuites: new[] { ApplicationGatewaySslCipherSuite.TlsDHERsaWithAes128GcmSha256 },
                availableProtocols: new[] { ApplicationGatewaySslProtocol.Tls1_2 });
            Assert.That(options.PredefinedPolicies, Has.Count.EqualTo(1));
            Assert.That(options.AvailableCipherSuites, Has.Count.EqualTo(1));
            Assert.That(options.AvailableProtocols, Has.Count.EqualTo(1));
            Assert.That(options.DefaultPolicy, Is.EqualTo(ApplicationGatewaySslPolicyName.AppGwSslPolicy20150501));
            Assert.That(options.ResourceType, Is.EqualTo(resourceType));
            BinaryData data = ModelReaderWriter.Write(options, ModelReaderWriterOptions.Json);
            var roundTrip = ModelReaderWriter.Read<ApplicationGatewayAvailableSslOptionsInfo>(data, ModelReaderWriterOptions.Json);
            Assert.That(roundTrip.ResourceType, Is.EqualTo(resourceType));
            Type type = typeof(ApplicationGatewayAvailableSslOptionsInfo);
            Assert.That(type.GetCustomAttribute<ObsoleteAttribute>(), Is.Not.Null);
            Assert.That(type.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
#pragma warning restore CS0618
        }

        private sealed class DerivedActiveRule : ActiveBaseSecurityAdminRule
        {
            public DerivedActiveRule() : base() { }
            public DerivedActiveRule(bool value) : base(value) { }
        }

        private sealed class DerivedFirewallRule : ApplicationGatewayFirewallRule
        {
            public DerivedFirewallRule() : base(true) { }
        }

        private sealed class DerivedFirewallRuleGroup : ApplicationGatewayFirewallRuleGroup
        {
            public DerivedFirewallRuleGroup() : base(true) { }
        }

        private sealed class DerivedFirewallRuleSet : ApplicationGatewayFirewallRuleSet
        {
            public DerivedFirewallRuleSet() : base(true) { }
        }

        private sealed class DerivedPrivateLinkResource : ApplicationGatewayPrivateLinkResource
        {
            public DerivedPrivateLinkResource() : base(true) { }
        }
    }
}
