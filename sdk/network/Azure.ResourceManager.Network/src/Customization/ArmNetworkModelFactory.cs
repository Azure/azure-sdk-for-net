// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // Do not regenerate factory overloads that were absent from the 1.15 API.
    [CodeGenSuppress("LoadBalancerInboundNatPoolProperties", typeof(ResourceIdentifier), typeof(LoadBalancingTransportProtocol), typeof(int), typeof(int), typeof(int), typeof(int?), typeof(bool?), typeof(bool?), typeof(NetworkProvisioningState?))]
    // The renamed numeric wire property must not consume or discard the legacy string input.
    // Preserve this overload and store its values only in the independent Rules collection.
    [CodeGenSuppress("ManagedRuleSetRuleGroup", typeof(string), typeof(IEnumerable<string>))]
    [CodeGenSuppress("ApplicationGatewayOnDemandProbe", typeof(ApplicationGatewayProtocol?), typeof(string), typeof(string), typeof(int?), typeof(bool?), typeof(bool?), typeof(ApplicationGatewayProbeHealthResponseMatch), typeof(ResourceIdentifier), typeof(ResourceIdentifier))]
    [CodeGenSuppress("ConnectionMonitorCreateOrUpdateContent", typeof(ConnectionMonitorSource), typeof(ConnectionMonitorDestination), typeof(bool?), typeof(int?), typeof(IEnumerable<ConnectionMonitorEndpoint>), typeof(IEnumerable<ConnectionMonitorTestConfiguration>), typeof(IEnumerable<ConnectionMonitorTestGroup>), typeof(IEnumerable<ConnectionMonitorOutput>), typeof(string))]
    [CodeGenSuppress("ConnectionMonitorCreateOrUpdateContent", typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ConnectionMonitorSource), typeof(ConnectionMonitorDestination), typeof(bool?), typeof(int?), typeof(IEnumerable<ConnectionMonitorEndpoint>), typeof(IEnumerable<ConnectionMonitorTestConfiguration>), typeof(IEnumerable<ConnectionMonitorTestGroup>), typeof(IEnumerable<ConnectionMonitorOutput>), typeof(string))]
    // Preserve the released factory overloads and keep their implementation helpers nonpublic.
    [CodeGenSuppress("VirtualNetworkApplianceData", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(double?), typeof(IEnumerable<VirtualNetworkApplianceIPConfiguration>), typeof(VirtualNetworkApplianceIPVersionType?), typeof(NetworkProvisioningState?), typeof(Guid?), typeof(SubnetData), typeof(ETag?))]
    [CodeGenSuppress("VirtualNetworkApplianceData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ETag?), typeof(string), typeof(IEnumerable<VirtualNetworkApplianceIPConfiguration>), typeof(NetworkProvisioningState?), typeof(Guid?), typeof(SubnetData))]
    [CodeGenSuppress("P2SConnectionConfiguration", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(VirtualNetworkAddressSpace), typeof(RoutingConfiguration), typeof(bool?), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<VpnServerConfigurationPolicyGroupData>), typeof(NetworkProvisioningState?), typeof(ETag?))]
    [CodeGenSuppress("P2SConnectionConfiguration", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(ETag?), typeof(IEnumerable<string>), typeof(RoutingConfiguration), typeof(bool?), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<VpnServerConfigurationPolicyGroupData>), typeof(NetworkProvisioningState?))]
    [CodeGenSuppress("EffectiveBaseSecurityAdminRule", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(IEnumerable<NetworkManagerSecurityGroupItem>), typeof(IEnumerable<NetworkConfigurationGroup>), typeof(string))]
    [CodeGenSuppress("EffectiveNetworkSecurityGroup", typeof(ResourceIdentifier), typeof(EffectiveNetworkSecurityGroupAssociation), typeof(IEnumerable<EffectiveNetworkSecurityRule>), typeof(string))]
    // TODO: Remove this suppression when https://github.com/microsoft/typespec/issues/11846 is fixed.
    [CodeGenSuppress("EffectiveNetworkSecurityGroup", typeof(NetworkSubResource), typeof(EffectiveNetworkSecurityGroupAssociation), typeof(IEnumerable<EffectiveNetworkSecurityRule>), typeof(string))]
    // Keep the internal reference helper out of the public factory signature.
    [CodeGenSuppress("PublicIPPrefixData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(NetworkIPVersion?), typeof(IEnumerable<IPTag>), typeof(int?), typeof(string), typeof(IEnumerable<ReferencedPublicIPAddress>), typeof(Guid?), typeof(NetworkProvisioningState?), typeof(NatGatewayData), typeof(bool?), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(ExtendedLocation), typeof(PublicIPPrefixSku), typeof(ETag?), typeof(IEnumerable<string>))]
    // The generated factory signature includes the internal ApplicationGatewayForContainersReferenceDefinition helper type,
    // which would make a public method less accessible than one of its parameters.
    [CodeGenSuppress("WebApplicationFirewallPolicyData", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(PolicySettings), typeof(IEnumerable<WebApplicationFirewallCustomRule>), typeof(IEnumerable<ApplicationGatewayData>), typeof(NetworkProvisioningState?), typeof(WebApplicationFirewallPolicyResourceState?), typeof(ManagedRulesDefinition), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<ApplicationGatewayForContainersReferenceDefinition>), typeof(ETag?))]
    [CodeGenSuppress("WebApplicationFirewallPolicyData", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(PolicySettings), typeof(IEnumerable<WebApplicationFirewallCustomRule>), typeof(IEnumerable<ApplicationGatewayData>), typeof(NetworkProvisioningState?), typeof(WebApplicationFirewallPolicyResourceState?), typeof(ManagedRulesDefinition), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<ApplicationGatewayForContainersReferenceDefinition>), typeof(WebApplicationFirewallPolicyTier?), typeof(ETag?))]
    // The native ResourceType overload has the same inaccessible helper parameter and must also be suppressed.
    [CodeGenSuppress("WebApplicationFirewallPolicyData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(PolicySettings), typeof(IEnumerable<WebApplicationFirewallCustomRule>), typeof(IEnumerable<ApplicationGatewayData>), typeof(NetworkProvisioningState?), typeof(WebApplicationFirewallPolicyResourceState?), typeof(ManagedRulesDefinition), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<ApplicationGatewayForContainersReferenceDefinition>), typeof(WebApplicationFirewallPolicyTier?), typeof(ETag?))]
    public static partial class ArmNetworkModelFactory
    {
        /// <summary> Initializes a new appliance connection using the legacy NFV factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Please use the overload with the connectionRoutingConfiguration parameter instead.")]
        public static NetworkVirtualApplianceConnectionData NetworkVirtualApplianceConnectionData(ResourceIdentifier id, string name, ResourceType? resourceType, string namePropertiesName, NetworkProvisioningState? provisioningState, long? asn, long? tunnelIdentifier, IEnumerable<string> bgpPeerAddress, bool? enableInternetSecurity, RoutingConfigurationNfv routingConfiguration)
            => NetworkVirtualApplianceConnectionData(id, name, resourceType, namePropertiesName, provisioningState, asn, tunnelIdentifier, bgpPeerAddress, enableInternetSecurity, connectionRoutingConfiguration: null);

        /// <summary> Defines a managed rule set rule group with legacy string rules. </summary>
        /// <param name="ruleGroupName"> Name of the rule group. </param>
        /// <param name="rules"> Legacy string rules retained for compatibility; these values are not serialized. </param>
        /// <returns> A new <see cref="Models.ManagedRuleSetRuleGroup"/> instance for mocking. </returns>
        /// <remarks> Populate the returned model's <see cref="Models.ManagedRuleSetRuleGroup.RuleIds"/> collection to mock numeric rule identifiers. </remarks>
        public static ManagedRuleSetRuleGroup ManagedRuleSetRuleGroup(string ruleGroupName = default, IEnumerable<string> rules = default)
            => new ManagedRuleSetRuleGroup(ruleGroupName, (rules ?? new ChangeTrackingList<string>()).ToList());

        internal static VirtualNetworkApplianceData VirtualNetworkApplianceData(ResourceIdentifier id = default, string name = default, string @type = default, AzureLocation? location = default, IDictionary<string, string> tags = default, double? bandwidthInGbps = default, IEnumerable<VirtualNetworkApplianceIPConfiguration> ipConfigurations = default, VirtualNetworkApplianceIPVersionType? privateIPAddressVersion = default, NetworkProvisioningState? provisioningState = default, Guid? resourceGuid = default, SubnetData subnet = default, ETag? eTag = default)
        {
            return new VirtualNetworkApplianceData(
                id,
                name,
                @type is null ? (ResourceType?)null : new ResourceType(@type),
                location,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                default,
                bandwidthInGbps is null && ipConfigurations is null && privateIPAddressVersion is null && provisioningState is null && resourceGuid is null && subnet is null ? default : new VirtualNetworkAppliancePropertiesFormat(
                    bandwidthInGbps,
                    (ipConfigurations ?? new ChangeTrackingList<VirtualNetworkApplianceIPConfiguration>()).ToList(),
                    privateIPAddressVersion,
                    provisioningState,
                    resourceGuid,
                    subnet,
                    default),
                eTag);
        }

        // Keep the released typed/string-bandwidth overload and forward its metadata through the canonical factory.
        /// <summary> Initializes a new instance of <see cref="Network.VirtualNetworkApplianceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkApplianceData VirtualNetworkApplianceData(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, AzureLocation? location = default, IDictionary<string, string> tags = default, ETag? etag = default, string bandwidthInGbps = default, IEnumerable<VirtualNetworkApplianceIPConfiguration> ipConfigurations = default, NetworkProvisioningState? provisioningState = default, Guid? resourceGuid = default, SubnetData subnet = default)
        {
            VirtualNetworkApplianceData model = VirtualNetworkApplianceData(
                id: id,
                name: name,
                @type: resourceType?.ToString(),
                location: location,
                tags: tags,
                ipConfigurations: ipConfigurations,
                provisioningState: provisioningState,
                resourceGuid: resourceGuid,
                subnet: subnet,
                eTag: etag);
            model.BandwidthInGbps = bandwidthInGbps;
            return model;
        }

        internal static P2SConnectionConfiguration P2SConnectionConfiguration(ResourceIdentifier id = default, string name = default, string @type = default, VirtualNetworkAddressSpace vpnClientAddressPool = default, RoutingConfiguration routingConfiguration = default, bool? enableInternetSecurity = default, IEnumerable<WritableSubResource> configurationPolicyGroupAssociations = default, IEnumerable<VpnServerConfigurationPolicyGroupData> previousConfigurationPolicyGroupAssociations = default, NetworkProvisioningState? provisioningState = default, ETag? eTag = default)
        {
            return new P2SConnectionConfiguration(
                id,
                default,
                name,
                @type is null ? (ResourceType?)null : new ResourceType(@type),
                vpnClientAddressPool is null && routingConfiguration is null && enableInternetSecurity is null && configurationPolicyGroupAssociations is null && previousConfigurationPolicyGroupAssociations is null && provisioningState is null ? default : new P2SConnectionConfigurationProperties(
                    vpnClientAddressPool,
                    routingConfiguration,
                    enableInternetSecurity,
                    (configurationPolicyGroupAssociations ?? new ChangeTrackingList<WritableSubResource>()).ToList(),
                    (previousConfigurationPolicyGroupAssociations ?? new ChangeTrackingList<VpnServerConfigurationPolicyGroupData>()).ToList(),
                    provisioningState,
                    default),
                eTag);
        }

        // Keep the released flattened signature and forward ResourceType through the canonical factory without loss.
        /// <summary> Initializes a new instance of <see cref="Models.P2SConnectionConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static P2SConnectionConfiguration P2SConnectionConfiguration(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, IEnumerable<string> vpnClientAddressPrefixes, RoutingConfiguration routingConfiguration, bool? enableInternetSecurity, IEnumerable<WritableSubResource> configurationPolicyGroupAssociations, IEnumerable<VpnServerConfigurationPolicyGroupData> previousConfigurationPolicyGroupAssociations, NetworkProvisioningState? provisioningState)
        {
            return P2SConnectionConfiguration(
                id: id,
                name: name,
                @type: resourceType?.ToString(),
                vpnClientAddressPool: vpnClientAddressPrefixes is null ? default : new VirtualNetworkAddressSpace(vpnClientAddressPrefixes.ToList(), new ChangeTrackingList<IpamPoolPrefixAllocation>(), default),
                routingConfiguration: routingConfiguration,
                enableInternetSecurity: enableInternetSecurity,
                configurationPolicyGroupAssociations: configurationPolicyGroupAssociations,
                previousConfigurationPolicyGroupAssociations: previousConfigurationPolicyGroupAssociations,
                provisioningState: provisioningState,
                eTag: etag);
        }

        /// <summary> Initializes a new instance of <see cref="Models.EffectiveBaseSecurityAdminRule"/>. </summary>
        /// <param name="resourceId"> Resource ID. </param>
        /// <param name="configurationDescription"> A description of the security admin configuration. </param>
        /// <param name="ruleCollectionDescription"> A description of the rule collection. </param>
        /// <param name="ruleCollectionAppliesToGroups"> Groups for which the rule collection applies. </param>
        /// <param name="ruleGroups"> Network configuration groups. </param>
        /// <param name="kind"> The effective security admin rule kind. </param>
        /// <returns> A new <see cref="Models.EffectiveBaseSecurityAdminRule"/> instance for mocking. </returns>
        public static EffectiveBaseSecurityAdminRule EffectiveBaseSecurityAdminRule(ResourceIdentifier resourceId = default, string configurationDescription = default, string ruleCollectionDescription = default, IEnumerable<NetworkManagerSecurityGroupItem> ruleCollectionAppliesToGroups = default, IEnumerable<NetworkConfigurationGroup> ruleGroups = default, string kind = default)
        {
            return new UnknownEffectiveBaseSecurityAdminRule(
                resourceId,
                configurationDescription,
                ruleCollectionDescription,
                (ruleCollectionAppliesToGroups ?? new ChangeTrackingList<NetworkManagerSecurityGroupItem>()).ToList(),
                (ruleGroups ?? new ChangeTrackingList<NetworkConfigurationGroup>()).ToList(),
                kind,
                default);
        }

        // This released legacy model has no generated factory; set its typed base storage beneath the read-only getter.
        // This metadata repair does not add support for the other currently unassigned envelope arguments.
        /// <summary> Initializes a new instance of <see cref="Models.ApplicationGatewayAvailableSslOptionsInfo"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use ApplicationGatewayAvailableSslOptionsInfoData instead.")]
        public static ApplicationGatewayAvailableSslOptionsInfo ApplicationGatewayAvailableSslOptionsInfo(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, AzureLocation? location = default, IDictionary<string, string> tags = default, IEnumerable<WritableSubResource> predefinedPolicies = default, ApplicationGatewaySslPolicyName? defaultPolicy = default, IEnumerable<ApplicationGatewaySslCipherSuite> availableCipherSuites = default, IEnumerable<ApplicationGatewaySslProtocol> availableProtocols = default)
        {
            var result = new ApplicationGatewayAvailableSslOptionsInfo();
            ((NetworkTrackedResourceData)result).ResourceType = resourceType;
            foreach (var item in predefinedPolicies ?? Enumerable.Empty<WritableSubResource>())
            {
                result.PredefinedPolicies.Add(item);
            }
            foreach (var item in availableCipherSuites ?? Enumerable.Empty<ApplicationGatewaySslCipherSuite>())
            {
                result.AvailableCipherSuites.Add(item);
            }
            foreach (var item in availableProtocols ?? Enumerable.Empty<ApplicationGatewaySslProtocol>())
            {
                result.AvailableProtocols.Add(item);
            }
            result.DefaultPolicy = defaultPolicy;
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ConnectionMonitorQueryResult"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This legacy query result is not supported by the current connection monitor API.")]
        public static ConnectionMonitorQueryResult ConnectionMonitorQueryResult(ConnectionMonitorSourceStatus? sourceStatus = default, IEnumerable<ConnectionStateSnapshot> states = default)
        {
            return new ConnectionMonitorQueryResult();
        }

        /// <summary> Initializes a new instance of <see cref="Models.ConnectionStateSnapshot"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This legacy query snapshot is not supported by the current connection monitor API.")]
        public static ConnectionStateSnapshot ConnectionStateSnapshot(NetworkConnectionState? networkConnectionState = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, EvaluationState? evaluationState = default, long? avgLatencyInMs = default, long? minLatencyInMs = default, long? maxLatencyInMs = default, long? probesSent = default, long? probesFailed = default, IEnumerable<ConnectivityHopInfo> hops = default)
        {
            return new ConnectionStateSnapshot();
        }

        /// <summary> Initializes a new instance of <see cref="Models.InboundSecurityRule"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use InboundSecurityRuleData instead.")]
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, ETag? etag = default, IEnumerable<InboundSecurityRules> rules = default, NetworkProvisioningState? provisioningState = default)
        {
            return InboundSecurityRule(id, name, resourceType, etag, default, rules, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Models.InboundSecurityRule"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use InboundSecurityRuleData instead.")]
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, ETag? etag = default, InboundSecurityRuleType? ruleType = default, IEnumerable<InboundSecurityRules> rules = default, NetworkProvisioningState? provisioningState = default)
        {
            var properties = new InboundSecurityRuleProperties(ruleType, (rules ?? Enumerable.Empty<InboundSecurityRules>()).ToList(), provisioningState, default);
            return new InboundSecurityRule(id, name, resourceType, etag, properties, default);
        }

        // Adds the model factory method omitted for the custom canonical shared network manager connection model.
        /// <summary> Initializes a new instance of <see cref="Network.NetworkManagerConnectionData"/>. </summary>
        public static NetworkManagerConnectionData NetworkManagerConnectionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ResourceIdentifier networkManagerId = default, ScopeConnectionState? connectionState = default, string description = default, ETag? etag = default)
        {
            var properties = new NetworkManagerConnectionProperties(networkManagerId, connectionState, description, default);
            return new NetworkManagerConnectionData(id, name, resourceType, systemData, properties, etag, default);
        }
    }
}
