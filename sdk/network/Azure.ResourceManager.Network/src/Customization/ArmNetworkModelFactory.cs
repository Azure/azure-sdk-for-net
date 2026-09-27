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
    /// <summary> Compatibility declaration for the ArmNetworkModelFactory type. </summary>
    // Preserve both bandwidth factory signatures and populate the renamed numeric property.
    [CodeGenSuppress("VirtualNetworkApplianceData", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(double?), typeof(IEnumerable<VirtualNetworkApplianceIPConfiguration>), typeof(VirtualNetworkApplianceIpVersionType?), typeof(NetworkProvisioningState?), typeof(Guid?), typeof(SubnetData), typeof(ETag?))]
    [CodeGenSuppress("VirtualNetworkApplianceData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(ETag?), typeof(string), typeof(IEnumerable<VirtualNetworkApplianceIPConfiguration>), typeof(NetworkProvisioningState?), typeof(Guid?), typeof(SubnetData))]
    [CodeGenSuppress("P2SConnectionConfiguration", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(VirtualNetworkAddressSpace), typeof(RoutingConfigurationNfv), typeof(bool?), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<VpnServerConfigurationPolicyGroupData>), typeof(NetworkProvisioningState?), typeof(ETag?))]
    [CodeGenSuppress("P2SConnectionConfiguration", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType?), typeof(ETag?), typeof(IEnumerable<string>), typeof(RoutingConfiguration), typeof(bool?), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<VpnServerConfigurationPolicyGroupData>), typeof(NetworkProvisioningState?))]
    [CodeGenSuppress("EffectiveBaseSecurityAdminRule", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(IEnumerable<NetworkManagerSecurityGroupItem>), typeof(IEnumerable<NetworkConfigurationGroup>), typeof(string))]
    [CodeGenSuppress("PeerRouteList", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int?))]
    [CodeGenSuppress("EffectiveNetworkSecurityGroup", typeof(ResourceIdentifier), typeof(EffectiveNetworkSecurityGroupAssociation), typeof(IEnumerable<EffectiveNetworkSecurityRule>), typeof(string))]
    // TODO: Remove this suppression when https://github.com/microsoft/typespec/issues/11846 is fixed.
    [CodeGenSuppress("EffectiveNetworkSecurityGroup", typeof(NetworkSubResource), typeof(EffectiveNetworkSecurityGroupAssociation), typeof(IEnumerable<EffectiveNetworkSecurityRule>), typeof(string))]
    // The generated factory signature includes the internal ApplicationGatewayForContainersReferenceDefinition helper type,
    // which would make a public method less accessible than one of its parameters.
    [CodeGenSuppress("WebApplicationFirewallPolicyData", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(PolicySettings), typeof(IEnumerable<WebApplicationFirewallCustomRule>), typeof(IEnumerable<ApplicationGatewayData>), typeof(NetworkProvisioningState?), typeof(WebApplicationFirewallPolicyResourceState?), typeof(ManagedRulesDefinition), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<ApplicationGatewayForContainersReferenceDefinition>), typeof(ETag?))]
    [CodeGenSuppress("WebApplicationFirewallPolicyData", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(AzureLocation?), typeof(IDictionary<string, string>), typeof(PolicySettings), typeof(IEnumerable<WebApplicationFirewallCustomRule>), typeof(IEnumerable<ApplicationGatewayData>), typeof(NetworkProvisioningState?), typeof(WebApplicationFirewallPolicyResourceState?), typeof(ManagedRulesDefinition), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<WritableSubResource>), typeof(IEnumerable<ApplicationGatewayForContainersReferenceDefinition>), typeof(WebApplicationFirewallPolicyTier?), typeof(ETag?))]
    public static partial class ArmNetworkModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Network.VirtualNetworkApplianceData"/>. </summary>
        public static VirtualNetworkApplianceData VirtualNetworkApplianceData(ResourceIdentifier id = default, string name = default, string @type = default, AzureLocation? location = default, IDictionary<string, string> tags = default, double? bandwidthInGbps = default, IEnumerable<VirtualNetworkApplianceIPConfiguration> ipConfigurations = default, VirtualNetworkApplianceIpVersionType? privateIPAddressVersion = default, NetworkProvisioningState? provisioningState = default, Guid? resourceGuid = default, SubnetData subnet = default, ETag? eTag = default)
        {
            return new VirtualNetworkApplianceData(
                id,
                name,
                @type,
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

        /// <summary> Initializes a new instance of <see cref="Network.VirtualNetworkApplianceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualNetworkApplianceData VirtualNetworkApplianceData(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, AzureLocation? location = default, IDictionary<string, string> tags = default, ETag? etag = default, string bandwidthInGbps = default, IEnumerable<VirtualNetworkApplianceIPConfiguration> ipConfigurations = default, NetworkProvisioningState? provisioningState = default, Guid? resourceGuid = default, SubnetData subnet = default)
        {
            VirtualNetworkApplianceData model = VirtualNetworkApplianceData(
                id: id,
                name: name,
                @type: default,
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

        // Preserve the released parameter name while initializing the renamed generated collection.
        /// <summary> Initializes a new instance of <see cref="Models.P2SConnectionConfiguration"/>. </summary>
        public static P2SConnectionConfiguration P2SConnectionConfiguration(ResourceIdentifier id = default, string name = default, string @type = default, VirtualNetworkAddressSpace vpnClientAddressPool = default, RoutingConfigurationNfv routingConfiguration = default, bool? enableInternetSecurity = default, IEnumerable<WritableSubResource> configurationPolicyGroupAssociations = default, IEnumerable<VpnServerConfigurationPolicyGroupData> previousConfigurationPolicyGroupAssociations = default, NetworkProvisioningState? provisioningState = default, ETag? eTag = default)
        {
            return new P2SConnectionConfiguration(
                id,
                default,
                name,
                @type,
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

        /// <summary> Initializes a new instance of <see cref="Models.P2SConnectionConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static P2SConnectionConfiguration P2SConnectionConfiguration(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, IEnumerable<string> vpnClientAddressPrefixes, RoutingConfiguration routingConfiguration, bool? enableInternetSecurity, IEnumerable<WritableSubResource> configurationPolicyGroupAssociations, IEnumerable<VpnServerConfigurationPolicyGroupData> previousConfigurationPolicyGroupAssociations, NetworkProvisioningState? provisioningState)
        {
            return P2SConnectionConfiguration(
                id: id,
                name: name,
                @type: default,
                vpnClientAddressPool: vpnClientAddressPrefixes is null ? default : new VirtualNetworkAddressSpace(vpnClientAddressPrefixes.ToList(), default, default),
                routingConfiguration: default,
                enableInternetSecurity: enableInternetSecurity,
                configurationPolicyGroupAssociations: configurationPolicyGroupAssociations,
                previousConfigurationPolicyGroupAssociations: previousConfigurationPolicyGroupAssociations,
                provisioningState: provisioningState,
                eTag: etag);
        }

        // Restores the released enum-shaped factory overload and delegates it to the canonical overload that accepts
        // the Boolean IsOnlyIPv6PeeringEnabled value.
        /// <summary> Initializes a new instance of <see cref="Network.HubVirtualNetworkConnectionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is deprecated and is no longer supported by the service.")]
        public static HubVirtualNetworkConnectionData HubVirtualNetworkConnectionData(ResourceIdentifier id = default, string name = default, string @type = default, bool? allowHubToRemoteVnetTransit = default, bool? allowRemoteVnetToUseHubVnetGateways = default, bool? enableInternetSecurity = default, RoutingConfigurationNfv routingConfiguration = default, EnableOnlyIPv6PeeringState? enableOnlyIPv6Peering = default, NetworkProvisioningState? provisioningState = default, ResourceIdentifier remoteVirtualNetworkId = default, ResourceIdentifier connectionPolicyId = default, ETag? eTag = default)
        {
            bool? isOnlyIPv6PeeringEnabled = enableOnlyIPv6Peering.HasValue
                ? enableOnlyIPv6Peering.Value == EnableOnlyIPv6PeeringState.Enabled
                : default;

            return HubVirtualNetworkConnectionData(
                id,
                name,
                @type,
                allowHubToRemoteVnetTransit,
                allowRemoteVnetToUseHubVnetGateways,
                enableInternetSecurity,
                routingConfiguration,
                isOnlyIPv6PeeringEnabled,
                provisioningState,
                remoteVirtualNetworkId,
                connectionPolicyId,
                eTag);
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

        /// <summary> Initializes a new instance of <see cref="Models.ApplicationGatewayAvailableSslOptionsInfo"/>. </summary>
        public static ApplicationGatewayAvailableSslOptionsInfo ApplicationGatewayAvailableSslOptionsInfo(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, AzureLocation? location = default, IDictionary<string, string> tags = default, IEnumerable<WritableSubResource> predefinedPolicies = default, ApplicationGatewaySslPolicyName? defaultPolicy = default, IEnumerable<ApplicationGatewaySslCipherSuite> availableCipherSuites = default, IEnumerable<ApplicationGatewaySslProtocol> availableProtocols = default)
        {
            var result = new ApplicationGatewayAvailableSslOptionsInfo();
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
        public static ConnectionMonitorQueryResult ConnectionMonitorQueryResult(ConnectionMonitorSourceStatus? sourceStatus = default, IEnumerable<ConnectionStateSnapshot> states = default)
        {
            return new ConnectionMonitorQueryResult();
        }

        /// <summary> Initializes a new instance of <see cref="Models.ConnectionStateSnapshot"/>. </summary>
        public static ConnectionStateSnapshot ConnectionStateSnapshot(NetworkConnectionState? networkConnectionState = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, EvaluationState? evaluationState = default, long? avgLatencyInMs = default, long? minLatencyInMs = default, long? maxLatencyInMs = default, long? probesSent = default, long? probesFailed = default, IEnumerable<ConnectivityHopInfo> hops = default)
        {
            return new ConnectionStateSnapshot();
        }

        /// <summary> Initializes a new instance of <see cref="Models.InboundSecurityRule"/>. </summary>
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, ETag? etag = default, IEnumerable<InboundSecurityRules> rules = default, NetworkProvisioningState? provisioningState = default)
        {
            return InboundSecurityRule(id, name, resourceType, etag, default, rules, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Models.InboundSecurityRule"/>. </summary>
        public static InboundSecurityRule InboundSecurityRule(ResourceIdentifier id = default, string name = default, ResourceType? resourceType = default, ETag? etag = default, InboundSecurityRuleType? ruleType = default, IEnumerable<InboundSecurityRules> rules = default, NetworkProvisioningState? provisioningState = default)
        {
            var result = new InboundSecurityRule { RuleType = ruleType };
            foreach (var item in rules ?? Enumerable.Empty<InboundSecurityRules>())
            {
                result.Rules.Add(item);
            }
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.PeerRoute"/>. </summary>
        public static PeerRoute PeerRoute(string network = default, string nextHop = default, string sourcePeer = default, string origin = default, string asPath = default, string localAddress = default, int? weight = default)
        {
            return new PeerRoute();
        }

        // Adds the model factory method omitted for the custom canonical shared network manager connection model.
        /// <summary> Initializes a new instance of <see cref="Network.NetworkManagerConnectionData"/>. </summary>
        public static NetworkManagerConnectionData NetworkManagerConnectionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ResourceIdentifier networkManagerId = default, ScopeConnectionState? connectionState = default, string description = default, ETag? etag = default)
        {
            var properties = new NetworkManagerConnectionProperties(networkManagerId, connectionState, description, default);
            return new NetworkManagerConnectionData(id, name, resourceType, systemData, properties, etag, default);
        }

        // Restores the released subscription-specific factory API over the canonical shared connection model.
        /// <summary> Initializes a new instance of <see cref="Network.SubscriptionNetworkManagerConnectionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use NetworkManagerConnectionData instead.")]
        public static SubscriptionNetworkManagerConnectionData SubscriptionNetworkManagerConnectionData(ResourceIdentifier id = default, string name = default, string type = default, string eTag = default, ResourceIdentifier networkManagerId = default, ScopeConnectionState? connectionState = default, string description = default, SystemData systemData = default)
        {
            var properties = new NetworkManagerConnectionProperties(networkManagerId, connectionState, description, default);
            return new SubscriptionNetworkManagerConnectionData(id, name, type, eTag, default, properties, systemData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PeerRouteList"/>. </summary>
        /// <param name="localAddress"> The peer's local address. </param>
        /// <param name="network"> The route's network prefix. </param>
        /// <param name="nextHop"> The route's next hop. </param>
        /// <param name="sourcePeer"> The peer this route was learned from. </param>
        /// <param name="origin"> The source this route was learned from. </param>
        /// <param name="asPath"> The route's AS path sequence. </param>
        /// <param name="weight"> The route's weight. </param>
        /// <returns> A new <see cref="Models.PeerRouteList"/> instance for mocking. </returns>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `ArmNetworkModelFactory.PeerRoute` instead.", false)]
        public static PeerRouteList PeerRouteList(string localAddress = default, string network = default, string nextHop = default, string sourcePeer = default, string origin = default, string asPath = default, int? weight = default)
        {
            return new PeerRouteList(localAddress, network, nextHop, sourcePeer, origin, asPath, weight, default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.EffectiveNetworkSecurityGroup"/>. </summary>
        /// <param name="networkSecurityGroupId"> Resource ID. </param>
        /// <param name="association"> Associated resources. </param>
        /// <param name="effectiveSecurityRules"> A collection of effective security rules. </param>
        /// <param name="tagMap"> Mapping of tags to list of IP Addresses included within the tag. </param>
        /// <returns> A new <see cref="Models.EffectiveNetworkSecurityGroup"/> instance for mocking. </returns>
        public static EffectiveNetworkSecurityGroup EffectiveNetworkSecurityGroup(ResourceIdentifier networkSecurityGroupId = default, EffectiveNetworkSecurityGroupAssociation association = default, IEnumerable<EffectiveNetworkSecurityRule> effectiveSecurityRules = default, string tagMap = default)
        {
            return new EffectiveNetworkSecurityGroup(
                networkSecurityGroupId is null ? default : new NetworkSubResource(networkSecurityGroupId, default),
                association,
                (effectiveSecurityRules ?? new ChangeTrackingList<EffectiveNetworkSecurityRule>()).ToList(),
                tagMap,
                default);
        }
    }
}
